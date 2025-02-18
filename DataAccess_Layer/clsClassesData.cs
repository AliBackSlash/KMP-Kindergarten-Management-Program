using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsClassesData
    {
        public static DataTable GetClassesInfo()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = " select  (select Count(0) from KidsPersonalInfo where ClassID=Clases.Code)as TotalKids, Clases.Code,Clases.Class,TeachersInfo.Name from Clases " +
                           "left join TeachersInfo on TeachersInfo.ClassID=Clases.Code";

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

        public static bool DeleteAllClasses()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "truncate table Clases";

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

        public static bool DeleteClasseWithID(byte ID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Delete  Clases where Code = @ID";

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

        public static bool AddClass(string ClaseName)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "insert into Clases (Class) " +
                "values (@ClaseName)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClaseName", ClaseName);

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

        public static bool UpdateClass(byte Code, string ClaseName)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "update Clases set Class = @ClaseName  where code = @Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClaseName", ClaseName);
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

    }
}
