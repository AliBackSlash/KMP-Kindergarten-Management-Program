using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.ImportantForms
{
    public class clsSend
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public static List<string> Send_Whats_App_Message_For_Group(List<string> PhoneNumbers,List<string> Names,char Kind, string message, DoWorkEventArgs e,BackgroundWorker BGWorker)
        {

            string encodedMessage = Uri.EscapeDataString(message);
            List<string> list = new List<string>();
            int Counter = 0;
            foreach (string Phone in PhoneNumbers)
            {
                if (BGWorker.CancellationPending) // التحقق مما إذا تم طلب الإلغاء
                {
                    e.Cancel = true;
                    return list;
                }
                string whatsappUrl = $"whatsapp://send?phone={"2" + Phone}&text={encodedMessage}";
                
                try
                {
                    Process.Start(whatsappUrl);

                    Thread.Sleep(1000);

                    SendKeys.SendWait("{ENTER}");
                    clsMessageArchive.AddToMessage_Archive(Names[++Counter], '1', message, Kind);

                }
                catch (Exception ex)
                {
                    list.Add(Phone);
                }
            }
            return list;
        }
        public static bool Send_Whats_App_Message_For_One(string PhoneNumbers, string message )
        {

            string encodedMessage = Uri.EscapeDataString(message);


            string whatsappUrl = $"whatsapp://send?phone={"2" + PhoneNumbers}&text={encodedMessage}";
            
            try
            {             

                Process.Start(whatsappUrl);

                Thread.Sleep(1000);

                SendKeys.SendWait("{ENTER}");
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
