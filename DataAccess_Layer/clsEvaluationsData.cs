using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsEvaluationsData
    {
        public static DataTable GetEvaluationInfo(short classID)
        {

            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM DayEvaluation where ClassID = @classID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@classID", classID);


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

        public static DataTable GetWinnerHistory()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT ChildName,Date,Degree FROM WinnerKids order by Date desc";


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

        public static DataTable GetWinnerCard()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT ChildName,ClassName,Image,Gendor,Degree,Date FROM WinnerKids where month(Date) = month(getdate()) order by Degree desc";


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



        public static DataTable GetDayEvaluationInfo()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT Gendor, Code, Name,ClassID FROM KidsPersonalInfo";

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

        public static bool AddDayEvaluationInfo(string ChildID, string ChildName, short ClassID, bool Gendor)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "INSERT INTO DayEvaluation (ChildID ,ChildName ,Gendor  ,ClassID,Degree1 ,Degree2 ,Degree3 ,Degree4 ,Degree5 ,Degree6 ,Degree7 ,TotalDegrees ) " +
                           "VALUES" +
                           "(@ChildID ,@ChildName,@Gendor  ,@ClassID,@Degree1 ,@Degree2 ,@Degree3 ,@Degree4 ,@Degree5 ,@Degree6 ,@Degree7 ,@TotalDegrees)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ChildID", ChildID);
            command.Parameters.AddWithValue("@ChildName", ChildName);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@Degree1", false);
            command.Parameters.AddWithValue("@Degree2", false);
            command.Parameters.AddWithValue("@Degree3", false);
            command.Parameters.AddWithValue("@Degree4", false);
            command.Parameters.AddWithValue("@Degree5", false);
            command.Parameters.AddWithValue("@Degree6", false);
            command.Parameters.AddWithValue("@Degree7", false);
            command.Parameters.AddWithValue("@TotalDegrees", 0);


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

        public static bool UpdateDayEvaluationInfo(string ChildID, bool Degree1, bool Degree2, bool Degree3,
            bool Degree4, bool Degree5, bool Degree6, bool Degree7)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "UPDATE DayEvaluation  set Degree1 = @Degree1,Degree2 = @Degree2 ,Degree3 = @Degree3" +
                ",Degree4 = @Degree4,Degree5 = @Degree5,Degree6 = @Degree6 ,Degree7 =@Degree7 WHERE ChildID = @ChildID";

            SqlCommand command = new SqlCommand(query, connection);

            if (Degree1 != null)
                command.Parameters.AddWithValue("@Degree1", Degree1);

            command.Parameters.AddWithValue("@Degree2", Degree2);

            command.Parameters.AddWithValue("@Degree3", Degree3);

            command.Parameters.AddWithValue("@Degree4", Degree4);

            command.Parameters.AddWithValue("@Degree5", Degree5);

            command.Parameters.AddWithValue("@Degree6", Degree6);

            command.Parameters.AddWithValue("@Degree7", Degree7);

            command.Parameters.AddWithValue("@ChildID", ChildID);


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

        public static bool UpdateDayEvaluationData(string ChildID, string ChildName, short ClassID, bool Gendor)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "UPDATE DayEvaluation  set ChildName = @ChildName,ClassID = @ClassID ,Gendor = @Gendor WHERE ChildID = @ChildID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ChildName", ChildName);

            command.Parameters.AddWithValue("@ClassID", ClassID);

            command.Parameters.AddWithValue("@Gendor", Gendor);

            command.Parameters.AddWithValue("@ChildID", ChildID);


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

        public static bool UpdateDayEvaluationInfo(string ChildID, bool Degree1, bool Degree2, bool Degree3,
            bool Degree4, bool Degree5, bool Degree6, bool Degree7, byte TotalDegrees)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "UPDATE DayEvaluation  set Degree1 = @Degree1,Degree2 = @Degree2 ,Degree3 = @Degree3" +
                ",Degree4 = @Degree4,Degree5 = @Degree5,Degree6 = @Degree6 ,Degree7 =@Degree7,TotalDegrees = TotalDegrees+@TotalDegrees WHERE ChildID = @ChildID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Degree1", Degree1);

            command.Parameters.AddWithValue("@Degree2", Degree2);

            command.Parameters.AddWithValue("@Degree3", Degree3);

            command.Parameters.AddWithValue("@Degree4", Degree4);

            command.Parameters.AddWithValue("@Degree5", Degree5);

            command.Parameters.AddWithValue("@Degree6", Degree6);

            command.Parameters.AddWithValue("@Degree7", Degree7);

            if (TotalDegrees != null)
                command.Parameters.AddWithValue("@TotalDegrees", TotalDegrees);
            else
                command.Parameters.AddWithValue("@TotalDegrees", DBNull.Value);

            command.Parameters.AddWithValue("@ChildID", ChildID);


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

        public static bool ResetDayEvaluationInfo()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Update DayEvaluation set Degree1=0,Degree2=0,Degree3=0,Degree4=0,Degree5=0,Degree6=0,Degree7=0,TotalDegrees=0";

            SqlCommand command = new SqlCommand(query, connection);



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


        public static bool DeleteFromEvaluationTable(string Code)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "delete from DayEvaluation  where ChildID = @Code  ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Code", Code);

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

        public static bool TruncateWinnerHistory()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "truncate table WinnerKids";

            SqlCommand command = new SqlCommand(query, connection);


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

        public static bool UpdateEvaluationResults(string Code, byte degree)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "update KidsEvaluation set Degree += @degree where ChildID = cast(@Code as int) ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@degree", degree);
            command.Parameters.AddWithValue("@Code", Code);

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

        public static bool GetWinnerKids()

        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "insert  into WinnerKids select * from MonthlyWinner";

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

                throw;
            }
            finally { connection.Close(); }
            return success;
        }
    }
}
