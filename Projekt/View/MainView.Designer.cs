namespace Projekt.View
{
    partial class MainView
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
            pnlImages = new Panel();
            SuspendLayout();
            // 
            // pnlImages
            // 
            pnlImages.Dock = DockStyle.Bottom;
            pnlImages.Location = new Point(0, 521);
            pnlImages.Name = "pnlImages";
            pnlImages.Size = new Size(923, 184);
            pnlImages.TabIndex = 14;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(923, 705);
            Controls.Add(pnlImages);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kamera";
            FormClosing += MainView_FormClosing;
            Load += MainView_Load;
            ResumeLayout(false);
        }

        #endregion
        private View.CameraControl CameraControl;
        public Panel pnlImages;
    }
}