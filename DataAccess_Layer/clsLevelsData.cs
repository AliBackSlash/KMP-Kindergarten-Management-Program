using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyDataAccessLayer
{
    public class clsLevelsData
    {
        public static bool AddLevel(string LevelName, string Contant)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_AddLevel @LevelName,@Contant", connection))
            {
                command.Parameters.AddWithValue("@LevelName", LevelName);
                command.Parameters.AddWithValue("@Contant", Contant);

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

        public static bool UpdateLevel(short Code, string LevelName, string Contant)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("SP_UpdateLevel @Code , @LevelName ,  @Contant", connection))
            {
                command.Parameters.AddWithValue("@LevelName", LevelName);
                command.Parameters.AddWithValue("@Contant", Contant);
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

        public static DataTable GetLevels()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetLevels", connection))
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
                    // لا يتم رمي الاستثناء
                }
                return datble;
            }
        }

        public static bool DeleteAllLevels()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_DeleteAllLevels", connection))
            {
                bool success = false;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // TRUNCATE لا تُرجع قيمة، لذا نستخدم ExecuteNonQuery
                    success = true;
                }
                catch (Exception)
                {
                    success = false;
                }
                return success;
            }
        }

        public static bool DeleteLevelWithID(byte ID)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_DeleteLevelWithID @ID", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

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

        public static short GetLevelID(string Name)
        {
            short code = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("SP_GetLevelID @Name", connection))
            {
                command.Parameters.AddWithValue("@Name", Name);

                try
                {
                    connection.Open();
                    object ID = command.ExecuteScalar();
                    if (ID != null && short.TryParse(ID.ToString(), out short result))
                        code = result;
                }
                catch (Exception ex)
                {
                }
            }
            return code;
        }

        public static string GetLevelName(short ID)
        {
            string Name = "";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetLevelName @ID", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();
                    object nameObj = command.ExecuteScalar();
                    if (nameObj != null)
                        Name = nameObj.ToString();
                }
                catch (Exception ex)
                {
                    
                }
            }
            return Name;
        }
        public static int NumberOfLevels()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_NumberOfLevels", connection))
                {
                    try
                    {
                        connection.Open();
                        return (int)command.ExecuteScalar();

                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }


        }
    }
}
