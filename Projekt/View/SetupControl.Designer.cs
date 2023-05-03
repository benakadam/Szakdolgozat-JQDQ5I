namespace Projekt.View
{
    partial class SetupControl
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
            btnCamera = new Button();
            label3 = new Label();
            cboCameras = new ComboBox();
            txtSavePicturesPath = new TextBox();
            txtPythonPath = new TextBox();
            btnSavePicturesPath = new Button();
            btnPythonPath = new Button();
            btnSave = new Button();
            pnlSettings = new Panel();
            label1 = new Label();
            txtStationID = new TextBox();
            pnlDetails = new Panel();
            txtISBN = new TextBox();
            txtWeight = new TextBox();
            txtWidth = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtHeight = new TextBox();
            label2 = new Label();
            pnlSettings.SuspendLayout();
            pnlDetails.SuspendLayout();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Size = new Size(66, 22);
            // 
            // btnMinimize
            // 
            btnMinimize.Margin = new Padding(3, 2, 3, 2);
            btnMinimize.Size = new Size(66, 22);
            // 
            // titleBar
            // 
            titleBar.Margin = new Padding(3, 2, 3, 2);
            titleBar.Size = new Size(331, 22);
            // 
            // btnCamera
            // 
            btnCamera.BackColor = SystemColors.ActiveBorder;
            btnCamera.FlatAppearance.BorderSize = 0;
            btnCamera.FlatStyle = FlatStyle.Flat;
            btnCamera.Font = new Font("Berlin Sans FB", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnCamera.ForeColor = Color.White;
            btnCamera.Location = new Point(255, 274);
            btnCamera.Margin = new Padding(3, 2, 3, 2);
            btnCamera.Name = "btnCamera";
            btnCamera.Size = new Size(209, 143);
            btnCamera.TabIndex = 0;
            btnCamera.Text = "Kamera";
            btnCamera.UseVisualStyleBackColor = false;
            btnCamera.Click += btnCamera_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 118);
            label3.Name = "label3";
            label3.Size = new Size(145, 18);
            label3.TabIndex = 14;
            label3.Text = "Kiválasztott kamera:";
            // 
            // cboCameras
            // 
            cboCameras.FormattingEnabled = true;
            cboCameras.Location = new Point(204, 116);
            cboCameras.Margin = new Padding(3, 2, 3, 2);
            cboCameras.Name = "cboCameras";
            cboCameras.Size = new Size(146, 26);
            cboCameras.TabIndex = 13;
            // 
            // txtSavePicturesPath
            // 
            txtSavePicturesPath.Enabled = false;
            txtSavePicturesPath.Location = new Point(167, 72);
            txtSavePicturesPath.Margin = new Padding(3, 2, 3, 2);
            txtSavePicturesPath.Name = "txtSavePicturesPath";
            txtSavePicturesPath.Size = new Size(608, 25);
            txtSavePicturesPath.TabIndex = 11;
            // 
            // txtPythonPath
            // 
            txtPythonPath.Enabled = false;
            txtPythonPath.Location = new Point(167, 25);
            txtPythonPath.Margin = new Padding(3, 2, 3, 2);
            txtPythonPath.Name = "txtPythonPath";
            txtPythonPath.Size = new Size(606, 25);
            txtPythonPath.TabIndex = 9;
            // 
            // btnSavePicturesPath
            // 
            btnSavePicturesPath.ForeColor = Color.Black;
            btnSavePicturesPath.Location = new Point(24, 65);
            btnSavePicturesPath.Margin = new Padding(3, 2, 3, 2);
            btnSavePicturesPath.Name = "btnSavePicturesPath";
            btnSavePicturesPath.Size = new Size(137, 35);
            btnSavePicturesPath.TabIndex = 15;
            btnSavePicturesPath.Text = "Képek mentése:";
            btnSavePicturesPath.UseVisualStyleBackColor = true;
            btnSavePicturesPath.Click += btnSavePicturesPath_Click;
            // 
            // btnPythonPath
            // 
            btnPythonPath.ForeColor = Color.Black;
            btnPythonPath.Location = new Point(24, 18);
            btnPythonPath.Margin = new Padding(3, 2, 3, 2);
            btnPythonPath.Name = "btnPythonPath";
            btnPythonPath.Size = new Size(137, 35);
            btnPythonPath.TabIndex = 16;
            btnPythonPath.Text = "Python útvonal:";
            btnPythonPath.UseVisualStyleBackColor = true;
            btnPythonPath.Click += btnPythonPath_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(673, 102);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(102, 34);
            btnSave.TabIndex = 17;
            btnSave.Text = "Mentés";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // pnlSettings
            // 
            pnlSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSettings.BackColor = SystemColors.ControlDark;
            pnlSettings.Controls.Add(label1);
            pnlSettings.Controls.Add(txtStationID);
            pnlSettings.Controls.Add(btnPythonPath);
            pnlSettings.Controls.Add(btnSave);
            pnlSettings.Controls.Add(txtPythonPath);
            pnlSettings.Controls.Add(txtSavePicturesPath);
            pnlSettings.Controls.Add(btnSavePicturesPath);
            pnlSettings.Controls.Add(cboCameras);
            pnlSettings.Controls.Add(label3);
            pnlSettings.Location = new Point(0, 0);
            pnlSettings.Margin = new Padding(3, 2, 3, 2);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(923, 169);
            pnlSettings.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(372, 118);
            label1.Name = "label1";
            label1.Size = new Size(107, 18);
            label1.TabIndex = 19;
            label1.Text = "Munkaállomás:";
            // 
            // txtStationID
            // 
            txtStationID.Location = new Point(495, 118);
            txtStationID.Name = "txtStationID";
            txtStationID.Size = new Size(128, 25);
            txtStationID.TabIndex = 18;
            // 
            // pnlDetails
            // 
            pnlDetails.BackColor = SystemColors.ActiveBorder;
            pnlDetails.Controls.Add(txtISBN);
            pnlDetails.Controls.Add(txtWeight);
            pnlDetails.Controls.Add(txtWidth);
            pnlDetails.Controls.Add(label6);
            pnlDetails.Controls.Add(label5);
            pnlDetails.Controls.Add(label4);
            pnlDetails.Controls.Add(txtHeight);
            pnlDetails.Controls.Add(label2);
            pnlDetails.Location = new Point(493, 274);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(209, 143);
            pnlDetails.TabIndex = 19;
            // 
            // txtISBN
            // 
            txtISBN.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtISBN.Location = new Point(98, 13);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(95, 25);
            txtISBN.TabIndex = 7;
            // 
            // txtWeight
            // 
            txtWeight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtWeight.Location = new Point(98, 43);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(95, 25);
            txtWeight.TabIndex = 6;
            // 
            // txtWidth
            // 
            txtWidth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtWidth.Location = new Point(98, 106);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(95, 25);
            txtWidth.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 109);
            label6.Name = "label6";
            label6.Size = new Size(71, 18);
            label6.TabIndex = 4;
            label6.Text = "Szélesség:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 77);
            label5.Name = "label5";
            label5.Size = new Size(76, 18);
            label5.TabIndex = 3;
            label5.Text = "Magasság:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 45);
            label4.Name = "label4";
            label4.Size = new Size(38, 18);
            label4.TabIndex = 2;
            label4.Text = "Súly:";
            // 
            // txtHeight
            // 
            txtHeight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHeight.Location = new Point(98, 74);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(95, 25);
            txtHeight.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 16);
            label2.Name = "label2";
            label2.Size = new Size(43, 18);
            label2.TabIndex = 0;
            label2.Text = "ISBN:";
            // 
            // SetupControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlDetails);
            Controls.Add(pnlSettings);
            Controls.Add(btnCamera);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SetupControl";
            Padding = new Padding(22, 19, 22, 19);
            Size = new Size(923, 514);
            Load += SetupControl_Load;
            Controls.SetChildIndex(btnCamera, 0);
            Controls.SetChildIndex(pnlSettings, 0);
            Controls.SetChildIndex(pnlDetails, 0);
            Controls.SetChildIndex(titleBar, 0);
            Controls.SetChildIndex(btnMinimize, 0);
            Controls.SetChildIndex(btnExit, 0);
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCamera;
        private Label label3;
        private ComboBox cboCameras;
        private TextBox txtSavePicturesPath;
        private TextBox txtPythonPath;
        private Button btnSavePicturesPath;
        private Button btnPythonPath;
        private Button btnSave;
        private Panel pnlSettings;
        private Label label1;
        public TextBox txtStationID;
        private Panel pnlDetails;
        private TextBox txtISBN;
        private TextBox txtWeight;
        private TextBox txtWidth;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtHeight;
        private Label label2;
    }
}
