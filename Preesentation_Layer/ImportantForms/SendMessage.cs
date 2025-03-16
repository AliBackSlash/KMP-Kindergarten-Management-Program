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
    public partial class Sendmessagefrm : Form
    {
        public Sendmessagefrm()
        {
            InitializeComponent();
        }
        public delegate void GetMessage(string Message);
        public event GetMessage Message;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Message?.Invoke(txMessage.Text);
            this.Close();
        }
    }
}
