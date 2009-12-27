using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using DAO;

namespace Services
{
    public class Test
    {
         Server sr;

        public Test()
        {
            sr = new Server();
            sr.Server_name = @"VISKY_THANH\SQLEXPRESS";
            sr.Database_name = "test";
     
        }
        public object get_test()
        {
            SqlCommand cmd=new SqlCommand();
            cmd.Connection = DataProvider.ConnectionData(sr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getMSSV";
            SqlParameter pa=new SqlParameter();
            pa.ParameterName = "@MSSV";
            pa.SqlValue = "50502605";
            cmd.Parameters.Add(pa);
            object t=cmd.ExecuteScalar();
            return t;
        }

        
    }
}
