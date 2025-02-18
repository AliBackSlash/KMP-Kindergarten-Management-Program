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

        public static DataTable GetEmployeesAmountInfo()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "select * from EmployeesAccounts";

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

        public static DataTable GetWorkerAmountInfo()
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "select * from WorkersAccounts";

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

        public static bool DeleteMonthlyAccountDataForEmployss(string ID, DateTime SalaryMonth)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Delete from EmployeesAccounts where Code = @ID and Year(SalaryMonth) = @Year and Month(SalaryMonth) = @Month";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Month", SalaryMonth.Month);
            command.Parameters.AddWithValue("@Year", SalaryMonth.Year);
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

        public static bool DeleteMonthlyAccountDataForWorker(string ID, DateTime SalaryMonth)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "Delete from WorkersAccounts where Code = @ID and Year(SalaryMonth) = @Year and Month(SalaryMonth) = @Month";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Month", SalaryMonth.Month);
            command.Parameters.AddWithValue("@Year", SalaryMonth.Year);
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

        public static bool GetMonthlyAccountData()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = " insert  into EmployeesAccounts select Code,Name,Salary,dateadd(month,-1,SalaryMonth) as SalaryMonth from EmployeesAccountsMonthlyInfo;" +
                           "insert  into WorkersAccounts select Code,Name,Salary,dateadd(month,-1,SalaryMonth) as SalaryMonth from WorkersAccountsMonthlyInfo ";

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

        public static bool AddEmployeesAccountstHistory(string ID, string Name, DateTime Date, string Add, string Dis, string Amount, string Period,
                                                        bool Gendor, string Month, DateTime SalaryMonth, char Kind, int UserID)
        {
            
           
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "INSERT INTO EmployeesAccountsHistory (ID ,Name ,Date,AddM,Dis ,Amount  ,Period  ,Gendor,Month,Kind,SalaryMonth)" +
                           " VALUES " +
                           "(@ID ,@Name ,@Date,@Add,@Dis ,@Amount  ,@Period  ,@Gendor,@Month,@Kind,@SalaryMonth)";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@Add", Add);
            command.Parameters.AddWithValue("@Dis", Dis);
            command.Parameters.AddWithValue("@Kind", Kind);

            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Period", Period);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Month", Month);
            command.Parameters.AddWithValue("@SalaryMonth", SalaryMonth);



            bool Saccess = false;
            try
            {
                connection.Open();
                if (command.ExecuteNonQuery() != 0)
                {
                    //will be converted to trunsaction in T-SQL soon
                    Saccess = true;
                    clsTreasuryData.AddToTreasuryMonthlyData(Convert.ToSingle(Amount), DateTime.Now, Kind, false, UserID, Convert.ToInt32(ID));
                }
            }
            catch (Exception)
            {
                Saccess = false;
            }
            finally { connection.Close(); }

            return Saccess;
        }
        public static DataTable GetEmployeesInfoToSaveInHistory(string Code)
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT TeachersInfo.Code, TeachersInfo.Name, TeachersInfo.Period, TeachersInfo.Gendor,TeachersInfo.Salary FROM  TeachersInfo  where TeachersInfo.Code = @Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);

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

        public static DataTable GetWorkerInfoToSaveInHistory(string Code)
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT  WorkerInfo.Code, WorkerInfo.Name, WorkerInfo.Period, WorkerInfo.Gendor,WorkerInfo.Salary  FROM  WorkerInfo where  WorkerInfo.Code = @Code";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);

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

        public static DataTable GetEmployeesAccountHistory(char Kind)
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM EmployeesAccountsHistory where Kind = @Kind";

            SqlCommand command = new SqlCommand(query, connection);
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
        public static DataTable GetEmployeesAccountHistoryBetweenTwoDate(char Kind,DateTime DateFrom, DateTime DateTo)
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT * FROM EmployeesAccountsHistory where Kind = @Kind and Date between cast(@DateFrom as date)  and  cast(@DateTo as date)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Kind", Kind);
            command.Parameters.AddWithValue("@DateFrom", DateFrom);
            command.Parameters.AddWithValue("@DateTo", DateTo);

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
        public static DataTable GetEmployeesAccountHistory(DateTime date)
        {
            DataTable datble = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = "SELECT ID, Name, Date, Amount, AddAmount, Period, JopName, Gendor FROM EmployeesAccountsHistory" +
                           " where EmployeesAccountsHistory.Date = @date";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@date", date);
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
    }
}
