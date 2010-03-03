using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.lic;
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
                if (DAO.DataProvider.TestConnection(getDatabaseInfo.mode, getDatabaseInfo.serverName,
                                                getDatabaseInfo.databaseName, getDatabaseInfo.user, getDatabaseInfo.pass))
                {
                    Services.get_GUI.serverName = getDatabaseInfo.serverName;
                    Services.get_GUI.databaseName = getDatabaseInfo.databaseName;
                    Services.get_GUI.Mode = getDatabaseInfo.mode;
                    Services.get_GUI.UserName = getDatabaseInfo.user;
                    Services.get_GUI.Password = getDatabaseInfo.pass;
                    Lc.Check();
                    Services.get_GUI getGUI = new get_GUI();
                    if (StaticClass.version == Lc.Version.Demo)
                    {
                        int num = getGUI.GetNumOfInvoice();
                        FrmRegisterInfo frmRegisterInfo;
                        if (num > 200)
                        {
                            frmRegisterInfo = new FrmRegisterInfo("Quá 200 hóa đơn.", false);
                            //frmRegisterInfo.ShowDialog();
                            Application.Run(frmRegisterInfo);
                            //if (MessBox2Choice.ShowBox("Quá 100 hóa đơn.\n Bạn có muốn đăng kí không?", Color.Red) == DialogResult.Yes)
                            //{
                            //    Application.Run(new FrmRegister());
                            //}
                        }
                        else
                        {
                            frmRegisterInfo = new FrmRegisterInfo("Bạn còn " + (200 - num).ToString() + " hóa đơn để thử\n với phiên bản Demo", true);
                            //frmRegisterInfo.ShowDialog();
                            frmRegisterInfo.ShowDialog();
                            //Alert.Show("Bạn còn " + (100 - num).ToString()+" hóa đơn để thử\n với phiên bản Demo");
                            Application.Run(new FrmLogin());
                        }
                    }
                    else
                    {
                        Application.Run(new FrmLogin());
                        //Application.Run(new FrmSetupTSButton());
                    }
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
            //Application.Run(new FrmReporting());
        }
    }
}
