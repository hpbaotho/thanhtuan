﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using DAO;
using WindowsFormsApplication4.lic;
using WindowsFormsApplication4.Networking;

namespace WindowsFormsApplication4
{
    class StaticClass
    {
        public static FrmBanHang frmbanhangMain;
        public static bool isChangeInventory;
        public static bool isAdmin = false;
        public static string cashierId = "";
        public static DataRow thongTinNV = null;
        public static string storeId = "1001";
        public static string stationId = "01";
        public static string stationIdForInvent = "";
        public static string custNum = "101";
        public static DataRow taxRate;
        public static int BackColor = -8355712;
        public static int BackColorDept = -32768;
        public static int ForeColor = -16777216;
        public static int Form_Color = 12632256;
        public static string Font = "Microsoft Sans Serif";
        public static float FontSize = 14.25F;
        public static byte ScheduleIndex=0;
        public static byte NumberofSettupButonTS = 14;
        public static byte ButtonTypeInventory = 0;
        public static byte ButtonTypeDepartment = 1;
        public static Lc.Version version = Lc.Version.Demo;
        public static int m_Version = 0;
        public static ClientNetwork socket;
        #region database

        public static Server RPServer;
        public static string serverName = "";
        public static string databaseName = "";
        public static string userName = "";
        public static string password = "";
        public static string mode = "";
        #endregion
    }
}
