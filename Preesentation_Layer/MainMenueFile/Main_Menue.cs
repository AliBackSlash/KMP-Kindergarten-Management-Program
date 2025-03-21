using LiveCharts.Wpf;
using LiveCharts;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using LiveCharts.WinForms;
using System.Linq;
using System.Threading.Tasks;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Main_Menue : Form
    {
        public Main_Menue()
        {
            InitializeComponent();
        }

        private void HeaderInfo()
        {
            lbTotalAmount.Text = clsMainMenue.TreasuryAmmount().ToString();
            lbCurrentTotalAmount.Text = clsMainMenue.CurrentTreasuryAmmount().ToString();

            int NumOfStudebts = clsChild.NumberOfKids();
            int NumOfTeachers = clsEmployee.NumberOfTeachers();



            string KidsCame =  clsGeneric.GetNumberOfAttendedMember('C').ToString();
            lbKidsCame.Text = KidsCame != "" ? KidsCame : "0";


            lbKidsNotCame.Text = (NumOfStudebts - Convert.ToInt16(KidsCame)).ToString();

            string TeacherCame = clsGeneric.GetNumberOfAttendedMember('T').ToString();
            lbTeacherCame.Text = TeacherCame != "" ? TeacherCame : "0";

            lbTeacherNotCame.Text = (NumOfTeachers - Convert.ToInt16(TeacherCame)).ToString();

            lbNumOfLevel.Text = clsLevels.NumberOfLevels().ToString();

            lbNumOfClass.Text = clsClsases.NumberOfClases().ToString();

            

        }




        private void Chart1INfo()
        {
            try
            {
                SeriesCollection seriesCollection = new SeriesCollection
        {
        new PieSeries
        {
            Title = "الطلاب",
            Values = new ChartValues<double> { clsGeneric.ReturnLastValueIWantINT("select sum(SubscirptionID) from KidsPersonalInfo") },
            DataLabels = true,
            LabelPoint = point => $"{point.SeriesView.Title}: {point.Y}" // عرض العنوان والقيمة
        },
        new PieSeries
        {
            Title = "المعلمين",
            Values = new ChartValues<double> { clsGeneric.ReturnLastValueIWantINT("select sum(Salary) from TeachersInfo") },
            DataLabels = true,
            LabelPoint = point => $"{point.SeriesView.Title}: {point.Y}" // عرض العنوان والقيمة
        },
        new PieSeries
        {
            Title = "العمال",
            Values = new ChartValues<double> { clsGeneric.ReturnLastValueIWantINT("select sum(Salary) from WorkerInfo") },
            DataLabels = true,
            LabelPoint = point => $"{point.SeriesView.Title}: {point.Y}" // عرض العنوان والقيمة
        }
        };
                pieChart1.Series = seriesCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Chart2Info()
        {
            try
            {
                SeriesCollection seriesCollectionforstudens = new SeriesCollection
        {
            new PieSeries
            {
                Title = " الطلاب الحاضرين",
                Values = new ChartValues<double> { Convert.ToInt16(lbKidsCame.Text) },
                DataLabels = true,
                LabelPoint = point => $"{point.SeriesView.Title}: {point.Y}" // عرض العنوان والقيمة
            },
            new PieSeries
            {
                Title = " الطلاب الغائبين",
                Values = new ChartValues<double> { Convert.ToInt16(lbKidsNotCame.Text) },
                DataLabels = true,
                LabelPoint = point => $"{point.SeriesView.Title}: {point.Y}" // عرض العنوان والقيمة
            }
        };
                pieChart3.Series = seriesCollectionforstudens;

                SeriesCollection seriesCollectionforTeachers = new SeriesCollection
        {
            new PieSeries
            {
                Title = " المعلمين الحاضرين",
                Values = new ChartValues<double> { Convert.ToInt16(lbTeacherCame.Text) },
                DataLabels = true,
                LabelPoint = point => $"{point.SeriesView.Title}: {point.Y}" // عرض العنوان والقيمة
            },
            new PieSeries
            {
                Title = " المعلمين الغائبين",
                Values = new ChartValues<double> { Convert.ToInt16(lbTeacherNotCame.Text) },
                DataLabels = true,
                LabelPoint = point => $"{point.SeriesView.Title}: {point.Y}" // عرض العنوان والقيمة
            }
        };
                pieChart2.Series = seriesCollectionforTeachers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Chart3Info()
        {
            try
            {
                DataTable degrees = clsGeneric.ReturnGroupOfDataIWant("SELECT AVG(E.TotalDegrees) AS Degree, C.Class FROM DayEvaluation E INNER JOIN KidsPersonalInfo K on k.Code = E.ChildID inner join Clases C ON C.Code = K.ClassID GROUP BY C.Class");
                if (degrees == null || degrees.Rows.Count == 0) return;

                SeriesCollection seriesCollection = new SeriesCollection();
                foreach (DataRow row in degrees.Rows)
                {
                    if (row["Class"] != null && row["Degree"] != null && !Convert.IsDBNull(row["Degree"]))
                    {
                        seriesCollection.Add(new PieSeries
                        {
                            Title = row["Class"].ToString(),
                            Values = new ChartValues<double> { Convert.ToDouble(row["Degree"]) },
                            DataLabels = true,
                            LabelPoint = point => $"{point.SeriesView.Title}: {point.Participation:P}"
                        });
                    }
                }
                cartesianChart2.Series = seriesCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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
        private void Main_Menue_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

       

        public void Reafrsh1()
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart2.Series.Clear();
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisY.Clear();
           
           



            HeaderInfo();
            Chart1INfo();
            Chart2Info();
            Chart3Info();
            Chart4Info();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            HeaderInfo();
            Chart1INfo();
            Chart2Info();
            Chart3Info();
            Chart4Info();
            timer1.Stop();
        }
    }
}
