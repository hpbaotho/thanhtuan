using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmChangePassAdmin : Form
    {
        private Service.ServiceGet serviceGet;
        public FrmChangePassAdmin()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
            creTextBox1.isPass = true;
            creTextBox2.isPass = true;
            creTextBox3.isPass = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if( serviceGet.checkAdminPass(creTextBox1.Text, StaticClass.storeId))
            {
                if(creTextBox2.Text == creTextBox3.Text)
                {
                    Services.get_GUI get_GUI = new get_GUI();
                    get_GUI.UpdateAdminPass(StaticClass.storeId, creTextBox2.Text);
                }
                
            }
            this.Dispose();
           
        }
    }
}
