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
        private decimal de;

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
            if (Decimal.TryParse(textBox1.Text, out tienTra))
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
            else
            {
                MessageBox.Show("Tiền nhập vào không hợp lệ");
            } 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.StartsWith("-"))
            {
                //textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text.Substring(1,textBox1.Text.Length-1)));
                textBox1.Text = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(Decimal.TryParse(textBox1.Text,out tienTra))
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
            else
            {
                MessageBox.Show("Tiền nhập vào không hợp lệ");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //decimal aaa;
            //if (Decimal.TryParse(textBox1.Text, out aaa))
            //{
            //    textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
            //}
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBox1.Text, out tienTra))
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
            else
            {
                MessageBox.Show("Tiền nhập vào không hợp lệ");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBox1.Text, out tienTra))
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
            else
            {
                MessageBox.Show("Tiền nhập vào không hợp lệ");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if(Decimal.TryParse(textBox1.Text,out de))
            {
                textBox1.Text = String.Format("{0:#,#}", de + 10000);
            }
            else
            {
                textBox1.Text = String.Format("{0:#,#}", 10000);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.ToString().StartsWith("D"))
            //{
            //    decimal aaa;
            //    if(Decimal.TryParse(textBox1.Text,out aaa))
            //    {
            //        textBox1.Text = String.Format("{0:0,0}", Convert.ToDecimal(textBox1.Text));
            //    }
               
            //}
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
            if (Char.IsDigit(e.KeyChar))
            {
                textBox1.AppendText(e.KeyChar.ToString());
            }
            if (textBox1.Text != "")
            {
                if(Decimal.TryParse(textBox1.Text,out de))
                {
                    textBox1.Text = String.Format("{0:#,#}", Convert.ToDecimal(textBox1.Text));
                }
            }
            
                
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", de + 20000);
            }
            else
            {
                textBox1.Text = String.Format("{0:#,#}", 20000);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", de + 50000);
            }
            else
            {
                textBox1.Text = String.Format("{0:#,#}", 50000);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", de + 100000);
            }
            else
            {
                textBox1.Text = String.Format("{0:#,#}", 100000);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", de + 200000);
            }
            else
            {
                textBox1.Text = String.Format("{0:#,#}", 200000);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBox1.Text, out de))
            {
                textBox1.Text = String.Format("{0:#,#}", de + 500000);
            }
            else
            {
                textBox1.Text = String.Format("{0:#,#}", 500000);
            }
        }
    }
}
