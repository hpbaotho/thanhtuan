using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmSetupStation : Form
    {
        private Services.get_GUI getGui;
        private Service.ServiceGet serviceGet;
        public FrmSetupStation()
        {
            InitializeComponent();
            getGui = new get_GUI();
            serviceGet = new ServiceGet();
        }

        private void SetupStation_Load(object sender, EventArgs e)
        {
            DataTable stationList = getGui.GetAllStation(StaticClass.storeId);
            for (int i = 0; i < stationList.Rows.Count; i++)
            {
                listBox1.Items.Add(stationList.Rows[i]["Station_ID"].ToString());
            }
            listBox1.SelectedItem = StaticClass.stationId;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection m_cnADONetConnection = new OleDbConnection();
            m_cnADONetConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\ConfigDatabase.mdb";
            m_cnADONetConnection.Open();
            string query = "Update DatabaseInfo set StationID = '" + listBox1.SelectedItem.ToString()+"'";
            OleDbCommand ad = new OleDbCommand(query, m_cnADONetConnection);
            ad.ExecuteNonQuery();
            m_cnADONetConnection.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard();
            if(frmKeyBoard.ShowDialog() == DialogResult.OK)
            {
                if(listBox1.Items.Contains(frmKeyBoard.value))
                {
                    Alert.Show("Mã này đã có rồi.",Color.Red);
                }
                else
                {
                    object[] station = new object[] { frmKeyBoard.value, StaticClass.storeId, "2", "1", "2", "0", "NONE", "NONE", "0", "NONEP", "NONE", "NONE", "NONE", "NONE" 
                        ,"N/A","0","NONE",true,true,"Y","5",false,true,false,false,false,"0","aaa",
                        "N/A",false,"1",true,"0","sss","0","0",false,DateTime.Now,false,"0","","","","",
                        false,"0","aaa",false,false,"0","","aaa",false,"1","0","0",false,"0","NONE","8421631",
                        false,"",0,false,"1",true,false,"0","0",false,false,false,false,false,"0","0",false,"0","0",
                        "aaa","0","0",false,false,"0",false,true,"NONEP","","","0","1","1","None",false,false,false,false,false,
                        "7","0","1","1",0,"NONE","1",false,"1"};
                    getGui.InsertStation(station);
                    ArrayList printers = serviceGet.getPrinters(StaticClass.storeId, "01");
                    foreach (Printer o in printers)
                    {
                        serviceGet.InsertPrinter(o, frmKeyBoard.value);
                    }
                    listBox1.Items.Add(frmKeyBoard.value);

                    
                    
                }
            }
        }
    }
}
