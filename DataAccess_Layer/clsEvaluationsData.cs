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
    {//done
        public static DataTable GetEvaluationInfo(short classID)
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetEvaluationInfo @classID", connection))
            {
                command.Parameters.AddWithValue("@classID", classID);

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
                    // لا يتم رمي الاستثناء
                }
            }
            return datble;
        }

        //done
        public static DataTable GetWinnerHistory()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetWinnerHistory", connection))
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
                    // لا يتم رمي الاستثناء
                }
            }
            return datble;
        }

        //done
        public static DataTable GetWinnerCard()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_GetWinnerCard", connection))
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
                    // لا يتم رمي الاستثناء
                }
            }
            return datble;
        }

        //done
        public static bool UpdateDayEvaluationInfo(string ChildID, bool Degree1, bool Degree2, bool Degree3,
            bool Degree4, bool Degree5, bool Degree6, bool Degree7)
        {
            string query = @"exec SP_UpdateDayEvaluationInfo @ChildID, @Degree1, @Degree2, @Degree3, 
                     @Degree4, @Degree5, @Degree6, @Degree7";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Degree1", Degree1);
                command.Parameters.AddWithValue("@Degree2", Degree2);
                command.Parameters.AddWithValue("@Degree3", Degree3);
                command.Parameters.AddWithValue("@Degree4", Degree4);
                command.Parameters.AddWithValue("@Degree5", Degree5);
                command.Parameters.AddWithValue("@Degree6", Degree6);
                command.Parameters.AddWithValue("@Degree7", Degree7);
                command.Parameters.AddWithValue("@ChildID", ChildID);

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

        //done
        public static bool ResetDally()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_ResetDayEvaluationInfo", connection))
            {
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

        //done
        public static bool TruncateWinnerHistory()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_TruncateWinnerHistory", connection))
            {
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

        //done
        public static bool GetWinnerKids()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_SaveWinnerKids", connection))
            {
                bool success = false;
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() != 0)
                        success = true;
                }
                catch (Exception)
                {
                    // لا يتم رمي الاستثناء
                }
                return success;
            }
        }
    }
}
