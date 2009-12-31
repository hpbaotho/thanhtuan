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
    public partial class FrmQuanLyDanhMuc : Form
    {
        private DataTable catagries;
        private Services.get_GUI services;
        private int limit;
        private int currentIndex;
        public FrmQuanLyDanhMuc()
        {
            InitializeComponent();
            services=new get_GUI();

            catagries = services.GetAllCategories(StaticClass.storeId);
            dataBinding();
        }
        private void dataBinding()
        {
            creComboBox1.DataSource = catagries;
            creComboBox1.DisplayMember = catagries.Columns[0].ColumnName;
        }
        private void FrmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            changeState(catagries, 0);   
            limit = catagries.Rows.Count - 1;
            currentIndex = 0; 
        }
        private void changeState(DataTable table, int rowIndex)
        {
            //SetCurrentIndexComboBox(table, rowIndex);
            creComboBox1.SelectedIndex = currentIndex;
            txtMa.Text = table.Rows[rowIndex][0].ToString();
            txtMota.Text = table.Rows[rowIndex][2].ToString();
           
        }
       
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if(btn_thoat.Text.Equals("Thoát"))
                this.Dispose();
            else
            {
                btn_Them.Text = "Thêm";
                btn_capnhat.Enabled = true;
                btn_xoa.Enabled = true;
                btn_thoat.Text = "Thoát";
                txtMa.Enabled = false;
                txtMota.SelectionStart = 0;
                txtMota.Focus();
                txtMota.SelectionLength = txtMota.Text.Length;
                button1.Visible = true;
                button2.Visible = true;
                label3.Visible = true;
                creComboBox1.Visible = true;
                //button1.Invoke(new EventHandler(button1_Click), button1, null);
                button1_Click(button1,null);
                this.Refresh();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //txtMota.Enabled = false;
            txtMota.Focus();
            txtMota.SelectionStart = 0;
            txtMota.SelectionLength = txtMota.Text.Length;
            if (currentIndex == limit)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            changeState(catagries, currentIndex);
            //this.panel2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMota.Focus();
            txtMota.SelectionStart = 0;
            txtMota.SelectionLength = txtMota.Text.Length;
            if (currentIndex == 0)
            {
                currentIndex = limit;
            }
            else
            {
                currentIndex--;
            }
            changeState(catagries, currentIndex);
            //this.panel2.Refresh();
                   
        }

        private void creComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView r = (DataRowView) creComboBox1.SelectedItem;
            txtMa.Text = r.Row[0].ToString();
            txtMota.Text = r.Row[2].ToString();
            txtMota.SelectionStart = 0;
            txtMota.SelectionLength = txtMota.Text.Length;
        }


        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            DataRowView r = (DataRowView) creComboBox1.SelectedItem;
            services.UpdateCategory(r.Row[0].ToString(),StaticClass.storeId,txtMota.Text);
            txtMota.Enabled = true;
            txtMota.SelectionStart = 0;
            txtMota.Focus();
            txtMota.SelectionLength = txtMota.Text.Length;

            catagries = services.GetAllCategories(StaticClass.storeId);
            limit = catagries.Rows.Count - 1;
            for (int i = 0; i < catagries.Rows.Count; i++)
            {
                if (catagries.Rows[i][0].Equals(txtMa.Text))
                {
                    currentIndex = i;
                    break;
                }
            }
            dataBinding();
            creComboBox1.SelectedIndex = currentIndex;

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ToggleState();
        }
        private void ToggleState()
        {
            if(btn_Them.Text.Equals("Thêm"))
            {
                btn_Them.Text = "Lưu Lại";
                btn_capnhat.Enabled = false;
                btn_xoa.Enabled = false;
                btn_thoat.Text = "Hủy";
                txtMa.Text = "";
                txtMa.Enabled = true;
                txtMa.Focus();
                txtMota.Text = "";
                txtMota.Enabled = true;
                button1.Visible = false;
                button2.Visible = false;
                label3.Visible = false;
                creComboBox1.Visible = false;
                this.Refresh();
                //creComboBox1.SelectedIndexChanged -= new System.EventHandler(this.creComboBox1_SelectedIndexChanged);
                return;
            }
            if(txtMa.Text.Equals(""))
            {
                MessageBox.Show("ban pai nhap ma danh muc");
                txtMa.Focus();
                return;
            }
            
            services.InsertCategory(txtMa.Text,StaticClass.storeId,txtMota.Text);
            catagries = services.GetAllCategories(StaticClass.storeId);
            limit = catagries.Rows.Count - 1;
            for (int i = 0; i < catagries.Rows.Count; i++)
            {
                if (catagries.Rows[i][0].Equals(txtMa.Text))
                {
                    currentIndex = i;
                    break;
                }
            }
            btn_Them.Text = "Thêm";
            btn_capnhat.Enabled = true;
            btn_xoa.Enabled = true;
            btn_thoat.Text = "Thoát";
            txtMa.Enabled = false;

            txtMota.SelectionStart = 0;
            txtMota.Focus();
            txtMota.SelectionLength = txtMota.Text.Length;
            button1.Visible = true;
            button2.Visible = true;
            label3.Visible = true;

            creComboBox1.Visible = true;
            this.Refresh();
            dataBinding();
            creComboBox1.SelectedIndex = currentIndex;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(creComboBox1.SelectedText);
            //MessageBox.Show(creComboBox1.GetItemText(creComboBox1.SelectedItem));
            string CatId = creComboBox1.GetItemText(creComboBox1.SelectedItem);
            if(CatId.Equals("NONE"))
            {
                MessageBox.Show("Bạn không được xóa thư mục này");
                return;
            }
            DataTable tmp = services.GetAllDepartmentsBySubType(StaticClass.storeId,CatId);
            
            if(tmp.Rows.Count>0)
            {
                if(MessageBox.Show("neu xoa thi nhung mat hang thuoc loai nay se dc set None","chu y",MessageBoxButtons.YesNo).Equals(System.Windows.Forms.DialogResult.Yes))
                    services.DeleteCategory(creComboBox1.GetItemText(creComboBox1.SelectedItem),StaticClass.storeId);
                return;
            }
            
            services.DeleteCategory(creComboBox1.GetItemText(creComboBox1.SelectedItem), StaticClass.storeId);
            catagries = services.GetAllCategories(StaticClass.storeId);
            limit = catagries.Rows.Count - 1;
            dataBinding();
            button1_Click(button1,null);
        }
    }
}
