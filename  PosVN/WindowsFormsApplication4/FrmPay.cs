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
    public partial class FrmPay : Form
    {
        public decimal tienTra;
        public decimal tienThoi;
        public string hinhThucTra;

        public FrmPay()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBox1.Text) < Convert.ToDecimal(textBox2.Text))
            {
                MessageBox.Show("Số tiền trả thấp hơn số tiền nợ");
            }
            else
            {
                tienTra = Convert.ToDecimal(textBox1.Text);
                tienThoi = Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(textBox2.Text);
                hinhThucTra = "CA";
                this.DialogResult = DialogResult.OK;
            }

            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
            textBox1.Text =  String.Format("{0:0,0}",Convert.ToDecimal(textBox1.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");
            textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.StartsWith("-"))
            {
                textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text.Substring(1,textBox1.Text.Length-1)));
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBox1.Text) < Convert.ToDecimal(textBox2.Text))
            {
                MessageBox.Show("Số tiền trả thấp hơn số tiền nợ");
            }
            else
            {
                tienTra = Convert.ToDecimal(textBox1.Text);
                tienThoi = Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(textBox2.Text);
                hinhThucTra = "CA";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //decimal a;
            //if(Decimal.TryParse(textBox1.Text,out a))
            //{
            //    textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
            //}
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBox1.Text) < Convert.ToDecimal(textBox2.Text))
            {
                MessageBox.Show("Số tiền trả thấp hơn số tiền nợ");
            }
            else
            {
                tienTra = Convert.ToDecimal(textBox1.Text);
                tienThoi = Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(textBox2.Text);
                hinhThucTra = "CC";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBox1.Text) < Convert.ToDecimal(textBox2.Text))
            {
                MessageBox.Show("Số tiền trả thấp hơn số tiền nợ");
            }
            else
            {
                tienTra = Convert.ToDecimal(textBox1.Text);
                tienThoi = Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(textBox2.Text);
                hinhThucTra = "DC";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
        }
    }
}
