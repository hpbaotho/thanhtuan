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
    public partial class MessBox2Choice : Form
    {
        static MessBox2Choice newMessageBox;
        static DialogResult Button_id;
        public static DialogResult ShowBox(string txtMessage, Color c)
        {
            newMessageBox = new MessBox2Choice();
            newMessageBox.label1.Text = txtMessage;
            newMessageBox.label1.Left = (newMessageBox.Width - newMessageBox.label1.Width)/2;
            newMessageBox.BackColor = c;
            newMessageBox.ShowDialog();
            return Button_id;
        }
        public MessBox2Choice() 
        {
            InitializeComponent();
           
        }

        private void MessBox2Choice_Load(object sender, EventArgs e)
        {

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Button_id = System.Windows.Forms.DialogResult.No;
            newMessageBox.Dispose();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Button_id = System.Windows.Forms.DialogResult.Yes; 
            newMessageBox.Dispose();
        }
    }
}
