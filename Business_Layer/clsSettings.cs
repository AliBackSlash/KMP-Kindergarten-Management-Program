
using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyBusinessLayer
{
    public class clsSettings
    {
        public byte DaysLateToPay { get; }
        public byte DaysKindsAbsence { get; }
        public short KidsBratherAge { get; }
        public string KidsBratherAge2 { get; }
        public string TimeEnter { get; }
        public string LasttimeEnter { get; }
        public string LasttimeLeave { get; }
        public string TimeLeave { get; }
        public string TimeLateForKids { get; }
        public string NotefayKidsLate { get; }
        public string TimeEnterForTeacher { get; }
        public string TimeLateForTeachers { get; }
        public string TimeEnterForWorkers { get; }
        public string TimeLateForWorkers { get; }
        public float LateDiscount { get; }
        public float AbsenceLate { get; }
        public string DaysOfStaudyInMonth { get; }
        public byte Vication1 { get; }
        public byte Vication2 { get; }
        public string PackupPath { get; }
        public string OrgName { get; }
        public string ManagerName { get; }
        public bool SmallPaper { get; }
        public string LogoPath { get; }
        public bool AskBeforPrint { get; }
        public bool ShowBeforPrint { get; }
        public string SMSNumber { get; }
        public string WhatsAppNumber { get; }
        public string OrgEmail { get; }
        public string AbsenceMessage { get; }
        public string SubMessage { get; }
        public string BrothersAgeMessage { get; }
        public string BirthDayMessage { get; }
        public string EmpAge { get; }
        public bool IsPayInBegning { get; }
        public clsSettings(byte DaysLateToPay, byte DaysKindsAbsence, short KidsBratherAge,
           string KidsBratherAge2, string timeEnter, string lasttimeEnter, string lasttimeLeave, string timeLeave, string TimeLateForKids, string NotefayKidsLate,
           string TimeEnterForTeacher, string TimeLateForTeacher, string TimeEnterForWorker, string TimeLateForWorkers,
           float LateDiscount, float AbsenceLate, string DayOfStaudyInMonth, byte Vication1, byte Vication2, string packupPath, string
           OrgName, string ManagerName, bool SmaolPaper, string LogoPath, bool AskBeforPrint, bool ShowBeforPrint, string SMSNumber, string WhatsAppNumber,
           string OrgEmail, string AbsenceMessage, string SubMessage, string BrothersAgeMessage, string BirthDayMessage, string EmpAge, bool isPayInBegning)
        {
            this.DaysLateToPay = DaysLateToPay;
            this.DaysKindsAbsence = DaysKindsAbsence;
            this.KidsBratherAge = KidsBratherAge;
            this.KidsBratherAge2 = KidsBratherAge2;
            TimeEnter = timeEnter;
            LasttimeEnter = lasttimeEnter;
            LasttimeLeave = lasttimeLeave;
            TimeLeave = timeLeave;
            this.TimeLateForKids = TimeLateForKids;
            this.NotefayKidsLate = NotefayKidsLate;
            this.TimeEnterForTeacher = TimeEnterForTeacher;
            this.TimeLateForTeachers = TimeLateForTeacher;
            this.TimeEnterForWorkers = TimeEnterForWorker;
            this.TimeLateForWorkers = TimeLateForWorkers;
            this.LateDiscount = LateDiscount;
            this.AbsenceLate = AbsenceLate;
            this.DaysOfStaudyInMonth = DayOfStaudyInMonth;
            this.Vication1 = Vication1;
            this.Vication2 = Vication2;
            PackupPath = packupPath;
            this.OrgName = OrgName;
            this.ManagerName = ManagerName;
            this.SmallPaper = SmaolPaper;
            this.LogoPath = LogoPath;
            this.AskBeforPrint = AskBeforPrint;
            this.ShowBeforPrint = ShowBeforPrint;
            this.SMSNumber = SMSNumber;
            this.WhatsAppNumber = WhatsAppNumber;
            this.OrgEmail = OrgEmail;
            this.AbsenceMessage = AbsenceMessage;
            this.SubMessage = SubMessage;
            this.BrothersAgeMessage = BrothersAgeMessage;
            this.BirthDayMessage = BirthDayMessage;
            this.EmpAge = EmpAge;
            IsPayInBegning = isPayInBegning;
        }
        public static DataTable GetSettingInfo()
        {
            return clsSettingsData.GetSettingInfo();
        }

        public static clsSettings GetSetting()
        {
            DataTable SettingData = clsSettingsData.GetSettingInfo();
            string   KidsBratherAge2 = "", timeEnter = "", lasttimeEnter = "", lasttimeLeave = "", timeLeave = "", TimeLateForKids = "", NotefayKidsLate = "", TimeEnterForTeacher = "", TimeLateForTeacher = "", 
            TimeEnterForWorker = "", TimeLateForWorkers = "", DayOfStaudyInMonth = "", packupPath = "", OrgName = "", ManagerName = "", LogoPath = "", 
            SMSNumber = "", WhatsAppNumber = "", OrgEmail = "", AbsenceMessage = "", SubMessage = "", BrothersAgeMessage = "",BirthDayMessage = "", EmpAge = "";
            byte DaysLateToPay = 0, DaysKindsAbsence = 0;
            float LateDiscount = 0, AbsenceLate = 0;
            byte Vication1 = 0, Vication2 = 0;
            short KidsBratherAge = 0;


            bool AskBeforPrint = false, ShowBeforPrint = false, SmaolPaper = false, IsPayInBegning = false;
            DataRow row;
            bool Success = false;
            if (SettingData!=null)
            {
                row = SettingData.Rows[0];

                DaysLateToPay = Convert.ToByte(row["DaysLateToPay"]);
                DaysKindsAbsence = Convert.ToByte(row["DaysKindsAbsence"]);
                KidsBratherAge = Convert.ToInt16( row["KidsBratherAge"]);
                KidsBratherAge2 = row["KidsBratherAge2"].ToString();
                timeEnter = row["timeEnter"].ToString();
                lasttimeEnter = row["LasttimeEnter"].ToString();
                lasttimeLeave = row["LasttimeLeave"].ToString();
                timeLeave = row["timeLeave"].ToString();
                TimeLateForKids = row["TimeLateForKids"].ToString();
                NotefayKidsLate = row["NotefayKidsLate"].ToString();
                TimeEnterForTeacher = row["TimeEnterForTeacher"].ToString();
                TimeLateForTeacher = row["TimeLateForTeachers"].ToString();
                TimeEnterForWorker = row["TimeEnterForWorker"].ToString();
                TimeLateForWorkers = row["TimeLateForWorkers"].ToString();
                LateDiscount = Convert.ToSingle(row["LateDiscount"]);
                AbsenceLate = Convert.ToSingle(row["AbsenceLate"]);
                DayOfStaudyInMonth = row["DayOfStaudyInMonth"].ToString();
                packupPath = row["packupPath"].ToString();
                OrgName = row["OrgName"].ToString();
                ManagerName = row["ManagerName"].ToString();
                LogoPath = row["LogoPath"]?.ToString();
                SMSNumber = row["SMSNumber"]?.ToString();
                WhatsAppNumber = row["WhatsAppNumber"]?.ToString();
                OrgEmail = row["OrgEmail"]?.ToString();
                AbsenceMessage = row["AbsenceMessage"].ToString();
                SubMessage = row["SubMessage"].ToString();
                BrothersAgeMessage = row["BrothersAgeMessage"].ToString();
                BirthDayMessage = row["BirthDayMessage"].ToString();
                EmpAge = row["EmpAge"].ToString();

                Vication1 = Convert.ToByte(row["Vication1"]);
                Vication2 = Convert.ToByte(row["Vication2"]);

                AskBeforPrint = Convert.ToBoolean(row["AskBeforPrint"]);
                ShowBeforPrint = Convert.ToBoolean(row["ShowBeforPrint"]);
                SmaolPaper = Convert.ToBoolean(row["SmallPaper"]);
                IsPayInBegning = Convert.ToBoolean(row["IsPayInBegning"]);
                Success = true;
            }

            if (Success)
                return new clsSettings( DaysLateToPay,  DaysKindsAbsence,  KidsBratherAge,
            KidsBratherAge2,  timeEnter,  lasttimeEnter,  lasttimeLeave,  timeLeave,  TimeLateForKids,  NotefayKidsLate,
            TimeEnterForTeacher,  TimeLateForTeacher,  TimeEnterForWorker,  TimeLateForWorkers,
            LateDiscount,  AbsenceLate,  DayOfStaudyInMonth,  Vication1,  Vication2,  packupPath, 
           OrgName,  ManagerName,  SmaolPaper,  LogoPath,  AskBeforPrint,  ShowBeforPrint,  SMSNumber,  WhatsAppNumber,
            OrgEmail,  AbsenceMessage,  SubMessage,  BrothersAgeMessage,  BirthDayMessage,  EmpAge,IsPayInBegning);
            else
                return null;



        }

        public static bool UpdateSetting(string DaysLateToPay, string DaysKindsAbsence, string KidsBratherAge,
           string KidsBratherAge2, string timeEnter, string lasttimeEnter, string lasttimeLeave, string timeLeave, string TimeLateForKids, string NotefayKidsLate,
           string TimeEnterForTeacher, string TimeLateForTeacher, string TimeEnterForWorker, string TimeLateForWorkers,
           string LateDiscount, string AbsenceLate, string DayOfStaudyInMonth, char Vication1, char Vication2, string packupPath, string
           OrgName, string ManagerName, bool SmaolPaper, string LogoPath, bool AskBeforPrint,bool ShowBeforPrint,string SMSNumber,string WhatsAppNumber,
           string OrgEmail,string AbsenceMessage,string SubMessage,string BrothersAgeMessage,string BirthDayMessage,string EmpAge,bool IsPayInBegning)
        {
            return clsSettingsData.UpdateSetting(DaysLateToPay, DaysKindsAbsence, KidsBratherAge,
            KidsBratherAge2, timeEnter, lasttimeEnter, lasttimeLeave, timeLeave, TimeLateForKids, NotefayKidsLate,
            TimeEnterForTeacher, TimeLateForTeacher, TimeEnterForWorker, TimeLateForWorkers,
            LateDiscount, AbsenceLate, DayOfStaudyInMonth, Vication1, Vication2, packupPath,
           OrgName, ManagerName, SmaolPaper, LogoPath, AskBeforPrint, ShowBeforPrint,  SMSNumber,  WhatsAppNumber,  OrgEmail, 
           AbsenceMessage,  SubMessage, BrothersAgeMessage, BirthDayMessage, EmpAge, IsPayInBegning);
        }

        public static bool BackUPDataBase(string BackupPath)
        {
          return clsSettingsData.BackUPDataBase(BackupPath);
        }

        public static bool RestoreData(string Path)
        {
            return clsSettingsData.RestoreData(Path);
        }
    }
}
