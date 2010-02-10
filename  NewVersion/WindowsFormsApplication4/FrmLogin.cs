using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using POSReport.Report;
using Services;
using WindowsFormsApplication4.lic;
using WindowsFormsApplication4.Networking;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmLogin : Form
    {
        private FrmLayout layout;
        private ServiceGet serviceGet;
        private get_GUI getGui;
        private Thread LoginThread;
        private Networking.ClientNetwork login;
        private string ipServer;
        private int portServer;
        private static FrmLogin m_Instance;

        public static FrmLogin GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new FrmLogin();
            return m_Instance;
        }
        public FrmLogin()
        {
                m_Instance = this;
                InitializeComponent();
                timer2.Enabled = true;
                panel1.Focus();
                textBox1.Focus();  
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void FrmLogin_Load(object sender, EventArgs e)
        {
            //OleDbConnection m_cnADONetConnection = new OleDbConnection();
            //OleDbDataAdapter m_daDataAdapter;
            //OleDbCommandBuilder m_cbCommandBuilder;
            //DataTable m_dtDict = new DataTable();

            //m_cnADONetConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\ConfigDatabase.mdb";

            //m_cnADONetConnection.Open();
            //m_daDataAdapter = new OleDbDataAdapter("Select * From DatabaseInfo", m_cnADONetConnection);
            //m_cbCommandBuilder = new OleDbCommandBuilder(m_daDataAdapter);
            //m_daDataAdapter.Fill(m_dtDict);
            //if (m_dtDict.Rows.Count != 0)
            //{
            //    StaticClass.mode = m_dtDict.Rows[0]["Mode"].ToString();
            //    if (m_dtDict.Rows[0]["InstanceName"].ToString() == "" )
            //    {
            //        StaticClass.serverName = m_dtDict.Rows[0]["ServerName"].ToString();
            //    }
            //    else
            //    {
            //        StaticClass.serverName = m_dtDict.Rows[0]["ServerName"].ToString() + "\\" + m_dtDict.Rows[0]["InstanceName"].ToString();
            //    }
                
            //    StaticClass.databaseName = m_dtDict.Rows[0]["DatabaseName"].ToString();
            //    Services.get_GUI.serverName = StaticClass.serverName;
            //    Services.get_GUI.databaseName = StaticClass.databaseName;
               
            //}
           
            serviceGet = new ServiceGet();
            getGui = new get_GUI();

            label5.Text = "Máy : " + StaticClass.stationId;
            button45.changeColor(Color.White, Color.Red);
            button46.changeColor(Color.White,Color.FromArgb(0,150,0));
            button9.changeColor(Color.White, Color.Red);
            button7.changeColor(Color.White, Color.FromArgb(0, 150, 0));
            button13.changeColor(Color.White,Color.Gray);
            button24.changeColor(Color.White, Color.Yellow);
            button25.changeColor(Color.White, Color.Yellow);
            button26.changeColor(Color.White, Color.Yellow);
            button27.changeColor(Color.White, Color.Yellow);
            button28.changeColor(Color.White, Color.Yellow);
            button29.changeColor(Color.White, Color.Yellow);
            button30.changeColor(Color.White, Color.Yellow);
            button31.changeColor(Color.White, Color.Yellow);
            button32.changeColor(Color.White, Color.Yellow);
            button33.changeColor(Color.White, Color.Yellow);
            button34.changeColor(Color.White, Color.Yellow);
            button35.changeColor(Color.White, Color.Yellow);
            button36.changeColor(Color.White, Color.Yellow);
            button37.changeColor(Color.White, Color.Yellow);
            button38.changeColor(Color.White, Color.Yellow);
            button39.changeColor(Color.White, Color.Yellow);
            button40.changeColor(Color.White, Color.Yellow);
            button41.changeColor(Color.White, Color.Yellow);
            button42.changeColor(Color.White, Color.Yellow);
            button43.changeColor(Color.White, Color.Yellow);
            button44.changeColor(Color.White, Color.Yellow);
            button48.changeColor(Color.White, Color.Yellow);
            button49.changeColor(Color.White, Color.Yellow);
            button50.changeColor(Color.White, Color.Yellow);
            button51.changeColor(Color.White, Color.Yellow);
            button52.changeColor(Color.White, Color.Yellow);
            button53.changeColor(Color.White,Color.Orange);
            button54.changeColor(Color.White,Color.Yellow);
            button55.changeColor(Color.White,Color.OrangeRed);


            panel2.Visible = false;
            panel1.Visible = true;
            textBox1.Clear();
            textBox2.Clear();
            bool focus = textBox1.Focus();
            bool f = textBox1.Focused;
            this.Refresh();

            DataTable setup =  getGui.GetSetupByStore(StaticClass.storeId);
            string path = setup.Rows[0]["Company_Info_5"].ToString();
            FileInfo fi = new FileInfo(path);
            if(path != ""&& fi.Exists)
            {
                pictureBox1.Image = Image.FromFile(path);
            }
            label3.Text = setup.Rows[0]["Invoice_Notes_10"].ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                try
                {
                    string path = Application.StartupPath + "\\ConfigServer.reg";
                    string data = lic.FileReadWrite.ReadFile(path);
                    if (data != string.Empty)
                    {
                        string[] parts = data.Split('@');
                        ipServer = parts[0];
                        portServer = Convert.ToInt32(parts[1]);
                    }
                    panel2.Visible = true;
                    panel1.Visible = false;
                    panel2.BringToFront();
                    textBox2.Focus();

                }
                catch (Exception)
                {

                    panel2.Visible = true;
                    panel1.Visible = false;
                    panel2.BringToFront();
                    textBox2.Focus();
                }

            }
            
        }

        private void button45_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel1.BringToFront();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void button45_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text += "1";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text += "2";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text += "3";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text += "4";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Text += "5";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox2.Text += "6";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox2.Text += "7";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text += "8";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text += "9";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text += "0";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox2.Text += "a";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox2.Text += "b";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox2.Text += "c";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox2.Text += "d";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox2.Text += "e";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            textBox2.Text += "f";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox2.Text += "g";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            textBox2.Text += "h";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox2.Text += "i";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox2.Text += "j";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            textBox2.Text += "k";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            textBox2.Text += "l";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            textBox2.Text += "m";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            textBox2.Text += "n";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox2.Text += "o";
        }

        private void button43_Click(object sender, EventArgs e)
        {
            textBox2.Text += "p";
        }

        private void button42_Click(object sender, EventArgs e)
        {
            textBox2.Text += "q";
        }

        private void button40_Click(object sender, EventArgs e)
        {
            textBox2.Text += "r";
        }

        private void button41_Click(object sender, EventArgs e)
        {
            textBox2.Text += "s";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            textBox2.Text += "t";
        }

        private void button52_Click(object sender, EventArgs e)
        {
            textBox2.Text += "u";
        }

        private void button51_Click(object sender, EventArgs e)
        {
            textBox2.Text += "v";
        }

        private void button49_Click(object sender, EventArgs e)
        {
            textBox2.Text += "w";
        }

        private void button50_Click(object sender, EventArgs e)
        {
            textBox2.Text += "x";
        }

        private void button48_Click(object sender, EventArgs e)
        {
            textBox2.Text += "y";
        }

        private void button44_Click(object sender, EventArgs e)
        {
            textBox2.Text += "z";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Application.Exit();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Application.Exit();
        }

        private void button46_Click(object sender, EventArgs e)
        {

            int check = serviceGet.Login(textBox1.Text, textBox2.Text, "1001");
            if(check == 0)
            {
                Alert.Show("Đăng nhập sai mã nhân\n viên !",Color.Red);
                this.FrmLogin_Load(null,null);
                textBox1.Focus();
            }
            else if(check == 1)
            {
                Alert.Show("Password không đúng !",Color.Red);
                this.FrmLogin_Load(null, null);
            }
            else if(check == 2)
            {
                //StaticClass.cashierId = textBox1.Text;
                
                string tmp = "";
                if(StaticClass.thongTinNV["EmpName"].ToString() == "")
                {
                    tmp = textBox1.Text;
                }
                else
                {
                    tmp = StaticClass.thongTinNV["EmpName"].ToString();
                }
                LoginThread =new Thread(BeginLogin);
                LoginThread.Start(tmp);
                StaticClass.taxRate = getGui.GetTaxRate(StaticClass.storeId).Rows[0];
                layout = new FrmLayout(tmp);
                layout.formLogin = this;
                layout.ShowDialog();
            }
            else if(check == 3)
            {
                Alert.Show("Tài khoản đã bị vô hiệu.", Color.Red);
                this.FrmLogin_Load(null, null);
            }


        }
        //slgn
        public void RequestMess(string s)
        {
            login.Request(s);
        }
        public void DisposeLogin()
        {
            login.LogOut();
            LoginThread.Abort();
        }
        public void BeginLogin(object tmp)
        {
            login=new ClientNetwork();
            //StaticClass.socket = login;
            login.Login(ipServer,portServer,tmp.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (textBox1.Text != "")
                {
                    panel2.Visible = true;
                    panel1.Visible = false;
                    panel2.BringToFront();
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button46_Click(null,null);
            }
        }

        private void chọnDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdminPass frm = new FrmAdminPass();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!serviceGet.checkAdminPass(frm.text, StaticClass.storeId))
                {
                    Alert.Show("Password không đúng !");
                }
                else
                {
                    FrmConfigDatabase frmConfigDatabase = new FrmConfigDatabase();
                    frmConfigDatabase.ShowDialog();
                }
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if(Alert.ShowClockInRequest())
            {
                FrmManager frmManager = new FrmManager();
                frmManager.ShowDialog();
            }
        }

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != "")
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                getGui.UpdateLogoPath(StaticClass.storeId,openFileDialog.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label3.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            //label4.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now);
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        private void xóaHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdminPass adminPass = new FrmAdminPass();
            if (adminPass.ShowDialog() == DialogResult.OK)
            {
                if (serviceGet.checkAdminPass(adminPass.text, "1001"))
                {
                    if (getGui.OnholdNumber(StaticClass.storeId) != 0)
                    {
                        Alert.Show("Vẫn còn hóa đơn chưa\n thanh toán.",Color.Red);
                        return;
                    }
                    if (MessBox2Choice.ShowBox("Bạn có muốn xóa tất cả \nhóa đơn không ?", Color.Red) == DialogResult.Yes)
                    {
                        getGui.ClearAllInvoice(StaticClass.storeId);
                    }
                }
                else
                {
                    Alert.Show("Bạn đã nhập sai \nmật khẩu !", Color.Red);
                }
            }
           
        }

        private void đổiMậtKhẩuQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassAdmin frmChangePassAdmin = new FrmChangePassAdmin();
            frmChangePassAdmin.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           if(label4.Left <= 0 - label4.Width)
           {
               label4.Left = 1022;
           }
           else
           {
               label4.Left -= 5;
           }
        }
        public ServiceGet test = new ServiceGet();
        private void xemSốTiềnBánTrongNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Alert.ShowClockInRequest())
            {
                DateTime DateTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

                DateTime DateTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                POSReport.Report.rptDetailSaleReport_2 DetailSaleReport = new rptDetailSaleReport_2();
                string[] pa = { "@Store_ID", "@DateTime1", "@DateTime2", "@Status", "@Cashier_ID", "Report Title", };

                object[] value = { StaticClass.storeId, DateTime1, DateTime2, "C", StaticClass.cashierId, "Báo cáo bán hàng chi tiết trong ngày" };
                test.FillDataReport(DetailSaleReport, pa, value, true);
                ReportClass reportClass = DetailSaleReport;
                if (reportClass == null)
                    return;
                //FrmViewReporting frmViewReporting = new FrmViewReporting(reportClass);
                //frmViewReporting.Show();
                Utilities.Utils.Print(reportClass,Printer.PrinterHoadon);

            }

        }

        private void cấuHìnhServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Alert.ShowAdminPassRequest())
            {
                FrmConfigServer frmConfigServer = new FrmConfigServer();
                frmConfigServer.ShowDialog();
            }
            
        }

        private void càiĐặtMãMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Alert.ShowAdminPassRequest())
            {
                FrmSetupStation frmSetupStation = new FrmSetupStation();
                frmSetupStation.ShowDialog();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
