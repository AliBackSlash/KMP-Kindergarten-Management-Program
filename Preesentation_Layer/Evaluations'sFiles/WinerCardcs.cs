using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class WinerCardcs : UserControl
    {
        public WinerCardcs(string Name,string Class,string Degree,string Date,string ImagePath)
        {
            InitializeComponent();

            if (File.Exists(ImagePath))
                pic.ImageLocation = ImagePath;
            lbName.Text = Name; 
            lbClass.Text = Class;
            lbDegree.Text = Degree;
            lbDate.Text = Date;
            
        }
    }
}
