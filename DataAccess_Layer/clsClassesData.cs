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
    public class clsClassesData
    {
        //done
        public static DataTable GetClassesMenue()
        {
            DataTable datble = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("SP_GetClassesMenue", connection))
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
            return datble;
        }
        //done
        public static bool DeleteAllClasses()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_DeleteAllClasses", connection))
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
        //done
        public static bool DeleteClasseWithID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_DeleteClasseWithID @ID", connection))
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
        //done
        public static bool AddClass(string ClaseName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_AddClass @ClaseName", connection))
            {
                command.Parameters.AddWithValue("@ClaseName", ClaseName);
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
        //done
        public static bool UpdateClass(byte Code, string ClaseName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_UpdateClass @ClaseName ,@Code", connection))
            {
                command.Parameters.AddWithValue("@ClaseName", ClaseName);
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
        //done
        public static short GetClassID(string Name)
        {
            short code = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetClassID @Name", connection))
            {
                command.Parameters.AddWithValue("@Name", Name);
                try
                {
                    connection.Open();
                    object ID = command.ExecuteScalar();
                    if (ID != null && short.TryParse(ID.ToString(), out short result))
                        code = result;
                }
                catch (Exception)
                {
                }
            }
            return code;
        }
        //done
        public static string GetClassName(short ID)
        {
            string Name = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetClassName @ID", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    object nameObj = command.ExecuteScalar();
                    if (nameObj != null)
                        Name = nameObj.ToString();
                }
                catch (Exception)
                {
                }
            }
            return Name;
        }

    }
}
