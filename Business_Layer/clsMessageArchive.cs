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
    public class clsMessageArchive
    {
        public static bool AddToMessage_Archive(string Name, char Through, string MessageContant, char Kind)
        {

           return clsMessageArchiveData.AddToMessage_Archive(Name,  Through, MessageContant, Kind);
        }

        public static DataTable GetMessage_Archive(char Kind,string Name="")
        {
            return clsMessageArchiveData.GetMessage_Archive(Kind,Name);
        }

        public static bool DeleteAll()
        {
            return clsMessageArchiveData.DeleteAll();
        }
    }
}
