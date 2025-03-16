using K_M_S_PROGRAM.Employees_sFiles;
using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.ImportantForms;
using MyBusinessLayer;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static ZXing.QrCode.Internal.Mode;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Employees_sList : Form
    {
        public Employees_sList()
        {
            InitializeComponent();
        }


        char Kind;
        private void ShowTeacherInfo(string Name="")
        {
            DataTable table = null;
            System.Drawing.Image image = null;
            if(Name=="")
            {
                table = clsEmployee.GetTeacherListInfo();
                foreach (DataRow row in table.Rows)
                {

                    image = (bool)row["Gendor"] ? Properties.Resources.man1 : image = Properties.Resources.woman;

                    dgvEmployeesMenue.Rows.Add(image, row["Code"], row["Name"], row["Address"], row["Qualification"], row["DateOfBirth"]
                        ,clsLevels.GetLevelName(Convert.ToInt16(row["LevelID"])),clsClsases.GetClassName(Convert.ToInt16(row["ClassID"])), row["Period"], row["PhoneNumber"], row["GendorName"]);
                }
                Kind = 'T';
            }
            else
            {
                table = clsEmployee.GetTeacherListInfo(Name);
                foreach (DataRow row in table.Rows)
                {

                    image = (bool)row["Gendor"] ? Properties.Resources.man1 : image = Properties.Resources.woman;
                    
                    dgvEmployeesMenue.Rows.Add(image, row["Code"], row["Name"], row["Address"], row["Qualification"], row["DateOfBirth"]
                        , row["LevelID"], row["ClassID"], row["Period"], row["PhoneNumber"], row["GendorName"]);
                }
                Kind = 'T';
            }
           
        }

        private void ShowWorkerInfo(string Name="")
        {
            DataTable table = null;
            System.Drawing.Image image = null;
            if(Name=="")
            {
                table = clsWorker.GetWorkerListInfo();
                foreach (DataRow row in table.Rows)
                {

                    image = (bool)row["Gendor"] ? Properties.Resources.man1 : image = Properties.Resources.woman;

                    dgvEmployeesMenue.Rows.Add(image, row["Code"], row["Name"], null, null, null
                        , null, null, row["Period"], row["Phone"], row["GendorName"]);
                }
                Kind = 'W';
            }
            else
            {
                table = clsWorker.GetWorkerListInfo(Name);
                foreach (DataRow row in table.Rows)
                {

                    image = (bool)row["Gendor"] ? Properties.Resources.man1 : image = Properties.Resources.woman;

                    dgvEmployeesMenue.Rows.Add(image, row["Code"], row["Name"], null, null, null
                        , null, null, row["Period"], row["Phone"], row["GendorName"]);
                }
                Kind = 'W';
            }
            
        }

        private void Employees_sList_Load(object sender, EventArgs e)
        {
            ShowTeacherInfo();
        }

       

        private void btTeacher_Click(object sender, EventArgs e)
        {
            btEmail.Enabled = true;
            btSMS.Enabled = true;
            dgvEmployeesMenue.Rows.Clear();
            ShowTeacherInfo();
            Kind = 'T';
        }

        private void btWorker_Click(object sender, EventArgs e)
        {
            btEmail.Enabled = false;
            btSMS.Enabled = false;
            dgvEmployeesMenue.Rows.Clear();
            ShowWorkerInfo();
            Kind = 'W';
        }

        public void btRefreash_Click()
        {
            if(rdTeacher.Checked)
            {
                dgvEmployeesMenue.Rows.Clear();
                ShowTeacherInfo();
            }
            else
            {
                dgvEmployeesMenue.Rows.Clear();
                ShowWorkerInfo();
            }
        }

        private bool  DeleteWorker(int ID)
        {
            return clsWorker.DeleteWorker(ID);
        }

        private bool DeleteTeacher(int ID)
        {
            return clsEmployee.DeleteTeacher(ID);
        }
        private void btDalete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد من ازالة هذا الموظف ", "تأكيد",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bool sccess = false;
                foreach (DataGridViewRow row in dgvEmployeesMenue.Rows)
                {

                    if (btWhatsApp.Enabled)
                    {
                        sccess = DeleteTeacher((int)dgvEmployeesMenue.CurrentRow.Cells["Code"].Value);
                        dgvEmployeesMenue.Rows.Clear();
                        ShowTeacherInfo();
                        break;
                    }
                    else
                    {
                        sccess = DeleteWorker((int)dgvEmployeesMenue.CurrentRow.Cells["Code"].Value);
                        dgvEmployeesMenue.Rows.Clear();
                        ShowWorkerInfo();
                        break;
                    }


                }

                if (sccess)
                    clsUtil.Show("عملية إزالة ناجحة");
                else
                    clsUtil.Show("هذا الموظف لديه بيانات متعلقة به من بيانات في قائمة الرواتب الشهرية وغيره لذا لا يمكن حذفه", false);

            }
            else
                return;

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
            foreach (DataGridViewRow row in dgvEmployeesMenue.Rows)
            {
                if (Convert.ToBoolean(row.Cells[11].Value))
                {

                    clsNotes.AddNotes(Convert.ToInt16(row.Cells[1].Value), Note, rdTeacher.Checked ? 'T' : 'W', Date);

                }
            }
            clsUtil.Show("تم تسجيل الملاحظات ");

        }

        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            dgvEmployeesMenue.Rows.Clear();
            if (Kind == 'T')
                ShowTeacherInfo(txSearsh.Text);
            else
                ShowWorkerInfo(txSearsh.Text);

        }

        private void btAddEmployee_Click(object sender, EventArgs e)
        {
            Add_Employees frm = new Add_Employees(rdTeacher.Checked);
            frm.ShowDialog();
        }

        private void btShowInfo_Click(object sender, EventArgs e)
        {
            if(rdTeacher.Checked)
            {
                EmpInfo frm = new EmpInfo(Convert.ToInt16(dgvEmployeesMenue.CurrentRow.Cells["Code"].Value));
                frm.CallUpdate += btRefreash_Click;
                frm.ShowDialog();
            }
            else
            {
                WorkerInfo frm = new WorkerInfo (Convert.ToInt16(dgvEmployeesMenue.CurrentRow.Cells["Code"].Value));
                frm.CallUpdate += btRefreash_Click;
                frm.ShowDialog();

            }
        }

       

        private void تعديلبياناتالطفلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Employees frm = new Add_Employees(Convert.ToInt16(dgvEmployeesMenue.CurrentRow.Cells["Code"].Value),rdTeacher.Checked);
            frm.ShowDialog();
        }

        private void كتابةملاحظةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notes notes = new Notes();
            notes.Get += SaveNotes; ;
            notes.ShowDialog();

        }

        private void SaveNotes(string Note)
        {
            string Date = DateTime.Now.ToString("dd-MM-yyyy");
            if (clsNotes.AddNotes(Convert.ToInt16(dgvEmployeesMenue.CurrentRow.Cells[1].Value), Note,rdTeacher.Checked?'T':'W', Date))
                clsUtil.Show("تم حفظ الملاحظة");
            else
                clsUtil.Show("لم يتم حفظ الملاحظة",false);

        }


        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد من ازالة هذا الموظف ", "تأكيد", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            bool sccess = false;
            if (btWhatsApp.Enabled)
            {
                sccess = DeleteTeacher(Convert.ToInt16(dgvEmployeesMenue.CurrentRow.Cells["Code"].Value));
                dgvEmployeesMenue.Rows.Clear();
                ShowTeacherInfo();
              
            }
            else
            {
                sccess = DeleteWorker(Convert.ToInt16(dgvEmployeesMenue.CurrentRow.Cells["Code"].Value));
                dgvEmployeesMenue.Rows.Clear();
                ShowWorkerInfo();
              
            }



            if (sccess)
                clsUtil.Show("عملية إزالة ناجحة");
            else
                clsUtil.Show("هذا الموظف لديه بيانات متعلقة به من بيانات في قائمة الرواتب الشهرية وغيره لذا لا يمكن حذفه تأكد من انهائها اولا", false);
        }

        private void btSMS_Click(object sender, EventArgs e)
        {
            clsUtil.Show("سوف يتم تنفيذ هذه الخدمة قريبا");
        }

      
        List<string> PNumbers = new List<string>();
        List<string> Names = new List<string>();
        private void btWhatsApp_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvEmployeesMenue.Rows)
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
        string Message = "";
        private void Send(string Message)
        {
          this.Message = Message;
            if (BGWorker.IsBusy)
                clsUtil.Show("إنتظر حتي يتم الإنتهاء من الإرسال الحالي", false);
            else
                BGWorker.RunWorkerAsync();

        }

        private void واتسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sendmessagefrm frm = new Sendmessagefrm();
            frm.Message += Send_Message;
            frm.ShowDialog();

        }

        private void Send_Message(string Message)
        {
            if (clsSend.Send_Whats_App_Message_For_One(dgvEmployeesMenue.CurrentRow.Cells["Phone"].Value.ToString(), Message))
            { clsUtil.Show("تم"); clsMessageArchive.AddToMessage_Archive(dgvEmployeesMenue.CurrentRow.Cells["Name"].Value.ToString(), '1', Message, rdTeacher.Checked ? 'T' : 'W'); }
            else
                clsUtil.Show("لم تتم", false);
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> failedNumbers = new List<string>();
            failedNumbers = clsSend.Send_Whats_App_Message_For_Group(PNumbers, Names, rdTeacher.Checked ? 'T' : 'W', Message,e,BGWorker);
            if (failedNumbers.Count >= 0)
                clsUtil.Show("تم الإرسال بنجاح ");
            else
                clsUtil.Show($"هناك مايقرب من {failedNumbers.Count} لم يتم الارسال لهم", false);

            PNumbers.Clear();
            Names.Clear();
        }

        private void btStopSend_Click(object sender, EventArgs e)
        {
            BGWorker.CancelAsync();
        }
    }
}
