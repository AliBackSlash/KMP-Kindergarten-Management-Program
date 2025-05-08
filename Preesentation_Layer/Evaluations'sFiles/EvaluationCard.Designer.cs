namespace K_M_S_PROGRAM.Evaluations_sFiles
{
    partial class EvaluationCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picFoto = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2RatingStar1 = new Guna.UI2.WinForms.Guna2RatingStar();
            this.Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CkToChenageColor = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.Transparent;
            this.picFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picFoto.Image = global::K_M_S_PROGRAM.Properties.Resources.boy;
            this.picFoto.Location = new System.Drawing.Point(3, 3);
            this.picFoto.Name = "picFoto";
            this.picFoto.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picFoto.ShadowDecoration.Parent = this.picFoto;
            this.picFoto.Size = new System.Drawing.Size(88, 74);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // guna2RatingStar1
            // 
            this.guna2RatingStar1.BackColor = System.Drawing.Color.Transparent;
            this.guna2RatingStar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2RatingStar1.Location = new System.Drawing.Point(8, 154);
            this.guna2RatingStar1.Name = "guna2RatingStar1";
            this.guna2RatingStar1.RatingColor = System.Drawing.Color.Goldenrod;
            this.guna2RatingStar1.Size = new System.Drawing.Size(202, 40);
            this.guna2RatingStar1.TabIndex = 1;
            this.guna2RatingStar1.Value = 2F;
            // 
            // Elipse
            // 
            this.Elipse.BorderRadius = 15;
            this.Elipse.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 49);
            this.label1.TabIndex = 2;
            // 
            // CkToChenageColor
            // 
            this.CkToChenageColor.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CkToChenageColor.CheckedState.BorderRadius = 2;
            this.CkToChenageColor.CheckedState.BorderThickness = 0;
            this.CkToChenageColor.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CkToChenageColor.CheckedState.Parent = this.CkToChenageColor;
            this.CkToChenageColor.Location = new System.Drawing.Point(97, 3);
            this.CkToChenageColor.Name = "CkToChenageColor";
            this.CkToChenageColor.ShadowDecoration.Parent = this.CkToChenageColor;
            this.CkToChenageColor.Size = new System.Drawing.Size(20, 20);
            this.CkToChenageColor.TabIndex = 3;
            this.CkToChenageColor.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CkToChenageColor.UncheckedState.BorderRadius = 2;
            this.CkToChenageColor.UncheckedState.BorderThickness = 0;
            this.CkToChenageColor.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CkToChenageColor.UncheckedState.Parent = this.CkToChenageColor;
            this.CkToChenageColor.Visible = false;
            this.CkToChenageColor.CheckedChanged += new System.EventHandler(this.CkToChenageColor_CheckedChanged);
            // 
            // EvaluationCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.CkToChenageColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2RatingStar1);
            this.Controls.Add(this.picFoto);
            this.Name = "EvaluationCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(226, 210);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picFoto;
        private Guna.UI2.WinForms.Guna2RatingStar guna2RatingStar1;
        private Guna.UI2.WinForms.Guna2Elipse Elipse;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox CkToChenageColor;
    }
}
