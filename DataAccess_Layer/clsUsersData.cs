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
           , ref string SecondPassword, ref int Pirrimsion,ref string JopName, ref string Image,ref bool Gendor)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM UsersData where UserName = @UserName and Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            bool found = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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
                reader.Close();
            }
            catch (Exception ex)
            {
                found = false;

            }
            finally { connection.Close(); }

            return found;
        }
         public static bool FindFromComboBox(ref int ID, ref string Name,ref string UserName,ref string Password
           , ref string SecondPassword, ref int Pirrimsion,ref string JopName, ref string Image, ref bool Gendor)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM UsersData where cast(Code as nvarchar) + '-' +Name = @Name;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            bool found = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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
                reader.Close();
            }
            catch (Exception ex)
            {
                found = false;

            }
            finally { connection.Close(); }

            return found;
        }

        public static bool Find(int Code,ref string Name, ref string UserName, ref string Password
         , ref string SecondPassword, ref int Pirrimsion,ref string JopName, ref string Image, ref bool Gendor)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM UsersData where Code = @Code;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);
            bool found = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Code = (int)reader["Code"];
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
                reader.Close();
            }
            catch (Exception ex)
            {
                found = false;

            }
            finally { connection.Close(); }

            return found;
        }

        public static bool AddUser(string Name, string UserName, string Password
            , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Insert into  UsersData (Name,UserName,Password,Temp,Pirrimsion,Image,Gendor,JopName)" +
                " values (@Name,@UserName,@Password,@Temp,@Pirrimsion,@Image,@Gendor,@JopName)";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Temp", Temp);
            command.Parameters.AddWithValue("@Pirrimsion", Pirrimsion);
            if (Image != null)
                command.Parameters.AddWithValue("@Image", Image);
            else
                command.Parameters.AddWithValue("@Image", DBNull.Value);

            command.Parameters.AddWithValue("@JopName", JopName);
            command.Parameters.AddWithValue("@Gendor", Gendor);



            bool found = false;

            try
            {
                connection.Open();

                if (command.ExecuteNonQuery() != 0)
                    found = true;

            }
            catch (Exception ex)
            {
                found = false;

            }
            finally { connection.Close(); }

            return found;
        }

        public static bool UpdateUser(int Code, string Name, string UserName, string Password
           , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Update UsersData " +
                " set Name=@Name, UserName=@UserName , Password =@Password, Temp =@Temp, Pirrimsion =@Pirrimsion,Image =@Image,Gendor =@Gendor,JopName =@JopName " +
                "where Code=@Code";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Code", Code);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Temp", Temp);
            command.Parameters.AddWithValue("@Pirrimsion", Pirrimsion);
            if (Image != "")
                command.Parameters.AddWithValue("@Image", Image);
            else
                command.Parameters.AddWithValue("@Image", DBNull.Value);
            command.Parameters.AddWithValue("@JopName", JopName);
            command.Parameters.AddWithValue("@Gendor", Gendor);



            bool found = false;

            try
            {
                connection.Open();

                if (command.ExecuteNonQuery() != 0)
                    found = true;

            }
            catch (Exception ex)
            {
                found = false;

            }
            finally { connection.Close(); }

            return found;
        }



        public static bool IsUserNameExists(string UserName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "select 1 from UsersData where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

           
            command.Parameters.AddWithValue("@UserName", UserName);
           
            bool found = false;

            try
            {
                connection.Open();

                if (command.ExecuteScalar() != null)
                    found = true;

            }
            catch (Exception ex)
            {
                found = false;

            }
            finally { connection.Close(); }

            return found;
        }

        public static bool IsUserNameAndPasswordExistsForThisID(string UserName,string Password,int ID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "select 1 from UsersData where UserName = @UserName and Password = @Password and Code = @ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@ID", ID);

            bool found = false;

            try
            {
                connection.Open();

                if (command.ExecuteScalar() != null)
                    found = true;

            }
            catch (Exception ex)
            {
                found = false;

            }
            finally { connection.Close(); }

            return found;
        } 
        public static DataTable GetUserInfo()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "SELECT Gendor, Code, Name, JopName FROM  UsersData where JopName<>'Founder'";

            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();

            }
            catch (Exception)
            {

                //Throw;
            }
            finally { Connection.Close(); }

            return table;
        }

        public static DataTable GetUserInfo(string Name)
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = $"SELECT Gendor, Code, Name, JopName FROM  UsersData where Name like '{Name}%' and JopName<>'Founder' ";

            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();

            }
            catch (Exception)
            {

                //Throw;
            }
            finally { Connection.Close(); }

            return table;
        }

        public static bool DeleteUser(int ID)

        {


            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "delete from UsersData where Code=@ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            int RowsEffected = 0;
            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }


            return (RowsEffected != 0);
        }
    }
}
