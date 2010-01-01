using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using POSReport.Report;

namespace POSReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport5 xxx = new CrystalReport5();
            xxx.DataSourceConnections[0].SetConnection("TUAN\\SQLEXPRESS","POSMIENNAM",true);
            MessageBox.Show(xxx.DataSourceConnections[0].DatabaseName);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();

            ParameterFieldDefinitions crParameterFieldDefinitions1;
            ParameterFieldDefinition crParameterFieldDefinition1;
            ParameterValues crParameterValues1 = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();


            crParameterDiscreteValue.Value = "1001";
            crParameterFieldDefinitions = xxx.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Store_ID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue1.Value = textBox1.Text;
            crParameterFieldDefinitions1 = xxx.DataDefinition.ParameterFields;
            crParameterFieldDefinition1 = crParameterFieldDefinitions1["@Invoice_Number"];
            crParameterValues1 = crParameterFieldDefinition1.CurrentValues;

            crParameterValues1.Clear();
            crParameterValues1.Add(crParameterDiscreteValue1);
            crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);


            xxx.PrintToPrinter(1, true, 1, 1);
            crystalReportViewer1.ReportSource = xxx;
        }
    }
}
