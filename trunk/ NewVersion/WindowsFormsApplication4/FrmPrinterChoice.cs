using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmPrinterChoice : FrmPOS
    {
        private Service.ServiceGet serviceGet;
        public string PrinterName;
        public FrmPrinterChoice()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
        }

        private void FrmPrinterChoice_Load(object sender, EventArgs e)
        {
            ArrayList printers = serviceGet.getPrinters(StaticClass.storeId, StaticClass.stationId);
            foreach (Printer o in printers)
            {
                creListBox1.Items.Add(o.PrinterName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(creListBox1.SelectedItem != null)
            {
                PrinterName = creListBox1.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Alert.Show("Chưa chọn máy in",Color.Red);
            }
        }
    }
}
