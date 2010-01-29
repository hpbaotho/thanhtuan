using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    class Employee
    {
        public const int XEM_BAN_KHAC = 45;
        public const int CFA_INVOICE_DELETE_ITEMS = 30;
        public const int CFA_INVOICE_DISCOUNT = 28;
        public const int CFA_INVOICE_PRICE_CHANGE = 29;
        public const int CFA_INVOICE_VOID = 31;
        public const int CFA_TRANSFER_TABLE = 57;
        public const int CFA_INVOICE_QUAN_CHANGE = 0;
        public const int CFA_INVOICE_RETURN = 1;
        public const int CFA_SETUP_TAX = 2;
        public const int CFA_SETUP_PRINTER = 3;
        public const int CFA_SETUP_RECEIPT_NOTES = 4;
        public const int CFA_SETUP_DEPTS_EDIT = 5;
        public const int CFA_SETUP_INVENT_EDIT = 6;
        public const int CFA_SETUP_EDIT_EMP = 7;
        public const int CFA_REPORT_DISPLAY = 8;

        public static bool CheckGrant(string storeId,string cashierId,int grantNum)
        {
            if(!StaticClass.isAdmin)
            {
                get_GUI getGui = new get_GUI();
                DataTable emp = getGui.GetEmpById(cashierId);
                Service.ServiceGet service = new ServiceGet();
                switch (grantNum)
                {
                    case XEM_BAN_KHAC:
                        return check(storeId, cashierId, "CFA_Other_Tables");
                    case CFA_INVOICE_DELETE_ITEMS:
                        return check(storeId, cashierId, "CFA_Invoice_DeleteItems");
                    case CFA_INVOICE_DISCOUNT:
                        return check(storeId, cashierId, "CFA_Invoice_Discount");
                    case CFA_INVOICE_PRICE_CHANGE:
                        return check(storeId, cashierId, "CFA_Invoice_PriceChange");
                    case CFA_INVOICE_VOID:
                        return check(storeId, cashierId, "CFA_Invoice_Void");
                    case CFA_TRANSFER_TABLE:
                        return check(storeId, cashierId, "CFA_Transfer_Tables");
                    case CFA_INVOICE_QUAN_CHANGE:
                        return check(storeId, cashierId, "CFA_ENDTRANS_CASH");
                    case CFA_INVOICE_RETURN:
                        return check(storeId, cashierId, "CFA_Refund_Item");
                    case CFA_SETUP_TAX:
                        return check(storeId, cashierId, "CFA_Setup_Tax");
                    case CFA_SETUP_PRINTER:
                        return check(storeId, cashierId, "CFA_Setup_DefPrinter");
                    case CFA_SETUP_RECEIPT_NOTES:
                        return check(storeId, cashierId, "CFA_SETUP_RECEIPT_NOTES");
                    case CFA_SETUP_DEPTS_EDIT:
                        return check(storeId, cashierId, "CFA_Depts_Edit");
                    case CFA_SETUP_INVENT_EDIT:
                        return check(storeId, cashierId, "CFA_Inven_Edit");
                    case CFA_SETUP_EDIT_EMP:
                        return check(storeId, cashierId, "CFA_SETUP_EDIT_EMPLOYEES");
                    case CFA_REPORT_DISPLAY:
                        return check(storeId, cashierId, "CFA_Reports_Display");
                    default:
                        return false;

                }
            }
            else
            {
                return true;
            }
            
        }
        private static bool check(string storeId, string cashierId, string columnName)
        {
            get_GUI getGui = new get_GUI();
            DataTable emp = getGui.GetEmpById(cashierId);
            Service.ServiceGet service = new ServiceGet();
            if (emp.Rows[0][columnName].ToString() == "Y")
            {
                return true;
            }
            else if (emp.Rows[0][columnName].ToString() == "P")
            {
                FrmAdminPass frm = new FrmAdminPass();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!service.checkAdminPass(frm.text, storeId))
                    {
                        Alert.Show("Password không đúng !",Color.Red);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (emp.Rows[0][columnName].ToString() == "N")
            {
                Alert.Show("Bạn không có quyền để\n thực hiện chức năng này",Color.Red);
                return false;
            }
            return false;
        }

    }
}
