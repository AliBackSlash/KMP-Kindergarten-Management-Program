using System;
using MyBusinessLayer;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;

namespace K_M_S_PROGRAM.Kids_sFile
{
    public partial class AddPerant : Form
    {
        enum enMode { Add, Update }
        enMode mode;
        public AddPerant(int ID)
        {
            InitializeComponent();
            ChildID = ID;
            mode = enMode.Add;
            perant = new clsPerant();
        }

        public AddPerant(int ID,int PerantID)
        {
            InitializeComponent();
            label1.Text = "تعديل بيانات الاباء";

            ChildID = ID;
            this.PerantID = PerantID;
            mode = enMode.Update;
        }
        private void _ResetDefaultValue()
        {
            txFatherJop.Text = "";
            txFatherName.Text = "";
            txFatherPhone.Text = "";
            txMotherJop.Text = "";
            txMotherName.Text = "";
            txMotherPhone.Text = "";
        }

        private void _LoadData()
        {
            perant = clsPerant.Find(PerantID);

            if (perant == null) 
            {
                clsUtil.Show("Not data set", false);
                return;
            }

            txFatherJop.Text   =  perant.FatherJop;
            txFatherName.Text  =  perant.FatherName;
            txFatherPhone.Text =  perant.PhoneNumber;
            txMotherJop.Text   =  perant.MotherJop;
            txMotherName.Text  =  perant.MotherName;
            txMotherPhone.Text =  perant.MPhone;

        }
        int ChildID=-1;
        int PerantID=-1;
        clsPerant perant = null;
        private void btClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            //في خطأ هنا في اضافة الابوين                                                       
            perant.ChildID = ChildID;
            perant.FatherJop = txFatherJop.Text.Trim();
            perant.FatherName = txFatherName.Text.Trim();
            perant.PhoneNumber = txFatherPhone.Text.Trim();
            perant.MotherJop = txMotherJop.Text.Trim();
            perant.MotherName = txMotherName.Text.Trim();
            perant.MPhone = txMotherPhone.Text.Trim();

            if(perant.Save())
            {
                label1.Text = "تعديل بيانات الاباء";
                mode = enMode.Update;
                clsUtil.Show("تم حفظ البيانات بنجاح");
            }
            else
                clsUtil.Show("هناك خطأ في إدخال البيانات",false);

        }

        private void AddPerant_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (mode == enMode.Update)
                _LoadData();
        }

        private void txFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((TextBox)sender, "لا يمكنك إدخال ارقام في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }

        private void txMotherPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((TextBox)sender, "لا يمكنك إدخال احرف في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }
    }
}
