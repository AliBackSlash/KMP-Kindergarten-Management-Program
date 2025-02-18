using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsNotesData
    {
        public static bool AddNotes(int ID, string Note, char Kind, string Date)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "INSERT INTO Notes ( ID, Note, Kind, Date)" +
                           " VALUES " +
                           "( @ID, @Note, @Kind, @Date)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Note", Note);
            command.Parameters.AddWithValue("@Kind", Kind);
            command.Parameters.AddWithValue("@Date", Date);


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

        public static DataTable GetNotes(string ID, char Kind)
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT Note,Date FROM  Notes " +
                           "where ID = @ID and Kind=@Kind";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
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

        public static DataTable GetAllNotesForKids(string NameToSearsh = "")
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query;

            if (NameToSearsh != "")
                query = "select KidsPersonalInfo.Name , Notes.Date,Notes.Kind,Notes.Note from Notes inner join " +
                           $"KidsPersonalInfo on Notes.ID=KidsPersonalInfo.Code where KidsPersonalInfo.Name like '{NameToSearsh}%'";
            else
                query = "select KidsPersonalInfo.Name , Notes.Date,Notes.Kind,Notes.Note from Notes inner " +
                           "join KidsPersonalInfo on Notes.ID=KidsPersonalInfo.Code";

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

        public static DataTable GetAllNotesForTeachers(string NameToSearsh = "")
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query;


            if (NameToSearsh != "")
                query = "select TeachersInfo.Name , Notes.Date,Notes.Kind,Notes.Note from Notes inner join " +
                           $"TeachersInfo on Notes.ID=TeachersInfo.Code where TeachersInfo.Name like '{NameToSearsh}%'";
            else
                query = "select TeachersInfo.Name , Notes.Date,Notes.Kind,Notes.Note from Notes inner " +
                           "join TeachersInfo on Notes.ID=TeachersInfo.Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NameToSearsh", NameToSearsh);

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

        public static DataTable GetAllNotesForWorkers(string NameToSearsh = "")
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query;


            if (NameToSearsh != "")
                query = "select WorkerInfo.Name , Notes.Date,Notes.Kind,Notes.Note from Notes inner join " +
                           $"WorkerInfo on Notes.ID=WorkerInfo.Code where WorkerInfo.Name like '{NameToSearsh}%'";
            else
                query = "select WorkerInfo.Name , Notes.Date,Notes.Kind,Notes.Note from Notes inner " +
                           "join WorkerInfo on Notes.ID=WorkerInfo.Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NameToSearsh", NameToSearsh);

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


        public static bool DeleteAllRecordsInTableNotes()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "truncate table Notes";

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
    }
}
