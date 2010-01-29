using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

namespace WindowsFormsApplication4
{
    public partial class FrmViewReporting : Form
    {
        public FrmViewReporting()
        {
            InitializeComponent();
        }
        public FrmViewReporting(ReportClass report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
