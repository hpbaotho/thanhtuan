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
            try
            {
                string cnStr = "";
                if (ser.Mode == "AUT")
                {
                    cnStr = @"Server =" + ser.Server_name + @";Database = " + ser.Database_name + @"; Integrated Security = True; Asynchronous Processing = True";
                    cn = new SqlConnection(cnStr);
                    cn.Open();
                    return cn;
                }
                else if (ser.Mode == "SQL")
                {
                    cnStr = @"Server =" + ser.Server_name + @";Database = " + ser.Database_name + @"; User ID=" + ser.UserName + ";Password=" + ser.Password + ";Trusted_Connection=False;";
                    cn = new SqlConnection(cnStr);
                    cn.Open();
                    return cn;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SqlConnection ConnectionData(Server ser,string mode,string username,string pass)
        {
            try
            {
                string cnStr = "";
                if (mode == "AUT")
                {
                    cnStr = @"Server =" + ser.Server_name + @";Database = " + ser.Database_name + @"; Integrated Security = True; Asynchronous Processing = True";
                    cn = new SqlConnection(cnStr);
                    cn.Open();
                    return cn;
                }
                else if (mode == "SQL")
                {
                    cnStr = @"Server =" + ser.Server_name + @";Database = " + ser.Database_name + @"; User ID="+username+";Password="+pass +";Trusted_Connection=False;";
                    cn = new SqlConnection(cnStr);
                    cn.Open();
                    return cn;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public static void close_connection()
        {
            if(cn.State==ConnectionState.Open)
                cn.Close();

        }
        public static bool TestConnection(string mode,string serverName,string databaseName,string userName,string pass)
        {
            try
            {
                if(mode == "AUT")
                {
                    string cnStr = @"Server =" + serverName + @";Database = " + databaseName + @"; Integrated Security = True; Asynchronous Processing = True";
                    cn = new SqlConnection(cnStr);
                    cn.Open();
                    cn.Close();
                }   
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
