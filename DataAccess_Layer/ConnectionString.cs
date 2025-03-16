using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MyDataAccessLayer
{
    public class ConnectionString
    {
        public static string Connectionstring = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

    }
}
