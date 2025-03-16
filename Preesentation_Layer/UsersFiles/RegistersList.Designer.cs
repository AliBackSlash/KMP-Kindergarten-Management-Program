namespace K_M_S_PROGRAM.UsersFiles
{
    partial class RegistersList
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.txSearsh = new Guna.UI2.WinForms.Guna2TextBox();
            this.btDelete = new Guna.UI2.WinForms.Guna2Button();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.DTPDateFrom = new CodeeloUI.Controls.CodeeloDateTimePicker();
            this.DTPDateTo = new CodeeloUI.Controls.CodeeloDateTimePicker();
            this.ckDate = new CodeeloUI.Controls.CodeeloCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sataPictureBox2 = new SATAUiFramework.Controls.SATAPictureBox();
            this.sataPanel2 = new SATAUiFramework.SATAPanel();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRegisters = new MetroFramework.Controls.MetroGrid();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTask = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sEllipse1 = new Sipaa.Framework.SEllipse();
            this.tableLayoutPanel1.SuspendLayout();
            this.sataPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).BeginInit();
            this.sataPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisters)).BeginInit();
            this.cnTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sataPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sataPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvRegisters, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1130, 733);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // sataPanel1
            // 
            this.sataPanel1.BackColor = System.Drawing.Color.White;
            this.sataPanel1.BackColor2 = System.Drawing.Color.White;
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius1;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.txSearsh);
            this.sataPanel1.Controls.Add(this.btDelete);
            this.sataPanel1.Controls.Add(this.lbFrom);
            this.sataPanel1.Controls.Add(this.lbTo);
            this.sataPanel1.Controls.Add(this.DTPDateFrom);
            this.sataPanel1.Controls.Add(this.DTPDateTo);
            this.sataPanel1.Controls.Add(this.ckDate);
            this.sataPanel1.Controls.Add(this.label3);
            this.sataPanel1.Controls.Add(this.sataPictureBox2);
            this.sataPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sataPanel1.Location = new System.Drawing.Point(3, 53);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(1124, 74);
            this.sataPanel1.TabIndex = 0;
            // 
            // txSearsh
            // 
            this.txSearsh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txSearsh.Animated = true;
            this.txSearsh.BackColor = System.Drawing.Color.Transparent;
            this.txSearsh.BorderRadius = 10;
            this.txSearsh.BorderThickness = 2;
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
            this.txSearsh.Location = new System.Drawing.Point(444, 13);
            this.txSearsh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txSearsh.Name = "txSearsh";
            this.txSearsh.PasswordChar = '\0';
            this.txSearsh.PlaceholderText = "ابحث_ياسم_المستخدم";
            this.txSearsh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txSearsh.SelectedText = "";
            this.txSearsh.ShadowDecoration.Parent = this.txSearsh;
            this.txSearsh.ShortcutsEnabled = false;
            this.txSearsh.Size = new System.Drawing.Size(242, 47);
            this.txSearsh.TabIndex = 51;
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
            this.btDelete.Location = new System.Drawing.Point(181, 23);
            this.btDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.ShadowDecoration.Parent = this.btDelete;
            this.btDelete.Size = new System.Drawing.Size(38, 40);
            this.btDelete.TabIndex = 49;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.BackColor = System.Drawing.Color.Transparent;
            this.lbFrom.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lbFrom.ForeColor = System.Drawing.Color.Black;
            this.lbFrom.Location = new System.Drawing.Point(234, 0);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbFrom.Size = new System.Drawing.Size(26, 25);
            this.lbFrom.TabIndex = 48;
            this.lbFrom.Text = "إلي";
            this.lbFrom.Visible = false;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.BackColor = System.Drawing.Color.Transparent;
            this.lbTo.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lbTo.ForeColor = System.Drawing.Color.Black;
            this.lbTo.Location = new System.Drawing.Point(59, 0);
            this.lbTo.Name = "lbTo";
            this.lbTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTo.Size = new System.Drawing.Size(26, 25);
            this.lbTo.TabIndex = 47;
            this.lbTo.Text = "من";
            this.lbTo.Visible = false;
            // 
            // DTPDateFrom
            // 
            this.DTPDateFrom.BorderColor = System.Drawing.Color.Black;
            this.DTPDateFrom.BorderSize = 1;
            this.DTPDateFrom.CalendarFont = null;
            this.DTPDateFrom.CalendarForeColor = System.Drawing.Color.Empty;
            this.DTPDateFrom.CalendarMonthBackground = System.Drawing.Color.Empty;
            this.DTPDateFrom.CalendarTitleBackColor = System.Drawing.Color.Empty;
            this.DTPDateFrom.CalendarTitleForeColor = System.Drawing.Color.Empty;
            this.DTPDateFrom.CalendarTrailingForeColor = System.Drawing.Color.Empty;
            this.DTPDateFrom.Checked = false;
            this.DTPDateFrom.FillColor = System.Drawing.Color.White;
            this.DTPDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.DTPDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDateFrom.Location = new System.Drawing.Point(9, 28);
            this.DTPDateFrom.MinimumSize = new System.Drawing.Size(4, 35);
            this.DTPDateFrom.Name = "DTPDateFrom";
            this.DTPDateFrom.Size = new System.Drawing.Size(133, 35);
            this.DTPDateFrom.TabIndex = 32;
            this.DTPDateFrom.TextColor = System.Drawing.Color.Black;
            this.DTPDateFrom.ValueChanged += new System.EventHandler(this.txSearsh_TextChanged);
            // 
            // DTPDateTo
            // 
            this.DTPDateTo.BorderColor = System.Drawing.Color.Black;
            this.DTPDateTo.BorderSize = 1;
            this.DTPDateTo.CalendarFont = null;
            this.DTPDateTo.CalendarForeColor = System.Drawing.Color.Empty;
            this.DTPDateTo.CalendarMonthBackground = System.Drawing.Color.Empty;
            this.DTPDateTo.CalendarTitleBackColor = System.Drawing.Color.Empty;
            this.DTPDateTo.CalendarTitleForeColor = System.Drawing.Color.Empty;
            this.DTPDateTo.CalendarTrailingForeColor = System.Drawing.Color.Empty;
            this.DTPDateTo.Checked = false;
            this.DTPDateTo.FillColor = System.Drawing.Color.White;
            this.DTPDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.DTPDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDateTo.Location = new System.Drawing.Point(181, 28);
            this.DTPDateTo.MinimumSize = new System.Drawing.Size(4, 35);
            this.DTPDateTo.Name = "DTPDateTo";
            this.DTPDateTo.Size = new System.Drawing.Size(133, 35);
            this.DTPDateTo.TabIndex = 45;
            this.DTPDateTo.TextColor = System.Drawing.Color.Black;
            this.DTPDateTo.Visible = false;
            this.DTPDateTo.ValueChanged += new System.EventHandler(this.txSearsh_TextChanged);
            // 
            // ckDate
            // 
            this.ckDate.ButtonBorderSize = 1.6F;
            this.ckDate.ButtonCircleSize = 18F;
            this.ckDate.ButtonColor = System.Drawing.Color.Purple;
            this.ckDate.ButtonColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(220)))), ((int)(((byte)(95)))));
            this.ckDate.DrawCircleButton = false;
            this.ckDate.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ckDate.Location = new System.Drawing.Point(148, 33);
            this.ckDate.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.ckDate.MarkType = CodeeloUI.Enums.CheckBoxMark.Mark;
            this.ckDate.MarkWidth = 3;
            this.ckDate.Name = "ckDate";
            this.ckDate.Size = new System.Drawing.Size(27, 24);
            this.ckDate.TabIndex = 44;
            this.ckDate.UseVisualStyleBackColor = true;
            this.ckDate.CheckedChanged += new System.EventHandler(this.ckDate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(815, 16);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(238, 41);
            this.label3.TabIndex = 37;
            this.label3.Text = "تسجيلات الدخول والانصراف";
            // 
            // sataPictureBox2
            // 
            this.sataPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sataPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.sataPictureBox2.BackgroundImage = global::K_M_S_PROGRAM.Properties.Resources.absence__2_;
            this.sataPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sataPictureBox2.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.sataPictureBox2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.sataPictureBox2.BorderSize = 0;
            this.sataPictureBox2.GradientAngle = 50F;
            this.sataPictureBox2.Location = new System.Drawing.Point(1059, 9);
            this.sataPictureBox2.Name = "sataPictureBox2";
            this.sataPictureBox2.Size = new System.Drawing.Size(56, 56);
            this.sataPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sataPictureBox2.TabIndex = 18;
            this.sataPictureBox2.TabStop = false;
            // 
            // sataPanel2
            // 
            this.sataPanel2.BackColor = System.Drawing.Color.White;
            this.sataPanel2.BackColor2 = System.Drawing.Color.White;
            this.sataPanel2.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 10;
            borderRadius2.BottomRight = 10;
            borderRadius2.TopLeft = 10;
            borderRadius2.TopRight = 10;
            this.sataPanel2.BorderRadius = borderRadius2;
            this.sataPanel2.BorderThickness = 0;
            this.sataPanel2.Controls.Add(this.lbTotalRecords);
            this.sataPanel2.Controls.Add(this.label1);
            this.sataPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sataPanel2.Location = new System.Drawing.Point(3, 676);
            this.sataPanel2.Name = "sataPanel2";
            this.sataPanel2.Size = new System.Drawing.Size(1124, 54);
            this.sataPanel2.TabIndex = 14;
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalRecords.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalRecords.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lbTotalRecords.ForeColor = System.Drawing.Color.Green;
            this.lbTotalRecords.Location = new System.Drawing.Point(719, 7);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTotalRecords.Size = new System.Drawing.Size(275, 41);
            this.lbTotalRecords.TabIndex = 39;
            this.lbTotalRecords.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(1000, 7);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(110, 41);
            this.label1.TabIndex = 38;
            this.label1.Text = "عدد الأسطر";
            // 
            // dgvRegisters
            // 
            this.dgvRegisters.AllowUserToAddRows = false;
            this.dgvRegisters.AllowUserToDeleteRows = false;
            this.dgvRegisters.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRegisters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegisters.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvRegisters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegisters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvRegisters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegisters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegisters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.Column3});
            this.dgvRegisters.ContextMenuStrip = this.cnTask;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegisters.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegisters.EnableHeadersVisualStyles = false;
            this.dgvRegisters.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvRegisters.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvRegisters.Location = new System.Drawing.Point(3, 140);
            this.dgvRegisters.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dgvRegisters.Name = "dgvRegisters";
            this.dgvRegisters.ReadOnly = true;
            this.dgvRegisters.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegisters.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRegisters.RowHeadersVisible = false;
            this.dgvRegisters.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRegisters.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRegisters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRegisters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegisters.Size = new System.Drawing.Size(1124, 530);
            this.dgvRegisters.TabIndex = 15;
            // 
            // Code
            // 
            this.Code.HeaderText = "Column2";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "الإسم";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "الوقت";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "نوع العملية";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // cnTask
            // 
            this.cnTask.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.cnTask.Name = "cnTask";
            this.cnTask.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cnTask.Size = new System.Drawing.Size(195, 28);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::K_M_S_PROGRAM.Properties.Resources.Vision_Test_32;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 24);
            this.toolStripMenuItem2.Text = "إظهار بيانات المستخدم";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // sEllipse1
            // 
            this.sEllipse1.CornerRadius = 20;
            this.sEllipse1.TargetControl = this.dgvRegisters;
            // 
            // RegistersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1130, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistersList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "1073741824";
            this.Load += new System.EventHandler(this.RegistersList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.sataPanel1.ResumeLayout(false);
            this.sataPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).EndInit();
            this.sataPanel2.ResumeLayout(false);
            this.sataPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisters)).EndInit();
            this.cnTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbTo;
        private CodeeloUI.Controls.CodeeloDateTimePicker DTPDateFrom;
        private CodeeloUI.Controls.CodeeloDateTimePicker DTPDateTo;
        private CodeeloUI.Controls.CodeeloCheckBox ckDate;
        private System.Windows.Forms.Label label3;
        private SATAUiFramework.Controls.SATAPictureBox sataPictureBox2;
        private SATAUiFramework.SATAPanel sataPanel2;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroGrid dgvRegisters;
        private Guna.UI2.WinForms.Guna2Button btDelete;
        private Guna.UI2.WinForms.Guna2TextBox txSearsh;
        private MetroFramework.Controls.MetroContextMenu cnTask;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Sipaa.Framework.SEllipse sEllipse1;
    }
}