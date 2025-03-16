using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsGenericData
    {
        public static DataTable FillComboBoxWithNames(string query)
        {

            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);


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

        public static DataTable ReturnGroupOfDataIWant(string query)
        {

            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);


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

        public static bool DeleteTableData(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            SqlCommand command = new SqlCommand(query, connection);

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
     
        public static bool UpdateDateOfOpen(string Column, string date)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = $"update DateOpen set {Column} = @date";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@date", date);

            bool Saccess = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    Saccess = true;
            }
            catch (Exception)
            {
                Saccess = false;
            }
            finally { connection.Close(); }

            return Saccess;
        }

        public static string ReturnLastDateOfOpen(string query)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);


            SqlCommand command = new SqlCommand(query, connection);

            string date = "";
            bool Saccess = false;
            try
            {
                connection.Open();
                object date1 = command.ExecuteScalar();
                if (date1 != null)
                    date = date1.ToString();
            }
            catch (Exception)
            {
                Saccess = false;
            }
            finally { connection.Close(); }

            return date;
        }

        public static string ReturnLastValueIWant(string query)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);


            SqlCommand command = new SqlCommand(query, connection);

            string date = "";
            try
            {
                connection.Open();
                object date1 = command.ExecuteScalar();
                if (date1 != null)
                    date = date1.ToString();
            }
            catch (Exception)
            {

            }
            finally { connection.Close(); }

            return date;
        }

        public static int ReturnLastValueIWantINT(string query)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);


            SqlCommand command = new SqlCommand(query, connection);

            int date = 0;
            try
            {
                connection.Open();
                object date1 = command.ExecuteScalar();
                if (date1 != null)
                    date = Convert.ToInt32(date1);
            }
            catch (Exception)
            {

            }
            finally { connection.Close(); }

            return date;
        }

        public static string ReturnLastID(string query)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);


            SqlCommand command = new SqlCommand(query, connection);

            string date = "";
            bool Saccess = false;
            try
            {
                connection.Open();
                object date1 = command.ExecuteScalar();
                if (date1 != null)
                    date = date1.ToString();
            }
            catch (Exception)
            {
                Saccess = false;
            }
            finally { connection.Close(); }

            return date;
        }
    }
}
