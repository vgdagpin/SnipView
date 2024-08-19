using System.Runtime.InteropServices;

namespace SnipView
{
    public partial class SnipViewer : Form
    {
        private bool isDragging = false;
        private Point dragStartPoint = Point.Empty;
        private bool isDrawing = false;
        private Point previousPoint = Point.Empty;
        private Bitmap drawingBitmap = null!;
        private Graphics drawingGraphics = null!;

        private Stack<Bitmap> undoStack = new Stack<Bitmap>();

        public SnipViewer()
        {
            InitializeComponent();          
        }

        private void SnipViewer_Load(object sender, EventArgs e)
        {
            ApplyShadow();

            if (BackgroundImage != null)
            {
                drawingBitmap = new Bitmap(BackgroundImage);
                drawingGraphics = Graphics.FromImage(drawingBitmap);

                BackgroundImage = drawingBitmap;
            }
        }

        private void SnipViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Alt)
                {
                    isDrawing = true;
                    previousPoint = e.Location;

                    // Push the current state onto the undo stack
                    undoStack.Push((Bitmap)drawingBitmap.Clone());
                }
                else
                {
                    isDragging = true;
                    dragStartPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void SnipViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = this.Location;
                newLocation.X += e.X - dragStartPoint.X;
                newLocation.Y += e.Y - dragStartPoint.Y;
                this.Location = newLocation;
            }
            else if (isDrawing)
            {
                if (drawingGraphics != null)
                {
                    drawingGraphics.DrawLine(Pens.Red, previousPoint, e.Location);
                    previousPoint = e.Location;
                    this.Invalidate(); // Refresh the form to show the drawing
                }
            }
        }

        private void SnipViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isDrawing)
                {
                    isDrawing = false;
                }
                else
                {
                    isDragging = false;
                }
            }
        }

        private void ApplyShadow()
        {
            var v = 2;
            DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
            var margins = new MARGINS()
            {
                cyBottomHeight = 1,
                cxLeftWidth = 1,
                cxRightWidth = 1,
                cyTopHeight = 1
            };
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        private void SnipViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X))
            {
                Clipboard.SetImage(BackgroundImage!);
                Close();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                using (var fileDialog = new SaveFileDialog())
                {
                    var defaultDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Snips");

                    if (!Directory.Exists(defaultDir))
                    {
                        Directory.CreateDirectory(defaultDir);
                    }

                    fileDialog.AddExtension = true;
                    fileDialog.FileName = "Snip-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    fileDialog.DefaultExt = "png";
                    fileDialog.Filter = "PNG Image|*.png";
                    fileDialog.InitialDirectory = defaultDir;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        BackgroundImage!.Save(fileDialog.FileName);
                        Close();
                    }
                }
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                UndoLastAction();
            }
        }

        private void UndoLastAction()
        {
            if (undoStack.Count > 0)
            {
                drawingBitmap = undoStack.Pop();
                drawingGraphics = Graphics.FromImage(drawingBitmap);
                BackgroundImage = drawingBitmap;
                Invalidate(); // Refresh the form to show the restored state
            }
        }

        private struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }
    }
}
