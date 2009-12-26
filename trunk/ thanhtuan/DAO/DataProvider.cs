using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DAO
{
    public class DataProvider
    {
        //private Server ser;
        private static SqlConnection cn;
        public static SqlConnection ConnectionData(Server ser)
        {      
            string cnStr = @"Server =" +  ser.Server_name+  @";Database = " + ser.Database_name+  @"; Integrated Security = True; Asynchronous Processing = True";
            cn = new SqlConnection(cnStr);
            cn.Open();
            return cn;
        }
        public static void close_connection()
        {
            if(cn.State==ConnectionState.Open)
                cn.Close();

        }
    }
}
