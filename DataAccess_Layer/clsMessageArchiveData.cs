using System;
using System.Data.SqlClient;
using System.Data;

namespace MyDataAccessLayer
{
    public class clsMessageArchiveData
    {
        public static bool AddToMessage_Archive(string Name, char Through, string MessageContant, char Kind)
        {
            // 1 = WhatsApp 2= SMS 3= Email
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                string query = "";
                using (SqlCommand command = new SqlCommand("Exec SP_AddToMessage_Archive @Name,@Date,@Through,@MessageContant,@Kind", connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@Through", Through);
                    command.Parameters.AddWithValue("@MessageContant", MessageContant);
                    command.Parameters.AddWithValue("@Kind", Kind);

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

        public static DataTable GetMessage_Archive(char Kind, string Name = "")
        {
            DataTable datble = new DataTable();
            string query;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                if (Name == "")
                    query = "SELECT * from MessageArchive where Kind = @Kind";
                else
                    query = $"SELECT * from MessageArchive where Kind = @Kind and Name Like '{Name}%'";

                using (SqlCommand command = new SqlCommand("SP_GetMessage_Archive @Name ,@Kind", connection))
                {
                    command.Parameters.AddWithValue("@Kind", Kind);
                    command.Parameters.AddWithValue("@Name", Name);

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
                        return datble;
                    }
                    catch (Exception)
                    {
                       
                    }
                }
            }
            return null;
        }

        public static bool DeleteAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("truncate table MessageArchive", connection))
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
        }


    }
}
