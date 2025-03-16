using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.Resources;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.UsersFiles
{
    public partial class User_Info_Card : UserControl
    {
        public User_Info_Card()
        {
            InitializeComponent();
        }

        int Code = 0;
        clsUser _User = null;

        public void FillInfo(int Code)
        {
            _User = clsUser.Find(Code);
            if( _User == null )
            {
                clsUtil.Show("يوجد خطأ في نقل البيانات يبدو أن البيانات مشغولة!", false);
                return;
            }

            this.Code = _User.Code;

            if (_User.ImagePath != "")
                if (File.Exists(_User.ImagePath))
                    picPhoto.ImageLocation = _User.ImagePath;
                else
                    picPhoto.Image = Properties.Resources.man;


            lbCode.Text = _User.Code.ToString();
            lbName.Text = _User.Name;
            lbUserName.Text = _User.UserName;
            lbJopName.Text = _User.JopName;

            ckFullAccess.Checked = _User.Pirrimsion == -1 ? true : false;

            if (_User.Gendor)
                ckMale.Checked = true;
            else
                ckFemale.Checked = true;



        }

        private void ctEdite_Click(object sender, EventArgs e)
        {
            Add_Users add_ = new Add_Users(Code);
            add_.ShowDialog();
        }
    }
}
