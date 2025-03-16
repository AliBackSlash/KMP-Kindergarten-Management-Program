using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsBrothersData
    {
        //done
        public static bool Add_Brothers(int ID, string Name, DateTime Date)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("exec SP_Add_Brothers  @ID ,  @Name ,  @Date ", connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@ID", ID);

                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                           
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        //done
        public static bool delete_BrotherswithChildID(int ID,string Name)
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("exec SP_Delete_BrotherswithChildID @ID,@Name ", connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@Name", Name);

                        connection.Open();
                        return command.ExecuteNonQuery()!=0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        //done
        public static bool Update_Brothers(int ID, string Name, DateTime Date)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("exec SP_Update_Brother @ID,@Name,@Date", connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@ID", ID);

                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        //done
        public static DataTable GetChildBrothers(int ID)
        {
            DataTable data = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("exec SP_GetChildBrothers @ID", connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                data.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // التعامل مع الاستثناء أو تسجيله
            }

            return data;
        }
        //done
        public static bool GetBrotherInfo(int ID, ref string Name, ref DateTime dateOfBirth, ref int ChildID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("exec SP_GetBrotherInfo @ID", connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Name = (string)reader["Name"];
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                                ChildID = (int)reader["ChildID"];
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;

        }


       
    }
}
