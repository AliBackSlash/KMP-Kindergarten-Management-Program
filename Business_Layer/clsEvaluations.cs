using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsEvaluations
    {
        public static DataTable GetEvaluationInfo(short className)
        {
            return clsEvaluationsData.GetEvaluationInfo(className);
        }

        public static DataTable GetWinnerHistory()
        {
            return clsEvaluationsData.GetWinnerHistory();
        }

        public static DataTable GetWinnerCard()
        {
            return clsEvaluationsData.GetWinnerCard();
        }

        public static bool TruncateWinnerHistory()
        {
            return clsEvaluationsData.TruncateWinnerHistory();
        }

       
        public static bool UpdateDayEvaluationInfo(string ChildID, bool Degree1, bool Degree2, bool Degree3,
           bool Degree4, bool Degree5, bool Degree6, bool Degree7)
        {
            return clsEvaluationsData.UpdateDayEvaluationInfo(ChildID, Degree1, Degree2, Degree3,
             Degree4, Degree5, Degree6, Degree7);
        }

        public static bool ResetDally()
        {
            return clsEvaluationsData.ResetDally();
        }

        public static bool GetWinnerKids()
        {
            return clsEvaluationsData  .GetWinnerKids();
        }
    }
}
