using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MyBusinessLayer
{
    public class clsUser
    {

        public clsUser()
        {
            Code = -1;
            Name = "";
            UserName = "";
            Password = "";
            Temp = "";
            Pirrimsion = 0;
            ImagePath = "";
            Gendor = false;
            JopName = "";
            mode = enMode.Add;
        }


       
        public clsUser(int iD, string name, string userName, string password, string temp, int pirrimsion,string jopName, string image, bool gendor)
        {
            Code = iD;
            Name = name;
            UserName = userName;
            Password = password;
            Temp = temp;
            Pirrimsion = pirrimsion;
            ImagePath = image;
            Gendor = gendor;
            JopName = jopName;
            mode = enMode.Update;
        }

        enum enMode { Add,Update}
        enMode mode = enMode.Add;
       

        public int Code { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Temp { get; set; }
        public int Pirrimsion { get; set; }

        public string ImagePath { get; set; }
        public string JopName { get;  set; }
        public bool Gendor { get;  set; }


        public static clsUser Find(string UserName, string Password)
        {
            int ID = 0, Pirrimsion=0;
            string Name = "", SecondPassword = "", Image = "", JopName="";
            bool Gendor = false;

            if (clsUsersData.Find(ref ID, ref Name, UserName,
                 Password, ref SecondPassword, ref Pirrimsion,ref JopName, ref Image, ref Gendor))
                return new clsUser(ID, Name, UserName, Password, SecondPassword, Pirrimsion, JopName, Image,Gendor);
            else
                return null;


        }
        public static clsUser Find(string Name)
        {
            int ID = 0, Pirrimsion = 0;
            string  SecondPassword = "", Image = "",NamePassword = "", JopName="", Password = "";
            bool Gendor = false;
            if (clsUsersData.FindFromComboBox(ref ID,ref  Name,ref NamePassword,
                 ref Password, ref SecondPassword, ref Pirrimsion,ref JopName, ref Image,ref Gendor))
                return new clsUser(ID, Name, NamePassword, Password, SecondPassword, Pirrimsion, JopName, Image,Gendor);
            else
                return null;


        }

        public static clsUser Find(int Code)
        {
            int Pirrimsion = 0;
            string Name = "",SecondPassword = "", Image = "", NamePassword = "", JopName="", Password = "";
            bool Gendor = false;

            if (clsUsersData.Find(Code,ref Name, ref NamePassword,
                 ref Password, ref SecondPassword, ref Pirrimsion,ref JopName, ref Image, ref Gendor))
                return new clsUser(Code, Name, NamePassword, Password, SecondPassword, Pirrimsion, JopName, Image,Gendor);
            else
                return null;


        }

        public static bool AddUser(string Name, string UserName, string Password
            , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            return clsUsersData.AddUser(Name, UserName, Password, Temp, Pirrimsion, Image, Gendor, JopName);
        }

        public static bool UpdateUser(int Code, string Name, string UserName, string Password
          , string Temp, int Pirrimsion, string Image, bool Gendor, string JopName)
        {
            return clsUsersData.UpdateUser(Code, Name, UserName, Password, Temp, Pirrimsion, Image, Gendor, JopName);
        }

        private  bool _AddUser()
        {
            return clsUsersData.AddUser(Name, UserName, Password, Temp, Pirrimsion, ImagePath, Gendor, JopName);
        }

        private  bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(Code, Name, UserName, Password, Temp, Pirrimsion, ImagePath, Gendor, JopName);
        }

        public static bool IsUserNameExists(string UserName)
        {
            return clsUsersData.IsUserNameExists(UserName);
        }

        public static bool IsUserNameAndPasswordExistsForThisID(string UserName, string Password, int ID)
        {
            return clsUsersData.IsUserNameAndPasswordExistsForThisID(UserName, Password, ID);

        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.Add:
                    if (_AddUser())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }
        public static DataTable GetUserInfo()
        {
            return clsUsersData.GetUserInfo();
        }


        public static DataTable GetUserInfo(string N)
        {
            return clsUsersData.GetUserInfo(N);
        }
        public static bool DeleteUser(int ID)

        {
            return clsUsersData.DeleteUser(ID);
        }

    }
}
