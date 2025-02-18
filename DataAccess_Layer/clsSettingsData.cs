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
        public static DataTable GetSettingInfo()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "select * from ProgramSetting";

            SqlCommand command = new SqlCommand(query, connection);



            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    datble.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return datble;
        }

        public static bool UpdateSetting(string DaysLateToPay, string DaysKindsAbsence, string KidsBratherAge,
           string KidsBratherAge2, string timeEnter, string lasttimeEnter, string lasttimeLeave, string timeLeave, string TimeEarlyLeave, string NotefayKidsLate,
            string TimeEnterForTeacher, string TimeLeaveForTeacher, string TimeEnterForWorker, string TimeLeaveForWorker,
            string LateDiscount, string AbsenceLate, string DayOfStaudyInMonth, char Vication1, char Vication2, string packupPath, string
            OrgName, string ManagerName, bool SmaolPaper, string LogoPath,bool AskBeforPrint,bool ShowBeforPrint, string SMSNumber, string WhatsAppNumber, string OrgEmail
            , string AbsenceMessage, string SubMessage,string BrothersAgeMessage,string BirthDayMessage)

        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "UPDATE ProgramSetting" +
                "   SET DaysLateToPay   =@DaysLateToPay " +
                ",DaysKindsAbsence       =@DaysKindsAbsence  " +
                ",KidsBratherAge =@KidsBratherAge ," +
                "KidsBratherAge2=@KidsBratherAge2 " +
                " ,timeEnter =@timeEnter " +
                " ,LasttimeEnter =@lasttimeEnter" +
                " ,timeLeave =@timeLeave " +
                ",LasttimeLeave=@lasttimeLeave" +
                " ,TimeLateForKids =@TimeEarlyLeave" +
                ",NotefayKidsLate  =@NotefayKidsLate" +
                " ,TimeEnterForTeacher =@TimeEnterForTeacher" +
                " ,TimeLateForTeachers =@TimeLeaveForTeacher" +
                " ,TimeEnterForWorker  =@TimeEnterForWorker" +
                " ,TimeLateForWorkers  =@TimeLeaveForWorker" +
                "  ,LateDiscount  =@LateDiscount" +
                ",AbsenceLate  =@AbsenceLate" +
                " ,DayOfStaudyInMonth  =@DayOfStaudyInMonth " +
                ",Vication1  =@Vication1," +
                "Vication2 =@Vication2 " +
                ",packupPath =@packupPath " +
                ",ShowBeforPrint =@ShowBeforPrint" +
                ",OrgName =@OrgName ,SmallPaper =@SmaolPaper " +
                " ,ManagerName =@ManagerName ,LogoPath =@LogoPath" +
                ",AskBeforPrint = @AskBeforPrint" +
                ",SMSNumber =@SMSNumber" +
                ",WhatsAppNumber =@WhatsAppNumber" +
                ",AbsenceMessage = @AbsenceMessage" +
                ",SubMessage = @SubMessage" +
                ",BrothersAgeMessage = @BrothersAgeMessage" +
                ",BirthDayMessage = @BirthDayMessage" +
                ",OrgEmail =@OrgEmail";

            SqlCommand command = new SqlCommand(query, connection);
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
            if (LogoPath != null)
                command.Parameters.AddWithValue("@LogoPath", LogoPath);
            else
                command.Parameters.AddWithValue("@LogoPath", DBNull.Value);
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


            bool success = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    success = true;
            }
            catch (Exception)
            {
                success = false;


            }
            finally { connection.Close(); }

            return success;
        }


        static string GetProjectPath()
        {
            return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        }
        static string GetFirstFileInProject(string path)
        {
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            if (files.Length > 0)
                return files[0];

            return "";
        }
        public static void RestorDataBase()
        {
            string DataBasePath = GetFirstFileInProject(GetProjectPath())+"KMP.back";
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "use KMP backup database KMP to disk = '@DataBasePath'";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DataBasePath", DataBasePath);

            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool BackUPDataBase(string BackupPath)
        {
            bool success = false;

            try
            {
                string directory = Path.GetDirectoryName(BackupPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string query;
                if (!File.Exists(BackupPath))
                    query = $"BACKUP DATABASE KMP TO DISK = '{BackupPath}'";
                else
                    query = $"BACKUP DATABASE KMP TO DISK = '{BackupPath}' WITH DIFFERENTIAL";


                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        if (command.ExecuteNonQuery() != 0)
                            success = true;

                    }
                }
            }
            catch (Exception ex)
            {
            }

            return success;
        }
    }

}


