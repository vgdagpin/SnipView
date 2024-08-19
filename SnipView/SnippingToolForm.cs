using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnipView
{
    public partial class SnippingToolForm : Form
    {
        private Point startPoint;
        private Rectangle selectionRectangle;
        private bool isSelecting;

        public SnippingToolForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal; // Change to Normal to set custom bounds
            this.Bounds = System.Windows.Forms.SystemInformation.VirtualScreen; // Set to cover all screens
            this.BackColor = Color.White;
            this.Opacity = 0.5;
            this.TopMost = true;
            this.Cursor = Cursors.Cross;
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
                this.Close();
                CaptureScreenshot();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (isSelecting)
            {
                using (Pen pen = new Pen(Color.Red, 2))
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
                        FormBorderStyle = FormBorderStyle.None,
                        Size = selectionRectangle.Size,
                        Location = selectionRectangle.Location,
                        StartPosition = FormStartPosition.Manual,
                        BackgroundImage = (Image)bitmap.Clone()
                    };

                    vwr.Show();
                }
            }
        }
    }
}