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
using System.Windows.Markup;

namespace K_M_S_PROGRAM.UsersFiles
{
    public partial class RegistersList : Form
    {
        public RegistersList()
        {
            InitializeComponent();
        }
        DataTable data;
       
        private void GetRegistersData()
        {
             dgvRegisters.Rows.Clear();
            if (txSearsh.Text != "" && ckDate.Checked == false) 
                data = clsRegistersAndOperation.GetAllRegisters(txSearsh.Text);

            else if (ckDate.Checked)
                data = clsRegistersAndOperation.GetAllRegisters(DTPDateFrom.Value, DTPDateTo.Value,txSearsh.Text);
            else
                data = clsRegistersAndOperation.GetAllRegisters();

        }
        void FillInfo(string UserName = "")
        {
            GetRegistersData();
            foreach (DataRow row in data.Rows)
            {
                dgvRegisters.Rows.Add(row["Code"], row["UserName"], Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), Convert.ToDateTime(row["Date"]).ToString("hh:mm:ss  tt"), row["Status"]);

            }
            lbTotalRecords.Text = data.Rows.Count.ToString();

        }

        private void RegistersList_Load(object sender, EventArgs e)
        {
            DTPDateFrom.MaxDate = DateTime.Now;
            DTPDateTo.MaxDate = DateTime.Now.AddDays(1);
            FillInfo();
        }

        void ShowDateTo()
        {
            lbTo.Visible = ckDate.Checked;
            lbFrom.Visible = ckDate.Checked;
            DTPDateTo.Visible = ckDate.Checked;
            if (ckDate.Checked)
            {
                btDelete.Location = new Point(320, 23);
               
            }
            else
            {
                btDelete.Location = new Point(181, 23);
               
            }

        }
        private void ckDate_CheckedChanged(object sender, EventArgs e)
        {
            ShowDateTo();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Show_User_info show = new Show_User_info((int)dgvRegisters.CurrentRow.Cells["Code"].Value);
            show.ShowDialog();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (clsRegistersAndOperation.DeleteAllRegisters())
            { clsUtil.Show("تم مسح جميع السجل "); dgvRegisters.Rows.Clear(); }
            else
                clsUtil.Show("يوجد خطأ في البيانان أو انه لا يوجد بيانات ", false);


        }

        private void txSearsh_TextChanged(object sender, EventArgs e)
        {
            DTPDateTo.MinDate = DTPDateFrom.MaxDate.AddDays(1);
            FillInfo(txSearsh.Text);

        }
    }
}
