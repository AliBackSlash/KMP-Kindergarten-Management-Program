namespace K_M_S_PROGRAM
{
    partial class Login_Screen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Screen));
            this.lbError = new System.Windows.Forms.Label();
            this.lbProgramName = new System.Windows.Forms.Label();
            this.btLogin = new Guna.UI2.WinForms.Guna2Button();
            this.ckRemember = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picShowIcon = new System.Windows.Forms.PictureBox();
            this.TxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picShowIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbError
            // 
            this.lbError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lbError.Location = new System.Drawing.Point(306, 199);
            this.lbError.Name = "lbError";
            this.lbError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbError.Size = new System.Drawing.Size(247, 19);
            this.lbError.TabIndex = 11;
            this.lbError.Text = "ادخل إسم المستخدم و كلمة المرور";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbProgramName
            // 
            this.lbProgramName.Font = new System.Drawing.Font("Times New Roman", 33F, System.Drawing.FontStyle.Bold);
            this.lbProgramName.ForeColor = System.Drawing.Color.Black;
            this.lbProgramName.Location = new System.Drawing.Point(306, 18);
            this.lbProgramName.Name = "lbProgramName";
            this.lbProgramName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbProgramName.Size = new System.Drawing.Size(247, 68);
            this.lbProgramName.TabIndex = 18;
            this.lbProgramName.Text = "K-M-P";
            this.lbProgramName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btLogin
            // 
            this.btLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLogin.Animated = true;
            this.btLogin.BorderColor = System.Drawing.Color.White;
            this.btLogin.BorderRadius = 8;
            this.btLogin.BorderThickness = 1;
            this.btLogin.CheckedState.Parent = this.btLogin;
            this.btLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLogin.CustomImages.Parent = this.btLogin;
            this.btLogin.FillColor = System.Drawing.Color.Blue;
            this.btLogin.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btLogin.ForeColor = System.Drawing.Color.White;
            this.btLogin.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.btLogin.HoverState.FillColor = System.Drawing.Color.White;
            this.btLogin.HoverState.ForeColor = System.Drawing.Color.Blue;
            this.btLogin.HoverState.Parent = this.btLogin;
            this.btLogin.Location = new System.Drawing.Point(354, 265);
            this.btLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLogin.Name = "btLogin";
            this.btLogin.ShadowDecoration.Parent = this.btLogin;
            this.btLogin.Size = new System.Drawing.Size(150, 45);
            this.btLogin.TabIndex = 31;
            this.btLogin.Text = "Login";
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // ckRemember
            // 
            this.ckRemember.Animated = true;
            this.ckRemember.BackColor = System.Drawing.Color.Transparent;
            this.ckRemember.Checked = true;
            this.ckRemember.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ckRemember.CheckedState.BorderRadius = 2;
            this.ckRemember.CheckedState.BorderThickness = 0;
            this.ckRemember.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ckRemember.CheckedState.Parent = this.ckRemember;
            this.ckRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckRemember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckRemember.Location = new System.Drawing.Point(306, 224);
            this.ckRemember.Name = "ckRemember";
            this.ckRemember.ShadowDecoration.Parent = this.ckRemember;
            this.ckRemember.Size = new System.Drawing.Size(20, 20);
            this.ckRemember.TabIndex = 35;
            this.ckRemember.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ckRemember.UncheckedState.BorderRadius = 2;
            this.ckRemember.UncheckedState.BorderThickness = 0;
            this.ckRemember.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ckRemember.UncheckedState.Parent = this.ckRemember;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Cursor = System.Windows.Forms.Cursors.Default;
            this.label15.Font = new System.Drawing.Font("Simplified Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(328, 218);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(134, 32);
            this.label15.TabIndex = 36;
            this.label15.Text = "Remember me";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 318);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(568, 24);
            this.label1.TabIndex = 37;
            this.label1.Text = "V 1.1.0";
            // 
            // picShowIcon
            // 
            this.picShowIcon.BackColor = System.Drawing.Color.White;
            this.picShowIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShowIcon.Image = global::K_M_S_PROGRAM.Properties.Resources.hidden;
            this.picShowIcon.Location = new System.Drawing.Point(316, 165);
            this.picShowIcon.Name = "picShowIcon";
            this.picShowIcon.Size = new System.Drawing.Size(25, 19);
            this.picShowIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShowIcon.TabIndex = 17;
            this.picShowIcon.TabStop = false;
            this.picShowIcon.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxPassword
            // 
            this.TxPassword.Animated = true;
            this.TxPassword.BackColor = System.Drawing.Color.Transparent;
            this.TxPassword.BorderRadius = 10;
            this.TxPassword.BorderThickness = 2;
            this.TxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxPassword.DefaultText = "";
            this.TxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxPassword.DisabledState.Parent = this.TxPassword;
            this.TxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TxPassword.FocusedState.Parent = this.TxPassword;
            this.TxPassword.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.TxPassword.ForeColor = System.Drawing.Color.Black;
            this.TxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxPassword.HoverState.Parent = this.TxPassword;
            this.TxPassword.IconRight = global::K_M_S_PROGRAM.Properties.Resources._lock;
            this.TxPassword.IconRightSize = new System.Drawing.Size(30, 30);
            this.TxPassword.Location = new System.Drawing.Point(306, 156);
            this.TxPassword.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.TxPassword.Name = "TxPassword";
            this.TxPassword.PasswordChar = '\0';
            this.TxPassword.PlaceholderText = "كلمة_المرور";
            this.TxPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxPassword.SelectedText = "";
            this.TxPassword.ShadowDecoration.Parent = this.TxPassword;
            this.TxPassword.Size = new System.Drawing.Size(247, 38);
            this.TxPassword.TabIndex = 1;
            // 
            // txUserName
            // 
            this.txUserName.Animated = true;
            this.txUserName.BackColor = System.Drawing.Color.Transparent;
            this.txUserName.BorderRadius = 10;
            this.txUserName.BorderThickness = 2;
            this.txUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txUserName.DefaultText = "";
            this.txUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txUserName.DisabledState.Parent = this.txUserName;
            this.txUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txUserName.FocusedState.Parent = this.txUserName;
            this.txUserName.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txUserName.ForeColor = System.Drawing.Color.Black;
            this.txUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txUserName.HoverState.Parent = this.txUserName;
            this.txUserName.IconRight = global::K_M_S_PROGRAM.Properties.Resources.usericon;
            this.txUserName.IconRightSize = new System.Drawing.Size(30, 30);
            this.txUserName.Location = new System.Drawing.Point(306, 109);
            this.txUserName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txUserName.Name = "txUserName";
            this.txUserName.PasswordChar = '\0';
            this.txUserName.PlaceholderText = "اسم_المستخدم";
            this.txUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txUserName.SelectedText = "";
            this.txUserName.ShadowDecoration.Parent = this.txUserName;
            this.txUserName.ShortcutsEnabled = false;
            this.txUserName.Size = new System.Drawing.Size(247, 38);
            this.txUserName.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::K_M_S_PROGRAM.Properties.Resources.Forgot_password_rafiki;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 318);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Screen
            // 
            this.AcceptButton = this.btLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(568, 342);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ckRemember);
            this.Controls.Add(this.picShowIcon);
            this.Controls.Add(this.TxPassword);
            this.Controls.Add(this.txUserName);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.lbProgramName);
            this.Controls.Add(this.lbError);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login_Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KMP ";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picShowIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.PictureBox picShowIcon;
        private System.Windows.Forms.Label lbProgramName;
        private Guna.UI2.WinForms.Guna2Button btLogin;
        private Guna.UI2.WinForms.Guna2TextBox txUserName;
        private Guna.UI2.WinForms.Guna2TextBox TxPassword;
        private Guna.UI2.WinForms.Guna2CustomCheckBox ckRemember;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

