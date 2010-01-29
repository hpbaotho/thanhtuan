using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Controls
{
    public partial class Clock : UserControl
    {
        public Clock()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Clock_Load(object sender, EventArgs e)
        {
            label1.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            label2.Text = String.Format("{0:HH:mm:ss}", DateTime.Now);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            label2.Text = String.Format("{0:HH:mm:ss}", DateTime.Now);
        }
    }
}
