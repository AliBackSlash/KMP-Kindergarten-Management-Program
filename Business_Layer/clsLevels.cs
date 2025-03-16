using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsLevels
    {
        public static bool AddLevel(string LevelName, string Contant)
        {
            return clsLevelsData.AddLevel(LevelName, Contant);
        }

        public static bool UpdateLevel(short Code, string LevelName, string Contant)
        {
            return clsLevelsData.UpdateLevel(Code, LevelName, Contant);
        }

        public static DataTable GetLevels()
        {
            return clsLevelsData.GetLevels();
        }

        public static bool DeleteAllLevels()
        {

            return clsLevelsData.DeleteAllLevels();
        }

        public static bool DeleteLevelWithID(byte ID)
        {

            return clsLevelsData.DeleteLevelWithID(ID);
        }


        public static short GetLevelID(string Name)
        {
            return clsLevelsData.GetLevelID(Name);
        }

        public static string GetLevelName(short ID)
        {
            return clsLevelsData.GetLevelName(ID);
        }

    }
}
