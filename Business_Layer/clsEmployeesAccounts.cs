using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsEmployeesAccounts
    {
       

        public static DataTable GetEmployeesAmountInfo()
        {
            return clsEmployeesAccountsData.GetEmployeesAmountInfo();
        }

        public static DataTable GetWorkerAmountInfo()
        {
            return clsEmployeesAccountsData.GetWorkerAmountInfo();

        }


        public static bool GetMonthlyAccountData()
        {
            return clsEmployeesAccountsData .AddMonthlyAccountsData();
        }

        public static bool DeleteMonthlyAccountDataForEmployss(string ID, DateTime SalaryMonth)
        {

            return clsEmployeesAccountsData.DeleteMonthlyAccountDataForEmployss(ID, SalaryMonth);
        }

        public static bool DeleteMonthlyAccountDataForWorker(string ID, DateTime SalaryMonth)
        {


            return clsEmployeesAccountsData.DeleteMonthlyAccountDataForWorker(ID,SalaryMonth);
        }


        public static bool AddEmployeesAccountstoHistory(int ID, DateTime Date, float Add, float Dis, float Amount, string Month, DateTime SalaryMonth, char Kind, int UserID)
        {
            return clsEmployeesAccountsData.AddEmployeesAccountstHistory(ID, Date, Add, Dis, Amount, Month, SalaryMonth, Kind,UserID);
        }

        public static DataTable GetEmployeesAccountHistory(char Kind)
        {
            return clsEmployeesAccountsData.GetEmployeesAccountHistory(Kind);
        }
        public static DataTable GetEmployeesAccountHistoryBetweenTwoDate(char Kind,DateTime DateFrom,DateTime DateTo)
        {
            return clsEmployeesAccountsData.GetEmployeesAccountHistoryBetweenTwoDate(Kind,DateFrom, DateTo);
        }
       
    }
}
