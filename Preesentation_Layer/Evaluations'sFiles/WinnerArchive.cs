using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Evaluations_sFiles
{
    public partial class WinnerArchive : Form
    {
        public WinnerArchive()
        {
            InitializeComponent();
        }

        public void WinnerArchive_Load(object sender, EventArgs e)
        {

            DataTable data = clsEvaluations.GetWinnerHistory();
            dgvWinnerHistory.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {

                dgvWinnerHistory.Rows.Add(row["ChildName"], Convert.ToDateTime(row["Date"]).ToString(clsUtil.MonthFormat), row["Degree"]);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع السجل ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                if (clsEvaluations.TruncateWinnerHistory())
                {
                    clsUtil.Show("تم مسح جميع السجل بنجاح");
                    dgvWinnerHistory.Rows.Clear();
                }
                else
                {
                    clsUtil.Show("يبدو ان البيانات مشغولة في مكان اخر اذا لم يتم المسح  بصورة متكررة تواصل مع مشرفي البرنامج", false);
                }
            }
        }
    }

            
        
    
}
