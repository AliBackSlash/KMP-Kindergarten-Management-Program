using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsEmployeesAccountsData
    {
        // done
        public static DataTable GetEmployeesAmountInfo()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                using (SqlCommand command = new SqlCommand("exec SP_GetEmployeesAmountInfo", connection))
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
                    }
                }
            return datble;
        }
        //done
        public static DataTable GetWorkerAmountInfo()
        {
            DataTable datble = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                using (SqlCommand command = new SqlCommand("exec SP_GetWorkerAmountInfo", connection))
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
                    }
                }
            return datble;
        }
        //done
        public static bool DeleteMonthlyAccountDataForEmployss(string ID, DateTime SalaryMonth)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_DeleteMonthlyAccountDataForEmployss @ID , @Year ,@Month ", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Month", SalaryMonth.Month);
                command.Parameters.AddWithValue("@Year", SalaryMonth.Year);

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
        public static bool DeleteMonthlyAccountDataForWorker(string ID, DateTime SalaryMonth)
        {
           

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_DeleteMonthlyAccountDataForWorker @ID , @Year ,@Month ", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Month", SalaryMonth.Month);
                command.Parameters.AddWithValue("@Year", SalaryMonth.Year);

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
        public static bool AddMonthlyAccountsData()
        {
           
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_AddMonthlyAccountsData", connection))
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
        public static bool AddEmployeesAccountstHistory(int ID,DateTime Date, float Add, float Dis, float Amount, DateTime SalaryMonth, char Kind, int UserID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_AddEmployeesAccountstoHistory @ID ,@Date ,@Add ,@Dis ,@Amount  ,@Kind ,@SalaryMonth,@UserID ", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Add", Add);
                command.Parameters.AddWithValue("@Dis", Dis);
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@SalaryMonth", SalaryMonth);

                try
                {
                    // يتم حفظ سجل الخزينة من داخل ال stored procedure

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
        public static DataTable GetEmployeesAccountHistory(char Kind)
        {
            DataTable datble = new DataTable();
            string Query = Kind == 'T' ? "exec SP_GetEmployeesAccountHistory 'T'" : "exec SP_GetWorkersAccountHistory 'W'";


            
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(Query, connection))
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

                }
            }
            return datble;
        }
        //done
        public static DataTable GetEmployeesAccountHistoryBetweenTwoDate(char Kind, DateTime DateFrom, DateTime DateTo)
        {
            DataTable datble = new DataTable();
            string Query = Kind == 'T' ? "exec SP_GetTeachersAccountHistoryBetweenTwoDate 'T' ,@DateFrom ,@DateTo \r\n" : "exec SP_GetWorkersAccountHistoryBetweenTwoDate 'W' ,@DateFrom ,@DateTo";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand(Query, connection))
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
       
    }
}
