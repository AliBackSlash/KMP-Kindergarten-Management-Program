using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Kids_sFile
{
    public partial class GraduationCard : UserControl
    {
        
        public GraduationCard(string name,DateTime DateOfJoin,DateTime DateOfGraduation,string ImPath,bool gendor)
        {
            InitializeComponent();
            Calendar calenda = CultureInfo.InstalledUICulture.Calendar;
            lbName.Text = name;
            lbDateOfJoin.Text = DateOfJoin.ToString(clsUtil.DateFormat);
            lbDateOfGraduation.Text = DateOfGraduation.ToString(clsUtil.DateFormat);
            lbNumOfStudyYears.Text = $"{calenda.GetYear(DateOfGraduation)- calenda.GetYear(DateOfJoin)} سنة و {Math.Abs(calenda.GetMonth(DateOfGraduation) - calenda.GetMonth(DateOfJoin))} شهر و {Math.Abs(calenda.GetDayOfMonth(DateOfGraduation) - calenda.GetDayOfMonth(DateOfJoin))} يوم.";
            if (File.Exists(ImPath))
                picPhote.ImageLocation = ImPath;
            else
                if (gendor)
                    picPhote.Image = Properties.Resources.boy;
                else
                    picPhote.Image = Properties.Resources.girl;

        }
    }
}
