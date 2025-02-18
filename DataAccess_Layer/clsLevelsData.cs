using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsLevelsData
    {
        public static bool AddLevel(string LevelName, string Contant)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "insert into Levels (Level,LevelContant) " +
                "values (@LevelName,@Contant)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LevelName", LevelName);
            command.Parameters.AddWithValue("@Contant", Contant);

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

        public static bool UpdateLevel(byte Code, string LevelName, string Contant)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "update Levels set Level = @LevelName , LevelContant = @Contant where code = @Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LevelName", LevelName);
            command.Parameters.AddWithValue("@Contant", Contant);
            command.Parameters.AddWithValue("@Code", Code);


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

        public static DataTable GetLevels()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT(select Count(0) from KidsPersonalInfo where LevelID=Levels.Code) as TotalKids, * from Levels";

            SqlCommand command = new SqlCommand(query, connection);



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

        public static bool DeleteAllLevels()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "truncate table Levels";

            SqlCommand command = new SqlCommand(query, connection);



            bool success = false;
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null)
                    success = true;
            }
            catch (Exception)
            {
                success = false;


            }
            finally { connection.Close(); }

            return success;
        }

        public static bool DeleteLevelWithID(byte ID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Delete  Levels where Code = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);


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
