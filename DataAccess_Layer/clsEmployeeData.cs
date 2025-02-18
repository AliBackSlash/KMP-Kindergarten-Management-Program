using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Security.Policy;
using System.Xml.Linq;

namespace MyDataAccessLayer
{
    public class clsEmployeeData
    {
        public static DataTable GetTeacherInfo()
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM TeachersInfo";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return data;
        }
        public static bool DeleteTeatcher(int ID)
        {


            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "delete FROM TeachersInfo where Code = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            bool deleted = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    deleted = true;
            }
            catch (Exception)
            {
                deleted = false;

            }
            finally { connection.Close(); }
            return deleted;
        }
        public static DataTable GetTeacherListInfo()
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"SELECT Gendor, Code, Name, Address, Qualification, DateOfBirth, LevelID, ClassID,
                             case 
                             when Period = 1 then 'صباحي'
                             else 'مسائي'
                             end
                             as Period,
                             case 
                             when Gendor = 1 then 'معلم'
                             else 'معلمة'
                             end
                             as GendorName ,PhoneNumber FROM TeachersInfo";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return data;
        }
        public static DataTable GetTeacherListInfo(string Name)
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"SELECT Gendor, Code, Name, Address, Qualification, DateOfBirth, LevelID, ClassID,
                              case 
                              when Period = 1 then 'صباحي'
                              else 'مسائي'
                              end
                              as Period,
                              case 
                              when Gendor = 1 then 'معلم'
                              else 'معلمة'
                              end"+
                             $" as GendorName ,PhoneNumber FROM TeachersInfo where Name like \'{Name}%\'";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return data;
        }
        public static DataTable GetOneTeacherWithInfo(string Name)
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM TeachersInfo where Name = @Name";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return data;
        }           
        public static DataTable GetNameFromTables(string TableName)
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT Name FROM @TableName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TableName", TableName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return data;
        }  
        //new
        public static bool AddTeacher(string ID, string name, string Qulification, string School, string CardNumber
                              , string Email, string Phone, DateTime DateOfBirth, string Address, byte SocialStatus,
            string Image, bool Gendor, bool Period, float Salary, short ClassID, short LevelID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"INSERT INTO TeachersInfo
                                 (Code,Name,Qualification,School,PersonalCardNumber,Email,PhoneNumber,DateOfBirth,
                                  Address,SocialStutas,Image,Gendor,Period,Salary,ClassID,LevelID )
                            VALUES
                                  (@ID,@Name,@Qualification,@School,@PersonalCardNumber,@Email,@PhoneNumber,@DateOfBirth
                                   ,@Address,@SocialStutas,@Image,@Gendor,@Period,@Salary,@ClassID,@LevelID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            command.Parameters.AddWithValue("@Name", name);
            if (Qulification != "")
                command.Parameters.AddWithValue("@Qualification", Qulification);
            else
                command.Parameters.AddWithValue("@Qualification", System.DBNull.Value);

            if (School != "")
                command.Parameters.AddWithValue("@School", School);
            else
                command.Parameters.AddWithValue("@School", DBNull.Value);
            if (CardNumber != "")
                command.Parameters.AddWithValue("@PersonalCardNumber", CardNumber);
            else
                command.Parameters.AddWithValue("@PersonalCardNumber", DBNull.Value);

            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@PhoneNumber", Phone);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@SocialStutas", SocialStatus);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@LevelID", LevelID);

            if (Image != null)
                command.Parameters.AddWithValue("@Image", Image);
            else
                command.Parameters.AddWithValue("@Image", DBNull.Value);

            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Period", Period);
            command.Parameters.AddWithValue("@Salary", Salary);


            bool isAdded = false;

            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    isAdded = true;

            }
            catch (Exception)
            {

                isAdded = false;
            }
            finally { connection.Close(); }


            return isAdded;
        }
        //new
        public static bool UpdateTeacher(string OldID,string NewID, string name, string Qulification, string School, string CardNumber
                              , string Email, string Phone, DateTime DateOfBirth, string Address, byte SocialStatus,
            string Image, bool Gendor, bool Period, float Salary, short ClassID, short LevelID)

        {


            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"UPDATE TeachersInfo
                                SET Code =@NewID
                                  ,Name = @Name
                                  ,Qualification =@Qualification        
                                  ,School =@School 
                                  ,PersonalCardNumber = @PersonalCardNumber
                                  ,Email = @Email
                                  ,PhoneNumber = @PhoneNumber
                                  ,DateOfBirth = @DateOfBirth
                                  ,Address = @Address
                                  ,SocialStutas = @SocialStutas
                                  ,Image = @Image
                                  ,LevelID = @LevelID
                                  ,ClassID = @ClassID
                                  ,Gendor = @Gendor
                                  ,Period = @Period
                                  ,Salary = @Salary
                             WHERE Code = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", OldID);

            command.Parameters.AddWithValue("@NewID", NewID);

            command.Parameters.AddWithValue("@Name", name);
            if (Qulification != "")
                command.Parameters.AddWithValue("@Qualification", Qulification);
            else
                command.Parameters.AddWithValue("@Qualification", System.DBNull.Value);

            if (School != "")
                command.Parameters.AddWithValue("@School", School);
            else
                command.Parameters.AddWithValue("@School", DBNull.Value);
            if (CardNumber != "")
                command.Parameters.AddWithValue("@PersonalCardNumber", CardNumber);
            else
                command.Parameters.AddWithValue("@PersonalCardNumber", DBNull.Value);

            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@PhoneNumber", Phone);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@SocialStutas", SocialStatus);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@LevelID", LevelID);

            if (Image != null)
                command.Parameters.AddWithValue("@Image", Image);
            else
                command.Parameters.AddWithValue("@Image", DBNull.Value);

            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Period", Period);
            command.Parameters.AddWithValue("@Salary", Salary);



            bool deleted = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    deleted = true;
            }
            catch (Exception)
            {
                deleted = false;

            }
            finally { connection.Close(); }
            return deleted;
        }

        public static bool FindByCode(string ID,ref string Name,ref string Qulification,ref string School,ref string CardNumber
                               ,ref string Email,ref string Phone,ref DateTime DateOfBirth,ref string Address,ref byte SocialStatus,
                               ref string Image,ref bool Gendor,ref bool Period,ref float Salary,ref short ClassID,ref short LevelID)
        {
            string query = "Select * from TeachersInfo where Code = @ID";
            bool find = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);

                        
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Name = (string)reader["Name"];
                                Qulification = (string)reader["Qualification"];
                                School = (string)reader["School"];
                                CardNumber = reader["PersonalCardNumber"]?.ToString();
                                Email = reader["Email"]?.ToString();
                                Phone = (string)reader["PhoneNumber"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Address = (string)reader["Address"];
                                SocialStatus = Convert.ToByte(reader["SocialStutas"]);
                                Image = reader["Image"]?.ToString();
                                Gendor = (bool)reader["Gendor"];
                                Period = (bool)reader["Period"];
                                Salary = Convert.ToSingle(reader["Salary"]);
                                ClassID = Convert.ToInt16(reader["ClassID"] );
                                LevelID = Convert.ToInt16(reader["LevelID"]);
                                find = true;
                            }
                        }


                    };

                }


            }
            catch (Exception)
            {


            }
            return find;
        }
        public static bool FindByName(string Name, ref string ID, ref string Qulification, ref string School, ref string CardNumber
                             , ref string Email, ref string Phone, ref DateTime DateOfBirth, ref string Address, ref byte SocialStatus,
                             ref string Image, ref bool Gendor, ref bool Period, ref float Salary, ref short ClassID, ref short LevelID)
        {
            string query = "Select * from TeachersInfo where Name = @Name";
            bool find = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);


                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ID = (string)reader["Code"];
                                Qulification = (string)reader["Qualification"];
                                School = (string)reader["School"];
                                CardNumber = reader["PersonalCardNumber"]?.ToString();
                                Email = reader["Email"]?.ToString();
                                Phone = (string)reader["PhoneNumber"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Address = (string)reader["Address"];
                                SocialStatus = Convert.ToByte(reader["SocialStutas"]);
                                Image = reader["Image"]?.ToString();
                                Gendor = (bool)reader["Gendor"];
                                Period = (bool)reader["Period"];
                                Salary = Convert.ToSingle(reader["Salary"]);
                                ClassID = Convert.ToInt16(reader["ClassID"]);
                                LevelID = Convert.ToInt16(reader["LevelID"]);
                                find = true;
                            }
                        }


                    };

                }


            }
            catch (Exception)
            {


            }
            return find;
        }
    }
       
    
}
