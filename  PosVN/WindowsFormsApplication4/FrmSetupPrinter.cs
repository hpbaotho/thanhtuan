using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmSetupPrinter : Form
    {
        private Hashtable Printers;
        private Service.ServiceGet serviceGet;
        private Services.get_GUI getGui;
        string selectPrinter;
        public FrmSetupPrinter()
        {
            InitializeComponent();
            Printers = new Hashtable();
            serviceGet = new ServiceGet();
            getGui = new get_GUI();
        }

        private void FrmSetupPrinter_Load(object sender, EventArgs e)
        {
            ArrayList P = serviceGet.getPrinters(StaticClass.storeId, StaticClass.stationId);
            foreach (Printer o in P )
            {
                Printers.Add(o.PrinterName,o);
                listBox1.Items.Add(o.PrinterName);
                //creCheckBox1.Checked = o.Disable;
            }
            if(P.Count > 0)
            {
                selectPrinter = ((Printer) P[0]).PrinterName;
            }
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                listBox2.Items.Add(printerName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool kt = false;
            selectPrinter = listBox1.SelectedItem.ToString();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if(((Printer)Printers[listBox1.SelectedItem.ToString()]).Details == listBox2.Items[i].ToString()  )
                {
                    listBox2.SelectedIndex = i;
                    kt = true;
                    break;
                }
            }
            if(!kt)
            {
                listBox2.SelectedIndex = 0;
            }
            creCheckBox1.Checked = ((Printer) Printers[listBox1.SelectedItem.ToString()]).Disable;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Printer printer = (Printer) Printers[selectPrinter];
            printer.Details = listBox2.SelectedItem.ToString();
        }

        private void creCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
                Printer printer = (Printer)Printers[selectPrinter];
                printer.Disable = creCheckBox1.Checked;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard();
            if(frmKeyBoard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(!Printers.ContainsKey(frmKeyBoard.value))
                {
                    Printer printer = new Printer(frmKeyBoard.value,"","","NONE",false,false,false);
                    printer.isNew = true;
                    Printers.Add(frmKeyBoard.value,printer);
                    listBox1.Items.Add(frmKeyBoard.value);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    Alert.Show("Tên máy in đã có rồi",Color.Red);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Báo cáo" || listBox1.SelectedItem.ToString() == "Hóa đơn")
            {
                Alert.Show("Không thể xóa máy in này",Color.Red);
            }
            else
            {
                Printer printer = (Printer)Printers[selectPrinter];
                printer.isDelete = true;
                string oldSelectPrinter = selectPrinter;
                listBox1.SelectedIndex = 0;
                listBox1.Items.Remove(oldSelectPrinter);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList a = new ArrayList(Printers.Values);
            foreach (Printer c in a)
            {
                if(c.isNew)
                {
                    if(!c.isDelete)
                    {
                        serviceGet.InsertPrinter(c);
                    }
                }
                else if(c.isDelete)
                {
                    getGui.DeletePrinter(StaticClass.storeId,StaticClass.stationId,c.PrinterName);
                }
                else 
                {
                    getGui.UpdatePrinter(StaticClass.storeId,StaticClass.stationId,c.PrinterName,c.Disable,c.Two_Color,c.Cut_Print,c.LocalPort,c.NetworkPort,c.Details);
                }
            }
            this.Dispose();
        }
    }
}
