using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication4.Utilities;

namespace WindowsFormsApplication4.Persistence
{
    public class Prices
    {
        public decimal price;
        public DateTime cr1;
        public DateTime cr2;
        public string cr3;
        public bool Enable = true;
        public int priceType = 3;
        public bool isDelete = false;
        public bool isNew = false;
        public Prices(decimal pri, DateTime cri1, DateTime cri2, string cri3, bool enable, int priceT)
        {
            price = pri;
            cr1 = cri1;
            cr2 = cri2;
            cr3 = cri3;
            Enable = enable;
            priceType = priceT;
        }
        public Prices(decimal pri, DateTime cri1, DateTime cri2, string cri3)
        {
            price = pri;
            cr1 = cri1;
            cr2 = cri2;
            cr3 = cri3;
            Enable = true;
            priceType = 3;
        }
        public static string translate(string x)
        {

            switch (x)
            {
                case "2":
                    return "Thứ Hai";
                case "3":
                    return "Thứ Ba";
                case "4":
                    return "Thứ Tư";
                case "5":
                    return "Thứ Năm";
                case "6":
                    return "Thứ Sáu";
                case "7":
                    return "Thứ Bảy";
                case "1":
                    return "Chủ nhật";
            }
            return "";
        }

        public override string ToString()
        {
            return "Giá : " + String.Format("{0:0,0}", price) + ", " + translate(cr3) + " " +
                String.Format("{0:HH:mm}", cr1) + " - " + String.Format("{0:HH:mm}", cr2); 
        }

    }
}
