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
    public partial class FrmClockIn : Form
    {
        public string MaNV = "";
        public string pass = "";
        public FrmClockIn()
        {
            InitializeComponent();
            creTextBox2.isPass = true;
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

    }
}
