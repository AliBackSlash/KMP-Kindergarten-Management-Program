using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsRegistersAndOperationsData
    {
        public static bool AddRegister(int Code,string UserName, DateTime Date,bool IsEnter)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"INSERT INTO Registers (Code,UserName,Date,IsEnter)  VALUES (@Code,@UserName,@Date,@IsEnter) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@IsEnter", IsEnter);

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

        public static DataTable GetAllRegisters(string UserName = "")
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

            string query ;

            if(UserName!="")
                query = $"SELECT Code, UserName, Date,case when IsEnter = 1 then 'دخول' else 'خروج'end as Status FROM Registers where UserName like '{UserName}%' order by Date desc";
            else
                query = "SELECT Code, UserName, Date,case when IsEnter = 1 then 'دخول' else 'خروج'end as Status FROM   Registers order by Date desc";

            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();

            }
            catch (Exception)
            {

                //Throw;
            }
            finally { Connection.Close(); }

            return table;
        }

        public static DataTable GetAllRegisters(DateTime DateFrom,DateTime DateTo)
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = @"SELECT Code, UserName, Date,case when IsEnter = 1 then 'دخول' else 'خروج'end as Status FROM 
                  Registers where Date between @DateFrom and @DateTo order by Date desc";


            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@DateFrom", DateFrom);
            command.Parameters.AddWithValue("@DateTo", DateTo);
            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();

            }
            catch (Exception)
            {

                //Throw;
            }
            finally { Connection.Close(); }

            return table;
        }
        public static bool DeleteAllRegisters()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"delete Registers";

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
