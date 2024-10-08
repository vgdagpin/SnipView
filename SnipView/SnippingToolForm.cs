namespace SnipView
{
    public partial class SnippingToolForm : Form
    {
        private Point startPoint;
        private Rectangle selectionRectangle;
        private bool isSelecting;

        protected ScreenshotPreview ScreenshotPreview { get; private set; }

        public event EventHandler<SnipViewer>? OnSnipCaptured;
        public event EventHandler<SnipViewer>? OnSnipClosed;

        public SnippingToolForm(ScreenshotPreview screenshotPreview)
        {
            ScreenshotPreview = screenshotPreview;

            InitializeComponent();

            Bounds = SystemInformation.VirtualScreen;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                ScreenshotPreview.Close();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                isSelecting = true;
                selectionRectangle = new Rectangle(e.Location, new Size(0, 0));
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isSelecting)
            {
                selectionRectangle = new Rectangle(
                    Math.Min(startPoint.X, e.X),
                    Math.Min(startPoint.Y, e.Y),
                    Math.Abs(startPoint.X - e.X),
                    Math.Abs(startPoint.Y - e.Y));
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isSelecting = false;
                Close();
                CaptureScreenshot();
                ScreenshotPreview.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (isSelecting)
            {
                using (Pen pen = new Pen(Color.White, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
            }
        }

        private void CaptureScreenshot()
        {
            if (selectionRectangle.Width > 0 && selectionRectangle.Height > 0)
            {
                using (Bitmap bitmap = new Bitmap(selectionRectangle.Width, selectionRectangle.Height))
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(selectionRectangle.Location, Point.Empty, selectionRectangle.Size);

                    var vwr = new SnipViewer
                    {
                        Size = selectionRectangle.Size,
                        Location = selectionRectangle.Location,
                        BackgroundImage = (Image)bitmap.Clone()
                    };

                    vwr.FormClosed += (sender, e) =>
                    {
                        OnSnipClosed?.Invoke(sender,(SnipViewer)sender!);
                    };

                    vwr.Show();

                    OnSnipCaptured?.Invoke(this, vwr);
                }
            }
        }

        private void tmrOpacity_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 0.3D)
            {
                Cursor = Cursors.Cross;
                tmrOpacity.Enabled = false;
            }

            Opacity += 0.1D;
        }
    }
}