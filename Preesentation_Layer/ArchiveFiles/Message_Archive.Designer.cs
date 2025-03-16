namespace K_M_S_PROGRAM.Resources
{
    partial class Message_Archive
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMessageArchive = new MetroFramework.Controls.MetroGrid();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdKids = new CodeeloUI.Controls.CodeeloRadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdTeachers = new CodeeloUI.Controls.CodeeloRadioButton();
            this.rdWorkers = new CodeeloUI.Controls.CodeeloRadioButton();
            this.txSearsh = new Guna.UI2.WinForms.Guna2TextBox();
            this.btDelete = new Guna.UI2.WinForms.Guna2Button();
            this.sataPictureBox2 = new SATAUiFramework.Controls.SATAPictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.sEllipse1 = new Sipaa.Framework.SEllipse();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageArchive)).BeginInit();
            this.sataPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMessageArchive, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.sataPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(997, 658);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvMessageArchive
            // 
            this.dgvMessageArchive.AllowUserToAddRows = false;
            this.dgvMessageArchive.AllowUserToDeleteRows = false;
            this.dgvMessageArchive.AllowUserToResizeRows = false;
            this.dgvMessageArchive.BackgroundColor = System.Drawing.Color.White;
            this.dgvMessageArchive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMessageArchive.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvMessageArchive.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Simplified Arabic", 13.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.NullValue = "فارغة";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessageArchive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMessageArchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessageArchive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun-ExtB", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMessageArchive.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMessageArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMessageArchive.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvMessageArchive.EnableHeadersVisualStyles = false;
            this.dgvMessageArchive.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvMessageArchive.GridColor = System.Drawing.Color.White;
            this.dgvMessageArchive.Location = new System.Drawing.Point(3, 86);
            this.dgvMessageArchive.Name = "dgvMessageArchive";
            this.dgvMessageArchive.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessageArchive.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMessageArchive.RowHeadersVisible = false;
            this.dgvMessageArchive.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMessageArchive.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMessageArchive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMessageArchive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessageArchive.Size = new System.Drawing.Size(991, 569);
            this.dgvMessageArchive.TabIndex = 10;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewImageColumn1.FillWeight = 200F;
            this.dataGridViewImageColumn1.HeaderText = "@";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 53;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "الإسم";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 67;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 76;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "محتوي الرسالة";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // sataPanel1
            // 
            this.sataPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.sataPanel1.BackColor2 = System.Drawing.Color.LightGray;
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius1;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.groupBox2);
            this.sataPanel1.Controls.Add(this.txSearsh);
            this.sataPanel1.Controls.Add(this.btDelete);
            this.sataPanel1.Controls.Add(this.sataPictureBox2);
            this.sataPanel1.Controls.Add(this.label12);
            this.sataPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sataPanel1.Location = new System.Drawing.Point(3, 23);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(991, 57);
            this.sataPanel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.rdKids);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rdTeachers);
            this.groupBox2.Controls.Add(this.rdWorkers);
            this.groupBox2.Location = new System.Drawing.Point(67, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 39);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(209, 6);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(39, 28);
            this.label6.TabIndex = 28;
            this.label6.Text = "أطفال";
            // 
            // rdKids
            // 
            this.rdKids.BackColor = System.Drawing.Color.Transparent;
            this.rdKids.ButtonAreaSize = 18F;
            this.rdKids.ButtonBorderSize = 1.6F;
            this.rdKids.ButtonColor = System.Drawing.Color.Silver;
            this.rdKids.ButtonColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(220)))), ((int)(((byte)(95)))));
            this.rdKids.ButtonToggleSize = 12F;
            this.rdKids.Checked = true;
            this.rdKids.DrawCircleButton = true;
            this.rdKids.DrawCircleToggle = true;
            this.rdKids.Location = new System.Drawing.Point(248, 8);
            this.rdKids.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdKids.Name = "rdKids";
            this.rdKids.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdKids.Size = new System.Drawing.Size(26, 24);
            this.rdKids.TabIndex = 27;
            this.rdKids.TabStop = true;
            this.rdKids.UseVisualStyleBackColor = false;
            this.rdKids.CheckedChanged += new System.EventHandler(this.rdKinds_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(116, 6);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(52, 28);
            this.label4.TabIndex = 25;
            this.label4.Text = "مدرسين";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(28, 6);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(39, 28);
            this.label5.TabIndex = 26;
            this.label5.Text = "عمال";
            // 
            // rdTeachers
            // 
            this.rdTeachers.BackColor = System.Drawing.Color.Transparent;
            this.rdTeachers.ButtonAreaSize = 18F;
            this.rdTeachers.ButtonBorderSize = 1.6F;
            this.rdTeachers.ButtonColor = System.Drawing.Color.Silver;
            this.rdTeachers.ButtonColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(220)))), ((int)(((byte)(95)))));
            this.rdTeachers.ButtonToggleSize = 12F;
            this.rdTeachers.DrawCircleButton = true;
            this.rdTeachers.DrawCircleToggle = true;
            this.rdTeachers.Location = new System.Drawing.Point(165, 8);
            this.rdTeachers.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdTeachers.Name = "rdTeachers";
            this.rdTeachers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdTeachers.Size = new System.Drawing.Size(26, 24);
            this.rdTeachers.TabIndex = 23;
            this.rdTeachers.UseVisualStyleBackColor = false;
            this.rdTeachers.CheckedChanged += new System.EventHandler(this.rdKinds_CheckedChanged);
            // 
            // rdWorkers
            // 
            this.rdWorkers.BackColor = System.Drawing.Color.Transparent;
            this.rdWorkers.ButtonAreaSize = 18F;
            this.rdWorkers.ButtonBorderSize = 1.6F;
            this.rdWorkers.ButtonColor = System.Drawing.Color.Silver;
            this.rdWorkers.ButtonColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(220)))), ((int)(((byte)(95)))));
            this.rdWorkers.ButtonToggleSize = 12F;
            this.rdWorkers.DrawCircleButton = true;
            this.rdWorkers.DrawCircleToggle = true;
            this.rdWorkers.Location = new System.Drawing.Point(68, 8);
            this.rdWorkers.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdWorkers.Name = "rdWorkers";
            this.rdWorkers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdWorkers.Size = new System.Drawing.Size(26, 24);
            this.rdWorkers.TabIndex = 24;
            this.rdWorkers.UseVisualStyleBackColor = false;
            this.rdWorkers.CheckedChanged += new System.EventHandler(this.rdKinds_CheckedChanged);
            // 
            // txSearsh
            // 
            this.txSearsh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txSearsh.Animated = true;
            this.txSearsh.BackColor = System.Drawing.Color.Transparent;
            this.txSearsh.BorderRadius = 10;
            this.txSearsh.BorderThickness = 3;
            this.txSearsh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txSearsh.DefaultText = "";
            this.txSearsh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txSearsh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txSearsh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txSearsh.DisabledState.Parent = this.txSearsh;
            this.txSearsh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txSearsh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txSearsh.FocusedState.Parent = this.txSearsh;
            this.txSearsh.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txSearsh.ForeColor = System.Drawing.Color.Black;
            this.txSearsh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txSearsh.HoverState.Parent = this.txSearsh;
            this.txSearsh.IconRight = global::K_M_S_PROGRAM.Properties.Resources.Searsh_;
            this.txSearsh.IconRightSize = new System.Drawing.Size(30, 30);
            this.txSearsh.Location = new System.Drawing.Point(387, 4);
            this.txSearsh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txSearsh.Name = "txSearsh";
            this.txSearsh.PasswordChar = '\0';
            this.txSearsh.PlaceholderText = "بحث_بالاسم";
            this.txSearsh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txSearsh.SelectedText = "";
            this.txSearsh.ShadowDecoration.Parent = this.txSearsh;
            this.txSearsh.ShortcutsEnabled = false;
            this.txSearsh.Size = new System.Drawing.Size(223, 49);
            this.txSearsh.TabIndex = 54;
            this.txSearsh.TextChanged += new System.EventHandler(this.txSearsh_TextChanged);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btDelete.Animated = true;
            this.btDelete.BorderColor = System.Drawing.Color.IndianRed;
            this.btDelete.BorderRadius = 8;
            this.btDelete.BorderThickness = 1;
            this.btDelete.CheckedState.Parent = this.btDelete;
            this.btDelete.CustomImages.Parent = this.btDelete;
            this.btDelete.FillColor = System.Drawing.Color.Transparent;
            this.btDelete.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btDelete.ForeColor = System.Drawing.Color.White;
            this.btDelete.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.btDelete.HoverState.FillColor = System.Drawing.Color.White;
            this.btDelete.HoverState.ForeColor = System.Drawing.Color.Blue;
            this.btDelete.HoverState.Parent = this.btDelete;
            this.btDelete.Image = global::K_M_S_PROGRAM.Properties.Resources.de;
            this.btDelete.Location = new System.Drawing.Point(9, 7);
            this.btDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.ShadowDecoration.Parent = this.btDelete;
            this.btDelete.Size = new System.Drawing.Size(38, 40);
            this.btDelete.TabIndex = 53;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // sataPictureBox2
            // 
            this.sataPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sataPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.sataPictureBox2.BackgroundImage = global::K_M_S_PROGRAM.Properties.Resources.inbox;
            this.sataPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sataPictureBox2.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.sataPictureBox2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.sataPictureBox2.BorderSize = 1;
            this.sataPictureBox2.GradientAngle = 50F;
            this.sataPictureBox2.Location = new System.Drawing.Point(939, 7);
            this.sataPictureBox2.Name = "sataPictureBox2";
            this.sataPictureBox2.Size = new System.Drawing.Size(43, 43);
            this.sataPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sataPictureBox2.TabIndex = 19;
            this.sataPictureBox2.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(805, 13);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(128, 31);
            this.label12.TabIndex = 16;
            this.label12.Text = "سجل الرسائل";
            // 
            // sEllipse1
            // 
            this.sEllipse1.CornerRadius = 20;
            this.sEllipse1.TargetControl = this.dgvMessageArchive;
            // 
            // Message_Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(997, 658);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Message_Archive";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Tag = "2097152";
            this.Text = "Message_Arshif";
            this.Load += new System.EventHandler(this.Message_Archive_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessageArchive)).EndInit();
            this.sataPanel1.ResumeLayout(false);
            this.sataPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroGrid dgvMessageArchive;
        private SATAUiFramework.SATAPanel sataPanel1;
        private SATAUiFramework.Controls.SATAPictureBox sataPictureBox2;
        private System.Windows.Forms.Label label12;
        private Sipaa.Framework.SEllipse sEllipse1;
        private Guna.UI2.WinForms.Guna2TextBox txSearsh;
        private Guna.UI2.WinForms.Guna2Button btDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private CodeeloUI.Controls.CodeeloRadioButton rdKids;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CodeeloUI.Controls.CodeeloRadioButton rdTeachers;
        private CodeeloUI.Controls.CodeeloRadioButton rdWorkers;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}