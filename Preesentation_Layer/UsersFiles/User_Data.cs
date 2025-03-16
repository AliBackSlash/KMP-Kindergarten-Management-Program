using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.UsersFiles;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace K_M_S_PROGRAM.Resources
{
    public partial class User_Data : Form
    {
        public User_Data()
        {
            InitializeComponent();
        }
        
        private void FillUserListWithData(string Name="")
        {
            System.Drawing.Image image = null;
            DataTable data = null;
            if (Name == "")
                 data = clsUser.GetUserInfo();
            else
                data = clsUser.GetUserInfo(Name);

            foreach (DataRow row in data.Rows)
            {
                if (Convert.ToBoolean(row["Gendor"]))
                { image = Properties.Resources.man1; }
                else
                { image = Properties.Resources.woman; }

                dgvUsersData.Rows.Add(image, row["Code"], row["Name"], row["JopName"]);

            }

        }
        private void DeleteUser()
        {

            if (clsUser.DeleteUser((int)dgvUsersData.CurrentRow.Cells["Code"].Value))
                clsUtil.Show("تم إزالة المستخدم");
            else
                clsUtil.Show("لم تتم الإزلة يبدو أن البيانات مشغولة حاول لاحقا", false);
        }

        private void User_Data_Load(object sender, EventArgs e)
        {
            FillUserListWithData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
           
        }

        public void Refreash()
        {
            dgvUsersData.Rows.Clear();

            FillUserListWithData();
        }

        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            dgvUsersData.Rows.Clear();

            FillUserListWithData(txSearsh.Text);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Pirrimsion == -1)
            {
                DeleteUser();
                dgvUsersData.Rows.Clear();
                FillUserListWithData();
            }
            else
                clsUtil.Show("هذه الخصية متاحة فقط للمشرفين", false);
           
        }

        private void إرسالرسالةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Pirrimsion == -1)
            {
                Add_Users add_ = new Add_Users('a');
                add_.ShowDialog();
            }
            else
                clsUtil.Show("هذه الخصية متاحة فقط للمشرفين", false);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvUsersData.CurrentRow.Cells["Code"].Value;
            CheckPassword check = new CheckPassword(ID);
            check.ShowDialog();

            if(check.IsRightAnswerForPassword)
            {
                Add_Users add_ = new Add_Users(ID);
                add_.ShowDialog();
            }
            else
            {
                check.Close();

            }
           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Show_User_info show_User = new Show_User_info((int)dgvUsersData.CurrentRow.Cells["Code"].Value);
            show_User.ShowDialog();
        }
    }
}
