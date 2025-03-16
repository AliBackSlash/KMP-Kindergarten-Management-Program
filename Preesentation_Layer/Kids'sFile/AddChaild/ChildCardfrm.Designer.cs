namespace K_M_S_PROGRAM.Kids_sFile.AddChaild
{
    partial class ChildCardfrm
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
            this.lbECode = new System.Windows.Forms.Label();
            this.sButton1 = new Sipaa.Framework.SButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.childCard2 = new K_M_S_PROGRAM.Kids_sFile.AddChaild.ChildCard();
            this.sEllipse2 = new Sipaa.Framework.SEllipse();
            this.SuspendLayout();
            // 
            // lbECode
            // 
            this.lbECode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbECode.AutoSize = true;
            this.lbECode.BackColor = System.Drawing.Color.Transparent;
            this.lbECode.Font = new System.Drawing.Font("Simple Bold Jut Out", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbECode.ForeColor = System.Drawing.Color.White;
            this.lbECode.Location = new System.Drawing.Point(426, 67);
            this.lbECode.Name = "lbECode";
            this.lbECode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbECode.Size = new System.Drawing.Size(147, 35);
            this.lbECode.TabIndex = 62;
            this.lbECode.Text = "بيانات الطفل";
            // 
            // sButton1
            // 
            this.sButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.sButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.sButton1.BorderRadius = 10;
            this.sButton1.BorderSize = 0;
            this.sButton1.FlatAppearance.BorderSize = 0;
            this.sButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sButton1.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.sButton1.ForeColor = System.Drawing.Color.White;
            this.sButton1.Location = new System.Drawing.Point(12, 12);
            this.sButton1.Name = "sButton1";
            this.sButton1.Size = new System.Drawing.Size(42, 41);
            this.sButton1.TabIndex = 63;
            this.sButton1.Text = "X";
            this.sButton1.UseVisualStyleBackColor = false;
            this.sButton1.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 36);
            this.panel1.TabIndex = 64;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // childCard2
            // 
            this.childCard2.BackColor = System.Drawing.Color.MidnightBlue;
            this.childCard2.Location = new System.Drawing.Point(11, 143);
            this.childCard2.Name = "childCard2";
            this.childCard2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.childCard2.Size = new System.Drawing.Size(975, 457);
            this.childCard2.TabIndex = 65;
            // 
            // sEllipse2
            // 
            this.sEllipse2.CornerRadius = 30;
            this.sEllipse2.TargetControl = this;
            // 
            // ChildCardfrm
            // 
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1000, 606);
            this.Controls.Add(this.childCard2);
            this.Controls.Add(this.lbECode);
            this.Controls.Add(this.sButton1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildCardfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChildCardfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChildCard childCard1;
        private Sipaa.Framework.SEllipse sEllipse1;
        private CodeeloUI.Controls.CodeeloButton btClose;
        public System.Windows.Forms.Label lbECode;
        private Sipaa.Framework.SButton sButton1;
        private System.Windows.Forms.Panel panel1;
        private ChildCard childCard2;
        private Sipaa.Framework.SEllipse sEllipse2;
    }
}