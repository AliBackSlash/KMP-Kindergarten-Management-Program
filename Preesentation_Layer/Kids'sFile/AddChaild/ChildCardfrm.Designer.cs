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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildCardfrm));
            this.lbECode = new System.Windows.Forms.Label();
            this.childCard2 = new K_M_S_PROGRAM.Kids_sFile.AddChaild.ChildCard();
            this.SuspendLayout();
            // 
            // lbECode
            // 
            this.lbECode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbECode.AutoSize = true;
            this.lbECode.BackColor = System.Drawing.Color.Transparent;
            this.lbECode.Font = new System.Drawing.Font("Simple Bold Jut Out", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbECode.ForeColor = System.Drawing.Color.White;
            this.lbECode.Location = new System.Drawing.Point(426, 19);
            this.lbECode.Name = "lbECode";
            this.lbECode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbECode.Size = new System.Drawing.Size(147, 35);
            this.lbECode.TabIndex = 62;
            this.lbECode.Text = "بيانات الطفل";
            // 
            // childCard2
            // 
            this.childCard2.BackColor = System.Drawing.Color.MidnightBlue;
            this.childCard2.Location = new System.Drawing.Point(11, 78);
            this.childCard2.Name = "childCard2";
            this.childCard2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.childCard2.Size = new System.Drawing.Size(975, 457);
            this.childCard2.TabIndex = 65;
            // 
            // ChildCardfrm
            // 
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1000, 564);
            this.Controls.Add(this.childCard2);
            this.Controls.Add(this.lbECode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChildCardfrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
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
        private ChildCard childCard2;
    }
}