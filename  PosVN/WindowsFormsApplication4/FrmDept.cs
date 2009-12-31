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
   
    public partial class FrmDept : FrmPOS
    {

        #region MyNotes
            //button1: btn_Thêm;
            //button2: btn_Lưu thay đổi;
            //button3: btn_Quản lý ds;
            //button4: btn_sao chép;
            //button5: btn_xóa;
            //button7: btn_thoát;
            //button8: btn_trước;
            //button9: btn_sau;
            //button10: btn_tìm kiếm;
        #endregion
        private Services.get_GUI get_service;
        private string text_header = "Thông tin chung cho ";
        private int currentIndex;
        private int limit;
        private DataTable departs;
        private DataTable Categories;
        private string OldDept_ID;
        public FrmDept()
        {
            get_service = new get_GUI();
            InitializeComponent();
            Categories = get_service.GetAllCategories(StaticClass.storeId);
            Service.Util.UpdateDataTableForCombo(cmbCate,Categories, 2);
            for(int j=0;j<Categories.Rows.Count;j++)
            {
                if(Categories.Rows[j][2].Equals("Không phân loại"))
                {
                    cmbCate.SelectedIndex = j;
                    return;
                }
            }

          
        }

        private void FrmDept_Load(object sender, EventArgs e)
        {
            int i = cmbCate.SelectedIndex;
            
            DataTable departmentsBysubType = get_service.GetAllDepartmentsBySubType(StaticClass.storeId, get_service.GetAllCategories(StaticClass.storeId).Rows[i][0].ToString());
            changeState(departmentsBysubType, 0);
            departs = get_service.GetAllDepartments2(StaticClass.storeId);
            limit = departs.Rows.Count-1;
            //get current index of Cmb in departs
            for (int j = 0; j < departs.Rows.Count; j++)
            {
                DataRowView tmp = (DataRowView)cmbCate.SelectedItem;
                if(tmp.Row[0].Equals(departs.Rows[j][7]))
                {
                    currentIndex = j;
                    break;
                }
            }
        }
        private void SetCurrentIndexComboBox(DataTable table,int rowIndex)
        {
            DataRowView tmp = (DataRowView)cmbCate.SelectedItem;
            if (!tmp.Row[0].Equals(table.Rows[rowIndex][7]))
            {
                for (int i = 0; i < Categories.Rows.Count; i++)
                {
                    if (Categories.Rows[i][0].Equals(table.Rows[rowIndex][7]))
                    {
                        cmbCate.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        private void changeState(DataTable table,int rowIndex)
        {
            SetCurrentIndexComboBox(table,rowIndex);
            txtDeptID.Text = table.Rows[rowIndex][0].ToString();
            txtDeptDesc.Text = table.Rows[rowIndex][2].ToString();
            label1.Text = text_header + "'"+table.Rows[rowIndex][2].ToString()+"'";
            Type(Convert.ToInt16(table.Rows[rowIndex][3]));
            checkedAttribute(Convert.ToBoolean(table.Rows[rowIndex][8]), table.Rows[rowIndex][9].ToString(), Convert.ToBoolean(table.Rows[rowIndex][10]), Convert.ToBoolean(table.Rows[rowIndex][11]), Convert.ToBoolean(table.Rows[rowIndex][12]), Convert.ToDouble(table.Rows[rowIndex][13]), Convert.ToInt32(table.Rows[rowIndex][14]));
        }

        private void Type(int t)
        {
            switch (t)
            {
                case 0:
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    return;
                case 1:
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                    return;
                case 2:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = true;
                    return;
                default:
                    return;
            }
        }
        private void checkedAttribute(bool print_dep_note,string text,bool re_permission, bool re_series,bool barTax, double cost, int square)
        {
            checkBox1.Checked = print_dep_note;
            textBox1.Text = text;
            checkBox2.Checked = re_permission;
            checkBox3.Checked = re_series;
            checkBox4.Checked = barTax;
            creTextBox1.Text = cost.ToString();
            creTextBox2.Text = square.ToString();
        }
        public void FirstState()
        {
            for (int i = 1; (i < 11); i++)
            {
                if(i!=6)
                    this.Controls["button" + i.ToString()].Enabled = true;
            }
            button7.Text = "Thoát";
            button1.Text = "Thêm các mặt hàng";
            ckb_Sua.Enabled = true;
            ckb_Sua.Checked = false;
            txtDeptID.Enabled = false;
            this.Refresh();
        }
        public void AddState(int i)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            ckb_Sua.Enabled = false;
            //cmbCate.SelectedIndex = 0;
            button1.Text = "Lưu lại";
            button7.Text = "Hủy";
            txtDeptID.Text = "";
            txtDeptID.Enabled = true;
            txtDeptID.Focus();
            if(i==1)
            {
                txtDeptDesc.Text = "";
                start_state();
            }

            this.Refresh();

        }

        private void start_state()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            textBox1.Text = "";
            creTextBox1.Text = "0";
            creTextBox2.Text = "0";
            Type(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text.Equals("Lưu lại"))
            {
                if(txtDeptID.Text.Equals(""))
                {
                    MessageBox.Show("Bạn phải nhập mã");
                    return;
                }
                //cmbCate.SelectedIndex = 0;
                DataRowView item = (DataRowView) cmbCate.SelectedItem;
                DataTable tmp = get_service.GetAllDepartmentsByDeptId(txtDeptID.Text, StaticClass.storeId);
                if(tmp.Rows.Count>0)
                {
                    MessageBox.Show("Mã đã có rùi");
                    return;
                }
                int function = 0;
                get_service.CreateDepartment(txtDeptID.Text, StaticClass.storeId, item.Row[0].ToString(),
                                             txtDeptDesc.Text, getType(), checkBox1.Checked, textBox1.Text,
                                             checkBox2.Checked, checkBox3.Checked, checkBox4.Checked,
                                             Convert.ToDouble(creTextBox1.Text), Convert.ToInt32(creTextBox2.Text),
                                             StaticClass.stationId, "", function, "", StaticClass.BackColor,
                                             StaticClass.ForeColor);
                departs = get_service.GetAllDepartments2(StaticClass.storeId);
                limit = departs.Rows.Count - 1;
            }
            if(sender.Equals(button4))
                AddState(0);
            else
                AddState(1);
            

        }
        private byte  getType()
        {
            if (radioButton1.Checked)
                return 0;
            if (radioButton2.Checked)
                return 1;
            if (radioButton3.Checked)
                return 2;
            return 0;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if(button7.Text == "Hủy")
            {
                FirstState();
                changeState(departs,currentIndex);
            }
            else
            {
                this.Dispose();
            }
        }

        private void txtDeptID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(currentIndex==limit)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            changeState(departs, currentIndex);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(currentIndex==0)
            {
                currentIndex = limit;
            }
            else
            {
                currentIndex--;
            }
            changeState(departs, currentIndex);
        }

        private void ckb_Sua_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Sua.Checked)
            {
                txtDeptID.Enabled = true;
                txtDeptID.Focus();
                txtDeptID.SelectionLength = txtDeptID.Text.Length;
                OldDept_ID = txtDeptID.Text;
                return;
            }
            txtDeptID.Enabled = false;
            txtDeptDesc.Focus();
            txtDeptDesc.SelectionLength = txtDeptDesc.Text.Length;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmQuanLyDanhMuc Form_Qldm=new FrmQuanLyDanhMuc();
            Form_Qldm.StartPosition = FormStartPosition.CenterScreen;
            Form_Qldm.ShowDialog();
            Categories = get_service.GetAllCategories(StaticClass.storeId);
            Service.Util.UpdateDataTableForCombo(cmbCate, Categories, 2);
            
        }

        private void cmbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(button1.Text.Equals("Lưu lại"))
            {
                txtDeptID.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DataRowView item = (DataRowView) txtDeptID.SelectedItem;

            //MessageBox.Show(item.Row[0].ToString());
            //string CatId = item.Row[0].ToString();
            if (txtDeptID.Text.Equals("NONE"))
            {
                MessageBox.Show("Bạn không được xóa mặt hàng này");
                return;
            }
            DataTable tmp = get_service.GetAllInventoryByDept(StaticClass.storeId,txtDeptID.Text);

            if (tmp.Rows.Count > 0)
            {
                if (MessageBox.Show("neu xoa thi nhung mat hang thuoc loai nay se dc set None", "chu y", MessageBoxButtons.YesNo).Equals(System.Windows.Forms.DialogResult.Yes))
                    get_service.DeleteDept(txtDeptID.Text, StaticClass.storeId);
                return;
            }

            get_service.DeleteDept(txtDeptID.Text, StaticClass.storeId);
            departs = get_service.GetAllDepartments2(StaticClass.storeId);
            limit = departs.Rows.Count - 1;
            button8_Click(button8, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OldDept_ID.Equals("NONE"))
            {
                MessageBox.Show("Bạn không được sửa mặt hàng này");
                return;
            }
            DataRowView item = (DataRowView)cmbCate.SelectedItem;
            get_service.UpdateDepartment(OldDept_ID,txtDeptID.Text, StaticClass.storeId, item.Row[0].ToString(),
                                             txtDeptDesc.Text, getType(), checkBox1.Checked, textBox1.Text,
                                             checkBox2.Checked, checkBox3.Checked, checkBox4.Checked,
                                             Convert.ToDouble(creTextBox1.Text), Convert.ToInt32(creTextBox2.Text),
                                             StaticClass.stationId, "", 0, "", StaticClass.BackColor,
                                             StaticClass.ForeColor);
            departs = get_service.GetAllDepartments2(StaticClass.storeId);
            ckb_Sua.Checked = false;

            MessageBox.Show("Bạn đã thay đổi thành công");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1_Click(button4,null);
        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            string[] column = {Const.Department.Dept_ID, Const.Department.Description};
            FrmSearch search = new FrmSearch(departs, column);
            search.passdata = new FrmSearch.PassData(changeState);
            search.ShowDialog();

        }
    }
}
