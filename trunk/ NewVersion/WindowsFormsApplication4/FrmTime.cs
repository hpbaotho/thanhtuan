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
    public partial class FrmTime : Form
    {
        private int hour=12;
        private int minute=0;
        private string mode="AM";
        private int second=0;
        private byte count = 0;
        private bool check = false;
        #region Properties
        public int Hour
        {
            get
            {
                return hour;
            }
        }
        public int Minute
        {
            get
            {
                return minute;
            }
        }
        public int Second
        {
            get
            {
                return second;
            }
        }
        public string Mode
        {
            get
            {
                return mode;
            }
        }
        #endregion
        public FrmTime()
        {
            InitializeComponent();
            hour = 12;
            minute = 0;
            mode = "AM";
            button29.Text="Chọn "+hour+":00"+":00"+" "+mode;
            
        }
        public FrmTime(string s)
        {
            InitializeComponent();
            label1.Text = s;
            hour = 12;
            minute = 0;
            mode = "AM";
            button29.Text = "Chọn " + hour + ":00" + ":00" + " " + mode;

        }
        private void button28_Click(object sender, EventArgs e)
        {
            hour = 12;
            minute = 0;
            second = 0;
            mode = "AM";
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        public delegate void passPa(int h, int m, int s, string st);

        public passPa myPassPara;
        private void button29_Click(object sender, EventArgs e)
        {
            if(myPassPara != null)
            {
                myPassPara(hour, minute, second, mode);
            }
            
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            //button29.Text = "Chọn " + hour + minute +" "+ mode;
        }
        private void myText(int h,int m,int s,string mode)
        {
            if(m<10)
            {
                button29.Text = "Chọn " + hour + ":0" + minute + ":00" + " " + mode;
                button29.Invalidate();
                return;
            }
           
            button29.Text = "Chọn " + hour + ":" + minute + ":00" + " " + mode;
            button29.Invalidate();
        }
        private void button26_Click(object sender, EventArgs e)
        {
            mode = "AM";
            myText(hour,minute,second,mode);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            mode = "PM";
            myText(hour, minute, second, mode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hour = 0;
            myText(hour, minute, second, mode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hour = 1;
            myText(hour, minute, second, mode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hour = 2;
            myText(hour, minute, second, mode);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hour = 3;
            myText(hour, minute, second, mode);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hour = 4;
            myText(hour, minute, second, mode);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hour = 5;
            myText(hour, minute, second, mode);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hour = 6;
            myText(hour, minute, second, mode);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hour = 7;
            myText(hour, minute, second, mode);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hour = 8;
            myText(hour, minute, second, mode);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hour = 9;
            myText(hour, minute, second, mode);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hour = 10;
            myText(hour, minute, second, mode);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hour = 11;
            myText(hour, minute, second, mode);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (check && count < 4)
            {
                minute++;
                count++;
                myText(hour, minute, second, mode);
                return;
            }
            check = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            minute = 0;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            minute = 5;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            minute = 10;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            minute = 15;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            minute = 20;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            minute = 25;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            minute = 30;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            minute = 35;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            minute = 40;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            minute = 45;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            minute = 50;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            minute = 55;
            check = true;
            count = 0;
            myText(hour, minute, second, mode);
        }
    }
}
