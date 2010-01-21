using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Controls;

namespace WindowsFormsApplication4
{
    public partial class FrmSetupInvoiceNotes : Form
    {
        public FrmSetupInvoiceNotes()
        {
            InitializeComponent();
        }

        private void FrmSetupInvoiceNotes_Load(object sender, EventArgs e)
        {
            Services.get_GUI get_GUI = new get_GUI();
            DataTable a =  get_GUI.GetSetupByStore(StaticClass.storeId);
            for (var i = 1; i < 10; i++)
            {
                this.tabControl1.TabPages[1].Controls["cretextbox" + i].Text = a.Rows[0][24+i].ToString();
            }
            textBox1.Text = a.Rows[0][34].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services.get_GUI get_GUI = new get_GUI();
            get_GUI.UpdateInvoiceNotes(StaticClass.storeId,creTextBox1.Text,creTextBox2.Text,creTextBox3.Text,creTextBox4.Text,creTextBox5.Text,creTextBox6.Text,creTextBox7.Text,creTextBox8.Text,creTextBox9.Text,textBox1.Text);
            this.Dispose();
        }
    }
}
