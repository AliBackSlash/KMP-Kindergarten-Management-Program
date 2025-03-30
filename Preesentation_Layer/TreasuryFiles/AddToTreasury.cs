using Guna.UI2.WinForms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Web.Util;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.TreasuryFiles
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }
        public Transaction(string Month, float CurrentAmount)
        {
            InitializeComponent();
            rdInputs.Visible = false;
            rdOutputs.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            IsCallFromTreasuryHistory = true;
            this.Month = Month;
            this.CurrentAmount = CurrentAmount;
        }
        bool IsCallFromTreasuryHistory = false;
        string Month = "";
        float CurrentAmount = 0;
        private void txAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((Guna2TextBox)sender, "لا يمكنك إدخال احرف في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            float.TryParse(txAmount.Text, out float amount);
           if(amount == 0)
           {
                clsUtil.Show("ادخل المبلغ", false);
                return;
           }
           
            if (IsCallFromTreasuryHistory)
            {

                if (CurrentAmount < amount)
                {
                    clsUtil.Show("المبلغ المدخل يتجاوز المبلغ المتاح لهذا الشهر برجاء تقليل المبلغ ", false);
                    return;

                }
                if(clsTreasury.Trunsaction(Month, amount))
                    clsUtil.Show("تمت عملية السحب");
                else
                    clsUtil.Show("هناك خطأ في البيانات ", false);
            }
            else
            {
                if (clsTreasury.AddToTreasuryMonthlyData(amount, rdInputs.Checked ? 'I' : 'O', rdInputs.Checked, clsGlobal.CurrentUser.Code, 0))
                    clsUtil.Show("تمت الإضافة");
                else
                    clsUtil.Show("هناك خطأ في البيانات ", false);
            }

            this.Close();

        }
    }
}
