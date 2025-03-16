using K_M_S_PROGRAM.Resources;
using MyBusinessLayer;
using SATAUiFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static Xamarin.Essentials.Permissions;
using System.Data.SqlClient;

namespace K_M_S_PROGRAM.GlobalClasses
{
    public static class clsUtil
    {
        public static string DateFormat = "dd-MM-yyyy";
        public static string MonthFormat = "MM-yyyy";

        private readonly static string key = "1253802468214569";
        public delegate void Call(); 
       
        public static void Show(string message, bool isSuccess = true, Call call = null)
        {
            MyMessage mes = new MyMessage();

            mes.lbTitale.Text = message;
            if (isSuccess)
                mes.pic.Image = Properties.Resources.Done_Animated;

            else
                mes.pic.Image = Properties.Resources.wrong1;

            mes.ShowDialog();
            call?.Invoke();

        }

        public static string GitDayInWeekName(DateTime Date)
        {
            byte dayNum = (byte)Date.DayOfWeek;

            switch(dayNum)
            {
                case 0:
                    return "الأحد";
                case 1:
                    return "الإثنين";
                case 2:
                    return "الثلاثاء";
                case 3:
                    return "الأربعاء";
                case 4:
                    return "الخميس";
                case 5:
                    return "الجمعة";
                case 6:
                    return "السبت";
            }

            return "غير معروف";
        }
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"C:\KMP-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static void ShowImage(string Path,SATAPictureBox pictureBox,bool gendor,bool IsChild=false)
        {

            if (File.Exists(Path))
                pictureBox.ImageLocation = Path;
            else
            {
                if (IsChild)
                {
                    if (gendor)
                        pictureBox.Image = Properties.Resources.boy;
                    else
                        pictureBox.Image = Properties.Resources.girl;
                }
                else
                {
                    if (gendor)
                        pictureBox.Image = Properties.Resources.man;
                    else
                        pictureBox.Image = Properties.Resources.woman;
                }
            }

        }

        public static string ComputeHash(string Value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] HashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Value));
                StringBuilder sd = new StringBuilder();
                foreach (byte b in HashBytes)
                {
                    sd.Append(b.ToString("x2"));
                }
                return sd.ToString();
            }
        }
        //استبدال الهاش بيهم
        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        
        public static string Decrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        private static bool AbsenceAllKidsRemander()
        {
            DateTime date = DateTime.Now;

            DataTable KidsAbsence = clsAbsences.GetAllMemberThanDontCameToday(@"select KidsPersonalInfo.code from KidsPersonalInfo  where KidsPersonalInfo.Code not in (select ID from
                                                                                EnterAndLeaveHistory where Date  = cast(getdate() as date)  and Kind='C')");

            bool Success = false;
            foreach (DataRow row in KidsAbsence.Rows)
            {
                Success = clsAbsences.AddToAbsenceHistory(Convert.ToInt16(row["Code"]), date, 'C');
            }

            return Success;
        }

        private static bool AbsenceAllEmployeesRemander()
        {
            DateTime date = DateTime.Now;


            DataTable EmployeeAbsence = clsAbsences.GetAllMemberThanDontCameToday(@"select TeachersInfo.code from TeachersInfo  where TeachersInfo.Code not in (select ID from 
                                                                                     EnterAndLeaveHistory where Date  = cast(getdate() as date) and Kind='T')");



            bool Success = false;

            foreach (DataRow row in EmployeeAbsence.Rows)
            {
                Success = clsAbsences.AddToAbsenceHistory(Convert.ToInt16(row["Code"]), date,'T');

            }

            return Success;
        }

        private static bool AbsenceAllWorkersRemander()
        {
            DateTime date = DateTime.Now;


            DataTable WorkerAbsence = clsAbsences.GetAllMemberThanDontCameToday(@"select WorkerInfo.code from WorkerInfo where WorkerInfo.Code not in
                                                                                (select ID from EnterAndLeaveHistory where Date  = cast(getdate() as date) and Kind='W')");

            bool Success = false;

            foreach (DataRow row in WorkerAbsence.Rows)
            {
                Success = clsAbsences.AddToAbsenceHistory(Convert.ToInt16(row["Code"]), date, 'W');

            }
            return Success;
        }

        public static void btAbsenceRemander_Click()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            bool Kids =false , Employees=false, Workers = false;
            string Message = "تمت إضافة جميع ";
            if (date != clsGeneric.ReturnLastDateOfOpen("select DateOfAbsenceRemander from DateOpen"))
            {

                if (AbsenceAllKidsRemander())
                    Kids = true;

                if (AbsenceAllEmployeesRemander())
                    Employees = true;

                if (AbsenceAllWorkersRemander())
                    Workers = true;
                
                if (Kids == false && Employees == false && Workers == false)
                    return;
               
                clsGeneric.Reset("DateOfAbsenceRemander", date);

                if (Kids)
                    Message += "الأطفال ";
                if (Employees)
                    Message += "المعلمين ";
                if (Workers)
                    Message += "العمال ";
                Message += "الذين لم يحضروا الي سجل الغياب ";

                Show(Message);

            }
            
        }
        //فيه مشكلة في كيفية بدأ اضافة الاشتراكات في اول مرة استخدام للبرنامج شوف حلها قبل ما تنقل البرنامج للعميل
        public static void GetSubscaition()
        {
            string DateNow = DateTime.Now.Month.ToString();
            if (DateNow != clsGeneric.ReturnLastDateOfOpen("select DateOfGetSubscraipData from DateOpen"))
            {
                if (clsSubscriptions.GetPaymentSubscriptionInfoDataAndPutTiInSubscraitionPaymentTable(clsGlobal.Settings.IsPayInBegning))
                {
                    Show("تم إضافة الإشتراكات بنجاح");           
                    clsGeneric.Reset("DateOfGetSubscraipData", DateNow);
             
                }
                else
                {
                    Show("يبدو ان البيانات مشغولة في مكان اخر حاول لاحقا", false);
                }
            }
            

        }
        public static void GetEmpSalary()
        {
            string DateNow = DateTime.Now.Month.ToString();
            if (DateNow != clsGeneric.ReturnLastDateOfOpen("select DateOfGetAccountsData from DateOpen"))
            {
                if (clsEmployeesAccounts.GetMonthlyAccountData())
                {
                    Show("تم إضافة الرواتب بنجاح");  
                    clsGeneric.Reset("DateOfGetAccountsData", DateNow);

                }
                else
                {
                    Show("يبدو ان البيانات مشغولة في مكان اخر حاول لاحقا", false);
                }

            }
           
        }
        public static void RestMonthly()
        {

            string Month = DateTime.Now.Month.ToString();

            if (clsGeneric.ReturnLastDateOfOpen("select DeteOfResetEvaluation from DateOpen") != Month)
            {
                clsEvaluations.ResetDally();
                if (clsEvaluations.GetWinnerKids())
                {
                    Show("تم إنهاء التقيم الشهر وإرسال بيانت الأطفال الفائزين");
                    clsGeneric.Reset("DeteOfResetEvaluation", Month);
                }
                else
                    Show("يبدو أن هناك مشكل حاول مرة اخري أو تواصل مع مشرفي البرنامج", false);
            }
          



        }

        public static void printDocument_Small_Size_For_Kid(ref PrintPageEventArgs e,string CurrentName,string MonthSub,string DateOfPayment,float Amount,float Paid,float Remender,bool SecondTime, string ManagerName)
        {
            int receiptWidth = 240;
            int lineHeight = 20;
            int currentY = 80;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            StringFormat Centerformat = new StringFormat();
            Centerformat.Alignment = StringAlignment.Center;
            Centerformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            Font font = new Font("Times New Roman", 11, FontStyle.Bold);
            Brush brush = Brushes.Black;

            Font BackFont = new Font("Times New Roman", 7, FontStyle.Bold);

            PictureBox p = new PictureBox();
            string LogoPath = clsGeneric.ReturnLastValueIWant("Select LogoPath from ProgramSetting");
            string OrgnaizatiionName = clsGeneric.ReturnLastValueIWant("Select OrgName from ProgramSetting");
            if (LogoPath != "")
            {
                p.Image = Image.FromFile(LogoPath);
                e.Graphics.DrawImage(ResizeImage(p.Image, 70, 70), new Point(110, 0));
            }


            e.Graphics.DrawString(OrgnaizatiionName, new Font("Times New Roman", 14, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);
            currentY += lineHeight + 10;

            e.Graphics.DrawString("****************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += lineHeight;

            e.Graphics.DrawString($"الاسم : {CurrentName}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"تاريخ الدفع : {DateOfPayment} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"اشتراك شهر : {MonthSub} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة اشتراك شهر : {Amount}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة المبلغ المدفوع : {Paid}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة المبلغ المتبقي : {Remender}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;
            e.Graphics.DrawString($"الوقت: {DateTime.Now.ToString("T")}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"منفذ عملية الدفع: {clsGlobal.CurrentUser.Name}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight + 5;

            e.Graphics.DrawString("****************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += 12;

            e.Graphics.DrawString($"وصل دفع الاشتراك الشهري الخاص ب{OrgnaizatiionName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"نشكركم على حسن ثقتكم بنا طاب يومكم", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"مدير المؤسسة أ/{ManagerName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);

            if (SecondTime)
            {
                currentY += 30;
                e.Graphics.DrawString("'معاد طباعته'", new Font("Times New Roman", 12, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);

            }


        }
        public static void printDocument_Large_Size_For_Kid(ref PrintPageEventArgs e,string CurrentName, string MonthSub, string DateOfPayment, float Amount, float Paid,float Remender, bool SecondTime,string ManagerName)
        {
            int receiptWidth = 270;
            int lineHeight = 20;
            int currentY = 80;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            StringFormat Centerformat = new StringFormat();
            Centerformat.Alignment = StringAlignment.Center;
            Centerformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            Font font = new Font("Times New Roman", 12, FontStyle.Bold);
            Brush brush = Brushes.Black;

            Font BackFont = new Font("Times New Roman", 8, FontStyle.Bold);

            PictureBox p = new PictureBox();
            string LogoPath = clsGeneric.ReturnLastValueIWant("Select LogoPath from ProgramSetting");
            string OrgnaizatiionName = clsGeneric.ReturnLastValueIWant("Select OrgName from ProgramSetting");
            if (LogoPath != "")
            {
                p.Image = Image.FromFile(LogoPath);
                e.Graphics.DrawImage(ResizeImage(p.Image, 70, 70), new Point(110, 0));
            }


            e.Graphics.DrawString(OrgnaizatiionName, new Font("Times New Roman", 14, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);
            currentY += lineHeight + 10;

            e.Graphics.DrawString("************************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += lineHeight;

            e.Graphics.DrawString($"الاسم : {CurrentName}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"تاريخ الدفع : {DateOfPayment} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"اشتراك شهر : {MonthSub} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة اشتراك شهر : {Amount}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة المبلغ المدفوع : {Paid}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة المبلغ المتبقي : {Remender}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;
            e.Graphics.DrawString($"الوقت : {DateTime.Now.ToString("T")}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"منفذ عملية الدفع : {clsGlobal.CurrentUser.Name}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight + 5;

            e.Graphics.DrawString("************************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += 12;

            e.Graphics.DrawString($"وصل دفع الاشتراك الشهري الخاص ب{OrgnaizatiionName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"نشكركم على حسن ثقتكم بنا طاب يومكم", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"مدير المؤسسة أ/{ManagerName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);


            if (SecondTime)
            {
                currentY += 30;
                e.Graphics.DrawString("'معاد طباعته'", new Font("Times New Roman", 12, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);

            }

        }

       //---//
        public static void printDocument_Small_Size_For_Emp(ref PrintPageEventArgs e,string CurrentName,string MonthSalary,
            string DateOfPayment,float Amount,float Incentives,float Dedication,bool SecondTime, string ManagerName)
        {
            int receiptWidth = 240;
            int lineHeight = 20;
            int currentY = 80;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            StringFormat Centerformat = new StringFormat();
            Centerformat.Alignment = StringAlignment.Center;
            Centerformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            Font font = new Font("Times New Roman", 11, FontStyle.Bold);
            Brush brush = Brushes.Black;

            Font BackFont = new Font("Times New Roman", 7, FontStyle.Bold);

            PictureBox p = new PictureBox();
            string LogoPath = clsGeneric.ReturnLastValueIWant("Select LogoPath from ProgramSetting");
            string OrgnaizatiionName = clsGeneric.ReturnLastValueIWant("Select OrgName from ProgramSetting");
            if (LogoPath != "")
            {
                p.Image = Image.FromFile(LogoPath);
                e.Graphics.DrawImage(ResizeImage(p.Image, 70, 70), new Point(110, 0));
            }


            e.Graphics.DrawString(OrgnaizatiionName, new Font("Times New Roman", 14, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);
            currentY += lineHeight + 10;

            e.Graphics.DrawString("****************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += lineHeight;

            e.Graphics.DrawString($"الاسم : {CurrentName}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"تاريخ الإستلام : {DateOfPayment} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"راتب شهر : {MonthSalary} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة الراتب : {Amount}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة الحوافز : {Incentives}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

             e.Graphics.DrawString($"قيمة الخصم : {Dedication}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"الإجمالي : {(Amount - Dedication) + Incentives}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($" الوقت: {DateTime.Now.ToString("T")}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"منفذ عملية الدفع: {clsGlobal.CurrentUser.Name}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight + 5;

            e.Graphics.DrawString("****************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += 12;

            e.Graphics.DrawString($"وصل دفع الراتب الشهري الخاص ب{OrgnaizatiionName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"نشكركم على حسن ثقتكم بنا طاب يومكم", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"مدير المؤسسة أ/{ManagerName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);

            if (SecondTime)
            {
                currentY += 30;
                e.Graphics.DrawString("'معاد طباعته'", new Font("Times New Roman", 12, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);

            }


        }

        public static void printDocument_Large_Size_For_Emp(ref PrintPageEventArgs e, string CurrentName, string MonthSalary,
            string DateOfPayment, float Amount, float Incentives, float Dedication, bool SecondTime, string ManagerName)
        {
            int receiptWidth = 270;
            int lineHeight = 20;
            int currentY = 80;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            StringFormat Centerformat = new StringFormat();
            Centerformat.Alignment = StringAlignment.Center;
            Centerformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            Font font = new Font("Times New Roman", 12, FontStyle.Bold);
            Brush brush = Brushes.Black;

            Font BackFont = new Font("Times New Roman", 8, FontStyle.Bold);

            PictureBox p = new PictureBox();
            string LogoPath = clsGeneric.ReturnLastValueIWant("Select LogoPath from ProgramSetting");
            string OrgnaizatiionName = clsGeneric.ReturnLastValueIWant("Select OrgName from ProgramSetting");
            if (LogoPath != "")
            {
                p.Image = Image.FromFile(LogoPath);
                e.Graphics.DrawImage(ResizeImage(p.Image, 70, 70), new Point(110, 0));
            }


            e.Graphics.DrawString(OrgnaizatiionName, new Font("Times New Roman", 14, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);
            currentY += lineHeight + 10;

            e.Graphics.DrawString("************************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += lineHeight;

            e.Graphics.DrawString($"الاسم : {CurrentName}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"تاريخ الإستلام : {DateOfPayment} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"راتب شهر : {MonthSalary} ", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة الراتب : {Amount}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة الحوافز : {Incentives}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"قيمة الخصم : {Dedication}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"الإجمالي : {(Amount - Dedication) + Incentives}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"الوقت: {DateTime.Now.ToString("T")}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight;

            e.Graphics.DrawString($"منفذ عملية الدفع: {clsGlobal.CurrentUser.Name}", font, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += lineHeight + 5;

            e.Graphics.DrawString("************************************", new Font("Times New Roman", 10, FontStyle.Bold), brush, new RectangleF(0, currentY, 280, lineHeight), Centerformat);
            currentY += 12;

            e.Graphics.DrawString($"وصل دفع الراتب الشهري الخاص ب{OrgnaizatiionName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"نشكركم على حسن ثقتكم بنا طاب يومكم", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);
            currentY += 12;

            e.Graphics.DrawString($"مدير المؤسسة أ/{ManagerName}", BackFont, brush, new RectangleF(0, currentY, receiptWidth, lineHeight), format);

            if (SecondTime)
            {
                currentY += 30;
                e.Graphics.DrawString("'معاد طباعته'", new Font("Times New Roman", 12, FontStyle.Bold), brush, new RectangleF(0, currentY, 300, lineHeight), Centerformat);

            }

        }
        private static Image ResizeImage(Image imgToResize, int width, int height)
        {
            return new Bitmap(imgToResize, new Size(width, height));
        }

        

    }
}
