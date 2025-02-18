using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsBrothersData
    {
        public static bool Add_Brothers(int ID, string Name, DateTime Date)

        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "INSERT INTO BrotherInfo(Name,DateOfBirth ,ChildID )VALUES(@Name,@Date,@ID);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@ID", ID);

            if (Name == "")
                return false;

            bool RowsEffected = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                    RowsEffected = true;
            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }


            return RowsEffected;
        }

        public static bool delete_BrotherswithName(string Name)

        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "delete from BrotherInfo where Name = @Name";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);

            int RowsEffected = 0;
            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }


            return (RowsEffected != 0);
        }

        public static bool delete_BrotherswithID(int ID)

        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "delete from BrotherInfo where ChildID = @ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            int RowsEffected = 0;
            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }


            return (RowsEffected != 0);
        }

        public static bool Update_Brothers(int ID, string Name, DateTime Date)

        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "UPDATE BrotherInfo   SET Name = @Name,DateOfBirth =  @Date  WHERE BrotherInfo.ID=@ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@ID", ID);

            if (Name == "")
                return false;

            int RowsEffected = 0;
            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }



            return (RowsEffected != 0);
        }

        public static DataTable GetChildBrothers(int ID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "SELECT * FROM BrotherInfo where ChildID =@ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            DataTable data = new DataTable();
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


            }
            finally { connection.Close(); }

            return data;
        }

        public static bool GetChildBrothers(int ID,ref string Name,ref DateTime dateOfBirth,ref int ChildID )
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "SELECT * FROM BrotherInfo where ID =@ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            bool found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Name = (string)reader["Name"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    ChildID = (int)reader["ChildID"];
                    found = true;
                }
                reader.Close();

            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }

            return found;
        }
    }
}
