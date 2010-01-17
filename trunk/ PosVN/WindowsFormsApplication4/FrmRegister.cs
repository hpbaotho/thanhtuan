using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PCARegHelper;
using WindowsFormsApplication4.lic;

namespace WindowsFormsApplication4
{
    public partial class FrmRegister : FrmPOS
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            creTextBox1.Text = Sc.SC().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = Lc.Parse(creTextBox2.Text, creTextBox3.Text);
            string actPath = System.Windows.Forms.Application.StartupPath + @"\actc.reg";
            string regPath = System.Windows.Forms.Application.StartupPath + @"\regc.reg";
            if(a)
            {
                Alert.Show("Đăng kí thành công !\n Chạy lại chương trình \nđể sử dụng");
                FileReadWrite.WriteFile(actPath, creTextBox2.Text);
                FileReadWrite.WriteFile(regPath, creTextBox3.Text);
            }
            this.Dispose();
        }
    }
}
