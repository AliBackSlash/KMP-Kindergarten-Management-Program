using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace MyDataAccessLayer
{
    public  class clsUsersData
    {
        public static bool Find(ref int ID, ref string Name, string UserName, string Password
 , ref string SecondPassword, ref int Pirrimsion, ref string JopName, ref string Image, ref bool Gendor)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_FindUserByUserNameAndPassword  @UserName , @Password", connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ID = (int)reader["Code"];
                                Name = (string)reader["Name"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                SecondPassword = (string)reader["Temp"];
                                Pirrimsion = (int)reader["Pirrimsion"];
                                Image = reader["Image"]?.ToString();
                                JopName = reader["JopName"]?.ToString();
                                Gendor = (bool)reader["Gendor"];
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool FindFromComboBox(ref int ID, ref string Name, ref string UserName, ref string Password
            , ref string SecondPassword, ref int Pirrimsion, ref string JopName, ref string Image, ref bool Gendor)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_FindFromComboBox  @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ID = (int)reader["Code"];
                                Name = (string)reader["Name"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                SecondPassword = (string)reader["Temp"];
                                Pirrimsion = (int)reader["Pirrimsion"];
                                Image = reader["Image"]?.ToString();
                                JopName = reader["JopName"]?.ToString();
                                Gendor = (bool)reader["Gendor"];
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool Find(int Code, ref string Name, ref string UserName, ref string Password
            , ref string SecondPassword, ref int Pirrimsion, ref string JopName, ref string Image, ref bool Gendor)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_FindUserByCode  @Code", connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Name = (string)reader["Name"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                SecondPassword = (string)reader["Temp"];
                                Pirrimsion = (int)reader["Pirrimsion"];
                                Image = reader["Image"]?.ToString();
                                JopName = reader["JopName"]?.ToString();
                                Gendor = (bool)reader["Gendor"];
                                found = true;
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return found;
        }

        public static bool AddUser(string Name, string UserName, string Password
            , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_AddNewUser  @Name ,@UserName ,@Password ,@Temp ,@Pirrimsion ,@Image ,@Gendor ,@JopName", connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Temp", Temp);
                    command.Parameters.AddWithValue("@Pirrimsion", Pirrimsion);
                    command.Parameters.AddWithValue("@Image", Image != null ? Image : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@JopName", JopName);
                    command.Parameters.AddWithValue("@Gendor", Gendor);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static bool UpdateUser(int Code, string Name, string UserName, string Password
            , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_UpdateUser @Code, @Name ,@UserName ,@Password ,@Temp ,@Pirrimsion ,@Image ,@Gendor ,@JopName", connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Temp", Temp);
                    command.Parameters.AddWithValue("@Pirrimsion", Pirrimsion);
                    command.Parameters.AddWithValue("@Image", string.IsNullOrEmpty(Image) ? (object)DBNull.Value : Image);
                    command.Parameters.AddWithValue("@JopName", JopName);
                    command.Parameters.AddWithValue("@Gendor", Gendor);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static bool IsUserNameExists(string UserName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_IsUserNameExists @UserName", connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        return command.ExecuteScalar() != null;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static bool IsUserNameAndPasswordExistsForThisID(string UserName, string Password, int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_IsUserNameAndPasswordExistsForThisID @UserName ,@Password ,@ID ", connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        return command.ExecuteScalar() != null;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static DataTable GetUserInfo()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_GetUserInfo", connection))
                {
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
                    }
                    catch
                    {
                        return table;
                    }
                }
            }
            return table;
        }

        public static DataTable GetUserInfo(string Name)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_GetUserInfoWithFilter @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

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
                    }
                    catch
                    {
                        return table;
                    }
                }
            }
            return table;
        }

        public static bool DeleteUser(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_DeleteUser @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
        //
    }
}
