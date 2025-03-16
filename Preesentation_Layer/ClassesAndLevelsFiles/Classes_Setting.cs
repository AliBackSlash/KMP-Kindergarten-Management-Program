using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }
        enum enMode { Add, Update, dalete }
        enMode mode = enMode.Add;
        private void rdAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAdd.Checked)
            {

                txCode.Text = null;
                txCode.Enabled = false;
                btSave.Enabled = true;
                btSave.Text = "إضافة";
                txCode.BorderColor = Color.Red;
                mode = enMode.Add;
                txName.Enabled = true;
                txName.BorderColor = Color.MediumSlateBlue;



            }
            else if (rdUpdate.Checked)
            {

                txCode.Enabled = true;
                btSave.Text = "تعديل";
                btSave.Enabled = true;
                txCode.BorderColor = Color.MediumSlateBlue;
                mode = enMode.Update;
                txName.Enabled = true;
                txName.BorderColor = Color.MediumSlateBlue;

            }
            else
            {
                btSave.Text = ".......";
                btSave.Enabled=false;
                txCode.Enabled = true;
                txCode.BorderColor = Color.MediumSlateBlue;
                mode = enMode.Update;
                txName.Text = null;
                txName.Enabled = false;
                txName.BorderColor = Color.Red;
                mode = enMode.dalete;

            }
        }

        DataTable data = null;

        private void FillMenue()
        {
            data = clsClsases.GetClassesInfo();
            foreach (DataRow row in data.Rows)
            {
                dgvClasses.Rows.Add(row["Code"], row["Class"], row["Name"], row["TotalKids"]);
            }
        }
        private bool Add()
        {
            return clsClsases.AddClass(txName.Text);

        }

        private bool _Update()
        {
            return clsClsases.UpdateClass(Convert.ToByte(txCode.Text),txName.Text);
        }


        private void MakeTheChanges()
        {
            if (rdAdd.Checked == false && rdUpdate.Checked == false)
            {
                clsUtil.Show("لا توجد عملية محددة؟", false, () => txCode.Focus());
                return;
            }

            switch (mode)
            {
                case enMode.Add:
                    {
                        if (txName.Text == "")
                        {
                            clsUtil.Show("قم بتعبئة الخانات بصورة جيدة", false, () => txCode.Focus());
                            return;
                        }
                        if (Add())
                        {
                            clsUtil.Show("تم إضافة الفصل بنجاح");
                            dgvClasses.Rows.Clear();
                            FillMenue();
                        }
                        else
                        {
                            clsUtil.Show("لم تتم الإضافة تأكد من المعلومات المضافة", false, () => txCode.Focus());
                        }
                    }
                    break;

                case enMode.Update:
                    {
                        if (txName.Text == "" || txCode.Text == "")
                        {
                            clsUtil.Show("قم بتعبئة الخانات بصورة جيدة", false, () => txCode.Focus());
                            return;
                        }
                        if (_Update())
                        {
                            clsUtil.Show("تم تحديث الفصل بنجاح");
                            dgvClasses.Rows.Clear();
                            FillMenue();
                        }
                        else
                        {
                            clsUtil.Show("لم يتم التحديث تأكد من المعلومات وخصوصا الكود الخاص بالفصل المراد تعديله", false, () => txCode.Focus());
                        }
                    }
                    break;
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {

            MakeTheChanges();

        }

        private void Clases_Load(object sender, EventArgs e)
        {
            FillMenue();
        }

        public void btRefreash()
        {
            dgvClasses.Rows.Clear();
            FillMenue();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

           
            if (mode == enMode.dalete)
            {
                if (txCode.Text == "")
                {
                    clsUtil.Show("أدخل الكود من فضلك ",false, () => txCode.Focus());
                    return;
                }
                if (clsClsases.DeleteClasseWithID(Convert.ToInt16(txCode.Text)))
                {
                    clsUtil.Show("تم مسح الفصل بنجاح");
                    dgvClasses.Rows.Clear();
                    FillMenue();
                    return;
                }
                else
                {
                    clsUtil.Show(" هذا الفصل مرتبط مع بيانت اخري لا أستطيع مسحه يجب مسح متعلقاته اولا!", false, () => txCode.Focus());
                }

            }
            else
            {
                if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع المستويات ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
                {
                    if (clsClsases.DeleteAllClasses())
                    {
                        clsUtil.Show("تم مسح جميع الفصول بنجاح");
                        dgvClasses.Rows.Clear();
                        FillMenue();
                        return;
                    }
                    else
                    {
                        clsUtil.Show("يبدو أن هناك فصل مرتبط مع بيانت اخري لا أستطيع مسحه يجب مسح متعلقاته اولا",false, () => txCode.Focus());
                    }
                }
            }


        }

    }
}

