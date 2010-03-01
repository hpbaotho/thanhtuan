using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerConfig
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "C:\\Ip.txt";

            if (checkIP(textBox1.Text, "9999"))
            {
                string data = textBox1.Text;
                FileReadWrite.WriteFile(filename, data);
                this.Dispose();
            }
        }
        private bool checkIP(string ip, string port)
        {
            string[] parts = ip.Split('.');
            if (parts.Length != 4)
            {
                MessageBox.Show("Nhập sai IP");
                return false;
            }
            foreach (string s in parts)
            {
                try
                {
                    if (Convert.ToByte(s) > 255)
                    {
                        MessageBox.Show("Nhập sai IP");
                        return false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhập sai IP");
                    return false;
                }

            }
            try
            {
                int p = Convert.ToInt32(port);
                if (p > 65535)
                {
                    MessageBox.Show("Nhập sai IP");
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập sai IP");
                return false;
            }
        }
    }
}
