using System;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
namespace K_M_S_PROGRAM.Resources
{
    public partial class Notes : Form
    {


        string _ID;
        char _Kind;
        public Notes(string Code,char Kind)
        {
            InitializeComponent();
            _ID= Code;
            _Kind= Kind;
        }

        public Notes()
        {
            InitializeComponent();
        }

        public delegate void GetNotes(string Message);
        public event GetNotes Get;

      
       
       
        private void btSave_Click(object sender, EventArgs e)
        {

            Get?.Invoke(txNote.Text);
            this.Close();

           

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txNote_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
