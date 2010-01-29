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
    public partial class FrmRegisterInfo : FrmPOS
    {
        public FrmRegisterInfo()
        {
            InitializeComponent();
        }

        public bool isDemo = false;
        public FrmRegisterInfo(string text,bool isDemo)
        {
            InitializeComponent();
            label1.Text = text;
            this.isDemo = isDemo;
            if(!isDemo)
            {
                button1.Text = "Thoát";
            }
        }

        private void FrmRegisterInfo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isDemo)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}
