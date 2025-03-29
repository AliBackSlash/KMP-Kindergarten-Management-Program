using K_M_S_PROGRAM.Kids_sFile;
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

namespace K_M_S_PROGRAM.Resources
{
    public partial class Kids_s_Repports : Form
    {
        public Kids_s_Repports()
        {
            InitializeComponent();
        }

        public void Kids_s_Repports_Load(object sender, EventArgs e)
        {
            DataTable data = clsChild.GetGraduations();

            flCoutaner.Controls.Clear();

            foreach (DataRow row in data.Rows)
            {
                GraduationCard card = new GraduationCard(row["Name"].ToString(), Convert.ToDateTime(row["DateOfJoin"])
                    , Convert.ToDateTime(row["DateOfGraduation"]), row["ImagePath"].ToString(),Convert.ToBoolean( row["Gendor"]));
                flCoutaner.Controls.Add(card);
            }
        }
    }
}
