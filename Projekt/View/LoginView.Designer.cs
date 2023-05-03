namespace Projekt.View
{
    partial class LoginView
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
            btnLogin = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            txtLoginPassword = new TextBox();
            txtLoginUsername = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(14, 164);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(105, 40);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Belépés";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(323, 164);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Mégsem";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 40);
            label1.Name = "label1";
            label1.Size = new Size(173, 28);
            label1.TabIndex = 2;
            label1.Text = "Bejelentkezési név:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(14, 83);
            label2.Name = "label2";
            label2.Size = new Size(67, 28);
            label2.TabIndex = 3;
            label2.Text = "Jelszó:";
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Location = new Point(193, 84);
            txtLoginPassword.Margin = new Padding(3, 4, 3, 4);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.PasswordChar = '*';
            txtLoginPassword.Size = new Size(229, 27);
            txtLoginPassword.TabIndex = 1;
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.Location = new Point(193, 41);
            txtLoginUsername.Margin = new Padding(3, 4, 3, 4);
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(229, 27);
            txtLoginUsername.TabIndex = 0;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 217);
            Controls.Add(txtLoginUsername);
            Controls.Add(txtLoginPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bejelentkezés";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private TextBox txtLoginPassword;
        private TextBox txtLoginUsername;
    }
}