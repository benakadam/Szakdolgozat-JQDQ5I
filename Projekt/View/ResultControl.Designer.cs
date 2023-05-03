namespace Projekt.View
{
    partial class ResultControl
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
            txtTitle = new TextBox();
            btnSend = new Button();
            btnBack = new Button();
            btnSearch = new Button();
            dgdSearchResult = new DataGridView();
            btnRestart = new Button();
            txtWeight = new TextBox();
            txtHeight = new TextBox();
            txtWidth = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pnlDimensions = new Panel();
            label4 = new Label();
            label5 = new Label();
            txtISBN = new TextBox();
            txtAuthor = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdSearchResult).BeginInit();
            pnlDimensions.SuspendLayout();
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
            titleBar.Size = new Size(360, 22);
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(87, 45);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(243, 25);
            txtTitle.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.ForeColor = Color.Black;
            btnSend.Location = new Point(773, 454);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(126, 46);
            btnSend.TabIndex = 3;
            btnSend.Text = "Adatok küldése";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(24, 454);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(126, 46);
            btnBack.TabIndex = 4;
            btnBack.Text = "Vissza";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(417, 77);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(148, 41);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Keresés";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgdSearchResult
            // 
            dgdSearchResult.AllowUserToAddRows = false;
            dgdSearchResult.AllowUserToDeleteRows = false;
            dgdSearchResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgdSearchResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdSearchResult.Location = new Point(24, 148);
            dgdSearchResult.Name = "dgdSearchResult";
            dgdSearchResult.ReadOnly = true;
            dgdSearchResult.RowHeadersWidth = 51;
            dgdSearchResult.RowTemplate.Height = 25;
            dgdSearchResult.Size = new Size(874, 300);
            dgdSearchResult.TabIndex = 6;
            dgdSearchResult.CellClick += dgdSearchResult_CellClick;
            // 
            // btnRestart
            // 
            btnRestart.ForeColor = Color.Black;
            btnRestart.Location = new Point(773, 454);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(126, 46);
            btnRestart.TabIndex = 7;
            btnRestart.Text = "Új termék";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Visible = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // txtWeight
            // 
            txtWeight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtWeight.Location = new Point(97, 12);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(131, 25);
            txtWeight.TabIndex = 8;
            // 
            // txtHeight
            // 
            txtHeight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHeight.Location = new Point(97, 38);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(131, 25);
            txtHeight.TabIndex = 9;
            // 
            // txtWidth
            // 
            txtWidth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtWidth.Location = new Point(97, 64);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(131, 25);
            txtWidth.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 12);
            label1.Name = "label1";
            label1.Size = new Size(38, 18);
            label1.TabIndex = 11;
            label1.Text = "Súly:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 39);
            label2.Name = "label2";
            label2.Size = new Size(76, 18);
            label2.TabIndex = 12;
            label2.Text = "Magasság:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 67);
            label3.Name = "label3";
            label3.Size = new Size(71, 18);
            label3.TabIndex = 13;
            label3.Text = "Szélesség:";
            // 
            // pnlDimensions
            // 
            pnlDimensions.AutoSize = true;
            pnlDimensions.BackColor = SystemColors.ControlDark;
            pnlDimensions.Controls.Add(label1);
            pnlDimensions.Controls.Add(label3);
            pnlDimensions.Controls.Add(txtWeight);
            pnlDimensions.Controls.Add(label2);
            pnlDimensions.Controls.Add(txtHeight);
            pnlDimensions.Controls.Add(txtWidth);
            pnlDimensions.Location = new Point(661, 45);
            pnlDimensions.Margin = new Padding(3, 2, 3, 2);
            pnlDimensions.Name = "pnlDimensions";
            pnlDimensions.Size = new Size(237, 98);
            pnlDimensions.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 48);
            label4.Name = "label4";
            label4.Size = new Size(38, 18);
            label4.TabIndex = 15;
            label4.Text = "Cím:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(344, 48);
            label5.Name = "label5";
            label5.Size = new Size(43, 18);
            label5.TabIndex = 16;
            label5.Text = "ISBN:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(396, 46);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(169, 25);
            txtISBN.TabIndex = 17;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(87, 75);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(243, 25);
            txtAuthor.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 77);
            label6.Name = "label6";
            label6.Size = new Size(54, 18);
            label6.TabIndex = 18;
            label6.Text = "Szerző:";
            // 
            // ResultControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtAuthor);
            Controls.Add(label6);
            Controls.Add(txtISBN);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pnlDimensions);
            Controls.Add(btnRestart);
            Controls.Add(dgdSearchResult);
            Controls.Add(btnSearch);
            Controls.Add(btnBack);
            Controls.Add(btnSend);
            Controls.Add(txtTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ResultControl";
            Padding = new Padding(22, 19, 22, 19);
            Size = new Size(923, 514);
            Controls.SetChildIndex(txtTitle, 0);
            Controls.SetChildIndex(btnSend, 0);
            Controls.SetChildIndex(btnBack, 0);
            Controls.SetChildIndex(btnSearch, 0);
            Controls.SetChildIndex(dgdSearchResult, 0);
            Controls.SetChildIndex(btnRestart, 0);
            Controls.SetChildIndex(pnlDimensions, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtISBN, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(txtAuthor, 0);
            Controls.SetChildIndex(titleBar, 0);
            Controls.SetChildIndex(btnMinimize, 0);
            Controls.SetChildIndex(btnExit, 0);
            ((System.ComponentModel.ISupportInitialize)dgdSearchResult).EndInit();
            pnlDimensions.ResumeLayout(false);
            pnlDimensions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTitle;
        private Button btnSend;
        private Button btnBack;
        private Button btnSearch;
        private DataGridView dgdSearchResult;
        private Button btnRestart;
        private TextBox txtWeight;
        private TextBox txtHeight;
        private TextBox txtWidth;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel pnlDimensions;
        private Label label4;
        private Label label5;
        private TextBox txtISBN;
        private TextBox txtAuthor;
        private Label label6;
    }
}
