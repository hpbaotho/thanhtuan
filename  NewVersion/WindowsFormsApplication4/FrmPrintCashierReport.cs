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
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmPrintCashierReport : Form
    {
        public DateTime startDate;
        public DateTime endDate;
        private Service.ServiceGet serviceGet;
        public FrmPrintCashierReport()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
            startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        }

        private void FrmPrintCashierReport_Load(object sender, EventArgs e)
        {
            UpdateDatetime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            FrmCanlendar frmCanlendar = new FrmCanlendar("Chọn ngày bắt đầu");
            if (frmCanlendar.ShowDialog() == DialogResult.OK)
            {
                DateTime tmp = frmCanlendar.monthCalendar1.SelectionStart;
                startDate = new DateTime(tmp.Year, tmp.Month, tmp.Day, startDate.Hour, startDate.Minute, startDate.Second);
                UpdateDatetime();
            }
        }

        private void UpdateDatetime()
        {
            txtStartDate.Text = String.Format("{0:d/M/yyyy}", startDate);
            txtEndDate.Text = String.Format("{0:d/M/yyyy}", endDate);
            txtStartTime.Text = String.Format("{0:HH:mm}", startDate);
            txtEndTime.Text = String.Format("{0:HH:mm}", endDate);
        }

        private void txtEndDate_DoubleClick(object sender, EventArgs e)
        {
            FrmCanlendar frmCanlendar = new FrmCanlendar("Chọn ngày kết thúc");
            if (frmCanlendar.ShowDialog() == DialogResult.OK)
            {
                DateTime tmp = frmCanlendar.monthCalendar1.SelectionStart;
                endDate = new DateTime(tmp.Year, tmp.Month, tmp.Day, endDate.Hour, endDate.Minute, endDate.Second);
                UpdateDatetime();
            }
        }

        private void txtStartTime_DoubleClick(object sender, EventArgs e)
        {
            FrmTime frmTime = new FrmTime("Chọn thời gian bắt đầu");
            if (frmTime.ShowDialog() == DialogResult.OK)
            {
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, FrmReporting.ChangeModeTime(frmTime.Hour, frmTime.Mode), frmTime.Minute, frmTime.Second);
                UpdateDatetime();
            }
        }

        private void txtEndTime_DoubleClick(object sender, EventArgs e)
        {
            FrmTime frmTime = new FrmTime("Chọn thời gian kết thúc");
            if (frmTime.ShowDialog() == DialogResult.OK)
            {
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, FrmReporting.ChangeModeTime(frmTime.Hour, frmTime.Mode), frmTime.Minute, frmTime.Second);
                UpdateDatetime();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POSReport.Report.rptDetailSaleReport_2 DetailSaleReport = new rptDetailSaleReport_2();
            string[] pa = { "@Store_ID", "@DateTime1", "@DateTime2", "@Status", "@Cashier_ID", "Report Title", };

            object[] value = { StaticClass.storeId, startDate, endDate, "C", StaticClass.cashierId, "Báo cáo bán hàng chi tiết trong ngày" };
            serviceGet.FillDataReport(DetailSaleReport, pa, value, true);
            ReportClass reportClass = DetailSaleReport;
            if (reportClass == null)
                this.Dispose();
            //FrmViewReporting frmViewReporting = new FrmViewReporting(reportClass);
            //frmViewReporting.Show();
            Utilities.Utils.Print(reportClass, Printer.PrinterHoadon);
            this.Dispose();
        }

    }
}
