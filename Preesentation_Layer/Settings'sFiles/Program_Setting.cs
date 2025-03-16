using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xamarin.Essentials;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Program_Setting : Form
    {
        public Program_Setting()
        {
            InitializeComponent();
        }

        string OldLogoPath = "";
        private void Program_Setting_Load(object sender, EventArgs e)
        {
            FillSettingWithData();
            SavePath = txSavePath.Text;
            OldLogoPath = picLogo.ImageLocation;
        }


        private void CheckedVecationDay(byte C)
        {
            if (C == 6)
                ch1.Checked = true;
            if (C == 0)
                ch2.Checked = true; 
            if (C == 1)
                ch3.Checked = true; 
            if (C == 2)
                ch4.Checked = true; 
            if (C == 3)
                ch5.Checked = true; 
            if (C == 4)
                ch6.Checked = true; 
            if (C == 5)
                ch7.Checked = true;

        }
        public void FillSettingWithData()
        {
            DataTable data = clsSettings.GetSettingInfo();

            
            if(data.Rows.Count>0)
             {  
                DataRow Row = data.Rows[0];
                if (File.Exists(clsGlobal.Settings.LogoPath))
                    picLogo.ImageLocation = clsGlobal.Settings.LogoPath;


                
                txDaysLateToPay.Text = clsGlobal.Settings.DaysLateToPay.ToString();
                txDaysKindsAbsence.Text = clsGlobal.Settings.DaysKindsAbsence.ToString();
                txKidsBratherAge.Text = clsGlobal.Settings.KidsBratherAge2.ToString();
                txtimeEnter.Text = clsGlobal.Settings.TimeEnter;
                txtimeLeave.Text = clsGlobal.Settings.TimeLeave;
                txTimeLateForKids.Text = clsGlobal.Settings.TimeLateForKids;
                txLastEnterTime.Text = clsGlobal.Settings.LasttimeEnter;
                txLasttimeLeave.Text = clsGlobal.Settings.LasttimeLeave;
                SavePath = clsGlobal.Settings.PackupPath;

                txNotefayKidsAbsence.Text = clsGlobal.Settings.NotefayKidsLate;
                txTimeEnterForTeacher.Text = clsGlobal.Settings.TimeEnterForTeacher;
                txTimeLateForTeachers.Text = clsGlobal.Settings.TimeLateForTeachers;
                txTimeEnterForWorker.Text = clsGlobal.Settings.TimeEnterForWorkers;
                txTimeLateForWorker.Text = clsGlobal.Settings.TimeLateForWorkers;
                txLateDiscount.Text = clsGlobal.Settings.LateDiscount.ToString();
                txAbsenceLate.Text = clsGlobal.Settings.AbsenceLate.ToString();
                txDayOfStaudyInMonth.Text = clsGlobal.Settings.DaysOfStaudyInMonth;
                txEmpAge.Text = clsGlobal.Settings.EmpAge;
                txOrgName.Text = clsGlobal.Settings.OrgName;
                txManagerName.Text = clsGlobal.Settings.ManagerName;
                txSavePath.Text = clsGlobal.Settings.PackupPath;
                txSMSNumber.Text = clsGlobal.Settings.SMSNumber;
                txWhatsAppNumber.Text = clsGlobal.Settings.WhatsAppNumber;
                txOrgEmail.Text = clsGlobal.Settings.OrgEmail;
                txSubMessage.Text = clsGlobal.Settings.SubMessage;
                txAbsenceMessage.Text = clsGlobal.Settings.AbsenceMessage;
                txBrothersAgeMessage.Text = clsGlobal.Settings.BrothersAgeMessage;
                txBirthDayMessage.Text = clsGlobal.Settings.BirthDayMessage;


                if (clsGlobal.Settings.SmallPaper)
                    rdSmaolPaper.Checked = true;
                else
                    rdLargePaper.Checked = true;

                if (clsGlobal.Settings.ShowBeforPrint)
                    ckShowBeforPrint.Checked = true;
                else
                    ckShowBeforPrint.Checked = false;
               
                if (clsGlobal.Settings.AskBeforPrint)
                    ckAskBeforPrint.Checked = true;
                else
                    ckAskBeforPrint.Checked = false;

                if (clsGlobal.Settings.IsPayInBegning)
                    rdInBeginingOfMonth.Checked = true;
                else
                    rdInEndOfMonth.Checked = true;


                CheckedVecationDay(clsGlobal.Settings.Vication1);
                CheckedVecationDay(clsGlobal.Settings.Vication2);

            }

        }

        string SavePath;
        private void btSavePackup_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "حفظ النسخة الإحتياطية";
            saveFileDialog1.DefaultExt = ".bak";
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                SavePath=saveFileDialog1.FileName;
            }
            txSavePath.Text = SavePath;


        }

        private void picLogo_Click(object sender, EventArgs e)
        {
          
            
           openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
           openFileDialog1.FilterIndex = 1;
           openFileDialog1.RestoreDirectory = true;

           if (openFileDialog1.ShowDialog() == DialogResult.OK)
           {
               // Process the selected file
               string selectedFilePath = openFileDialog1.FileName;

                picLogo.ImageLocation = selectedFilePath;
               // ...
           }
            
        }

        private char[] GetVication()
        {
            char[] vacation = new char[2];
           

            byte i = 0;
           
            if (ch1.Checked)
            { vacation[i] = '6'; i++; }
            
            if (ch2.Checked)
            { vacation[i] = '0'; i++; }
            
            if (ch3.Checked&&i<2)
            { vacation[i] = '1'; i++; }
            
            if (ch4.Checked && i < 2)
            { vacation[i] = '2'; i++; }
            
            if (ch5.Checked && i < 2)
            { vacation[i] = '3'; i++; }
            
            if (ch6.Checked && i < 2)
            { vacation[i] = '4'; i++; }
            
            if (ch7.Checked && i < 2)
            { vacation[i] = '5'; i++; }

            //because this is no day number 9 if user chose one vacation
            if (i == 1 && i < 2)
                vacation[i] = '9';
           
            return vacation;
        }
        private bool _HandlePersonImage()
        {

            if (OldLogoPath != picLogo.ImageLocation)
            {
                if (OldLogoPath != "" && OldLogoPath != null)
                {
                    

                    try
                    {
                        File.Delete(OldLogoPath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (picLogo.ImageLocation != "")
                {
                    string SourceImageFile = picLogo.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picLogo.ImageLocation = SourceImageFile;
                        OldLogoPath = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private bool UpdateSetting()
        {
            char[] vacation = new char[2];

            vacation = GetVication();


            string[] Age = txKidsBratherAge.Text.Split('-');

            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddYears(Convert.ToByte(Age[0])).AddMonths(Convert.ToByte(Age[1]));

            TimeSpan duration = endDate - startDate;
            int days = duration.Days;

            if (!_HandlePersonImage())
                return false;

            return clsSettings.UpdateSetting(txDaysLateToPay.Text, txDaysKindsAbsence.Text, days.ToString(),txKidsBratherAge.Text,
            txtimeEnter.Text,  txLastEnterTime.Text, txLasttimeLeave.Text,txtimeLeave.Text, txTimeLateForKids.Text, txNotefayKidsAbsence.Text,
            txTimeEnterForTeacher.Text, txTimeLateForTeachers.Text, txTimeEnterForWorker.Text, txTimeLateForWorker.Text,
            txLateDiscount.Text, txAbsenceLate.Text, txDayOfStaudyInMonth.Text, vacation[1], vacation[0] , SavePath,
           txOrgName.Text, txManagerName.Text,rdSmaolPaper.Checked, picLogo.ImageLocation, ckAskBeforPrint.Checked, ckShowBeforPrint.Checked,txSMSNumber.Text,txWhatsAppNumber.Text,txOrgEmail.Text,txAbsenceMessage.Text
           ,txSubMessage.Text,txBrothersAgeMessage.Text,txBirthDayMessage.Text, txEmpAge.Text,rdInBeginingOfMonth.Checked);

           
            

               
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (UpdateSetting())
                clsUtil.Show("تم تحديث الإعدادات");
            else
                clsUtil.Show("لم يتم تحديث الإعدادات  تأكد من إدخال البيانات بصورة صحيحة",false);
            clsGlobal.main_Screan.ComputeTheCammingDate();
            clsGlobal.Settings = clsSettings.GetSetting();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/AliElsaied");
           
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            clsSettings.RestoreData(txSavePath.Text);
        }

       
        private void btDalete_Click(object sender, EventArgs e)
        {
            picLogo.ImageLocation = "";
            picLogo.Image = Properties.Resources.icons8_add_camera_60;
        }
        byte numberOfCheckVigation = 0;
       
    }
}
