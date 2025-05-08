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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpInfo));
            this.lbECode = new System.Windows.Forms.Label();
            this.empCard1 = new K_M_S_PROGRAM.Employees_sFiles.EmpCard();
            this.SuspendLayout();
            // 
            // lbECode
            // 
            this.lbECode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbECode.AutoSize = true;
            this.lbECode.BackColor = System.Drawing.Color.Transparent;
            this.lbECode.Font = new System.Drawing.Font("Simple Bold Jut Out", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbECode.ForeColor = System.Drawing.Color.White;
            this.lbECode.Location = new System.Drawing.Point(303, 19);
            this.lbECode.Name = "lbECode";
            this.lbECode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbECode.Size = new System.Drawing.Size(157, 35);
            this.lbECode.TabIndex = 61;
            this.lbECode.Text = "بيانات الموظف";
            // 
            // empCard1
            // 
            this.empCard1.BackColor = System.Drawing.Color.Indigo;
            this.empCard1.Location = new System.Drawing.Point(12, 80);
            this.empCard1.Name = "empCard1";
            this.empCard1.Size = new System.Drawing.Size(739, 278);
            this.empCard1.TabIndex = 64;
            // 
            // EmpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(765, 378);
            this.Controls.Add(this.empCard1);
            this.Controls.Add(this.lbECode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmpInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmpInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lbECode;
        private EmpCard empCard1;
    }
}