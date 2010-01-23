using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class Printer
    {
        public string PrinterName;
        public string LocalPort;
        public string NetworkPort;
        public string Details;
        public bool Disable;
        public bool Two_Color;
        public bool Cut_Print;
        public bool isNew = false;
        public bool isDelete = false;
        public Printer(string pName,string localp,string netp,string detail,bool disable,bool twoColor,bool cutprint)
        {
            PrinterName = pName;
            LocalPort = localp;
            NetworkPort = netp;
            Details = detail;
            Two_Color = twoColor;
            Disable = disable;
            Cut_Print = cutprint;
            isNew = false;
            isDelete = false;
        }
        public Printer(string pName)
        {
            PrinterName = pName;
            isNew = false;
            isDelete = false;
        }
        public override string ToString()
        {
            return PrinterName;
        }
    }
}
