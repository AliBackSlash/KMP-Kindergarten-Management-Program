namespace K_M_S_PROGRAM.Employees_sFiles
{
    partial class EmpInfo
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
            this.sEllipse1 = new Sipaa.Framework.SEllipse();
            this.lbECode = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btClose = new Sipaa.Framework.SButton();
            this.empCard1 = new K_M_S_PROGRAM.Employees_sFiles.EmpCard();
            this.SuspendLayout();
            // 
            // sEllipse1
            // 
            this.sEllipse1.CornerRadius = 30;
            this.sEllipse1.TargetControl = this;
            // 
            // lbECode
            // 
            this.lbECode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbECode.AutoSize = true;
            this.lbECode.BackColor = System.Drawing.Color.Transparent;
            this.lbECode.Font = new System.Drawing.Font("Simple Bold Jut Out", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbECode.ForeColor = System.Drawing.Color.White;
            this.lbECode.Location = new System.Drawing.Point(303, 47);
            this.lbECode.Name = "lbECode";
            this.lbECode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbECode.Size = new System.Drawing.Size(157, 35);
            this.lbECode.TabIndex = 61;
            this.lbECode.Text = "بيانات الموظف";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 25);
            this.panel1.TabIndex = 62;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btClose.BorderRadius = 10;
            this.btClose.BorderSize = 0;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Location = new System.Drawing.Point(12, 12);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(42, 41);
            this.btClose.TabIndex = 63;
            this.btClose.Text = "X";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // empCard1
            // 
            this.empCard1.BackColor = System.Drawing.Color.Indigo;
            this.empCard1.Location = new System.Drawing.Point(12, 108);
            this.empCard1.Name = "empCard1";
            this.empCard1.Size = new System.Drawing.Size(739, 278);
            this.empCard1.TabIndex = 64;
            // 
            // EmpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(765, 398);
            this.Controls.Add(this.empCard1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lbECode);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmpInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmpInfo";
            this.Load += new System.EventHandler(this.EmpInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sipaa.Framework.SEllipse sEllipse1;
        public System.Windows.Forms.Label lbECode;
        private Sipaa.Framework.SButton btClose;
        private System.Windows.Forms.Panel panel1;
        private EmpCard empCard1;
    }
}