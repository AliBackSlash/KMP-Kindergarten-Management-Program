
using K_M_S_PROGRAM.UsersFiles;
using System;

using System.Windows.Forms;

namespace K_M_S_PROGRAM
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Screen());
        }
    }
}
