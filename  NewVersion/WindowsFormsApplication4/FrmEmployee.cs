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
using WindowsFormsApplication4.Const;

namespace WindowsFormsApplication4
{
    public partial class FrmEmployee : Form
    {
        private Services.get_GUI get_service;
        private DataTable Employees;
        private int currentIndex;
        private int limit;
        private string text_header = "Thông tin chung cho ";
        public FrmEmployee()
        {
            InitializeComponent();
            get_service = new get_GUI();
            Employees = get_service.GetAllEmployee(StaticClass.storeId);
            defaultPermission();
            //cmbDept.DisplayMember = Const.Department.Dept_ID;
            //cmbDept.DataSource = get_service.GetAllDepartmentsByType(StaticClass.storeId, Const.Department.EMPLOYEE);
            cmbDept.DataSource = viewOfDept();
            txtSwipt.isPass = true;
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            
            string DeptId = cmbDept.SelectedItem.ToString();
            //DataTable InventoryByDepart = get_service.GetAllInventoryByDept_Button(StaticClass.ScheduleIndex, DeptId, StaticClass.storeId);
            //changeState(InventoryByDepart, currentIndex);

            //inventory = get_service.GetAllInventory(StaticClass.storeId);
            limit = Employees.Rows.Count - 1;
            //get current index of Cmb in departs
            for (int j = 0; j < viewOfDept().Count; j++)
            {
                //DataRowView tmp = (DataRowView)cmbDept.SelectedItem;
                if (DeptId.Equals(Employees.Rows[j][Employee_Prop.Dept_ID]))
                {
                    currentIndex = j;
                    changeState(Employees,currentIndex);
                    return;
                }
            }
            currentIndex = 0;
            changeState(Employees, currentIndex);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #region View
        private ArrayList viewOfDept()
        {
            DataTable tmp = get_service.GetAllDepartmentsByType(StaticClass.storeId, Const.Department.EMPLOYEE);
            ArrayList tmp0=new ArrayList();
            tmp0.Add("");
            for(int i=0;i<tmp.Rows.Count;i++)
            {
                tmp0.Add(tmp.Rows[i][Employee_Prop.Dept_ID]);
            }
            return tmp0;
        }
        private ArrayList viewOfPermission()
        {
            return new ArrayList(new string[]{"Hỏi mật khẩu","Cho phép","Không cho phép"});
        }
        private void defaultPermission()
        {
            cmbChuyenB.DataSource = viewOfPermission();
            cmbDoiGia.DataSource = viewOfPermission();
            cmbDoiSL.DataSource = viewOfPermission();
            cmbGhiChu.DataSource = viewOfPermission();
            cmbHuyHD.DataSource = viewOfPermission();
            cmbKhauTru.DataSource = viewOfPermission();
            cmbKho.DataSource = viewOfPermission();
            cmbMayIn.DataSource = viewOfPermission();
            cmbMH.DataSource = viewOfPermission();
            cmbNV.DataSource = viewOfPermission();
            cmbThue.DataSource = viewOfPermission();
            cmbTraLai.DataSource = viewOfPermission();
            cmbXemBC.DataSource = viewOfPermission();
            cmbXemBK.DataSource = viewOfPermission();
            cmbXoaMA.DataSource = viewOfPermission();
            cmbTSConfig.DataSource = viewOfPermission();
            cmbMoKetSat.DataSource = viewOfPermission();
            cmbCustEdit.DataSource = viewOfPermission();
        }
        #endregion

        private void ckb_Sua_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Sua.Checked)
            {
                button6.Enabled = true;
                txtEmpID.Enabled = true;
                txtEmpID.Focus();
                txtEmpID.SelectionLength = txtEmpID.Text.Length;
                return;
            }
            txtEmpID.Enabled = false;
            //txtInventDesc.Focus();
            //txtInventDesc.SelectionLength = txtInventDesc.Text.Length;
            button6.Enabled = false;
        }
        private string ComboBox2String(ComboBox cmb,string t)
        {
            string rowView = cmb.SelectedItem.ToString();
            switch (rowView)
            {
                case "Hỏi mật khẩu":
                    return Employee_Prop.PROMPT;
                case "Cho phép":
                    return Employee_Prop.YES;
                case "Không cho phép":
                    return Employee_Prop.NO;
            }
            //return rowView[t].ToString();
            return null;
        }
        private int string2intCombobox(string s)
        {
            switch (s)
            {
                case Employee_Prop.PROMPT:
                    return 0;
                case Employee_Prop.YES:
                    return 1;
                case Employee_Prop.NO:
                    return 2;
            }
            return 3;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text.Equals("Lưu lại"))
            {
                if (txtEmpID.Text.Equals(""))
                {
                    Alert.Show("Bạn phải nhập mã đã!", Color.Red);
                    return;
                }
                //cmbCate.SelectedIndex = 0;
                //DataRowView item = (DataRowView)cmbDept.SelectedItem;
                DataTable tmp = get_service.GetEmployeeByID(StaticClass.storeId, txtEmpID.Text);
                if (tmp.Rows.Count > 0)
                {
                    Alert.Show("Mã này đã tồn tại", Color.Red);
                    return;
                }

                int function = 0;
                //MessageBox.Show(tmp.Rows[0]["ItemName"].ToString());
                //DataRowView itemRow = (DataRowView)cmbDept.SelectedItem;
                string deptId = cmbDept.SelectedItem.ToString();
                get_service.CreateEmployee(txtEmpID.Text,txtCus.Text,deptId,txtPass.Text,txtSwipt.Text,txtHour.Text,StaticClass.Form_Color,Employee_Prop.PROMPT,ComboBox2String(cmbThue,Employee_Prop.CFA_Setup_Tax)
                                               ,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,ComboBox2String(cmbMayIn,Employee_Prop.CFA_Setup_DefPrinter)
                                               ,Employee_Prop.PROMPT,ComboBox2String(cmbMH,Employee_Prop.CFA_Inven_Edit),Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,ComboBox2String(cmbKho,Employee_Prop.CFA_Depts_Edit)
                                               , Employee_Prop.PROMPT, Employee_Prop.PROMPT, ComboBox2String(cmbCustEdit, Employee_Prop.CFA_Cust_Edit), ComboBox2String(cmbXemBC, Employee_Prop.CFA_Reports_Display), Employee_Prop.PROMPT
                                               ,Employee_Prop.PROMPT,ComboBox2String(cmbKhauTru,Employee_Prop.CFA_Invoice_Discount),ComboBox2String(cmbDoiGia,Employee_Prop.CFA_Invoice_PriceChange),ComboBox2String(cmbXoaMA,Employee_Prop.CFA_Invoice_DeleteItems)
                                               ,ComboBox2String(cmbHuyHD,Employee_Prop.CFA_Invoice_Void),Employee_Prop.PROMPT,Employee_Prop.PROMPT,true,Employee_Prop.PROMPT,ComboBox2String(cmbTraLai,Employee_Prop.CFA_Refund_Item),true,true,txtEmpName.Text,Employee_Prop.PROMPT
                                               ,Employee_Prop.PROMPT,Employee_Prop.PROMPT,"01",ComboBox2String(cmbXemBK,Employee_Prop.CFA_Other_Tables),Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,cbDisable.Checked,cbAdmin.Checked,Employee_Prop.PROMPT
                                               ,ComboBox2String(cmbMoKetSat,Employee_Prop.CFA_Open_Cash_Drawer),cbTake.Checked,cbRequire.Checked,Employee_Prop.PROMPT,ComboBox2String(cmbChuyenB,Employee_Prop.CFA_Transfer_Tables),Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT
                                               ,Employee_Prop.PROMPT,Employee_Prop.PROMPT,txtHo.Text,"",txtTen.Text,txtSSN.Text,txtAdress.Text,"",txtCity.Text,"","",txtSDT.Text,txtEmail.Text,DateTime.Now,"",Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,""
                                               ,"",Employee_Prop.PROMPT,Employee_Prop.PROMPT,"",Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,"",StaticClass.storeId,""
                                               ,Employee_Prop.PROMPT,Employee_Prop.PROMPT,0,0,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT
                                               ,Employee_Prop.PROMPT,ComboBox2String(cmbDoiSL,Employee_Prop.CFA_ENDTRANS_CASH),Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,ComboBox2String(cmbTSConfig,Employee_Prop.CFA_TS_CONFIG),Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,ComboBox2String(cmbGhiChu,Employee_Prop.CFA_SETUP_RECEIPT_NOTES),Employee_Prop.PROMPT
                                               ,Employee_Prop.PROMPT,ComboBox2String(cmbNV,Employee_Prop.CFA_SETUP_EDIT_EMPLOYEES),Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT,Employee_Prop.PROMPT);

                Employees = get_service.GetAllEmployee(StaticClass.storeId);
                limit = Employees.Rows.Count - 1;
            }
            if (sender.Equals(button4))
                AddState(0);
            else
                AddState(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button11_Click(button4, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string deptId = cmbDept.SelectedItem.ToString();
            get_service.UpdateEmployee(txtEmpID.Text, txtCus.Text, deptId, txtPass.Text, txtSwipt.Text, txtHour.Text, StaticClass.Form_Color, Employee_Prop.PROMPT, ComboBox2String(cmbThue, Employee_Prop.CFA_Setup_Tax)
                                               , Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, ComboBox2String(cmbMayIn, Employee_Prop.CFA_Setup_DefPrinter)
                                               , Employee_Prop.PROMPT, ComboBox2String(cmbMH, Employee_Prop.CFA_Inven_Edit), Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, ComboBox2String(cmbKho, Employee_Prop.CFA_Depts_Edit)
                                               , Employee_Prop.PROMPT, Employee_Prop.PROMPT, ComboBox2String(cmbCustEdit, Employee_Prop.CFA_Cust_Edit), ComboBox2String(cmbXemBC, Employee_Prop.CFA_Reports_Display), Employee_Prop.PROMPT
                                               , Employee_Prop.PROMPT, ComboBox2String(cmbKhauTru, Employee_Prop.CFA_Invoice_Discount), ComboBox2String(cmbDoiGia, Employee_Prop.CFA_Invoice_PriceChange), ComboBox2String(cmbXoaMA, Employee_Prop.CFA_Invoice_DeleteItems)
                                               , ComboBox2String(cmbHuyHD, Employee_Prop.CFA_Invoice_Void), Employee_Prop.PROMPT, Employee_Prop.PROMPT, true, Employee_Prop.PROMPT, ComboBox2String(cmbTraLai, Employee_Prop.CFA_Refund_Item), true, true, txtEmpName.Text, Employee_Prop.PROMPT
                                               , Employee_Prop.PROMPT, Employee_Prop.PROMPT, "01", ComboBox2String(cmbXemBK, Employee_Prop.CFA_Other_Tables), Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, cbDisable.Checked, cbAdmin.Checked, Employee_Prop.PROMPT
                                               , ComboBox2String(cmbMoKetSat,Employee_Prop.CFA_Open_Cash_Drawer), cbTake.Checked, cbRequire.Checked, Employee_Prop.PROMPT, ComboBox2String(cmbChuyenB, Employee_Prop.CFA_Transfer_Tables), Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT
                                               , Employee_Prop.PROMPT, Employee_Prop.PROMPT, txtHo.Text, "", txtTen.Text, txtSSN.Text, txtAdress.Text, "", txtCity.Text, "", "", txtSDT.Text, txtEmail.Text, DateTime.Now, "", Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, ""
                                               , "", Employee_Prop.PROMPT, Employee_Prop.PROMPT, "", Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, "", StaticClass.storeId, ""
                                               , Employee_Prop.PROMPT, Employee_Prop.PROMPT, 0, 0, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT
                                               , Employee_Prop.PROMPT, ComboBox2String(cmbDoiSL, Employee_Prop.CFA_ENDTRANS_CASH), Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, ComboBox2String(cmbTSConfig, Employee_Prop.CFA_TS_CONFIG), Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, ComboBox2String(cmbGhiChu, Employee_Prop.CFA_SETUP_RECEIPT_NOTES), Employee_Prop.PROMPT
                                               , Employee_Prop.PROMPT, ComboBox2String(cmbNV, Employee_Prop.CFA_SETUP_EDIT_EMPLOYEES), Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT, Employee_Prop.PROMPT);
            Employees = get_service.GetAllEmployee(StaticClass.storeId);
            ckb_Sua.Checked = false;

            //serviceGet.UpdateInventPrinter(InventPrinters, txtInvenId.Text);
            //Alert.Show("Bạn đã thay đổi thành công", Color.Blue);
        }
        #region ChangeState
        private void changeState(DataTable table, int rowIndex)
        {
            SetCurrentIndexComboBox(table, rowIndex);
            txtEmpID.Text = table.Rows[rowIndex][Const.Employee_Prop.Cashier_ID].ToString();
            txtEmpName.Text = table.Rows[rowIndex][Const.Employee_Prop.EmpName].ToString();
            txtSwipt.Text = table.Rows[rowIndex][Const.Employee_Prop.Swipe_ID].ToString();

            cbDisable.Checked = Convert.ToBoolean(table.Rows[rowIndex][Employee_Prop.Disabled]);
            cbAdmin.Checked= Convert.ToBoolean(table.Rows[rowIndex][Employee_Prop.Admin_Access]);
            cbRequire.Checked= Convert.ToBoolean(table.Rows[rowIndex][Employee_Prop.ReqClockIn]);
            cbTake.Checked= Convert.ToBoolean(table.Rows[rowIndex][Employee_Prop.CCTipsNow]);

            label23.Text = text_header + "'" + table.Rows[rowIndex][Const.Employee_Prop.Cashier_ID] + "'";
            cmbChuyenB.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Transfer_Tables].ToString()));
            cmbDoiGia.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Invoice_PriceChange].ToString()));
            cmbDoiSL.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_ENDTRANS_CASH].ToString()));
            cmbGhiChu.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_SETUP_RECEIPT_NOTES].ToString()));
            cmbHuyHD.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Invoice_Void].ToString()));
            cmbKhauTru.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Invoice_Discount].ToString()));
            cmbKho.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Depts_Edit].ToString()));
            cmbMayIn.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Setup_DefPrinter].ToString()));
            cmbMH.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Inven_Edit].ToString()));
            cmbNV.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_SETUP_EDIT_EMPLOYEES].ToString()));
            cmbThue.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Setup_Tax].ToString()));
            cmbTraLai.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Refund_Item].ToString()));
            cmbXemBC.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Reports_Display].ToString()));
            cmbXemBK.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Other_Tables].ToString()));
            cmbXoaMA.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Invoice_DeleteItems].ToString()));
            cmbTSConfig.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_TS_CONFIG].ToString()));
            cmbMoKetSat.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Open_Cash_Drawer].ToString()));
            cmbCustEdit.SelectedIndex = Convert.ToInt32(string2intCombobox(table.Rows[rowIndex][Employee_Prop.CFA_Cust_Edit].ToString()));

            txtHo.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.First_Name]);
            txtTen.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.Last_Name]);
            txtSSN.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.SSN]);
            txtSDT.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.Phone_1]);
            txtPass.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.Password]);
            txtHour.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.Hourly_Wage]);
            txtEmail.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.EMail]);
            txtCus.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.CustNum]);
            txtCity.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.City]);
            txtBirth.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.Birthday]);
            txtAdress.Text = Convert.ToString(table.Rows[rowIndex][Employee_Prop.Address_1]);
            //bool Modifier_Item = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.IsModifier]);
            //bool Exclude = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Exclude_Acct_Limit]);
            //bool CheckId = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Check_ID]);
            //bool CheckId2 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Check_ID2]);
            //bool CountThisItem = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Count_This_Item]);
            //bool PrintOnRe = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Print_On_Receipt]);
            //bool AllowBuy = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Allow_BuyBack]);
            //bool PromptPrice = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Prompt_Price]);
            //bool PromptQua = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Prompt_Quantity]);
            ////
            //bool DisableItem = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Inactive]);
            ////
            //bool SpecialPer = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Special_Permission]);
            //bool UseSerial = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Use_Serial_Numbers]);
            //bool Auto = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.AutoWeigh]);
            //bool Food = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.FoodStampable]);
            //byte Type = Convert.ToByte(table.Rows[rowIndex][Const.Inventory.ItemType]);
            //string cost = table.Rows[rowIndex][Const.Inventory.Cost].ToString();
            //string price = table.Rows[rowIndex][Const.Inventory.Price].ToString();
            //string stock = table.Rows[rowIndex][Const.Inventory.In_Stock].ToString();
            //bool tax1 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Tax_1]);
            //bool tax2 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Tax_2]);
            //bool tax3 = Convert.ToBoolean(table.Rows[rowIndex][Const.Inventory.Tax_3]);
            //checkedAttribute(Modifier_Item, Exclude, CheckId, CheckId2, CountThisItem, PrintOnRe, AllowBuy, PromptPrice,
            //                 PromptQua, DisableItem, SpecialPer, UseSerial, Auto, Food, Type, cost, price, tax1, tax2, tax3);
            //InventPrinters = serviceGet.getAllInventPrinter(StaticClass.storeId,
            //                                                table.Rows[rowIndex][Const.Inventory.ItemNum].ToString());
            //creListBox1.Items.Clear();
            //for (int i = 0; i < InventPrinters.Count; i++)
            //{
            //    Printer printer = (Printer)InventPrinters[i];
            //    creListBox1.Items.Add(printer);
            //    //creListBox1.DisplayMember = "PrinterName";
            //}
        }

        private void SetCurrentIndexComboBox(DataTable table, int rowIndex)
        {
            string tmp = cmbDept.SelectedItem.ToString();
            if (!tmp.Equals(table.Rows[rowIndex][Const.Employee_Prop.Dept_ID]))
            {
                for (int i = 0; i < viewOfDept().Count; i++)
                {
                    if (viewOfDept()[i].Equals(table.Rows[rowIndex][Const.Department.Dept_ID]))
                    {
                        cmbDept.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        #endregion

        #region State
        public void AddState(int i)
        {
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
            txtEmpID.Text = "";
            txtEmpID.Enabled = true;
            txtEmpID.Focus();
            if (i == 1)
            {
                txtEmpName.Text = "";
                start_state();
            }
            this.Refresh();
        }
        private void start_state()
        {
            cmbChuyenB.SelectedIndex = 0;
            cmbDoiGia.SelectedIndex = 0;
            cmbDoiSL.SelectedIndex = 0;
            cmbGhiChu.SelectedIndex = 0;
            cmbHuyHD.SelectedIndex = 0;
            cmbKhauTru.SelectedIndex = 0;
            cmbKho.SelectedIndex = 0;
            cmbMayIn.SelectedIndex = 0;
            cmbMH.SelectedIndex = 0;
            cmbNV.SelectedIndex = 0;
            cmbThue.SelectedIndex = 0;
            cmbTraLai.SelectedIndex = 0;
            cmbXemBC.SelectedIndex = 0;
            cmbXemBK.SelectedIndex = 0;
            cmbXoaMA.SelectedIndex = 0;
            cmbTSConfig.SelectedIndex = 0;
            cmbMoKetSat.SelectedIndex = 0;

            cmbDept.SelectedIndex = 0;
            txtTen.Text = "";
            txtHo.Text = "";
            txtSwipt.Text = "";
            txtSSN.Text = "";
            txtSDT.Text = "";
            txtPass.Text = "";
            txtHour.Text = "0.0";
            txtEmpName.Text = "";
            txtEmpID.Text = "";
            txtEmail.Text = "";
            txtCus.Text = "";
            txtCity.Text = "";
            txtBirth.Text = "";
            txtAdress.Text = "";
            txtEmpID.Focus();
        }
        public void FirstState()
        {
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = false;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;

            button7.Text = "Thoát";
            button11.Text = "Thêm mới nhân viên";
            ckb_Sua.Enabled = true;
            ckb_Sua.Checked = false;
            txtEmpID.Enabled = false;
            this.Refresh();
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable ExistEmployee = get_service.GetEmployeeInInvoiceTotal(txtEmpID.Text);
            if (ExistEmployee.Rows.Count > 0)
            {
                DialogResult t =
                    MessBox2Choice.ShowBox("Nhân viên mà bạn xóa \nHiện không xóa được.\n Bạn có muốn xóa không", Color.YellowGreen);
                if (t.Equals(System.Windows.Forms.DialogResult.No))
                    return;

            }
            get_service.DeleteEmployee(txtEmpID.Text, StaticClass.storeId);
            Employees = get_service.GetAllEmployee(StaticClass.storeId);
            limit = Employees.Rows.Count - 1;
            button8_Click(button8, null);
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
            changeState(Employees, currentIndex);
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
            changeState(Employees, currentIndex);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Hủy")
            {
                FirstState();
                changeState(Employees, currentIndex);
            }
            else
            {
                this.Dispose();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string[] column = { Employee_Prop.Cashier_ID, Employee_Prop.EmpName,Employee_Prop.Dept_ID,Employee_Prop.Address_1,Employee_Prop.Phone_1};
            FrmSearch search = new FrmSearch(Employees, column);
            search.tableType = "Employee";
            search.passdata = new FrmSearch.PassData(changeState);
            search.ShowDialog();
        }
    }
}
