namespace K_M_S_PROGRAM.Employees_sFiles
{
    partial class WorkerInfo
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
            this.btClose = new Sipaa.Framework.SButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbECode = new System.Windows.Forms.Label();
            this.sEllipse1 = new Sipaa.Framework.SEllipse();
            this.workerCard1 = new K_M_S_PROGRAM.Employees_sFiles.WorkerCard();
            this.SuspendLayout();
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
            this.btClose.TabIndex = 65;
            this.btClose.Text = "X";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 25);
            this.panel1.TabIndex = 64;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // lbECode
            // 
            this.lbECode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbECode.AutoSize = true;
            this.lbECode.BackColor = System.Drawing.Color.Transparent;
            this.lbECode.Font = new System.Drawing.Font("Simple Bold Jut Out", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbECode.ForeColor = System.Drawing.Color.Black;
            this.lbECode.Location = new System.Drawing.Point(203, 57);
            this.lbECode.Name = "lbECode";
            this.lbECode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbECode.Size = new System.Drawing.Size(157, 35);
            this.lbECode.TabIndex = 66;
            this.lbECode.Text = "بيانات الموظف";
            // 
            // sEllipse1
            // 
            this.sEllipse1.CornerRadius = 30;
            this.sEllipse1.TargetControl = this;
            // 
            // workerCard1
            // 
            this.workerCard1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.workerCard1.Location = new System.Drawing.Point(12, 122);
            this.workerCard1.Name = "workerCard1";
            this.workerCard1.Size = new System.Drawing.Size(538, 260);
            this.workerCard1.TabIndex = 67;
            // 
            // WorkerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 394);
            this.Controls.Add(this.workerCard1);
            this.Controls.Add(this.lbECode);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkerInfo";
            this.Load += new System.EventHandler(this.WorkerInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sipaa.Framework.SButton btClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbECode;
        private Sipaa.Framework.SEllipse sEllipse1;
        private WorkerCard workerCard1;
    }
}