using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsWorker
    {
        enum enMode { Add,Update}
        enMode mode;
        public int Code { get; set; }
        public string name { get; set; }
        public string Phone { get; set; }
        public string CardNumber { get; set; }       
        public bool Gendor { get; set; }
        public string Image { get; set; }
        public float Salary { get; set; }
        public bool Period { get; set; }

        public clsWorker() 
        {
            this.Code = 0;
            this.name = "";
            this.Phone = "";
            this.CardNumber = "";
            this.Gendor = false;
            this.Image = "";
            this.Salary = 0;
            this.Period = false;
            mode = enMode.Add;
        }

        public clsWorker (int Code,string name, string Phone, string CardNumber, bool Gender, string Image, float Salary, bool Period)
        {
            this.Code = Code;
            this.name = name;
            this.Phone = Phone;
            this.CardNumber = CardNumber;
            this.Gendor = Gender;
            this.Image = Image;
            this.Salary = Salary;
            this.Period = Period;
            mode = enMode.Update;
        }

        public static bool AddWorker(string name, string Phone, string CardNumber, string TimeEnter, string TimeLeave, bool DiscountEnter,
         bool DiscountLeave, bool Gender, string Image, byte AmountID, bool Period)
        {
            return false;
        }
        public static bool UpdateWorkerInfo(int ID, string Name, string Phone, string PersonalCardNumber, bool EnterDiscount, bool LeaveDiscount,
            string TimeEnter, string TimeLeave, bool Gendor, string Image, byte AmountID, bool Period)
        {
            return false;
        }
        private bool _AddWorker()
        {
            return clsWorkerDate.AddWorker(Code, name, Phone, CardNumber,  Gendor, Image, Salary, Period);
        }
        private bool _UpdateWorkerInfo()
        {
            return clsWorkerDate.UpdateWorkerInfo(Code, name, Phone, CardNumber, Gendor, Image, Salary, Period);
        }

        public static clsWorker Find(int Code)
        {
            string name = "", Phone = "", CardNumber = "",  Image="" ;
            bool Gender = false, Period = false;
            float Salary = 0;

            bool found = clsWorkerDate.FindByCode(Code, ref name, ref Phone, ref CardNumber, ref Gender, ref Image, ref Salary, ref Period);

            if (found)
                return new clsWorker(Code, name, Phone, CardNumber, Gender, Image, Salary, Period);
            else
                return null;
        }

        public static clsWorker FindByName(string Name)
        {
            int Code = 0;
            string  Phone = "", CardNumber = "", Image = "";
            bool Gender = false, Period = false;
            float Salary = 0;

            bool found = clsWorkerDate.FindByName(ref Name, ref Code, ref Phone, ref CardNumber, ref Gender, ref Image, ref Salary, ref Period);

            if (found)
                return new clsWorker(Code,Name,  Phone, CardNumber, Gender, Image, Salary, Period);
            else
                return null;
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.Add:
                    if (_AddWorker())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateWorkerInfo();
            }

            return false;
        }

        public static DataTable GetWorkerInfo()
        {
            return clsWorkerDate.GetWorkerInfo();
        }
        public static DataTable GetWorkerListInfo()
        {
            return clsWorkerDate.GetWorkerListInfo();
        }
        public static DataTable GetWorkerListInfo(string Name)
        {
            return clsWorkerDate.GetWorkerListInfo(Name);
        }
        public static bool DeleteWorker(int ID)
        {
            return clsWorkerDate.DeleteWorker(ID);
        }
       
    }
}
