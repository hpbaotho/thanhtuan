using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Controls;
using POSReport.Report;
using WindowsFormsApplication4.Persistence;

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
            SelectChange(((button)sender).Name, "panel3");
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
            if(!Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_SETUP_INVENT_EDIT))
            {
                return;
            }
            FrmInventory frmInventory = new FrmInventory();
            frmInventory.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_SETUP_DEPTS_EDIT))
            {
                return;
            }
            FrmDept frmDept = new FrmDept();
            frmDept.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_SETUP_PRINTER))
            {
                return;
            }
            FrmSetupPrinter frmSetupPrinter = new FrmSetupPrinter();
            frmSetupPrinter.ShowDialog();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_SETUP_TAX))
            {
                return;
            }
            FrmSetupTax frmSetupTax = new FrmSetupTax();
            frmSetupTax.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_SETUP_RECEIPT_NOTES))
            {
                return;
            }
            FrmSetupInvoiceNotes frmSetupInvoiceNotes = new FrmSetupInvoiceNotes();
            frmSetupInvoiceNotes.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_REPORT_DISPLAY))
            {
                return;
            }
            FrmReporting frmReporting = new FrmReporting();
            frmReporting.ShowDialog();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            FrmSetupTSButton frmSetupTSButton = new FrmSetupTSButton();
            frmSetupTSButton.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_SETUP_EDIT_EMP))
            {
                return;
            }
            FrmEmployee frmEmployee = new FrmEmployee();
            frmEmployee.ShowDialog();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            rptOpenDrawer rptOpenDrawer = new rptOpenDrawer();
            Utilities.Utils.Print(rptOpenDrawer,Printer.PrinterHoadon);
        }
    }
}
