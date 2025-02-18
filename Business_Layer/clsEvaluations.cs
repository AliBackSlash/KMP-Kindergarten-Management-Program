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

        public static bool UpdateDayEvaluationData(string ChildID, string ChildName, short ClassID, bool Gendor)
        {
            return clsEvaluationsData.UpdateDayEvaluationData(ChildID, ChildName, ClassID, Gendor);
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

        public static bool UpdateEvaluationResults(string Code, byte degree)
        {
            return clsEvaluationsData.UpdateEvaluationResults(Code, degree);
        }

        public static bool DeleteFromEvaluationTable(string Code)
        {
            return clsEvaluationsData.DeleteFromEvaluationTable(Code);
        }

        ////.........................///
        public static DataTable GetDayEvaluationInfo()
        {
            return clsEvaluationsData.GetDayEvaluationInfo();
        }

        public static bool ResetDayEvaluationInfo()
        {
            return clsEvaluationsData.ResetDayEvaluationInfo();
        }
        public static bool AddDayEvaluationInfo(string ChildID, string ChildName, byte ClassName, bool Gendor)
        {
            return clsEvaluationsData.AddDayEvaluationInfo(ChildID, ChildName, ClassName, Gendor);
        }

        public static bool UpdateDayEvaluationInfo(string ChildID, bool Degree1, bool Degree2, bool Degree3,
           bool Degree4, bool Degree5, bool Degree6, bool Degree7)
        {
            return clsEvaluationsData.UpdateDayEvaluationInfo(ChildID, Degree1, Degree2, Degree3,
             Degree4, Degree5, Degree6, Degree7);
        }

        public static bool UpdateDayEvaluationInfo(string ChildID, bool Degree1, bool Degree2, bool Degree3,
          bool Degree4, bool Degree5, bool Degree6, bool Degree7, byte TotalDegree)
        {
            return clsEvaluationsData.UpdateDayEvaluationInfo(ChildID, Degree1, Degree2, Degree3,
             Degree4, Degree5, Degree6, Degree7, TotalDegree);
        }

        public static bool GetWinnerKids()
        {
            return clsEvaluationsData  .GetWinnerKids();
        }
    }
}
