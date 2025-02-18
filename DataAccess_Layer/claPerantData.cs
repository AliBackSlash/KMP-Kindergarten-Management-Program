using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class claPerantData
    {
        public static bool AddParent(int ChildID, string FatherName, string FatherJop, string MotherName, string MotherJop, string MPhone, string PhoneNumber)
        {
            string query = @"exec SP_AddParent @FatherName, 
                            @FatherJop, @MotherName, @MotherJop, @MPhone, @PhoneNumber,@ChildID";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ChildID", ChildID);
                    command.Parameters.AddWithValue("@FatherName", FatherName);
                    command.Parameters.AddWithValue("@FatherJop", FatherJop);
                    command.Parameters.AddWithValue("@MotherName", MotherName);
                    command.Parameters.AddWithValue("@MotherJop", MotherJop);
                    command.Parameters.AddWithValue("@MPhone", MPhone);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
               // EventLog.WriteEntry("KMP", ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static bool UpdateParent(int Code, string FatherName, string FatherJop, string MotherName, string MotherJop, string MPhone, string PhoneNumber)
        {
            string query = @"exec SP_UpdateParent @FatherName, @FatherJop, @MotherName, @MotherJop, @MPhone, @PhoneNumber,@Code";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FatherName", FatherName);
                    command.Parameters.AddWithValue("@FatherJop", FatherJop);
                    command.Parameters.AddWithValue("@MotherName", MotherName);
                    command.Parameters.AddWithValue("@MotherJop", MotherJop);
                    command.Parameters.AddWithValue("@MPhone", MPhone);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Code", Code);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("KMP", ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static bool FindByCode(int Code, ref string FatherName, ref string FatherJop, ref string MotherName, ref string MotherJop, ref string MPhone, ref string PhoneNumber)
        {
            string query = "SELECT * FROM PerantInfo WHERE Code = @Code";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FatherName = reader["FatherName"].ToString();
                            FatherJop = reader["FatherJop"].ToString();
                            MotherName = reader["MotherName"].ToString();
                            MotherJop = reader["MotherJop"].ToString();
                            MPhone = reader["MPhone"].ToString();
                            PhoneNumber = reader["PhoneNumber"].ToString();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // EventLog.WriteEntry("KMP", ex.ToString(), EventLogEntryType.Error);
            }
            return false;
        }

        public static bool ISAlreadyHasPerantInSystem(int Code)
        {
            string query = "exec SP_ISAlreadyHasPerantInSystem @Code";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("KMP", ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }


    }
}
