using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Services;

namespace WindowsFormsApplication4.Persistence
{
    class SpecialPricing
    {
        public ArrayList BulkInfoList;
        public ArrayList OnSaleInfoList;
        public ArrayList PricesList;
        public get_GUI getGui;
        public string ItemNum;

        public SpecialPricing(string itemNum)
        {
            ItemNum = itemNum;
            getGui = new get_GUI();
            BulkInfoList = new ArrayList();
            OnSaleInfoList = new ArrayList();
            PricesList = new ArrayList();
            DataTable sale = getGui.GetBulkInfo(StaticClass.storeId, itemNum);
            if(sale != null)
            {
                for (int i = 0; i < sale.Rows.Count; i++)
                {
                    BulkInfo bulkInfo = new BulkInfo(Convert.ToSingle(sale.Rows[i]["Bulk_Quan"]), Convert.ToDecimal(sale.Rows[i]["Bulk_Price"]));
                    BulkInfoList.Add(bulkInfo);
                }
            }
            sale = getGui.GetOnsaleInfo(StaticClass.storeId, itemNum);
            if (sale != null)
            {
                for (int i = 0; i < sale.Rows.Count; i++)
                {
                    OnSalesInfo onSalesInfo = new OnSalesInfo(Convert.ToDateTime(sale.Rows[i]["Sale_Start"]), Convert.ToDateTime(sale.Rows[i]["Sale_End"]), Convert.ToSingle(sale.Rows[i]["Percent"]));
                    OnSaleInfoList.Add(onSalesInfo);
                }
            }

            sale = getGui.GetPrices(StaticClass.storeId, itemNum);
            if (sale != null)
            {
                for (int i = 0; i < sale.Rows.Count; i++)
                {
                    Prices prices = new Prices(Convert.ToDecimal(sale.Rows[i]["Price"]), Convert.ToDateTime(sale.Rows[i]["Criteria1"]), Convert.ToDateTime(sale.Rows[i]["Criteria2"]), Convert.ToString(sale.Rows[i]["Criteria3"]), Convert.ToBoolean(sale.Rows[i]["Enabled"]), Convert.ToInt32(sale.Rows[i]["PriceType"]));
                    PricesList.Add(prices);
                }
            }
        }

        public SpecialPricing()
        {
            getGui = new get_GUI();
            BulkInfoList = new ArrayList();
            OnSaleInfoList = new ArrayList();
            PricesList = new ArrayList();
        }

        public void Update()
        {
            foreach (BulkInfo o in BulkInfoList)
            {
                if(o.isDelete)
                {
                    if(!o.isNew)
                    {
                        getGui.DeleteBulkInfo(StaticClass.storeId,ItemNum,o.bulkQuant);
                    }
                }
                else
                {
                    if(o.isNew)
                    {
                        getGui.InsertBulkInfo(ItemNum,StaticClass.storeId,o.bulkPrice.ToString(),o.bulkQuant.ToString());
                    }
                }
            }

            foreach (OnSalesInfo o in OnSaleInfoList)
            {
                if (o.isDelete)
                {
                    if (!o.isNew)
                    {
                        getGui.DeleteOnsaleInfo(StaticClass.storeId,ItemNum,o.saleStart,o.saleEnd);
                    }
                }
                else
                {
                    if (o.isNew)
                    {
                        getGui.InsertOnsaleInfo(ItemNum,StaticClass.storeId,o.saleStart,o.saleEnd,o.percent);
                    }
                }
            }

            foreach (Prices o in PricesList)
            {
                if (o.isDelete)
                {
                    if (!o.isNew)
                    {
                        getGui.DeletePrices(StaticClass.storeId,ItemNum,o.cr1.ToString(),o.cr2.ToString(),o.cr3,o.priceType);
                    }
                }
                else
                {
                    if (o.isNew)
                    {
                        getGui.InsertPrices(ItemNum,StaticClass.storeId,o.price,o.cr1.ToString(),o.cr2.ToString(),o.cr3,o.Enable,o.priceType);
                    }
                }
            }
        }

    }
}
