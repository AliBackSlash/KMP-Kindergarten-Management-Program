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

namespace K_M_S_PROGRAM.Kids_sFile.AddChaild
{
    public partial class ChildCardfrm : Form
    {
        public ChildCardfrm(int ID)
        {
            InitializeComponent();
            childCard2.ID = ID;
        }
        public delegate void CallUpdateMethod();
        public event CallUpdateMethod CallUpdate;
        
        private void ChildCardfrm_Load(object sender, EventArgs e)
        {
           
            childCard2.FillChildPersonalData();
            if(childCard2.child == null)  
            {
                clsUtil.Show("يبدو أن بيانات هذا الطفل غير موجودة تأكد من تحديث المعلومات ثم اعد المحاولة", false);
                this.Close();
            }

        }
        
    }
}
