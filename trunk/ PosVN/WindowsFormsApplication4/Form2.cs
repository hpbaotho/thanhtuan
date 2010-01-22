using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using POSReport.Report;
using Services;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        public string text;
        public Service.ServiceGet test = new ServiceGet();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime DateTime1 = new DateTime(2009, 12, 27);
            DateTime DateTime2 = new DateTime(2010, 1, 3);

            ReportClass invoiceT = new InvoiceTotal();
            invoiceT.DataSourceConnections[0].SetConnection(Services.get_GUI.serverName, Services.get_GUI.databaseName, true);           
           
            invoiceT.SetParameterValue("@Store_ID", StaticClass.storeId);
            invoiceT.SetParameterValue("@DateTime1", DateTime1);
            invoiceT.SetParameterValue("@DateTime2", DateTime2);

            //ReportClass invoice = new rptItemDept();
            //string[] pa = {"@Store_ID","Report_Title_Param"};
            //string[] value = {StaticClass.storeId,"mat hang"};
            //test.FillDataReport(invoice,pa,value,true);
            //crystalReportViewer1.ReportSource = invoice;



            //ReportClass invoice = new rptInventoryByApha();
            //string[] pa = { "@Store_ID", "Report_Title_Param" };
            //string[] value = { StaticClass.storeId, "mat hang" };
            //test.FillDataReport(invoice, pa, value, true);
            //crystalReportViewer1.ReportSource = invoice;


            ReportClass invoice = new rptInvoiceTotalsDaily();
            string[] pa = { "@Store_ID", "Report_Title_Param" };
            string[] value = { StaticClass.storeId, "mat hang" };
            test.FillDataReport(invoice, pa, value, true);
            crystalReportViewer1.ReportSource = invoice;
            ////string[] para = {"@Store_ID", "Report_Title_Param" };
            ////string[] value = {StaticClass.storeId,"Invoice Daily"};

            ////test.FillDataReport(invoiceT, para, value, true);

            ////invoiceT.SetParameterValue("@Store_ID", StaticClass.storeId);
            ////invoiceT.SetParameterValue("Report_Title_Param", "thanh report");
            //crystalReportViewer1.ReportSource = invoiceT;
            //string[] para = { "@Store_ID", "Report_Title_Param" };
            //string[] value = { StaticClass.storeId, "Invoice Daily" };
            //rptItemDept t = new rptItemDept();
            //test.FillDataReport(t, para, value, true);
            //crystalReportViewer1.ReportSource = invoiceT};
            ////crystalReportViewer1.Update();
            //invoiceT.PrintToPrinter(1, false, 1, 1);

            //string result = MessBox2Choice.ShowBox("Do you want to exit?",Color.Red);
            //if (result.Equals("1"))
            //{
            //    MessageBox.Show("OK Button was Clicked");
            //}

            //if (result.Equals("2"))
            //{
            //    MessageBox.Show("Cancel Button was Clicked");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrystalReport1 crystalReport1 = new CrystalReport1();
            
        }
    }
}
