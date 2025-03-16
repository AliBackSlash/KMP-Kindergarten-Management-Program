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

namespace K_M_S_PROGRAM.Accounts
{
    public partial class DiscountInfo : Form
    {
        public DiscountInfo(int ID, string Month, char Kind = 'T')
        {
            InitializeComponent();
            _AbsenceDays = clsGeneric.ReturnGroupOfDataIWant($"select Date from AbsenceHistory where DateMonthForAbsnce = '{Month}' and ID = {ID} and Kind = '{Kind}'");
            _LateHoursDays = clsGeneric.ReturnGroupOfDataIWant($"select Date , cast(Late as int) as Late from EnterAndLeaveHistory where Month = '{Month}' and ID = {ID} and cast(Late as int)>0 and Kind ='{Kind}'; ");
        }


        DataTable _AbsenceDays;
        DataTable _LateHoursDays;
        float LateHoursPrice = clsGlobal.Settings.LateDiscount;
        float AbsencePrice = clsGlobal.Settings.AbsenceLate;
        //move this form
        bool move;
        int moveX, moveY;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            moveX = e.X;
            moveY = e.Y;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string FillLists(float totalMinutes)
        {
            TimeSpan timeSpan = TimeSpan.FromMinutes(totalMinutes);
            int hours = (int)timeSpan.TotalHours; // عدد الساعات  
            int minutes = timeSpan.Minutes; // عدد الدقائق المتبقية  
            return $"{hours}:{minutes}";
        }
        private void FillLists()
        {
            foreach (DataRow row in _AbsenceDays.Rows)
                dgvAbsence.Rows.Add(clsUtil.GitDayInWeekName((DateTime)row["Date"]),Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat));
            foreach (DataRow row in _LateHoursDays.Rows)
                dgvLates.Rows.Add(clsUtil.GitDayInWeekName((DateTime)row["Date"]), Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Late"]);

            if (_AbsenceDays.Rows.Count > 0)
            {
                float AbsDay = _AbsenceDays.Rows.Count;

                lbTotlAbsenceDays.Text = AbsDay.ToString();
                lbAbsenceAmount.Text = (AbsDay * AbsencePrice).ToString();
            }
            if (_LateHoursDays.Rows.Count > 0)
            {
                float LateMinutes = Convert.ToSingle(_LateHoursDays.Compute("SUM(Late)", string.Empty));

                lbTotalHoursLate.Text = FillLists(LateMinutes);
                lbLateAmount.Text = ((LateMinutes/60) * LateHoursPrice).ToString();
            }
        }
        private void DiscountInfo_Load(object sender, EventArgs e)
        {
            lbLateHoursPrice.Text = LateHoursPrice.ToString();
            lbAbsencePrice.Text = AbsencePrice.ToString();
            FillLists();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }


    }
}
