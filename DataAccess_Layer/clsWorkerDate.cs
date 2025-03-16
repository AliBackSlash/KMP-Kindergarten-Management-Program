using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyDataAccessLayer
{
    public class clsWorkerDate
    {

        //new
        public static bool AddWorker(int Code, string name, string Phone, string CardNumber, bool Gender, string Image, float Salary, bool Period)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = @"INSERT INTO WorkerInfo
                        (Code ,Name ,Phone ,PersonalCardNumber,Gendor,Image,Salary ,Period)
                      VALUES
                        (@Code,@Name,@Phone,@PersonalCardNumber,@Gendor,@Image,@Salary,@Period)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@PersonalCardNumber", string.IsNullOrEmpty(CardNumber) ? (object)DBNull.Value : CardNumber);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Gendor", Gender);
                    command.Parameters.AddWithValue("@Image", string.IsNullOrEmpty(Image) ? (object)DBNull.Value : Image);
                    command.Parameters.AddWithValue("@Salary", Salary);
                    command.Parameters.AddWithValue("@Period", Period);

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

        public static bool UpdateWorkerInfo(int Code, string Name, string Phone, string PersonalCardNumber, bool Gendor, string Image, float Salary, bool Period)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = @"UPDATE WorkerInfo
                      SET Code = @Code
                         ,Name = @Name
                         ,Phone = @Phone
                         ,PersonalCardNumber = @PersonalCardNumber
                         ,Gendor = @Gendor
                         ,Image = @Image
                         ,Salary = @Salary
                         ,Period = @Period
                      WHERE Code = @Code";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@PersonalCardNumber", string.IsNullOrEmpty(PersonalCardNumber) ? (object)DBNull.Value : PersonalCardNumber);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Image", string.IsNullOrEmpty(Image) ? (object)DBNull.Value : Image);
                    command.Parameters.AddWithValue("@Salary", Salary);
                    command.Parameters.AddWithValue("@Period", Period);

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

        public static bool FindByCode(int ID, ref string name, ref string Phone, ref string CardNumber, ref bool Gender, ref string Image, ref float Salary, ref bool Period)
        {
            string query = "Select * from WorkerInfo where Code = @ID";
            bool find = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                name = (string)reader["Name"];
                                Phone = (string)reader["Phone"];
                                CardNumber = reader["PersonalCardNumber"]?.ToString();
                                Gender = (bool)reader["Gendor"];
                                Image = reader["Image"]?.ToString();
                                Salary = Convert.ToSingle(reader["Salary"]);
                                Period = (bool)reader["Period"];
                                find = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // يمكنك إضافة تسجيل للخطأ هنا إذا لزم الأمر
                    }
                }
            }
            return find;
        }

        public static bool FindByName(ref string Name, ref int ID, ref string Phone, ref string CardNumber, ref bool Gender, ref string Image, ref float Salary, ref bool Period)
        {
            string query = "Select * from WorkerInfo where cast(Code as varchar) +'-'+Name = @Name";
            bool find = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ID = Convert.ToInt16(reader["Code"]);
                                Name = reader["Name"].ToString();
                                Phone = (string)reader["Phone"];
                                CardNumber = reader["PersonalCardNumber"]?.ToString();
                                Gender = (bool)reader["Gendor"];
                                Image = reader["Image"]?.ToString();
                                Salary = Convert.ToSingle(reader["Salary"]);
                                Period = (bool)reader["Period"];
                                find = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // يمكنك إضافة تسجيل للخطأ هنا إذا لزم الأمر
                    }
                }
            }
            return find;
        }

        public static bool DeleteWorker(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "delete FROM WorkerInfo where Code = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
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
        }

        public static DataTable GetWorkerListInfo()
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = @"SELECT Gendor, Code, Name,case 
                       when Period = 1 then 'صباحي'
                       else 'مسائي'
                       end
                       as  Period,case 
                       when Gendor = 1 then 'عامل'
                       else 'عاملة'
                       end
                       as GendorName,Phone FROM WorkerInfo";

                using (SqlCommand command = new SqlCommand(query, connection))
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
            }
            return data;
        }

        public static DataTable GetWorkerListInfo(string Name)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = $@"SELECT Gendor, Code, Name,case 
                        when Period = 1 then 'صباحي'
                        else 'مسائي'
                        end
                        as  Period,case 
                        when Gendor = 1 then 'عامل'
                        else 'عاملة'
                        end
                        as GendorName,Phone FROM WorkerInfo Where Name like @Name+'%'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

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
            }
            return data;
        }

        public static DataTable GetWorkerInfo()
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "SELECT * FROM WorkerInfo";

                using (SqlCommand command = new SqlCommand(query, connection))
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
            }
            return data;
        }

        public static DataTable GetOneWorkerWithInfo(string Name)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "SELECT * FROM WorkerInfo where Name = @Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

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
            }
            return data;
        }
    }
}
