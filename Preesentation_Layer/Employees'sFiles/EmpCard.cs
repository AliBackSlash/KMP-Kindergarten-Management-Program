using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_M_S_PROGRAM.Resources;

namespace K_M_S_PROGRAM.Employees_sFiles
{
    public partial class EmpCard : UserControl
    {
        public EmpCard()
        {
            InitializeComponent();
        }
        public clsEmployee _employee;
        int Code = 0;

        
        public bool FillTeacherCardWithData(int Code)
        {
            _employee = clsEmployee.Find(Code);
            if (_employee == null)
            {
                return false;
            }
            this.Code = Code;
            if (_employee.Image != "")
                if (File.Exists(_employee.Image))
                    picPhoto.ImageLocation = _employee.Image;
            lbCode.Text = _employee.ID.ToString();
            lbName.Text = _employee.Name;
            lbSchool.Text = _employee.School;
            lbQulification.Text = _employee.Qualification;
            lbAddress.Text = _employee.Address;
            lbPhone.Text = _employee.Phone;
            lbCardNumber.Text = _employee.CardNumber;
            lbDateOfBirth.Text = _employee.DateOfBirth.ToString();
            lbEmail.Text = _employee.Email;
            ckAM.Checked = _employee.Period;
            ckPM.Checked = !(_employee.Period);
            ckFemale.Checked = !(_employee.Gendor);
            ckMale.Checked = _employee.Gendor;
            return true;
        }

        private void btEdite_Click(object sender, EventArgs e)
        {
            Add_Employees frm = new Add_Employees(Convert.ToInt16(lbCode.Text),true);
            frm.CallUpdate += Frm_CallUpdate;
            frm.ShowDialog();
        }

        private void Frm_CallUpdate()
        {
            FillTeacherCardWithData(Code);
        }
    }
}
