using MyDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MyBusinessLayer
{
    public class clsChild
    {
        enum enMode { Add,Update}

        enMode mode;
        public int Code { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool period{ get; set; }
        public short levelID { get; set; }
        public short classID { get; set; }
        public string levelName { get; set; }
        public string className { get; set; }
        public int PerantID { get; set; }  
        public clsPerant perant { get; set; }
        public DateTime dateOfJoin { get; set; }
        public string bus { get; set; }
        public string branch { get; set; }
        public bool gendor { get; set; }
        public string image { get; set; }
        public byte howYouKnowNurssry { get; set; }
        public byte socialStatus { get; set; }
        public string messageNumber { get; set; }
        public string mail { get; set; }
        public string infoAboutChild { get; set; }
        public float SubAmount { get; set; }
        public clsPersonCanTake personCanTake {  get; set; }
        public clsChild()
        {
            Code = 0;
            this.name = "";
            this.city = "";
            this.address = "";
            this.dateOfBirth = DateTime.Now;
            this.period = false;
            this.levelID = 0;
            this.classID = 0; 
            this.levelName = "";
            this.className = "";
            this.dateOfJoin = DateTime.Now;
            this.bus = "";
            this.branch = ""; ;
            this.gendor = false;
            this.image = ""; ;
            this.howYouKnowNurssry = 0;
            this.socialStatus = 0;
            this.messageNumber = ""; ;
            this.mail = ""; ;
            this.infoAboutChild = ""; ;
            this.SubAmount = 0;

            mode = enMode.Add;
        }
        public clsChild(int code, string name, string city, string address, 
            DateTime dateOfBirth, bool period,int PerantID, short levelID, short classID, 
            DateTime dateOfJoin, string bus, string branch, bool gendor, string
            image, byte howYouKnowNurssry, byte socialStatus, string messageNumber,
            string mail, string infoAboutChild, float subscID)
        {
            Code = code;
            this.name = name;
            this.city = city;
            this.address = address;
            this.dateOfBirth = dateOfBirth;
            this.period = period;
            this.levelID = levelID;
            this.levelName = clsLevels.GetLevelName(levelID);
            this.classID = classID;
            this.className = clsClsases.GetClassName(classID);
            this.dateOfJoin = dateOfJoin;
            this.PerantID = PerantID;
            perant = clsPerant.Find(PerantID);
            this.bus = bus;
            this.branch = branch;
            this.gendor = gendor;
            this.image = image;
            this.howYouKnowNurssry = howYouKnowNurssry;
            this.socialStatus = socialStatus;
            this.messageNumber = messageNumber;
            this.mail = mail;
            this.infoAboutChild = infoAboutChild;
            this.SubAmount = subscID;
            personCanTake = clsPersonCanTake.Find(code.ToString());
            mode = enMode.Update;

        }

        private bool _AddChild()
        {
            return clsChildData.AddNewChaild(Code, this.name, this.city, this.address, this.dateOfBirth, this.period, this.levelID
            , this.classID, this.dateOfJoin, this.bus, this.branch, this.gendor, this.image, this.howYouKnowNurssry, this.socialStatus
            , this.messageNumber, this.mail, this.infoAboutChild, this.SubAmount);

        }

        private bool _Update()
        {
            return clsChildData.UpdateChildInfo(Code, this.name, this.city, this.address, this.dateOfBirth, this.period, this.levelID
            , this.classID, this.dateOfJoin, this.bus, this.branch, this.gendor, this.image, this.howYouKnowNurssry, this.socialStatus
            , this.messageNumber, this.mail, this.infoAboutChild, this.SubAmount);
        }

        public static clsChild FindByCode(int Code)
        {
            string name = "" ,  city = "",  address = ""
            ,  bus = "",  branch = ""   ,  image = "",  messageNumber = "", mail = "", infoAboutChild = "";
            byte howYouKnowNurssry = 0,  socialStatus = 0;            
            bool gendor = false;
            DateTime dateOfJoin = DateTime.Now;
            bool period =false;
            short levelID = 0;
            DateTime dateOfBirth = dateOfJoin;
            float SubscID = 0;
            short classID = 0;
            int PerantID = 0;
            bool found = clsChildData.FindByCode(Code,ref name, ref city, ref address, ref dateOfBirth, ref period,ref PerantID, ref levelID
            , ref classID, ref dateOfJoin, ref bus, ref branch, ref gendor, ref image, ref howYouKnowNurssry, ref socialStatus
            , ref messageNumber, ref mail, ref infoAboutChild, ref SubscID);

            if (found)
                return new clsChild(Code, name, city, address, dateOfBirth, period, PerantID, levelID
            , classID, dateOfJoin, bus, branch, gendor, image, howYouKnowNurssry, socialStatus
            , messageNumber, mail, infoAboutChild, SubscID);
            else
                return null;
        }
        public static clsChild FindByName(string Name)
        {
            int Code = 0;
            string city = "", address = ""
            , bus = "", branch = "", image = "", messageNumber = "", mail = "", infoAboutChild = "";
            byte howYouKnowNurssry = 0, socialStatus = 0;
            bool gendor = false;
            DateTime dateOfJoin = DateTime.Now;
            bool period = false;
            short levelID = 0;
            DateTime dateOfBirth = dateOfJoin;
            float SubscID = 0;
            short classID = 0;
            int PerantID = 0;

            bool found = clsChildData.FindByName(ref Code, ref Name, ref city, ref address, ref dateOfBirth, ref period,ref PerantID, ref levelID
            , ref classID, ref dateOfJoin, ref bus, ref branch, ref gendor, ref image, ref howYouKnowNurssry, ref socialStatus
            , ref messageNumber, ref mail, ref infoAboutChild, ref SubscID);

            if (found) 
                return new clsChild(Code, Name, city, address, dateOfBirth, period,PerantID, levelID
            , classID, dateOfJoin, bus, branch, gendor, image, howYouKnowNurssry, socialStatus
            , messageNumber, mail, infoAboutChild, SubscID);
            else
                return null;
        }
        public bool Save()
        {
            switch(mode)
            {
                case enMode.Add:
                    if (_AddChild())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _Update();
            }

            return false;
        }
        public static DataTable GetKidsMenue()
        {
            return clsChildData.GetKidsMenue();
        }

        public static DataTable GetKidsMenue(string Name)
        {
            return clsChildData.GetKidsMenue(Name);
        }
        //
        public static DataTable GetKidsPersonalDataWithName(string Name)
        {
            return clsChildData.GetKidsCodeAndImagePathNameAndCode(Name);
        }
        //
       
        public static bool DeleteChildWhithAllInfo(int ID, string PerantID)
        {
            return clsChildData.DeleteChildWhithAllInfo(ID, PerantID);
        }

        public static DataTable GetKidsBirthDateNotification()
        {
            return clsChildData.GetKidsBirthDateNotification();
        }

        public static bool SetActiveChild(bool IsActive, int ID)
        {
           return clsChildData.SetActiveChild(IsActive, ID);
        }

        public static DataTable GetArchiveMenue()
        {
            return clsChildData.GetUnActiveMenue();
        }

        public static DataTable GetArchiveMenue(string Name)
        {
            return clsChildData.GetUnActiveMenue(Name);
        }

        public static int NumberOfKids()
        {
            return clsChildData.NumberOfKids();

        }

    }
}
