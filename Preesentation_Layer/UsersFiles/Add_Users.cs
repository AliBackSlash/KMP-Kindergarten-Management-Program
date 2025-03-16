using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Add_Users : Form
    {
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
        public Add_Users()
        {
            InitializeComponent();
            _User = new clsUser();
        }
        clsUser _User = null;
        public Add_Users(char add)
        {
            InitializeComponent();
            _User = new clsUser();
            cmUsersNames.Visible = false;
            btClose.Visible = true;
        }

        public Add_Users(int  Code)
        {
            InitializeComponent();
            btClose.Visible = true;
            cmUsersNames.Visible = false;
           
            FillDataToUpdate(Code);
        }

        string imagePath;
        private void picPersonalImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                imagePath = selectedFilePath;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                picPersonalImage.ImageLocation=selectedFilePath;
                // ...
            }
        }

        private void FillUsersNames()
        {
            DataTable names = clsGeneric.FillComboBoxWithNames("select cast(Code as nvarchar) + '-' +Name as Name from UsersData where JopName <> 'Founder'");

            foreach(DataRow row in names.Rows) 
            {
                cmUsersNames.Items.Add(row["Name"]);
            }
        }

        private  int GetPrimsion()
        {
            int primsion = 0;

            if (t1.Checked ) primsion+=1; 
            if (t2.Checked ) primsion += 2;
            if (t3.Checked ) primsion += 4;
            if (t4.Checked ) primsion += 8;
            if (t5.Checked ) primsion += 16;
            if (t6.Checked ) primsion += 32;
            if (t7.Checked ) primsion += 64;
            if (t8.Checked ) primsion += 128;
            if (tt9.Checked) primsion += 256;
            if (t10.Checked) primsion += 512;
            if (t11.Checked) primsion += 1024;
            if (t12.Checked) primsion += 2048;
            if (t13.Checked) primsion += 4096;
            if (t14.Checked) primsion += 8192;
            if (t15.Checked) primsion += 16384;
            if (t16.Checked) primsion += 32768;
            if (t17.Checked) primsion += 65536;
            if (t18.Checked) primsion += 131072;
            if (t19.Checked) primsion += 262144;
            if (t20.Checked) primsion += 524288;
            if (t21.Checked) primsion += 1048576;
            if (t22.Checked) primsion += 2097152;
            if (t23.Checked) primsion += 4194304;
            if (t24.Checked) primsion += 8388608;
            if (t25.Checked) primsion += 16777216;
            if (t26.Checked) primsion += 33554432;
            if (t27.Checked) primsion += 67108864;
            if (t28.Checked) primsion += 134217728;
            if (t29.Checked) primsion += 268435456;
            if (t30.Checked) primsion += 536870912;
            if (t31.Checked) primsion += 1073741824;


            return primsion;
        }

        private bool _HandlePersonImage()
        {

            if (_User.ImagePath != picPersonalImage.ImageLocation)
            {
                if (_User.ImagePath != "")
                {

                    try
                    {
                        File.Delete(_User.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (picPersonalImage.ImageLocation != "")
                {
                    string SourceImageFile = picPersonalImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picPersonalImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private bool AddUpdateUser()
        {
            if (picPersonalImage.ImageLocation != null)
                if (!_HandlePersonImage())
                    return false;

            int Pirrimsion = 0;

            if (ckFullAccess.Checked)
                Pirrimsion = -1;
            else
                Pirrimsion = GetPrimsion();

            _User.Name = txName.Text;
            _User.UserName = txUserName.Text;
            _User.Password = clsUtil.Encrypt(txPassword.Text.Trim());
            _User.Temp = clsUtil.Encrypt(txTemp.Text.Trim());
            _User.Pirrimsion = Pirrimsion;
            _User.ImagePath = picPersonalImage.ImageLocation!=null ?picPersonalImage.ImageLocation:"";
            _User.Gendor = rdMail.Checked;
            _User.JopName = txJop.Text;

           if ( _User.Save())
           {
                ResetAllTexBoxes();
                return true;
           }
            return false;
        }
        void CloseAfterUpdate()
        {
            
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (AddUpdateUser())
            {
               
                   
                clsUtil.Show("تم حفظ البيانات بنجاح");
                if (btClose.Visible)
                    this.Close();

               _User = new clsUser();
                this.Refreash();
            }
            else
            { 
                clsUtil.Show("يبدو ان هناك مشكلة في البيانات المدخلة حاول مرة اخري", false);
                if (btClose.Visible)
                    this.Close();
            }

        }

        bool showPass = false;
        private void btShowPassword_Click(object sender, EventArgs e)
        {
            if(showPass)
            {
                txPassword.PasswordChar = '*';
                txTemp.PasswordChar = '*';
                btShowPass.BackgroundImage = Properties.Resources.eye;
                showPass = false;
            }
            else
            {
                txPassword.PasswordChar = '\0';
                txTemp.PasswordChar = '\0';
                btShowPass.BackgroundImage = Properties.Resources.hidden;

                showPass = true;
            }
        }

        private void Add_Users_Load(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Pirrimsion == -1)
                cmUsersNames.Visible = true;
            else
                cmUsersNames.Visible = false;
            FillUsersNames();
        }

        private void ResetAllTexBoxes()
        {
            cmUsersNames.Text="";
            txName.Text = "";
            txUserName.Text = "";
            txPassword.Text  = "";
            txTemp.Text = "";
            txJop.Text = "";
            ckFullAccess.Checked = false;
            ckFullAccess.Checked = false;
            rdMail.Checked = false;
            rdFemale.Checked = false;
            picPersonalImage.Image = Properties.Resources.man;
            t1.Checked   = false;
            t2.Checked   = false;
            t3.Checked   = false;
            t4.Checked   = false;
            t5.Checked   = false;
            t6.Checked   = false;
            t7.Checked   = false;
            t8.Checked   = false;
            tt9.Checked  = false;
            t10.Checked  = false;
            t11.Checked  = false;
            t12.Checked  = false;
            t13.Checked  = false;
            t14.Checked  = false;
            t15.Checked  = false;
            t16.Checked  = false;
            t17.Checked  = false;
            t18.Checked  = false;
            t19.Checked  = false;
            t20.Checked  = false;
            t21.Checked  = false;
            t22.Checked  = false;
            t23.Checked  = false;
            t24.Checked  = false;
            t25.Checked  = false;
            t26.Checked  = false;
            t27.Checked  = false;
            t28.Checked  = false;
            t29.Checked  = false;
            t30.Checked  = false;

        }

        private void ResetPrimmison()
        {
            t1.Checked = false;
            t2.Checked = false;
            t3.Checked = false;
            t4.Checked = false;
            t5.Checked = false;
            t6.Checked = false;
            t7.Checked = false;
            t8.Checked = false;
            tt9.Checked = false;
            t10.Checked = false;
            t11.Checked = false;
            t12.Checked = false;
            t13.Checked = false;
            t14.Checked = false;
            t15.Checked = false;
            t16.Checked = false;
            t17.Checked = false;
            t18.Checked = false;
            t19.Checked = false;
            t20.Checked = false;
            t21.Checked = false;
            t22.Checked = false;
            t23.Checked = false;
            t24.Checked = false;
            t25.Checked = false;
            t26.Checked = false;
            t27.Checked = false;
            t28.Checked = false;
            t29.Checked = false;
            t30.Checked = false;

        }
        // عدل الكود عشان يتناسب مع الحل الجديد
        private void FillUsersData()
        {
            imagePath = _User.ImagePath;
            if (_User.ImagePath != null)
                if (File.Exists(_User.ImagePath))
                    picPersonalImage.ImageLocation= _User.ImagePath;
            else
                picPersonalImage.Image = Properties.Resources.man;

            txName.Text = _User.Name;
            txUserName.Text = _User.UserName;
            txPassword.Text = clsUtil.Decrypt(_User.Password);
            txTemp.Text = clsUtil.Decrypt(_User.Temp);
            txJop.Text = _User.JopName;

            if (_User.Pirrimsion == -1)
                ckFullAccess.Checked = true;
            else
                ckFullAccess.Checked = false;

            if (_User.Gendor)
                rdMail.Checked = true;
            else
                rdFemale.Checked = true;

            Code = _User.Code;

            if (_User.Pirrimsion == 0)
                return;
            if ((_User.Pirrimsion & Convert.ToInt32(t1.Tag)) == Convert.ToInt32(t1.Tag))
                t1.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t2.Tag)) == Convert.ToInt32(t2.Tag))
                t2.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t3.Tag)) == Convert.ToInt32(t3.Tag))
                t3.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t4.Tag)) == Convert.ToInt32(t4.Tag))
                t4.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t5.Tag)) == Convert.ToInt32(t5.Tag))
                t5.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t6.Tag)) == Convert.ToInt32(t6.Tag))
                t6.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t7.Tag)) == Convert.ToInt32(t7.Tag))
                t7.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t8.Tag)) == Convert.ToInt32(t8.Tag))
                t8.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(tt9.Tag)) == Convert.ToInt32(tt9.Tag))
                tt9.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t10.Tag)) == Convert.ToInt32(t10.Tag))
                t10.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t11.Tag)) == Convert.ToInt32(t11.Tag))
                t11.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t12.Tag)) == Convert.ToInt32(t12.Tag))
                t12.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t13.Tag)) == Convert.ToInt32(t13.Tag))
                t13.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t14.Tag)) == Convert.ToInt32(t14.Tag))
                t14.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t15.Tag)) == Convert.ToInt32(t15.Tag))
                t15.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t16.Tag)) == Convert.ToInt32(t16.Tag))
                t16.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t17.Tag)) == Convert.ToInt32(t17.Tag))
                t17.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t18.Tag)) == Convert.ToInt32(t18.Tag))
                t18.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t19.Tag)) == Convert.ToInt32(t19.Tag))
                t19.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t20.Tag)) == Convert.ToInt32(t20.Tag))
                t20.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t21.Tag)) == Convert.ToInt32(t21.Tag))
                t21.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t22.Tag)) == Convert.ToInt32(t22.Tag))
                t22.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t23.Tag)) == Convert.ToInt32(t23.Tag))
                t23.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t24.Tag)) == Convert.ToInt32(t24.Tag))
                t24.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t25.Tag)) == Convert.ToInt32(t25.Tag))
                t25.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t26.Tag)) == Convert.ToInt32(t26.Tag))
                t26.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t27.Tag)) == Convert.ToInt32(t27.Tag))
                t27.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t28.Tag)) == Convert.ToInt32(t28.Tag))
                t28.Checked = true;

            if (_User.Pirrimsion == -1 || (_User.Pirrimsion & Convert.ToInt32(t29.Tag)) == Convert.ToInt32(t29.Tag))
                t29.Checked = true;

            if (_User.Pirrimsion == -1||(_User.Pirrimsion & Convert.ToInt32(t30.Tag)) == Convert.ToInt32(t30.Tag))
                t30.Checked = true;
            if (_User.Pirrimsion == -1||(_User.Pirrimsion & Convert.ToInt32(t31.Tag)) == Convert.ToInt32(t31.Tag))
                t31.Checked = true;


        }
        int Code = 0;
        private void cmUsersNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataToUpdate(cmUsersNames.Text);

        }

        void FillDataToUpdate(string Name )
        {

            _User = clsUser.Find(Name);
            if (_User != null )
            { 
                ResetPrimmison();
                FillUsersData();
            }

                
            
        }

        void FillDataToUpdate(int Code)
        {
            _User = clsUser.Find(Code);
            if (_User != null)
            {
                ResetPrimmison();
                FillUsersData();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDalete_Click(object sender, EventArgs e)
        {
            picPersonalImage.ImageLocation = "";
            picPersonalImage.Image = Properties.Resources.man;
        }

        public void Refreash()
        {
            cmUsersNames.Items.Clear();

            FillUsersNames();
            ResetAllTexBoxes();
          
        }
    }
}
