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
                dgvTreasuryHistory.Rows.Add(row["TotalExpenses"], row["TotalRevenue"],row["Total"], row["MONTH"]);
            }
            fillChaaaart(data);
            if (data.Rows.Count > 0)
                lbTotal.Text = data.Compute("SUM(Total)", string.Empty).ToString();
        }

        void fillChaaaart(DataTable data)
        {
            SeriesCollection seriesCollection = new SeriesCollection();
            Random r = new Random();

            foreach (DataRow row in data.Rows)
            {

                seriesCollection.Add(new PieSeries
                {
                    Title = row["Month"].ToString(),
                    Values = new ChartValues<float> { Convert.ToSingle(row["Total"]) },
                    DataLabels = true,

                });
            }

            pieChart1.Series = seriesCollection;
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

        private void ctmsTask_Opening(object sender, CancelEventArgs e)
        {
            if (Convert.ToSingle(dgvTreasuryHistory.CurrentRow.Cells[2].Value) <= 0)
                سحبمبلغToolStripMenuItem.Enabled = false;
            else
                سحبمبلغToolStripMenuItem.Enabled = true;

        }

        private void سحبمبلغToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(dgvTreasuryHistory.CurrentRow.Cells[3].Value.ToString(), Convert.ToSingle(dgvTreasuryHistory.CurrentRow.Cells[2].Value));
            transaction.ShowDialog();
            
            FillData();
        }
    }
}
