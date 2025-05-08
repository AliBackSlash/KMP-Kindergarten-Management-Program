namespace K_M_S_PROGRAM.UsersFiles
{
    partial class Show_User_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show_User_info));
            this.user_Info_Card1 = new K_M_S_PROGRAM.UsersFiles.User_Info_Card();
            this.SuspendLayout();
            // 
            // user_Info_Card1
            // 
            this.user_Info_Card1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.user_Info_Card1.Location = new System.Drawing.Point(15, 47);
            this.user_Info_Card1.Name = "user_Info_Card1";
            this.user_Info_Card1.Size = new System.Drawing.Size(474, 258);
            this.user_Info_Card1.TabIndex = 65;
            // 
            // Show_User_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 315);
            this.Controls.Add(this.user_Info_Card1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Show_User_info";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Show_User_info_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private User_Info_Card user_Info_Card1;
    }
}