namespace K_M_S_PROGRAM.Resources
{
    partial class MyMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMessage));
            this.lbTitale = new System.Windows.Forms.Label();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.pic = new SATAUiFramework.Controls.SATAPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitale
            // 
            this.lbTitale.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitale.Font = new System.Drawing.Font("Simplified Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitale.ForeColor = System.Drawing.Color.Black;
            this.lbTitale.Location = new System.Drawing.Point(0, 0);
            this.lbTitale.Name = "lbTitale";
            this.lbTitale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTitale.Size = new System.Drawing.Size(417, 136);
            this.lbTitale.TabIndex = 6;
            this.lbTitale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSave
            // 
            this.btSave.Animated = true;
            this.btSave.BorderColor = System.Drawing.Color.White;
            this.btSave.BorderRadius = 8;
            this.btSave.BorderThickness = 1;
            this.btSave.CheckedState.Parent = this.btSave;
            this.btSave.CustomImages.Parent = this.btSave;
            this.btSave.FillColor = System.Drawing.Color.Indigo;
            this.btSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.White;
            this.btSave.HoverState.BorderColor = System.Drawing.Color.Indigo;
            this.btSave.HoverState.FillColor = System.Drawing.Color.White;
            this.btSave.HoverState.ForeColor = System.Drawing.Color.Indigo;
            this.btSave.HoverState.Parent = this.btSave;
            this.btSave.Location = new System.Drawing.Point(12, 97);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.ShadowDecoration.Parent = this.btSave;
            this.btSave.Size = new System.Drawing.Size(109, 28);
            this.btSave.TabIndex = 33;
            this.btSave.Text = "موافق";
            this.btSave.Click += new System.EventHandler(this.btOk_Click);
            // 
            // pic
            // 
            this.pic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.pic.BorderColor = System.Drawing.Color.DodgerBlue;
            this.pic.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.pic.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.pic.BorderSize = 0;
            this.pic.GradientAngle = 50F;
            this.pic.Location = new System.Drawing.Point(417, 25);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(78, 78);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // MyMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(498, 136);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.lbTitale);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyMessage";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KMP-Messsage";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public SATAUiFramework.Controls.SATAPictureBox pic;
        public System.Windows.Forms.Label lbTitale;
        private Guna.UI2.WinForms.Guna2Button btSave;
    }
}