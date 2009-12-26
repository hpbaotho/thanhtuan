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
    public partial class FrmAdminPass : Form
    {
        public string text;
        public FrmAdminPass()
        {
            InitializeComponent();
            button1.changeColor(Color.White,Color.Red);
            button2.changeColor(Color.White,Color.Green);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            text = textBox1.Text;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard(true);
            if(frmKeyBoard.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = frmKeyBoard.value;
            }
        }
    }
}
