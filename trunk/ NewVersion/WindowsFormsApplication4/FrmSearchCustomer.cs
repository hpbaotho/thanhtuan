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
    public partial class FrmSearchCustomer : Form
    {
        private DataTable View;
        public int RowIndex;
        private string[] ColumnName;
        //private string DeptDesc;
        private Services.get_GUI get_services = new get_GUI();
        public DataGridViewRow selectRow;
        public FrmSearchCustomer()
        {
            InitializeComponent();
        }

        public FrmSearchCustomer(DataTable table, string[] colum)
        {
            InitializeComponent();
            View = table;
            ColumnName = colum;
            //DeptID = _DeptID;
            //DeptDesc = _DeptDesc;
        }

        private void FrmSearchCustomer_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = View;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            for (int i = 0; i < ColumnName.Length; i++)
            {
                dataGridView1.Columns[ColumnName[i]].Visible = true;
                dataGridView1.Columns[ColumnName[i]].Width = 220;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                selectRow = dataGridView1.SelectedRows[0];
                for (int i = 0; i < View.Rows.Count; i++)
                {
                    if (selectRow.Cells[0].Value.ToString() == View.Rows[i][0].ToString())
                    {
                        RowIndex = i;
                        break;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Alert.Show("Chưa chọn khách hàng !",Color.Red);
            }
            
        }

        private void creTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dataTable = get_services.getCustBySwipe(creTextBox1.Text);
                if(dataTable.Rows.Count >0)
                {
                    dataGridView1.DataSource = dataTable;
                    selectRow = dataGridView1.Rows[0];
                    for (int i = 0; i < View.Rows.Count; i++)
                    {
                        if(selectRow.Cells[0].Value.ToString() == View.Rows[i][0].ToString())
                        {
                            RowIndex = i;
                            break;
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    creTextBox1.Text = "";
                    creTextBox1.Focus();
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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = get_services.IndexSearchCust(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView1.DataSource = get_services.IndexSearchCust(textBox1.Text);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectRow = dataGridView1.SelectedRows[0];
                for (int i = 0; i < View.Rows.Count; i++)
                {
                    if (selectRow.Cells[0].Value.ToString() == View.Rows[i][0].ToString())
                    {
                        RowIndex = i;
                        break;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Alert.Show("Chưa chọn khách hàng !", Color.Red);
            }
        }
    }
}
