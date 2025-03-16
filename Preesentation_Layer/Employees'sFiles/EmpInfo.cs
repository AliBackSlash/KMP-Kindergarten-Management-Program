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

namespace K_M_S_PROGRAM.Employees_sFiles
{
    public partial class EmpInfo : Form
    {
        public EmpInfo(int ID)
        {
            InitializeComponent();
            this.ID = ID;

        }
        int ID =0;
        private void btClose_Click(object sender, EventArgs e)
        {
            CallUpdate?.Invoke();
            this.Close();
        }
        public delegate void CallUpdateMethod();
        public event CallUpdateMethod CallUpdate;
        private void EmpInfo_Load(object sender, EventArgs e)
        {
          
            if (!empCard1.FillTeacherCardWithData(ID))
            {
                clsUtil.Show("هناك مشكلة فى بيانات الموظف , من فضلك تأكد من صحة البيانات المدخلة", false);
                this.Close();
            }
        }

        //move this form
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
    }
}
