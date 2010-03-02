using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class FrmCanlendar : Form
    {
        public string getDateTime
        {
            get
            {
                return txtNow.Text;
            }
            set
            {
                txtNow.Text = value;
            }
        }
        public FrmCanlendar()
        {
            InitializeComponent();
            txtNow.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }
        public FrmCanlendar(string header)
        {
            InitializeComponent();
            label1.Text = header;
            txtNow.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtNow.Text = e.Start.ToShortDateString();
        }

        public delegate void passDatetime(DateTime o);

        public passDatetime passDate;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (passDate != null)
                passDate(monthCalendar1.SelectionStart);
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnNextM_Click(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddMonths(1));
        }

        private void btnNextY_Click(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddYears(1));
        }

        private void btnPreM_Click(object sender, EventArgs e)
        {
            int i = monthCalendar1.SelectionStart.Month == 1 ? 12 : monthCalendar1.SelectionStart.Month - 1;
            monthCalendar1.SetDate(new DateTime(monthCalendar1.SelectionStart.Year,i,monthCalendar1.SelectionStart.Day));
        }

        private void btnPreY_Click(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(new DateTime(monthCalendar1.SelectionStart.Year-1, monthCalendar1.SelectionStart.Month, monthCalendar1.SelectionStart.Day));
        }
    }
}
