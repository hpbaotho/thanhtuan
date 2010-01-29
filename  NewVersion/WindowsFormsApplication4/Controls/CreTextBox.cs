using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Controls
{
    public partial class CreTextBox : TextBox
    {
        public bool isKeyNumber = false;
        public bool isPass = false;
        public CreTextBox()
        {
            
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.BackColor = Color.Yellow;
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.BackColor = Color.White;
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if(isKeyNumber)
            {
                FrmKeyboardNumber frmKeyboardNumber = new FrmKeyboardNumber("Nhập giá trị");
                if(frmKeyboardNumber.ShowDialog() == DialogResult.OK)
                {
                    this.Text = frmKeyboardNumber.value;
                }
            }
            else
            {
                FrmKeyBoard frmKeyboardNumber = new FrmKeyBoard(isPass);
                if (frmKeyboardNumber.ShowDialog() == DialogResult.OK)
                {
                    this.Text = frmKeyboardNumber.value;
                }
            }

        }
      
    }
}
