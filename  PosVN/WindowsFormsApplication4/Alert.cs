using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    class Alert
    {
        public static void Show(string alertText)
        {
            MessBox messBox = new MessBox(alertText);
            messBox.ShowDialog();
        }
        public static void Show(string alertText,Color backColor)
        {
            MessBox messBox = new MessBox(alertText);
            messBox.BackColor = backColor;
            messBox.ShowDialog();
        }
        public static bool ShowAdminPassRequest()
        {
            Service.ServiceGet serviceGet = new ServiceGet();
            FrmAdminPass frm = new FrmAdminPass();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!serviceGet.checkAdminPass(frm.text, StaticClass.storeId))
                {
                    Alert.Show("Password không đúng !");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
