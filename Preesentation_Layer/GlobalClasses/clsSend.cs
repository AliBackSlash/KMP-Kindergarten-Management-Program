using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.ImportantForms
{
    public class clsSend
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public static async Task<List<string>> Send_Whats_App_Message_For_Group(List<string> PhoneNumbers, List<string> Names, char Kind, string message, DoWorkEventArgs e, BackgroundWorker BGWorker)
        {
            string encodedMessage = Uri.EscapeDataString(message);
            int Counter = -1;
            List<string> FailedList = new List<string>();
            foreach (string Phone in PhoneNumbers)
            {
                Counter++;

                if (BGWorker.CancellationPending)
                {
                    e.Cancel = true;

                    break;
                }

                string WhatsAppUrl = $"whatsapp://send?phone=2{Phone}&text={encodedMessage}";

                try
                {
                    Process.Start(WhatsAppUrl);

                    await Task.Delay(3000); 

                    SendKeys.SendWait("{ENTER}");

                    await Task.Delay(2000);

                    clsMessageArchive.AddToMessage_Archive(Names[Counter], '1', message, Kind);
                    
                    
                }
                catch (Exception)
                {
                    FailedList.Add(Phone);
                    return FailedList;

                }
            }
                return FailedList;
        }

        public async static Task<bool> Send_Whats_App_Message_For_One(string PhoneNumbers, string message )
        {

            string encodedMessage = Uri.EscapeDataString(message);


            string whatsappUrl = $"whatsapp://send?phone={"2" + PhoneNumbers}&text={encodedMessage}";
            
            try
            {             

                Process.Start(whatsappUrl);

                await Task.Delay(3000);

                SendKeys.SendWait("{ENTER}");

                await Task.Delay(2000);

                SendKeys.SendWait("{ENTER}");
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
