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
            return clsClassesData.GetClassesMenue();
        }

        public static bool DeleteAllClasses()
        {

            return clsClassesData.DeleteAllClasses();
        }

        public static bool DeleteClasseWithID(int ID)
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


        public static short GetClassID(string Name)
        {
            return clsClassesData.GetClassID(Name);
        }

        public static string GetClassName(short ID)
        {
            return clsClassesData.GetClassName(ID);
        }



    }
}
