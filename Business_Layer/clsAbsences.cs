using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsAbsences
    {
        public static DataTable ReturnEnteredInfo(string query)
        {
            return clsAbsenceData.ReturnEnteredInfo(query);
        }

        public static bool AddToEnterAndLeaveHistory( int ID, DateTime Date, short Late, char Kind)
        {
            return clsAbsenceData.AddToEnterAndLeaveHistory(ID,Date, Late, Kind);
        }
        public static bool AddToLeaveHistory(int ID,DateTime Date , char Kind)
        {
            return clsAbsenceData.AddToLeaveHistory(ID,Date,Kind);
        }

        public static bool ISThisMemberAlreadyRegister(string ID, DateTime Date, char Kind)
        {
            return clsAbsenceData.ISThisMemberAlreadyRegister(ID, Date, Kind);
        }

        public static bool ISThisMemberAlreadyRegisterLeave(string ID, DateTime Date, char Kind)
        {
            return clsAbsenceData.ISThisMemberAlreadyRegisterLeave(ID, Date, Kind); ;
        }

        public static bool AddToAbsenceHistory( int ID, DateTime Date, char Kind)
        {
            return clsAbsenceData.AddToAbsenceHistory(ID, Date, Kind);
        }

        public static bool FindChild(int ID)
        {
            return clsAbsenceData.FindChild(ID);
        }

        public static bool FindEmployee(int ID)
        {
            return clsAbsenceData.FindEmployee(ID);
        }

        public static bool FindWorker(int ID)
        {
            return clsAbsenceData.FindWorker(ID);
        }

        public static DataTable GetLeaveHistory(char Kind)
        {
            return clsAbsenceData.GetLeaveHistory(Kind);
        }
        public static DataTable GetLeaveHistoryBetweenTowDates(char Kind, DateTime DateFrom, DateTime DateTo)
        {
            return clsAbsenceData.GetLeaveHistoryBetweenTowDates(Kind, DateFrom, DateTo);
        }
        public static DataTable GetEnterHistory(char Kind)
        {
            return clsAbsenceData.GetEnterAndLeaveHistory(Kind);
        }

        public static DataTable GetEnterAndLeaveHistoryBetweenTowDates(char Kind, DateTime DateFrom, DateTime DateTo)
        {
            return clsAbsenceData.GetEnterAndLeaveHistoryBetweenTowDates(Kind, DateFrom, DateTo);
        }

        public static DataTable GetAllMemberThanDontCameToday(string query)
        {
            return clsAbsenceData.GetAllMemberThatDontCameToday(query);
        }

        public static DataTable GetAbsenceHistoryData(char Kind)
        {
            return clsAbsenceData.GetAbsenceHistoryData(Kind);
        }
        public static DataTable GetAbsenceHistoryDataBetweenTwoDates(char Kind, DateTime DateFrom, DateTime DateTo)

        {
            return clsAbsenceData.GetAbsenceHistoryDataBetweenTwoDates(Kind, DateFrom, DateTo);
        }
        public static bool DeleteAllAbsence()
        {
            return clsAbsenceData.DeleteAllAbsence();
        }

        public static bool DeleteEnterHistory()
        {
            return clsAbsenceData.DeleteAllEnterHistory();
        }

        public static bool DeleteAllLeaveHistory()
        {
            return clsAbsenceData.DeleteAllLeaveHistory();
        }

        public static DataTable ReturnKidsThatAbsenceMoreInThisMonth(byte DayOfAbsenceToNote)
        {
            return clsAbsenceData.ReturnKidsThatAbsenceMoreInThisMonth(DayOfAbsenceToNote);
        }
    }
}
