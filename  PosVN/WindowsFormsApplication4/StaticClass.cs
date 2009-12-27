using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
        public static string custNum = "101";
        public static DataRow taxRate;
    }
}
