using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class About_this_Program : Form
    {
        public About_this_Program()
        {
            InitializeComponent();
        }
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/AliElsaied");

        }
        
        private void AppendFeature(string title, string description)
        {
            AppendColoredText(title, Color.Green, true);
            AppendColoredText(description + "\n", Color.Black);
        }
        private void AppendColoredText(string text, Color color, bool bold = false, int fontSize = 19, bool underline = false)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = color;

            FontStyle style = FontStyle.Regular;
            if (bold) style |= FontStyle.Bold;
            if (underline) style |= FontStyle.Underline;

            richTextBox1.SelectionFont = new Font("Arial", fontSize, style);
            richTextBox1.AppendText(text);
            richTextBox1.SelectionColor = richTextBox1.ForeColor; // إعادة اللون الافتراضي
        }
        private void About_this_Program_Load(object sender, EventArgs e)
        {
            AppendColoredText("\n\nنظام متكامل لإدارة الحضانات التعليمية، يوفر حلولًا متقدمة لتنظيم العمليات اليومية بكفاءة وسهولة. يهدف المشروع إلى تبسيط إدارة الحضانات عبر مجموعة من الميزات الذكية، مما يساعد في تحسين الأداء الإداري ومتابعة جميع التفاصيل المتعلقة بالأطفال والموظفين والاشتراكات المالية وغيرها.\n\n", Color.Black);

            // القسم: أهم الميزات
            AppendColoredText("✨ أهم الميزات:\n", Color.Blue, true, 20);

            AppendFeature("🔹 لوحة التحكم الرئيسية: ", "تعرض ملخصًا للحسابات، الحضور والغياب للأطفال والموظفين، إجمالي الخزينة، وعدد الفصول والمستويات.");
            AppendFeature("🔹 إدارة الأطفال: ", "إضافة وتعديل بيانات الأطفال، تتبع الحضور والغياب، أرشفة البيانات، إرسال الملاحظات والتنبيهات، وإرسال الرسائل عبر WhatsApp (مع دعم مستقبلي لـ SMS والبريد الإلكتروني).");
            AppendFeature("🔹 إدارة الموظفين: ", "إضافة وتعديل الموظفين، متابعة الحضور والانصراف، تسجيل الرواتب، إرسال الإشعارات، وكتابة الملاحظات.");
            AppendFeature("🔹 الاشتراكات والمدفوعات: ", "متابعة الاشتراكات، تسجيل عمليات الدفع، وإدارة السجلات المالية بدقة.");
            AppendFeature("🔹 الإشعارات الذكية: ", "تنبيهات بأعياد ميلاد الأطفال، الاشتراكات غير المدفوعة، الغيابات المتكررة، وإشعارات تخص الفائزين في التقييمات.");
            AppendFeature("🔹 إدارة الفصول والمستويات: ", "تنظيم الفصول والمستويات التعليمية بفعالية.");
            AppendFeature("🔹 الخزينة والسجلات المالية: ", "عرض عمليات الدفع الحالية والسابقة، وسجل الخزينة لتتبع التدفقات المالية.");
            AppendFeature("🔹 إدارة المستخدمين والصلاحيات: ", "تحديد المستخدمين المسموح لهم بالدخول وتخصيص صلاحياتهم.");
            AppendFeature("🔹 إعدادات متقدمة: ", "تسجيل الدخول والخروج، وإدارة إعدادات النظام.\n");

            // القسم: العمليات التلقائية
            AppendColoredText("🚀 ", Color.Red, true, 20);
            AppendColoredText("العمليات التلقائية:\n", Color.Red, true, 20);
            AppendColoredText("✔️ ", Color.Blue);
            AppendColoredText("إضافة الاشتراكات والرواتب تلقائيًا.\n", Color.Black);
            AppendColoredText("✔️ ", Color.Blue);
            AppendColoredText("تسجيل الحضور والانصراف والغياب دون تدخل يدوي.\n", Color.Black);
            AppendColoredText("✔️ ", Color.Blue);
            AppendColoredText("تنفيذ تقييمات الأطفال وإدارة العمليات الروتينية بشكل ذاتي.\n\n", Color.Black);

        }
    }
}





