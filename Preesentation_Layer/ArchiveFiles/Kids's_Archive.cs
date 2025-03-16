using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Kids_s_Arshif : Form
    {
        public Kids_s_Arshif()
        {
            InitializeComponent();
        }

       

        DataTable table = null;
        private void ShowArchiveInfo(string name="")
        {
            if (name == "")
                table = clsChild.GetArchiveMenue();
            else
                table = clsChild.GetArchiveMenue(name);


            Image image = null;
            string gender = "";
            dgvArchiveMenue.Rows.Clear();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToBoolean(row["Gendor"]))
                { image = Properties.Resources.boy; gender = "ولد"; }
                else
                { image = Properties.Resources.girl; gender = "بنت"; }

                dgvArchiveMenue.Rows.Add(image,row["DateOfArchive"], row["Name"],row["DateOfBirth"],
                    row["Level"], row["Class"], row["Period"], row["FatherPhoneNumber"],gender,0, row["Code"]);
                


            }
        }

        public void Kids_s_Arshif_Load(object sender, EventArgs e)
        {
            ShowArchiveInfo();
        }

        bool IsItemesChecked = false;
        private void ckCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if(IsItemesChecked==false)
            {
                foreach (DataGridViewRow row in dgvArchiveMenue.Rows)
                {
                    if (row.Cells[8].Value != null)
                        row.Cells[9].Value = true;
                }
                IsItemesChecked = true;
            }
            else
            {
                foreach (DataGridViewRow row in dgvArchiveMenue.Rows)
                {
                    row.Cells[9].Value = false;
                }
                IsItemesChecked=false;
            }
            
        }
       
        private void btReturn_Click(object sender, EventArgs e)
        {
            dgvArchiveMenue.EndEdit();
            bool Success = false;
            foreach (DataGridViewRow row in dgvArchiveMenue.Rows)
            {
                if (Convert.ToBoolean(row.Cells[9].Value))
                {
                    if (clsChild.SetActiveChild(true, (int)row.Cells["Code"].Value))
                        Success = true;
                    else
                        Success = false;
                }
            }

            table = clsChild.GetArchiveMenue();
            dgvArchiveMenue.Rows.Clear();
            ShowArchiveInfo();

            if(Success)
                clsUtil.Show("تم الإسترجاع بنجاح");
            else
                clsUtil.Show("ليس هناك اي طالب محدد!", false);
        }

        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            dgvArchiveMenue.Rows.Clear();
            ShowArchiveInfo(txSearsh.Text);
        }

        private void ckCheckAll_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }  
}
