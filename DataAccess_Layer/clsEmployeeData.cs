using System;
using System.Data.SqlClient;
using System.Data;

namespace MyDataAccessLayer
{
    public class clsEmployeeData
    {
        //done
        public static DataTable GetTeacherInfo()
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec Sp_GetTeacherInfo", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            data.Load(reader);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return data;
        }
        //done
        public static bool DeleteTeacher(int ID)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec Sp_DeleteTeacher @ID", connection))
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
        public static DataTable GetTeacherListInfo()
        {
            DataTable data = new DataTable();
           
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetTeacherListInfo", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            data.Load(reader);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return data;
        }
        //done
        public static DataTable GetTeacherListInfo(string Name)
        {
            DataTable data = new DataTable();
           
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetTeacherListInfoWithFilter @Name", connection))
            {
                command.Parameters.AddWithValue("@Name", Name + "%");

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            data.Load(reader);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return data;
        }
        //done
        public static bool AddTeacher(int ID, string name, string Qualification, string School, string CardNumber,
                                      string Email, string Phone, DateTime DateOfBirth, string Address, byte SocialStatus,
                                      string Image, bool Gendor, bool Period, float Salary, short ClassID, short LevelID)
        {
            bool isAdded = false;
            string query = @"exec SP_AddTeacher @ID  , @Name , @Qualification , @School 
                             , @PersonalCardNumber , @Email , @PhoneNumber , @DateOfBirth ,
                             @Address , @SocialStutas , @Image , @Gendor , @Period , @Salary , @ClassID , @LevelID ";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Qualification", string.IsNullOrEmpty(Qualification) ? (object)DBNull.Value : Qualification);
                command.Parameters.AddWithValue("@School", string.IsNullOrEmpty(School) ? (object)DBNull.Value : School);
                command.Parameters.AddWithValue("@PersonalCardNumber", string.IsNullOrEmpty(CardNumber) ? (object)DBNull.Value : CardNumber);
                command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                command.Parameters.AddWithValue("@PhoneNumber", Phone);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@SocialStutas", SocialStatus);
                command.Parameters.AddWithValue("@Image", string.IsNullOrEmpty(Image) ? (object)DBNull.Value : Image);
                command.Parameters.AddWithValue("@Gendor", Gendor);
                command.Parameters.AddWithValue("@Period", Period);
                command.Parameters.AddWithValue("@Salary", Salary);
                command.Parameters.AddWithValue("@ClassID", ClassID);
                command.Parameters.AddWithValue("@LevelID", LevelID);

                try
                {
                    connection.Open();
                    isAdded = command.ExecuteNonQuery() != 0;
                }
                catch (Exception)
                {
                    isAdded = false;
                }
            }

            return isAdded;
        }
        //done
        public static bool UpdateTeacher(int ID, string name, string Qualification, string School, string CardNumber,
                                         string Email, string Phone, DateTime DateOfBirth, string Address, byte SocialStatus,
                                         string Image, bool Gendor, bool Period, float Salary, short ClassID, short LevelID)
        {
            bool updated = false;
            string query = @"exec SP_UpdateTeacher @ID  , @Name , @Qualification , @School 
                        , @PersonalCardNumber , @Email , @PhoneNumber , @DateOfBirth ,
                        @Address , @SocialStutas , @Image , @Gendor , @Period , @Salary , @ClassID , @LevelID ";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Qualification", string.IsNullOrEmpty(Qualification) ? (object)DBNull.Value : Qualification);
                command.Parameters.AddWithValue("@School", string.IsNullOrEmpty(School) ? (object)DBNull.Value : School);
                command.Parameters.AddWithValue("@PersonalCardNumber", string.IsNullOrEmpty(CardNumber) ? (object)DBNull.Value : CardNumber);
                command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                command.Parameters.AddWithValue("@PhoneNumber", Phone);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@SocialStutas", SocialStatus);
                command.Parameters.AddWithValue("@Image", string.IsNullOrEmpty(Image) ? (object)DBNull.Value : Image);
                command.Parameters.AddWithValue("@Gendor", Gendor);
                command.Parameters.AddWithValue("@Period", Period);
                command.Parameters.AddWithValue("@Salary", Salary);
                command.Parameters.AddWithValue("@ClassID", ClassID);
                command.Parameters.AddWithValue("@LevelID", LevelID);

                try
                {
                    connection.Open();
                    updated = command.ExecuteNonQuery() != 0;
                }
                catch (Exception)
                {
                    updated = false;
                }
            }

            return updated;
        }
        //done
        public static bool FindByCode(int ID, ref string Name, ref string Qualification, ref string School, ref string CardNumber,
                                      ref string Email, ref string Phone, ref DateTime DateOfBirth, ref string Address, ref byte SocialStatus,
                                      ref string Image, ref bool Gendor, ref bool Period, ref float Salary, ref short ClassID, ref short LevelID)
        {
            bool find = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_FindTeacherByCode @ID", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Name = reader["Name"].ToString();
                            Qualification = reader["Qualification"].ToString();
                            School = reader["School"].ToString();
                            CardNumber = reader["PersonalCardNumber"]?.ToString();
                            Email = reader["Email"]?.ToString();
                            Phone = reader["PhoneNumber"].ToString();
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Address = reader["Address"].ToString();
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
                }
                catch (Exception)
                {
                    // Handle exception
                }
            }

            return find;
        }

        public static bool FindByName(ref string Name, ref int ID, ref string Qualification, ref string School, ref string CardNumber,
                                      ref string Email, ref string Phone, ref DateTime DateOfBirth, ref string Address, ref byte SocialStatus,
                                      ref string Image, ref bool Gendor, ref bool Period, ref float Salary, ref short ClassID, ref short LevelID)
        {
            bool find = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_FindTeacherByName @Name ", connection))
            {
                command.Parameters.AddWithValue("@Name", Name);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ID = Convert.ToInt16(reader["Code"]);
                            Name = reader["Name"].ToString();
                            Qualification = reader["Qualification"].ToString();
                            School = reader["School"].ToString();
                            CardNumber = reader["PersonalCardNumber"]?.ToString();
                            Email = reader["Email"]?.ToString();
                            Phone = reader["PhoneNumber"].ToString();
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Address = reader["Address"].ToString();
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
                }
                catch (Exception)
                {
                    // Handle exception
                }
            }

            return find;
        }
    }
       
    
}
