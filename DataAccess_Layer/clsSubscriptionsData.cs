using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace MyDataAccessLayer
{
    public class clsSubscriptionsData
    {
        public static bool UpdateRemnderForChild(string Code,string Month,float Amount,int UserID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Update SubscriptionsHistory set Amount = Amount+Remander,Remander = 0 where Month = @Month and Code = @Code";

            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@Month", Month);
           

            bool Saccess = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                {

                    Saccess = true;
                    //will be converted to trunsaction in T-SQL soon

                    if (Month == DateTime.Now.ToString("MM-yyyy"))
                        clsTreasuryData.AddToTreasuryMonthlyData(Amount, DateTime.Now, 'B', true, UserID, Convert.ToInt32(Code));
                    else 
                        clsTreasuryData.AddToTreasuryYearlyData(Amount, DateTime.Now, 'B', true, UserID, Convert.ToInt32(Code));

                }
            }
            catch (Exception)
            {
                Saccess = false;
            }
            finally { connection.Close(); }

            return Saccess;
        }

        public static DataTable GetChildSubscripInfo()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT  KidsPersonalInfo.Gendor,KidsPersonalInfo.Code, KidsPersonalInfo.Name, Clases.Class, KidsPersonalInfo.SubscirptionID FROM KidsPersonalInfo" +
                " INNER JOIN Clases ON KidsPersonalInfo.ClassID = Clases.Code";

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
        public static DataTable GetChildSubscripInfo(string Name)
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT  KidsPersonalInfo.Gendor,KidsPersonalInfo.Code, KidsPersonalInfo.Name, Clases.Class, KidsPersonalInfo.SubscirptionID FROM KidsPersonalInfo" +
                $" INNER JOIN Clases ON KidsPersonalInfo.ClassID = Clases.Code where KidsPersonalInfo.Name like '{Name}%'";

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
        public static bool GetPaymentSubscriptionInfoDataAndPutItInSubscraitionPaymentTable()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "insert  into SubscraitionPayment select * from SubscraitionPaymentData";

            SqlCommand command = new SqlCommand(query, connection);

            bool success = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    success = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return success;
        }

        public static bool deleteSubscraip(string Code)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "delete from  SubscraitionPayment where Code = @Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);
            bool success = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    success = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return success;
        }

        public static DataTable GetPaymentSubscriptionInfo(string Code="") 
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query;
            if (Code != "")
                query = "select * from SubscraitionPayment where Code = @Code  order by Code";
            else
                query = "select * from SubscraitionPayment  order by Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);
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

        public static bool AddToPaymentHistory(bool Gendor, string Name, string Level, string Class, bool Period, string Amount
            , DateTime DateOfPayment, string Remander, string Code, string Month, int UserID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "INSERT INTO SubscriptionsHistory (Gendor ,Name ,Level ,Class ,Period ,Amount  ,DateOfPayment ,Remander,Code,Month)" +
                           "VALUES" +
                           "(@Gendor ,@Name ,@Level ,@Class ,@Period ,cast(@Amount as smallmoney) ,@DateOfPayment  ,@Remander,@Code,@Month)";
            //will be converted to trunsaction in T-SQL soon


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Level", Level);
            command.Parameters.AddWithValue("@Class", Class);
            command.Parameters.AddWithValue("@Period", Period);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@DateOfPayment", DateOfPayment);
            command.Parameters.AddWithValue("@Remander", Remander);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@Month", Month);


            bool Saccess = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                {
                    Saccess = true;
                    clsTreasuryData.AddToTreasuryMonthlyData(Convert.ToSingle(Amount), DateTime.Now, 'K', true, UserID, Convert.ToInt32(Code));
                }
            }
            catch (Exception)
            {
                Saccess = false;
            }
            finally { connection.Close(); }

            return Saccess;
        }

        public static DataTable GetPaymentHistoryInfo()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Select * from SubscriptionsHistory order by DateOfPayment";

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
    }
}
