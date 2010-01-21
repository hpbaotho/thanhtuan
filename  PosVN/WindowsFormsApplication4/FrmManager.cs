using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Controls;

namespace WindowsFormsApplication4
{
    public partial class FrmManager : FrmPOS
    {
        private string selectedButton;
        public FrmManager()
        {
            InitializeComponent();
            selectedButton = "";
        }
        public void SelectChange(string select,string panelName)
        {
            if(select != selectedButton)
            {
                if(selectedButton !="")
                {
                    ((button)this.Controls[selectedButton]).changeColor(Color.White, Color.FromArgb(0, 170, 0));
                }
                
                ((button)this.Controls[select]).changeColor(Color.White,Color.Lime);
                this.Controls[panelName].BringToFront();
                
                
                selectedButton = select;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectChange(((button)sender).Name,"panel1");
        }

        private void FrmManager_Load(object sender, EventArgs e)
        {
            SelectChange("button1","panel1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectChange(((button)sender).Name, "panel2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectChange(((button)sender).Name, "panel1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectChange(((button)sender).Name, "panel1");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectChange(((button)sender).Name, "panel1");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmInventory frmInventory = new FrmInventory();
            frmInventory.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmDept frmDept = new FrmDept();
            frmDept.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            FrmSetupPrinter frmSetupPrinter = new FrmSetupPrinter();
            frmSetupPrinter.ShowDialog();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            FrmSetupTax frmSetupTax = new FrmSetupTax();
            frmSetupTax.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            FrmSetupInvoiceNotes frmSetupInvoiceNotes = new FrmSetupInvoiceNotes();
            frmSetupInvoiceNotes.ShowDialog();
        }
    }
}
