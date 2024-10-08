using System.Runtime.InteropServices;

namespace SnipView
{
    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private ScreenshotPreview? screenshotPreview;
        protected ScreenshotPreview ScreenshotPreview
        {
            get
            {
                if (screenshotPreview == null)
                {
                    screenshotPreview = new ScreenshotPreview();
                    screenshotPreview.Bounds = SystemInformation.VirtualScreen;

                    screenshotPreview.OnSnipCaptured += ScreenshotPreview_OnSnipCaptured;
                    screenshotPreview.OnSnipClosed += ScreenshotPreview_OnSnipClosed;
                }

                return screenshotPreview;
            }
        }

        private List<SnipViewer> OpenedSnips = new List<SnipViewer>();

        private static string? defaultDirectory;
        public static string DefaultDirectory
        {
            get
            {
                if (defaultDirectory == null)
                {
                    var defaultDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Snips");

                    if (!Directory.Exists(defaultDir))
                    {
                        Directory.CreateDirectory(defaultDir);
                    }

                    defaultDirectory = defaultDir;
                }

                return defaultDirectory;
            }
        }

        private void ScreenshotPreview_OnSnipClosed(object? sender, SnipViewer e)
        {
            OpenedSnips.Remove(e);

            closeAllToolStripMenuItem.Visible = OpenedSnips.Count > 0;
            saveAllToolStripMenuItem.Visible = OpenedSnips.Count > 0;

            closeAllToolStripMenuItem.Text = $"Close All ({OpenedSnips.Count})";
            saveAllToolStripMenuItem.Text = $"Save All ({OpenedSnips.Count})";
        }

        private void ScreenshotPreview_OnSnipCaptured(object? sender, SnipViewer e)
        {
            OpenedSnips.Add(e);

            closeAllToolStripMenuItem.Visible = OpenedSnips.Count > 0;
            saveAllToolStripMenuItem.Visible = OpenedSnips.Count > 0;

            closeAllToolStripMenuItem.Text = $"Close All ({OpenedSnips.Count})";
            saveAllToolStripMenuItem.Text = $"Save All ({OpenedSnips.Count})";
        }

        public Main()
        {
            InitializeComponent();

            /*
              MOD_ALT: 0x0001
              MOD_CONTROL: 0x0002
              MOD_SHIFT: 0x0004
              MOD_WIN: 0x0008
            */

            RegisterHotKey(Handle, 1, 12, (int)Keys.Z);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                if (m.WParam.ToInt32() == 1)
                {
                    ScreenshotPreview.Show();
                }
            }

            base.WndProc(ref m);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, 1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continue to close SnipView?", "Close SnipView", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Close();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = OpenedSnips.ToArray();

            foreach (var item in temp)
            {
                item.Close();
            }
        }

        private void snipsManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SnipsManager().Show();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ScreenshotPreview.Show();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = OpenedSnips.ToArray();

            foreach (var item in temp)
            {
                item.Save(group: DateTime.Now.ToString("yyyy-dd-MM HHmmss"));
            }
        }

        private void snipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenshotPreview.Show();
        }
    }
}
