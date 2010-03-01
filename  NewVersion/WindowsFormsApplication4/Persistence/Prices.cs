using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class Prices
    {
        public decimal price;
        public DateTime cr1;
        public DateTime cr2;
        public DateTime cr3;
        public bool Enable = true;
        public int priceType = 3;
        public bool isDelete = false;
        public bool isNew = false;
        public Prices(DateTime cri1, DateTime cri2, DateTime cri3, bool enable, int priceT)
        {
            cr1 = cri1;
            cr2 = cri2;
            cr3 = cri3;
            Enable = enable;
            priceType = priceT;
        }
        public Prices(DateTime cri1, DateTime cri2, DateTime cri3)
        {
            cr1 = cri1;
            cr2 = cri2;
            cr3 = cri3;
            Enable = true;
            priceType = 3;
        }

    }
}
