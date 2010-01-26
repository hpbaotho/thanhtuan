using System;
using System.Collections.Generic;
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
                reportClass.DataSourceConnections[0].SetConnection(StaticClass.serverName, StaticClass.databaseName, true);
                reportClass.PrintOptions.PrinterName = printer.Details;
                reportClass.PrintOptions.ApplyPageMargins(new PageMargins(1, 2, 1, 0));
                reportClass.PrintToPrinter(1,false,0,0);
            }
        }
    }
}
