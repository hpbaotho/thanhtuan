﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.TextChanged += new EventHandler(panel1_TextChanged);
        }

        void panel1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("sadsa");
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Enter += new EventHandler(Form1_Enter);
        }

        void Form1_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("asd");
        }
    }
}
