using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class AbsenceHistory : Form
    {
        public AbsenceHistory()
        {
            InitializeComponent();
        }
        
        enum enWhoEnter { Employee, worker, child }
        enWhoEnter whoEnter = enWhoEnter.child;

        DataTable data = null;
        private void ClearBackColorForButtons()
        {
            btKids.BackColor = Color.Transparent;
            btTeacher.BackColor = Color.Transparent;
            btWorker.BackColor = Color.Transparent;

        }

        private void ShowKidsEnterAndLeaveHistory(char Kind,string Code = "")
        {
            System.Drawing.Image image = null;
            string Period = "";
            if (ckDateTo.Checked)
                data = clsAbsences.GetAbsenceHistoryDataBetweenTwoDates(Kind,DTPDateFrom.Value,DTPDateTo.Value);
            else              
                data = clsAbsences.GetAbsenceHistoryData(Kind);

            dgvAbsenceHistory.Rows.Clear();
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                }
                lbTotalRecords.Text = dgvAbsenceHistory.Rows.Count.ToString();
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                    }


                }
            }
            else if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {

                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false) 
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);
                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        if (row["ID"].ToString() == Code)
                        {
                            image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                            Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                            dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {

                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                }
            }

            lbTotalRecords.Text = dgvAbsenceHistory.Rows.Count.ToString();
        }

        private void ShowEmployeesEnterAndLeaveHistory(char Kind, string Code = "")
        {
            System.Drawing.Image image = null;
            string Period = "";

            if (ckDateTo.Checked)
                data = clsAbsences.GetAbsenceHistoryDataBetweenTwoDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
            else
                data = clsAbsences.GetAbsenceHistoryData(Kind); 
            dgvAbsenceHistory.Rows.Clear();
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                }
                lbTotalRecords.Text = dgvAbsenceHistory.Rows.Count.ToString();
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                    }


                }
            }
            else if (Code == ""&& ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {

                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                    }


                }
            }
            else if (Code != "" &&ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);
                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        if (row["ID"].ToString() == Code)
                        {
                            image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                            Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                            dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {

                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Class"], Period);

                }
            }
            lbTotalRecords.Text = dgvAbsenceHistory.Rows.Count.ToString();

        }

        private void ShowWorkerEnterAndLeaveHistory(char Kind,  string Code = "")
        {
            System.Drawing.Image image = null;
            string Period = "";

            if (ckDateTo.Checked)
                data = clsAbsences.GetAbsenceHistoryDataBetweenTwoDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
            else
                data = clsAbsences.GetAbsenceHistoryData(Kind);
            dgvAbsenceHistory.Rows.Clear();
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), "", Period);

                }
                lbTotalRecords.Text = dgvAbsenceHistory.Rows.Count.ToString();
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), "", Period);

                    }


                }
            }
            else if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {

                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat)  , "", Period);

                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false) 
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), "", Period);
                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        if (row["ID"].ToString() == Code)
                        {
                            image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                            Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                            dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), "", Period);
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {

                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvAbsenceHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), "", Period);

                }
            }
            lbTotalRecords.Text = dgvAbsenceHistory.Rows.Count.ToString();

        }

        private void btKids_Click(object sender, EventArgs e)
        {         
            ClearBackColorForButtons();
            btKids.BackColor = Color.Black;
            whoEnter = enWhoEnter.child;
            ShowAbsenceDataWithOrder();
           
        }

        private void btWorker_Click(object sender, EventArgs e)
        {
            ClearBackColorForButtons();
            btWorker.BackColor = Color.Black;
            whoEnter = enWhoEnter.worker;
            ShowAbsenceDataWithOrder();

        }

        private void btTeacher_Click(object sender, EventArgs e)
        {
            ClearBackColorForButtons();
            btTeacher.BackColor = Color.Black;
            whoEnter = enWhoEnter.Employee;
            ShowAbsenceDataWithOrder();
        }


        
        private void codeeloDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {           
            DTPDateTo.MinDate = DTPDateFrom.Value;
            if (ckDate.Checked)
                ShowAbsenceDataWithOrder();

        }

        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            ShowAbsenceDataWithOrder();
        }

        private void btDalete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع السجل ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                if (clsAbsences.DeleteAllAbsence())
                {
                    clsUtil.Show("تم مسح جميع السجل بنجاح");
                    dgvAbsenceHistory.Rows.Clear();
                    return;
                }
                else
                    clsUtil.Show("يبدو أن البيانات مشغولة حاول لاحقا", false);
            }
        }
        private void ShowDateToControlWithDrivedControls()
        {
            lbTo.Visible = ckDate.Checked;
            lbFrom.Visible = ckDate.Checked;
            DTPDateTo.Visible = ckDate.Checked;
            ckDateTo.Visible = ckDate.Checked;
            if (ckDate.Checked)
            {
                btDelete.Location = new Point(488, 19);
                btKids.Location = new Point(443, 19);
                btWorker.Location = new Point(398, 19);
                btTeacher.Location = new Point(353, 19);
            }
            else
            {
                btDelete.Location = new Point(316, 19);
                btKids.Location = new Point(271, 19);
                btWorker.Location = new Point(226, 19);
                btTeacher.Location = new Point(181, 19);
                ckDateTo.Checked = false;
            }

        }
        private void rdDate_CheckedChanged(object sender, EventArgs e)
        {
            ShowAbsenceDataWithOrder();
            ShowDateToControlWithDrivedControls();
        }

        public void ShowAbsenceDataWithOrder()
        {

            switch (whoEnter)
            {
                case enWhoEnter.child:
                    ShowKidsEnterAndLeaveHistory('C', txSearsh.Text);
                    break;

                case enWhoEnter.Employee:
                    ShowEmployeesEnterAndLeaveHistory('T', txSearsh.Text);
                    break;

                case enWhoEnter.worker:
                    ShowWorkerEnterAndLeaveHistory('W', txSearsh.Text);
                    break;
            }

        }

        private void AbsenceHistory_Load(object sender, EventArgs e)
        {
            DTPDateFrom.MaxDate = DateTime.Now;
            DTPDateTo.MaxDate = DateTime.Now;
            ShowAbsenceDataWithOrder();
        }

        private void ckDateTo_CheckedChanged(object sender, EventArgs e)
        {
            ShowAbsenceDataWithOrder();
        }

        private void DTPDateTo_ValueChanged(object sender, EventArgs e)
        {
            ShowAbsenceDataWithOrder();
        }
    }
}
