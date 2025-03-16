using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsTreasuryData
    {
        public static DataTable GetMonthlyData(string Day = "")
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GetMonthlyData @Day", connection))
            {
                command.Parameters.AddWithValue("@Day", Day);
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static DataTable GetMonthlyDataOrder(char Trunsaction, string Day = "")
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GetMonthlyDataWithFilter @Trunsaction ,@Day", connection))
            {
                command.Parameters.AddWithValue("@Day", Day);
                command.Parameters.AddWithValue("@Trunsaction", Trunsaction);

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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static bool AddToTreasuryMonthlyData(float Amount, char Kind, bool Trunsaction, int UserID, int MemberID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_AddToTreasuryMonthlyData @Amount ,@Kind ,@Trunsaction ,@UserID  ,@MemberID\r\n", connection))
            {
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static DataTable GetYearlyData(string Month = "")
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("EXEC SP_GetYearlyData @Month", connection))
            {
                command.Parameters.AddWithValue("@Month", Month);
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static DataTable GetYearlyData(string Month, string Day, char Trunsaction = '\0')
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GetYearlyDataWithFilter @Month ,@Day ,@Trunsaction", connection))
            {
                command.Parameters.AddWithValue("@Month", Month);
                command.Parameters.AddWithValue("@Day", Day);
                command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static DataTable GetYearlyDataOrderForMonth(string Month, char Trunsaction = '\0')
        {
            DataTable datble = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GetYearlyDataOrderForMonth @Month ,@Trunsaction", connection))
            {
                command.Parameters.AddWithValue("@Month", Month);
                command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static DataTable GetYearlyDataOrder(char Trunsaction)
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GGetYearlyDataOrder @Trunsaction ", connection))
            {
                command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static DataTable GetYearlyDataOrder(char Trunsaction, string Month, string Day)
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GGetYearlyDataOrder2 @Trunsaction ,@Month , @Day", connection))
            {
                command.Parameters.AddWithValue("@Month", Month);
                command.Parameters.AddWithValue("@Day", Day);
                command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static bool AddToTreasuryYearlyData(float Amount, char Kind, bool Trunsaction, int UserID, int MemberID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_AddToTreasuryYearlyData @Amount ,@Kind ,@Trunsaction ,@UserID  ,@MemberID", connection))
            {
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static bool MoveMonthlyToYearlyTreasury()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_MoveMonthlyToYearlyTreasury ", connection))
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

        public static bool SaveTreasuryHistoryData()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_SaveTreasuryHistoryData", connection))
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

        public static DataTable GetCurrentMonthes()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GetCurrentMonthes", connection))
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static DataTable GetHistory()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("Exec SP_GetTrusearyHistory", connection))
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
                    // Exception handling - returning empty DataTable
                }
            }
            return datble;
        }

        public static bool ClearHistory()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("truncate table TreasuryHistory;", connection))
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

        public static bool ClearYearlyData()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("truncate table TreasuryYearlyData;", connection))
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
