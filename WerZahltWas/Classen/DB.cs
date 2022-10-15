using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerZahltWas.Classen
{
    public class DB
    {
        
        public static SqlConnection DbCon()
        {
            string conString = ConfigurationManager.ConnectionStrings["WerBezahltWas"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            return con;
        }
    }
}
