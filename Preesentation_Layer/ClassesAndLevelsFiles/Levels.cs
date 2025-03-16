using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
namespace K_M_S_PROGRAM.Resources
{
    public partial class Levels : Form
    {
        public Levels()
        {
            InitializeComponent();
        }

        enum enMode { Add,Update,dalete}
        enMode mode= enMode.Add;

        private void rdAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAdd.Checked)
            {
                txCode.Text = null ;
                txCode.Enabled = false;
                btSave.Text = "إضافة";
                txCode.BorderColor = Color.Red;
                mode = enMode.Add;
                btSave.Enabled = true;

                txLevelName.Enabled = true;
                txLevelName.BorderColor = Color.MediumSlateBlue;
                txContant.Enabled = true;
                txContant.BorderColor = Color.MediumSlateBlue;
            }
            else if(rdUpdate.Checked)
            {
                txCode.Enabled = true;
                btSave.Text = "تعديل";
                btSave.Enabled = true;

                txCode.BorderColor = Color.MediumSlateBlue;
                mode = enMode.Update;
                txLevelName.Enabled = true;
                txLevelName.BorderColor = Color.MediumSlateBlue;
                txContant.Enabled = true;
                txContant.BorderColor = Color.MediumSlateBlue;
            }
            else
            {
                txCode.Enabled = true;
                btSave.Text = ".......";
                btSave.Enabled = false;
                txCode.BorderColor = Color.MediumSlateBlue;
                mode = enMode.dalete;
                txLevelName.Text = null;
                txLevelName.Enabled = false;
                txLevelName.BorderColor = Color.Red;
                txContant.Text = null;
                txContant.Enabled = false;
                txContant.BorderColor = Color.Red;
            }
        }

        DataTable data = null;

        private void FillMenue()
        {
             data = clsLevels.GetLevels();
            foreach (DataRow row in data.Rows)
            {
                dgvlevels.Rows.Add(row["Code"],row["Level"], row["LevelContant"], row["TotalKids"]);
            }
        }
        private bool Add()
        {
            return clsLevels.AddLevel(txLevelName.Text, txContant.Text);
        }

        private bool _Update()
        {
            return clsLevels.UpdateLevel(Convert.ToInt16(txCode.Text),txLevelName.Text, txContant.Text);
        }

        private void MakeTheChanges()
        {
            if (rdAdd.Checked == false && rdUpdate.Checked == false)
            {
                clsUtil.Show("لا توجد عملية محددة؟", false);
                return;
            }

            switch (mode)
            {
                case enMode.Add:
                    {
                        if (txLevelName.Text == "" || txLevelName.Text == "")
                        {
                            clsUtil.Show("قم بتعبئة الخانات بصورة جيدة", false);
                            return;
                        }
                        if (Add())
                        {
                            clsUtil.Show("تم إضافة المستوي بنجاح");
                            dgvlevels.Rows.Clear();
                            FillMenue();
                        }
                        else
                        {
                            clsUtil.Show("لم تتم الإضافة تأكد من المعلومات المضافة", false);
                        }
                    }
                    break;

                case enMode.Update:
                    {
                        if (txCode.Text == "")
                        {
                            clsUtil.Show("قم بتعبئة الخانات بصورة جيدة", false);
                            return;
                        }
                        if (_Update())
                        {
                            clsUtil.Show("تم تحديث المستوي بنجاح");
                            dgvlevels.Rows.Clear();
                            FillMenue();
                        }
                        else
                        {
                            clsUtil.Show("لم يتم التحديث تأكد من المعلومات وخصوصا الكود الخاص بالمستوي المراد تعديله", false);
                        }
                    }
                    break;
            }
        }

      
        private void btSave_Click(object sender, EventArgs e)
        {

            MakeTheChanges();
        }

        private void Levels_Load(object sender, EventArgs e)
        {
            FillMenue();
        }

        public void btRefreash_Click()
        {
            dgvlevels.Rows.Clear();
            FillMenue();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            
            if (mode == enMode.dalete)
            {
                if (txCode.Text == "")
                {
                    clsUtil.Show("من فضلك أدخل الكود للمسح...", false);
                    return;
                }
                if (clsLevels.DeleteLevelWithID(Convert.ToByte(txCode.Text)))
                {
                    clsUtil.Show("تم مسح المستوي بنجاح");
                    dgvlevels.Rows.Clear();
                    FillMenue();
                    return;
                }
                else
                {
                    clsUtil.Show("هذا المستوي مرتبط مع بيانت اخري لا تستطيع مسحه يجب مسح متعلقاته اولا !", false);
                }

            }
            else
            {
                if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع المستويات ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
                {
                    if(clsLevels.DeleteAllLevels())
                    {
                       clsUtil.Show("تم مسح جميع المستويات"); 
                        
                    }
                    else
                    {
                        clsUtil.Show("يبدو أن هناك مستوي مرتبط مع بيانت اخري لا أستطيع مسحه يجب مسح متعلقاته اولا", false);
                    }
                }
            }
                

        }

    }
}
