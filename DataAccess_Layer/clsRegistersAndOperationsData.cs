using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsRegistersAndOperationsData
    {
        public static bool AddRegister(int Code, bool IsEnter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("Exec SP_AddRegister @Code ,@IsEnter", connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@IsEnter", IsEnter);

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
        public static DataTable GetAllRegisters(string UserName = "")
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("exec SP_GetAllRegisters @UserName", connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                table.Load(reader);
                            }
                        }
                        return table;
                    }
                    catch (Exception)
                    {
                        return table; // إرجاع الجدول الفارغ في حالة الخطأ
                    }
                }
            }
        }
        public static DataTable GetAllRegisters(DateTime DateFrom, DateTime DateTo, string UserName)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
               
                using (SqlCommand command = new SqlCommand("exec SP_GetAllRegistersBetweenTwoDates  @UserName ,@DateFrom ,  @DateTo\r\n", connection))
                {
                    command.Parameters.AddWithValue("@DateFrom", DateFrom);
                    command.Parameters.AddWithValue("@DateTo", DateTo);
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                table.Load(reader);
                            }
                        }
                        return table;
                    }
                    catch (Exception)
                    {
                        return table; // إرجاع الجدول الفارغ في حالة الخطأ
                    }
                }
            }
        }
        public static bool DeleteAllRegisters()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("truncate table Registers", connection))
                {
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
    }
}
