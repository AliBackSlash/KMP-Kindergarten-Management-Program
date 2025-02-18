using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsMainMenue
    {
        public static int TreasuryAmmount()
        {
            return clsMainMenueData.TreasuryAmmount();
        }

        public static int CurrentTreasuryAmmount()
        {
            return clsMainMenueData.CurrentTreasuryAmmount();
        }
    }
}
