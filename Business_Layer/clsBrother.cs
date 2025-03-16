using Microsoft.Win32.SafeHandles;
using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsBrother
    {
        enum enMode { Add, Update }
        enMode mode;
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public int childID { get; set; }

        public clsBrother()
        {
            mode = enMode.Add;
        }

        public clsBrother(int iD, string name, DateTime date, int childID)
        {
            ID = iD;
            Name = name;
            Date = date;
            this.mode = enMode.Update;
            this.childID = childID;
        }
        public  bool Add_Brothers()
        {
            return clsBrothersData.Add_Brothers(this.childID, this.Name, this.Date);
        }

        public  bool Update_Brothers()
        {
            return clsBrothersData.Update_Brothers(this.ID, this.Name, this.Date);
        }
        public static clsBrother Find(int ID)
        {
            string name = "";
            DateTime date = DateTime.Now;
            int ChildID = 0;
            bool Found = clsBrothersData.GetBrotherInfo(ID,ref name,ref date,ref ChildID);

            if (Found)
                return new clsBrother(ID, name, date,ChildID);
            else 
                return null;
        }

        public bool Save()
        {

            switch(mode)
            {
                case enMode.Add:
                    return Add_Brothers();
                case enMode.Update:
                    return Update_Brothers();
            }

            return false;
        }
       
        public static bool delete_BrotherswithChildID(int ID,string Name)
        {
            return clsBrothersData.delete_BrotherswithChildID(ID,Name);
        }
       
        public static DataTable GetChildBrothers(int ID)
        {
            return clsBrothersData.GetChildBrothers(ID);
        }



    }
}
