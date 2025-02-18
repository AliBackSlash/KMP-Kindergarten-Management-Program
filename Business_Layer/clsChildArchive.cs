using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsChildArchive
    {
        public static DataTable GetArchiveMenue()
        {
            return clsChildArchiveData.GetArchiveMenue();
        }

        public static DataTable GetArchiveMenue(string Name)
        {
            return clsChildArchiveData.GetArchiveMenue(Name);
        }

        //not tested
        public static bool Save(string ChildCode)
        {
            clsChild Child = null;
            clsPerant perant = null;
            clsPersonCanTake PersonCanTake = null;

            Child = clsChild.FindByCode(ChildCode);
            if (Child == null)
            {
                return false;
            }
            perant = clsPerant.Find(Child.PerantID);
            if (perant == null)
                perant = new clsPerant();
            PersonCanTake = clsPersonCanTake.Find(Child.OldCode);
            if(PersonCanTake == null)
                PersonCanTake = new clsPersonCanTake();

            bool Added = clsChildArchiveData.SaveToArchive(Child.OldCode, Child.name, Child.city, Child.address, Child.dateOfBirth,
                Child.period, Child.levelID, Child.classID, Child.dateOfJoin,
                Child.bus, Child.branch, Child.SubAmount, Child.gendor, Child.image,
                perant.FatherName, perant.FatherJop, perant.PhoneNumber, perant.MotherName, perant.MotherJop
                , perant.MPhone, Child.howYouKnowNurssry, Child.socialStatus, Child.messageNumber,
                Child.mail, Child.infoAboutChild, PersonCanTake.Name, PersonCanTake.SeltAlkraba, PersonCanTake.PhoneNumber
               , PersonCanTake.PersonalCardNumber);

            if (Added)
                return true;
            else
                return false;
        }


        public static bool Return(string ChildCode)
        {
            DataTable dt = clsChildArchiveData.FindByChildID(ChildCode);
            if (dt.Rows.Count<=0) 
                return false;
           DataRow row = dt.Rows[0];
            clsChild Child = new clsChild();

            Child.NewCode = ChildCode;
            Child.name = (string)row["Name"];
            Child.city= (string)row["City"]; 
            Child.address = (string)row["Address"];
            Child.dateOfBirth = (DateTime)row["DateOfBirth"];
            Child.period = (bool)row["Period"];
            Child.levelID = Convert.ToInt16(row["LevelID"]);
            Child.classID = Convert.ToInt16(row["ClassID"]);
            Child.dateOfJoin = (DateTime)row["DateOfSubscraip"];
            Child.bus = row["BusID"]?.ToString();
            Child.branch = row["Branch"]?.ToString();
            Child.SubAmount = Convert.ToSingle(row["SubscirptionID"]);
            Child.gendor = (bool)row["Gendor"];
            Child.image = row["Image"]?.ToString();
            Child.howYouKnowNurssry = Convert.ToByte(row["HowYouKnowNursery"]);
            Child.socialStatus = Convert.ToByte(row["SocialStatus"]);
            Child.messageNumber = (string)row["MessageNumber"];
            Child.mail = row["Email"]?.ToString();
            Child.infoAboutChild = row["InfoAboutChild"]?.ToString();

            clsPerant perant = new clsPerant();

            perant.FatherName = row["FatherName"]?.ToString();
            perant.FatherJop = row["FatherJop"]?.ToString();
            perant.PhoneNumber = row["FatherPhoneNumber"]?.ToString();
            perant.MotherName = row["MotherName"]?.ToString();
            perant.MotherJop = row["MotherJop"]?.ToString();
            perant.MPhone = row["MPhoneNumber"]?.ToString();

            clsPersonCanTake PersonCanTake = new clsPersonCanTake();

            PersonCanTake.Name = row["TName"]?.ToString(); 
            PersonCanTake.SeltAlkraba = row["SeltAlkraba"]?.ToString();
            PersonCanTake.PhoneNumber = row["TPhoneNumber"]?.ToString();
            PersonCanTake.PersonalCardNumber = row["PersonalCardNumber"]?.ToString();

            if(Child.Save())
            {
                perant.ChildID = Convert.ToInt32(ChildCode);
                perant.Save();
                PersonCanTake.ChildID = ChildCode;
                PersonCanTake.Save();
                clsChildArchiveData.DeleteReocrdFromArchive(ChildCode);
                return true;
            }
            else
                return false;

        }

    }
}
