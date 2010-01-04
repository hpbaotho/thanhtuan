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
