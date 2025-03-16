using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.Resources;
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

namespace K_M_S_PROGRAM.Kids_sFile.AddChaild.Brothers
{
    public partial class BrothersMenue : Form
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

        private void ـعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdate_brothers add_ = new AddUpdate_brothers((int)dgvBrothersMenue.CurrentRow.Cells["Code"].Value, true);
            add_.ShowDialog();
        }
        clsBrother _brother;
        int ID;
        DataTable _BroMenue = null;
        public bool found = false;
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public BrothersMenue(int ID)
        {
            InitializeComponent();   
            this.ID = ID;
            _BroMenue = clsBrother.GetChildBrothers(ID);
            if (_BroMenue.Rows.Count == 0)
            {
                clsUtil.Show("لا يوجد إخوة مسجلين في النظام لهذا الطالب", false);
                found = false;
            }
            else
                found = true;
        }

        private void BrothersMenue_Load(object sender, EventArgs e)
        {
            FillInfo();
        }

        private void FillInfo()
        {
           
            foreach (DataRow row in  _BroMenue.Rows)
            {
                dgvBrothersMenue.Rows.Add(row["ID"],row["Name"], Convert.ToDateTime(row["DateOfBirth"]).ToString("dd-MM-yyyy"));
            }
            
        }
        
    }
}
