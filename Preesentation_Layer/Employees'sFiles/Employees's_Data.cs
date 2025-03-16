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
    public partial class Employees_s_Data : Form
    {
        public Employees_s_Data()
        {
            InitializeComponent();
        }

        DataTable table = clsEmployee.GetTeacherInfo();

        private void FillCmboBoxWithEmployeesName()
        {
           
            cmEmploNames.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                cmEmploNames.Items.Add(row["Code"].ToString() +"-"+ row["Name"].ToString());
            }
        }

       

      
        private void GetAllNotes(char Kind)
        {
            DataTable data = clsNotes.GetNotes(lbCode.Text, Kind);

            foreach (DataRow row in data.Rows)
            {
                dgvNotes.Rows.Add(row["Date"], row["Note"]);
            }
        }

        bool IsTeacher = true;
        private void FillEmployeeWithData(string EmployeeName)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["Code"].ToString() + "-" + row["Name"].ToString() == EmployeeName)
                {
                    if (IsTeacher)
                    {
                        lbCode.Text = row["Code"].ToString();

                        dgvNotes.Rows.Clear();
                        GetAllNotes('T');
                        return;
                    }
                       
                    else
                    {      
                        lbCode.Text = row["Code"].ToString();   
                        dgvNotes.Rows.Clear();
                        GetAllNotes('W');
                        return;
                    }
                }
               
            }
        }

        private void btEmployee_Click(object sender, EventArgs e)
        {
            table = clsEmployee.GetTeacherInfo();
            FillCmboBoxWithEmployeesName();
            IsTeacher = true;
        }

        private void btWorker_Click(object sender, EventArgs e)
        {
            table = clsWorker.GetWorkerInfo();
            FillCmboBoxWithEmployeesName();
            IsTeacher = false;
        }

        private void Employees_s_Data_Load(object sender, EventArgs e)
        {
            FillCmboBoxWithEmployeesName();
        }

        private void btRefrish_Click(object sender, EventArgs e)
        {
            if(IsTeacher)
            {
                table = clsEmployee.GetTeacherInfo();
                FillCmboBoxWithEmployeesName();
            }
            else
            {
                table = clsWorker.GetWorkerInfo();
                FillCmboBoxWithEmployeesName();
            }

        }

        private void cmEmploNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillEmployeeWithData(cmEmploNames.Text);
        }

       
    }
}
