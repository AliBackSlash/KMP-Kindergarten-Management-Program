using K_M_S_PROGRAM.Accounts;
using K_M_S_PROGRAM.Employees_sFiles;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static Xamarin.Essentials.Permissions;

namespace K_M_S_PROGRAM.Resources
{
    public partial class EmploeesAccounts : Form
    {
        public EmploeesAccounts()
        {
            InitializeComponent();
        }

        float Amount1 = 0;
        float TotalAmountForTeacher = 0;
        float TotalAmountForWorkwe = 0;
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        string CurrentName = "";
        DateTime CurrentRowDate = new DateTime();

        float Incentives = 0;
        float Dedication = 0;
        private void Kids_s_Subscriptions_Load(object sender, EventArgs e)
        {
            GetTeachersAmountsInfo();  
            GetWorkersAmountsInfo();

        }

        private bool AddToEmployeesAccountHistory(int Code, float add, float dis,float salary, DateTime SalaryMonth,char Kind )
        {
            Incentives = add;
            Dedication = dis;
            salary += Incentives;
            salary -= Dedication;
            

            return clsEmployeesAccounts.AddEmployeesAccountstoHistory(Code, DateTime.Now, add,dis, salary,
                SalaryMonth, Kind,clsGlobal.CurrentUser.Code);
        }
       
        private void SaveEmpToHistory()

        {
           

            if (AddToEmployeesAccountHistory((int)dgvEmployeesAmounts.CurrentRow.Cells["Code"].Value,
                        dgvEmployeesAmounts.CurrentRow.Cells["AddM"].Value != null ? Convert.ToSingle(dgvEmployeesAmounts.CurrentRow.Cells["AddM"].Value ): 0, Convert.ToSingle(dgvEmployeesAmounts.CurrentRow.Cells["Dis"].Value),
                        Convert.ToSingle(dgvEmployeesAmounts.CurrentRow.Cells["Amount"].Value), DateTime.ParseExact(dgvEmployeesAmounts.CurrentRow.Cells["Date"].Value.ToString(), "MM-yyyy", null), 'T'))
            {
                if (clsGlobal.Settings.AskBeforPrint)
                {
                    if (MessageBox.Show("هل تريد طباعة الوصل؟", "تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if(clsGlobal.Settings.ShowBeforPrint)
                        {
                            printPreviewDialog.Document = printDocument1;
                            printPreviewDialog.ShowDialog();
                        }
                       
                         printDocument1.Print();
                    }
                }
                else
                {
                    if (clsGlobal.Settings.ShowBeforPrint)
                    {
                        printPreviewDialog.Document = printDocument1;
                        printPreviewDialog.ShowDialog();
                    }
                    printDocument1.Print();
                }

                clsUtil.Show($"تمت دفع راتب أ/ {dgvEmployeesAmounts.CurrentRow.Cells["Name"].Value} (بنجاح)");
                clsEmployeesAccounts.DeleteMonthlyAccountDataForEmployss(dgvEmployeesAmounts.CurrentRow.Cells["Code"].Value.ToString(),
                   DateTime.ParseExact(dgvEmployeesAmounts.CurrentRow.Cells["Date"].Value.ToString(), "MM-yyyy", null));
                dgvEmployeesAmounts.Rows.Clear();
                GetTeachersAmountsInfo();
            }
            else
                clsUtil.Show("لم تتم  تأكد من أنك قمت بملئ المدخلات بصورة صحيحة",false);

        }            

        private void SaveWorkerToHistory()
        {
            if (AddToEmployeesAccountHistory((int)dgvWorkerAmountInfo.CurrentRow.Cells["Code1"].Value, dgvWorkerAmountInfo.CurrentRow.Cells["Add"].Value != null ? Convert.ToSingle(dgvWorkerAmountInfo.CurrentRow.Cells["Add"].Value) : 0,
                         Convert.ToSingle(dgvWorkerAmountInfo.CurrentRow.Cells["Disc"].Value), Convert.ToSingle(dgvWorkerAmountInfo.CurrentRow.Cells["Amount2"].Value) ,DateTime.ParseExact(dgvWorkerAmountInfo.CurrentRow.Cells["Date1"].Value.ToString(), "MM-yyyy", null),'W'))
            {
                if (clsGlobal.Settings.AskBeforPrint)
                {
                    if (MessageBox.Show("هل تريد طباعة الوصل؟", "تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (clsGlobal.Settings.ShowBeforPrint)
                        {
                            printPreviewDialog.Document = printDocument1;
                            printPreviewDialog.ShowDialog();
                        }
                        printDocument1.Print();
                    }
                }
                else
                {
                    if (clsGlobal.Settings.ShowBeforPrint)
                    {
                        printPreviewDialog.Document = printDocument1;
                        printPreviewDialog.ShowDialog();
                    }
                    printDocument1.Print();
                }

                clsUtil.Show($"تمت دفع راتب أ/ {dgvWorkerAmountInfo.CurrentRow.Cells[0].Value}(بنجاح)");
                clsEmployeesAccounts.DeleteMonthlyAccountDataForWorker(dgvWorkerAmountInfo.CurrentRow.Cells["Code1"].Value.ToString(),
                     DateTime.ParseExact(dgvWorkerAmountInfo.CurrentRow.Cells["Date1"].Value.ToString(), "MM-yyyy", null));
                dgvWorkerAmountInfo.Rows.Clear();
                GetWorkersAmountsInfo();

            }
            else
                clsUtil.Show("لم تتم  تأكد من أنك قمت بملئ المدخلات بصورة صحيحة", false);

        }
      
        private void GetWorkersAmountsInfo()
        {
            DataTable Workers = clsEmployeesAccounts.GetWorkerAmountInfo();
            string DateMonth = "";
            float discount = 0;
            string AmountDiscount = "0";
            byte AbsenceDiscount = 0;

          

            foreach (DataRow row in Workers.Rows)
            {
                DateMonth = Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy");

                discount = clsGeneric.ReturnLastValueIWantINT($"select sum(cast(Late as int)) from EnterAndLeaveHistory where EnterAndLeaveHistory.ID={Convert.ToUInt16(row["Code"])} " +
                    $"and EnterAndLeaveHistory.Kind='W' and EnterAndLeaveHistory.month='{DateMonth}'");

                AbsenceDiscount = Convert.ToByte(clsGeneric.ReturnLastValueIWantINT($"select count(id) from AbsenceHistory where " +
                    $" AbsenceHistory.ID={Convert.ToUInt16(row["Code"])} and AbsenceHistory.Kind='W' and AbsenceHistory.DateMonthForAbsnce='{DateMonth}'"));

                discount = discount / 60;

                AmountDiscount = ((clsGlobal.Settings.LateDiscount * discount) + clsGlobal.Settings.AbsenceLate * AbsenceDiscount).ToString();


                dgvWorkerAmountInfo.Rows.Add(row["Code"],row["Name"], DateMonth, Convert.ToInt32(row["Amount"]), null, AmountDiscount);
            }

            if (Workers.Rows.Count > 0)
                TotalAmountForWorkwe = Convert.ToSingle(Workers.Compute("SUM(Amount)", string.Empty));
            else
                TotalAmountForWorkwe = 0;

            lbTotalAmountForWorkers.Text = TotalAmountForWorkwe.ToString();

            if (TotalAmountForTeacher == 0 && TotalAmountForWorkwe == 0)
                lbTotal.Text = "0";
            else
                lbTotal.Text = (TotalAmountForWorkwe + TotalAmountForTeacher).ToString();

        }
        private void GetTeachersAmountsInfo()
        {
            DataTable Emps = clsEmployeesAccounts.GetEmployeesAmountInfo();
            string DateMonth = "";
            float discount = 0;
            string AmountDiscount = "0";
            byte AbsenceDiscount = 0;

            foreach (DataRow row in Emps.Rows)
            {
                DateMonth = Convert.ToDateTime(row["SalaryMonth"]).ToString("MM-yyyy");
                discount = clsGeneric.ReturnLastValueIWantINT($"select round( sum(cast(Late as int)),4) from EnterAndLeaveHistory where" +
                    $" EnterAndLeaveHistory.ID={Convert.ToUInt16(row["Code"])} and EnterAndLeaveHistory.Kind='T' and EnterAndLeaveHistory.month='{DateMonth}'");
                AbsenceDiscount = Convert.ToByte(clsGeneric.ReturnLastValueIWantINT($"select count(id) from AbsenceHistory where " +
                    $" AbsenceHistory.ID={Convert.ToInt16(row["Code"])} and AbsenceHistory.Kind='T' and AbsenceHistory.DateMonthForAbsnce='{DateMonth}'"));
                
                discount = discount / 60;

                AmountDiscount = ((clsGlobal.Settings.LateDiscount * discount) + (clsGlobal.Settings.AbsenceLate * AbsenceDiscount)).ToString();
                
                dgvEmployeesAmounts.Rows.Add(row["Code"],row["Name"], DateMonth, Convert.ToInt32(row["Amount"]),null, AmountDiscount);
            }




            if (Emps.Rows.Count > 0)
                TotalAmountForTeacher = Convert.ToSingle(Emps.Compute("SUM(Amount)", string.Empty));
            else
                TotalAmountForTeacher = 0;
            lbTotalAmountForTeachers.Text = TotalAmountForTeacher.ToString();

            if (TotalAmountForTeacher == 0 && TotalAmountForWorkwe == 0)
                lbTotal.Text = "0";
            else
                lbTotal.Text = (TotalAmountForWorkwe + TotalAmountForTeacher).ToString();

        }
        public void Refreash1()
        {
            dgvEmployeesAmounts.Rows.Clear();
            dgvWorkerAmountInfo.Rows.Clear();
            GetTeachersAmountsInfo();
            GetWorkersAmountsInfo();
        }
       
        private void تفاصيلالخصمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiscountInfo frm = new DiscountInfo((int)dgvEmployeesAmounts.CurrentRow.Cells["Code"].Value, dgvEmployeesAmounts.CurrentRow.Cells["Date"].Value.ToString());
            frm.ShowDialog();
        }

        private void metroContextMenu1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvEmployeesAmounts.CurrentRow.Cells[5].Value.ToString() == "0")
                    تفاصيلالخصمToolStripMenuItem.Enabled = false;
                else
                    تفاصيلالخصمToolStripMenuItem.Enabled = true;
            }
            catch
            { 
                تفاصيلالخصمToolStripMenuItem.Enabled = false; 
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DiscountInfo frm = new DiscountInfo((int)dgvWorkerAmountInfo.CurrentRow.Cells["Code1"].Value, dgvWorkerAmountInfo.CurrentRow.Cells["Date1"].Value.ToString(),'W');
            frm.ShowDialog();
        }

        private void MetroContextMenu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvWorkerAmountInfo.CurrentRow.Cells[5].Value.ToString() == "0")
                    toolStripMenuItem1.Enabled = false;
                else
                    toolStripMenuItem1.Enabled = true;
            }
            catch
            {
                toolStripMenuItem1.Enabled = false;
            }
        }

        private void دفعالراتبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvEmployeesAmounts.EndEdit();
            dgvWorkerAmountInfo.EndEdit();

            Parallel.Invoke(() => {
                Amount1 = Convert.ToSingle(dgvEmployeesAmounts.CurrentRow.Cells["Amount"].Value);
                CurrentRowDate = DateTime.ParseExact(dgvEmployeesAmounts.CurrentRow.Cells["Date"].Value.ToString(), clsUtil.MonthFormat, null);
                CurrentName = dgvEmployeesAmounts.CurrentRow.Cells["Name"].Value.ToString();
            });
            SaveEmpToHistory();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EmpInfo empInfo = new EmpInfo(Convert.ToInt16(dgvEmployeesAmounts.CurrentRow.Cells["Code"].Value));
            
            empInfo.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            WorkerInfo workerInfo = new WorkerInfo(Convert.ToInt16(dgvWorkerAmountInfo.CurrentRow.Cells["Code1"].Value));
            workerInfo.ShowDialog();
        }

        private void دفعالراتبToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dgvEmployeesAmounts.EndEdit();
            dgvWorkerAmountInfo.EndEdit();

            Parallel.Invoke(() => {
                Amount1 = Convert.ToSingle(dgvWorkerAmountInfo.CurrentRow.Cells["Amount2"].Value);
                CurrentRowDate = DateTime.ParseExact(dgvWorkerAmountInfo.CurrentRow.Cells["Date1"].Value.ToString(), clsUtil.MonthFormat, null);
                CurrentName = dgvWorkerAmountInfo.CurrentRow.Cells["Name1"].Value.ToString();
            });
            SaveWorkerToHistory();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (clsGlobal.Settings.SmallPaper)
                clsUtil.printDocument_Small_Size_For_Emp(ref e, CurrentName, CurrentRowDate.ToString("MMMM yyyy"), DateTime.Now.ToString("yyyy-MM-dd"), Amount1, Incentives, Dedication, false, clsGlobal.Settings.ManagerName);
            else
                clsUtil.printDocument_Large_Size_For_Emp(ref e, CurrentName, CurrentRowDate.ToString("MMMM yyyy"), DateTime.Now.ToString("yyyy-MM-dd"), Amount1, Incentives, Dedication, false, clsGlobal.Settings.ManagerName);

        }
    }
}
