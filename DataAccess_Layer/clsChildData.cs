using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;  // لإستخدام EventLog
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyDataAccessLayer
{
    public class clsChildData
    {
        //done
        public static DataTable GetKidsMenue()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_GetKidsMenue", connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                table.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }
            }

            return table;
        }
        //done
        public static DataTable GetKidsMenue(string Name)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                // يُرجى ملاحظة أن استخدام string interpolation هنا (بدلاً من معاملات SQL) قد يعرض الكود لهجمات SQL Injection.
                using (SqlCommand command = new SqlCommand($"Exec SP_GetKidsMenueWithFilter @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                table.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return table;
        }
        //done
        public static DataTable GetKidsCodeAndImagePathNameAndCode(string Name)
        {

            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_GetKidsCodeAndImagePathNameAndCode @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                table.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return table;
        }
        //done
        public static bool AddNewChaild(int Code, string name, string city, string address, DateTime dateOfBirth, bool period, short levelID,
            short classID, DateTime dateOfJoin, string bus, string branch, bool gendor, string image, byte howYouKnowNurssry, byte socialStatus,
            string messageNumber, string mail, string infoAboutChild, float SubAmount)
        {

            string query = @"exec SP_AddNewChaild @Code, @name, @city, @address, @dateOfBirth, @period, 
                            @levelID, @classID, @dateOfJoin, @bus, @branch, @gendor, @infoAboutChild, @image,
                            @SubAmount,@howYouKnowNurssry, @socialStatus, @messageNumber, @mail";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // إضافة المعاملات
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@period", period);
                    command.Parameters.AddWithValue("@levelID", levelID);
                    command.Parameters.AddWithValue("@classID", classID);
                    command.Parameters.AddWithValue("@dateOfJoin", dateOfJoin);
                    if (!string.IsNullOrEmpty(bus))
                        command.Parameters.AddWithValue("@bus", bus);
                    else
                        command.Parameters.AddWithValue("@bus", DBNull.Value);
                    if (!string.IsNullOrEmpty(branch))
                        command.Parameters.AddWithValue("@branch", branch);
                    else
                        command.Parameters.AddWithValue("@branch", DBNull.Value);
                    command.Parameters.AddWithValue("@gendor", gendor);
                    if (!string.IsNullOrEmpty(infoAboutChild))
                        command.Parameters.AddWithValue("@infoAboutChild", infoAboutChild);
                    else
                        command.Parameters.AddWithValue("@infoAboutChild", DBNull.Value);
                    if (!string.IsNullOrEmpty(image))
                        command.Parameters.AddWithValue("@image", image);
                    else
                        command.Parameters.AddWithValue("@image", DBNull.Value);
                    command.Parameters.AddWithValue("@SubAmount", SubAmount);
                    command.Parameters.AddWithValue("@howYouKnowNurssry", howYouKnowNurssry);
                    if (socialStatus != 0)
                        command.Parameters.AddWithValue("@socialStatus", socialStatus);
                    else
                        command.Parameters.AddWithValue("@socialStatus", DBNull.Value);
                    command.Parameters.AddWithValue("@messageNumber", messageNumber);
                    if (!string.IsNullOrEmpty(mail))
                        command.Parameters.AddWithValue("@mail", mail);
                    else
                        command.Parameters.AddWithValue("@mail", DBNull.Value);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                        // will add this kid id to evaluation table 
                        // this will be execute in stored procedure 'SP_AddNewChaild'
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

        }
        //done
        public static bool UpdateChildInfo(int Code, string name, string city, string address, DateTime dateOfBirth, bool period, short levelID,
            short classID, DateTime dateOfJoin, string bus, string branch, bool gendor, string image, byte howYouKnowNurssry, byte socialStatus,
            string messageNumber, string mail, string infoAboutChild, float SubAmount)
        {

            string query = @"exec SP_UpdateChildInfo @Code, @name, @city, @address, @dateOfBirth, @period, 
                            @levelID, @classID, @dateOfJoin, @bus, @branch, @gendor, @infoAboutChild, @image,
                            @SubAmount,@howYouKnowNurssry, @socialStatus, @messageNumber, @mail";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@period", period);
                    command.Parameters.AddWithValue("@levelID", levelID);
                    command.Parameters.AddWithValue("@classID", classID);
                    command.Parameters.AddWithValue("@dateOfJoin", dateOfJoin);
                    if (!string.IsNullOrEmpty(bus))
                        command.Parameters.AddWithValue("@bus", bus);
                    else
                        command.Parameters.AddWithValue("@bus", DBNull.Value);
                    if (!string.IsNullOrEmpty(branch))
                        command.Parameters.AddWithValue("@branch", branch);
                    else
                        command.Parameters.AddWithValue("@branch", DBNull.Value);
                    command.Parameters.AddWithValue("@gendor", gendor);
                    if (!string.IsNullOrEmpty(infoAboutChild))
                        command.Parameters.AddWithValue("@infoAboutChild", infoAboutChild);
                    else
                        command.Parameters.AddWithValue("@infoAboutChild", DBNull.Value);
                    if (!string.IsNullOrEmpty(image))
                        command.Parameters.AddWithValue("@image", image);
                    else
                        command.Parameters.AddWithValue("@image", DBNull.Value);
                    command.Parameters.AddWithValue("@SubAmount", SubAmount);
                    command.Parameters.AddWithValue("@howYouKnowNurssry", howYouKnowNurssry);
                    if (socialStatus != 0)
                        command.Parameters.AddWithValue("@socialStatus", socialStatus);
                    else
                        command.Parameters.AddWithValue("@socialStatus", DBNull.Value);
                    command.Parameters.AddWithValue("@messageNumber", messageNumber);
                    if (!string.IsNullOrEmpty(mail))
                        command.Parameters.AddWithValue("@mail", mail);
                    else
                        command.Parameters.AddWithValue("@mail", DBNull.Value);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

        }
        //done
        public static bool FindByCode(int ID, ref string name, ref string city, ref string address, ref DateTime dateOfBirth, ref bool period, ref int PerantID, ref short levelID,
           ref short classID, ref DateTime dateOfJoin, ref string bus, ref string branch, ref bool gendor, ref string image, ref byte howYouKnowNurssry, ref byte socialStatus,
           ref string messageNumber, ref string mail, ref string infoAboutChild, ref float SubAmount)
        {
            bool Find = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Exec SP_FindByChildCode @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                name = reader["Name"].ToString();
                                city = reader["City"].ToString();
                                address = reader["Address"].ToString();
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                                period = (bool)reader["Period"];
                                levelID = Convert.ToInt16(reader["LevelID"]);
                                classID = Convert.ToInt16(reader["ClassID"]);
                                dateOfJoin = (DateTime)reader["DateOfSubscraip"];
                                // القيم الخاصة بـ bus و branch لم تُعالج في الكود الأصلي.
                                gendor = (bool)reader["Gendor"];
                                image = reader["Image"] == DBNull.Value ? "" : reader["Image"].ToString();
                                howYouKnowNurssry = reader["HowYouKnowNursery"] == DBNull.Value ? Byte.MinValue : Convert.ToByte(reader["HowYouKnowNursery"]);
                                socialStatus = reader["SocialStatus"] == DBNull.Value ? Byte.MinValue : Convert.ToByte(reader["SocialStatus"]);
                                messageNumber = reader["MessageNumber"].ToString();
                                mail = reader["Email"] != DBNull.Value ? "" : reader["Email"].ToString();
                                infoAboutChild = reader["InfoAboutChild"].ToString();
                                SubAmount = Convert.ToSingle(reader["SubscirptionID"]);
                                PerantID = reader["PerantID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["PerantID"]);

                                Find = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                        Find = false;
                    }
                }
            }

            return Find;
        }
        //done
        public static bool FindByName(ref int ID, ref string name, ref string city, ref string address, ref DateTime dateOfBirth, ref bool period, ref int PerantID, ref short levelID,
          ref short classID, ref DateTime dateOfJoin, ref string bus, ref string branch, ref bool gendor, ref string image, ref byte howYouKnowNurssry, ref byte socialStatus,
          ref string messageNumber, ref string mail, ref string infoAboutChild, ref float SubAmount)
        {
            bool Find = false;



            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_FindByChildName @name", connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ID = (int)reader["Code"];
                                name = reader["Name"].ToString();
                                city = reader["City"].ToString();
                                address = reader["Address"].ToString();
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                                period = (bool)reader["Period"];
                                levelID = Convert.ToInt16(reader["LevelID"]);
                                classID = Convert.ToInt16(reader["ClassID"]);
                                dateOfJoin = (DateTime)reader["DateOfSubscraip"];
                                gendor = (bool)reader["Gendor"];
                                image = reader["Image"] == DBNull.Value ? "" : reader["Image"].ToString();
                                howYouKnowNurssry = reader["HowYouKnowNursery"] == DBNull.Value ? Byte.MinValue : Convert.ToByte(reader["HowYouKnowNursery"]);
                                socialStatus = reader["SocialStatus"] == DBNull.Value ? Byte.MinValue : Convert.ToByte(reader["SocialStatus"]);
                                messageNumber = reader["MessageNumber"].ToString();
                                mail = reader["Email"] != DBNull.Value ? "" : reader["Email"].ToString();
                                infoAboutChild = reader["InfoAboutChild"].ToString();
                                SubAmount = Convert.ToSingle(reader["SubscirptionID"]);
                                PerantID = reader["PerantID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["PerantID"]);

                                Find = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Find = false;
                    }
                }
            }

            return Find;
        }
        //done
        public static bool DeleteChildWhithAllInfo(int ID, string PerantID)
        {


            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_DeleteChildWhithAllInfo @ID,@PerantID", connection))
                {
                    command.Parameters.AddWithValue("@PerantID", PerantID);
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() != 0;
                        
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

        }
        //done
        public static DataTable GetKidsBirthDateNotification()
        {
            DataTable table = new DataTable();


            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetKidsBirthDateNotification", connection))
                {
                   
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                table.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return table;
        }

        public static bool SetActiveChild(bool IsActive,int ID)
        {
            bool success = false;
            

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("exec SP_SetActiveChild @IsActive ,@Date , @ID ", connection))
                {
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);

                    try
                    {
                        connection.Open();
                        if (command.ExecuteNonQuery() != 0)
                        {
                            success = true;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return success;
        }
        //done
        public static DataTable GetUnActiveMenue()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

           
            SqlCommand command = new SqlCommand("exec SP_GetUnActiveMenue", Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();

            }
            catch (Exception)
            {

                //Throw;
            }
            finally { Connection.Close(); }

            return table;
        }
        //done
        public static DataTable GetUnActiveMenue(string Name)
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

           
            SqlCommand command = new SqlCommand("exec SP_GetUnActiveMenueWithFilter @Name", Connection);
            command.Parameters.AddWithValue("@Name", Name);
            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();

            }
            catch (Exception)
            {

            }
            finally { Connection.Close(); }

            return table;
        }

    }
}
