namespace K_M_S_PROGRAM.TreasuryFiles
{
    partial class AddToTreasury
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddToTreasury));
            this.rdOutputs = new CodeeloUI.Controls.CodeeloRadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rdInputs = new CodeeloUI.Controls.CodeeloRadioButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdOutputs
            // 
            this.rdOutputs.BackColor = System.Drawing.Color.Transparent;
            this.rdOutputs.ButtonAreaSize = 18F;
            this.rdOutputs.ButtonBorderSize = 1.6F;
            this.rdOutputs.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.rdOutputs.ButtonColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(220)))), ((int)(((byte)(95)))));
            this.rdOutputs.ButtonToggleSize = 12F;
            this.rdOutputs.DrawCircleButton = true;
            this.rdOutputs.DrawCircleToggle = true;
            this.rdOutputs.Location = new System.Drawing.Point(31, 104);
            this.rdOutputs.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdOutputs.Name = "rdOutputs";
            this.rdOutputs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdOutputs.Size = new System.Drawing.Size(26, 24);
            this.rdOutputs.TabIndex = 24;
            this.rdOutputs.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(54, 102);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(62, 28);
            this.label5.TabIndex = 26;
            this.label5.Text = "مصروفات";
            // 
            // txAmount
            // 
            this.txAmount.Animated = true;
            this.txAmount.BackColor = System.Drawing.Color.Transparent;
            this.txAmount.BorderRadius = 10;
            this.txAmount.BorderThickness = 3;
            this.txAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txAmount.DefaultText = "";
            this.txAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txAmount.DisabledState.Parent = this.txAmount;
            this.txAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txAmount.FocusedState.Parent = this.txAmount;
            this.txAmount.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txAmount.ForeColor = System.Drawing.Color.Black;
            this.txAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txAmount.HoverState.Parent = this.txAmount;
            this.txAmount.Location = new System.Drawing.Point(5, 46);
            this.txAmount.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txAmount.Name = "txAmount";
            this.txAmount.PasswordChar = '\0';
            this.txAmount.PlaceholderText = "أدخل قيمة المبلغ......";
            this.txAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txAmount.SelectedText = "";
            this.txAmount.ShadowDecoration.Parent = this.txAmount;
            this.txAmount.ShortcutsEnabled = false;
            this.txAmount.Size = new System.Drawing.Size(241, 50);
            this.txAmount.TabIndex = 55;
            this.txAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txAmount_KeyPress);
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
            this.btSave.Location = new System.Drawing.Point(69, 151);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.ShadowDecoration.Parent = this.btSave;
            this.btSave.Size = new System.Drawing.Size(113, 40);
            this.btSave.TabIndex = 57;
            this.btSave.Text = "حفظ";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // rdInputs
            // 
            this.rdInputs.BackColor = System.Drawing.Color.Transparent;
            this.rdInputs.ButtonAreaSize = 18F;
            this.rdInputs.ButtonBorderSize = 1.6F;
            this.rdInputs.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.rdInputs.ButtonColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(220)))), ((int)(((byte)(95)))));
            this.rdInputs.ButtonToggleSize = 12F;
            this.rdInputs.DrawCircleButton = true;
            this.rdInputs.DrawCircleToggle = true;
            this.rdInputs.Location = new System.Drawing.Point(137, 104);
            this.rdInputs.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdInputs.Name = "rdInputs";
            this.rdInputs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdInputs.Size = new System.Drawing.Size(26, 24);
            this.rdInputs.TabIndex = 24;
            this.rdInputs.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(160, 102);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(43, 28);
            this.label3.TabIndex = 26;
            this.label3.Text = "إيرادات";
            // 
            // AddToTreasury
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 208);
            this.Controls.Add(this.rdInputs);
            this.Controls.Add(this.rdOutputs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txAmount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddToTreasury";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CodeeloUI.Controls.CodeeloRadioButton rdOutputs;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txAmount;
        private Guna.UI2.WinForms.Guna2Button btSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private CodeeloUI.Controls.CodeeloRadioButton rdInputs;
        private System.Windows.Forms.Label label3;
    }
}