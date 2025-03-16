using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDataAccessLayer
{
    public class clsSettingsData
    {

        public static bool RestoreData(string Path)
        {
            string query = @"use master
                 if exists( select * from sys.databases where name='KMP') 
                begin
                 drop database KMP end;
                restore database KMP
                from disk = '@Path'";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Path", Path);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() != 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static DataTable GetSettingInfo()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GetSettingInfo", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            datble.Load(reader);
                        }
                    }
                }
                catch (Exception)
                {
                   
                }
            }
            return datble;
        }

        public static bool UpdateSetting(string DaysLateToPay, string DaysKindsAbsence, string KidsBratherAge,
            string KidsBratherAge2, string timeEnter, string lasttimeEnter, string lasttimeLeave, string timeLeave,
            string TimeEarlyLeave, string NotefayKidsLate, string TimeEnterForTeacher, string TimeLeaveForTeacher,
            string TimeEnterForWorker, string TimeLeaveForWorker, string LateDiscount, string AbsenceLate,
            string DayOfStaudyInMonth, char Vication1, char Vication2, string packupPath, string OrgName,
            string ManagerName, bool SmaolPaper, string LogoPath, bool AskBeforPrint, bool ShowBeforPrint,
            string SMSNumber, string WhatsAppNumber, string OrgEmail, string AbsenceMessage, string SubMessage,
            string BrothersAgeMessage, string BirthDayMessage, string EmpAge, bool IsPayInBegning)
        {
            string query = @"exec SP_UpdateProgramSettings @DaysLateToPay ,@DaysKindsAbsence ,
                            @KidsBratherAge ,@KidsBratherAge2 ,@timeEnter ,@lasttimeEnter ,@timeLeave ,
                            @lasttimeLeave ,@TimeEarlyLeave ,@NotefayKidsLate ,
                            @TimeEnterForTeacher ,@TimeLeaveForTeacher ,@TimeEnterForWorker ,@TimeLeaveForWorker ,
                            @LateDiscount ,@AbsenceLate ,@DayOfStaudyInMonth ,@Vication1 ,@Vication2 ,
                            @packupPath ,@ShowBeforPrint ,@OrgName ,@SmaolPaper ,@ManagerName ,
                            @LogoPath ,@AskBeforPrint ,@SMSNumber ,@WhatsAppNumber ,@AbsenceMessage ,
                            @SubMessage ,@BrothersAgeMessage ,@BirthDayMessage ,@EmpAge ,@OrgEmail ,@IsPayInBegning;";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DaysLateToPay", DaysLateToPay);
                command.Parameters.AddWithValue("@DaysKindsAbsence", DaysKindsAbsence);
                command.Parameters.AddWithValue("@KidsBratherAge", KidsBratherAge);
                command.Parameters.AddWithValue("@KidsBratherAge2", KidsBratherAge2);
                command.Parameters.AddWithValue("@timeEnter", timeEnter);
                command.Parameters.AddWithValue("@timeLeave", timeLeave);
                command.Parameters.AddWithValue("@TimeEarlyLeave", TimeEarlyLeave);
                command.Parameters.AddWithValue("@NotefayKidsLate", NotefayKidsLate);
                command.Parameters.AddWithValue("@TimeEnterForTeacher", TimeEnterForTeacher);
                command.Parameters.AddWithValue("@TimeLeaveForTeacher", TimeLeaveForTeacher);
                command.Parameters.AddWithValue("@TimeEnterForWorker", TimeEnterForWorker);
                command.Parameters.AddWithValue("@TimeLeaveForWorker", TimeLeaveForWorker);
                command.Parameters.AddWithValue("@LateDiscount", LateDiscount);
                command.Parameters.AddWithValue("@AbsenceLate", AbsenceLate);
                command.Parameters.AddWithValue("@DayOfStaudyInMonth", DayOfStaudyInMonth);
                command.Parameters.AddWithValue("@Vication1", Vication1);
                command.Parameters.AddWithValue("@Vication2", Vication2);
                command.Parameters.AddWithValue("@packupPath", packupPath);
                command.Parameters.AddWithValue("@OrgName", OrgName);
                command.Parameters.AddWithValue("@ManagerName", ManagerName);
                command.Parameters.AddWithValue("@LogoPath", LogoPath ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@lasttimeEnter", lasttimeEnter);
                command.Parameters.AddWithValue("@lasttimeLeave", lasttimeLeave);
                command.Parameters.AddWithValue("@SmaolPaper", SmaolPaper);
                command.Parameters.AddWithValue("@AskBeforPrint", AskBeforPrint);
                command.Parameters.AddWithValue("@ShowBeforPrint", ShowBeforPrint);
                command.Parameters.AddWithValue("@SMSNumber", SMSNumber);
                command.Parameters.AddWithValue("@WhatsAppNumber", WhatsAppNumber);
                command.Parameters.AddWithValue("@OrgEmail", OrgEmail);
                command.Parameters.AddWithValue("@SubMessage", SubMessage);
                command.Parameters.AddWithValue("@AbsenceMessage", AbsenceMessage);
                command.Parameters.AddWithValue("@BrothersAgeMessage", BrothersAgeMessage);
                command.Parameters.AddWithValue("@BirthDayMessage", BirthDayMessage);
                command.Parameters.AddWithValue("@EmpAge", EmpAge);
                command.Parameters.AddWithValue("@IsPayInBegning", IsPayInBegning);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() != 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool BackUPDataBase(string BackupPath)
        {

            try
            {
                string directory = Path.GetDirectoryName(BackupPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                bool NotFirstBackup = File.Exists(BackupPath) ;

                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                using (SqlCommand command = new SqlCommand("Exec SP_BackUPDataBase @NotFirstBackup,@BackupPath", connection))
                {
                    command.Parameters.AddWithValue("@NotFirstBackup", NotFirstBackup);
                    command.Parameters.AddWithValue("@BackupPath", BackupPath);
                    connection.Open();
                    return command.ExecuteNonQuery() != 0;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }

}


