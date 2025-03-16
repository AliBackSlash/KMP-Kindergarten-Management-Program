namespace K_M_S_PROGRAM.TreasuryFiles
{
    partial class TreasuryData
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sataPanel4 = new SATAUiFramework.SATAPanel();
            this.btStopSend = new Guna.UI2.WinForms.Guna2Button();
            this.cmDays = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdAll = new CodeeloUI.Controls.CodeeloRadioButton();
            this.rdInputs = new CodeeloUI.Controls.CodeeloRadioButton();
            this.rdOutputs = new CodeeloUI.Controls.CodeeloRadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sataPictureBox2 = new SATAUiFramework.Controls.SATAPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTreasryMonthlyData = new MetroFramework.Controls.MetroGrid();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEllipse1 = new Sipaa.Framework.SEllipse();
            this.tableLayoutPanel1.SuspendLayout();
            this.sataPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreasryMonthlyData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sataPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1101, 692);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // sataPanel4
            // 
            this.sataPanel4.BackColor = System.Drawing.Color.White;
            this.sataPanel4.BackColor2 = System.Drawing.Color.White;
            this.sataPanel4.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel4.BorderRadius = borderRadius1;
            this.sataPanel4.BorderThickness = 0;
            this.sataPanel4.Controls.Add(this.btStopSend);
            this.sataPanel4.Controls.Add(this.cmDays);
            this.sataPanel4.Controls.Add(this.groupBox2);
            this.sataPanel4.Controls.Add(this.sataPictureBox2);
            this.sataPanel4.Controls.Add(this.label7);
            this.sataPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sataPanel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.sataPanel4.Location = new System.Drawing.Point(3, 38);
            this.sataPanel4.Name = "sataPanel4";
            this.sataPanel4.Size = new System.Drawing.Size(1095, 59);
            this.sataPanel4.TabIndex = 10;
            // 
            // btStopSend
            // 
            this.btStopSend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btStopSend.Animated = true;
            this.btStopSend.BorderColor = System.Drawing.Color.IndianRed;
            this.btStopSend.BorderRadius = 8;
            this.btStopSend.BorderThickness = 1;
            this.btStopSend.CheckedState.Parent = this.btStopSend;
            this.btStopSend.CustomImages.Parent = this.btStopSend;
            this.btStopSend.FillColor = System.Drawing.Color.Transparent;
            this.btStopSend.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btStopSend.ForeColor = System.Drawing.Color.White;
            this.btStopSend.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.btStopSend.HoverState.FillColor = System.Drawing.Color.White;
            this.btStopSend.HoverState.ForeColor = System.Drawing.Color.Blue;
            this.btStopSend.HoverState.Parent = this.btStopSend;
            this.btStopSend.Image = global::K_M_S_PROGRAM.Properties.Resources.Recovered_png_file_952_;
            this.btStopSend.Location = new System.Drawing.Point(296, 11);
            this.btStopSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btStopSend.Name = "btStopSend";
            this.btStopSend.ShadowDecoration.Parent = this.btStopSend;
            this.btStopSend.Size = new System.Drawing.Size(38, 40);
            this.btStopSend.TabIndex = 55;
            this.btStopSend.Click += new System.EventHandler(this.btStopSend_Click);
            // 
            // cmDays
            // 
            this.cmDays.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmDays.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.cmDays.FormattingEnabled = true;
            this.cmDays.Items.AddRange(new object[] {
            "0"});
            this.cmDays.Location = new System.Drawing.Point(432, 11);
            this.cmDays.Name = "cmDays";
            this.cmDays.Size = new System.Drawing.Size(230, 32);
            this.cmDays.TabIndex = 48;
            this.cmDays.SelectedIndexChanged += new System.EventHandler(this.cmDays_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdAll);
            this.groupBox2.Controls.Add(this.rdInputs);
            this.groupBox2.Controls.Add(this.rdOutputs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(9, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 39);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // rdAll
            // 
            this.rdAll.BackColor = System.Drawing.Color.Transparent;
            this.rdAll.ButtonAreaSize = 18F;
            this.rdAll.ButtonBorderSize = 1.6F;
            this.rdAll.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.rdAll.ButtonColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(220)))), ((int)(((byte)(95)))));
            this.rdAll.ButtonToggleSize = 12F;
            this.rdAll.Checked = true;
            this.rdAll.DrawCircleButton = true;
            this.rdAll.DrawCircleToggle = true;
            this.rdAll.Location = new System.Drawing.Point(248, 8);
            this.rdAll.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdAll.Name = "rdAll";
            this.rdAll.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdAll.Size = new System.Drawing.Size(26, 24);
            this.rdAll.TabIndex = 27;
            this.rdAll.TabStop = true;
            this.rdAll.UseVisualStyleBackColor = false;
            this.rdAll.CheckedChanged += new System.EventHandler(this.cmDays_SelectedIndexChanged);
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
            this.rdInputs.Location = new System.Drawing.Point(165, 8);
            this.rdInputs.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdInputs.Name = "rdInputs";
            this.rdInputs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdInputs.Size = new System.Drawing.Size(26, 24);
            this.rdInputs.TabIndex = 23;
            this.rdInputs.UseVisualStyleBackColor = false;
            this.rdInputs.CheckedChanged += new System.EventHandler(this.cmDays_SelectedIndexChanged);
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
            this.rdOutputs.Location = new System.Drawing.Point(76, 8);
            this.rdOutputs.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdOutputs.Name = "rdOutputs";
            this.rdOutputs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdOutputs.Size = new System.Drawing.Size(26, 24);
            this.rdOutputs.TabIndex = 24;
            this.rdOutputs.UseVisualStyleBackColor = false;
            this.rdOutputs.CheckedChanged += new System.EventHandler(this.cmDays_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(11, 6);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(69, 28);
            this.label5.TabIndex = 26;
            this.label5.Text = "المصروفات";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(119, 6);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(51, 28);
            this.label4.TabIndex = 25;
            this.label4.Text = "الإيرادات";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(221, 6);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(32, 28);
            this.label6.TabIndex = 28;
            this.label6.Text = "الكل";
            // 
            // sataPictureBox2
            // 
            this.sataPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sataPictureBox2.BackgroundImage = global::K_M_S_PROGRAM.Properties.Resources.pound;
            this.sataPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sataPictureBox2.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.sataPictureBox2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.sataPictureBox2.BorderSize = 1;
            this.sataPictureBox2.GradientAngle = 50F;
            this.sataPictureBox2.Location = new System.Drawing.Point(1038, 3);
            this.sataPictureBox2.Name = "sataPictureBox2";
            this.sataPictureBox2.Size = new System.Drawing.Size(48, 48);
            this.sataPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sataPictureBox2.TabIndex = 23;
            this.sataPictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(740, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(292, 33);
            this.label7.TabIndex = 2;
            this.label7.Text = "بيانات الخزينة الشهرية";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.dgvTreasryMonthlyData, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1095, 586);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // dgvTreasryMonthlyData
            // 
            this.dgvTreasryMonthlyData.AllowUserToAddRows = false;
            this.dgvTreasryMonthlyData.AllowUserToDeleteRows = false;
            this.dgvTreasryMonthlyData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dgvTreasryMonthlyData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTreasryMonthlyData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTreasryMonthlyData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTreasryMonthlyData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvTreasryMonthlyData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTreasryMonthlyData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTreasryMonthlyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreasryMonthlyData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Amount,
            this.Column1,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTreasryMonthlyData.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTreasryMonthlyData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTreasryMonthlyData.EnableHeadersVisualStyles = false;
            this.dgvTreasryMonthlyData.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvTreasryMonthlyData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTreasryMonthlyData.Location = new System.Drawing.Point(3, 7);
            this.dgvTreasryMonthlyData.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.dgvTreasryMonthlyData.Name = "dgvTreasryMonthlyData";
            this.dgvTreasryMonthlyData.ReadOnly = true;
            this.dgvTreasryMonthlyData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTreasryMonthlyData.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTreasryMonthlyData.RowHeadersVisible = false;
            this.dgvTreasryMonthlyData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTreasryMonthlyData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTreasryMonthlyData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTreasryMonthlyData.Size = new System.Drawing.Size(1089, 576);
            this.dgvTreasryMonthlyData.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "المبلغ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 63;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn6.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Amount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "الوقت";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 200;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "نوع العملية";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "عملية";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 63;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "منفذ العملية";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // sEllipse1
            // 
            this.sEllipse1.CornerRadius = 20;
            this.sEllipse1.TargetControl = this.dgvTreasryMonthlyData;
            // 
            // TreasuryData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1101, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TreasuryData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Tag = "16384";
            this.Text = "TreasuryData";
            this.Load += new System.EventHandler(this.TreasuryData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.sataPanel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreasryMonthlyData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SATAUiFramework.SATAPanel sataPanel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private CodeeloUI.Controls.CodeeloRadioButton rdAll;
        private CodeeloUI.Controls.CodeeloRadioButton rdInputs;
        private CodeeloUI.Controls.CodeeloRadioButton rdOutputs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private SATAUiFramework.Controls.SATAPictureBox sataPictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroGrid dgvTreasryMonthlyData;
        private Sipaa.Framework.SEllipse sEllipse1;
        private System.Windows.Forms.ComboBox cmDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Guna.UI2.WinForms.Guna2Button btStopSend;
    }
}