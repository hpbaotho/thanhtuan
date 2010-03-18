using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using POSReport.Report;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4.Utilities
{
    public static class Utils
    {
        public static void Print(ReportClass reportClass,string printerName)
        {
            Service.ServiceGet serviceGet = new ServiceGet();
            Printer printer = serviceGet.GetPrinterByName(StaticClass.storeId, StaticClass.stationId, printerName);
            if (!(printer == null || printer.Details == "NONE" || printer.Disable == true))
            {
                if (StaticClass.mode == "AUT")
                {
                    reportClass.DataSourceConnections[0].SetConnection(StaticClass.serverName, StaticClass.databaseName, true);
                }
                else if (StaticClass.mode == "SQL")
                {
                    //reportClass.DataSourceConnections[0].SetConnection(StaticClass.serverName, StaticClass.databaseName,
                                                                      // StaticClass.userName, StaticClass.password);
                    reportClass.SetDatabaseLogon(StaticClass.userName, StaticClass.password, StaticClass.serverName,
                                                 StaticClass.databaseName,true);
                    reportClass.DataSourceConnections[0].IntegratedSecurity = false;
                }
                else
                {
                    return;
                }
                
                reportClass.PrintOptions.PrinterName = printer.Details;
                if(printerName == "Hóa đơn")
                {
                    reportClass.PrintOptions.ApplyPageMargins(new PageMargins(1, 2, 1, 0));
                }
                
                try
                {
                    reportClass.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    Alert.Show("Lỗi máy in", Color.Red);
                }
                
            }
        }

        public static string translateDate(DateTime dateTime)
        {
            
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Thứ Hai";
                case DayOfWeek.Tuesday:
                    return "Thứ Ba";
                case DayOfWeek.Wednesday:
                    return "Thứ Tư";
                case DayOfWeek.Thursday:
                    return "Thứ Năm";
                case DayOfWeek.Friday:
                    return "Thứ Sáu";
                case DayOfWeek.Saturday:
                    return "Thứ Bảy";
                case DayOfWeek.Sunday:
                    return "Chủ nhật";
            }
            return "";
        }
    }
}
