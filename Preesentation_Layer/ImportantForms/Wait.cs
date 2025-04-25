using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.ImportantForms
{
    public partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
          
            this.ShowInTaskbar = false;

        }

       
        private void Wait_Load(object sender, EventArgs e)
        {
            guWait.Start();
        }
    }
}
