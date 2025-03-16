using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.Resources;
using MyBusinessLayer;
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

namespace K_M_S_PROGRAM.Kids_sFile.AddChaild
{
    public partial class ChildCard : UserControl
    {
        public ChildCard()
        {
            InitializeComponent();

        }
        public clsChild child;
        public int ID;

       
        public void FillChildPersonalData()
        {
            child = clsChild.FindByCode(ID);

            if (child!=null)
            {

                lbCode.Text = child.Code.ToString();
                lbName.Text = child.name;
                lbCity.Text = child.city;
                lbAddress.Text = child.address;
                lbDate.Text = child.dateOfBirth.ToString("dd-MM-yyyy");
                lbClass.Text = clsClsases.GetClassName( child.classID );
                lbPeriod.Text = child.period?"صباحي" : "مسائي";
                lbLevel.Text = clsLevels.GetLevelName(child.levelID);
                lbPhone.Text = child.messageNumber;
                lbBus.Text = "لبس هناك باص";
                lbMail.Text = child.mail;
                if (child.gendor)
                    lbGendor.Text = "ولد";
                else
                    lbGendor.Text = "بنت";
                if(child.perant!=null)
                { 
                    lbFName.Text = child.perant.FatherName;
                    lbFjop.Text = child.perant.FatherJop;
                    lbMName.Text = child.perant.MotherName;
                    lbMJop.Text = child.perant.MotherJop;
                    lbMPhone.Text = child.perant.MPhone;
                    lbFPhone.Text = child.perant.PhoneNumber;
                }
                if(child.personCanTake!=null)
                {
                    lbTName.Text = child.personCanTake.Name;
                    lbTKraba.Text = child.personCanTake.SeltAlkraba;
                    lbTPhone.Text = child.personCanTake.PhoneNumber;
                    lbTPersonalCardNumber.Text = child.personCanTake.PersonalCardNumber;
                }
                clsUtil.ShowImage(child.image, picChailPhoto, child.gendor,true);
               
            }
           
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            Add_Child frm = new Add_Child(Convert.ToInt16(lbCode.Text));
            frm.Finshed += FillChildPersonalData;
            frm .ShowDialog();
        }

    }
}
