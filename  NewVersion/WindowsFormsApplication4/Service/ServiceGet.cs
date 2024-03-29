﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using POSReport.Report;
using Services;
using WindowsFormsApplication4.Const;
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.RPDatasets;
using WindowsFormsApplication4.RPDatasets.RPDataset1TableAdapters;


namespace WindowsFormsApplication4.Service
{
    public class ServiceGet
    {
        public get_GUI getGui ;
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
                            tmpBut.BackColor = Color.BlueViolet;
                        }
                        if (Convert.ToBoolean(tbl.Rows[i][15]))
                        {
                            tmpBut.BackColor = Color.Red;
                            tmpBut.ForeColor = Color.Gray;
                            //tmpBut.Enabled = false;
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
                string adminSwipe = getGui.GetAdminPass(storeId).Rows[0][2].ToString();
                DataTable thongTinNV = getGui.GetEmployeeByID(storeId, Id);
                if (Convert.ToBoolean(thongTinNV.Rows[0][Employee_Prop.Disabled]))
                {
                    return 3;
                }
                if (pass.ToLower() == cashierPass.ToLower() || pass.ToLower() == adminPass.ToLower() || (pass.ToLower() == adminSwipe.ToLower() && adminSwipe != ""))
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
                    //DataTable thongTinNV = getGui.GetEmployeeByID(storeId,Id);
                    StaticClass.thongTinNV = thongTinNV.Rows[0];
                    return 2;
                }
                else
                {
                    return 1;
                }
                
            }
        }

        public int LoginBySwipe(string swipe,string storeId)
        {
            DataTable emp = getGui.GetEmpSwipe(swipe, storeId);
            if(swipe == "")
            {
                return 1;
            }
            if(emp.Rows.Count > 0)
            {
                StaticClass.isAdmin = false;
                StaticClass.cashierId = emp.Rows[0]["Cashier_ID"].ToString();
                StaticClass.thongTinNV = emp.Rows[0];
                return 0;
            }
            return 1;
        }

        public bool checkAdminPass(string pass,string storeId)
        {
            DataTable adminPass = getGui.GetAdminPass(storeId);
            if (pass.ToLower() == adminPass.Rows[0][1].ToString().ToLower() || (pass.ToLower() == adminPass.Rows[0][2].ToString().ToLower() && adminPass.Rows[0][2].ToString().ToLower()!=""))
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
            if(mode)
            {
                report.DataSourceConnections[0].SetConnection(Services.get_GUI.serverName, Services.get_GUI.databaseName, true);
            }
            else
            {
                report.SetDatabaseLogon(StaticClass.userName, StaticClass.password, StaticClass.serverName,
                                                 StaticClass.databaseName, true);
                report.DataSourceConnections[0].IntegratedSecurity = true;
            }
            
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
        public ArrayList getPrintersOfKitchen(string store_ID, string station_ID)
        {
            ArrayList printers = new ArrayList();
            DataTable record = getGui.GetPrintersOfKitchen(store_ID, station_ID);
            for (int i = 0; i < record.Rows.Count; i++)
            {
                string PrinterName = record.Rows[i]["PrinterName"].ToString();
                string NetworkPort = record.Rows[i]["NetworkPort"].ToString();
                string Localport = record.Rows[i]["LocalPort"].ToString();
                string detail = record.Rows[i]["Details"].ToString();
                bool disable = Convert.ToBoolean(record.Rows[i]["Disabled"]);
                bool twoColor = Convert.ToBoolean(record.Rows[i]["Two_Color_Printing"]);
                bool cutPrint = Convert.ToBoolean(record.Rows[i]["CutReceipt"]);
                Printer printer = new Printer(PrinterName, Localport, NetworkPort, detail, disable, twoColor, cutPrint);
                printers.Add(printer);
            }
            return printers;
        }


        public void InsertPrinter(Printer printer,string station)
        {
            getGui.InsertPrinter(StaticClass.storeId,station,printer.PrinterName,printer.Disable,printer.Two_Color,printer.Cut_Print,printer.LocalPort,printer.NetworkPort,printer.Details);
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

        public ArrayList GetTSButtonDept(string storeID)
        {
            DataTable table = getGui.GetAllTSButtonDept(storeID);
            ArrayList re = new ArrayList();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TSButtonDept tsButton = new TSButtonDept("01", Convert.ToInt32(table.Rows[i]["Index"]),
                 table.Rows[i]["Caption"].ToString(), table.Rows[i]["Picture"].ToString(), table.Rows[i]["Option1"].ToString(),
                 Convert.ToInt32(table.Rows[i]["BackColor"]), Convert.ToInt32(table.Rows[i]["ForeColor"]), Convert.ToBoolean(table.Rows[i]["Visible"]),
                 table.Rows[i]["Ident"].ToString(), GetTSButtonInvent(table.Rows[i]["Ident"].ToString(), storeID));
                re.Add(tsButton);
            }
            return re;
        }

        public ArrayList GetTSButtonInvent( string DeptId, string StoreID)
        {
            DataTable table = getGui.GetAllTSButtonInvent(StoreID,DeptId);
            ArrayList re = new ArrayList();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TSButton tsButton = new TSButton("01", Convert.ToInt32(table.Rows[i]["Index"]),
                 table.Rows[i]["Caption"].ToString(), table.Rows[i]["Picture"].ToString(), table.Rows[i]["Option1"].ToString(),
                 Convert.ToInt32(table.Rows[i]["BackColor"]), Convert.ToInt32(table.Rows[i]["ForeColor"]), Convert.ToBoolean(table.Rows[i]["Visible"]),
                 table.Rows[i]["Ident"].ToString());
                re.Add(tsButton);
            }
            return re;
        }

        public ArrayList GetInventIngredient(string storeId, string itemNum)
        {
            DataTable ingredient = getGui.GetIngredient(itemNum, storeId);
            ArrayList re = new ArrayList();
            for (int i = 0; i < ingredient.Rows.Count; i++)
            {
                Ingredient ingre = new Ingredient(ingredient.Rows[i]["Ingredient"].ToString(), ingredient.Rows[i]["ItemName"].ToString(),
                    Convert.ToSingle(ingredient.Rows[i]["Quantity"]), Convert.ToInt32(ingredient.Rows[i]["Measurement"]),
                    Convert.ToSingle(ingredient.Rows[i]["Yield"]), Convert.ToDecimal(ingredient.Rows[i]["Cost"]));
                ingre.Instock = Convert.ToSingle(ingredient.Rows[i]["In_Stock"]);
                re.Add(ingre);
            }
            return re;
        }

        public ArrayList GetCustSwipeById(string custId)
        {
            ArrayList re = new ArrayList();
            DataTable table = getGui.getCustSwipeById(custId);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                CustomerSwipe customerSwipe = new CustomerSwipe(table.Rows[i]["Swipe_ID"].ToString());
                re.Add(customerSwipe);
            }
            return re;
        }
        public ArrayList GetReasonCode(string StoreID,short Type)
        {
            RPDatasets.RPDataset1TableAdapters.Setup_Reason_CodesTableAdapter setup_Reason_CodesTableAdapter =
                new Setup_Reason_CodesTableAdapter {Connection = DAO.DataProvider.ConnectionData(StaticClass.RPServer)};
            DataTable dataTable = setup_Reason_CodesTableAdapter.GetData(StaticClass.storeId,
                                                                  Type);
            ArrayList reasonlist = new ArrayList();  
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ReasonCode reasonCode = new ReasonCode(dataTable.Rows[i]["Reason_Code"].ToString(), Convert.ToInt32(dataTable.Rows[i]["Reason_Type"]));
                reasonlist.Add(reasonCode);
            }
            return reasonlist;
        }

    }
}
