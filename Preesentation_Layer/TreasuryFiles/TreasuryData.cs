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

namespace K_M_S_PROGRAM.TreasuryFiles
{
    public partial class TreasuryData : Form
    {
        public TreasuryData()
        {
            InitializeComponent();
        }

        void FillComboBoxWithDay()
        {
            byte day = (byte)DateTime.Now.Day;
            byte counter = 0;
            while (counter <= day)
            {
                cmDays.Items.Add(++counter);
            }
        }

        public void FillData()
        {
            DataTable data = new DataTable();
            dgvTreasryMonthlyData.Rows.Clear();
            if(cmDays.Text == "0" && rdAll.Checked)
                data = clsTreasury.GetMonthlyData();
            else if (cmDays.Text != "0" && rdAll.Checked)
                data = clsTreasury.GetMonthlyData(cmDays.Text);
            else if(cmDays.Text != "0")
                data = clsTreasury.GetMonthlyData(rdInputs.Checked?'1':'0',cmDays.Text);
            else
                data = clsTreasury.GetMonthlyData(rdInputs.Checked ? '1' : '0');


            foreach (DataRow row in data.Rows)
            {
                dgvTreasryMonthlyData.Rows.Add(Convert.ToSingle(row["Amount"]),Convert.ToDateTime(row["DateTime"]).ToString(clsUtil.DateFormat),
                    Convert.ToDateTime(row["DateTime"]).ToString("hh:mm:ss tt"), row["Kind"], row["Trunsaction"],row["UserName"]);
            }

        }
        private void TreasuryData_Load(object sender, EventArgs e)
        {
          
            FillComboBoxWithDay();
            cmDays.SelectedIndex = 0;
        }

        

        private void cmDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();

        }

        private void btStopSend_Click(object sender, EventArgs e)
        {
            AddToTreasury toTreasury = new AddToTreasury();
            toTreasury.ShowDialog();
            FillData();
        }
    }
}
