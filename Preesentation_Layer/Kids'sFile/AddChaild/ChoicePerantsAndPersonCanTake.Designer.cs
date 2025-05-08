namespace K_M_S_PROGRAM.Kids_sFile.AddChaild
{
    partial class ChoicePerantsAndPersonCanTake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoicePerantsAndPersonCanTake));
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.cmNames = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.btSave.Location = new System.Drawing.Point(63, 106);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.ShadowDecoration.Parent = this.btSave;
            this.btSave.Size = new System.Drawing.Size(113, 40);
            this.btSave.TabIndex = 33;
            this.btSave.Text = "حفظ";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // cmNames
            // 
            this.cmNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmNames.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Bold);
            this.cmNames.FormattingEnabled = true;
            this.cmNames.Location = new System.Drawing.Point(12, 29);
            this.cmNames.Name = "cmNames";
            this.cmNames.Size = new System.Drawing.Size(215, 43);
            this.cmNames.TabIndex = 34;
            // 
            // ChoicePerantsAndPersonCanTake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 167);
            this.Controls.Add(this.cmNames);
            this.Controls.Add(this.btSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoicePerantsAndPersonCanTake";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChoicePerantsAndPersonCanTake_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btSave;
        private System.Windows.Forms.ComboBox cmNames;
    }
}