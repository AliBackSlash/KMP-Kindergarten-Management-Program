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
        public static DataTable GetMonthlyData(string Day="")
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            if (Day == "")
                 query = @"SELECT   TreasuryMonthlyData.Amount, TreasuryMonthlyData.DateTime,case when TreasuryMonthlyData.Kind ='K' then 'سداد إشتراك ' 
                           when TreasuryMonthlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryMonthlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                           else 'دفع راتب عامل' end as Kind, case when TreasuryMonthlyData.Trunsaction =1 then ' إيداع' 
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryMonthlyData INNER JOIN
                                                    UsersData ON TreasuryMonthlyData.UserID = UsersData.Code order by TreasuryMonthlyData.DateTime";
                 else
                query = $@"SELECT    TreasuryMonthlyData.Amount, TreasuryMonthlyData.DateTime,case when TreasuryMonthlyData.Kind ='K' then 'سداد إشتراك ' 
                           when TreasuryMonthlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryMonthlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                           else 'دفع راتب عامل' end as Kind, case when TreasuryMonthlyData.Trunsaction =1 then ' إيداع' 
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryMonthlyData INNER JOIN
                                                    UsersData ON TreasuryMonthlyData.UserID = UsersData.Code where Day( TreasuryMonthlyData.DateTime ) = {Day} order by TreasuryMonthlyData.DateTime";
                           

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
        
        public static DataTable GetMonthlyDataOrder(char Trunsaction, string Day = "")
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            if (Day == "")
                query = $@"SELECT  TreasuryMonthlyData.Amount, TreasuryMonthlyData.DateTime,case when TreasuryMonthlyData.Kind ='K' then 'سداد إشتراك ' 
                when TreasuryMonthlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryMonthlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                else 'دفع راتب عامل' end as Kind, case when TreasuryMonthlyData.Trunsaction =1 then ' إيداع' 
                else ' سحب' end as Trunsaction, UsersData.UserName
                FROM            TreasuryMonthlyData INNER JOIN
                                         UsersData ON TreasuryMonthlyData.UserID = UsersData.Code where Trunsaction = {Trunsaction} order by TreasuryMonthlyData.DateTime";
            else
                query = $@"SELECT   TreasuryMonthlyData.Amount, TreasuryMonthlyData.DateTime,case when TreasuryMonthlyData.Kind ='K' then 'سداد إشتراك ' 
                when TreasuryMonthlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryMonthlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                else 'دفع راتب عامل' end as Kind, case when TreasuryMonthlyData.Trunsaction =1 then ' إيداع' 
                else ' سحب' end as Trunsaction, UsersData.UserName
                FROM            TreasuryMonthlyData INNER JOIN
                                         UsersData ON TreasuryMonthlyData.UserID = UsersData.Code where Day( TreasuryMonthlyData.DateTime ) = {Day} and Trunsaction = {Trunsaction} order by TreasuryMonthlyData.DateTime";


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

                throw ;
            }
            finally { connection.Close(); }
            return datble;

        }

        public static bool AddToTreasuryMonthlyData(float Amount , DateTime date ,char Kind,bool Trunsaction ,int UserID,int MemberID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"INSERT INTO TreasuryMonthlyData (Amount ,DateTime ,Kind,Trunsaction ,UserID,MemberID) VALUES (@Amount ,@DateTime ,@Kind,@Trunsaction ,@UserID,@MemberID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@DateTime", date);
            command.Parameters.AddWithValue("@Kind", Kind);
            command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static DataTable GetYearlyData(string Month = "")
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            if (Month == "")
                query = @"SELECT   TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind ='K' then 'سداد إشتراك ' 
                           when TreasuryYearlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                           else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction =1 then ' إيداع' 
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryYearlyData INNER JOIN
                                                    UsersData ON TreasuryYearlyData.UserID = UsersData.Code order by TreasuryYearlyData.DateTime";
            else
                query = $@"SELECT    TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind ='K' then 'سداد إشتراك ' 
                           when TreasuryYearlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                           else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction =1 then ' إيداع' 
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryYearlyData INNER JOIN
                                                    UsersData ON TreasuryYearlyData.UserID = UsersData.Code where Month( TreasuryYearlyData.DateTime ) = {Month} order by TreasuryYearlyData.DateTime";


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
        public static DataTable GetYearlyData(string Month,string Day,char Trunsaction='\0')
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            
            if(Trunsaction!='\0')
                query = $@"SELECT    TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind ='K' then 'سداد إشتراك ' 
                           when TreasuryYearlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                           else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction =1 then ' إيداع' 
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryYearlyData INNER JOIN
                                                    UsersData ON TreasuryYearlyData.UserID = UsersData.Code where Day( TreasuryYearlyData.DateTime ) = {Day} and Month( TreasuryYearlyData.DateTime ) = {Month} and Trunsaction = {Trunsaction} order by TreasuryYearlyData.DateTime";
            else
                query = $@"SELECT    TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind ='K' then 'سداد إشتراك ' 
                           when TreasuryYearlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                           else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction =1 then ' إيداع' 
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryYearlyData INNER JOIN
                                                    UsersData ON TreasuryYearlyData.UserID = UsersData.Code where Day( TreasuryYearlyData.DateTime ) = {Day} and Month( TreasuryYearlyData.DateTime ) = {Month} order by TreasuryYearlyData.DateTime";


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


        public static DataTable GetYearlyDataOrderForMonth(string Month,  char Trunsaction='\0')
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
           if(Trunsaction != '\0')
                query = $@"SELECT TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind = 'K' then 'سداد إشتراك '
                           when TreasuryYearlyData.Kind = 'T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind = 'B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب '
                           else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction = 1 then ' إيداع'
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryYearlyData INNER JOIN
                                                    UsersData ON TreasuryYearlyData.UserID = UsersData.Code where Month(TreasuryYearlyData.DateTime ) = {Month}
                          and Trunsaction = {Trunsaction} order by TreasuryYearlyData.DateTime";
           else
                query = $@"SELECT TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind = 'K' then 'سداد إشتراك '
                           when TreasuryYearlyData.Kind = 'T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind = 'B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب '
                           else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction = 1 then ' إيداع'
                           else ' سحب' end as Trunsaction, UsersData.UserName
                           FROM            TreasuryYearlyData INNER JOIN
                                                    UsersData ON TreasuryYearlyData.UserID 
                          = UsersData.Code where Month(TreasuryYearlyData.DateTime ) = {Month} order by TreasuryYearlyData.DateTime";

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
        public static DataTable GetYearlyDataOrder(char Trunsaction)
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
                query = $@"SELECT  TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind ='K' then 'سداد إشتراك ' 
                when TreasuryYearlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction =1 then ' إيداع' 
                else ' سحب' end as Trunsaction, UsersData.UserName
                FROM            TreasuryYearlyData INNER JOIN
                                         UsersData ON TreasuryYearlyData.UserID = UsersData.Code where Trunsaction = {Trunsaction} order by TreasuryYearlyData.DateTime";
            
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
        public static DataTable GetYearlyDataOrder(char Trunsaction, string Month, string Day)
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
           
                query = $@"SELECT   TreasuryYearlyData.Amount, TreasuryYearlyData.DateTime,case when TreasuryYearlyData.Kind ='K' then 'سداد إشتراك ' 
                when TreasuryYearlyData.Kind ='T' then 'دفع راتب معلم ' when TreasuryYearlyData.Kind ='B' then 'سداد مبلغ متبقي من قيمة اشتراك طالب ' 
                else 'دفع راتب عامل' end as Kind, case when TreasuryYearlyData.Trunsaction =1 then ' إيداع' 
                else ' سحب' end as Trunsaction, UsersData.UserName
                FROM            TreasuryYearlyData INNER JOIN
                                         UsersData ON TreasuryYearlyData.UserID = UsersData.Code where Day( TreasuryYearlyData.DateTime ) = {Day} 
                                      and Month( TreasuryYearlyData.DateTime ) = {Month} andTrunsaction = {Trunsaction} order by TreasuryYearlyData.DateTime";


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

        public static bool AddToTreasuryYearlyData(float Amount, DateTime date, char Kind, bool Trunsaction, int UserID,int MemberID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"INSERT INTO TreasuryYearlyData (Amount ,DateTime ,Kind,Trunsaction ,UserID,MemberID) VALUES (@Amount ,@DateTime ,@Kind,@Trunsaction ,@UserID,@MemberID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@DateTime", date);
            command.Parameters.AddWithValue("@Kind", Kind);
            command.Parameters.AddWithValue("@Trunsaction", Trunsaction);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static bool MoveMonthlyToYearlyTreasury()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"insert into TreasuryYearlyData select * from TreasuryMonthlyData";

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
        public static bool SaveTreasuryHistoryData()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"declare @DateToSave  DateTime
                             set @DateToSave = DateAdd(Month,-1,getDate())
                             insert into TreasuryHistory select * from (select (select sum(Amount) from
                             TreasuryMonthlyData t where t.Trunsaction = 0) as TotalExpenses ,(select sum(Amount) 
                             from TreasuryMonthlyData t2 where t2.Trunsaction = 1) as TotalRevenue, 
                             cast(Month(@DateToSave)as varchar) +'-' + cast(Year(@DateToSave) as varchar) as Month) t1
                             truncate table TreasuryMonthlyData;
                            ";

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

        public static DataTable GetCurrentMonthes()
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            query = "select distinct FORMAT( Month(DateTime),'00') as Month from TreasuryYearlyData order by Month";


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

        public static DataTable GetHistory()
        {
            string query;
            DataTable datble = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            query = "select * from TreasuryHistory";


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


        public static bool ClearHistory()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"truncate table TreasuryHistory; ";

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

        public static bool ClearYearlyData()
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"truncate table TreasuryYearlyData; ";

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
