using LiveCharts.Wpf;
using LiveCharts;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using LiveCharts.WinForms;
using System.Drawing;
using K_M_S_PROGRAM.Kids_sFile.AddChaild;
namespace K_M_S_PROGRAM.Resources
{
    public partial class Kids_s_Subscriptions : Form
    {
        public Kids_s_Subscriptions()
        {
            InitializeComponent();
            PicWellPaper.Image = Properties.Resources.SalaryAnimated;
        }

        private void Kids_s_Subscriptions_Load(object sender, EventArgs e)
        {
            GetChildSubscripInfo();
          

           
        }
        DataTable table;
        private void GetChildSubscripInfo(string Name="")
        {
            if (Name == "")
                 table = clsSubscriptions.GetChildSubscripInfo();
            else
                table = clsSubscriptions.GetChildSubscripInfo(Name);

            Image image = null;
            dgvSubscripDetails.Rows.Clear();
            foreach(DataRow row in table.Rows) 
            {
                if (Convert.ToBoolean(row["Gendor"]))
                { image = Properties.Resources.boy; }
                else
                { image = Properties.Resources.girl; }
                dgvSubscripDetails.Rows.Add(image,row["Code"],row["Name"], row["Class"],Convert.ToInt32( row["SubscirptionID"]));
            }

            if (table.Rows.Count > 0)
                lbTotalAmount.Text = Convert.ToInt32(table.Compute("SUM(SubscirptionID)", string.Empty)).ToString();
        }
        public void btRefreash_Click()
        {
            dgvSubscripDetails.Rows.Clear();
            GetChildSubscripInfo();
           
        }

        private void كتابةملاحظةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notes frm = new Notes(dgvSubscripDetails.CurrentRow.Cells["Code"].Value.ToString(),'C');
            frm.ShowDialog();
        }

        private void تعديلtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Child frm = new Add_Child((int)dgvSubscripDetails.CurrentRow.Cells["Code"].Value);
            frm.ShowDialog();
        }

        private void إظهارإلبياناتtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChildCardfrm frm = new ChildCardfrm((int)dgvSubscripDetails.CurrentRow.Cells["Code"].Value);
            frm.ShowDialog();
        }

        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            if (txSearsh.Text != "")
                GetChildSubscripInfo(txSearsh.Text);
            else
                GetChildSubscripInfo();
        }
    }
}
