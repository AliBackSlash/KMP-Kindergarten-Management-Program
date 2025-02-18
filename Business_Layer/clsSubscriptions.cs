using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsSubscriptions
    {
      
        public static DataTable GetChildSubscripInfo()
        {
            return clsSubscriptionsData.GetChildSubscripInfo();
        }
        public static DataTable GetChildSubscripInfo(string Name)
        {
            return clsSubscriptionsData.GetChildSubscripInfo(Name);
        }
        public static DataTable GetPaymentSubscriptionInfo(string Code="")
        {
            return clsSubscriptionsData.GetPaymentSubscriptionInfo(Code);
        }
        public static bool deleteSubscraipPaymentForMonth(string Code)
        {
            return clsSubscriptionsData.deleteSubscraip(Code);
        }
        public static bool GetPaymentSubscriptionInfoDataAndPutTiInSubscraitionPaymentTable()
        {
            return clsSubscriptionsData.GetPaymentSubscriptionInfoDataAndPutItInSubscraitionPaymentTable();
        }

        public static bool AddToPaymentHistory(bool Gendor, string Name, string Level, string Class, bool Period, string Amount
           , DateTime DateOfPayment, string Remander, string Code, string Month, int UserID)
        {
            return clsSubscriptionsData.AddToPaymentHistory(Gendor, Name, Level, Class, Period, Amount, DateOfPayment, Remander, Code, Month,UserID);
        }

        public static bool UpdateRemnderForChild(string Code, string Month,float Amount, int UserID)
        {
            return clsSubscriptionsData.UpdateRemnderForChild(Code, Month, Amount,UserID);
        }

        public static DataTable GetPaymentHistoryInfo()
        {
            return clsSubscriptionsData.GetPaymentHistoryInfo();
        }
    }
}
