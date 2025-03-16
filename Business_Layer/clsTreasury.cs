using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsTreasury
    {
        public static DataTable GetMonthlyData(string Day = "")
        {

           return clsTreasuryData.GetMonthlyData(Day);

        }
        public static bool AddToTreasuryMonthlyData(float Amount, char Kind, bool Trunsaction, int UserID, int MemberID)
        {
            return clsTreasuryData.AddToTreasuryMonthlyData(Amount, Kind, Trunsaction, UserID, MemberID);
        }

        public static DataTable GetMonthlyData(char Trunsaction,string Day = "")
        {

            return clsTreasuryData.GetMonthlyDataOrder(Trunsaction,Day);

        }

        public static DataTable GetYearlyData(string Day = "")
        {
           return clsTreasuryData.GetYearlyData(Day);
        }

        public static DataTable GetYearlyDataOrder(char Trunsaction)
        {
            return clsTreasuryData.GetYearlyDataOrder(Trunsaction);


        }

        public static DataTable GetYearlyDataOrderForMonth(string Month, char Trunsaction = '\0')
        {
            return clsTreasuryData.GetYearlyDataOrderForMonth(Month,Trunsaction);
        }
       
        public static DataTable GetCurrentMonthes()
        {
            return clsTreasuryData.GetCurrentMonthes();

        }
        public static DataTable GetYearlyData(string Month, string Day,char Trunsaction='\0')
        {
           return clsTreasuryData.GetYearlyData(Month,Day, Trunsaction);
        }
        public static DataTable GetYearlyDataOrder(char Trunsaction, string Month, string Day)
        {
            return clsTreasuryData.GetYearlyDataOrder(Trunsaction,Month,Day);
        }

        public static bool ResetTreasury()
        {
            string Month = DateTime.Now.Month.ToString();
            bool Success = false;
            if (clsGeneric.ReturnLastDateOfOpen("select DateOfResetTrueasury from DateOpen") != Month)
            {
                if (clsTreasuryData.MoveMonthlyToYearlyTreasury() && clsTreasuryData.SaveTreasuryHistoryData())
                {
                    Success = true;
                    clsGeneric.Reset("DateOfResetTrueasury", Month);
                }
               else
                    Success = false;
            }
            return Success;
          
        }

        public static DataTable GetHistory()
        {
            return clsTreasuryData.GetHistory();
        }
        public static bool ClearHistory()
        {

            return clsTreasuryData.ClearHistory();
        }

        public static bool ClearYearlyData()
        {

            return clsTreasuryData.ClearYearlyData();
        }
    }
}
