using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GetDatabaseInfo getDatabaseInfo = new GetDatabaseInfo();
            if (!getDatabaseInfo.isconfiged)
            {
                FrmDelete requestconn = new FrmDelete();
                requestconn.label1.Text =
                "Chưa có kết nối database.\n Bạn có muốn chọn database không?";
                if (requestconn.ShowDialog() == DialogResult.OK)
                {
                    FrmConfigDatabase frmConfigDatabase = new FrmConfigDatabase();
                    frmConfigDatabase.ShowDialog();
                }
            }
            else
            {
                if(DAO.DataProvider.TestConnection(getDatabaseInfo.mode, getDatabaseInfo.serverName,
                                                getDatabaseInfo.databaseName, getDatabaseInfo.user, getDatabaseInfo.pass))

                {
                    Application.Run(new FrmLogin());
                }
                else
                {
                    FrmDelete requestconn = new FrmDelete();
                    requestconn.label1.Text =
                    "Kết nối không thành công.\n Bạn có muốn chọn database không?";
                    if (requestconn.ShowDialog() == DialogResult.OK)
                    {
                        FrmConfigDatabase frmConfigDatabase = new FrmConfigDatabase();
                        frmConfigDatabase.ShowDialog();
                    }
                }
                    
            }
        }
    }
}
