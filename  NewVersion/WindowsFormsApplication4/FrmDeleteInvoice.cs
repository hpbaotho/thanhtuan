using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmDeleteInvoice : Form
    {
        public DateTime startDate;
        public DateTime endDate;
        private Service.ServiceGet serviceGet;
        public FrmDeleteInvoice()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
            startDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0);
            endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serviceGet.getGui.OnholdNumber(StaticClass.storeId) != 0)
            {
                Alert.Show("Vẫn còn hóa đơn chưa\n thanh toán.", Color.Red);
                return;
            }
            if (MessBox2Choice.ShowBox("Bạn có muốn xóa tất cả \nhóa đơn không ?", Color.Red) == DialogResult.Yes)
            {
                serviceGet.getGui.ClearAllInvoice(StaticClass.storeId);
                string path = Application.StartupPath + @"\logfile.txt";
                if(File.Exists(path) )
                {
                    File.Delete(path);
                }
                Alert.Show("Xóa thành công");
            }
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            FrmCanlendar frmCanlendar = new FrmCanlendar("Chọn ngày bắt đầu");
            if(frmCanlendar.ShowDialog() == DialogResult.OK)
            {
                DateTime tmp = frmCanlendar.monthCalendar1.SelectionStart;
                startDate = new DateTime(tmp.Year,tmp.Month,tmp.Day,startDate.Hour,startDate.Minute,startDate.Second);
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

        private void FrmDeleteInvoice_Load(object sender, EventArgs e)
        {
            UpdateDatetime();
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
            if(frmTime.ShowDialog() == DialogResult.OK)
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
            DataTable onhold = serviceGet.getGui.GetInvoiceOnholdByTime(StaticClass.storeId, startDate, endDate);
            if(onhold.Rows.Count > 0 )
            {
                Alert.Show("Còn hóa đơn chưa\n thanh toán",Color.Red);
            }
            else
            {
                serviceGet.getGui.ClearAllInvoiceByDate(StaticClass.storeId,startDate,endDate);
                Alert.Show("Xóa thành công");
            }
        }
    }
}
