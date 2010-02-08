using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class FrmConfigServer : Form
    {
        public FrmConfigServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + "\\ConfigServer.reg";
                                
            if(checkIP(creTextBox1.Text,creTextBox2.Text))
            {
                string data = creTextBox1.Text + "@" + creTextBox2.Text;
                lic.FileReadWrite.WriteFile(filename, data);
                this.Dispose();
            }
        }
        private bool checkIP(string ip,string port)
        {
            string[] parts = ip.Split('.');
            if(parts.Length!=4)
            {
                Alert.Show("Nhập sai IP", Color.Red);
                return false;
            }
            foreach (string s in parts)
            {
                try
                {
                    if (Convert.ToByte(s) > 255)
                    {
                            Alert.Show("Nhập sai IP", Color.Red);
                            return false;                       
                    }
                }
                catch (Exception)
                {
                    Alert.Show("Nhập sai IP", Color.Red);
                    return false;
                }
                
            }
            try
            {
                int p = Convert.ToInt32(port);
                if(p>65535)
                {
                    Alert.Show("Nhập sai IP", Color.Red);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                Alert.Show("Nhập sai IP", Color.Red);
                return false;
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmConfigServer_Load(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + "\\ConfigServer.reg";
            string data = lic.FileReadWrite.ReadFile(filename);
            if(data!=string.Empty)
            {
                string[] parts = data.Split('@');
                creTextBox1.Text = parts[0];
                creTextBox2.Text = parts[1];
            }

        }
    }
}
