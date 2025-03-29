using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyBusinessLayer;
using K_M_S_PROGRAM.GlobalClasses;

namespace K_M_S_PROGRAM.TreasuryFiles
{
    public partial class TreasuryHistory : Form
    {
        public TreasuryHistory()
        {
            InitializeComponent();

        }
        public void FillData()
        {
            DataTable data = clsTreasury.GetHistory();
            dgvTreasuryHistory.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {
                dgvTreasuryHistory.Rows.Add(row["TotalExpenses"], row["TotalRevenue"],Convert.ToSingle(row["TotalRevenue"]) - Convert.ToSingle(row["TotalExpenses"]), row["Month"]);
            }
        }
        private void TreasuryHistory_Load(object sender, EventArgs e)
        {
            FillData();
            SeriesCollection seriesCollection = new SeriesCollection();
            Random r = new Random();

            foreach (DataGridViewRow row in dgvTreasuryHistory.Rows)
            {

                seriesCollection.Add(new PieSeries
                {
                    Title = row.Cells[3].Value.ToString(),
                    Values = new ChartValues<float> { Convert.ToSingle(row.Cells[2].Value) },
                    DataLabels = true,

                });
            }

            pieChart1.Series = seriesCollection;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع السجل ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                if (clsTreasury.ClearHistory())
                    clsUtil.Show("تم بنجاح");
                else
                    clsUtil.Show("حدث خطأ", false);            
            }
        }
    }
}
