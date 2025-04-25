using K_M_S_PROGRAM.GlobalClasses;
using Microsoft.Win32;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static K_M_S_PROGRAM.LoginFiles.RestoreDataBase;

namespace K_M_S_PROGRAM.LoginFiles
{
    public partial class RestoreDataBase : Form
    {
        public RestoreDataBase()
        {
            InitializeComponent();
        }

        public RestoreDataBase(bool NotFirst)
        {
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.BackgroundImage = Properties.Resources.logo;
            notFirst = NotFirst;
            InitializeComponent();
        }
        bool notFirst = false;
        bool Restored = false;
        public delegate void IsRestored(bool Restored);
        public event IsRestored evRestored;
        private void btSavePackup_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "فتح ملف قاعدة البيانات";
            openFileDialog1.Filter = "Database Files|*.bak;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txSavePath.Text = openFileDialog1.FileName;

            }

        }

        private void RestoreDataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            evRestored?.Invoke(Restored);
        }

        private async void btRestore_Click(object sender, EventArgs e)
        {
            if (txSavePath.Text == "")
            {
                clsUtil.Show("من فضلك قم باختيار مسار ملف البيانات اولا!", false); return;
            }
            btRestore.Visible = false;
            waitControl.Visible = true;
            waitControl.Start();
            await Task.Run(() => { Restored = clsSettings.RestoreData(txSavePath.Text); });
            if (!Restored)
            {
                waitControl.Stop();
                waitControl.Visible = false;
                btRestore.Visible = true;
                clsUtil.Show("هناك مشكلة تواجهنا في محرك البيانات الخاص بجهازك تواصل مع الدعم الفني عن طريق الربط الذي سيظهر اسفل النافذة لحل هذه المشكلة", false);
                lbMyAccount.Visible = true;
            }
            else
            {
                waitControl.Stop();
                waitControl.Visible = false;
                btRestore.Visible = true;
                lbIntro.Text = "";
                if (notFirst)
                    clsUtil.Show("تم");
                timer1.Start();
                clsGlobal.setFristOpenToBeClose();

            }

        }
        string IntroScript = "";
        int counter = 0;
        private void RestoreDataBase_Load(object sender, EventArgs e)
        {
            IntroScript = "\nالسلام عليكم ورحمة الله وبركاته \n" +
                            "يسرُّ إدارة KMP لبرامج إدارة الهيئات التعليمية أن ترحّب بكم وتشكر لكم ثقتكم في اختيار تطبيقنا لإدارة مؤسستكم التعليمية. \n" +
                            "للانطلاق في رحلتكم معنا، يرجى اتباع الخطوات البسيطة التالية: \n" +
                            "❇️ الضغط على الزر ذو الثلاث نقاط. \n" +
                            "❇️ اختيار ملف البيانات المرفق مع التطبيق. \n" +
                            "❇️ النقر على زر \'Restore\' لبدء التجربة المجانية والاستمتاع بكامل المزايا. \n" +
                            "نتمنى لكم تجربة سلسة وفعّالة، ونرحّب بأي استفسارات أو ملاحظات.";

            if (notFirst)
            {
                btRestore.Enabled = true;
                btSavePackup.Enabled = true;
                lbIntro.Visible = false;

            }
            else
                timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lbIntro.Text += IntroScript[counter++];
            if (counter >= IntroScript.Length)
            {
                IntroScript = "تم تفعيل البرنامج بنجاح! 🎉\n" +
                    "عند إغلاق هذه النافذة، ستظهر لك شاشة تسجيل الدخول.\n" +
                    "▪ أدخل كلمة **temp** في خانة اسم المستخدم.\n" +
                    "▪ أدخل الرقم **12** في خانة كلمة المرور.\n" +
                    "بمجرد تسجيل الدخول، يمكنك حذف هذا المستخدم.\n" +
                    "الآن، يمكنك إنشاء حسابك الخاص والبدء في استخدام التطبيق بكل سهولة! 🚀\n" +
                    "بعد إنشاء حسابك، قم باتباع الإجراءات التالية:\n" +
                    "❇️ توجه إلى شاشة الإعدادات وقم بضبطها لتناسب احتياجاتك.\n" +
                    "❇️ انتقل إلى شاشة الفصول ثم المستويات، وأضف الفصول والمستويات الخاصة بحضانتك.\n" +
                    "❇️ في قسم \"الأطفال\"، يمكنك إضافة الأطفال بسهولة، مع وجود تعليمات مفصلة هناك.\n" +
                    "❇️ كما يمكنك إضافة المدرسين والعمال من قسم الموظفين.\n" +
                    "نتمنى لك تجربة ممتعة! 😊\n";
                counter = 0;
                timer1.Stop();
                btSavePackup.Enabled = true;
            }


        }

        private void lbMyAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/AliElsaied");
        }

        private void txSavePath_TextChanged(object sender, EventArgs e)
        {
            btRestore.Enabled = true;
        }
    }
}
