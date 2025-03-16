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

namespace K_M_S_PROGRAM.UsersFiles
{
    public partial class CheckPassword : Form
    {
        public CheckPassword(int ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        public CheckPassword()
        {
            InitializeComponent();
        }

        int ID = 0;
        public bool IsRightAnswerForPassword  = false;
        private void btLogin_Click(object sender, EventArgs e)
        {
            if(ID!=0)
            {
                if (clsUser.IsUserNameAndPasswordExistsForThisID(txUserName.Text, clsUtil.Encrypt(TxPassword.Text), ID))
                {
                    IsRightAnswerForPassword = true;
                    this.Hide();
                }
                else
                {
                    clsUtil.Show(" خطأ في إسم المستخدم وكلمة المرور", false);
                    this.Hide(); 
                }
            }
            else
            {

            }


        }

        
    }
}
