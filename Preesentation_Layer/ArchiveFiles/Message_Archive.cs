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
    public partial class Message_Archive : Form
    {
        public Message_Archive()
        {
            InitializeComponent();
        }
        char Kind = 'C';
        public void FillInfo(string Name="")
        {
            Image image;
            DataTable data;
            dgvMessageArchive.Rows.Clear();

            if (Name != "")
                data = clsMessageArchive.GetMessage_Archive(Kind,Name);
            else
                data = clsMessageArchive.GetMessage_Archive(Kind);

            foreach (DataRow row in data.Rows)
            {
                if (Convert.ToChar(row["Through"]) == '1')
                    image = Properties.Resources.logo;
                else if (Convert.ToChar(row["Through"]) == '2')
                    image = Properties.Resources.sms;
                else
                    image = Properties.Resources.gmail;


                dgvMessageArchive.Rows.Add(image,row["Name"],Convert.ToDateTime( row["DateTime"]).ToString("dd-MM-yyyy || hh:mm:ss"), row["MessageContant"]);
            }
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (clsMessageArchive.DeleteAll())
                { clsUtil.Show("تم مسح السجل"); FillInfo(); }
            else
                clsUtil.Show("هناك خطأ ما في النظام حاول لاحقا", false);
        }

        private void Message_Archive_Load(object sender, EventArgs e)
        {
            FillInfo();
        }

        private void rdKinds_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKids.Checked)
            {
                Kind = 'C';
                FillInfo();
            }
            else if (rdTeachers.Checked)
            {
                Kind = 'T';
                FillInfo();
            }
            else
            {
                Kind = 'W';
                FillInfo();
            }
        }

        private void txSearsh_TextChanged(object sender, EventArgs e)
        {
            FillInfo(txSearsh.Text);
        }
    }
}
