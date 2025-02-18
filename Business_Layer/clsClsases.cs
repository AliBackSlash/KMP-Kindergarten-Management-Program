using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsClsases
    {
        public static DataTable GetClassesInfo()
        {
            return clsClassesData.GetClassesInfo();
        }

        public static bool DeleteAllClasses()
        {

            return clsClassesData.DeleteAllClasses();
        }

        public static bool DeleteClasseWithID(byte ID)
        {

            return clsClassesData.DeleteClasseWithID(ID);
        }

        public static bool AddClass(string ClaseName)
        {

            return clsClassesData.AddClass(ClaseName);
        }

        public static bool UpdateClass(byte Code, string ClaseName)
        {

            return clsClassesData.UpdateClass(Code, ClaseName);
        }


    }
}
