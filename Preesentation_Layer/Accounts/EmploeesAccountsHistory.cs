using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;

namespace K_M_S_PROGRAM.Resources
{
    public partial class EmploeesAccountsHistory : Form
    {
        public EmploeesAccountsHistory()
        {
            InitializeComponent();
        }

        //اعمل فصل بين العمال والمزظفين وقوم بالخطوات المناسبة

        char Kind = 'T';

        private void FillHistoryTable(string Code="",DateTime? Date = null)
        {
            DataTable data = null;
            Image image = null;
            string Period = "";
            if (ckDateTo.Checked)
                data = clsEmployeesAccounts.GetEmployeesAccountHistoryBetweenTwoDate(Kind,DTPDateFrom.Value,DTPDateTo.Value);
            else
                data = clsEmployeesAccounts.GetEmployeesAccountHistory(Kind);
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.man1 : Properties.Resources.woman;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvPaymentHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToInt16(row["Amount"]), row["AddM"], row["Dis"], Period);

                }
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.man1 : Properties.Resources.woman;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvPaymentHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToInt16(row["Amount"]), row["AddM"], row["Dis"], Period);

                    }


                }
            }
            else if (Code == "" && ckDate.Checked == false) 
            {
                foreach (DataRow row in data.Rows)
                {

                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.man1 : Properties.Resources.woman;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvPaymentHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToInt16(row["Amount"]), row["AddM"], row["Dis"], Period);

                }

            }
            else if(Code != "" && ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if(Code== row["ID"].ToString())
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.man1 : Properties.Resources.woman;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvPaymentHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToInt16(row["Amount"]), row["AddM"], row["Dis"], Period);

                    }
                }
            }
            else if (Code == "" && ckDate.Checked == true)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (Date == (DateTime)row["Date"])
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.man1 : Properties.Resources.woman;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvPaymentHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToInt16(row["Amount"]), row["AddM"], row["Dis"], Period);

                    }
                }
            }
            else if (Code != "" && ckDate.Checked == true)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (Date == (DateTime)row["Date"]&& Code == row["ID"].ToString())
                    {
                        image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.man1 : Properties.Resources.woman;
                        Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                        dgvPaymentHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToInt16(row["Amount"]), row["AddM"], row["Dis"], Period);

                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    image = Convert.ToBoolean(row["Gendor"]) ? Properties.Resources.man1 : Properties.Resources.woman;
                    Period = Convert.ToBoolean(row["Period"]) ? "صباحي" : "مسائي";
                    dgvPaymentHistory.Rows.Add(image, row["ID"], row["Name"], Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToInt16(row["Amount"]), row["AddM"], row["Dis"], Period);

                }
            }
        }

        private void EmploeesAccountsHistory_Load(object sender, EventArgs e)
        {
            DTPDateFrom.MaxDate = DateTime.Now;
            DTPDateTo.MaxDate = DateTime.Now;
            FillHistoryTable();
        }

        public void btRefreash_Click()
        {
            dgvPaymentHistory.Rows.Clear();
            FillHistoryTable();
        }

        private void tsSearsh__TextChanged(object sender, EventArgs e)
        {
            dgvPaymentHistory.Rows.Clear();
            FillHistoryTable(txSearsh.Text, DTPDateFrom.Value.Date);
        }

        MyMessage message = new MyMessage();
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع السجل ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                if (clsGeneric.DeleteTableData("truncate table EmployeesAccountsHistory"))
                {
                    message.lbTitale.Text = "تم مسح السجل";
                    message.pic.BackgroundImage = Properties.Resources.ok;

                    message.ShowDialog();
                    dgvPaymentHistory.Rows.Clear();
                    FillHistoryTable();

                }
                else
                {
                    message.lbTitale.Text = "يبدو أن البيانات مشغولة حاول لاحقا";
                    message.pic.BackgroundImage = Properties.Resources.notRegster1;

                    message.ShowDialog();
                }
            }
        }

        private void codeeloDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvPaymentHistory.Rows.Clear();
            DTPDateTo.MinDate = DTPDateFrom.Value;
            FillHistoryTable(txSearsh.Text , DTPDateFrom.Value.Date);
            
        }

        private void ShowDateToControlWithDrivedControls()
        {
            lbTo.Visible = ckDate.Checked;
            lbFrom.Visible = ckDate.Checked;
            DTPDateTo.Visible = ckDate.Checked;
            ckDateTo.Visible = ckDate.Checked;
            if (ckDate.Checked)
                btDelete.Location = new Point(347, 25);                
            else
            {
                btDelete.Location = new Point(181, 24);
                ckDateTo.Checked = false;
            }

        }
        private void rdDate_CheckedChanged(object sender, EventArgs e)
        {
            dgvPaymentHistory.Rows.Clear();
            FillHistoryTable(txSearsh.Text, DTPDateFrom.Value.Date);
            ShowDateToControlWithDrivedControls();
        }

        private void rdTeacher_CheckedChanged(object sender, EventArgs e)
        {
            Kind = 'T';
            dgvPaymentHistory.Rows.Clear();

            FillHistoryTable(txSearsh.Text, DTPDateFrom.Value.Date);
        }

        private void rdWorker_CheckedChanged(object sender, EventArgs e)
        {
            Kind = 'W';
            dgvPaymentHistory.Rows.Clear();

            FillHistoryTable(txSearsh.Text, DTPDateFrom.Value.Date);
        }

        private void ckDateTo_CheckedChanged(object sender, EventArgs e)
        {
            dgvPaymentHistory.Rows.Clear();
            FillHistoryTable(txSearsh.Text, DTPDateFrom.Value.Date);
        }

        private void txSearsh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
