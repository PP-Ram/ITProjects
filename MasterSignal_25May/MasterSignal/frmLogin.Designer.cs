namespace MasterSignal
{
    partial class frmLogin
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.rdoCusRole = new System.Windows.Forms.RadioButton();
            this.rdoUserRole = new System.Windows.Forms.RadioButton();
            this.lnkNewUser = new System.Windows.Forms.LinkLabel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpNewUser = new System.Windows.Forms.GroupBox();
            this.lnkBack = new System.Windows.Forms.LinkLabel();
            this.lblHeading2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewConPass = new System.Windows.Forms.TextBox();
            this.lblNewConPassword = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtNewUN = new System.Windows.Forms.TextBox();
            this.lblNewUserName = new System.Windows.Forms.Label();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpNewUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(24, 45);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(85, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(24, 100);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 20);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserName.Location = new System.Drawing.Point(130, 40);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(190, 29);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(130, 88);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(190, 29);
            this.txtPassword.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(49, 143);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(183, 143);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 31);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.rdoCusRole);
            this.grpLogin.Controls.Add(this.rdoUserRole);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.btnCancel);
            this.grpLogin.Controls.Add(this.lnkNewUser);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.txtUserName);
            this.grpLogin.Controls.Add(this.lblPassword);
            this.grpLogin.Controls.Add(this.lblUserName);
            this.grpLogin.Location = new System.Drawing.Point(53, 79);
            this.grpLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLogin.Size = new System.Drawing.Size(350, 217);
            this.grpLogin.TabIndex = 3;
            this.grpLogin.TabStop = false;
            // 
            // rdoCusRole
            // 
            this.rdoCusRole.AutoSize = true;
            this.rdoCusRole.Location = new System.Drawing.Point(88, 183);
            this.rdoCusRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoCusRole.Name = "rdoCusRole";
            this.rdoCusRole.Size = new System.Drawing.Size(93, 24);
            this.rdoCusRole.TabIndex = 17;
            this.rdoCusRole.TabStop = true;
            this.rdoCusRole.Text = "Customer";
            this.rdoCusRole.UseVisualStyleBackColor = true;
            // 
            // rdoUserRole
            // 
            this.rdoUserRole.AutoSize = true;
            this.rdoUserRole.Checked = true;
            this.rdoUserRole.Location = new System.Drawing.Point(10, 181);
            this.rdoUserRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoUserRole.Name = "rdoUserRole";
            this.rdoUserRole.Size = new System.Drawing.Size(59, 24);
            this.rdoUserRole.TabIndex = 16;
            this.rdoUserRole.TabStop = true;
            this.rdoUserRole.Text = "User";
            this.rdoUserRole.UseVisualStyleBackColor = true;
            // 
            // lnkNewUser
            // 
            this.lnkNewUser.AutoSize = true;
            this.lnkNewUser.Location = new System.Drawing.Point(234, 187);
            this.lnkNewUser.Name = "lnkNewUser";
            this.lnkNewUser.Size = new System.Drawing.Size(119, 20);
            this.lnkNewUser.TabIndex = 15;
            this.lnkNewUser.TabStop = true;
            this.lnkNewUser.Text = "Create New User";
            this.lnkNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewUser_LinkClicked);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(78, 21);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(61, 44);
            this.picLogo.TabIndex = 14;
            this.picLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(144, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Smart Forex App";
            // 
            // grpNewUser
            // 
            this.grpNewUser.Controls.Add(this.lnkBack);
            this.grpNewUser.Controls.Add(this.lblHeading2);
            this.grpNewUser.Controls.Add(this.btnClear);
            this.grpNewUser.Controls.Add(this.btnNewUser);
            this.grpNewUser.Controls.Add(this.lblEmailAddress);
            this.grpNewUser.Controls.Add(this.txtEmail);
            this.grpNewUser.Controls.Add(this.lblPhoneNo);
            this.grpNewUser.Controls.Add(this.txtPhone);
            this.grpNewUser.Controls.Add(this.lblNewPassword);
            this.grpNewUser.Controls.Add(this.txtNewConPass);
            this.grpNewUser.Controls.Add(this.lblNewConPassword);
            this.grpNewUser.Controls.Add(this.txtNewPass);
            this.grpNewUser.Controls.Add(this.txtNewUN);
            this.grpNewUser.Controls.Add(this.lblNewUserName);
            this.grpNewUser.Location = new System.Drawing.Point(46, 84);
            this.grpNewUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpNewUser.Name = "grpNewUser";
            this.grpNewUser.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpNewUser.Size = new System.Drawing.Size(355, 357);
            this.grpNewUser.TabIndex = 16;
            this.grpNewUser.TabStop = false;
            // 
            // lnkBack
            // 
            this.lnkBack.AutoSize = true;
            this.lnkBack.Location = new System.Drawing.Point(258, 325);
            this.lnkBack.Name = "lnkBack";
            this.lnkBack.Size = new System.Drawing.Size(99, 20);
            this.lnkBack.TabIndex = 100;
            this.lnkBack.TabStop = true;
            this.lnkBack.Text = "Back to Login";
            this.lnkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBack_LinkClicked);
            // 
            // lblHeading2
            // 
            this.lblHeading2.AutoSize = true;
            this.lblHeading2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeading2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblHeading2.Location = new System.Drawing.Point(25, 25);
            this.lblHeading2.Name = "lblHeading2";
            this.lblHeading2.Size = new System.Drawing.Size(156, 28);
            this.lblHeading2.TabIndex = 0;
            this.lblHeading2.Text = "Create New User";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(31, 291);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 31);
            this.btnClear.TabIndex = 70;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(186, 291);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(125, 31);
            this.btnNewUser.TabIndex = 60;
            this.btnNewUser.Text = "Create New User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(25, 249);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(103, 20);
            this.lblEmailAddress.TabIndex = 0;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(151, 237);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(159, 27);
            this.txtEmail.TabIndex = 50;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(25, 204);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(108, 20);
            this.lblPhoneNo.TabIndex = 0;
            this.lblPhoneNo.Text = "Phone Number";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(151, 193);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(159, 27);
            this.txtPhone.TabIndex = 40;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(25, 113);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(70, 20);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "Password";
            // 
            // txtNewConPass
            // 
            this.txtNewConPass.Location = new System.Drawing.Point(151, 149);
            this.txtNewConPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewConPass.Name = "txtNewConPass";
            this.txtNewConPass.PasswordChar = '*';
            this.txtNewConPass.Size = new System.Drawing.Size(159, 27);
            this.txtNewConPass.TabIndex = 30;
            // 
            // lblNewConPassword
            // 
            this.lblNewConPassword.AutoSize = true;
            this.lblNewConPassword.Location = new System.Drawing.Point(23, 159);
            this.lblNewConPassword.Name = "lblNewConPassword";
            this.lblNewConPassword.Size = new System.Drawing.Size(127, 20);
            this.lblNewConPassword.TabIndex = 0;
            this.lblNewConPassword.Text = "Confirm Password";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(151, 105);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(159, 27);
            this.txtNewPass.TabIndex = 20;
            // 
            // txtNewUN
            // 
            this.txtNewUN.Location = new System.Drawing.Point(151, 61);
            this.txtNewUN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewUN.Name = "txtNewUN";
            this.txtNewUN.Size = new System.Drawing.Size(159, 27);
            this.txtNewUN.TabIndex = 10;
            // 
            // lblNewUserName
            // 
            this.lblNewUserName.AutoSize = true;
            this.lblNewUserName.Location = new System.Drawing.Point(25, 68);
            this.lblNewUserName.Name = "lblNewUserName";
            this.lblNewUserName.Size = new System.Drawing.Size(85, 20);
            this.lblNewUserName.TabIndex = 0;
            this.lblNewUserName.Text = "User Name:";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(447, 457);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.grpNewUser);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForexSmartApp";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpNewUser.ResumeLayout(false);
            this.grpNewUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkNewUser;
        private System.Windows.Forms.GroupBox grpNewUser;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewConPass;
        private System.Windows.Forms.Label lblNewConPassword;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtNewUN;
        private System.Windows.Forms.Label lblNewUserName;
        private System.Windows.Forms.Label lblHeading2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.LinkLabel lnkBack;
        private System.Windows.Forms.RadioButton rdoCusRole;
        private System.Windows.Forms.RadioButton rdoUserRole;
    }
}