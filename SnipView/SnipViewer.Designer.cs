﻿namespace SnipView
{
    partial class SnipViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // SnipViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 114);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SnipViewer";
            StartPosition = FormStartPosition.Manual;
            Text = "SnipViewer";
            TopMost = true;
            Load += SnipViewer_Load;
            KeyDown += SnipViewer_KeyDown;
            MouseDown += SnipViewer_MouseDown;
            MouseMove += SnipViewer_MouseMove;
            MouseUp += SnipViewer_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}