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
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "SELECT * FROM UsersData where UserName = @UserName and Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

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
                            found = true;
                        }
                    }
                }
            }
            return found;
        }

        public static bool FindFromComboBox(ref int ID, ref string Name, ref string UserName, ref string Password
            , ref string SecondPassword, ref int Pirrimsion, ref string JopName, ref string Image, ref bool Gendor)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "SELECT * FROM UsersData where cast(Code as nvarchar) + '-' +Name = @Name;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

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
                            found = true;
                        }
                    }
                }
            }
            return found;
        }

        public static bool Find(int Code, ref string Name, ref string UserName, ref string Password
            , ref string SecondPassword, ref int Pirrimsion, ref string JopName, ref string Image, ref bool Gendor)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "SELECT * FROM UsersData where Code = @Code;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);

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
            }
            return found;
        }

        public static bool AddUser(string Name, string UserName, string Password
            , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "Insert into UsersData (Name,UserName,Password,Temp,Pirrimsion,Image,Gendor,JopName)" +
                    " values (@Name,@UserName,@Password,@Temp,@Pirrimsion,@Image,@Gendor,@JopName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Temp", Temp);
                    command.Parameters.AddWithValue("@Pirrimsion", Pirrimsion);
                    command.Parameters.AddWithValue("@Image", Image != null ? Image : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@JopName", JopName);
                    command.Parameters.AddWithValue("@Gendor", Gendor);

                    connection.Open();
                    found = command.ExecuteNonQuery() != 0;
                }
            }
            return found;
        }

        public static bool UpdateUser(int Code, string Name, string UserName, string Password
            , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "Update UsersData " +
                    " set Name=@Name, UserName=@UserName, Password=@Password, Temp=@Temp, Pirrimsion=@Pirrimsion, Image=@Image, Gendor=@Gendor, JopName=@JopName " +
                    "where Code=@Code";
                using (SqlCommand command = new SqlCommand(query, connection))
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

                    connection.Open();
                    found = command.ExecuteNonQuery() != 0;
                }
            }
            return found;
        }

        public static bool IsUserNameExists(string UserName)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "select 1 from UsersData where UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    connection.Open();
                    found = command.ExecuteScalar() != null;
                }
            }
            return found;
        }

        public static bool IsUserNameAndPasswordExistsForThisID(string UserName, string Password, int ID)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "select 1 from UsersData where UserName = @UserName and Password = @Password and Code = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    found = command.ExecuteScalar() != null;
                }
            }
            return found;
        }

        public static DataTable GetUserInfo()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "SELECT Gendor, Code, Name, JopName FROM UsersData where JopName<>'Founder'";
                using (SqlCommand command = new SqlCommand(query, connection))
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
            }
            return table;
        }

        public static DataTable GetUserInfo(string Name)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = $"SELECT Gendor, Code, Name, JopName FROM UsersData where Name like '{Name}%' and JopName<>'Founder'";
                using (SqlCommand command = new SqlCommand(query, connection))
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
            }
            return table;
        }

        public static bool DeleteUser(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "delete from UsersData where Code=@ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    return command.ExecuteNonQuery() != 0;
                }
            }
        }
    }
}
