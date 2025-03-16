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
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
               
                using (SqlCommand command = new SqlCommand("exec SP_AddPersonCanTake @Name,@SeltAlkraba,@PhoneNumber,@PersonalCardNumber,@CHildID", connection))
                {
                    command.Parameters.AddWithValue("@CHildID", CHildID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@SeltAlkraba", SeltAlkraba);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@PersonalCardNumber", PersonalCardNumber);

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
        public static bool UpdateCanTake(string ChildID, string Name, string SeltAlkraba, string PhoneNumber, string PersonalCardNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
               
                using (SqlCommand command = new SqlCommand("exec SP_UpdateCanTake @Name,@SeltAlkraba,@PhoneNumber,@PersonalCardNumber,@CHildID", connection))
                {
                    command.Parameters.AddWithValue("@ChildID", ChildID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@SeltAlkraba", SeltAlkraba);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@PersonalCardNumber", PersonalCardNumber);

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
        public static bool FindByCode(string CHildID, ref string Name, ref string SeltAlkraba, ref string PhoneNumber, ref string PersonalCardNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("exec SP_FindByCode @CHildID", connection))
                {
                    command.Parameters.AddWithValue("@CHildID", CHildID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Name = (string)reader["Name"];
                                SeltAlkraba = (string)reader["SeltAlkraba"];
                                PhoneNumber = (string)reader["PhoneNumber"];
                                PersonalCardNumber = (string)reader["PersonalCardNumber"];
                                return true;
                            }
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }        
        public static bool ISAlreadyHasPersonCanTake(int CHildID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {

                using (SqlCommand command = new SqlCommand("exec SP_ISAlreadyHasPersonCanTake @CHildID", connection))
                {
                    command.Parameters.AddWithValue("@CHildID", CHildID);

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
        }
    }
}
