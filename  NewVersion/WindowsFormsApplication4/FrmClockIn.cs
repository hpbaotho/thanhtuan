using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmClockIn : Form
    {
        public string MaNV = "";
        public string pass = "";
        public bool Success = false;
        public FrmClockIn()
        {
            InitializeComponent();
            creTextBox2.isPass = true;
            Success = false;
            creTextBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MaNV = creTextBox1.Text;
            pass = creTextBox2.Text;
            DialogResult = DialogResult.OK;
        }

        private void creTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                MaNV = creTextBox1.Text;
                pass = creTextBox2.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void creTextBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void FrmClockIn_Load(object sender, EventArgs e)
        {

        }

        private void creTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                Service.ServiceGet serviceGet = new ServiceGet();
                if (serviceGet.checkAdminPass(creTextBox2.Text, StaticClass.storeId))
                {
                    Success = true;
                    StaticClass.isAdmin = true;
                    DialogResult = DialogResult.OK;
                }
                if(serviceGet.LoginBySwipe(creTextBox2.Text,StaticClass.storeId)==0)
                {
                    Success = true;
                    DialogResult = DialogResult.OK;
                }
                creTextBox1.SelectAll();
                creTextBox1.Focus();
            }
        }

    }
}
