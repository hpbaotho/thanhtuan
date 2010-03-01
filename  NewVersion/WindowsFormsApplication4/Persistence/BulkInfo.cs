using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class BulkInfo
    {
        public decimal bulkPrice;
        public float bulkQuant;
        public bool isDelete = false;
        public bool isNew = false;
        public BulkInfo(float quant,decimal price)
        {
            bulkPrice = price;
            bulkQuant = quant;
        }

    }
}
