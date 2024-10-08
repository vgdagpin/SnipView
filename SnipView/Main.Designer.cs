namespace SnipView
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            snipsManagerToolStripMenuItem = new ToolStripMenuItem();
            saveAllToolStripMenuItem = new ToolStripMenuItem();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            snipToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "SnipView";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { snipToolStripMenuItem, snipsManagerToolStripMenuItem, saveAllToolStripMenuItem, closeAllToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 142);
            // 
            // snipsManagerToolStripMenuItem
            // 
            snipsManagerToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            snipsManagerToolStripMenuItem.Name = "snipsManagerToolStripMenuItem";
            snipsManagerToolStripMenuItem.Size = new Size(180, 22);
            snipsManagerToolStripMenuItem.Text = "Snips Manager";
            snipsManagerToolStripMenuItem.Click += snipsManagerToolStripMenuItem_Click;
            // 
            // saveAllToolStripMenuItem
            // 
            saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            saveAllToolStripMenuItem.Size = new Size(180, 22);
            saveAllToolStripMenuItem.Text = "Save All";
            saveAllToolStripMenuItem.Visible = false;
            saveAllToolStripMenuItem.Click += saveAllToolStripMenuItem_Click;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(180, 22);
            closeAllToolStripMenuItem.Text = "Close All";
            closeAllToolStripMenuItem.Visible = false;
            closeAllToolStripMenuItem.Click += closeAllToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // snipToolStripMenuItem
            // 
            snipToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            snipToolStripMenuItem.Name = "snipToolStripMenuItem";
            snipToolStripMenuItem.ShortcutKeyDisplayString = "Win+Shift+Z";
            snipToolStripMenuItem.Size = new Size(180, 22);
            snipToolStripMenuItem.Text = "Snip";
            snipToolStripMenuItem.Click += snipToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 209);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Main";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Form1";
            WindowState = FormWindowState.Minimized;
            FormClosing += Main_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem snipsManagerToolStripMenuItem;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem saveAllToolStripMenuItem;
        private ToolStripMenuItem snipToolStripMenuItem;
    }
}
