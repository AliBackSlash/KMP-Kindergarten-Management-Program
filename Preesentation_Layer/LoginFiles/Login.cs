using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.Resources;
using MyBusinessLayer;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace K_M_S_PROGRAM
{
    public partial class Login_Screen : Form
    {
        public Login_Screen()
        {
            InitializeComponent();
            TxPassword.UseSystemPasswordChar = true;
        }

       
        //
        private void codeeloButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool showPassword = false;
      
        private void button2_Click(object sender, EventArgs e)
        {
            if (showPassword)
            {
                TxPassword.UseSystemPasswordChar = true;
                picShowIcon.Image = Properties.Resources.hidden;
                showPassword = false;

            }
            else
            {
                TxPassword.UseSystemPasswordChar = false;
                picShowIcon.Image = Properties.Resources.eye;
                showPassword = true;
            }
     
        }
        byte TrailNumber = 3;
        private void btLogin_Click(object sender, EventArgs e)
        {
            clsUser login = clsUser.Find(txUserName.Text.Trim(), clsUtil.Encrypt(TxPassword.Text.Trim()));

            if (login != null)
            {
                this.Hide();
                clsRegistersAndOperation.AddRegister(login.Code,true);
                if (ckRemember.Checked)
                    clsGlobal.RememberUsernameAndPassword(txUserName.Text.Trim(), TxPassword.Text.Trim());
                else
                    clsGlobal.RememberUsernameAndPassword("", "");

                Main_Screan main_Screan = new Main_Screan(login);
                //this.Hide();
                main_Screan.ShowDialog();
                this.Close();



            }
            else
            {
                if (txUserName.Text == "" && TxPassword.Text == "")
                    lbError.ForeColor = Color.DarkRed;
                else if (txUserName.Text == "")
                {
                    lbError.Text = "أدخل اسم المستخدم";
                    lbError.ForeColor = Color.DarkRed;

                }
                else if (TxPassword.Text == "")
                {
                    lbError.Text = "أدخل رمز الدخول";
                    lbError.ForeColor = Color.DarkRed;
                   
                }
                else
                {
                    lbError.Text = $"لا يوجد هذا المستخدم متبقي ({--TrailNumber}) محاولة";
                    lbError.ForeColor = Color.DarkRed;

                }

                if (TrailNumber <= 0)
                    clsUtil.Show("لقد انهيت محاولات التسجيل تواصل مع المشرف لمعرفة كلمة المرور الخاصة بك",false,() => this.Close());
            }
        }

        private void texUserName__TextChanged(object sender, EventArgs e)
        {
            lbError.ForeColor = Color.Black;

        }

       

        private void Login_Load(object sender, EventArgs e)
        {
            string userName = "", password = "";
            if (clsGlobal.GetStoredCredential(ref userName, ref password))
            {
                txUserName.Text = userName;
                TxPassword.Text = password;
                ckRemember.Checked = true;
            }
            else
                ckRemember.Checked = false;
        }

    }
}
