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
    public partial class FrmDept : FrmPOS
    {
        public FrmDept()
        {
            InitializeComponent();
        }

        private void FrmDept_Load(object sender, EventArgs e)
        {
            
        }
        public void FirstState()
        {
            for (int i = 1; i < 11; i++)
            {
                this.Controls["button" + i.ToString()].Enabled = true;
            }
            button7.Text = "Exit";
            button1.Text = "Add";
            txtDeptID.Enabled = false;
            this.Refresh();
        }
        public void AddState()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button1.Text = "Save";
            button7.Text = "Cancel";
            txtDeptID.Enabled = true;
            txtDeptID.Focus();
            this.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddState();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(button7.Text == "Cancel")
            {
                FirstState();
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
