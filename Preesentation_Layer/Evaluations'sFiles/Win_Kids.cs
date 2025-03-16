using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Win_Kids : Form
    {
        public Win_Kids()
        {
            InitializeComponent();
           
        }
        
        private void FillWinnerCard()
        {

            DataTable data = clsEvaluations.GetWinnerCard();

            WinerCardcs winerCardcs = null;
          
            foreach (DataRow row in data.Rows)
            {


                DateTime y = Convert.ToDateTime(row["Date"]);


                winerCardcs = new WinerCardcs(row["ChildName"].ToString(), row["ClassName"].ToString(), row["Degree"].ToString(),
                    Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy"), row["Image"].ToString());

                if (Convert.ToBoolean(row["Gendor"]))
                    winerCardcs.BackColor = Color.Teal;
                else
                    winerCardcs.BackColor = Color.LightPink;

                if (Convert.ToByte(row["Degree"]) == Convert.ToByte(data.Compute("Max(Degree)", null)))
                {
                    winerCardcs.BackColor = Color.Green;
                    winerCardcs.picTag.Visible = true;
                }

                fwWinnerList.Controls.Add(winerCardcs);


            }


        }

        private  void Win_Kids_Load(object sender, EventArgs e)
        {
            timer1.Start();
              

        }
        public void btRefreash_Click()
        {
            fwWinnerList.Controls.Clear();
            FillWinnerCard();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FillWinnerCard();

            timer1.Stop();
        }
    }
}
