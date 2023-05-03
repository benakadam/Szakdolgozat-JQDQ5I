namespace Projekt.View
{
    partial class CameraControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraControl));
            picboxCamera = new PictureBox();
            picboxCropped = new PictureBox();
            btnSelectPic = new Button();
            btnStart = new Button();
            btnTakePic = new Button();
            btnProcessImage = new Button();
            btnBack = new Button();
            btnSave = new Button();
            cboImageType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picboxCamera).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxCropped).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(858, 0);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Size = new Size(66, 22);
            // 
            // btnMinimize
            // 
            btnMinimize.Location = new Point(787, 0);
            btnMinimize.Margin = new Padding(3, 2, 3, 2);
            btnMinimize.Size = new Size(66, 22);
            // 
            // titleBar
            // 
            titleBar.Margin = new Padding(3, 2, 3, 2);
            titleBar.Size = new Size(396, 22);
            // 
            // picboxCamera
            // 
            picboxCamera.Location = new Point(24, 44);
            picboxCamera.Margin = new Padding(3, 2, 3, 2);
            picboxCamera.Name = "picboxCamera";
            picboxCamera.Size = new Size(414, 406);
            picboxCamera.TabIndex = 0;
            picboxCamera.TabStop = false;
            // 
            // picboxCropped
            // 
            picboxCropped.BackColor = Color.FromArgb(46, 51, 73);
            picboxCropped.Location = new Point(485, 44);
            picboxCropped.Margin = new Padding(3, 2, 3, 2);
            picboxCropped.Name = "picboxCropped";
            picboxCropped.Size = new Size(414, 406);
            picboxCropped.TabIndex = 1;
            picboxCropped.TabStop = false;
            // 
            // btnSelectPic
            // 
            btnSelectPic.ForeColor = Color.Black;
            btnSelectPic.Location = new Point(773, 454);
            btnSelectPic.Margin = new Padding(3, 2, 3, 2);
            btnSelectPic.Name = "btnSelectPic";
            btnSelectPic.Size = new Size(126, 38);
            btnSelectPic.TabIndex = 4;
            btnSelectPic.Text = "Tovább";
            btnSelectPic.UseVisualStyleBackColor = true;
            btnSelectPic.Click += btnSelectPic_Click;
            // 
            // btnStart
            // 
            btnStart.ForeColor = Color.Black;
            btnStart.Location = new Point(312, 454);
            btnStart.Margin = new Padding(3, 2, 3, 2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(126, 38);
            btnStart.TabIndex = 5;
            btnStart.Text = "Újra";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnTakePic
            // 
            btnTakePic.ForeColor = Color.Black;
            btnTakePic.Location = new Point(312, 455);
            btnTakePic.Margin = new Padding(0);
            btnTakePic.Name = "btnTakePic";
            btnTakePic.Size = new Size(126, 38);
            btnTakePic.TabIndex = 7;
            btnTakePic.Text = "Kép készítése";
            btnTakePic.UseVisualStyleBackColor = true;
            btnTakePic.Click += btnTakePic_Click;
            // 
            // btnProcessImage
            // 
            btnProcessImage.BackgroundImage = (Image)resources.GetObject("btnProcessImage.BackgroundImage");
            btnProcessImage.BackgroundImageLayout = ImageLayout.Zoom;
            btnProcessImage.Enabled = false;
            btnProcessImage.ForeColor = Color.Black;
            btnProcessImage.Location = new Point(444, 187);
            btnProcessImage.Margin = new Padding(3, 2, 3, 2);
            btnProcessImage.Name = "btnProcessImage";
            btnProcessImage.Size = new Size(35, 123);
            btnProcessImage.TabIndex = 8;
            btnProcessImage.UseVisualStyleBackColor = true;
            btnProcessImage.Click += btnProcessImage_Click;
            // 
            // btnBack
            // 
            btnBack.ForeColor = Color.Black;
            btnBack.Location = new Point(24, 454);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(126, 38);
            btnBack.TabIndex = 9;
            btnBack.Text = "Vissza";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.BackgroundImage = (Image)resources.GetObject("btnSave.BackgroundImage");
            btnSave.BackgroundImageLayout = ImageLayout.Zoom;
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(485, 455);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 38);
            btnSave.TabIndex = 10;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cboImageType
            // 
            cboImageType.FormattingEnabled = true;
            cboImageType.Items.AddRange(new object[] { "Elsődleges", "Oldal1", "Oldal2", "Hátoldal" });
            cboImageType.Location = new Point(617, 461);
            cboImageType.Name = "cboImageType";
            cboImageType.Size = new Size(129, 26);
            cboImageType.TabIndex = 12;
            // 
            // CameraControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboImageType);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Controls.Add(btnProcessImage);
            Controls.Add(btnTakePic);
            Controls.Add(btnStart);
            Controls.Add(btnSelectPic);
            Controls.Add(picboxCropped);
            Controls.Add(picboxCamera);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CameraControl";
            Padding = new Padding(22, 19, 22, 19);
            Size = new Size(923, 514);
            Load += CameraControl_Load;
            Controls.SetChildIndex(picboxCamera, 0);
            Controls.SetChildIndex(picboxCropped, 0);
            Controls.SetChildIndex(btnSelectPic, 0);
            Controls.SetChildIndex(btnStart, 0);
            Controls.SetChildIndex(btnTakePic, 0);
            Controls.SetChildIndex(btnProcessImage, 0);
            Controls.SetChildIndex(btnBack, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(cboImageType, 0);
            Controls.SetChildIndex(titleBar, 0);
            Controls.SetChildIndex(btnMinimize, 0);
            Controls.SetChildIndex(btnExit, 0);
            ((System.ComponentModel.ISupportInitialize)picboxCamera).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxCropped).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picboxCamera;
        private PictureBox picboxCropped;
        private Button btnSelectPic;
        private Button btnStart;
        private Button btnTakePic;
        private Button btnProcessImage;
        private Button btnBack;
        private Button btnSave;
        private ComboBox cboImageType;
    }
}