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
    public partial class WorkerInfo : Form
    {
        public WorkerInfo(int code)
        {
            InitializeComponent();
            this.Code = code;
        }
        int Code;
        public delegate void CallUpdateMethod();
        public event CallUpdateMethod CallUpdate;
       

        private void WorkerInfo_Load(object sender, EventArgs e)
        {
            if(!workerCard1.FillInfo(Code))
            {
                clsUtil.Show("هناك مشكلة فى بيانات الموظف , من فضلك تأكد من صحة البيانات المدخلة", false);
                this.Close();
            }
        }


    }
}
