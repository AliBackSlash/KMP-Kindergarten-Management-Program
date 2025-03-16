namespace K_M_S_PROGRAM.Resources
{
    partial class Subscription_History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPaymentHistory = new MetroFramework.Controls.MetroGrid();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remender1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTask = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.دفعالباقيoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.دفعالإشتراكToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.txSearsh = new Guna.UI2.WinForms.Guna2TextBox();
            this.btDelete = new Guna.UI2.WinForms.Guna2Button();
            this.sataPictureBox2 = new SATAUiFramework.Controls.SATAPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sEllipse1 = new Sipaa.Framework.SEllipse();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.cnTask.SuspendLayout();
            this.sataPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPaymentHistory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.sataPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 795);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvPaymentHistory
            // 
            this.dgvPaymentHistory.AllowUserToAddRows = false;
            this.dgvPaymentHistory.AllowUserToDeleteRows = false;
            this.dgvPaymentHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvPaymentHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaymentHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaymentHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaymentHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvPaymentHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Simplified Arabic", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.NullValue = "فارغة";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Olive;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2,
            this.Code,
            this.Name,
            this.DateOfPayment,
            this.Date,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.totalAmount,
            this.Remender1});
            this.dgvPaymentHistory.ContextMenuStrip = this.cnTask;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("SimSun-ExtB", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaymentHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPaymentHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvPaymentHistory.EnableHeadersVisualStyles = false;
            this.dgvPaymentHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvPaymentHistory.GridColor = System.Drawing.Color.White;
            this.dgvPaymentHistory.Location = new System.Drawing.Point(3, 98);
            this.dgvPaymentHistory.Name = "dgvPaymentHistory";
            this.dgvPaymentHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPaymentHistory.RowHeadersVisible = false;
            this.dgvPaymentHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPaymentHistory.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPaymentHistory.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvPaymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentHistory.Size = new System.Drawing.Size(1154, 694);
            this.dgvPaymentHistory.TabIndex = 13;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 200F;
            this.dataGridViewImageColumn2.HeaderText = "@";
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 43;
            // 
            // Code
            // 
            this.Code.HeaderText = "الكود";
            this.Code.Name = "Code";
            this.Code.Width = 150;
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name.HeaderText = "إسم الطفل";
            this.Name.Name = "Name";
            // 
            // DateOfPayment
            // 
            this.DateOfPayment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DateOfPayment.HeaderText = "تاريخ السداد";
            this.DateOfPayment.Name = "DateOfPayment";
            this.DateOfPayment.Width = 90;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Date.FillWeight = 60F;
            this.Date.HeaderText = "إشتراك شهر";
            this.Date.Name = "Date";
            this.Date.Width = 90;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.HeaderText = "المستوي";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.HeaderText = "إسم الفصل";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn18.HeaderText = "الفترة";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 58;
            // 
            // totalAmount
            // 
            this.totalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.totalAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.totalAmount.FillWeight = 80F;
            this.totalAmount.HeaderText = "قيمة المدفوعة";
            this.totalAmount.Name = "totalAmount";
            this.totalAmount.Width = 99;
            // 
            // Remender1
            // 
            this.Remender1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Remender1.FillWeight = 50F;
            this.Remender1.HeaderText = "المبلغ المتبقي";
            this.Remender1.Name = "Remender1";
            this.Remender1.Width = 98;
            // 
            // cnTask
            // 
            this.cnTask.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.دفعالباقيoolStripMenuItem,
            this.دفعالإشتراكToolStripMenuItem});
            this.cnTask.Name = "cnTask";
            this.cnTask.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cnTask.Size = new System.Drawing.Size(196, 76);
            this.cnTask.Opening += new System.ComponentModel.CancelEventHandler(this.cnTask_Opening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::K_M_S_PROGRAM.Properties.Resources.Vision_Test_32;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 24);
            this.toolStripMenuItem2.Text = "إظهار بيانات الطفل";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // دفعالباقيoolStripMenuItem
            // 
            this.دفعالباقيoolStripMenuItem.Image = global::K_M_S_PROGRAM.Properties.Resources.ok;
            this.دفعالباقيoolStripMenuItem.Name = "دفعالباقيoolStripMenuItem";
            this.دفعالباقيoolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.دفعالباقيoolStripMenuItem.Text = "دفع الباقي";
            this.دفعالباقيoolStripMenuItem.Click += new System.EventHandler(this.دفعالباقيoolStripMenuItem_Click);
            // 
            // دفعالإشتراكToolStripMenuItem
            // 
            this.دفعالإشتراكToolStripMenuItem.Image = global::K_M_S_PROGRAM.Properties.Resources.pound;
            this.دفعالإشتراكToolStripMenuItem.Name = "دفعالإشتراكToolStripMenuItem";
            this.دفعالإشتراكToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.دفعالإشتراكToolStripMenuItem.Text = "احصل علي وصل الدفع";
            this.دفعالإشتراكToolStripMenuItem.Click += new System.EventHandler(this.دفعالإشتراكToolStripMenuItem_Click);
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
            this.sataPanel1.Controls.Add(this.sataPictureBox2);
            this.sataPanel1.Controls.Add(this.label3);
            this.sataPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sataPanel1.Location = new System.Drawing.Point(3, 33);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(1154, 59);
            this.sataPanel1.TabIndex = 0;
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
            this.txSearsh.Location = new System.Drawing.Point(415, 5);
            this.txSearsh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txSearsh.Name = "txSearsh";
            this.txSearsh.PasswordChar = '\0';
            this.txSearsh.PlaceholderText = "ابحث بإستخدام الكود......";
            this.txSearsh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txSearsh.SelectedText = "";
            this.txSearsh.ShadowDecoration.Parent = this.txSearsh;
            this.txSearsh.ShortcutsEnabled = false;
            this.txSearsh.Size = new System.Drawing.Size(325, 49);
            this.txSearsh.TabIndex = 54;
            this.txSearsh.TextChanged += new System.EventHandler(this.txSearsh_TextChanged_1);
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
            this.btDelete.Location = new System.Drawing.Point(9, 9);
            this.btDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.ShadowDecoration.Parent = this.btDelete;
            this.btDelete.Size = new System.Drawing.Size(38, 40);
            this.btDelete.TabIndex = 53;
            this.btDelete.Click += new System.EventHandler(this.btDatete_Click);
            // 
            // sataPictureBox2
            // 
            this.sataPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sataPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.sataPictureBox2.BackgroundImage = global::K_M_S_PROGRAM.Properties.Resources.pound;
            this.sataPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sataPictureBox2.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.sataPictureBox2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.sataPictureBox2.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.sataPictureBox2.BorderSize = 0;
            this.sataPictureBox2.GradientAngle = 50F;
            this.sataPictureBox2.Location = new System.Drawing.Point(1098, 3);
            this.sataPictureBox2.Name = "sataPictureBox2";
            this.sataPictureBox2.Size = new System.Drawing.Size(53, 53);
            this.sataPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sataPictureBox2.TabIndex = 18;
            this.sataPictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(950, 16);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(142, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "سجل الإشتراكات";
            // 
            // sEllipse1
            // 
            this.sEllipse1.CornerRadius = 20;
            this.sEllipse1.TargetControl = this.dgvPaymentHistory;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Subscription_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1160, 795);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Tag = "2048";
            this.Text = "Subscription_Details";
            this.Load += new System.EventHandler(this.Payment_Subsciptions_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.cnTask.ResumeLayout(false);
            this.sataPanel1.ResumeLayout(false);
            this.sataPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sataPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SATAUiFramework.SATAPanel sataPanel1;
        private SATAUiFramework.Controls.SATAPictureBox sataPictureBox2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroGrid dgvPaymentHistory;
        private Sipaa.Framework.SEllipse sEllipse1;
        private MetroFramework.Controls.MetroContextMenu cnTask;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem دفعالإشتراكToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem دفعالباقيoolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Guna.UI2.WinForms.Guna2Button btDelete;
        private Guna.UI2.WinForms.Guna2TextBox txSearsh;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remender1;
    }
}