using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmInventory : Form
    {
        private Services.get_GUI get_service;
        private Service.ServiceGet serviceGet;
        private string text_header = "Thông tin chung cho ";
        private int currentIndex;
        private int limit;
        private DataTable departs;
        private DataTable inventory;
        private string OldInvent_ID;
        private ArrayList InventPrinters;
        public FrmInventory()
        {
            InitializeComponent();
            get_service=new get_GUI();
            serviceGet = new ServiceGet();
            InventPrinters = new ArrayList();
            departs = get_service.GetAllDepartments2(StaticClass.storeId);
            Service.Util.UpdateDataTableForCombo(cmbDept, departs, 2);
            for (int j = 0; j < departs.Rows.Count; j++)
            {
                if (departs.Rows[j][2].Equals("Không phân loại"))
                {
                    cmbDept.SelectedIndex = j;
                    return;
                }
            }
        }


        
        private void FrmInventory_Load(object sender, EventArgs e)
        {
            DataRowView rowView = (DataRowView) cmbDept.SelectedItem;
            string DeptId = rowView.Row[Const.Department.Dept_ID].ToString();
            DataTable InventoryByDepart = get_service.GetAllInventoryByDept_Button(StaticClass.ScheduleIndex, DeptId ,StaticClass.storeId);
            changeState(InventoryByDepart, currentIndex);
           
            inventory = get_service.GetAllInventory(StaticClass.storeId);
            limit = inventory.Rows.Count - 1;
            //get current index of Cmb in departs
            for (int j = 0; j < InventoryByDepart.Rows.Count; j++)
            {
                DataRowView tmp = (DataRowView)cmbDept.SelectedItem;
                if (tmp.Row[0].Equals(departs.Rows[j][7]))
                {
                    currentIndex = j;
                    break;
                }
            }
            
        }
        private void changeState(DataTable table, int rowIndex)
        {
            SetCurrentIndexComboBox(table, rowIndex);
            txtInvenId.Text = table.Rows[rowIndex][Const.Inventory.ItemNum].ToString();
            txtInventDesc.Text = table.Rows[rowIndex][Const.Inventory.ItemName].ToString();

            label1.Text = text_header + "'" + table.Rows[rowIndex][Const.Inventory.ItemName] + "'";

            bool Modifier_Item=Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.IsModifier]);
            bool Exclude = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Exclude_Acct_Limit]);
            bool CheckId = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Check_ID]);
            bool CheckId2 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Check_ID2]);
            bool CountThisItem = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Count_This_Item]);
            bool PrintOnRe = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Print_On_Receipt]);
            bool AllowBuy = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Allow_BuyBack]);
            bool PromptPrice = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Prompt_Price]);
            bool PromptQua = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Prompt_Quantity]);
            //
            bool DisableItem = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Inactive]);
            //
            bool SpecialPer = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Special_Permission]);
            bool UseSerial = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Use_Serial_Numbers]);
            bool Auto = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.AutoWeigh]);
            bool Food = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.FoodStampable]);
            byte Type = Convert.ToByte(table.Rows[rowIndex][Const.Inventory.ItemType]);
            string cost = table.Rows[rowIndex][Const.Inventory.Cost].ToString();
            string price=table.Rows[rowIndex][Const.Inventory.Price].ToString();
            string stock = table.Rows[rowIndex][Const.Inventory.In_Stock].ToString();
            bool tax1 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Tax_1]);
            bool tax2 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Tax_2]);
            bool tax3 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Tax_3]);

            float Instock = Convert.ToSingle(table.Rows[rowIndex][Const.Inventory.In_Stock]);
            txtKho.Text = Instock.ToString();
            checkedAttribute(Modifier_Item, Exclude, CheckId, CheckId2, CountThisItem, PrintOnRe, AllowBuy, PromptPrice,
                             PromptQua, DisableItem, SpecialPer, UseSerial, Auto, Food,Type,cost,price,tax1,tax2,tax3);
            InventPrinters = serviceGet.getAllInventPrinter(StaticClass.storeId,
                                                            table.Rows[rowIndex][Const.Inventory.ItemNum].ToString());
            creListBox1.Items.Clear();
            for (int i = 0; i < InventPrinters.Count; i++)
            {
                Printer printer = (Printer) InventPrinters[i];
                creListBox1.Items.Add(printer);
                //creListBox1.DisplayMember = "PrinterName";
            }
        }


        private void SetCurrentIndexComboBox(DataTable table, int rowIndex)
        {
            DataRowView tmp = (DataRowView)cmbDept.SelectedItem;
            if (!tmp.Row[Const.Department.Dept_ID].Equals(table.Rows[rowIndex][Const.Inventory.Dept_ID])) 
            {
                for (int i = 0; i < departs.Rows.Count; i++)
                {
                    if (departs.Rows[i][Const.Department.Dept_ID].Equals(table.Rows[rowIndex][Const.Inventory.Dept_ID]))
                    {
                        cmbDept.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        private void checkedAttribute(bool Modifier_Item, bool Exclude, bool CheckId, bool CheckId2, bool CountThisItem, bool PrintOnRe, bool AllowBuy,bool PromptPrice,bool PromptQua, bool DisableItem, bool SpecialPer, bool UseSerial, bool Auto, bool Food,byte type,string cost,string price,bool tax1,bool tax2,bool tax3)
        {
            creCheckBox1.Checked = Modifier_Item;
            creCheckBox2.Checked = Exclude;
            creCheckBox3.Checked = CheckId;
            creCheckBox4.Checked = CheckId2;
            creCheckBox5.Checked = CountThisItem;
            creCheckBox6.Checked = PrintOnRe;
            creCheckBox7.Checked = AllowBuy;
            creCheckBox8.Checked = PromptPrice;
            creCheckBox9.Checked = PromptQua;
            creCheckBox10.Checked = DisableItem;
            creCheckBox12.Checked = SpecialPer;
            creCheckBox13.Checked = UseSerial;
            creCheckBox14.Checked = Auto;
            creCheckBox15.Checked = Food;
            creCmbLoaiMH.SelectedIndex = 0;
            txtGia.Text = cost;
            txtGiaMua.Text = price;
            ckbTax1.Checked = tax1;
            ckbTax2.Checked = tax2;
            ckbTax3.Checked = tax3;
        }
        private void txtDeptDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void creCheckBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TabPage_Change(object sender, EventArgs e)
        {
            //if(!tabControl1.SelectedTab.Text.Equals("Optional Info"))
            //{
            //    MessageBox.Show("Đang xây dựng");
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Hủy")
            {
                FirstState();
                changeState(inventory, currentIndex);
            }
            else
            {
                this.Dispose();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (currentIndex == limit)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            changeState(inventory, currentIndex);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentIndex == 0)
            {
                currentIndex = limit;
            }
            else
            {
                currentIndex--;
            }
            changeState(inventory, currentIndex);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text.Equals("Lưu lại"))
            {
                if (txtInvenId.Text.Equals(""))
                {
                    Alert.Show("Bạn phải nhập mã đã!",Color.Red);
                    return;
                }
                //cmbCate.SelectedIndex = 0;
                DataRowView item = (DataRowView)cmbDept.SelectedItem;
                DataTable tmp = get_service.GetInventoryByItemNum(StaticClass.storeId, txtInvenId.Text);
                if (tmp.Rows.Count > 0)
                {
                    Alert.Show("Mã này đã tồn tại",Color.Red);
                    return;
                }
                
                int function = 0;
                //MessageBox.Show(tmp.Rows[0]["ItemName"].ToString());
                get_service.CreateInventory(txtInvenId.Text, txtInventDesc.Text,StaticClass.storeId, (txtGia.Text),
                                             (txtGiaMua.Text), Convert.ToSingle(txtKho.Text), ckbTax1.Checked, ckbTax2.Checked,
                                             ckbTax3.Checked, item.Row[Const.Department.Dept_ID].ToString(), creCheckBox1.Checked,
                                             creCheckBox2.Checked,creCheckBox13.Checked, false,
                                             creCheckBox14.Checked, creCheckBox15.Checked, 0, creCheckBox8.Checked, creCheckBox9.Checked, creCheckBox3.Checked, Convert.ToInt16(creCheckBox10.Checked), creCheckBox7.Checked,
                                             "", creCheckBox12.Checked, creCheckBox4.Checked, creCheckBox5.Checked, creCheckBox6.Checked,StaticClass.stationIdForInvent,0,item.Row[Const.Department.Dept_ID].ToString(), StaticClass.BackColor,
                                             StaticClass.ForeColor);
                inventory = get_service.GetAllInventory(StaticClass.storeId);
                limit = inventory.Rows.Count - 1;
            }
            if (sender.Equals(button4))
                AddState(0);
            else
                AddState(1);
            
        }
        public void AddState(int i)
        {   
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            //cmbCate.SelectedIndex = 0;
            ckb_Sua.Enabled = false;
            button11.Text = "Lưu lại";
            button7.Text = "Hủy";
            txtInvenId.Text = "";
            txtInvenId.Enabled = true;
            txtInvenId.Focus();
            if (i == 1)
            {
                txtInventDesc.Text = "";
                start_state();
            }
            this.Refresh();
        }
        private void start_state()
        {
            creCheckBox1.Checked = false;
            creCheckBox2.Checked = false;
            creCheckBox3.Checked = false;
            creCheckBox4.Checked = false;
            creCheckBox5.Checked = false;
            creCheckBox6.Checked = false;
            creCheckBox7.Checked = false;
            creCheckBox8.Checked = false;
            creCheckBox9.Checked = false;
            creCheckBox10.Checked = false;
            creCheckBox12.Checked = false;
            creCheckBox13.Checked = false;
            creCheckBox14.Checked = false;
            creCheckBox15.Checked = false;
            ckbTax1.Checked = false;
            ckbTax2.Checked = false;
            ckbTax3.Checked = false;

            txtGia.Text = "0";
            txtGiaMua.Text = "0";
            txtInventDesc.Text = "";
            txtKho.Text = "0";
        }
        public void FirstState()
        {
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = false;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;

            button7.Text = "Thoát";
            button11.Text = "Thêm mới loại hàng";
            ckb_Sua.Enabled = true;
            ckb_Sua.Checked = false;
            txtInvenId.Enabled = false;
            this.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button11_Click(button4,null);
        }

        private void ckb_Sua_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Sua.Checked)
            {
                button6.Enabled = true;
                txtInvenId.Enabled = true;
                txtInvenId.Focus();
                txtInvenId.SelectionLength = txtInvenId.Text.Length;
                OldInvent_ID = txtInvenId.Text;
                return;
            }
            txtInvenId.Enabled = false;
            //txtInventDesc.Focus();
            //txtInventDesc.SelectionLength = txtInventDesc.Text.Length;
            button6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable InventoryItemize = get_service.GetInvoiceItemizedByItemNum(StaticClass.storeId, txtInvenId.Text);
            if (InventoryItemize.Rows.Count > 0)
            {
                Alert.Show("Mặt hàng vẫn còn \ntrong hóa đơn.",Color.Red);
                return;
                
            }
            get_service.DeleteAllInventPrinter(StaticClass.storeId,txtInvenId.Text);
            get_service.DeleteInventory(txtInvenId.Text, StaticClass.storeId);
            inventory = get_service.GetAllInventory(StaticClass.storeId);
            limit = inventory.Rows.Count - 1;
            button8_Click(button8, null);
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button11.Text.Equals("Lưu lại"))
            {
                txtInvenId.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (OldInvent_ID.Equals("Non_Inventory"))
            {
                Alert.Show("Bạn không được sửa mặt hàng này",Color.Red);
                return;
            }
            DataRowView item = (DataRowView)cmbDept.SelectedItem;
            get_service.UpdateInventory(OldInvent_ID, txtInvenId.Text, txtInventDesc.Text, StaticClass.storeId, (txtGia.Text),
                                             (txtGiaMua.Text), Convert.ToSingle(txtKho.Text), ckbTax1.Checked, ckbTax2.Checked,
                                             ckbTax3.Checked, item.Row[Const.Department.Dept_ID].ToString(), creCheckBox1.Checked,
                                             creCheckBox2.Checked, creCheckBox13.Checked, false,
                                             creCheckBox14.Checked, creCheckBox15.Checked, 0, creCheckBox8.Checked, creCheckBox9.Checked, creCheckBox3.Checked, Convert.ToInt16(creCheckBox10.Checked), creCheckBox7.Checked,
                                             "", creCheckBox12.Checked, creCheckBox4.Checked, creCheckBox5.Checked, creCheckBox6.Checked, StaticClass.stationIdForInvent, 0, item.Row[Const.Department.Dept_ID].ToString(), StaticClass.BackColor,
                                             StaticClass.ForeColor);
            inventory = get_service.GetAllInventory(StaticClass.storeId);
            ckb_Sua.Checked = false;

            serviceGet.UpdateInventPrinter(InventPrinters,txtInvenId.Text);
            Alert.Show("Bạn đã thay đổi thành công",Color.Blue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alert.Show("Chức năng đang được xây dựng", Color.Blue);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string[] column = { Const.Inventory.ItemNum, Const.Inventory.ItemName,Const.Inventory.Dept_ID,Const.Inventory.Cost,Const.Inventory
                              .Price,Const.Inventory.In_Stock};
            FrmSearch search = new FrmSearch(inventory, column);
            search.passdata = new FrmSearch.PassData(changeState);
            search.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(creListBox1.SelectedItem != null)
            {
                Printer printer = (Printer) creListBox1.SelectedItem;
                printer.isDelete = true;
                creListBox1.ClearSelected();
                creListBox1.Items.Remove(printer);
            }
            else
            {
                Alert.Show("Chưa chọn máy in",Color.Red);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPrinterChoice frmPrinterChoice =new FrmPrinterChoice();
            if(frmPrinterChoice.ShowDialog() == DialogResult.OK)
            {
                if(CheckPrinterExist(frmPrinterChoice.PrinterName))
                {
                    Printer printer = new Printer(frmPrinterChoice.PrinterName);
                    printer.isNew = true;
                    InventPrinters.Add(printer);
                    creListBox1.Items.Add(printer);
                }
                else
                {
                    Alert.Show("Máy in đã có rồi",Color.Red);
                }
            }
        }
        private bool CheckPrinterExist(string pName)
        {
            foreach (Printer c in creListBox1.Items)
            {
                if(c.PrinterName == pName)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
