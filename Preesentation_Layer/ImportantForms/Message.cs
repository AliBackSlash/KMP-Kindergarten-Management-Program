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
    public partial class MyMessage : Form
    {
        public MyMessage()
        {
            InitializeComponent();
           
        }
       
        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
