using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.LoginFiles;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace K_M_S_PROGRAM
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool restored = true;
            if (clsGlobal.CheckFristOpenToRestoreDatabaseFile())
            {
                RestoreDataBase restore = new RestoreDataBase();
                restore.evRestored += res => { restored = res; };
                restore.ShowDialog();
            }

            if (restored)
                Application.Run(new Login_Screen());

        }

       
    }
}
