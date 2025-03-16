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
using ZXing.QrCode.Internal;

namespace K_M_S_PROGRAM.Employees_sFiles
{
    public partial class WorkerCard : UserControl
    {
        public WorkerCard()
        {
            InitializeComponent();
        }
        int Code = 0;
        public clsWorker worker;
        public bool FillInfo(int Code)
        {
            worker = clsWorker.Find(Code);

            if (worker!=null)
            {
                this.Code = Code;
                lbCode.Text = worker.Code.ToString();
                lbName.Text = worker.name;
                lbPhone.Text = worker.Phone;
                lbCardNumber.Text = worker.CardNumber;
                ckAM.Checked = worker.Period;
                ckPM.Checked = !(ckAM.Checked);
                clsUtil.ShowImage(worker.Image, picPhoto, worker.Gendor);
                ckMale.Checked = worker.Gendor;
                ckFemale.Checked = !(ckMale.Checked);
                return true;
            }

            return false;
        }

        private void btEdite_Click(object sender, EventArgs e)
        {
            Add_Employees frm = new Add_Employees(Convert.ToInt16(lbCode.Text), false);
            frm.CallUpdate += Frm_CallUpdate;
            frm.ShowDialog();
        }

        private void Frm_CallUpdate()
        {
            FillInfo(Code);
        }
    }
}
