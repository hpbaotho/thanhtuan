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
    public partial class MessBox : Form
    {
        public MessBox()
        {
            InitializeComponent();
        }
        public MessBox(string text)
        {
            InitializeComponent();
            label1.Text = text;
            label1.Left = (this.Width - label1.Width)/2;
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MessBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==13)
            {
                this.Dispose();
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Dispose();
            }
        }
    }
}
