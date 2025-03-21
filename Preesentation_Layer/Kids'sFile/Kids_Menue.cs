using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.ImportantForms;
using K_M_S_PROGRAM.Kids_sFile;
using K_M_S_PROGRAM.Kids_sFile.AddChaild;
using K_M_S_PROGRAM.Kids_sFile.AddChaild.Brothers;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using ZXing;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Kids_Menue : Form
    {
        public Kids_Menue()
        {
            InitializeComponent();
        }


        string Message = "";
        DataTable table = null;
        //private void FindRecord(string Name,string )
        private  void ShowKidsInfo(string Name = "")
        {
            if (Name == "")
                table = clsChild.GetKidsMenue();
            else
                table = clsChild.GetKidsMenue(Name);

            System.Drawing.Image image = null;
            string gender = "";

            dgvKidsMenue.Rows.Clear();
            foreach (DataRow row in table.Rows)
            {
                image = (bool)row["Gendor"] ? Properties.Resources.boy : image = Properties.Resources.girl;

                dgvKidsMenue.Rows.Add(image, row[0], row[1], row[2], row[3],
                    Convert.ToDateTime(row[4]).ToString("dd-MM-yyyy"), row[5], row[6], row[7], row[8], row[11], 0, row["PerantID"]);

            }
            lbTotalRecords.Text = dgvKidsMenue.Rows.Count.ToString();


        }

        private void Kids_Menue_Load(object sender, EventArgs e)
        {

            ShowKidsInfo();
        }

        public void Refrish1()
        {           
            dgvKidsMenue.Rows.Clear();
            ShowKidsInfo();
        }
        private void btArchive_Click(object sender, EventArgs e)
        {
            dgvKidsMenue.EndEdit();
            bool checkedRow = false;
            bool Success = false;
            foreach (DataGridViewRow row in dgvKidsMenue.Rows)
            {
                if (Convert.ToBoolean(row.Cells[11].Value))
                {
                    if (clsChild.SetActiveChild(false, (int)row.Cells["Code"].Value))
                    {
                        Success = true; 
                        checkedRow = true;
                    }
                    else
                    {
                        checkedRow = true;
                        Success = false;

                    }

                }

            }
            if (!checkedRow)
              { clsUtil.Show("ليس هناك اي طالب محدد!", false); return; }

            Refrish1();
            if (Success)
                clsUtil.Show("تم ارشفة الطفل بنجاح");
            else
                clsUtil.Show("يبدو أن بيانات الطفل غير مكتملة تأكد منها ثم اعد المحاولة", false);


        }


        bool IsItemesChecked = false;
        private void ckCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (IsItemesChecked == false)
            {
                foreach (DataGridViewRow row in dgvKidsMenue.Rows)
                {

                    row.Cells[11].Value = true;
                }
                IsItemesChecked = true;
            }
            else
            {
                foreach (DataGridViewRow row in dgvKidsMenue.Rows)
                {
                    row.Cells[11].Value = false;
                }
                IsItemesChecked = false;
            }

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("هل انت متأكد من ازالة هذا الطفل\nعند اختارك موافق سيتم حذف الطفل بكل مشتقاته ", "تأكيد",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (clsChild.DeleteChildWhithAllInfo((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value, dgvKidsMenue.CurrentRow.Cells["PerantID"].Value?.ToString()))
                    clsUtil.Show("تم إزالة الطفل بنجاح");
                else
                    clsUtil.Show(" لم تتم إزالة الطفل ",false);

                table = clsChild.GetKidsMenue();
                dgvKidsMenue.Rows.Clear();
                ShowKidsInfo();
            }
        }

        private void btNotes_Click(object sender, EventArgs e)
        {

            Notes notes = new Notes();
            notes.Get += Save_Notes;
            notes.ShowDialog();

        }

        private void Save_Notes(string Note)
        {
            string Date = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (DataGridViewRow row in dgvKidsMenue.Rows)
            {
                if (Convert.ToBoolean(row.Cells[11].Value))
                {

                    clsNotes.AddNotes((int)row.Cells[1].Value, Note, 'C', Date);

                }
            }
            clsUtil.Show("تم تسجيل الملاحظات ");

        }


        private void كتابةملاحظةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notes notes = new Notes();
            notes.Get += SaveNotes;
            notes.ShowDialog();
        }

        private void SaveNotes(string Note)
        {
            string Date = DateTime.Now.ToString("dd-MM-yyyy");

            if (clsNotes.AddNotes((int)dgvKidsMenue.CurrentRow.Cells[1].Value, Note, 'C', Date))
                clsUtil.Show("تم حفظ الملاحظة");
            else
                clsUtil.Show("لم يتم حفظ الملاحظة", false);

        }

        private void نقلاليالأرشيفToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (clsChild.SetActiveChild(false,(int)dgvKidsMenue.CurrentRow.Cells["Code"].Value))
            {
                clsUtil.Show("تم ارشفة الطفل بنجاح");
                Refrish1();
            }
            else
            {

                clsUtil.Show("يبدو أن بيانات الطفل غير مكتملة تأكد منها ثم اعد المحاولة", false);
            }

        }

        private void btChildInfo_Click(object sender, EventArgs e)
        {
            ChildCardfrm childCardfrm = new ChildCardfrm((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            childCardfrm.CallUpdate += Refrish1;
            childCardfrm.ShowDialog();
        }

        private void btAddBrother_Click(object sender, EventArgs e)
        {
            AddUpdate_brothers add_Brothers = new AddUpdate_brothers((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            add_Brothers.ShowDialog();
        }

        private void إضافةبياناتالأبوينToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddPerant addPerant = new AddPerant((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            addPerant.ShowDialog();
        }

        private void تعديلبياناتالاباءToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddPerant addPerant = new AddPerant((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value, (int)dgvKidsMenue.CurrentRow.Cells["PerantID"].Value);
            addPerant.ShowDialog();
        }

        private void cnTask_Opening(object sender, CancelEventArgs e)
        {
            int PerantID = 0;
            if (dgvKidsMenue.CurrentRow.Cells["PerantID"].Value != System.DBNull.Value)
                PerantID = (int)dgvKidsMenue.CurrentRow.Cells["PerantID"].Value;

            int Code = 0;
            Code = (int)dgvKidsMenue.CurrentRow.Cells["Code"].Value;

            bool HasPerant = clsPerant.ISAlreadyHasPerantInSystem(PerantID);
            bool HasPersonCanTake = clsPersonCanTake.ISAlreadyHasPersonCanTake(Code);
            إضافةبياناتالأبوينToolStripMenuItem1.Enabled = (!HasPerant);
            تعديلبياناتالاباءToolStripMenuItem.Enabled = HasPerant;

            إضافةمستلمToolStripMenuItem1.Enabled = (!HasPersonCanTake);
            تعديلبياناتالمستلمToolStripMenuItem.Enabled = HasPersonCanTake;
        }

        private void إضافةمستلمToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddParsonCanTake personCanTake = new AddParsonCanTake((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            personCanTake.ShowDialog();
        }

        private void تعديلبياناتالمستلمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddParsonCanTake personCanTake = new AddParsonCanTake((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value, true);
            personCanTake.ShowDialog();
        }

        private void إضافةأخToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddUpdate_brothers add_Brothers = new AddUpdate_brothers((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            add_Brothers.ShowDialog();
        }

        private void addChild_Click(object sender, EventArgs e)
        {
            Add_Child add_ = new Add_Child('a');
            add_.btClose.Visible = true;
            add_.ShowDialog();
            Refrish1();

        }

        private void إظهاربياناتالطفلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildCardfrm childCardfrm = new ChildCardfrm((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            childCardfrm.CallUpdate += Refrish1;
            childCardfrm.ShowDialog();
        }

        private void إضافةطفلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Child add_ = new Add_Child('a');
            add_.btClose.Visible = true;

            add_.ShowDialog();
            Refrish1();
        }

        private void تعديلبياناتالطفلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Child add_ = new Add_Child((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            add_.btClose.Visible = true;

            add_.ShowDialog();
            Refrish1();
        }

        private void تعديلبياناتالأخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdate_brothers add_Brothers = new AddUpdate_brothers((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value, true);
            add_Brothers.ShowDialog();
        }

       
        private void قائمةالإخوةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrothersMenue frm = new BrothersMenue((int)dgvKidsMenue.CurrentRow.Cells["Code"].Value);
            if (frm.found)
                frm.ShowDialog();
        }

        private void طباعةالباركودToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = dgvKidsMenue.CurrentRow.Cells["Code"].Value.ToString();
            if (!string.IsNullOrEmpty(text))
            {
                picBarcode.Image = GenerateBarcode(text, picBarcode.Width, picBarcode.Height);
                PrintBarcodeButton();
            }
            else
            {
                MessageBox.Show("Please enter a valid text.");
            }
        }
        private Bitmap GenerateBarcode(string text, int width, int height)
        {
            var options = new ZXing.Common.EncodingOptions
            {
                Width = width,
                Height = height,
                Margin = 0 // إزالة الهوامش لملء صورة الباركود بكاملها
            };

            var writer = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = options
            };

            return writer.Write(text);
        }
        private void PrintBarcodeButton()
        {
            if (picBarcode != null)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                PrintPreviewDialog printDialog = new PrintPreviewDialog();
                printDialog.Document = printDocument;

                printDocument.Print();
                
            }
            else
            {
                MessageBox.Show("Please generate a barcode first.");
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (picBarcode != null)
            {
                e.Graphics.DrawImage(picBarcode.Image, new Point(10, 10));
            }
        }
        List<string> PNumbers = new List<string>();
            List<string> Names = new List<string>();
        private void btSendWhatsApp_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvKidsMenue.Rows)
            {
                if (Convert.ToBoolean(row.Cells[11].Value))
                {
                    PNumbers.Add(row.Cells[9].Value.ToString());
                    Names.Add(row.Cells[2].Value.ToString());
                }
            }

            Sendmessagefrm frm = new Sendmessagefrm();
            frm.Message += Send;
            frm.ShowDialog();



        }
        private void Send(string Message)
        {
            this.Message = Message;
            if (BGWorker.IsBusy)
                clsUtil.Show("إنتظر حتي يتم الإنتهاء من الإرسال الحالي", false);
            else
                BGWorker.RunWorkerAsync();
        }

        private void txSearsh_TextChanged(object sender, EventArgs e)
        {
            dgvKidsMenue.Rows.Clear();
            ShowKidsInfo(txSearsh.Text);
        }

        private void واتسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sendmessagefrm frm = new Sendmessagefrm();
            frm.Message += Send_Message;
            frm.ShowDialog();
            


        }

        private void Send_Message(string Message)
        {
            try
            {
                if (clsSend.Send_Whats_App_Message_For_One(dgvKidsMenue.CurrentRow.Cells["Phone"].Value.ToString(), Message))
                { clsUtil.Show("تم الإرسال"); clsMessageArchive.AddToMessage_Archive(dgvKidsMenue.CurrentRow.Cells["Name"].Value.ToString(), '1', Message, 'C'); }
                else
                    clsUtil.Show("لم يتم الإرسال", false);
            }
            catch (Exception)
            {

            }
        }

        private void btSendSMS_Click(object sender, EventArgs e)
        {
            clsUtil.Show("سوف يتم تنفيذ هذه الخدمة قريبا");

        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<string> failedNumbers = new List<string>();


                failedNumbers = clsSend.Send_Whats_App_Message_For_Group(PNumbers,Names,'C' ,Message,e,BGWorker);
                if (failedNumbers.Count >= 0)
                    clsUtil.Show("تم الإرسال بنجاح ");
                else
                    clsUtil.Show($"هناك مايقرب من {failedNumbers.Count} لم يتم الارسال لهم", false);

                PNumbers.Clear();
                Names.Clear();
            }
            catch (Exception)
            {
            }
            this.Message = "";
        }

        private void توقيفعمليةالإرسالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BGWorker.CancelAsync();
            
        }
    }
}
