using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public class clsChildArchiveData
    {

        public static DataTable GetArchiveMenue()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "SELECT KidsArshef.Gendor,DateOfArchive,KidsArshef.Code, KidsArshef.Name," +
                           "KidsArshef.DateOfBirth, Levels.[Level], Clases.Class," +
                           "KidsArshef.Period, KidsArshef.FatherPhoneNumber FROM KidsArshef INNER JOIN Levels ON KidsArshef.LevelID = " +
                           "Levels.Code INNER JOIN Clases ON KidsArshef.ClassID = Clases.Code";

            SqlCommand command = new SqlCommand(query, Connection);

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

        public static DataTable GetArchiveMenue(string Name)
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "SELECT KidsArshef.Gendor,KidsArshef.DateOfArchive as DateOfArchive,KidsArshef.Code, KidsArshef.Name," +
                           "KidsArshef.DateOfBirth, Levels.[Level], Clases.Class, KidsArshef.Period, KidsArshef.FatherPhoneNumber " +
                           "FROM KidsArshef INNER JOIN Levels ON KidsArshef.LevelID =" +
                           $"  Levels.Code INNER JOIN Clases ON KidsArshef.ClassID = Clases.Code where KidsArshef.Name like '{Name}%'";

            SqlCommand command = new SqlCommand(query, Connection);

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

        public static bool DeleteReocrdFromArchive(string ID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "delete from KidsArshef where Code = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            bool RowsEffected = false;
            try
            {
                connection.Open();
                if (RowsEffected = command.ExecuteNonQuery() != 0)
                    RowsEffected = true;
            }
            catch (Exception)
            {
                RowsEffected = false;
            }
            finally { connection.Close(); }

            return RowsEffected;
        }

        public static DataTable FindByChildID(string ID)

        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "select top 1 * from KidsArshef where Code = @ID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@ID", ID);
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


        public static bool SaveToArchive(string Code, string name, string city, string address, DateTime dateOfBirth, bool period, short levelID
                                         , short classID, DateTime dateOfJoin, string bus, string branch, float SubscirptionID,  bool gendor, string image,
                                          string fatherName, string fatherJop, string fatherPhone
                                         , string motherName, string motherJop, string motherPhone, byte howYouKnowNurssry, byte socialStatus
                                         , string messageNumber, string mail, string infoAboutChild,
                                           string takeName, string takeSeltAlkraba
                                         , string takePhone, string takePersonalCardNumber)
        {
            DateTime time = DateTime.Now;
            SqlConnection connection = new SqlConnection(ConnectionString.Connectionstring);

            string query = "INSERT INTO KidsArshef (Code,Name,City,Address,DateOfBirth,Period,LevelID,ClassID," +
                "DateOfSubscraip,BusID,Gendor,InfoAboutChild,Image,Branch,SubscirptionID,DateOfArchive " +
                ",FatherName,FatherJop,MotherName,MotherJop,HowYouKnowNursery,SocialStatus,MessageNumber " +
                ",Email,FatherPhoneNumber,MPhoneNumber,TName,SeltAlkraba,TPhoneNumber,PersonalCardNumber) " +
                "VALUES " +

                "(@Code,@name, @city, @address, @dateOfBirth,@period,@levelID  " +
                ", @classID, @dateOfJoin, @bus,@gendor,@infoAboutChild, @image ,@branch,@SubscirptionID,@DateOfArchive, " +
                "@fatherName,@fatherJop, @motherName, @motherJop,  @howYouKnowNurssry, @socialStatus" +
                ", @messageNumber, @mail, @fatherPhone, @motherPhone, @takeName, @takeSeltAlkraba , " +
                "@takePhone, @takePersonalCardNumber)";

            SqlCommand command = new SqlCommand(query, connection);
            if (motherPhone != "")
            
                command.Parameters.AddWithValue("@motherPhone", motherPhone);

            
            else
            
                command.Parameters.AddWithValue("@motherPhone", System.DBNull.Value);

            

            command.Parameters.AddWithValue("@SubscirptionID", SubscirptionID);

            command.Parameters.AddWithValue("@Code", Code);

            //
            command.Parameters.AddWithValue("@DateOfArchive", time);
            if (fatherName != "")
                command.Parameters.AddWithValue("@fatherName", fatherName);
            else
                command.Parameters.AddWithValue("@fatherName", System.DBNull.Value);
            if (fatherJop != "")
                command.Parameters.AddWithValue("@fatherJop", fatherJop);
            else
                command.Parameters.AddWithValue("@fatherJop", System.DBNull.Value);

            if (motherName != "")
                command.Parameters.AddWithValue("@motherName", motherName);
            else
                command.Parameters.AddWithValue("@motherName", System.DBNull.Value);
            if (motherJop != "")
                command.Parameters.AddWithValue("@motherJop", motherJop);
            else
                command.Parameters.AddWithValue("@motherJop", System.DBNull.Value);
            //
            if (fatherPhone != "")
                command.Parameters.AddWithValue("@fatherPhone", fatherPhone);
            else
                command.Parameters.AddWithValue("@fatherPhone", System.DBNull.Value);            
            //
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@period", period);
            command.Parameters.AddWithValue("@levelID", levelID);
            command.Parameters.AddWithValue("@classID", classID);
            command.Parameters.AddWithValue("@dateOfJoin", dateOfJoin);
            if (bus != "")
                command.Parameters.AddWithValue("@bus", bus);
            else
                command.Parameters.AddWithValue("@bus", System.DBNull.Value);
            if (branch != "")
                command.Parameters.AddWithValue("@branch", branch);
            else
                command.Parameters.AddWithValue("@branch", System.DBNull.Value);

            command.Parameters.AddWithValue("@gendor", gendor);
            if (infoAboutChild != "")
                command.Parameters.AddWithValue("@infoAboutChild", infoAboutChild);
            else
                command.Parameters.AddWithValue("@infoAboutChild", System.DBNull.Value);

            if (image != "")
                command.Parameters.AddWithValue("@image", image);
            else
                command.Parameters.AddWithValue("@image", System.DBNull.Value);

            //
            command.Parameters.AddWithValue("@howYouKnowNurssry", howYouKnowNurssry);
            if (socialStatus != 0)
                command.Parameters.AddWithValue("@socialStatus", socialStatus);
            else
                command.Parameters.AddWithValue("@socialStatus", System.DBNull.Value);


            command.Parameters.AddWithValue("@messageNumber", messageNumber);

            if (mail != "")
                command.Parameters.AddWithValue("@mail", mail);
            else
                command.Parameters.AddWithValue("@mail", System.DBNull.Value);

           
            //
            if (takeName != "")
            {
                command.Parameters.AddWithValue("@takeName", takeName);
                command.Parameters.AddWithValue("@takeSeltAlkraba", takeSeltAlkraba);
                command.Parameters.AddWithValue("@takePhone", takePhone);
                command.Parameters.AddWithValue("@takePersonalCardNumber", takePersonalCardNumber);
            }
            else
            {
                command.Parameters.AddWithValue("@takeName", System.DBNull.Value);
                command.Parameters.AddWithValue("@takeSeltAlkraba", System.DBNull.Value);
                command.Parameters.AddWithValue("@takePhone", System.DBNull.Value);
                command.Parameters.AddWithValue("@takePersonalCardNumber", System.DBNull.Value);
            }

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
                //throw;
            }
            finally { connection.Close(); }



            return success ;
        }


    }
}
