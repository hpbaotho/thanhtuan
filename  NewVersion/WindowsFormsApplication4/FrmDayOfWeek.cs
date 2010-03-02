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
    public partial class FrmDayOfWeek : Form
    {
        public FrmDayOfWeek()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(creListBox1.SelectedItems.Count <= 0)
            {
                Alert.Show("Chưa chọn ngày");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
    }
}
