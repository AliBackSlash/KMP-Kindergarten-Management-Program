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
        static Mutex mutex;

        [STAThread]
        static void Main()
        {
            bool isNewInstance;
            mutex = new Mutex(true, "KMS_UniqueAppMutex", out isNewInstance);

            if (!isNewInstance)
            {
                // إذا كان التطبيق مفتوحًا بالفعل، استرجاع النسخة الحالية وإيقاف تشغيل النسخة الجديدة
                BringToFront();
                return;
            }

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

            // التأكد من إبقاء الـ Mutex حيًا حتى لا يتم تحريره قبل الوقت المطلوب
            GC.KeepAlive(mutex);
        }

        static void BringToFront()
        {
            Process current = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id)
                {
                    IntPtr handle = process.MainWindowHandle;
                    if (handle != IntPtr.Zero)
                    {
                        ShowWindow(handle, 1); // إظهار النافذة إذا كانت مخفية
                        SetForegroundWindow(handle); // جعلها في المقدمة
                    }
                    break;
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
