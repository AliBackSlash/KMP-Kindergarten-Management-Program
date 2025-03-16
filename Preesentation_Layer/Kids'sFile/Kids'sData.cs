using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Kids_sData : Form
    {
        public Kids_sData()
        {
            InitializeComponent();
        }

        DataTable datatable = null;
        private void FillComboBoxWithKidsName()
        {
            DataTable table = clsGeneric.FillComboBoxWithNames("select Code, Name from KidsPersonalInfo order by Code asc ");
            cmListKidsNames.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                cmListKidsNames.Items.Add(row["Code"]+"-"+row["Name"].ToString());
            }
        }
        private void FillChildPersonalData(DataRow row)
        {
            lbCode.Text = row["Code"].ToString();
            string Path = row["Image"].ToString();
            if (Path != "")
                if(File.Exists(Path))
                picChailPhoto.ImageLocation = Path;
            else
                picChailPhoto.Image = Properties.Resources.boy;

        }

        private void GetAllNotes()
        {
            DataTable data = clsNotes.GetNotes(lbCode.Text, 'C');

            foreach (DataRow row in data.Rows) 
            {
                dgvNotes.Rows.Add(row["Date"], row["Note"]);
            }
        }

        private void GetAlBrothers()
        {
            dgvBrothers.Rows.Clear();
            DataTable data = clsBrother.GetChildBrothers(Convert.ToInt16(lbCode.Text));

            foreach (DataRow row in data.Rows)
            {
                dgvBrothers.Rows.Add(row["Name"], Convert.ToDateTime(row["DateOfBirth"]).ToString(clsUtil.DateFormat));
            }
        }

        private void cmListKidsNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAbsence.Rows.Clear();
            dgvBrothers.Rows.Clear();
            dgvNotes.Rows.Clear();

            datatable = clsChild.GetKidsPersonalDataWithName(cmListKidsNames.Text);
            if( datatable != null )
            {
                DataRow row = datatable.Rows[0];
                if (row["Code"] + "-" + row["Name"].ToString() == cmListKidsNames.SelectedItem.ToString())
                {
                    FillChildPersonalData(row);
                    dgvNotes.Rows.Clear();
                    GetAllNotes();
                    GetAlBrothers();
                    GetAbsence();
                    return;
                }

            }

        }

       private void GetAbsence()
        {
            int Code = Convert.ToInt32(lbCode.Text);
            DataTable data = clsGeneric.ReturnGroupOfDataIWant($"select AbsenceHistory.Date from AbsenceHistory where AbsenceHistory.ID = {Code}");

            foreach (DataRow row in data.Rows)
            {
                dgvAbsence.Rows.Add(Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat));
            }
        }

        public void Kids_Menue_Load(object sender, EventArgs e)
        {
            FillComboBoxWithKidsName();
        }

    }
}
