using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsPersonCanTake
    {
        public clsPersonCanTake()
        {
            ChildID = "";
            Name = "";
            SeltAlkraba = "";
            PhoneNumber = "";
            PersonalCardNumber = "";
            mode = enMode.Add;
        }

        public clsPersonCanTake(string Code, string Name, string SeltAlkraba, string PhoneNumber, string PersonalCardNumber)
        {
            this.ChildID = Code;
            this.Name = Name;
            this.SeltAlkraba = SeltAlkraba;
            this.PhoneNumber = PhoneNumber;
            this.PersonalCardNumber = PersonalCardNumber;
            mode = enMode.Update;
        }

        enum enMode { Add, Update }
        enMode mode;
        public string ChildID { get; set; }
        public string Name { get; set; }
        public string SeltAlkraba { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalCardNumber { get; set; }

        public static clsPersonCanTake Find(string Code)
        {
            string Name = "", SeltAlkraba = "", PhoneNumber = "", PersonalCardNumber = "";

            bool Found = clsPersonCanTakeData.FindByCode(Code, ref Name, ref SeltAlkraba, ref PhoneNumber, ref PersonalCardNumber);

            if (Found)
                return new clsPersonCanTake(Code, Name, SeltAlkraba, PhoneNumber, PersonalCardNumber);
            else
                return null;

        }

        private bool _Add()
        {
            if (Name != "")
                return clsPersonCanTakeData.AddCanTake(ChildID, Name, SeltAlkraba, PhoneNumber, PersonalCardNumber);
            else
                return false;
        }

        private bool _Update()
        {
            return clsPersonCanTakeData.UpdateCanTake(ChildID, Name, SeltAlkraba, PhoneNumber, PersonalCardNumber);
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.Add:
                    if (_Add())
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

        public static bool ISAlreadyHasPersonCanTake(int Code)
        {
            return clsPersonCanTakeData.ISAlreadyHasPersonCanTake(Code);
        }
    }
}
