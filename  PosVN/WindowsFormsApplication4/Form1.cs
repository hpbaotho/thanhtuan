using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Networking;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        private Networking.ClientNetwork test;
        public Form1()
        {
            InitializeComponent();
             test = new ClientNetwork();
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Enter += new EventHandler(Form1_Enter);
        }

        void Form1_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("asd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            test.txtServerIP = Utilities.GetIP.getIP();
            test.txtPortIP = 1000;
            test.Login(test.txtServerIP,test.txtPortIP,"01");
        }
    }
}
