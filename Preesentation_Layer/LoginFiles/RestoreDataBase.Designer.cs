namespace K_M_S_PROGRAM.LoginFiles
{
    partial class RestoreDataBase
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
            this.components = new System.ComponentModel.Container();
            this.txSavePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.btSavePackup = new Guna.UI2.WinForms.Guna2Button();
            this.lbIntro = new System.Windows.Forms.Label();
            this.btRestore = new Guna.UI2.WinForms.Guna2Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbMyAccount = new System.Windows.Forms.LinkLabel();
            this.waitControl = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.SuspendLayout();
            // 
            // txSavePath
            // 
            this.txSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txSavePath.Animated = true;
            this.txSavePath.BackColor = System.Drawing.Color.Transparent;
            this.txSavePath.BorderRadius = 10;
            this.txSavePath.BorderThickness = 3;
            this.txSavePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txSavePath.DefaultText = "";
            this.txSavePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txSavePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txSavePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txSavePath.DisabledState.Parent = this.txSavePath;
            this.txSavePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txSavePath.Enabled = false;
            this.txSavePath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txSavePath.FocusedState.Parent = this.txSavePath;
            this.txSavePath.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txSavePath.ForeColor = System.Drawing.Color.Black;
            this.txSavePath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txSavePath.HoverState.Parent = this.txSavePath;
            this.txSavePath.IconRightSize = new System.Drawing.Size(30, 30);
            this.txSavePath.Location = new System.Drawing.Point(13, 278);
            this.txSavePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txSavePath.Name = "txSavePath";
            this.txSavePath.PasswordChar = '\0';
            this.txSavePath.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txSavePath.PlaceholderText = "The Path...";
            this.txSavePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txSavePath.SelectedText = "";
            this.txSavePath.ShadowDecoration.Parent = this.txSavePath;
            this.txSavePath.ShortcutsEnabled = false;
            this.txSavePath.Size = new System.Drawing.Size(623, 39);
            this.txSavePath.TabIndex = 100;
            this.txSavePath.TextChanged += new System.EventHandler(this.txSavePath_TextChanged);
            // 
            // btSavePackup
            // 
            this.btSavePackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSavePackup.Animated = true;
            this.btSavePackup.BorderColor = System.Drawing.Color.White;
            this.btSavePackup.BorderRadius = 8;
            this.btSavePackup.BorderThickness = 1;
            this.btSavePackup.CheckedState.Parent = this.btSavePackup;
            this.btSavePackup.CustomImages.Parent = this.btSavePackup;
            this.btSavePackup.Enabled = false;
            this.btSavePackup.FillColor = System.Drawing.Color.Indigo;
            this.btSavePackup.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSavePackup.ForeColor = System.Drawing.Color.White;
            this.btSavePackup.HoverState.BorderColor = System.Drawing.Color.Indigo;
            this.btSavePackup.HoverState.FillColor = System.Drawing.Color.White;
            this.btSavePackup.HoverState.ForeColor = System.Drawing.Color.Indigo;
            this.btSavePackup.HoverState.Parent = this.btSavePackup;
            this.btSavePackup.Location = new System.Drawing.Point(643, 283);
            this.btSavePackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSavePackup.Name = "btSavePackup";
            this.btSavePackup.ShadowDecoration.Parent = this.btSavePackup;
            this.btSavePackup.Size = new System.Drawing.Size(44, 28);
            this.btSavePackup.TabIndex = 99;
            this.btSavePackup.Text = "...";
            this.btSavePackup.Click += new System.EventHandler(this.btSavePackup_Click);
            // 
            // lbIntro
            // 
            this.lbIntro.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbIntro.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIntro.ForeColor = System.Drawing.Color.Blue;
            this.lbIntro.Location = new System.Drawing.Point(0, 0);
            this.lbIntro.Name = "lbIntro";
            this.lbIntro.Size = new System.Drawing.Size(699, 274);
            this.lbIntro.TabIndex = 101;
            // 
            // btRestore
            // 
            this.btRestore.Animated = true;
            this.btRestore.BorderColor = System.Drawing.Color.White;
            this.btRestore.BorderRadius = 8;
            this.btRestore.BorderThickness = 1;
            this.btRestore.CheckedState.Parent = this.btRestore;
            this.btRestore.CustomImages.Parent = this.btRestore;
            this.btRestore.Enabled = false;
            this.btRestore.FillColor = System.Drawing.Color.Indigo;
            this.btRestore.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRestore.ForeColor = System.Drawing.Color.White;
            this.btRestore.HoverState.BorderColor = System.Drawing.Color.Indigo;
            this.btRestore.HoverState.FillColor = System.Drawing.Color.White;
            this.btRestore.HoverState.ForeColor = System.Drawing.Color.Indigo;
            this.btRestore.HoverState.Parent = this.btRestore;
            this.btRestore.Location = new System.Drawing.Point(295, 335);
            this.btRestore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRestore.Name = "btRestore";
            this.btRestore.ShadowDecoration.Parent = this.btRestore;
            this.btRestore.Size = new System.Drawing.Size(108, 39);
            this.btRestore.TabIndex = 102;
            this.btRestore.Text = "Restore";
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbMyAccount
            // 
            this.lbMyAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMyAccount.BackColor = System.Drawing.Color.Transparent;
            this.lbMyAccount.Font = new System.Drawing.Font("Sylfaen", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbMyAccount.Location = new System.Drawing.Point(535, 382);
            this.lbMyAccount.Name = "lbMyAccount";
            this.lbMyAccount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbMyAccount.Size = new System.Drawing.Size(161, 25);
            this.lbMyAccount.TabIndex = 104;
            this.lbMyAccount.TabStop = true;
            this.lbMyAccount.Text = "Contact us....";
            this.lbMyAccount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbMyAccount.Visible = false;
            this.lbMyAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbMyAccount_LinkClicked);
            // 
            // waitControl
            // 
            this.waitControl.BackColor = System.Drawing.Color.Transparent;
            this.waitControl.CircleSize = 2F;
            this.waitControl.Location = new System.Drawing.Point(318, 324);
            this.waitControl.Name = "waitControl";
            this.waitControl.ProgressColor = System.Drawing.Color.BlueViolet;
            this.waitControl.Size = new System.Drawing.Size(62, 62);
            this.waitControl.TabIndex = 105;
            this.waitControl.Visible = false;
            // 
            // RestoreDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 408);
            this.Controls.Add(this.waitControl);
            this.Controls.Add(this.btRestore);
            this.Controls.Add(this.lbIntro);
            this.Controls.Add(this.txSavePath);
            this.Controls.Add(this.btSavePackup);
            this.Controls.Add(this.lbMyAccount);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RestoreDataBase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تثبيت ملف البيانات ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RestoreDataBase_FormClosing);
            this.Load += new System.EventHandler(this.RestoreDataBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txSavePath;
        private Guna.UI2.WinForms.Guna2Button btSavePackup;
        private System.Windows.Forms.Label lbIntro;
        private Guna.UI2.WinForms.Guna2Button btRestore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel lbMyAccount;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator waitControl;
    }
}