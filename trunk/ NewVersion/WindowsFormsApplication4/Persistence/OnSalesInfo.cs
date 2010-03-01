using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class OnSalesInfo
    {
        public DateTime saleStart;
        public DateTime saleEnd;
        public float percent;
        public bool isDelete;
        public bool isNew;
        public OnSalesInfo(DateTime saleS, DateTime saleE, float percen)
        {
            saleStart = saleS;
            saleEnd = saleE;
            percent = percen;
        }
    }
}
