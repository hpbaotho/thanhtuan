using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WindowsFormsApplication4.Utilities
{
    public static class GetIP
    {
        public static string getIP()
        {
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }
    }
}
