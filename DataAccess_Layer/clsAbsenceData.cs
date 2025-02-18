using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsAbsenceData
    {
        //----
        public static DataTable ReturnEnteredInfo(string query)
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
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
            }
            return datble;
        }

        //done
        public static DataTable ReturnKidsThatAbsenceMoreInThisMonth(byte DayOfAbsenceToNote)
        {
            DataTable datble = new DataTable();
            string date = DateTime.Now.ToString("MM-yyyy");

            string query = $@"exec SP_ReturnKidsThatAbsenceMoreInThisMonth @Month,@DayOfAbsenceToNote";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Month", date);
                command.Parameters.AddWithValue("@DayOfAbsenceToNote", DayOfAbsenceToNote);
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
            }
            return datble;
        }

        //done
        public static bool AddToEnterAndLeaveHistory( int ID, DateTime Date,short Late, char Kind)
        {
            string query = @"exec SP_AddToEnterAndLeaveHistory   @ID ,  @Date , @Time , @Late , @Kind , @Month ";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Time", Date.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@Late", Late);
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@Month", Date.ToString("MM-yyyy"));

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
        //done
        public static bool AddToLeaveHistory( int ID,DateTime Date,char Kind)
        {
            string query = @"SP_AddToLeaveHistory   @ID ,  @Date , @Time , @Kind , @Month ";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Time", Date.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@Month", Date.ToString("MM-yyyy"));

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
        //done
        public static bool ISThisMemberAlreadyRegister(string ID, DateTime Date, char Kind)
        {
            string query = "exec SP_ISThisMemberAlreadyRegister @ID ,@Date ,@Kind ";
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Kind", Kind);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //done
        public static bool ISThisMemberAlreadyRegisterLeave(string ID, DateTime Date, char Kind)
        {
            string query = "SP_ISThisMemberAlreadyRegisterLeave @ID ,@Date ,@Kind";
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Kind", Kind);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //done
        public static bool AddToAbsenceHistory( int ID, DateTime Date,char Kind)
        {
            string query = @"exec SP_AddToAbsenceHistory @ID,  @Date, @Kind, @Month";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@Month", Date.ToString("MM-yyyy"));

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
        //----
        public static DataTable GetAllMemberThatDontCameToday(string query)
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
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
            }
            return datble;
        }
        //done
        public static DataTable GetAbsenceHistoryData(char Kind)
        {
            DataTable datble = new DataTable();
            string query;
            if (Kind == 'C')
                query = "exec SP_GetAbsenceHistoryDataForKids";
            else if (Kind == 'T')
                query = "exec SP_GetAbsenceHistoryDataForTeachers";
            else
                query = "exec SP_GetAbsenceHistoryDataForWorkers";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
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

                }
            }
            return datble;
        }
        //done
        public static DataTable GetAbsenceHistoryDataBetweenTwoDates(char Kind, DateTime DateFrom, DateTime DateTo)
        {
            DataTable datble = new DataTable();
            string query;
            if (Kind == 'C')
                query = "exec SP_GetAbsenceHistoryDataForKidsBetweenTwoDates @DateFrom  ,@DateTo ";
            else if (Kind == 'T')
                query = "exec SP_GetAbsenceHistoryDataForTeachersBetweenTwoDates @DateFrom  ,@DateTo";
            else
                query = "exec SP_GetAbsenceHistoryDataForWorkersBetweenTowDates @DateFrom ,@DateTo ";


            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@DateFrom", DateFrom);
                command.Parameters.AddWithValue("@DateTo", DateTo);

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
            }
            return datble;
        }
        //done
        public static bool FindChild(int ID)
        {
            string query = "exec SP_AbsenceFindChild @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    object res = command.ExecuteScalar();
                    return res != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //done
        public static bool FindEmployee(int ID)
        {
            string query = "exec SP_AbsenceFindEmployee @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    object res = command.ExecuteScalar();
                    return res != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //done
        public static bool FindWorker(int ID)
        {
            string query = "exec SP_AbsenceFindWorker @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    object res = command.ExecuteScalar();
                    return res != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //done
        public static DataTable GetLeaveHistory(char Kind)
        {
            DataTable datble = new DataTable();
            string query;
            if (Kind == 'C')
                query = "SP_GetLeaveHistoryForKids";
            else if (Kind == 'T')
                query = "exec SP_GetLeaveHistoryForTeachers";
            else
                query = "exec SP_GetLeaveHistoryForWorker";


            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
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
            }
            return datble;
        }
        //done
        public static DataTable GetLeaveHistoryBetweenTowDates(char Kind, DateTime DateFrom, DateTime DateTo)
        {
            DataTable datble = new DataTable();
            string query;
            if (Kind == 'C')
                query = "exec SP_GetLeaveHistoryForKidsBetweenTowDates @DateFrom  ,@DateTo ";
            else if (Kind == 'T')
                query = "exec SP_GetLeaveHistoryForTeachersBetweenTowDates @DateFrom  ,@DateTo";
            else
                query = "exec SP_GetLeaveHistoryForWorkerBetweenTowDates @DateFrom ,@DateTo ";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@DateFrom", DateFrom);
                command.Parameters.AddWithValue("@DateTo", DateTo);
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
            }
            return datble;
        }
        //done
        public static DataTable GetEnterAndLeaveHistory(char Kind)
        {
            DataTable datble = new DataTable();
            string query;
            if (Kind == 'C') query = "EXEC SP_GetEnterHistoryForKids";
            else if (Kind == 'T') query = "EXEC SP_GetEnterHistoryForTeachers";
            else query = "exec SP_GetEnterHistoryForWorker";
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
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
                    throw;
                }
            }
            return datble;
        }
        //done
        public static DataTable GetEnterAndLeaveHistoryBetweenTowDates(char Kind, DateTime DateFrom, DateTime DateTo)
        {
            DataTable datble = new DataTable();
            string query;
            if (Kind == 'C') query = "EXEC SP_GetEnterHistoryForKidsBetweenTowDates @DateFrom  ,@DateTo ";
            else if (Kind == 'T') query = "EXEC SP_GetEnterHistoryForTeachersBetweenTowDates @DateFrom  ,@DateTo";
            else query = "exec SP_GetEnterHistoryForWorkerBetweenTowDates @DateFrom  ,@DateTo";
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DateFrom", DateFrom);
                command.Parameters.AddWithValue("@DateTo", DateTo);
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
            }
            return datble;
        }
        //done
        public static bool DeleteAllAbsence()
        {
            string query = "exec SP_DeleteAllAbsence";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
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
        //done
        public static bool DeleteAllEnterHistory()
        {
            string query = "exec SP_DeleteAllEnterHistory";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
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
        //done
        public static bool DeleteAllLeaveHistory()
        {
            string query = "exec SP_DeleteAllLeaveHistory";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
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
