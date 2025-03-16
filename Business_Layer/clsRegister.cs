using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsRegistersAndOperation
    {
        public static bool AddRegister(int Code, bool IsEnter)
        {
            return clsRegistersAndOperationsData.AddRegister(Code, IsEnter);
        }

        public static DataTable GetAllRegisters(string UserName="")
        {
            return clsRegistersAndOperationsData.GetAllRegisters(UserName);
        }

        public static DataTable GetAllRegisters(DateTime DateFrom, DateTime DateTo, string UserName)
        {
            return clsRegistersAndOperationsData.GetAllRegisters( DateFrom,  DateTo,  UserName);
        }

        public static bool DeleteAllRegisters()
        {
            return clsRegistersAndOperationsData.DeleteAllRegisters();
        }
    }
}
