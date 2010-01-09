using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class FrmSetupPrinter : Form
    {
        public FrmSetupPrinter()
        {
            InitializeComponent();
        }

        private void FrmSetupPrinter_Load(object sender, EventArgs e)
        {
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                listBox2.Items.Add(printerName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
