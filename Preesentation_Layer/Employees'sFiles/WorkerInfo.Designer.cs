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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerInfo));
            this.lbECode = new System.Windows.Forms.Label();
            this.workerCard1 = new K_M_S_PROGRAM.Employees_sFiles.WorkerCard();
            this.SuspendLayout();
            // 
            // lbECode
            // 
            this.lbECode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbECode.AutoSize = true;
            this.lbECode.BackColor = System.Drawing.Color.Transparent;
            this.lbECode.Font = new System.Drawing.Font("Simple Bold Jut Out", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbECode.ForeColor = System.Drawing.Color.Black;
            this.lbECode.Location = new System.Drawing.Point(203, 29);
            this.lbECode.Name = "lbECode";
            this.lbECode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbECode.Size = new System.Drawing.Size(157, 35);
            this.lbECode.TabIndex = 66;
            this.lbECode.Text = "بيانات الموظف";
            // 
            // workerCard1
            // 
            this.workerCard1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.workerCard1.Location = new System.Drawing.Point(12, 94);
            this.workerCard1.Name = "workerCard1";
            this.workerCard1.Size = new System.Drawing.Size(538, 260);
            this.workerCard1.TabIndex = 67;
            // 
            // WorkerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 373);
            this.Controls.Add(this.workerCard1);
            this.Controls.Add(this.lbECode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkerInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.WorkerInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lbECode;
        private WorkerCard workerCard1;
    }
}