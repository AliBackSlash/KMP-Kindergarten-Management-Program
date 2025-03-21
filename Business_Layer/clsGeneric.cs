using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsGeneric
    {
        //
        public static int GetNumberOfAttendedMember(char Kind)
        {
            return clsGenericData.GetNumberOfAttendedMember(Kind);
        }

        //
        public static DataTable FillComboBoxWithNames(string query)
        {
            return clsGenericData.FillComboBoxWithNames(query);
        }

        public static DataTable ReturnGroupOfDataIWant(string query)
        {
            return clsGenericData.ReturnGroupOfDataIWant(query);
        }

        public static string ReturnLastValueIWant(string query)
        {
            return clsGenericData.ReturnLastValueIWant(query);
        }

        public static int ReturnLastValueIWantINT(string query)
        {
            return clsGenericData.ReturnLastValueIWantINT(query);
        }


        public static bool DeleteTableData(string query)
        {
            return clsGenericData.DeleteTableData(query);
        }
       
        public static bool Reset(string Column, string date)
        {
            return clsGenericData.UpdateDateOfOpen(Column, date);
        }

        public static string ReturnLastDateOfOpen(string query)
        {
            return clsGenericData.ReturnLastDateOfOpen(query);
        }

        public static string ReturnLastID(string query)
        {
            return clsGenericData.ReturnLastID(query);
        }
    }
}
