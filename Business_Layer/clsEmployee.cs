using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Xml;
using System.Security.AccessControl;

namespace MyBusinessLayer
{
    public class clsEmployee
    {
        enum enMode { add,update}
        enMode mode;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string School { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public byte SocialStatus { get; set; }      
        public string Image { get; set; }
        public bool Gendor { get; set; }
        public bool Period { get; set; }
        public float Salary { get; set; }
        public short ClassID { get; set; }
        public short LevelID { get; set; }
        public string ClassName { get; set; }
        public string LevelName { get; set; }

        public clsEmployee()
        {
            ID = 0;
            Name = "";
            Qualification = ""; 
            School = "";
            CardNumber = "";
            Email ="";
            Phone ="";
            DateOfBirth = DateTime.Now;
            Address = "";
            SocialStatus = 0;
            Image ="";
            Gendor = false;
            Period = false;
            Salary =  0;
            ClassID = -1;
            LevelID = -1;
            ClassName = "";
            LevelName = "";
            mode = enMode.add;
        }
        public clsEmployee(int Id,string name, string qulification, string school, string cardNumber,
            string email, string phone, DateTime dateOfBirth, string address, byte socialStatus, string image,
            bool gendor, bool period, float salary, short classID, short levelID)
        {
            ID = Id;
            Name = name;
            Qualification = qulification;
            School = school;
            CardNumber = cardNumber;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Address = address;
            SocialStatus = socialStatus;
            Image = image;
            Gendor = gendor;
            Period = period;
            Salary = salary;
            ClassID = classID;
            LevelID = levelID;
            ClassName = clsClsases.GetClassName(classID);
            LevelName = clsLevels.GetLevelName(levelID);
            mode = enMode.update;
        }

        public static bool AddTeacher(string name, string Qulification, string School, string Graduation, string CardNumber
                              , string Email, string Phone, string DateOfBirth, string Address, string SocialStatus, string TimeEnter,
                              string TimeLeave, bool DiscountEnter, bool DiscountLeave, string Image, bool Gendor, bool Period, byte AmountID, short ClassID, short LevelID)
        {
            return false;
        }
        public static bool UpdateTeacherInfo(int ID, string Name, string Qualification, string School, string GraduationDate, string PersonalCardNumber, string Email,
          string PhoneNumber, string DateOfBirth, string Address, string SocialStutas, string TimeEnter, string TimeLeave, bool EnterDiscount, bool LeaveDiscount, string Image, short LevelID,
          short ClassID, bool Gendor, bool Period, byte AmountID)

        {
            return false;

        }

        //new
        public static clsEmployee Find(int Code)
        {
            string Name ="", Qulification = "", School = "", CardNumber = ""
                               , Email = "", Phone = "", Address = "", 
                                 Image = ""  ;
            DateTime DateOfBirth = DateTime.Now;
            bool Gendor= false, Period = false;
            float Salary=0;
            short ClassID =0, LevelID = 0;
            byte SocialStatus = 0;

            bool found = clsEmployeeData.FindByCode(Code,ref Name,ref Qulification,ref School,ref CardNumber
                               ,ref Email,ref Phone,ref DateOfBirth,ref Address,ref SocialStatus,
                                 ref Image,ref Gendor,ref Period,ref Salary,ref ClassID,ref LevelID);

            if (found)
                return new clsEmployee(Code, Name, Qulification, School, CardNumber
                                , Email, Phone, DateOfBirth, Address, SocialStatus,
                                  Image, Gendor, Period, Salary, ClassID, LevelID);
            else
                return null;
        }

        public static clsEmployee FindByName(string Name)
        {
            int Code = 0;
            string  Qulification = "", School = "", CardNumber = ""
                               , Email = "", Phone = "", Address = "",
                                 Image = "";
            DateTime DateOfBirth = DateTime.Now;
            bool Gendor = false, Period = false;
            float Salary = 0;
            short ClassID = 0, LevelID = 0;
            byte SocialStatus = 0;

            bool found = clsEmployeeData.FindByName(ref Name, ref Code, ref Qulification, ref School, ref CardNumber
                               , ref Email, ref Phone, ref DateOfBirth, ref Address, ref SocialStatus,
                                 ref Image, ref Gendor, ref Period, ref Salary, ref ClassID, ref LevelID);

            if (found)
                return new clsEmployee(Code, Name, Qulification, School, CardNumber
                                , Email, Phone, DateOfBirth, Address, SocialStatus,
                                  Image, Gendor, Period, Salary, ClassID, LevelID);
            else
                return null;
        }
        //new
        private bool _AddTeacher()
        {
            return clsEmployeeData.AddTeacher(ID, Name, Qualification, School, CardNumber
                               , Email, Phone, DateOfBirth, Address, SocialStatus, 
                                 Image, Gendor, Period,Salary,  ClassID, LevelID);
        }
        //new
        private bool _UpdateTeacherInfo()

        {
            return clsEmployeeData.UpdateTeacher( ID, Name,  Qualification,  School,  CardNumber
                                                  ,  Email,  Phone,  DateOfBirth,  Address,  SocialStatus,
                                                   Image,  Gendor,  Period,  Salary,  ClassID,  LevelID);

        }
        //new
        public bool Save()
        {
            switch(mode)
            {
                case enMode.add:
                    if (_AddTeacher())
                    {
                        mode = enMode.update;
                        return true;
                    }
                    else
                        return false;
                case enMode.update:
                    return _UpdateTeacherInfo();
            }

            return false;
        }
        
        public static DataTable GetTeacherInfo()
        {
            return clsEmployeeData.GetTeacherInfo();
        }
        public static DataTable GetTeacherListInfo()
        {
            return clsEmployeeData.GetTeacherListInfo();
        }
        public static DataTable GetTeacherListInfo(string Name)
        {
            return clsEmployeeData.GetTeacherListInfo(Name);
        }
        public static bool DeleteTeacher(int ID)
        {
            return clsEmployeeData.DeleteTeacher(ID);
        }
       
    }
}
