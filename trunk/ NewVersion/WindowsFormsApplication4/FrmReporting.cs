using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using POSReport.Report;
using Services;
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;
using CrystalDecisions.CrystalReports;
using WindowsFormsApplication4.Utilities;

namespace WindowsFormsApplication4
{
    public partial class FrmReporting : Form
    {
        private byte stateButton = 0;
        public ServiceGet test = new ServiceGet();
        private DateTime DateTime1;
        private DateTime DateTime2;
        private int Myhour1=0;
        private int Myminute1=0;
        private int Mysecond1=0;
        private int Myhour2=11;
        private int Myminute2=59;
        private int Mysecond2=59; 
        private string Mymode1="AM";
        private string Mymode2 = "PM";
        private int state = 0;
        private Services.get_GUI get_service;
        private DataTable Employee;
        private string StatusInvoice=Const.Invoice_Status.THANH_TOAN_ROI;
        private string Cashier_ID = "ALL";
        private string printerName = Printer.PrinterHoadon;
        public FrmReporting()
        {
            InitializeComponent();
            ArrayList thanh = new ArrayList();
            //thanh.AddRange(new string[]{"thanh","tuan"});
            listBox1.DataSource = viewSale();
            txtStartDate.Text = DateTime.Now.ToShortDateString();
            txtEndDate.Text = DateTime.Now.ToShortDateString();
            DateTime1 = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0);

            DateTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            txtStartTime.Text = "00" + ":00"  + ":" + "00" + " " + "AM";
            txtEndTime.Text = "11" + ":59" + ":" + "59" + " " + "PM";
            setChoseButton(btnSale);
            get_service=new get_GUI();
            
            Employee = get_service.GetAllEmployee(StaticClass.storeId);
            lstCashier.Items.Add("ALL");
            lstKindOfInvo.DataSource = viewKindOfInvoic();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            
            listBox1.DataSource = viewEm();
            state = stateButton = 20;
            setChoseButton(btnEmployee);
            EnableDateTime();
        }
        #region PopularData
        private void PopularDatain2lstCashier()
        {
            for(int i=0;i<Employee.Rows.Count;i++)
            {
                lstCashier.Items.Add(Employee.Rows[i][Const.Employee_Prop.Cashier_ID]);
            }
        }
        #endregion
        #region Views
        private ArrayList viewSale()
        {
            return new ArrayList(new string[] { "Báo cáo hóa đơn theo thời gian", "Báo cáo hóa đơn theo từng ngày", "Báo cáo bán hàng chi tiết trong ngày", "Báo cáo các mặt hàng trả lại", "Báo cáo chi tiết bán hàng theo nhóm" });
        }
        private ArrayList viewRes()
        {
            return new ArrayList(new string[] { "" });
        }
        private ArrayList viewCus()
        {
            return new ArrayList(new string[] { "" });
        }
        private ArrayList viewEm()
        {
            return new ArrayList(new string[] { "" });
        }
        private ArrayList viewInv()
        {
            return new ArrayList(new string[] { "Các mặt còn trong kho","Tình hình nhập hàng"});
        }

        private ArrayList viewKindOfInvoic()
        {
            return new ArrayList(new string[] { "Đã thanh toán","Hủy"});
        }
        #endregion
        
        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void startDateText(DateTime s)
        {
            txtStartDate.Text = s.ToShortDateString();
            DateTime tmp = new DateTime(s.Year, s.Month, s.Day, ChangeModeTime(Myhour1, Mymode1), Myminute1, Mysecond1);
            DateTime1 = tmp;

        }
        private void endDateText(DateTime s)
        {
            txtEndDate.Text = s.ToShortDateString();
            DateTime tmp = new DateTime(s.Year, s.Month, s.Day, ChangeModeTime(Myhour2, Mymode2), Myminute2, Mysecond2);
            DateTime2 = tmp;
        }
        private void txtStartDateDoubleClick(object sender, MouseEventArgs e)
        {
            FrmCanlendar myCalendar=new FrmCanlendar("Chọn Ngày Bắt Đầu");
            myCalendar.passDate = startDateText;
            myCalendar.ShowDialog();
        }

        private void txtEndDateDoubleClick(object sender, MouseEventArgs e)
        {
            FrmCanlendar myCalendar = new FrmCanlendar("Chọn Ngày Kết Thúc");
            myCalendar.passDate = endDateText;
            myCalendar.ShowDialog();
        }

        private void startTimeText(int hour,int minute,int second,string mode)
        {
            if(minute<10)
            {
                txtStartTime.Text = hour + ":0" + minute + ":" + second + " " + mode;
            }
            else
            {
                txtStartTime.Text = hour + ":" + minute + ":" + second + " " + mode;
            }
            Myhour1 = hour;
            Myminute1 = minute;
            Mysecond1 = second;
            Mymode1 = mode;
            DateTime tmp=new DateTime(DateTime1.Year,DateTime1.Month,DateTime1.Day,ChangeModeTime(hour, mode),minute,second);
            DateTime1 = tmp;
            
        }
        private void endTimeText(int hour, int minute, int second, string mode)
        {
            if (minute < 10)
            {
                txtStartTime.Text = hour + ":0" + minute + ":" + second + " " + mode;
            }
            else
            {
                txtEndTime.Text = hour + ":" + minute + ":" + second + " " + mode;
            }
            Myhour2 = hour;
            Myminute2 = minute;
            Mysecond2 = second;
            Mymode2 = mode;
            DateTime tmp = new DateTime(DateTime2.Year, DateTime2.Month, DateTime2.Day, ChangeModeTime(hour, mode), minute, second);
            DateTime2 = tmp;
        }
        private void txtStartTimeDoubleClick(object sender, MouseEventArgs e)
        {
            FrmTime myTime=new FrmTime("Chọn Giờ Bắt Đầu");
            myTime.myPassPara = startTimeText;
            myTime.ShowDialog();
        }

        private void txtEndTimeDoubleClick(object sender, MouseEventArgs e)
        {
            FrmTime myTime = new FrmTime("Chọn Giờ Kết Thúc");
            myTime.myPassPara = endTimeText;
            myTime.ShowDialog();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            
            listBox1.DataSource = viewSale();
            state=stateButton = 0;
            setChoseButton(btnSale);
            EnableDateTime();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = viewCus();
            state = stateButton = 10;
            setChoseButton(btnCustomer);
            EnableDateTime();
        }
        private void setChoseButton(object b)
        {
            btnSale.Color1 = Color.Blue;
            btnSale.Color2 = Color.Blue;

            btnCustomer.Color1 = Color.Blue;
            btnCustomer.Color2 = Color.Blue;

            btnEmployee.Color1 = Color.Blue;
            btnEmployee.Color2 = Color.Blue;

            btnRestaurant.Color1 = Color.Blue;
            btnRestaurant.Color2 = Color.Blue;

            btnInvoice.Color1 = Color.Blue;
            btnInvoice.Color2 = Color.Blue;
            WindowsFormsApplication4.Controls.button my = (button) b;
            my.Color1 = Color.Green;
            my.Color2 = Color.Green;
        }

        private void btnRestaurant_Click(object sender, EventArgs e)
        {
           
            listBox1.DataSource = viewRes();
            state = stateButton = 30;
            setChoseButton(btnRestaurant);
            EnableDateTime();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            listBox1.DataSource = viewInv();
            state = stateButton = 40;
            setChoseButton(btnInvoice);
            EnableDateTime();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            state = stateButton+listBox1.SelectedIndex;
            EnableDateTime();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #region ViewReporting
        private void EnableDateTime0(bool b)
        {
            txtStartTime.Enabled = b;
            txtEndTime.Enabled = b;
            txtStartDate.Enabled = b;
            txtEndDate.Enabled = b;
        }
        private void EnableDateTime()
        {
            
            switch (state)
            {
                case 0:
                    {
                        EnableDateTime0(true);
                        lstKindOfInvo.Enabled = true;
                        printerName = Printer.PrinterBaocao;
                        return;
                    }
                case 1:
                    {

                        EnableDateTime0(false);
                        lstKindOfInvo.Enabled = true;
                        lstKindOfInvo.SelectedIndex = 0;
                        lstCashier.SelectedIndex = 0;
                        printerName = Printer.PrinterBaocao;
                        return;
                    }
                case 2:
                    {
                        EnableDateTime0(true);
                        lstKindOfInvo.Enabled = false;
                        lstKindOfInvo.SelectedIndex = 0;
                        lstCashier.SelectedIndex = 0;
                        printerName = Printer.PrinterHoadon;
                        return;
                    }
                case 3:
                    {
                        EnableDateTime0(true);
                        lstKindOfInvo.Enabled = false;
                        lstKindOfInvo.SelectedIndex = 0;
                        lstCashier.SelectedIndex = 0;
                        printerName = Printer.PrinterBaocao;
                        return;
                    }
                case 4:
                    {
                        EnableDateTime0(true);
                        lstKindOfInvo.Enabled = true;
                        lstKindOfInvo.SelectedIndex = 0;
                        lstCashier.SelectedIndex = 0;
                        printerName = Printer.PrinterBaocao;
                        return;
                    }
                case 40:
                    {
                        EnableDateTime0(false);
                        lstKindOfInvo.Enabled = true;
                        lstKindOfInvo.SelectedIndex = 0;
                        lstCashier.SelectedIndex = 0;
                        printerName = Printer.PrinterBaocao;
                        return;
                    }

                case 41:
                    {
                        EnableDateTime0(true);
                        lstKindOfInvo.Enabled = false;
                        lstCashier.Enabled = false;
                        printerName = Printer.PrinterBaocao;
                        return;
                    }
                default:
                    EnableDateTime0(false);
                    lstKindOfInvo.Enabled = true;
                    lstKindOfInvo.SelectedIndex = 0;
                    lstCashier.SelectedIndex = 0;
                    printerName = Printer.PrinterBaocao;
                    return ;
            }
           
        }
        private ReportClass ViewReport(int s)
        {
            //EnableDateTime();
            switch (s)
            {
                case 0:
                    {
                        if(DateTime2.Ticks<=DateTime1.Ticks)
                        {
                            Alert.Show("Nhập Ngày Sai.\n Nhập lại ngày",Color.Red);
                            return null;
                        }
                        string status = "";
                        if(StatusInvoice==Const.Invoice_Status.THANH_TOAN_ROI)
                        {
                            status = "Hóa đơn thanh toán";
                        }else if(StatusInvoice==Const.Invoice_Status.HUY)
                        {
                            status = "Hóa đơn hủy";
                        }
                        POSReport.Report.InvoiceTotal invoiceTotal = new POSReport.Report.InvoiceTotal();
                        string[] pa = { "@Store_ID", "@DateTime1", "@DateTime2", "@Status", "@Cashier_ID","HuyOrThanhToan" };
                        object[] value = { StaticClass.storeId, DateTime1, DateTime2,StatusInvoice,Cashier_ID,status};
                        test.FillDataReport(invoiceTotal, pa, value, true);
                        return invoiceTotal;
                    }
                    
                case 1:
                    {
                        string status = "";
                        if (StatusInvoice == Const.Invoice_Status.THANH_TOAN_ROI)
                        {
                            status = "Hóa đơn thanh toán";
                        }
                        else if (StatusInvoice == Const.Invoice_Status.HUY)
                        {
                            status = "Hóa đơn hủy";
                        }
                        POSReport.Report.rptInvoiceTotalsDaily invoiceTotalsDaily = new rptInvoiceTotalsDaily();
                        string[] pa = { "@Store_ID", "Report_Title_Param", "@Status", "@Cashier_ID", "HuyOrThanhToan" };
                        object[] value = { StaticClass.storeId, "Báo cáo hóa đơn theo từng ngày", StatusInvoice, Cashier_ID, status };
                        test.FillDataReport(invoiceTotalsDaily, pa, value, true);
                        return invoiceTotalsDaily;
                    }
                case 2:
                    {

                        POSReport.Report.rptDetailSaleReport DetailSaleReport = new rptDetailSaleReport();
                        string[] pa = { "@Store_ID", "@DateTime1", "@DateTime2", "@Status", "@Cashier_ID", "Report Title", };
                        object[] value = { StaticClass.storeId, DateTime1, DateTime2, StatusInvoice, Cashier_ID, "Báo cáo bán hàng chi tiết trong ngày" };
                        test.FillDataReport(DetailSaleReport, pa, value, true);
                        return DetailSaleReport;
                    }
                case 3:
                    {
                        POSReport.Report.rptReturn rptReturn = new rptReturn();
                        string[] pa = { "@Store_ID", "@DateTime1", "@DateTime2", "@Status", "@Cashier_ID", "Report_Title", };
                        object[] value = { StaticClass.storeId, DateTime1, DateTime2, StatusInvoice, Cashier_ID, "Báo cáo các mặt hàng trả lại" };
                        test.FillDataReport(rptReturn, pa, value, true);
                        return rptReturn;
                    }
                case 4:
                    {
                        POSReport.Report.rptItemDept invoice = new rptItemDept();
                        string[] pa = { "@Store_ID", "Report_Title_Param", "@Status", "@DateTime1", "@DateTime2" };
                        object[] value = { StaticClass.storeId, "Báo cáo chi tiết bán hàng theo nhóm", StatusInvoice, DateTime1, DateTime2 };
                        test.FillDataReport(invoice, pa, value, true);
                        return invoice;
                    }
                case 40:
                    {
                        POSReport.Report.rptInventoryByApha rptInventoryByApha = new rptInventoryByApha();
                        string[] pa = { "@Store_ID", "Report_Title_Param" };
                        string[] value = { StaticClass.storeId, "Tình hình các mặt hàng trong kho" };
                        test.FillDataReport(rptInventoryByApha, pa, value, true);
                        return rptInventoryByApha; 
                    }

                case 41:
                    {
                        POSReport.Report.rptReceivedItems invoice = new rptReceivedItems();
                        string[] pa = { "@DateTime1", "@DateTime2" };
                        object[] value = { DateTime1, DateTime2 };
                        test.FillDataReport(invoice, pa, value, true);
                        return invoice;
                    }

                default:
                    return null;
            }     

        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            ReportClass reportClass= ViewReport(state);
            if (reportClass == null)
                return;
            FrmViewReporting frmViewReporting = new FrmViewReporting(reportClass);
            frmViewReporting.Show();

        }
        #region ChangeModeTime
        public static int ChangeModeTime(int hour, string mode)
        {
            if (mode.Equals("PM"))
                hour += 12;
            return hour;
        }
        #endregion


        private void lstKindOfInvo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstKindOfInvo.SelectedIndex)
            {
                case 0:
                    StatusInvoice = Const.Invoice_Status.THANH_TOAN_ROI;
                    break;
                case 1:
                    StatusInvoice = Const.Invoice_Status.HUY;
                    break;
                default:
                    break;
            }
        }

        private void lstCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cashier_ID = lstCashier.Items[lstCashier.SelectedIndex].ToString();
        }

        private void FrmReporting_Load(object sender, EventArgs e)
        {
            PopularDatain2lstCashier();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportClass reportClass = ViewReport(state);
            if (reportClass == null)
                return;
            Utils.Print(reportClass,printerName);
        }
    }
}
