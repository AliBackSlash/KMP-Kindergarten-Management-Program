using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Add_Absence : Form
    {
        public Add_Absence()
        {
            InitializeComponent();
        }

        enum enWhoEnter { Employee, worker, child }
        enWhoEnter whoEnter = enWhoEnter.child;
        string Period = "";
       

        private void btEmployees_Click(object sender, EventArgs e)
        {
            Period = rdAM.Checked ? "حضور" : "إنصراف";
            picTirnPhoto.Image = Properties.Resources.teacher;
            lbTitle.Text = "تسجيل " + Period + " المعلمين";
            whoEnter = enWhoEnter.Employee;
        }

        private void btWorker_Click(object sender, EventArgs e)
        {
            Period = rdAM.Checked ? "حضور" : "إنصراف";

            picTirnPhoto.Image = Properties.Resources.worker;
            lbTitle.Text = "تسجيل " + Period + " العمال";
            whoEnter = enWhoEnter.worker;
        }

        private void btKids_Click(object sender, EventArgs e)
        {
            Period = rdAM.Checked ? "حضور" : "إنصراف";

            picTirnPhoto.Image = Properties.Resources.boy;
            lbTitle.Text = $"تسجيل " + Period + " الطلاب ";
            whoEnter = enWhoEnter.child;
        }

        private void EnteredTheMember()
        {
            DataTable data = new DataTable();
            DataRow row;
            DateTime date ;

            DateTime SettingEnterTime = Convert.ToDateTime(clsGlobal.Settings.TimeEnter);
            DateTime LastSettingEnterTime = Convert.ToDateTime(clsGlobal.Settings.LasttimeEnter);

           
            
            string Hour = DateTime.Now.ToString("HH:mm");
            DateTime TimeNow = DateTime.ParseExact(Hour, "HH:mm", null);
            int Code = Convert.ToInt32(txSearsh.Text);


            if (TimeNow.TimeOfDay >= SettingEnterTime.TimeOfDay && TimeNow.TimeOfDay <= LastSettingEnterTime.TimeOfDay)
            {
                switch (whoEnter)
                {
                    case enWhoEnter.child:

                        if (clsAbsences.FindChild(Code))
                        {
                            date = DateTime.Now;

                            if (clsAbsences.ISThisMemberAlreadyRegister(txSearsh.Text, date, 'C'))
                                clsUtil.Show("تم تحضير هذا الطالب بالفعل", false);
                            else
                            {
                                
                                DateTime SettingEnterTimeForKids = Convert.ToDateTime(clsGlobal.Settings.TimeLateForKids);
                                short late = 0;
                                if (TimeNow.TimeOfDay > SettingEnterTimeForKids.TimeOfDay)
                                {
                                    late = (short)(TimeNow - SettingEnterTimeForKids).TotalMinutes;

                                }
                               
                                if (!clsAbsences.AddToEnterAndLeaveHistory(Code, date, late, 'C'))
                                    clsUtil.Show("هناك مشكلة في البيانات يرجي التحدث مع الدعم الفني ", false);
                            }


                        }
                        else
                            clsUtil.Show("هذا الطالب غير موجود ", false);
                        break;

                    case enWhoEnter.Employee:
                        if (clsAbsences.FindEmployee(Code))
                        {
                            date = DateTime.Now;
                            if (clsAbsences.ISThisMemberAlreadyRegister(txSearsh.Text, date, 'T'))
                                clsUtil.Show("تم تحضير هذا الموظف بالفعل", false);
                            else
                            {
                                DateTime SettingEnterTimeForTeacher = Convert.ToDateTime(clsGlobal.Settings.TimeLateForTeachers);
                                short late = 0;
                                if (TimeNow.TimeOfDay > SettingEnterTimeForTeacher.TimeOfDay)
                                {
                                    late = (short)(TimeNow - SettingEnterTimeForTeacher).TotalMinutes;

                                }

                                
                                if (!clsAbsences.AddToEnterAndLeaveHistory(Code, date,  late, 'T'))
                                    clsUtil.Show("هناك مشكلة في البيانات يرجي التحدث مع الدعم الفني ", false);
                            }

                        }
                        else
                            clsUtil.Show("هذا المدرس غير موجود",false);
                        break;

                    case enWhoEnter.worker:
                        if (clsAbsences.FindWorker(Code))
                        {
                            date = DateTime.Now;
                            if (clsAbsences.ISThisMemberAlreadyRegister(txSearsh.Text, date, 'W'))
                                clsUtil.Show("تم تحضير هذا الموظف بالفعل", false );
                            else
                            {
                                DateTime SettingEnterTimeForTeacher = Convert.ToDateTime(clsGlobal.Settings.TimeLateForWorkers);
                                short late = 0;
                                if (TimeNow.TimeOfDay > SettingEnterTimeForTeacher.TimeOfDay)
                                {
                                    late = (short)(TimeNow - SettingEnterTimeForTeacher).TotalMinutes;

                                }
                               
                                if (!clsAbsences.AddToEnterAndLeaveHistory(Code, date, late, 'W'))
                                    clsUtil.Show("هناك مشكلة في البيانات يرجي التحدث مع الدعم الفني ", false);
                            }

                        }
                        else
                            clsUtil.Show("هذا العامل غير موجود", false);
                        break;
                }

            }
            else
                clsUtil.Show("لا يمكنك إضافة غياب في ذلك الوقت ", false);
        }
        //تعديل نوع التاريخ من نص الي datetime

        private void LeaveTheMember()
        {
            DataTable data = new DataTable();
            DataRow row;
            DateTime date;
            //string Time = "";

            DateTime SettingLeaveTime = Convert.ToDateTime(clsGlobal.Settings.TimeLeave);
            DateTime LastSettingLeaveTime = Convert.ToDateTime(clsGlobal.Settings.LasttimeLeave);



            string Hour = DateTime.Now.ToString("HH:mm");
            DateTime TimeNow = DateTime.ParseExact(Hour, "HH:mm", null);
            int Code = Convert.ToInt32(txSearsh.Text);


            if (TimeNow.TimeOfDay >= SettingLeaveTime.TimeOfDay && TimeNow.TimeOfDay <= LastSettingLeaveTime.TimeOfDay)
            {
                switch (whoEnter)
                {
                    case enWhoEnter.child:
                        if (clsAbsences.FindChild(Code))
                        {
                            date = DateTime.Now;
                           

                            if (clsAbsences.ISThisMemberAlreadyRegisterLeave(txSearsh.Text, date, 'C'))
                                clsUtil.Show("تم إنصراف هذا الطالب بالفعل", false);
                            else
                            {
                               
                                if (!clsAbsences.AddToLeaveHistory( Code,date, 'C'))
                                    clsUtil.Show("هناك مشكلة في البيانات يرجي التحدث مع الدعم الفني ", false);
                            }




                        }
                        else
                            clsUtil.Show("هذا الطالب غير موجود ", false);
                        break;

                    case enWhoEnter.Employee:
                        if (clsAbsences.FindEmployee(Code))
                        {
                            date = DateTime.Now;



                            if (clsAbsences.ISThisMemberAlreadyRegisterLeave(Code.ToString(), date, 'T'))
                                clsUtil.Show("تم إنصراف هذا الموظف بالفعل", false);
                            else
                            {

                              
                                if (!clsAbsences.AddToLeaveHistory(Code,date, 'T'))
                                    clsUtil.Show("هناك مشكلة في البيانات يرجي التحدث مع الدعم الفني ", false);
                            }
                        }
                        else
                            clsUtil.Show("هذا المدرس غير موجود", false);
                        break;

                    case enWhoEnter.worker:
                        if (clsAbsences.FindWorker(Code))
                        {
                            date = DateTime.Now;



                            if (clsAbsences.ISThisMemberAlreadyRegisterLeave(txSearsh.Text, date, 'W'))
                                clsUtil.Show("تم إنصراف هذا العامل بالفعل", false);
                            else
                            {
                              
                                if (!clsAbsences.AddToLeaveHistory(Code,date, 'W'))
                                    clsUtil.Show("هناك مشكلة في البيانات يرجي التحدث مع الدعم الفني ", false);
                            }


                        }
                        else
                            clsUtil.Show("هذا العامل غير موجود", false);
                        break;
                }

            }
            else
                clsUtil.Show("لا يمكنك إضافة إنصراف في ذلك الوقت ", false);
        }

        private void btEntered_Click(object sender, EventArgs e)
        {


            if (rdAM.Checked)
            {
                if (txSearsh.Text == "")
                {
                    clsUtil.Show("عفوا ولكن ليس هناك اي كود مدخل", false);
                    txSearsh.Focus();
                    return;
                }
                EnteredTheMember();
                txSearsh.Text = string.Empty;

            }
            else if (rdPM.Checked)
            {
                if (txSearsh.Text == "")
                {
                    clsUtil.Show("عفوا ولكن ليس هناك اي كود مدخل", false);
                    txSearsh.Focus();

                    return;
                }
                LeaveTheMember();
                txSearsh.Text = string.Empty;


            }
            else
                clsUtil.Show("لا يوجد فترة محددة -> حضور أو إنصراف", false);

            txSearsh.Focus();
        }

        private void rdAM_CheckedChanged(object sender, EventArgs e)
        {
            switch(whoEnter)
            {
                case enWhoEnter.child:
                    btKids_Click(null, null);
                    break;
                case enWhoEnter.worker:

                    btWorker_Click(null, null); break;
                case enWhoEnter.Employee:

                    btEmployees_Click(null, null); break;
            }
        }

        private void rdPM_CheckedChanged(object sender, EventArgs e)
        {
            switch (whoEnter)
            {
                case enWhoEnter.child:
                    btKids_Click(null, null);
                    break;
                case enWhoEnter.worker:

                    btWorker_Click(null, null);
                    break;
                case enWhoEnter.Employee:

                    btEmployees_Click(null, null);
                    break;
            }
        }

        public void Add_Absence_Load(object sender, EventArgs e)
        {
            if ((byte)DateTime.Now.DayOfWeek == clsGlobal.Settings.Vication1
               ||
             (byte)DateTime.Now.DayOfWeek == clsGlobal.Settings.Vication2)
            {
                lbVevationMessage.Visible = true;
                txSearsh.Enabled = false;
                btEntered.Enabled = false;
                rdAM.Enabled = rdAM.Checked = false;
                rdPM.Enabled = rdPM.Checked = false;
                btKids.Enabled = btTeacher.Enabled = btWorker.Enabled = false;

            }
            else
            {
                lbVevationMessage.Visible = false;
                txSearsh.Enabled = true;
                btEntered.Enabled = true;
                rdAM.Enabled = rdAM.Checked = true;
                rdPM.Enabled = rdPM.Checked = true;
                btKids.Enabled = btTeacher.Enabled = btWorker.Enabled = true;
            }

            if (DateTime.Now.Hour > 11)
                rdPM.Checked = true;
            else
                rdAM.Checked = true;

            txSearsh.Focus();

        }

        private void txSearsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = true ;
        }

    }
}
