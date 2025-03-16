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
    public partial class NotesArchive : Form
    {
        public NotesArchive()
        {
            InitializeComponent();
        }

        enum enKind { Teacher,Worker,Kids}

        enKind kind = enKind.Kids;

        DataTable data = null;

        private void FillNotesArchiveMenueWithKidsNotes()
        {
            dgvNotesArchive.Rows.Clear();
            foreach (DataRow row in data.Rows) 
            {
                if (Convert.ToChar(row["Kind"]) == 'C')
                    dgvNotesArchive.Rows.Add(row["Name"], row["Date"], "طالب", row["Note"]);
            }
        }

        private void FillNotesArchiveMenueWithTeachersNotes()
        {
            dgvNotesArchive.Rows.Clear();

            foreach (DataRow row in data.Rows)
            {
                if (Convert.ToChar(row["Kind"]) == 'T')
                    dgvNotesArchive.Rows.Add(row["Name"], row["Date"], "معلم", row["Note"]);
            }
        }


        private void FillNotesArchiveMenueWithWorkersNotes()
        {
            dgvNotesArchive.Rows.Clear();

            foreach (DataRow row in data.Rows)
            {
                if (Convert.ToChar(row["Kind"]) == 'W')
                    dgvNotesArchive.Rows.Add(row["Name"], row["Date"], "عامل", row["Note"]);
            }
        }

        public void FillMenueWithResult()
        {
            switch(kind)
            {
               
                case enKind.Kids:

                    dgvNotesArchive.Rows.Clear();
                    data = clsNotes.GetAllNotesForKids(txSearsh.Text);
                    FillNotesArchiveMenueWithKidsNotes();
                    

                    break;

                case enKind.Teacher:

                    dgvNotesArchive.Rows.Clear();
                    data = clsNotes.GetAllNotesForTeachers(txSearsh.Text);
                    FillNotesArchiveMenueWithTeachersNotes();
                    
                    break;

                case enKind.Worker:

                    dgvNotesArchive.Rows.Clear();
                    data = clsNotes.GetAllNotesForWorkers(txSearsh.Text);
                    FillNotesArchiveMenueWithWorkersNotes();
                    

                    break;
            }
        }

        private void btTeachers_Click(object sender, EventArgs e)
        {
            kind = enKind.Teacher;
            FillMenueWithResult();
        }

        private void btWorkers_Click(object sender, EventArgs e)
        {
            kind = enKind.Worker;
            FillMenueWithResult();
        }

        private void btKids_Click(object sender, EventArgs e)
        {
            kind = enKind.Kids;
            FillMenueWithResult();
        }

        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            FillMenueWithResult();

        }

        MyMessage message=new MyMessage();
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل متأكد من انك تريد حذف كل السجل ", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)==DialogResult.OK)
            {
                if (clsNotes.DeleteAllRecordsInTableNotes())
                    clsUtil.Show("تم مسح كل السجل");
                else
                    clsUtil.Show("السجل بالفعل لا يحتوي علي اي بيانات", false);
            }

        }

       
    }
}
