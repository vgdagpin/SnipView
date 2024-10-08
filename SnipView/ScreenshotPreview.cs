namespace SnipView
{
    public partial class ScreenshotPreview : Form
    {
        public event EventHandler<SnipViewer>? OnSnipCaptured;
        public event EventHandler<SnipViewer>? OnSnipClosed;


        private Bitmap? screenshotBitmap;
        protected Bitmap ScreenshotBitmap
        {
            get
            {
                if (screenshotBitmap == null)
                {
                    screenshotBitmap = new Bitmap(Bounds.Width, Bounds.Height);
                }

                return screenshotBitmap;
            }
        }

        private Graphics? screenshotGrapics = null;
        protected Graphics ScreenshotGraphics
        {
            get
            {
                if (screenshotGrapics == null)
                {
                    screenshotGrapics = Graphics.FromImage(ScreenshotBitmap);
                }

                return screenshotGrapics;
            }
        }

        public ScreenshotPreview()
        {
            InitializeComponent();            
        }

        public new void Show()
        {
            ScreenshotGraphics.CopyFromScreen(Bounds.Location, Point.Empty, Bounds.Size);
            BackgroundImage = ScreenshotBitmap;

            Visible = true;

            var snipTool = new SnippingToolForm(this);

            snipTool.OnSnipCaptured += OnSnipCaptured;
            snipTool.OnSnipClosed += OnSnipClosed;

            snipTool.Show();
        }

        public new void Close()
        {
            Visible = false;
        }
    }
}
