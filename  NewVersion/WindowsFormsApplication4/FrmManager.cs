using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using WindowsFormsApplication4.Controls;
using POSReport.Report;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmManager : FrmPOS
    {
        private string selectedButton;
        public ServiceGet serviceGet;
        public FrmManager()
        {
            InitializeComponent();
            selectedButton = "";
            serviceGet = new ServiceGet();
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
            SelectChange("button3","panel3");
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
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_TS_CONFIG))
            {
                return;
            }
            FrmSetupTSButton frmSetupTSButton = new FrmSetupTSButton();
            frmSetupTSButton.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_Cust_Edit))
            {
                return;
            }
            FrmCustomer frmCustomer = new FrmCustomer();
            frmCustomer.ShowDialog();
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
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_Open_Cash_Drawer))
            {
                return;
            }
            //rptOpenDrawer rptOpenDrawer = new rptOpenDrawer();
            //Utilities.Utils.Print(rptOpenDrawer,Printer.PrinterHoadon);
            Service.ServiceGet serviceGet = new ServiceGet();
            Printer printer = serviceGet.GetPrinterByName(StaticClass.storeId, StaticClass.stationId, Printer.PrinterHoadon);
            if (!(printer == null || printer.Details == "NONE" || printer.Disable == true))
            {
                Service.CashdrawerService.OpenCashDrawer1(printer.Details);
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            
        }

        private void button32_Click(object sender, EventArgs e)
        {
            FrmGeneralSetup frmGeneralSetup = new FrmGeneralSetup();
            frmGeneralSetup.ShowDialog();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_PULLBACK_INVOICE))
            {
                return;
            }
            DataTable invoices = serviceGet.getGui.GetAllInvoices(StaticClass.storeId);
            string[] column = { "Invoice_Number", "Station_ID", "Grand_Total", "Cashier_ID", "Store_ID" };
            FrmSearch search = new FrmSearch(invoices, column);
            search.tableType = "Invoices";
            //search.passdata = new FrmSearch.PassData(changeState);
            if(search.ShowDialog() == DialogResult.OK)
            {
                string invoiceNum = search.selectRow.Cells["Invoice_Number"].Value.ToString();
                string tableName = search.selectRow.Cells["Orig_OnHoldID"].Value.ToString();
                printThanhToan(invoiceNum,tableName);
            }
        }

        private void printThanhToan(string invoiceNumber, string tableNumber)
        {
            Printer printer = serviceGet.GetPrinterByName(StaticClass.storeId, StaticClass.stationId, "Hóa đơn");
            if (!(printer == null || printer.Details == "NONE" || printer.Disable == true))
            {

                Re_ThanhToan xxx = new Re_ThanhToan();

                string[] pa = { "@Store_ID", "@Invoice_Number", "table" };
                object[] value = { StaticClass.storeId, invoiceNumber, tableNumber };
                serviceGet.FillDataReport(xxx, pa, value, true);
                //xxx.PrintOptions.PrinterName = printer.Details;

                xxx.PrintOptions.ApplyPageMargins(new PageMargins(1, 2, 1, 0));

                Utilities.Utils.Print(xxx, Printer.PrinterHoadon);
                //try
                //{
                //    xxx.PrintToPrinter(1, false, 0, 0);
                //}
                //catch (Exception)
                //{
                //    Alert.Show("Lỗi máy in", Color.Red);
                //}
                //Service.CashdrawerService.OpenCashDrawer1(printer.Details);
                xxx.Dispose();
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            DataTable dataTable = serviceGet.getGui.GetLastInvoice(StaticClass.stationId, StaticClass.storeId);
            if (dataTable.Rows.Count > 0)
            {
                printThanhToan(dataTable.Rows[0]["Invoice_Number"].ToString(), dataTable.Rows[0]["Orig_OnHoldID"].ToString());
            }
        }
    }
}
