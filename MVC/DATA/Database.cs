using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC.DATA
{
    public class Database
    {
        public static string BMISDatabase => ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        internal static IDisposable GetConnection(object bMIS2DataBase)
        {
            throw new NotImplementedException();
        }

        public static SqlConnection GetConnection(string database)
        {
            return new SqlConnection(database);
        }
    }
}