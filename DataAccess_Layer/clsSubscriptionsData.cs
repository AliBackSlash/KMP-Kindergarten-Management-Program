using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace MyDataAccessLayer
{
    public class clsSubscriptionsData
    {
        public static bool UpdateRemnderForChild(string Code, DateTime Month, float Amount, int UserID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_UpdateRemnderForChild @Month ,@Code,@Amount,@UserID", connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@Month", Month);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Amount", Amount);

                    try
                    {
                        connection.Open();
                        // يتم حفظ سجل الخزينة من داخل ال stored procedure
                        return command.ExecuteNonQuery() != 0;
                        
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public static DataTable GetChildSubscripInfo()
        {
            DataTable datble = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                
                using (SqlCommand command = new SqlCommand("Exec SP_GetChildSubscripInfo", connection))
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
            }
            return datble;
        }

        public static DataTable GetChildSubscripInfo(string Name)
        {
            DataTable datble = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_GetChildSubscripInfoWithFilter @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
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
                        throw;
                    }
                }
            }
            return datble;
        }

        public static bool GetPaymentSubscriptionInfoDataAndPutItInSubscraitionPaymentTable(bool IsPayInBegning)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_GetPaymentSubscriptionInfoDataAndPutItInSubscraitionPaymentTable @IsPayInBegning", connection))
                {
                    command.Parameters.AddWithValue("@IsPayInBegning", IsPayInBegning);
                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static bool deleteSubscraipPayment(string Code)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("delete from SubscraitionPayment where Code = @Code", connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
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
        }

        public static DataTable GetPaymentSubscriptionInfo(string Code = "")
        {
            DataTable datble = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
               
                using (SqlCommand command = new SqlCommand("Exec SP_GetPaymentSubscriptionInfo @Code", connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
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
                        throw;
                    }
                }
            }
            return datble;
        }

        public static bool AddToPaymentHistory(float Amount,
            DateTime DateOfPayment, float Remander, string Code, DateTime Month, int UserID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
               
                using (SqlCommand command = new SqlCommand("Exec SP_AddToPaymentHistory @Amount  , @DateOfPayment , @Remander , @Code , @Month,@UserID", connection))
                {

                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@DateOfPayment", DateOfPayment);
                    command.Parameters.AddWithValue("@Remander", Remander);
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@Month", Month);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        // يتم حفظ سجل الخزينة من داخل ال stored procedure

                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                        
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public static DataTable GetPaymentHistoryInfo()
        {
            DataTable datble = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_GetPaymentHistoryInfo", connection))
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
                        throw;
                    }
                }
            }
            return datble;
        }
    }
}
