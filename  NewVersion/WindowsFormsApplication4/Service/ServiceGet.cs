using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using POSReport.Report;
using Services;
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Persistence;


namespace WindowsFormsApplication4.Service
{
    public class ServiceGet
    {
        get_GUI getGui ;
        public ServiceGet()
        {
            getGui = new get_GUI();
        }

        public ArrayList getArrayButton(string storeID,string sectionName)
        {
            ArrayList mangButton = new ArrayList();
            DataTable tbl =  getGui.get_Array_button(storeID, sectionName);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                int x = (int)tbl.Rows[i][4];
                int y = (int)tbl.Rows[i][5];
                int height = (int)tbl.Rows[i][6];
                int width = (int)tbl.Rows[i][7];
                var tmpBut = new button(x, y, width, height);
                mangButton.Add(tmpBut);
            }
            return mangButton;
        }
        public DataTable getSections(string storeID)
        {
            return getGui.GetAllSections(storeID);
        }
        public ArrayList getTables(string storeID, string sectionName)
        {
            ArrayList mangButton = new ArrayList();
            DataTable tbl = getGui.GetAllTablesBySectionID(storeID,sectionName);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if ((int)tbl.Rows[i][10] == 0)
                {
                    int x = (int)tbl.Rows[i][4];
                    int y = (int)tbl.Rows[i][5];
                    int height = (int)tbl.Rows[i][6];
                    int width = (int)tbl.Rows[i][7];
                    int shapeType = (int) tbl.Rows[i][3];
                    TransButton.Shape shape;
                    if(shapeType == 0)
                    {
                        shape = TransButton.Shape.Rec;
                    }
                    else if(shapeType == 1)
                    {
                        shape = TransButton.Shape.Square;
                    }
                    else
                    {
                        shape = TransButton.Shape.Elip;
                    }
                   
                    var tmpBut = new TransButton(x, y, width, height);
                    tmpBut.ForeColor = Color.FromArgb((int)tbl.Rows[i][13]);
                    tmpBut.BorderColor = Color.FromArgb((int)tbl.Rows[i][13]);
                    if (tbl.Rows[i][17].ToString() != "")
                    {
                        tmpBut.cashierId = tbl.Rows[i][16].ToString();
                        if (tbl.Rows[i][16].ToString() == StaticClass.cashierId)
                        {
                            tmpBut.BackColor = Color.Green;
                        }
                        else
                        {
                            tmpBut.BackColor = Color.Orange;
                        }
                        if (Convert.ToBoolean(tbl.Rows[i][15]))
                        {
                            tmpBut.BackColor = Color.Red;
                            tmpBut.ForeColor = Color.Gray;
                            tmpBut.Enabled = false;
                        }
                        tmpBut.invoiceNum = tbl.Rows[i][17].ToString();
                    }
                    
                    tmpBut.ButtonShape = shape;
                    tmpBut.tableName = tbl.Rows[i][2].ToString();
                    tmpBut.ButtonText = tbl.Rows[i][2].ToString();
                    mangButton.Add(tmpBut);
                }
               
            }
            return mangButton;
        }
        public ArrayList getTablesEdit(string storeID, string sectionName)
        {
            ArrayList mangButton = new ArrayList();
            DataTable tbl = getGui.GetAllTablesBySectionID(storeID, sectionName);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if ((int)tbl.Rows[i][10] == 0)
                {
                    int x = (int)tbl.Rows[i][4];
                    int y = (int)tbl.Rows[i][5];
                    int height = (int)tbl.Rows[i][6];
                    int width = (int)tbl.Rows[i][7];
                    MyButton.ButtonStyles style;
                    if((int)tbl.Rows[i][3] == 0 || (int)tbl.Rows[i][3] == 1 )
                    {
                        style = MyButton.ButtonStyles.Rectangle;
                    }
                    else
                    {
                        style = MyButton.ButtonStyles.Ellipse;
                    }
                    var tmpBut = new MyButton(x, y, width, height, style);
                    tmpBut.borColor = Color.FromArgb((int) tbl.Rows[i][13]);
                    tmpBut.Text_pro = tbl.Rows[i][2].ToString();
                    mangButton.Add(tmpBut);
                }   
            }
            return mangButton;
        }
        public DataTable GetDepartments(string storeID)
        {
            return getGui.GetAllDepartments(storeID);

        }

        public int Login(string Id,string pass,string storeId)
        {
            DataTable getCashierpass = getGui.GetEmployeePass(Id);
            if(getCashierpass.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                string cashierPass = getCashierpass.Rows[0][1].ToString();
                string adminPass = getGui.GetAdminPass(storeId).Rows[0][1].ToString();
                if(pass.ToLower() == cashierPass.ToLower() || pass.ToLower() == adminPass.ToLower())
                {
                    if (pass.ToLower() == cashierPass.ToLower())
                    {
                        StaticClass.isAdmin = false;
                    }
                    else
                    {
                        StaticClass.isAdmin = true;
                    }
                    StaticClass.cashierId = Id;
                    DataTable thongTinNV = getGui.GetEmployeeByID(storeId,Id);
                    StaticClass.thongTinNV = thongTinNV.Rows[0];
                    return 2;
                }
                else
                {
                    return 1;
                }
                
            }
        }
        public bool checkAdminPass(string pass,string storeId)
        {
            if(pass.ToLower() == getGui.GetAdminPass(storeId).Rows[0][1].ToString().ToLower())
            {
                return true;
            }
            return false;
        }
        public DataTable InvoiceTotal(string Store_ID, DateTime DateTime1, DateTime DateTime2)
        {
            return getGui.GetInvoiceTotalByStoreID(Store_ID, DateTime1, DateTime2);
        }

        public void FillDataReport(ReportClass report,string[] para, object[] value,bool mode)
        {
            report.DataSourceConnections[0].SetConnection(Services.get_GUI.serverName, Services.get_GUI.databaseName, true);
            for (int i = 0; i < para.Length; i++)
            {
                report.SetParameterValue(para[i], value[i].ToString());
            }
        }
        public ArrayList getPrinters(string store_ID,string station_ID)
        {
            ArrayList printers = new ArrayList();
            DataTable record = getGui.GetPrinters(store_ID, station_ID);
            for (int i = 0; i < record.Rows.Count; i++)
            {
                string PrinterName = record.Rows[i]["PrinterName"].ToString();
                string NetworkPort = record.Rows[i]["NetworkPort"].ToString();
                string Localport = record.Rows[i]["LocalPort"].ToString();
                string detail = record.Rows[i]["Details"].ToString();
                bool disable = Convert.ToBoolean(record.Rows[i]["Disabled"]);
                bool twoColor = Convert.ToBoolean(record.Rows[i]["Two_Color_Printing"]);
                bool cutPrint = Convert.ToBoolean(record.Rows[i]["CutReceipt"]);
                Printer printer = new Printer(PrinterName,Localport,NetworkPort,detail,disable,twoColor,cutPrint);
                printers.Add(printer);
            }
            return printers;
        }
        public void InsertPrinter(Printer printer)
        {
            getGui.InsertPrinter(StaticClass.storeId,StaticClass.stationId,printer.PrinterName,printer.Disable,printer.Two_Color,printer.Cut_Print,printer.LocalPort,printer.NetworkPort,printer.Details);
        }
        public Printer GetPrinterByName(string store_ID, string station_ID,string Name)
        {
            DataTable record = getGui.GetPrinterByName(StaticClass.storeId, StaticClass.stationId, Name);
            if(record.Rows.Count > 0)
            {
                string PrinterName = record.Rows[0]["PrinterName"].ToString();
                string NetworkPort = record.Rows[0]["NetworkPort"].ToString();
                string Localport = record.Rows[0]["LocalPort"].ToString();
                string detail = record.Rows[0]["Details"].ToString();
                bool disable = Convert.ToBoolean(record.Rows[0]["Disabled"]);
                bool twoColor = Convert.ToBoolean(record.Rows[0]["Two_Color_Printing"]);
                bool cutPrint = Convert.ToBoolean(record.Rows[0]["CutReceipt"]);
                Printer printer = new Printer(PrinterName, Localport, NetworkPort, detail, disable, twoColor, cutPrint);
                return printer;
            }
            return null;
        }
        public ArrayList getAllInventPrinter(string storeId,string itemNum)
        {
            DataTable p = getGui.GetAllInventPrinter(storeId, itemNum);
            ArrayList printers = new ArrayList();
            for (int i = 0; i < p.Rows.Count; i++)
            {
                string pName = p.Rows[i]["PrinterName"].ToString();
                Printer printer = new Printer(pName);
                printers.Add(printer);
            }
            return printers;
        }
        public void UpdateInventPrinter(ArrayList printers,string itemNum)
        {
            foreach (Printer o in printers)
            {
                if(o.isDelete == true && o.isNew == false)
                {
                    getGui.DeleteInventPrinter(StaticClass.storeId,itemNum,o.PrinterName);
                }
                else if (o.isDelete == false && o.isNew == true)
                {
                    getGui.InsertInventPrinter(StaticClass.storeId,itemNum,o.PrinterName,"123");
                }
            }
        }
    }
}
