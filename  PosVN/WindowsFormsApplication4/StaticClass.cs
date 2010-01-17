using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WindowsFormsApplication4.lic;

namespace WindowsFormsApplication4
{
    class StaticClass
    {
        public static bool isChangeInventory;
        public static bool isAdmin = false;
        public static string cashierId = "";
        public static DataRow thongTinNV = null;
        public static string storeId = "1001";
        public static string stationId = "01";
        public static string stationIdForInvent = "";
        public static string custNum = "101";
        public static DataRow taxRate;
        public static int BackColor = -2894893;
        public static int ForeColor = -16777216;
        public static string Font = "Microsoft Sans Serif";
        public static float FontSize = 14.25F;
        public static byte ScheduleIndex=0;
        public static byte NumberofSettupButonTS = 14;
        public static byte ButtonTypeInventory = 0;
        public static byte ButtonTypeDepartment = 1;
        public static Lc.Version version = Lc.Version.Demo;
        public static int m_Version = 0; 

        #region database
        public static string serverName = "";
        public static string databaseName = "";
        public static string userName = "";
        public static string password = "";
        public static string mode = "";
        #endregion
    }
}
