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

namespace K_M_S_PROGRAM.Kids_sFile.AddChaild
{
    public partial class AddParsonCanTake : Form
    {
       
       
        enum enMode { Add, Update }
        enMode mode;
        public AddParsonCanTake(int ID)
        {
            InitializeComponent();
            ChildID = ID;
            mode = enMode.Add;
            PersonTake = new clsPersonCanTake();
        }

        public AddParsonCanTake(int ID, bool Update)
        {
            InitializeComponent();
            lbTitle.Text = "تعديل بيانات الاباء";

            ChildID = ID;
            mode = enMode.Update;
        }
        private void _ResetDefaultValue()
        {
            txTakeName.Text = "";
            txTakeSeltAlkraba.Text = "";
            txTakePhoneNumber.Text = "";
            txTakePersonalCardNumber.Text = "";
            
        }

        private void _LoadData()
        {
            PersonTake = clsPersonCanTake.Find(ChildID?.ToString());

            if (PersonTake == null)
            {
                clsUtil.Show("Not data set", false);
                return;
            }

            txTakeName.Text         = PersonTake.Name;
            txTakeSeltAlkraba.Text  = PersonTake.SeltAlkraba;
            txTakePhoneNumber.Text = PersonTake.PhoneNumber;
            txTakePersonalCardNumber.Text   = PersonTake.PersonalCardNumber;
           
        }
        int? ChildID = -1;
        clsPersonCanTake PersonTake = null;
       
        private void btSave_Click(object sender, EventArgs e)
        {

            PersonTake.Name = txTakeName.Text;
            PersonTake.SeltAlkraba = txTakeSeltAlkraba.Text;
            PersonTake.PhoneNumber = txTakePhoneNumber.Text;
            PersonTake.PersonalCardNumber = txTakePersonalCardNumber.Text; 
            PersonTake.ChildID = ChildID?.ToString();
            if (PersonTake.Save())

            {
                lbTitle.Text = "تعديل بيانات الاباء";
                mode = enMode.Update;
                clsUtil.Show("تم حفظ البيانات بنجاح");
            }
            else
                clsUtil.Show("هناك خطأ في إدخال البيانات", false);

        }

        private void PersonCanTake_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (mode == enMode.Update)
                _LoadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txTakePhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((TextBox)sender, "لا يمكنك إدخال احرف في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }

        private void txTakeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((TextBox)sender, "لا يمكنك إدخال ارقام في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }
    }
}
