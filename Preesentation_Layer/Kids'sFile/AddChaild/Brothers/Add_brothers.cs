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

namespace K_M_S_PROGRAM.Resources
{
    public partial class AddUpdate_brothers : Form
    {

        public AddUpdate_brothers(int ID,bool Update = false)
        {
            InitializeComponent();
            lbTittle.Text = "إضافة";
            _ID=ID;
            if (Update)
            {
                _brother = clsBrother.Find(ID);
                FillInfo();
            }
            else
                _brother = new clsBrother();
            txBorCode.Texts = ID.ToString();
        }
        int _ID = 0;
        clsBrother _brother;
        bool move;
        int moveX, moveY;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            moveX = e.X;
            moveY = e.Y;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        MyMessage message = new MyMessage();
        private void btSave_Click(object sender, EventArgs e)
        {
            _brother.Name = txName.Texts;
            _brother.childID = Convert.ToInt16(txBorCode.Texts);
            _brother.Date = txDataOfBirth.Value;
            if (_brother.Save())
            {
                clsUtil.Show("تم حفظ البيانات بنجاح");
                txName.Texts = "";
            }
            else
            {
                clsUtil.Show("تأكد من المعلومات المقدمة",false);
            }
        }

        private void Add_brothers_Load(object sender, EventArgs e)
        {
            if(_brother==null)
            txBorCode.Texts = _ID.ToString();

            txDataOfBirth.MaxDate = DateTime.Now;
            txDataOfBirth.MinDate = DateTime.Now.AddYears(-2);
        }

        private void FillInfo()
        {
            _brother = clsBrother.Find(_ID);
            if ( _brother == null )
            {
                clsUtil.Show("لا يوجد اخ مسجل في النظام لهذا الطالب", false);
                //this.Close();
                return;
            }
            lbTittle.Text = "تعديل";
            txBorCode.Texts=_brother.childID.ToString();
            txName.Texts = _brother.Name;
            txDataOfBirth.Value=_brother.Date;
        }

        private void codeeloButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
