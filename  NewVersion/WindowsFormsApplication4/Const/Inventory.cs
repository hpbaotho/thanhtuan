using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Const
{
    public static class Inventory
    {
        public const string ItemNum = "ItemNum";
        public const string ItemName = "ItemName";
        public const string Store_ID = "Store_ID";
        public const string Cost = "Cost";
        public const string Price = "Price";
        public const string Retail_Price = "Retail_Price";
        public const string In_Stock = "In_Stock";
        public const string Reorder_Level = "Reorder_Level";
        public const string Reorder_Quantity = "Reorder_Quantity";
        public const string Tax_1 = "Tax_1";
        public const string Tax_2 = "Tax_2";
        public const string Tax_3 = "Tax_3";
        public const string Vendor_Number = "Vendor_Number";
        public const string Dept_ID = "Dept_ID";
        public const string IsKit = "IsKit";
        public const string IsModifier = "IsModifier";
        public const string Kit_Override = "Kit_Override";
        public const string Inv_Num_Barcode_Labels = "Inv_Num_Barcode_Labels";
        public const string Use_Serial_Numbers = "Use_Serial_Numbers";
        public const string Num_Bonus_Points = "Num_Bonus_Points";
        public const string IsRental = "IsRental";
        public const string Use_Bulk_Pricing = "Use_Bulk_Pricing";
        public const string Print_Ticket = "Print_Ticket";
        public const string Print_Voucher = "Print_Voucher";
        public const string Num_Days_Valid = "Num_Days_Valid";
        public const string IsMatrixItem = "IsMatrixItem";
        public const string Vendor_Part_Num = "Vendor_Part_Num";
        public const string Location = "Location";
        public const string AutoWeigh = "AutoWeigh";
        public const string numBoxes = "numBoxes";
        public const string Dirty = "Dirty";
        public const string Tear = "Tear";
        public const string NumPerCase = "NumPerCase";
        public const string FoodStampable = "FoodStampable";
        public const string ReOrder_Cost = "ReOrder_Cost";
        public const string Helper_ItemNum = "Helper_ItemNum";
        public const string ItemName_Extra = "ItemName_Extra";
        public const string Exclude_Acct_Limit = "Exclude_Acct_Limit";
        public const string Check_ID = "Check_ID";
        public const string Old_InStock = "Old_InStock";
        public const string Date_Created = "Date_Created";
        public const string ItemType = "ItemType";
        public const string Prompt_Price = "Prompt_Price";
        public const string Prompt_Quantity = "Prompt_Quantity";
        public const string Inactive = "Inactive";
        public const string Allow_BuyBack = "Allow_BuyBack";
        public const string Picture = "Picture";
        public const string Last_Sold = "Last_Sold";
        public const string Unit_Type = "Unit_Type";
        public const string Unit_Size = "Unit_Size";
        public const string Fixed_Tax = "Fixed_Tax";
        public const string DOB = "DOB";
        public const string Special_Permission = "Special_Permission";
        public const string Prompt_Description = "Prompt_Description";
        public const string Check_ID2 = "Check_ID2";
        public const string Count_This_Item = "Count_This_Item";
        public const string Transfer_Cost_Markup = "Transfer_Cost_Markup";
        public const string Print_On_Receipt = "Print_On_Receipt";
        public const string Transfer_Markup_Enabled = "Transfer_Markup_Enabled";
        public const string As_Is = "As_Is";
        public const string InStock_Committed = "InStock_Committed";
        public const string RequireCustomer = "RequireCustomer";
        public const string PromptCompletionDate = "PromptCompletionDate";
        public const string PromptInvoiceNotes = "PromptInvoiceNotes";
        public const string Prompt_DescriptionOverDollarAmt = "Prompt_DescriptionOverDollarAmt";
        public const string Exclude_From_Loyalty = "Exclude_From_Loyalty";
        public const string BarTaxInclusive = "BarTaxInclusive";
        public const string ScaleSingleDeduct = "ScaleSingleDeduct";
        public const string GLNumber = "GLNumber";
        public const string ModifierType = "ModifierType";
        public const string Position = "Position";
        public const string numberOfFreeToppings = "numberOfFreeToppings";
        public const string ScaleItemType = "ScaleItemType";
        public const string DiscountType = "DiscountType";
        public const string AllowReturns = "AllowReturns";
        public const string SuggestedDeposit = "SuggestedDeposit";
        public const string Liability = "Liability";
        public const string IsDeleted = "IsDeleted";



        //
        public static string itemType2String(byte type)
        {
            switch (type)
            {
                case 0:
                    return "Standard";
                case 1:
                    return "Choice";
                case 2:
                    return "Modifier";
                case 3:
                    return "Coupon";
                default:
                    return "Nothing";
            }
        }

        public static byte string2ItemType(string s)
        {
            switch (s)
            {
                case "Standard Item":
                    return 0;
                case "Choice Item":
                    return 1;
                case "Modifier Group":
                    return 2;
                case "Coupon":
                    return 3;
            }
            return 4;
        }
    }
}
