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
            return clsClasesData.GetClassesMenue();
        }

        public static bool DeleteAllClasses()
        {

            return clsClasesData.DeleteAllClasses();
        }

        public static bool DeleteClasseWithID(int ID)
        {

            return clsClasesData.DeleteClasseWithID(ID);
        }

        public static bool AddClass(string ClaseName)
        {

            return clsClasesData.AddClass(ClaseName);
        }

        public static bool UpdateClass(byte Code, string ClaseName)
        {

            return clsClasesData.UpdateClass(Code, ClaseName);
        }


        public static short GetClassID(string Name)
        {
            return clsClasesData.GetClassID(Name);
        }

        public static string GetClassName(short ID)
        {
            return clsClasesData.GetClassName(ID);
        }
        public static int NumberOfClases()
        {
            return clsClasesData.NumberOfClases();
        }
        }
}
