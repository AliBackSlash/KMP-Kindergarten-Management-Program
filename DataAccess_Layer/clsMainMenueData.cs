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
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_TotalExpectTreasuryAmmount", connection))
            {
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
                    // لا يتم رمي الاستثناء
                }
                return Amount;
            }
        }

        public static int CurrentTreasuryAmmount()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            using (SqlCommand command = new SqlCommand("exec SP_CurrentTreasuryAmmount", connection))
            {

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
                    // لا يتم رمي الاستثناء
                }
                return Amount;
            }
        }
    }
}
