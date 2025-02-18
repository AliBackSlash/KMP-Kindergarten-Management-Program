using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsMainMenueData
    {
        public static int TreasuryAmmount()
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "SELECT SUM(SubscirptionID)FROM KidsPersonalInfo ";


            SqlCommand command = new SqlCommand(query, connection);



            int Amount = 0;
            try
            {
                connection.Open();
                object amount = command.ExecuteScalar();
                if (amount != null)
                    Amount = Convert.ToInt16(amount);
            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }


            return Amount;
        }


        public static int CurrentTreasuryAmmount()
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string date = DateTime.Now.ToString("MM-yyyy");
            string query = @"SELECT ISNULL(
                             (SELECT SUM(Amount) 
                              FROM TreasuryMonthlyData 
                              WHERE Kind = 'K') 
                             - 
                             (SELECT SUM(t.Amount)  
                              FROM TreasuryMonthlyData t 
                              WHERE t.Kind <> 'K'), 0) AS Result;
                         ";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@date", date);


            int Amount = 0;
            try
            {
                connection.Open();
                object amount = command.ExecuteScalar();
                if (amount != null)
                    Amount = Convert.ToInt16(amount);
            }
            catch (Exception)
            {


            }
            finally { connection.Close(); }


            return Amount;
        }
    }
}
