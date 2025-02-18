using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsPersonCanTakeData
    {
        public static bool AddCanTake(string CHildID, string Name, string SeltAlkraba, string PhoneNumber, string PersonalCardNumber)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"INSERT INTO PersonCanTakeChild
                           (Name
                           ,SeltAlkraba
                           ,PhoneNumber
                           ,PersonalCardNumber
                           ,KidsID)
                             VALUES
                           (@Name
                           ,@SeltAlkraba
                           ,@PhoneNumber
                           ,@PersonalCardNumber
                           ,@CHildID)
                             ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CHildID", CHildID);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@SeltAlkraba", SeltAlkraba);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@PersonalCardNumber", PersonalCardNumber);


            bool success = false;
            try
            {
                connection.Open();

                if(command.ExecuteNonQuery()!=0) 
                    success = true;
            }
            catch (Exception)
            {

            }
            finally { connection.Close(); }

            return success;
        }

        public static bool UpdateCanTake(string ChildID, string Name, string SeltAlkraba, string PhoneNumber, string PersonalCardNumber)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"UPDATE PersonCanTakeChild
                             SET Name               = @Name              
                                ,SeltAlkraba        = @SeltAlkraba       
                                ,PhoneNumber        =	@PhoneNumber       
                                ,PersonalCardNumber = @PersonalCardNumber
                                ,KidsID             = @ChildID            
                           WHERE KidsID =@ChildID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ChildID", ChildID);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@SeltAlkraba", SeltAlkraba);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@PersonalCardNumber", PersonalCardNumber);

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

        public static bool FindByCode(string KidsID, ref string Name, ref string SeltAlkraba, ref string PhoneNumber, ref string PersonalCardNumber)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"Select * from PersonCanTakeChild where KidsID = @KidsID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@KidsID", KidsID);

            bool success = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    success = true;
                    Name = (string)reader["Name"];
                    SeltAlkraba = (string)reader["SeltAlkraba"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    PersonalCardNumber = (string)reader["PersonalCardNumber"];

                }
            }
            catch (Exception)
            {
                success = false;


            }
            finally { connection.Close(); }

            return success;
        }

        public static bool ISAlreadyHasPersonCanTake(int Code)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);
            string query = @"Select 1 from PersonCanTakeChild where KidsID = @Code";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Code", Code);

            bool success = false;
            try
            {
                connection.Open();
                if (command.ExecuteScalar() != null)
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
