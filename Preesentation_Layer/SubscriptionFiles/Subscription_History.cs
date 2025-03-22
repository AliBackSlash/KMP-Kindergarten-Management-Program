using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.Kids_sFile.AddChaild;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Subscription_History : Form
    {
        public Subscription_History()
        {
         
            InitializeComponent();
        }


        string CurrentName;
        DateTime CurrentRowDate;
        float Amount;
        float Paid;
        float Remender;
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        private void ShowPayMentInfo(string Code="")
        {

            DataTable table = clsSubscriptions.GetPaymentHistoryInfo();
            Image image = null;
            string period = "";

            string gender = "";
            if(Code!="")
            {
                foreach (DataRow row in table.Rows)
                {

                    if(row["Code"].ToString()==Code)
                    {
                        image = (bool)row["Gendor"] ? Properties.Resources.boy : Properties.Resources.girl;
                        period = (bool)row["Period"] ? "صباحي" : "مسائي";

                        dgvPaymentHistory.Rows.Add(image, row["Code"], row["Name"],Convert.ToDateTime( row["DateOfPayment"]).ToString("dd-MM-yyyy"), row["Month"], row["Level"],
                            row["Class"], period, Convert.ToInt16(row["Amount"]), Convert.ToInt16(row["Remander"]));
                    }
                    
                }
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    image = (bool)row["Gendor"] ? Properties.Resources.boy : Properties.Resources.girl;
                    period = (bool)row["Period"] ? "صباحي" : "مسائي";

                    dgvPaymentHistory.Rows.Add(image, row["Code"], row["Name"], Convert.ToDateTime(row["DateOfPayment"]).ToString("dd-MM-yyyy"), row["Month"], row["Level"],
                           row["Class"], period, Convert.ToInt16(row["Amount"]),  Convert.ToInt16(row["Remander"]));

                }
            }
        }

        private void Payment_Subsciptions_Load(object sender, EventArgs e)
        {
           
            ShowPayMentInfo();

        }

        public void RefreashInfo()
        {
            dgvPaymentHistory.Rows.Clear();
            ShowPayMentInfo();

        }

       

        private void btDatete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع السجل ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                if (clsGeneric.DeleteTableData("Truncate table SubscriptionsHistory"))
                {
                    clsUtil.Show("تم مسح السجل");
                    dgvPaymentHistory.Rows.Clear();
                    ShowPayMentInfo();
                }
                else
                    clsUtil.Show("يبدو أن البيانات مشغولة حاول لاحقا", false);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChildCardfrm frm = new ChildCardfrm((int)dgvPaymentHistory.CurrentRow.Cells["Code"].Value);
            frm.ShowDialog();
        }

        private void دفعالإشتراكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentName = dgvPaymentHistory.CurrentRow.Cells["Name"].Value.ToString();
            CurrentRowDate = DateTime.ParseExact(dgvPaymentHistory.CurrentRow.Cells["Date"].Value.ToString(), "MM-yyyy", null);
            Amount = Convert.ToSingle(dgvPaymentHistory.CurrentRow.Cells["totalAmount"].Value);
            Remender = Convert.ToSingle(dgvPaymentHistory.CurrentRow.Cells["Remender1"].Value);
            Paid = Amount - Remender;
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
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (clsGlobal.Settings.SmallPaper)
                clsUtil.printDocument_Small_Size_For_Kid(ref e, CurrentName, CurrentRowDate.ToString("MMMM yyyy"), DateTime.Now.ToString("yyyy-MM-dd"), Amount, Paid, Remender, false, clsGlobal.Settings.ManagerName);
            else
                clsUtil.printDocument_Large_Size_For_Kid(ref e, CurrentName, CurrentRowDate.ToString("MMMM yyyy"), DateTime.Now.ToString("yyyy-MM-dd"), Amount, Paid, Remender, false, clsGlobal.Settings.ManagerName);

        }

        private void cnTask_Opening(object sender, CancelEventArgs e)
        {
            if(Convert.ToSingle(dgvPaymentHistory.CurrentRow.Cells["Remender1"].Value)==0)
                دفعالباقيoolStripMenuItem.Enabled = false;
            else
                دفعالباقيoolStripMenuItem.Enabled = true;


        }

        private void دفعالباقيoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsSubscriptions.UpdateRemnderForChild(dgvPaymentHistory.CurrentRow.Cells["Code"].Value.ToString(), 
                DateTime.ParseExact( dgvPaymentHistory.CurrentRow.Cells["Date"].Value.ToString(),"MM-yyyy",null),Convert.ToSingle(dgvPaymentHistory.CurrentRow.Cells["Remender1"].Value),clsGlobal.CurrentUser.Code))
                clsUtil.Show("تم تسديد المبلغ المتبقي بنجاح ");
            else
                clsUtil.Show("يوجد مشكلة ما حاول لاحقا",false);
            RefreashInfo();
        }

        private void txSearsh_TextChanged_1(object sender, EventArgs e)
        {
            dgvPaymentHistory.Rows.Clear();
            ShowPayMentInfo(txSearsh.Text);
        }
    }
}
