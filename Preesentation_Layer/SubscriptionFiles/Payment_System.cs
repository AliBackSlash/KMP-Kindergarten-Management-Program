using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.Kids_sFile.AddChaild;
using MyBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace K_M_S_PROGRAM.Resources
{
    public partial class Payment_Subsciptions : Form
    {
        public Payment_Subsciptions()
        {
            InitializeComponent();
        }

        float Amount;
        float Paid;
        float Remender;
        DateTime CurrentRowDate;
        string CurrentName = "";
        DataTable table = null;
        private void ShowPayMentInfo(string Code="")
        {
            table = clsSubscriptions.GetPaymentSubscriptionInfo(Code);
            dgvPaymentSubscriotins.Rows.Clear();
            Image image = null;
            string periood = "";
            float amount = 0;

            foreach (DataRow row in table.Rows)
            {
                image = (bool)row["Gendor"] ? Properties.Resources.boy : Properties.Resources.girl;
                periood = (bool)row["Period"] ? "صباحي" : "مسائي";
                amount = Convert.ToSingle(row["Amount"]);
                dgvPaymentSubscriotins.Rows.Add(image, row["Code"], row["Name"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.MonthFormat), row["Level"],
                    row["Class"], periood, amount, amount, "دفع");


            }
           
        }

        private void Payment_Subsciptions_Load(object sender, EventArgs e)
        {
            ShowPayMentInfo();

        }

        public void btRefreash_Click()
        {
            dgvPaymentSubscriotins.Rows.Clear();
            ShowPayMentInfo();


        }

        //make debuge to see the paid amount why is not changaed
        private bool SaveHistory(DataRow row, float paid)
        {
            Amount = Convert.ToInt16(row["Amount"]);
            Remender = Amount-paid ;
            Paid = paid;

            return clsSubscriptions.AddToPaymentHistory( Paid, DateTime.Now, Remender, row["Code"].ToString(), CurrentRowDate.ToString("MM-yyyy"),clsGlobal.CurrentUser.Code);
        }
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        private void SaveHistory(string Code,string Paid)
        {
            table = clsSubscriptions.GetPaymentSubscriptionInfo(Code);
            foreach (DataRow row in table.Rows)
            {
                if (row["Code"].ToString()==Code)
                    if(SaveHistory(row, Convert.ToSingle(Paid)))
                    {
                        if(clsGlobal.Settings.AskBeforPrint)
                        {
                            if(MessageBox.Show("هل تريد طباعة الوصل؟","تأكيد",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
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

                        clsUtil.Show("تم الحفظ بنجاح");
                        clsSubscriptions.deleteSubscraipPaymentForMonth(Code);
                        return;
                    }
                    else
                    {
                        clsUtil.Show("يبدو أن بيانات الطفل غير مكتملة تأكد منها ثم اعد المحاولة", false);
                        return;
                    }

            }

        }

      
        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            dgvPaymentSubscriotins.Rows.Clear();
            ShowPayMentInfo(txSearsh.Text);
        }
       

        private void كتابةملاحظةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notes frm = new Notes(dgvPaymentSubscriotins.CurrentRow.Cells["Code"].Value.ToString(), 'C');
            frm.ShowDialog();
        }

        private void تعديلtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Child frm = new Add_Child((int)dgvPaymentSubscriotins.CurrentRow.Cells["Code"].Value);
            frm.ShowDialog();
        }

        private void إظهارإلبياناتtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChildCardfrm frm = new ChildCardfrm((int)dgvPaymentSubscriotins.CurrentRow.Cells["Code"].Value);
            frm.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (clsGlobal.Settings.SmallPaper)
                clsUtil.printDocument_Small_Size_For_Kid(ref e, CurrentName, CurrentRowDate.ToString("MMMM yyyy"),DateTime.Now.ToString("yyyy-MM-dd"), Amount, Paid, Remender,false, clsGlobal.Settings.ManagerName);
            else
                clsUtil.printDocument_Large_Size_For_Kid(ref e, CurrentName, CurrentRowDate.ToString("MMMM yyyy"), DateTime.Now.ToString("yyyy-MM-dd"), Amount, Paid, Remender, false, clsGlobal.Settings.ManagerName);

        }

        private void دفعالإشتراكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvPaymentSubscriotins.EndEdit();

            Parallel.Invoke(() => {
                CurrentRowDate = DateTime.ParseExact(dgvPaymentSubscriotins.CurrentRow.Cells["Date"].Value.ToString(), clsUtil.MonthFormat, null);
                CurrentName = dgvPaymentSubscriotins.CurrentRow.Cells["Name"].Value.ToString();
            });
           

            SaveHistory(dgvPaymentSubscriotins.CurrentRow.Cells[1].Value.ToString(),dgvPaymentSubscriotins.CurrentRow.Cells[8].Value.ToString());
            dgvPaymentSubscriotins.Rows.Clear();
            ShowPayMentInfo(txSearsh.Text);
            
        }
    }
}
