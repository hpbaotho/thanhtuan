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
    public partial class FrmKeyboardNumber : FrmPOS
    {
        public string value;
        public FrmKeyboardNumber()
        {
            InitializeComponent();
        }
        public FrmKeyboardNumber(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            decimal de;
            if(Decimal.TryParse(textBox1.Text,out de))
            {
                value = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Alert.Show("Giá trị nhập vào không \nhợp lệ",Color.Red);
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void FrmKeyboardNumber_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                decimal de;
                if (Decimal.TryParse(textBox1.Text, out de))
                {
                    value = textBox1.Text;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Alert.Show("Giá trị nhập vào không \nhợp lệ", Color.Red);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "0.";
            }
            else if(!textBox1.Text.Contains("."))
            {
                textBox1.AppendText(".");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.StartsWith("0"))
            {
                textBox1.Text = "-" + textBox1.Text.Substring(1);
            }
            else if (textBox1.Text.StartsWith("-"))
            {
                textBox1.Text = textBox1.Text.Substring(1);
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }

        }
    }
}
