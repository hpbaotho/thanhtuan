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

        public BulkInfo(float quant, decimal price,bool isne)
        {
            bulkPrice = price;
            bulkQuant = quant;
            isNew = isne;
        }

        public override string ToString()
        {
            return "Số lượng : " + String.Format("{0:0.##}", bulkQuant) + " - Giá bán : " +
                   String.Format("{0:0,0}", bulkPrice);
        }

    }
}
