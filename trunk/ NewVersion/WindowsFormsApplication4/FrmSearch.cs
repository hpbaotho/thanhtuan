using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;

namespace WindowsFormsApplication4
{
    public partial class FrmSearch : Form
    {
        private DataTable View;
        private int RowIndex;
        private string []ColumnName;
        //private string DeptDesc;
        private Services.get_GUI get_services=new get_GUI();
        public DataGridViewRow selectRow;
        public string tableType = "Inventory";
        public FrmSearch()
        {
            InitializeComponent();
        }
        public  FrmSearch(DataTable table,string[] colum)
        {
            InitializeComponent();
            View = table;
            ColumnName = colum;
            //DeptID = _DeptID;
            //DeptDesc = _DeptDesc;
        }

    

        private void RowDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("");
        }

        public delegate void PassData(DataTable t,int rowIndex);

        public PassData passdata;
        private void ItemChosed(object sender, DataGridViewCellEventArgs e)
        {
            //View=get_services.GetAllInventory(StaticClass.storeId);
            //RowIndex=dataGridView1.SelectedCells[0].
            selectRow = dataGridView1.SelectedRows[0];
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //   if(dataGridView1.Rows[i].Selected)
            //       RowIndex = i;
            //}

            for (int i = 0; i < View.Rows.Count; i++)
            {
                if (selectRow.Cells[0].Value.ToString() == View.Rows[i][0].ToString())
                {
                    RowIndex = i;
                    break;
                }
            }

            if (passdata != null)
            {
                passdata(View, RowIndex);
            }
            //MessageBox.Show(e.RowIndex.ToString());

            this.DialogResult = DialogResult.OK;
            //this.Dispose();
        }

        private void RowClicked(object sender, DataGridViewCellEventArgs e)
        {
            //RowIndex = e.RowIndex;
            
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            if(tableType == "Invoices")
            {
                btnSelect.Text = "In hóa đơn";
            }
            dataGridView1.DataSource = View;
          
            for(int i=0;i<dataGridView1.Columns.Count;i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            for (int i = 0; i < ColumnName.Length; i++)
            {
                dataGridView1.Columns[ColumnName[i]].Visible = true;
                dataGridView1.Columns[ColumnName[i]].Width = 220;
            }
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            //View=get_services.GetAllInventory(StaticClass.storeId);
            //RowIndex=dataGridView1.SelectedCells[0].
            selectRow = dataGridView1.SelectedRows[0];
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //   if(dataGridView1.Rows[i].Selected)
            //       RowIndex = i;
            //}

            for (int i = 0; i < View.Rows.Count; i++)
            {
                if(selectRow.Cells[0].Value.ToString() == View.Rows[i][0].ToString())
                {
                    RowIndex = i;
                    break;
                }
            }
            
            if (passdata != null)
            {
                passdata(View, RowIndex);
            }
            //MessageBox.Show(e.RowIndex.ToString());
            
            this.DialogResult = DialogResult.OK;
            //this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tableType == "Inventory")
            {
                dataGridView1.DataSource = get_services.IndexSearchInventory(textBox1.Text,StaticClass.storeId);
            }
            else if(tableType == "Employee")
            {
                dataGridView1.DataSource = get_services.IndexSearchEmp(textBox1.Text);
            }
            else if(tableType == "Department")
            {
                dataGridView1.DataSource = get_services.IndexSearchDepartment(textBox1.Text,StaticClass.storeId);
            }
            else if (tableType == "Invoices")
            {
                dataGridView1.DataSource = get_services.IndexSearchInvoices(textBox1.Text, StaticClass.storeId);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (tableType == "Inventory")
                {
                    dataGridView1.DataSource = get_services.IndexSearchInventory(textBox1.Text,StaticClass.storeId);
                }
                else if (tableType == "Employee")
                {
                    dataGridView1.DataSource = get_services.IndexSearchEmp(textBox1.Text);
                }
                else if (tableType == "Department")
                {
                    dataGridView1.DataSource = get_services.IndexSearchDepartment(textBox1.Text,StaticClass.storeId);
                }
                else if (tableType == "Invoices")
                {
                    dataGridView1.DataSource = get_services.IndexSearchInvoices(textBox1.Text, StaticClass.storeId);
                }
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                //p.StartInfo.WorkingDirectory = @"C:\whatever";
                p.StartInfo.FileName = Application.StartupPath + @"\FreeVK.exe";
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                textBox1.Focus();
                //p.WaitForExit();
            }
            catch (Exception)
            {
                Alert.Show("Chương trình FreeVK.exe\n không tồn tại.", Color.Red);
            }
        }
    }
}
