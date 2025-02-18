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
        public static bool AddWorker(string Code,string name, string Phone, string CardNumber, bool Gender, string Image, float Salary, bool Period)
        {


            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"INSERT INTO WorkerInfo
                               (Code ,Name ,Phone ,PersonalCardNumber,Gendor,Image,Salary ,Period)
                             VALUES
                               (@Code,@Name,@Phone,@PersonalCardNumber,@Gendor,@Image,@Salary,@Period)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);

            command.Parameters.AddWithValue("@Name", name);

            if (CardNumber != "")
                command.Parameters.AddWithValue("@PersonalCardNumber", CardNumber);
            else
                command.Parameters.AddWithValue("@PersonalCardNumber", System.DBNull.Value);

            command.Parameters.AddWithValue("@Phone", Phone);     
            command.Parameters.AddWithValue("@Gendor", Gender);
            if (Image != null)
                command.Parameters.AddWithValue("@Image", Image);
            else
                command.Parameters.AddWithValue("@Image", System.DBNull.Value);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@Period", Period);

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
        public static bool UpdateWorkerInfo(string Code, string Name, string Phone, string PersonalCardNumber, bool Gendor, string Image, float Salary, bool Period)
        {


            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
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

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);

            command.Parameters.AddWithValue("@Name", Name);

            if (PersonalCardNumber != "")
                command.Parameters.AddWithValue("@PersonalCardNumber", PersonalCardNumber);
            else
                command.Parameters.AddWithValue("@PersonalCardNumber", System.DBNull.Value);

            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            if (Image != null   )
                command.Parameters.AddWithValue("@Image", Image);
            else
                command.Parameters.AddWithValue("@Image", System.DBNull.Value);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@Period", Period);

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

        public static bool FindByCode(string ID,ref string name, ref string Phone, ref string CardNumber, ref bool Gender, ref string Image, ref float Salary, ref bool Period)
        {
            string query = "Select * from WorkerInfo where Code = @ID";
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


                    };

                }


            }
            catch (Exception)
            {


            }
            return find;
        }
        public static bool FindByName(string Name, ref string ID, ref string Phone, ref string CardNumber, ref bool Gender, ref string Image, ref float Salary, ref bool Period)
        {
            string query = "Select * from WorkerInfo where Name = @Name";
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
                                Phone = (string)reader["Phone"];
                                CardNumber = reader["PersonalCardNumber"]?.ToString();
                                Gender = (bool)reader["Gendor"];
                                Image = reader["Image"]?.ToString();
                                Salary = Convert.ToSingle(reader["Salary"]);
                                Period = (bool)reader["Period"];
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

        public static bool DeleteWorker(int ID)
        {


            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "delete FROM WorkerInfo where Code = @ID";

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
        public static DataTable GetWorkerListInfo()
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"SELECT Gendor, Code, Name,case 
                              when Period = 1 then 'صباحي'
                              else 'مسائي'
                              end
                              as  Period,case 
                              when Gendor = 1 then 'عامل'
                              else 'عاملة'
                              end
                              as GendorName,Phone FROM WorkerInfo";

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
        public static DataTable GetWorkerListInfo(string Name)
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = $@"SELECT Gendor, Code, Name,case 
                               when Period = 1 then 'صباحي'
                               else 'مسائي'
                               end
                               as  Period,case 
                               when Gendor = 1 then 'عامل'
                               else 'عاملة'
                               end"+
                               $" as GendorName,Phone FROM WorkerInfo Where Name like\'{Name}%\'";

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
        public static DataTable GetWorkerInfo()
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM WorkerInfo";

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
        public static DataTable GetOneWorkerWithInfo(string Name)
        {
            DataTable data = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM WorkerInfo where Name = @Name";

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



    }
}
