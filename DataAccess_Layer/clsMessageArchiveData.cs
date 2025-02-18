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
    public class clsMessageArchiveData
    {
        public static bool AddToMessage_Archive(string Name,char Through,string MessageContant,char Kind)
        {
            // 1 = WhatsApp 2= SMS 3= Email
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "INSERT INTO MessageArchive(Name,DateTime,Through,MessageContant,Kind) VALUES (@Name,@Date,@Through,@MessageContant,@Kind)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Date", DateTime.Now);
            command.Parameters.AddWithValue("@Through", Through);
            command.Parameters.AddWithValue("@MessageContant", MessageContant);
            command.Parameters.AddWithValue("@Kind", Kind);


            bool success = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    success = true;
            }
            catch (Exception)
            {
                success = false;


            }
            finally { connection.Close(); }

            return success;
        }

        public static DataTable GetMessage_Archive(char Kind, string Name = "")
        {
            DataTable datble = new DataTable();
            string query;
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            if (Name == "")
                 query = "SELECT * from MessageArchive where Kind = @Kind";
            else
                query = $"SELECT * from MessageArchive where Kind = @Kind and Name Like '{Name}%'";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Kind", Kind);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    datble.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return datble;
        }

        public static bool DeleteAll()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "truncate table MessageArchive";

            SqlCommand command = new SqlCommand(query, connection);
           

            bool success = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    success = true;
            }
            catch (Exception)
            {
                success = false;


            }
            finally { connection.Close(); }

            return success;
        }


    }
}
