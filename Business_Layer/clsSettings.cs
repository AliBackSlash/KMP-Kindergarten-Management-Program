
using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsSettings
    {

       
        public static DataTable GetSettingInfo()
        {
            return clsSettingsData.GetSettingInfo();
        }

        public static bool UpdateSetting(string DaysLateToPay, string DaysKindsAbsence, string KidsBratherAge,
           string KidsBratherAge2, string timeEnter, string lasttimeEnter, string lasttimeLeave, string timeLeave, string TimeLateForKids, string NotefayKidsLate,
           string TimeEnterForTeacher, string TimeLateForTeacher, string TimeEnterForWorker, string TimeLateForWorkers,
           string LateDiscount, string AbsenceLate, string DayOfStaudyInMonth, char Vication1, char Vication2, string packupPath, string
           OrgName, string ManagerName, bool SmaolPaper, string LogoPath, bool AskBeforPrint,bool ShowBeforPrint,string SMSNumber,string WhatsAppNumber,
           string OrgEmail,string AbsenceMessage,string SubMessage,string BrothersAgeMessage,string BirthDayMessage)
        {
            return clsSettingsData.UpdateSetting(DaysLateToPay, DaysKindsAbsence, KidsBratherAge,
            KidsBratherAge2, timeEnter, lasttimeEnter, lasttimeLeave, timeLeave, TimeLateForKids, NotefayKidsLate,
            TimeEnterForTeacher, TimeLateForTeacher, TimeEnterForWorker, TimeLateForWorkers,
            LateDiscount, AbsenceLate, DayOfStaudyInMonth, Vication1, Vication2, packupPath,
           OrgName, ManagerName, SmaolPaper, LogoPath, AskBeforPrint, ShowBeforPrint,  SMSNumber,  WhatsAppNumber,  OrgEmail,  AbsenceMessage,  SubMessage, BrothersAgeMessage, BirthDayMessage);
        }

        public static bool BackUPDataBase(string BackupPath)
        {
          return clsSettingsData.BackUPDataBase(BackupPath);
        }
    }
}
