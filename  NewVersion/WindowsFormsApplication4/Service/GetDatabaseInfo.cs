using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace WindowsFormsApplication4.Service
{
    class GetDatabaseInfo
    {
        OleDbConnection m_cnADONetConnection = new OleDbConnection();
        OleDbDataAdapter m_daDataAdapter;
        OleDbCommandBuilder m_cbCommandBuilder;
        DataTable m_dtDict = new DataTable();
        public string serverName;
        public string databaseName;
        public string mode;
        public string user;
        public string pass;
        public bool isconfiged;

        public GetDatabaseInfo()
        {
            m_cnADONetConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\ConfigDatabase.mdb";

            m_cnADONetConnection.Open();
            m_daDataAdapter = new OleDbDataAdapter("Select * From DatabaseInfo", m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_daDataAdapter);
            m_daDataAdapter.Fill(m_dtDict);
            if (m_dtDict.Rows.Count != 0)
            {
                mode = StaticClass.mode = m_dtDict.Rows[0]["Mode"].ToString();
                if (m_dtDict.Rows[0]["InstanceName"].ToString() == "")
                {
                    serverName= StaticClass.serverName = m_dtDict.Rows[0]["ServerName"].ToString();
                }
                else
                {
                   serverName=  StaticClass.serverName = m_dtDict.Rows[0]["ServerName"].ToString() + "\\" + m_dtDict.Rows[0]["InstanceName"].ToString();
                }

                databaseName = StaticClass.databaseName = m_dtDict.Rows[0]["DatabaseName"].ToString();
                Services.get_GUI.serverName = StaticClass.serverName;
                Services.get_GUI.databaseName = StaticClass.databaseName;
                isconfiged = true;
                if(mode == "SQL")
                {
                    user = StaticClass.userName = m_dtDict.Rows[0]["UserID"].ToString();
                    pass = StaticClass.password = m_dtDict.Rows[0]["Password"].ToString();
                }
                else
                {
                    user = StaticClass.userName = "";
                    pass = StaticClass.password = "";
                }

            }
            else
            {
                isconfiged = false;
            }
        }

        public static string[] getLocalServer()
        {
            DataTable dt = SmoApplication.EnumAvailableSqlServers();
            string[] szSQLInstanceNames = new string[dt.Rows.Count];
            StringBuilder szSQLData = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        szSQLInstanceNames[i] = dr["Name"].ToString();
                        Server oServer;
                        oServer = new Server(szSQLInstanceNames[i]);
                        if (string.IsNullOrEmpty(dr["Instance"].ToString()))
                        {
                            szSQLInstanceNames[i] = szSQLInstanceNames[i] + "\\MSSQLSERVER";
                        }
                        szSQLData.AppendLine(szSQLInstanceNames[i] + "  Version: " + oServer.Information.Version.Major +
                                             "  Service Pack: " + oServer.Information.ProductLevel + "  Edition: " +
                                             oServer.Information.Edition + "  Collation: " +
                                             oServer.Information.Collation);
                    }
                    catch (Exception Ex)
                    {
                        szSQLData.AppendLine("Exception occured while connecting to " + szSQLInstanceNames[i] + " " +
                                             Ex.Message);
                    }

                    i++;
                }

            }
            return szSQLInstanceNames;

        }


    }
}
