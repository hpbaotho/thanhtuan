using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class FrmConfigDatabase : Form
    {
        OleDbConnection m_cnADONetConnection = new OleDbConnection();
        OleDbDataAdapter m_daDataAdapter;
        OleDbCommandBuilder m_cbCommandBuilder;
        DataTable m_dtDict = new DataTable();
        int m_rowPosition = 0;
        private string mode;
        private string userId;
        private string pass;
        private string serverName;
        private string instanceName;
        private string databaseName;
        private bool isConfiged = false;
        public FrmConfigDatabase()
        {
            InitializeComponent();
        }

        private void FrmConfigDatabase_Load(object sender, EventArgs e)
        {
            if (m_cnADONetConnection.State == ConnectionState.Open)
            {
                m_cnADONetConnection.Close();
            }
            m_cnADONetConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\ConfigDatabase.mdb";
            
            m_cnADONetConnection.Open();
            m_daDataAdapter = new OleDbDataAdapter("Select * From DatabaseInfo", m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_daDataAdapter);
            m_daDataAdapter.Fill(m_dtDict);
            if(m_dtDict.Rows.Count != 0)
            {
                listBox1.Items.Add("Tên Server : " + m_dtDict.Rows[0]["ServerName"]);
                listBox1.Items.Add("Tên Instance : " + m_dtDict.Rows[0]["InstanceName"]);
                listBox1.Items.Add("Tên Database : " + m_dtDict.Rows[0]["DatabaseName"]);
                if (m_dtDict.Rows[0]["Mode"].ToString() == "AUT")
                {
                    listBox1.Items.Add("Window Authentication");
                }
                else
                {
                    listBox1.Items.Add("UserName : " + m_dtDict.Rows[0]["UserID"]);
                    userId = m_dtDict.Rows[0]["UserID"].ToString();
                    pass = m_dtDict.Rows[0]["Password"].ToString();
                }
                mode = m_dtDict.Rows[0]["Mode"].ToString();
                serverName = m_dtDict.Rows[0]["ServerName"].ToString();
                instanceName = m_dtDict.Rows[0]["InstanceName"].ToString();
                databaseName = m_dtDict.Rows[0]["DatabaseName"].ToString();
                isConfiged = true;
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            if(isConfiged)
            {
                txt_ServerName.Text = serverName;
                txt_InstanceName.Text = instanceName;
                cmb_DatabaseNames.Text = databaseName;
                if(mode == "AUT")
                {
                    comboBox1.SelectedIndex = 0;
                    txt_Pass.Enabled = false;
                    txt_ID.Enabled = false;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                    txt_ID.Text = userId;
                    txt_Pass.Text = pass;
                }
            }
            
            txt_ServerName.Focus();

            //string[] serverNames = Service.GetDatabaseInfo.getLocalServer();
            //for (int i = 0; i < serverNames.Length; i++)
            //{
            //    cmb_ServerName.Items.Add(serverNames[i]);
            //}

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Window Authentication")
            {
                txt_Pass.Enabled = false;
                txt_ID.Enabled = false;
            }
            else
            {
                txt_Pass.Enabled = true;
                txt_ID.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                Alert.Show("Mode không hợp lệ", Color.Red);
                return;
            }

            string serverNa = txt_ServerName.Text;
            if (txt_InstanceName.Text != "")
            {
                serverNa += "\\" + txt_InstanceName.Text;
            }
            string mo = "";
            string pas = "";
            string user = "";
            if (comboBox1.SelectedItem.ToString() == "Window Authentication")
            {
                mo = "AUT";
            }
            else if (comboBox1.SelectedItem.ToString() == "SQL Server")
            {
                mo = "SQL";
                pas = txt_Pass.Text;
                user = txt_ID.Text;

            }
            if(DAO.DataProvider.TestConnection(mo,serverNa,cmb_DatabaseNames.Text,user,pas))
            {
                if (isConfiged)
                {
                    m_dtDict.Rows[0].Delete();
                    m_daDataAdapter.Update(m_dtDict);
                }
                string insert = "insert into DatabaseInfo values ('" + txt_ServerName.Text + "','" + txt_InstanceName.Text +
                                "','" + cmb_DatabaseNames.Text + "','" + mo + "','" +user+ "','"+pas+"','00')";

                OleDbCommand ad = new OleDbCommand(insert, m_cnADONetConnection);
                ad.ExecuteNonQuery();

                //m_daDataAdapter.Update(m_dtDict);
                if(listBox1.Items.Count != 0)
                {
                    listBox1.Items.Clear();
                }
                this.FrmConfigDatabase_Load(null,null);
                panel1.Visible = false;
                panel2.Visible = true;
                Application.Restart();
            }
            else
            {
                Alert.Show("Kết nối không thành công");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count != 0)
            {
                string delete = "delete from DatabaseInfo";

                OleDbCommand ad = new OleDbCommand(delete, m_cnADONetConnection);
                ad.ExecuteNonQuery();
                listBox1.Items.Clear();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string dbConnectionString = "";
                string serverNa = txt_ServerName.Text;
                if(txt_InstanceName.Text != "")
                {
                    serverNa += "\\" + txt_InstanceName.Text;
                }

                dbConnectionString = "Data Source=" + serverNa + ";Integrated Security = True;";
                //dbConnectionString = dbConnectionString + " User ID=" + dlg.Username + "; Password=" + dlg.Password + ";";

                SqlConnection dbConnection = new SqlConnection(dbConnectionString);
                dbConnection.Open();
                DataTable database = dbConnection.GetSchema("Databases");

                cmb_DatabaseNames.DataSource = database;
                cmb_DatabaseNames.DisplayMember = "Database_Name";
                cmb_DatabaseNames.SelectedIndex = 0;
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            txt_ServerName.Text = System.Environment.MachineName;
        }
    }
}
