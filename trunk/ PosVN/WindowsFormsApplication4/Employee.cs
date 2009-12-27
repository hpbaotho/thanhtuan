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
            get_GUI getGui = new get_GUI();
            DataTable emp = getGui.GetEmpById(cashierId);
            Service.ServiceGet service = new ServiceGet();
            switch (grantNum)
            {
                case XEM_BAN_KHAC:
                    if(emp.Rows[0][XEM_BAN_KHAC].ToString() == "P")
                    {
                        return true;
                    }
                    else if (emp.Rows[0][XEM_BAN_KHAC].ToString() == "Y")
                    {
                        FrmAdminPass frm = new FrmAdminPass();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            if (!service.checkAdminPass(frm.text, storeId))
                            {
                                MessageBox.Show("Password không đúng !");
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
                    break;
                default:
                    return false;

            }
        }

    }
}
