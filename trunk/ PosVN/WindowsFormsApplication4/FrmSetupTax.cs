using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmSetupTax : Form
    {
        public FrmSetupTax()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void creTextBox1_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox) sender;
            float a = 0;
            if(!(float.TryParse(txt.Text,out a)))
            {   
                    Alert.Show("Giá trị nhập vào không hợp lệ", Color.Red);
                    txt.Focus();
            }
            else
            {
                if (a < 0)
                {
                    Alert.Show("Giá trị nhập vào không hợp lệ", Color.Red);
                    txt.Focus();
                }
            }
        }

        private void FrmSetupTax_Load(object sender, EventArgs e)
        {
            Services.get_GUI a = new get_GUI();
            DataTable taxRate = a.GetTaxRate(StaticClass.storeId);
            creTextBox1.Text = String.Format("{0:0.##}",(Convert.ToDecimal(taxRate.Rows[0]["Tax1_Rate"])*100));
            creTextBox2.Text = String.Format("{0:0.##}", (Convert.ToDecimal(taxRate.Rows[0]["Tax2_Rate"]) * 100));
            creTextBox3.Text = String.Format("{0:0.##}", (Convert.ToDecimal(taxRate.Rows[0]["Tax3_Rate"]) * 100));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal t1 = Convert.ToDecimal(creTextBox1.Text)/100;
            decimal t2 = Convert.ToDecimal(creTextBox2.Text) / 100;
            decimal t3 = Convert.ToDecimal(creTextBox3.Text) / 100;
            Services.get_GUI get_GUI = new get_GUI();
            get_GUI.UpdateTax(StaticClass.storeId,t1,t2,t3);
            this.Dispose();
        }
    }
}
