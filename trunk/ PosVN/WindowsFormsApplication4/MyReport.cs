using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using POSReport.Report;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class MyReport : Form
    {
        private ServiceGet test;
        public MyReport()
        {
            InitializeComponent();
            test = new ServiceGet();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            

        }

        private void MyReport_Load(object sender, EventArgs e)
        {
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //DateTime DateTime1 = new DateTime(2009, 12, 27);
            //DateTime DateTime2 = new DateTime(2010, 1, 3);

            //ReportClass invoiceT = new InvoiceTotal();
            ////invoiceT.DataSourceConnections[0].SetConnection(Services.get_GUI.serverName, Services.get_GUI.databaseName, true);           
            ////DataTable InvoiceTotal = test.InvoiceTotal(StaticClass.storeId, DateTime1, DateTime2);
            //invoiceT.SetParameterValue("@Store_ID", StaticClass.storeId);
            //invoiceT.SetParameterValue("@DateTime1", DateTime1);
            //invoiceT.SetParameterValue("@DateTime2", DateTime2);
            ////string[] para = {"@Store_ID", "Report_Title_Param" };
            ////string[] value = {StaticClass.storeId,"Invoice Daily"};

            ////test.FillDataReport(invoiceT, para, value, true);

            ////invoiceT.SetParameterValue("@Store_ID", StaticClass.storeId);
            ////invoiceT.SetParameterValue("Report_Title_Param", "thanh report");
            //crystalReportViewer1.ReportSource = invoiceT;
            //string[] para = {"@Store_ID", "Report_Title_Param" };
            //string[] value = {StaticClass.storeId,"Invoice Daily"};
            //rptItemDept t=new rptItemDept();
            //test.FillDataReport(t,para,value,true);
            //crystalReportViewer1.ReportSource = t;
            //crystalReportViewer1.Update();
            //t.PrintToPrinter(1,false,1,1);

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
    }
}
