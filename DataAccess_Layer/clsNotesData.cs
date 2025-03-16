using System;
using System.Data.SqlClient;
using System.Data;


namespace MyDataAccessLayer
{
    public class clsNotesData
    {
        public static bool AddNotes(int ID, string Note, char Kind, string Date)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("Exec SP_AddNotes @ID, @Note, @Kind, @Date", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Note", Note);
                    command.Parameters.AddWithValue("@Kind", Kind);
                    command.Parameters.AddWithValue("@Date", Date);

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
                    return success;
                }
            }
        }

        public static DataTable GetNotes(string ID, char Kind)
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("Exec SP_GetNotesFor @ID ,  @Kind ", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Kind", Kind);

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
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                    return datble;
                }
            }
        }

        public static DataTable GetAllNotesForKids(string NameToSearsh = "")
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
               
                using (SqlCommand command = new SqlCommand("Exec SP_GetAllNotesForKidsFor @NameToSearsh", connection))
                {
                    command.Parameters.AddWithValue("@NameToSearsh", NameToSearsh);
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
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return datble;
                }
            }
        }

        public static DataTable GetAllNotesForTeachers(string NameToSearsh = "")
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("Exec SP_GetAllNotesForTeachers @NameToSearsh", connection))

                {
                    command.Parameters.AddWithValue("@NameToSearsh", NameToSearsh);
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
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return datble;
                }
            }
        }

        public static DataTable GetAllNotesForWorkers(string NameToSearsh = "")
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                
                using (SqlCommand command = new SqlCommand("Exec SP_GetAllNotesForWorkers @NameToSearsh", connection))
                {
                    command.Parameters.AddWithValue("@NameToSearsh", NameToSearsh);
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
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return datble;
                }
            }
        }

        public static bool DeleteAllRecordsInTableNotes()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("TRUNCATE TABLE Notes", connection))
                {
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
                    return success;
                }
            }
        }
    }
}
