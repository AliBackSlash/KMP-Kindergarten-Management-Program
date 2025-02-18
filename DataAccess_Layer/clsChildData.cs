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
                        // تسجيل الخطأ في سجل أحداث الويندوز
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return table;
        }

        public static DataTable GetKidsMenue(string Name)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                // يُرجى ملاحظة أن استخدام string interpolation هنا (بدلاً من معاملات SQL) قد يعرض الكود لهجمات SQL Injection.
                using (SqlCommand command = new SqlCommand($"Exec SP_GetKidsMenueWithFilter {Name}", connection))
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
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return table;
        }

        public static DataTable GetKidsPersonalInfoWithName(string Name)
        {
            DataTable table = new DataTable();

            string query = "SELECT KidsPersonalInfo.Code, KidsPersonalInfo.Name, " +
                "KidsPersonalInfo.City, KidsPersonalInfo.Address, OtherInfo.Email, KidsPersonalInfo.DateOfBirth, " +
                "KidsPersonalInfo.Period, KidsPersonalInfo.Gendor, KidsPersonalInfo.Image, PerantInfo.PhoneNumber, " +
                "PerantInfo.FatherName, PerantInfo.FatherJop, PerantInfo.MotherName, " +
                "PerantInfo.MotherJop, PerantInfo.MPhone, Levels.[Level], Clases.Class, PersonCanTakeChild.Name as TName, PersonCanTakeChild.SeltAlkraba, " +
                "PersonCanTakeChild.PhoneNumber as TPhoneNumber, PersonCanTakeChild.PersonalCardNumber " +
                "FROM KidsPersonalInfo LEFT JOIN PerantInfo ON KidsPersonalInfo.PerantID = PerantInfo.Code" +
                " INNER JOIN Clases ON KidsPersonalInfo.ClassID = Clases.Code INNER JOIN " +
                "Levels ON KidsPersonalInfo.LevelID = Levels.Code LEFT JOIN OtherInfo ON KidsPersonalInfo.Code = OtherInfo.ChildID" +
                " INNER JOIN PersonCanTakeChild ON KidsPersonalInfo.Code = PersonCanTakeChild.KidsID WHERE KidsPersonalInfo.Name = @Name";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
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
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return table;
        }

        public static DataTable GetKidsPersonalInfowithID(string ID)
        {
            DataTable table = new DataTable();

            string query = "SELECT KidsPersonalInfo.Code, KidsPersonalInfo.Name, " +
                "KidsPersonalInfo.City, KidsPersonalInfo.Address, OtherInfo.Email, KidsPersonalInfo.DateOfBirth, " +
                "KidsPersonalInfo.Period, KidsPersonalInfo.Gendor, KidsPersonalInfo.Image, PerantInfo.PhoneNumber, " +
                "PerantInfo.FatherName, PerantInfo.FatherJop, PerantInfo.MotherName, " +
                "PerantInfo.MotherJop, PerantInfo.MPhone, Levels.[Level], Clases.Class, PersonCanTakeChild.Name as TName, PersonCanTakeChild.SeltAlkraba, " +
                "PersonCanTakeChild.PhoneNumber as TPhoneNumber, PersonCanTakeChild.PersonalCardNumber " +
                "FROM KidsPersonalInfo LEFT JOIN PerantInfo ON KidsPersonalInfo.PerantID = PerantInfo.Code" +
                " INNER JOIN Clases ON KidsPersonalInfo.ClassID = Clases.Code INNER JOIN " +
                "Levels ON KidsPersonalInfo.LevelID = Levels.Code LEFT JOIN OtherInfo ON KidsPersonalInfo.Code = OtherInfo.ChildID" +
                " LEFT JOIN PersonCanTakeChild ON KidsPersonalInfo.Code = PersonCanTakeChild.KidsID WHERE KidsPersonalInfo.Code = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

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
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return table;
        }

        public static DataTable GetKidsAllPersonalInfo(string Name)
        {
            DataTable table = new DataTable();

            string query = @"SELECT DISTINCT KidsPersonalInfo.*, OtherInfo.HowYouKnowNursery, OtherInfo.SocialStatus, 
                               OtherInfo.MessageNumber, OtherInfo.Email  
                              FROM KidsPersonalInfo LEFT JOIN 
                               OtherInfo ON KidsPersonalInfo.Code = OtherInfo.ChildID WHERE KidsPersonalInfo.Name = @Name";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
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
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return table;
        }

        public static bool AddNewChaild(string Code, string name, string city, string address, DateTime dateOfBirth, bool period, short levelID,
            short classID, DateTime dateOfJoin, string bus, string branch, bool gendor, string image, byte howYouKnowNurssry, byte socialStatus,
            string messageNumber, string mail, string infoAboutChild, float SubAmount)
        {
            bool sucsses = false;

            string query =
                "INSERT INTO KidsPersonalInfo (Code,Name,City,Address,DateOfBirth,Period,LevelID,ClassID,DateOfSubscraip,BusID,Branch,Gendor,InfoAboutChild,Image,SubscirptionID) VALUES " +
                "(@Code, @name, @city, @address, @dateOfBirth, @period, @levelID, @classID, @dateOfJoin, @bus, @branch, @gendor, @infoAboutChild, @image, @SubAmount); " +
                "INSERT INTO OtherInfo (HowYouKnowNursery, SocialStatus, MessageNumber, Email, ChildID) " +
                "VALUES (@howYouKnowNurssry, @socialStatus, @messageNumber, @mail, @Code);";

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
                        if (command.ExecuteNonQuery() != 0)
                        {
                            sucsses = true;
                            clsEvaluationsData.AddDayEvaluationInfo(Code.ToString(), name, classID, gendor);
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                        sucsses = false;
                    }
                }
            }

            return sucsses;
        }

        public static bool UpdateChildInfo(string ID, string NewCode, string name, string city, string address, DateTime dateOfBirth, bool period, short levelID,
            short classID, DateTime dateOfJoin, string bus, string branch, bool gendor, string image, byte howYouKnowNurssry, byte socialStatus,
            string messageNumber, string mail, string infoAboutChild, float SubAmount)
        {
            bool success = false;

            string query = "UPDATE KidsPersonalInfo SET Code = @NewCode, Name = @name, City = @city, Address = @address, " +
                "DateOfBirth = @dateOfBirth, Period = @period, LevelID = @levelID, ClassID = @classID, DateOfSubscraip = @dateOfJoin, " +
                "BusID = @bus, Gendor = @gendor, InfoAboutChild = @infoAboutChild, Image = @image, Branch = @branch, SubscirptionID = @SubAmount " +
                "WHERE KidsPersonalInfo.Code = @ID; " +
                "UPDATE OtherInfo SET HowYouKnowNursery = @howYouKnowNurssry, SocialStatus = @socialStatus, MessageNumber = @messageNumber, " +
                "Email = @mail WHERE OtherInfo.ChildID = @ID;";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@NewCode", NewCode);
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
                        if (command.ExecuteNonQuery() != 0)
                            success = true;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                        success = false;
                    }
                }
            }

            return success;
        }

        public static bool FindByCode(string ID, ref string name, ref string city, ref string address, ref DateTime dateOfBirth, ref bool period, ref int PerantID, ref short levelID,
           ref short classID, ref DateTime dateOfJoin, ref string bus, ref string branch, ref bool gendor, ref string image, ref byte howYouKnowNurssry, ref byte socialStatus,
           ref string messageNumber, ref string mail, ref string infoAboutChild, ref float SubAmount)
        {
            bool Find = false;

            string query = @"SELECT DISTINCT KidsPersonalInfo.*, OtherInfo.HowYouKnowNursery, OtherInfo.SocialStatus, OtherInfo.MessageNumber, OtherInfo.Email 
                             FROM KidsPersonalInfo INNER JOIN OtherInfo ON KidsPersonalInfo.Code = OtherInfo.ChildID 
                             WHERE KidsPersonalInfo.Code = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
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

        public static bool FindByName(ref string ID, ref string name, ref string city, ref string address, ref DateTime dateOfBirth, ref bool period, ref int PerantID, ref short levelID,
          ref short classID, ref DateTime dateOfJoin, ref string bus, ref string branch, ref bool gendor, ref string image, ref byte howYouKnowNurssry, ref byte socialStatus,
          ref string messageNumber, ref string mail, ref string infoAboutChild, ref float SubAmount)
        {
            bool Find = false;

            string query = @"SELECT DISTINCT KidsPersonalInfo.*, OtherInfo.HowYouKnowNursery, OtherInfo.SocialStatus, OtherInfo.MessageNumber, OtherInfo.Email 
                             FROM KidsPersonalInfo INNER JOIN OtherInfo ON KidsPersonalInfo.Code = OtherInfo.ChildID 
                             WHERE CAST(KidsPersonalInfo.Code AS nvarchar) + '-' + KidsPersonalInfo.Name = @name";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ID = reader["Code"].ToString();
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
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                        Find = false;
                    }
                }
            }

            return Find;
        }

        public static bool DeleteChildWhithAllInfo(int ID, string PerantID)
        {
            bool success = false;

            string query = "DELETE FROM OtherInfo WHERE OtherInfo.ChildID = @ID; " +
                           "DELETE FROM PersonCanTakeChild WHERE PersonCanTakeChild.KidsID = @ID; " +
                           "DELETE FROM BrotherInfo WHERE BrotherInfo.ChildID = @ID; " +
                           "DELETE FROM KidsPersonalInfo WHERE KidsPersonalInfo.Code = @ID; " +
                           "DELETE FROM PerantInfo WHERE PerantInfo.Code = @PerantID; " +
                           "DELETE FROM Notes WHERE ID = @ID; " +
                           "DELETE FROM AbsenceHistory WHERE AbsenceHistory.ID = @ID; " +
                           "DELETE FROM EnterAndLeaveHistory WHERE EnterAndLeaveHistory.ID = @ID; " +
                           "DELETE FROM LeaveHistory WHERE LeaveHistory.ID = @ID;";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PerantID", PerantID);
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        if (command.ExecuteNonQuery() != 0)
                        {
                            success = true;
                            clsEvaluationsData.DeleteFromEvaluationTable(ID.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return success;
        }

        public static short GetClassID(string Name)
        {
            short code = 0;
            string query = "SELECT code FROM Clases WHERE class = @Name";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();
                        object ID = command.ExecuteScalar();
                        if (ID != null && short.TryParse(ID.ToString(), out short result))
                            code = result;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return code;
        }

        public static short GetLevelID(string Name)
        {
            short code = 0;
            string query = "SELECT code FROM Levels WHERE [Level] = @Name";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();
                        object ID = command.ExecuteScalar();
                        if (ID != null && short.TryParse(ID.ToString(), out short result))
                            code = result;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return code;
        }

        public static string GetClassName(short ID)
        {
            string Name = "";
            string query = "SELECT class FROM Clases WHERE code = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        object nameObj = command.ExecuteScalar();
                        if (nameObj != null)
                            Name = nameObj.ToString();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return Name;
        }

        public static string GetLevelName(short ID)
        {
            string Name = "";
            string query = "SELECT [level] FROM Levels WHERE code = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        object nameObj = command.ExecuteScalar();
                        if (nameObj != null)
                            Name = nameObj.ToString();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return Name;
        }

        public static DataTable GetKidsBirthDateNotification()
        {
            DataTable table = new DataTable();
            DateTime Date = DateTime.Now;

            string query = $@"SELECT Name, DateOfBirth, Code, OtherInfo.MessageNumber 
                              FROM KidsPersonalInfo 
                              INNER JOIN OtherInfo ON OtherInfo.ChildID = KidsPersonalInfo.Code 
                              WHERE MONTH(DateOfBirth) = MONTH(GETDATE()) 
                              AND (DAY(DateOfBirth) = DAY(GETDATE()) OR DAY(DATEADD(DAY, 1, GETDATE())) = DAY(DateOfBirth));";

            using (SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // المعاملات المُضافة هنا قد لا تكون ضرورية إذا لم تُستخدم في جملة الاستعلام؛
                    // ولكن تُترك كما هي للحفاظ على هيكل الكود الأصلي.
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@DateBefor", Date.AddDays(-1));

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
                        EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                    }
                }
            }

            return table;
        }
    }
}
