using Guna.UI2.WinForms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.TreasuryFiles
{
    public partial class AddToTreasury : Form
    {
        public AddToTreasury()
        {
            InitializeComponent();
        }

        private void txAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((Guna2TextBox)sender, "لا يمكنك إدخال احرف في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
           
            if(float.TryParse(txAmount.Text, out float Amount))
            {

                if (clsTreasury.AddToTreasuryMonthlyData(Amount, rdInputs.Checked ? 'I' : 'O', rdInputs.Checked, clsGlobal.CurrentUser.Code, 0))
                    clsUtil.Show("تمت الإضافة");
                else
                    clsUtil.Show("هناك خطأ في البيانات ", false);
                this.Close();
            }
            else
                clsUtil.Show("ادخل المبلغ", false);

            
        }
    }
}
