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
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Service;
using CrystalDecisions.CrystalReports;

namespace WindowsFormsApplication4
{
    public partial class FrmReporting : Form
    {
        private byte stateButton = 0;
        public ServiceGet test = new ServiceGet();
        private DateTime DateTime1;
        private DateTime DateTime2;
        private int state = 0;
        
        public FrmReporting()
        {
            InitializeComponent();
            ArrayList thanh = new ArrayList();
            //thanh.AddRange(new string[]{"thanh","tuan"});
            listBox1.DataSource = viewSale();
            txtStartDate.Text = DateTime.Now.ToShortDateString();
            txtEndDate.Text = DateTime.Now.ToShortDateString();
            DateTime1 = DateTime.Now;
            DateTime2 = DateTime.Now;
            txtStartTime.Text = "12" + ":00"  + ":" + "00" + " " + "AM";
            txtEndTime.Text = "12" + ":00" + ":" + "00" + " " + "AM";
            setChoseButton(btnSale);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            
            listBox1.DataSource = viewEm();
            state = stateButton = 20;
            setChoseButton(btnEmployee);
            EnableDateTime();
        }

        #region Views
        private ArrayList viewSale()
        {
            return new ArrayList(new string[] { "Báo cáo hóa đơn theo thời gian", "Tình hình bán cho tới ngày hiện tại" });
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
            return new ArrayList(new string[] { "Các mặt còn trong kho", "Tình hình bán mặt hàng theo mặt hàng" });
        }

        //private ArrayList viewInv()
        //{
        //    return new ArrayList(new string[] { });
        //}
        #endregion
        
        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void startDateText(DateTime s)
        {
            txtStartDate.Text = s.ToShortDateString();
            DateTime1 = s;
        }
        private void endDateText(DateTime s)
        {
            txtEndDate.Text = s.ToShortDateString();
            DateTime2 = s;
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
                        return;
                    }
                case 1:
                    {
                        EnableDateTime0(false);
                        return;
                    }
                case 40:
                    {
                        EnableDateTime0(false);
                        return;
                    }

                case 41:
                    {
                        EnableDateTime0(false);
                        return;
                    }
                default:
                    EnableDateTime0(false);
                    return ;
            }
           
        }
        private ReportClass ViewReport(int s)
        {
            EnableDateTime();
            switch (s)
            {
                case 0:
                    {
                        if(DateTime2.Ticks<=DateTime1.Ticks)
                        {
                            Alert.Show("Nhập Ngày Sai.\n Nhập lại ngày",Color.Red);
                            return null;
                        }
                        POSReport.Report.InvoiceTotal invoiceTotal = new POSReport.Report.InvoiceTotal();
                        string[] pa = { "@Store_ID", "@DateTime1", "@DateTime2" };
                        object[] value = { StaticClass.storeId, DateTime1, DateTime2 };
                        test.FillDataReport(invoiceTotal, pa, value, true);
                        return invoiceTotal;
                    }
                    
                case 1:
                    {
                        POSReport.Report.rptInvoiceTotalsDaily invoiceTotalsDaily = new rptInvoiceTotalsDaily();
                        string[] pa = { "@Store_ID", "Report_Title_Param" };
                        object[] value = { StaticClass.storeId, "Tình hình bán hàng" };
                        test.FillDataReport(invoiceTotalsDaily, pa, value, true);
                        return invoiceTotalsDaily;
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
                        POSReport.Report.rptItemDept invoice = new rptItemDept();
                        string[] pa = { "@Store_ID", "Report_Title_Param" };
                        string[] value = { StaticClass.storeId, "Báo cáo các mặt hàng" };
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
        private int ChangeModeTime(int hour, string mode)
        {
            if (mode.Equals("PM"))
                hour += 12;
            return hour;
        }
        #endregion
    }
}
