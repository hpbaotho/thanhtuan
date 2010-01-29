using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using PCARegHelper;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication4.lic
{
    class Sc
    {
        public static string showMac()
        {
            string str = "";
            foreach (NetworkAdapter adapter in NetworkAdapter.GetInstances("MACAddress IS NOT NULL"))
            {
                //DebugLog("isMACValid Net.Manufacturer = " + adapter.Manufacturer + " net.IsInstalledNull = " + adapter.IsInstalledNull.ToString() + " net.Name = " + adapter.Name.ToString());
                if (IsValidNetworkAdapter(adapter))
                {
                    str = CovertMacToBase36String(adapter.MACAddress);
                    //DebugLog("isMACValid thisBase36MAC: " + str);
                    //if (StringType.StrCmp(base36MAC, Strings.Right(str, 5), false) == 0)
                    //{

                    //}
                    //textBox1.Text = str;
                    //MessageBox.Show(Microsoft.VisualBasic.Strings.Right(str, 5));
                    //long code = 0;
                    //Radix.Decode(str, 0x24L, ref code);
                    //return code.ToString();
                    return Strings.Right(str, 5);
                }
            }
            return "";

        }
        private static string CovertMacToBase36String(string MacAddr)
        {
            return CovertMacToBase36String(GetMacValue(MacAddr));
        }
        private static string CovertMacToBase36String(long MacAddr)
        {
            return Radix.Encode(MacAddr, 0x24L);
        }

        private static long GetMacValue(string MacAddr)
        {
            byte[] buffer = new byte[8];
            string[] strArray = MacAddr.Split(new char[] { ':' });
            int index = 0;
            do
            {
                buffer[index] = byte.Parse(strArray[index], NumberStyles.HexNumber);
                index++;
            }
            while (index <= 5);
            buffer[6] = 0;
            buffer[7] = 0;
            return BitConverter.ToInt64(buffer, 0);
        }
        public static bool IsValidNetworkAdapter(NetworkAdapter net)
        {
            //DebugLog("IsValidNetworkAdapter - Checking if adapter is valid: Manufacturer=" + net.Manufacturer + " PNPDeviceID= " + net.PNPDeviceID + " Name=" + net.Name + " ProductName=" + net.ProductName + " Caption=" + net.Caption + " Description=" + net.Description);
            bool flag2 = ((((StringType.StrCmp(net.Manufacturer, "", false) > 0) && net.Installed) && ((StringType.StrCmp(net.PNPDeviceID, "", false) > 0) && (net.Name.ToUpper().IndexOf("VPN") == -1))) && (((net.ProductName.ToUpper().IndexOf("VPN") == -1) && (net.Caption.ToUpper().IndexOf("VPN") == -1)) && ((net.Description.ToUpper().IndexOf("VPN") == -1) && (net.Name.ToUpper().IndexOf("VIRTUAL") == -1)))) && ((((net.ProductName.ToUpper().IndexOf("VIRTUAL") == -1) && (net.Caption.ToUpper().IndexOf("VIRTUAL") == -1)) && ((net.Description.ToUpper().IndexOf("VIRTUAL") == -1) && (net.Name.ToUpper().IndexOf("MINIPORT") == -1))) && (((net.ProductName.ToUpper().IndexOf("MINIPORT") == -1) && (net.Caption.ToUpper().IndexOf("MINIPORT") == -1)) && (net.Description.ToUpper().IndexOf("MINIPORT") == -1)));
            //DebugLog("IsValidNetworkAdapter result=" + flag2.ToString());
            return flag2;
        }

        public static long SC()
        {
            string sc = "";
            sc += showMac();

            string a = FillCharacter(SystemInfo.RunQuery("Processor", "ProcessorId"), 3);
            string b = FillCharacter(SystemInfo.RunQuery("BaseBoard", "Product"), 3);
            sc += a + b;
            long code = 0;
            Radix.Decode(sc, 0x24L, ref code);
            return code;

        }
        public static string FillCharacter(string str,int num)
        {
            if(str.Length < num)
            {
                for (int i = 1; i < num - str.Length; i++)
                {
                    str = "0" + str;
                }
            }
            else
            {
                str = Strings.Right(str, num);
            }
            return str;
        }
    }
}
