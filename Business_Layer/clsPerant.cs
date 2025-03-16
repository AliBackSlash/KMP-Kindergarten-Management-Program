using MyDataAccessLayer;

namespace MyBusinessLayer
{
    public class clsPerant
    {
        public clsPerant()
        {
            ChildID = -1;
            FatherName  = "";
            FatherJop   = "";
            MotherName  = "";
            MotherJop   = "";
            MPhone      = "";
            PhoneNumber = "";
            mode = enMode.Add;
        }

        public clsPerant(int Code, string FatherName, string FatherJop, string MotherName, string MotherJop, string MPhone, string PhoneNumber)
        {
            this.ChildID = Code;
            this.FatherName = FatherName;
            this.FatherJop = FatherJop;
            this.MotherName = MotherName;
            this.MotherJop = MotherJop;
            this.MPhone = MPhone;
            this.PhoneNumber = PhoneNumber;
            mode = enMode.Update;
        }

        enum enMode { Add,Update}
        enMode mode;
        public int ChildID { get; set; }
        public string FatherName { get; set; }
        public string FatherJop { get; set; }
        public string MotherName { get; set; }
        public string MotherJop { get; set; }
        public string MPhone { get; set; }
        public string PhoneNumber { get; set; }

        public static clsPerant Find(int Code)
        {
            string FatherName = "", FatherJop = "", MotherName = "", MotherJop = "", MPhone = "", PhoneNumber = "";

            bool Found = claPerantData.FindByCode(Code, ref FatherName, ref FatherJop, ref MotherName, ref MotherJop, ref MPhone, ref PhoneNumber);

            if (Found)
                return new clsPerant(Code, FatherName, FatherJop, MotherName, MotherJop, MPhone, PhoneNumber);
            else
                return null;

        }

        private bool _Add()
        {
            if (FatherName != "")
                return claPerantData.AddParent(ChildID, FatherName, FatherJop, MotherName, MotherJop, MPhone, PhoneNumber);
            else
                return false;

        }

        private bool _Update()
        {
            return claPerantData.UpdateParent(ChildID, FatherName, FatherJop, MotherName, MotherJop, MPhone, PhoneNumber);
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.Add:
                    if(_Add())
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

        public static bool ISAlreadyHasPerantInSystem(int Code)
        {
            return claPerantData.ISAlreadyHasPerantInSystem(Code);
        }
    }
}
