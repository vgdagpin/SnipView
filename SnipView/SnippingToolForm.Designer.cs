﻿namespace SnipView
{
    partial class SnippingToolForm
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
            components = new System.ComponentModel.Container();
            tmrOpacity = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tmrOpacity
            // 
            tmrOpacity.Enabled = true;
            tmrOpacity.Interval = 50;
            tmrOpacity.Tick += tmrOpacity_Tick;
            // 
            // SnippingToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(321, 160);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SnippingToolForm";
            Opacity = 0D;
            Text = "SnippingToolForm";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer tmrOpacity;
    }
}