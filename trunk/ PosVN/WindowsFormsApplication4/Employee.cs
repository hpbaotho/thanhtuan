using System;
using System.Collections.Generic;
using System.Data;
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
            if (emp.Rows[0][columnName].ToString() == "P")
            {
                return true;
            }
            else if (emp.Rows[0][columnName].ToString() == "Y")
            {
                FrmAdminPass frm = new FrmAdminPass();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!service.checkAdminPass(frm.text, storeId))
                    {
                        Alert.Show("Password không đúng !");
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
            else
            {
                return false;
            }
        }

    }
}
