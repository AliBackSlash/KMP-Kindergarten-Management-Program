 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Activity_Evaluation : Form
    {
        public Activity_Evaluation()
        {
            InitializeComponent();
        }


        string OneGetEvaluation = clsGeneric.ReturnLastDateOfOpen("select DateOfEvaluation from DateOpen");

       
        private void FillKidsEvaluation(string Code="")
        {
            DataTable table = clsEvaluations.GetEvaluationInfo(clsClsases.GetClassID(cmClassName.Text));

            Image image = null;
            if(Code!="")
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["ChildID"].ToString()==Code)
                    {
                        if (Convert.ToBoolean(row["Gendor"]))
                            image = Properties.Resources.boy;
                        else
                            image = Properties.Resources.girl;
                        dgvKidsEvaluation.Rows.Add(image, row["ChildID"], row["ChildName"], row["Degree1"], row["Degree2"], row["Degree3"],
                            row["Degree4"], row["Degree5"], row["Degree6"], row["Degree7"], row["TotalDegrees"]);
                    }
                    
                }
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {

                    if (Convert.ToBoolean(row["Gendor"]))
                        image = Properties.Resources.boy;
                    else
                        image = Properties.Resources.girl;
                    dgvKidsEvaluation.Rows.Add(image, row["ChildID"], row["ChildName"], row["Degree1"], row["Degree2"], row["Degree3"],
                        row["Degree4"], row["Degree5"], row["Degree6"], row["Degree7"], row["TotalDegrees"]);
                }
            }
            
        }
        private void FillKidsEvaluationMenue(string Code="")
        {
            string Date = DateTime.Now.Date.ToString("dd-MM-yyyy");


            if (OneGetEvaluation!=Date)
            {
                dgvKidsEvaluation.Rows.Clear();
                FillKidsEvaluation(Code);
            }
            else

            {
                clsUtil.Show("لقد انهيت التقيمات اليوم",false);
            }


        }

       
        private void GetStudentDayDegree()
        {
            bool Success = clsEvaluations.ResetDally();

            if (Success)
                clsUtil.Show("تم بنجاح");
            else
                clsUtil.Show("لم تتم  تأكد من أنك قمت بملئ المدخلات بصورة صحيحة", false);
        }

        private void FillComboBoxWithClassNames()
        {
            DataTable Names = clsGeneric.FillComboBoxWithNames("SELECT Class FROM Clases");
            foreach (DataRow row in Names.Rows)
            {
                cmClassName.Items.Add(row["Class"]);
            }
        }

        private void Activity_Evaluation_Load(object sender, EventArgs e)
        {

            
            FillComboBoxWithClassNames();
        }

        private void cmClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvKidsEvaluation.EndEdit();
            foreach (DataGridViewRow row in dgvKidsEvaluation.Rows)
            {
                if (row.Cells[1].Value != null)
                    UpdateDayEvaluation(row);
            }
            dgvKidsEvaluation.Rows.Clear();
            FillKidsEvaluationMenue(txSearsh.Text);

        }

        private void UpdateDayEvaluation(DataGridViewRow row)
        {
            
            clsEvaluations.UpdateDayEvaluationInfo( row.Cells[1].Value.ToString(),Convert.ToBoolean(row.Cells[3].Value) ,Convert.ToBoolean(row.Cells[4].Value)
                , Convert.ToBoolean(row.Cells[5].Value), Convert.ToBoolean(row.Cells[6].Value),  Convert.ToBoolean(row.Cells[7].Value),
                Convert.ToBoolean(row.Cells[8].Value), Convert.ToBoolean(row.Cells[9].Value));
        }

        private void RestDay()
        {
            string Date = DateTime.Now.Date.ToString("dd-MM-yyyy");

            if (MessageBox.Show("تأكد من انك قمت بتقيم كل الطلاب في جميع الفصول", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, 
                MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                dgvKidsEvaluation.EndEdit();
                GetStudentDayDegree();
                if (clsGeneric.Reset("DateOfEvaluation", Date)) { 
                    OneGetEvaluation = clsGeneric.ReturnLastDateOfOpen("select DateOfEvaluation from DateOpen");
                    dgvKidsEvaluation.Rows.Clear();
                }
            }
        }

        string Date = DateTime.Now.Date.ToString("dd-MM-yyyy");
        private void btRestDally_Click(object sender, EventArgs e)
        {

            dgvKidsEvaluation.EndEdit();
            foreach (DataGridViewRow row in dgvKidsEvaluation.Rows)
            {
                if (row.Cells[1].Value != null)
                    UpdateDayEvaluation(row);
            }

            

            if (OneGetEvaluation != Date)
            {
                RestDay();
            }
            else
                clsUtil.Show("لقد انهيت التقيمات اليوم", false);

        }

        public void btRefreash_Click()
        {
            dgvKidsEvaluation.Rows.Clear();

            FillKidsEvaluationMenue(txSearsh.Text);
        }
        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            dgvKidsEvaluation.Rows.Clear();
            FillKidsEvaluationMenue(txSearsh.Text);
        }
       
        public void btSave_Click(object sender, EventArgs e)
        {
            dgvKidsEvaluation.EndEdit();
            foreach (DataGridViewRow row in dgvKidsEvaluation.Rows)
            {
                if (row.Cells[1].Value != null)
                    UpdateDayEvaluation(row);
            }
            if (OneGetEvaluation != Date)
                clsUtil.Show("تم بنجاح");
            else
                clsUtil.Show("لقد انهيت التقيمات اليوم", false);



        }
    }
}
