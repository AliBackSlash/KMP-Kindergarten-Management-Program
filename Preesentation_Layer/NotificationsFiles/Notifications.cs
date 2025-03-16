using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.ImportantForms;
using K_M_S_PROGRAM.Kids_sFile.AddChaild;
using MetroFramework.Controls;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
        }
        MetroGrid Grid; string Message; char Num;
        private void SendWhatsAppMessageForAll(MetroGrid Grid,string Message,char Num)
        {
            this.Grid = Grid;
            this.Message = Message;
            this.Num = Num;

            if (BGWorker.IsBusy)
                clsUtil.Show("إنتظر حتي يتم الإنتهاء من الإرسال الحالي", false);
            else
                BGWorker.RunWorkerAsync();

        }

        private void SendWhatsAppMessageForOne(MetroGrid Grid, string Message, char Num)
        {
            try
            {
                if (clsSend.Send_Whats_App_Message_For_One(Grid.CurrentRow.Cells["Phone" + Num].Value.ToString(), Message))
                { clsUtil.Show("تم الإرسال"); clsMessageArchive.AddToMessage_Archive(Grid.CurrentRow.Cells[1].Value.ToString(), '1', Message, 'C'); }
                else
                    clsUtil.Show("لم يتم الإرسال", false);
            }
            catch (Exception)
            {

            }
        }


        private void FillBirthDay()
        {

            DataTable BirthDay = clsChild.GetKidsBirthDateNotification();
            dgvChildBrithDay.Rows.Clear();
            foreach (DataRow row in BirthDay.Rows)
            {
                dgvChildBrithDay.Rows.Add(row["Code"],row["Name"], Convert.ToDateTime(row["DateOfBirth"]).ToString(clsUtil.DateFormat), row["MessageNumber"] );
            }
        }

        private void FillBrothers()
        {
            dgvBrothers.Rows.Clear();

            DataTable dateOfBirthForBro = clsGeneric.ReturnGroupOfDataIWant(@"select BrotherInfo.Name,BrotherInfo.DateOfBirth,BrotherInfo.ChildID,KidsPersonalInfo.Name as StudentName,OtherInfo.MessageNumber  From BrotherInfo 
                inner join KidsPersonalInfo on KidsPersonalInfo.Code=BrotherInfo.ChildID inner join OtherInfo on OtherInfo.ChildID = BrotherInfo.ChildID");
            
            foreach(DataRow row in  dateOfBirthForBro.Rows)
            {
                TimeSpan d = DateTime.Now - Convert.ToDateTime(row["DateOfBirth"]);
                
                if(d.Days >= clsGlobal.Settings.KidsBratherAge)
                {
                    dgvBrothers.Rows.Add(row["ChildID"],row["StudentName"], row["Name"], row["MessageNumber"]);
                }
            }

        }


        private void FillSubLate()
        {
            dgvChildSub.Rows.Clear();

            bool Entered = false;
            if(Convert.ToByte(DateTime.Now.Day) >= clsGlobal.Settings.DaysLateToPay)
            {
                DataTable SubLate = clsGeneric.ReturnGroupOfDataIWant(@"select Name,Amount,Month(Date) as Month , Year(Date) as Year ,Code,OtherInfo.MessageNumber 
                                                                       from SubscraitionPayment inner join  OtherInfo on OtherInfo.ChildID = SubscraitionPayment.Code");
                foreach (DataRow row in SubLate.Rows)
                {
                    dgvChildSub.Rows.Add(row["Code"],row["Name"],row["Month"],row["Year"], row["Amount"], row["MessageNumber"]);
                }
                Entered = true;
            }
            //To get Late sub from last Month
            if (Entered == false)
            {
                DataTable SubLate = clsGeneric.ReturnGroupOfDataIWant(@"select Name,Amount,Month(Date) as Month , Year(Date) as Year ,Code, OtherInfo.MessageNumber 
                                                                        from SubscraitionPayment inner join  OtherInfo on OtherInfo.ChildID = SubscraitionPayment.Code where Month(Date) <> Month(GetDate())");
                foreach (DataRow row in SubLate.Rows)
                {
                    dgvChildSub.Rows.Add(row["Code"], row["Name"], row["Month"], row["Year"], row["Amount"], row["MessageNumber"]);
                }
            }
        }

        private void FillKidsAbsence()
        {

            DataTable SubLate = clsAbsences.ReturnKidsThatAbsenceMoreInThisMonth(clsGlobal.Settings.DaysKindsAbsence);

            foreach (DataRow row in SubLate.Rows)
            {
                dgvChildAbsence.Rows.Add(row["ID"],row["Name"], row["times"]);
            }
        }

        public void Notifications_Load(object sender, EventArgs e)
        {
            FillBirthDay();
            FillBrothers();
            FillKidsAbsence();
            FillSubLate();

        }

        private void ChildBrithDay_Show_Info_Click(object sender, EventArgs e)
        {
            ChildCardfrm frm = new ChildCardfrm(Convert.ToInt16(dgvChildBrithDay.CurrentRow.Cells["Code"].Value));
            frm.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            clsUtil.Show("سوف يتم تنفيذ هذه الخدمة قريبا");

        }

        private void Brothers_whatsApp_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForOne(dgvBrothers, clsGlobal.Settings.BrothersAgeMessage, '1');
        }

        private void ChildBrithDay_whatsApp_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForOne(dgvChildBrithDay, clsGlobal.Settings.BirthDayMessage, '2');
        }

        private void ChildSub_whatsApp_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForOne(dgvChildSub,clsGlobal.Settings.SubMessage, '3');
        }

        private void ChildAbsence_whatsApp_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForOne(dgvChildAbsence, clsGlobal.Settings.AbsenceMessage, '4');
        }

        private void إرسالتنبيهاليالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForAll(dgvChildBrithDay, clsGlobal.Settings.BirthDayMessage, '2');
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForAll(dgvBrothers, clsGlobal.Settings.BrothersAgeMessage, '1');
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForAll(dgvChildSub, clsGlobal.Settings.SubMessage, '3');
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            SendWhatsAppMessageForAll(dgvChildAbsence, clsGlobal.Settings.AbsenceMessage, '4');
        }

        private void حذفالأخToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("هل تريد ازلة هذا الطفل من قائمة الإخوة؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (clsBrother.delete_BrotherswithChildID((int)dgvBrothers.CurrentRow.Cells[0].Value, dgvBrothers.CurrentRow.Cells[2].Value.ToString()))
            {
                dgvBrothers.Rows.Clear();
                FillBrothers();
            }
        }

        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           
            List<string> PNumbers = new List<string>();
            List<string> Names = new List<string>();
            foreach (DataGridViewRow row in Grid.Rows)
            {

                PNumbers.Add(row.Cells["Phone" + Num].Value.ToString());
                Names.Add(row.Cells[1].Value.ToString());

            }

            try
            {
                List<string> failedNumbers = new List<string>();


                failedNumbers = clsSend.Send_Whats_App_Message_For_Group(PNumbers, Names, 'C', Message, e, BGWorker);
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

            this.Grid = null;
            this.Message = "";
            this.Num = '\0';
        }

        private void BGWorker_Stop_Click(object sender, EventArgs e)
        {
            BGWorker.CancelAsync();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ChildCardfrm frm = new ChildCardfrm(Convert.ToInt16(dgvBrothers.CurrentRow.Cells["Code1"].Value) );
            frm.ShowDialog();
        }

        private void ChildAbsence_Show_Info_Click(object sender, EventArgs e)
        {
            ChildCardfrm frm = new ChildCardfrm(Convert.ToInt16(dgvChildAbsence.CurrentRow.Cells["ID"].Value));
            frm.ShowDialog();
        }

        private void ChildSub_Show_Info_Click(object sender, EventArgs e)
        {
            ChildCardfrm frm = new ChildCardfrm(Convert.ToInt16(dgvChildSub.CurrentRow.Cells["Code2"].Value));
            frm.ShowDialog();
        }

    }
}
