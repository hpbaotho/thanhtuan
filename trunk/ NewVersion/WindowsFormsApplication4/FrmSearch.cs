using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (passdata!=null)
            {
                passdata(View,e.RowIndex);
            }
            //MessageBox.Show(e.RowIndex.ToString());
            this.Dispose();
        }

        private void RowClicked(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = View;
          
            for(int i=0;i<dataGridView1.Columns.Count;i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            for (int i = 0; i < ColumnName.Length; i++)
            {
                dataGridView1.Columns[ColumnName[i]].Visible = true;
            }
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            //View=get_services.GetAllInventory(StaticClass.storeId);
            //RowIndex=dataGridView1.SelectedCells[0].
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               if(dataGridView1.Rows[i].Selected)
                   RowIndex = i;
            }
            
            if (passdata != null)
            {
                passdata(View, RowIndex);
            }
            //MessageBox.Show(e.RowIndex.ToString());
            this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
