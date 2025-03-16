using K_M_S_PROGRAM.GlobalClasses;
using LiveCharts.Wpf;
using LiveCharts;
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
    public partial class TreasuryYearly : Form
    {
        public TreasuryYearly()
        {
            InitializeComponent();
        }
        void FillComboBoxWithDay()
        {
            DataTable nothes = clsTreasury.GetCurrentMonthes();
            foreach (DataRow row in nothes.Rows)
            {
                cmMonthes.Items.Add(row["Month"]);
            }
        }

        public void FillData()
        {
            DataTable data = new DataTable();
            dgvTreasryYearlyData.Rows.Clear();

            if (cmDays.Text == "00" && rdAll.Checked && cmMonthes.Text == "00")
                data = clsTreasury.GetYearlyData();
            else if (cmDays.Text == "00" && rdAll.Checked && cmMonthes.Text != "00")
                data = clsTreasury.GetYearlyDataOrderForMonth(cmMonthes.Text);

            else if (cmDays.Text == "00" && rdAll.Checked == false && cmMonthes.Text != "00")
                data = clsTreasury.GetYearlyDataOrderForMonth(cmMonthes.Text, rdInputs.Checked ? '1' : '0');

            else if (cmDays.Text != "00" && rdAll.Checked && cmMonthes.Text != "00")
                data = clsTreasury.GetYearlyData(cmMonthes.Text, cmDays.Text);

            else if (cmDays.Text != "00" && rdAll.Checked == false && cmMonthes.Text != "00")
                data = clsTreasury.GetYearlyData(cmMonthes.Text, cmDays.Text, rdInputs.Checked ? '1' : '0');
            else
                data = clsTreasury.GetYearlyDataOrder(rdInputs.Checked ? '1' : '0');


            foreach (DataRow row in data.Rows)
            {
                dgvTreasryYearlyData.Rows.Add(Convert.ToSingle(row["Amount"]), Convert.ToDateTime(row["DateTime"]).ToString(clsUtil.DateFormat),
                    Convert.ToDateTime(row["DateTime"]).ToString("hh:mm:ss tt"), row["Kind"], row["Trunsaction"], row["UserName"]);
            }

        }
        private void Chart4Info()
        {
            try
            {
                DataTable inputTable = clsGeneric.ReturnGroupOfDataIWant("select * from TreasuryHistory");
                SeriesCollection seriesCollection = new SeriesCollection();
                List<string> labels = new List<string>(); // قائمة لتخزين أسماء الأشهر

                // إنشاء قوائم لتخزين القيم
                ChartValues<int> revenueValues = new ChartValues<int>();
                ChartValues<int> expenseValues = new ChartValues<int>();

                foreach (DataRow row in inputTable.Rows)
                {
                    string month = row["Month"].ToString();
                    labels.Add(month); // إضافة الشهر إلى قائمة العناوين

                    // إضافة القيم إلى القوائم
                    revenueValues.Add(Convert.ToInt32(row["TotalRevenue"]));
                    expenseValues.Add(Convert.ToInt32(row["TotalExpenses"]));
                }

                // إضافة السلسلتين إلى المجموعة بعد جمع كل القيم
                seriesCollection.Add(new ColumnSeries
                {
                    Title = "إيرادات",
                    Values = revenueValues,
                    DataLabels = true
                });

                seriesCollection.Add(new ColumnSeries
                {
                    Title = "مصروفات",
                    Values = expenseValues,
                    DataLabels = true
                });

                cartesianChart1.Series = seriesCollection;

                // إعداد المحور X لعرض الأشهر
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis
                {
                    Labels = labels // تعيين الأشهر كعناوين على المحور X 
                });

                // إعداد المحور Y
                cartesianChart1.AxisY.Clear();
                cartesianChart1.AxisY.Add(new Axis
                {
                    LabelFormatter = value => value.ToString("N0") // تنسيق الأرقام
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void TreasuryData_Load(object sender, EventArgs e)
        {
            Chart4Info();
            FillComboBoxWithDay();
            cmMonthes.Text = "00";
            cmDays.Text = "00";
            DateTime Minidate = DateTime.Now.AddMonths(-12/*put the limit from setting*/);
            DateTime Maxdate = DateTime.Now;
            monthCalendar1.MinDate = new DateTime(Minidate.Year, Minidate.Month, Minidate.Day);
            monthCalendar1.MaxDate = new DateTime(Maxdate.Year, Maxdate.Month, Maxdate.Day);
            
        }



        private void cmDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع السجل ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                if (clsTreasury.ClearYearlyData())
                    clsUtil.Show("تم بنجاح");
                else
                    clsUtil.Show("حدث خطأ", false);
            }
        }
    }
}
