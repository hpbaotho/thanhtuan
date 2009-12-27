using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Controls;

namespace WindowsFormsApplication4
{
    public partial class FrmKeyBoard : FrmPOS
    {
        public string value;
        private bool isPass;
        public FrmKeyBoard()
        {
            InitializeComponent();
            isPass = false;
        }
        public FrmKeyBoard(bool isPass)
        {
            InitializeComponent();
            this.isPass = isPass;
        }
        
        private string[] bangChucai;
        private string[] bangChuCaiShift;
        private void FrmKeyBoard_Load(object sender, EventArgs e)
        {
            bangChucai = new string[]{"1","2","3","4","5","6","7","8","9","0","-","Q","W","E","R","T","Y","U","I","O","P","A","S","D","F","G","H","J","K","L",".",",","M","N","B","V","C","X","Z"};
            bangChuCaiShift = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", ">", "<", "m", "n", "b", "v", "c", "x", "z" };
            for (int i = 3; i < 42; i++)
            {
                var tmp = (button) this.Controls["button" + i.ToString()];
                this.Controls["button" + i.ToString()].Text = bangChucai[i - 3];
                ((button)this.Controls["button" + i.ToString()]).Click += new EventHandler(FrmKeyBoard_Click);
                if(i>12 && i<42)
                {
                    tmp.changeColor(Color.White,Color.Yellow);
                }
            }
            button1.changeColor(Color.White,Color.Red);
            button2.changeColor(Color.White, Color.Red);
            button42.changeColor(Color.White, Color.Orange);
            button43.changeColor(Color.White, Color.Orange);
            button44.changeColor(Color.White, Color.Orange);


            String x = "●";
            if(isPass)
            {
                textBox1.PasswordChar = x[0];
            }
        }

        void FrmKeyBoard_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((button) sender).Text;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            var tmp = (button) sender;
            if (tmp.Text == "Down    Shift" )
            {
                tmp.Text = "▲        Shift";
                for (int i = 3; i < 42; i++)
                {
                    this.Controls["button" + i.ToString()].Text = bangChucai[i - 3];
                }
            }
            else
            {
                tmp.Text = "Down    Shift";
                for (int i = 3; i < 42; i++)
                {
                    this.Controls["button" + i.ToString()].Text = bangChuCaiShift[i - 3];
                }
            }
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            textBox1.Text += " ";
        }

        private void button44_Click(object sender, EventArgs e)
        {
            value = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
