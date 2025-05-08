using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_M_S_PROGRAM.Kids_sFile.AddChaild
{
    public partial class ChoicePerantsAndPersonCanTake : Form
    {
        public ChoicePerantsAndPersonCanTake(bool IsPerants,int ChildID)
        {
            InitializeComponent();
            this.IsParents = IsPerants;
            this.ChildID = ChildID;
        }
        bool IsParents;
        int ChildID;

        void FillData(bool IsParents)
        {
            DataTable Names = clsGeneric.FillComboBoxWithNames(IsParents ? "Select cast(Code as nvarchar) + '-' + FatherName as Name from PerantInfo order by Code"
                : "Select cast(Code as nvarchar) + '-' +Name as Name from KidsPersonalInfo");
            cmNames.Items.Clear();
            foreach (DataRow row in Names.Rows)
            { cmNames.Items.Add(row["Name"]); }
        }

        private void ChoicePerantsAndPersonCanTake_Load(object sender, EventArgs e)
        {
            FillData(IsParents);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cmNames.Text != "")
            {
                int PCode = Convert.ToInt32(cmNames.Text.Substring(0, cmNames.Text.IndexOf("-")));
                if (clsGeneric.PerformOperationAndReturnBoolean($"update KidsPersonalInfo set PerantID = {PCode} where Code = {ChildID}"))
                    clsUtil.Show("تم بنجاح");
                else
                    clsUtil.Show("هناك خطأ حدث تواصل مع الدعم الفني", false);
            }
            else
                clsUtil.Show("اختر والد اولا", false);
        }
    }
}
