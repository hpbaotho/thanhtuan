using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Const;

namespace WindowsFormsApplication4
{
    public partial class FrmCustomer : Form
    {
        private Services.get_GUI get_service;
        private Customer.CustomerDataTable Customers;
        private int currentIndex;
        private int limit;
        private string m_oldCusNum = "";
        public FrmCustomer()
        {

            InitializeComponent();
            get_service = new get_GUI();
            Customers = get_service.GetAllCustomers();
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            limit = Customers.Rows.Count - 1;
            currentIndex = 0;
            changeState(Customers, currentIndex);
        }
        #region ChangeState
        private void changeState(Customer.CustomerDataTable customerDataTable, int rowindex)
        {
            if(customerDataTable.Rows.Count>0)
            {
                var row = customerDataTable.Rows[rowindex] as Customer.CustomerRow;
                if (row != null)
                {
                    txtAddress.Text = row.IsAddress_1Null() ? "" : row.Address_1;

                    txtDateBirth.Text = row.IsBirthdayNull() ? "" : row.Birthday.ToShortDateString();
                    txtDateCloseAccount.Text = row.IsAcct_Close_DateNull() ? "" : row.Acct_Close_Date.ToShortDateString();

                    txtDateCustomer.Text = row.IsCreateDateNull() ? "" : row.CreateDate.ToShortDateString();

                    txtDateOpenAccount.Text = row.IsAcct_Open_DateNull() ? "" : row.Acct_Open_Date.ToShortDateString();

                    txtDiscountPercent.Text = row.Discount_Percent.ToString();
                    txtEmail.Text = row.IsEMailNull() ? "" : row.EMail;
                    txtMaKH.Text = row.CustNum;
                    txtMaxBalance.Text = row.IsAcct_Max_BalanceNull() ? "" : row.Acct_Max_Balance.ToString();
                    txtMobilephone.Text = row.IsPhone_1Null() ? "" : row.Phone_1;
                    txtName.Text = row.Last_Name;
                    txtNameCompany.Text = row.IsCompanyNull() ? "" : row.Company;
                    txtTelephone.Text = row.IsPhone_2Null() ? "" : row.Phone_2;
                    lblNumberOfAdd.Text = row.IsAcct_BalanceNull() ? "" : row.Acct_Balance.ToString();
                }
            }
           
        }
        #endregion

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (btnAddCustomer.Text.Equals("Lưu lại"))
            {
                if (txtMaKH.Text.Equals(""))
                {
                    Alert.Show("Bạn phải nhập mã đã!", Color.Red);
                    return;
                }
                //cmbCate.SelectedIndex = 0;
                //DataRowView item = (DataRowView)cmbDept.SelectedItem;
                Customer.CustomerDataTable tmp = get_service.GetCustomerByID(txtMaKH.Text);
                if (tmp.Rows.Count > 0)
                {
                    Alert.Show("Mã này đã tồn tại", Color.Red);
                    return;
                }

                DateTime dateTimeOpenAccount = DateTime.Now;
                DateTime dateTimeCloseAccount = DateTime.Now;
                DateTime dateTimeBirth = DateTime.Now;
                Decimal maxBalance=new decimal();
                if (!DateTime.TryParse(txtDateOpenAccount.Text,out dateTimeOpenAccount))
                {
                    Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                    txtDateOpenAccount.Focus();
                    return;
                }
                if(!DateTime.TryParse(txtDateCloseAccount.Text,out dateTimeCloseAccount))
                {

                    Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                    txtDateCloseAccount.Focus();
                    return;
                }
                if(!DateTime.TryParse(txtDateBirth.Text,out dateTimeBirth))
                {
                    
                    Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                    txtDateBirth.Focus();
                    return;
                }
                if (!Decimal.TryParse(txtMaxBalance.Text,out maxBalance))
                {
                    Alert.Show("Bạn nhập sai", Color.Red);
                    txtMaxBalance.Focus();
                    return;
                }
                get_service.CreateCustomer(txtMaKH.Text, "", txtName.Text, txtNameCompany.Text, txtAddress.Text, "", "",
                                           "", "", txtTelephone.Text, txtMobilephone.Text,
                                           "", "", "", "", float.Parse(txtDiscountPercent.Text),
                                           DateTime.Parse(txtDateOpenAccount.Text),
                                           DateTime.Parse(txtDateCloseAccount.Text), (decimal?) 0,
                                           Decimal.Parse(txtMaxBalance.Text),
                                           true, 0, true, null, true, "", "", txtEmail.Text, "VN", "", DateTime.Now, "", 
                                           DateTime.Parse(txtDateBirth.Text), null, null, true, null, null, "", null, null, "", true,
                                           null, null, "", txtAddress.Text, "", "", "", null, null, null);


                limit = Customers.Rows.Count - 1;
            }
            AddState(1);
        }
        #region State
        public void AddState(int i)
        {
            btnDeleteCustomer.Enabled = false;
            
            btnSearch.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            //cmbCate.SelectedIndex = 0;
            ckb_Sua.Enabled = false;
            if(i==1)
            {
                btnSaveCustomer.Enabled = false;
                btnAddCustomer.Enabled = true;
                btnAddCustomer.Text = "Lưu lại";
                
                txtMaKH.Text = "";
                txtMaKH.Enabled = true;
                txtMaKH.Focus();
                txtName.Text = "";
                start_state();
                
            }else
            {
                btnAddCustomer.Enabled = false;
            }
            btnExit.Text = "Hủy";
           
            this.Refresh();
        }
        private void start_state()
        {
            txtAddress.Text = "";
            txtDateBirth.Text = "";
            txtDateCloseAccount.Text = DateTime.Now.ToShortDateString();
            txtDateCustomer.Text = DateTime.Now.ToShortDateString();
            txtDateOpenAccount.Text = DateTime.Now.ToShortDateString();
            txtDiscountPercent.Text = "0";
            txtMaxBalance.Text = "";
            txtMaKH.Text = "";
            txtEmail.Text = "";
            txtMobilephone.Text = "";
            txtName.Text = "";
            txtNameCompany.Text = "";
            txtTelephone.Text = "";
            txtMaKH.Focus();
        }
        #endregion
        private void ckb_Sua_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Sua.Checked)
            {
                m_oldCusNum = txtMaKH.Text;
                btnSaveCustomer.Enabled = true;
                txtName.Enabled = true;
                txtName.Focus();
                txtName.SelectionLength = txtName.Text.Length;
                AddState(0);
                return;
            }
            txtName.Enabled = false;
            btnSaveCustomer.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnExit.Text == "Hủy")
            {
                FirstState();
                Customers = get_service.GetAllCustomers();
                limit = Customers.Rows.Count - 1;
                changeState(Customers, currentIndex);
            }
            else
            {
                this.Dispose();
            }
        }
        public void FirstState()
        {
            btnAddCustomer.Enabled = true;
            btnSearch.Enabled = true;
            btnSaveCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnExit.Text = "Thoát";
            btnAddCustomer.Text = "Thêm khách hàng";
            ckb_Sua.Enabled = true;
            ckb_Sua.Checked = false;
            txtMaKH.Enabled = false;
            this.Refresh();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Equals(""))
            {
                Alert.Show("Bạn phải nhập mã đã!", Color.Red);
                return;
            }
            //cmbCate.SelectedIndex = 0;
            //DataRowView item = (DataRowView)cmbDept.SelectedItem;
            //Customer.CustomerDataTable tmp = get_service.GetCustomerByID(txtMaKH.Text);
            //if (tmp.Rows.Count > 0)
            //{
            //    Alert.Show("Mã này đã tồn tại", Color.Red);
            //    return;
            //}

            DateTime dateTimeOpenAccount = DateTime.Now;
            DateTime dateTimeCloseAccount = DateTime.Now;
            DateTime dateTimeBirth = DateTime.Now;
            Decimal maxBalance = new decimal();
            if (!DateTime.TryParse(txtDateOpenAccount.Text, out dateTimeOpenAccount))
            {
                Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                txtDateOpenAccount.Focus();
                return;
            }
            if (!DateTime.TryParse(txtDateCloseAccount.Text, out dateTimeCloseAccount))
            {

                Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                txtDateCloseAccount.Focus();
                return;
            }
            if (!DateTime.TryParse(txtDateBirth.Text, out dateTimeBirth))
            {

                Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                txtDateBirth.Focus();
                return;
            }
            if (!Decimal.TryParse(txtMaxBalance.Text, out maxBalance))
            {
                Alert.Show("Bạn nhập sai", Color.Red);
                txtMaxBalance.Focus();
                return;
            }
            get_service.UpdateCustomer(txtMaKH.Text, "", txtName.Text, txtNameCompany.Text, txtAddress.Text, "", "",
                                           "", "", txtTelephone.Text, txtMobilephone.Text,
                                           "", "", "", "", float.Parse(txtDiscountPercent.Text),
                                           DateTime.Parse(txtDateOpenAccount.Text),
                                           DateTime.Parse(txtDateCloseAccount.Text), (decimal?)0,
                                           Decimal.Parse(txtMaxBalance.Text),
                                           true, 0, true, null, true, "", "", txtEmail.Text, "VN", "", DateTime.Now, "",
                                           DateTime.Parse(txtDateBirth.Text), null, null, true, null, null, "", null, null, "", true,
                                           null, null, "", txtAddress.Text, "", "", "", null, null, null,m_oldCusNum);

            Customers = get_service.GetAllCustomers();
            ckb_Sua.Checked = false;
            btnSearch.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnExit.Text = "Thoát";
            btnDeleteCustomer.Enabled = true;
            btnAddCustomer.Enabled = true;
            btnSaveCustomer.Enabled = false;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex == 0)
            {
                currentIndex = limit;
            }
            else
            {
                currentIndex--;
            }
            changeState(Customers, currentIndex);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex == limit)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            changeState(Customers, currentIndex);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string[] column = { Customer_Prop.CustNum, Customer_Prop.Last_Name, Customer_Prop.Address_1, Customer_Prop.Phone_1 };
            //FrmSearch search = new FrmSearch(Customers, column);
            //search.passdata = new FrmSearch.PassData(changeState);
            //search.ShowDialog();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            //DataTable ExistEmployee = get_service.GetEmployeeInInvoiceTotal(txtEmpID.Text);
            //if (ExistEmployee.Rows.Count > 0)
            //{
            //    DialogResult t =
            //        MessBox2Choice.ShowBox("Nhân viên mà bạn xóa \nHiện không xóa được.\n Bạn có muốn xóa không", Color.YellowGreen);
            //    if (t.Equals(System.Windows.Forms.DialogResult.No))
            //        return;

            //}
            get_service.DeleteCustomer(txtMaKH.Text);
            Customers = get_service.GetAllCustomers();
            limit = Customers.Rows.Count - 1;
            btnPrevious_Click(btnPrevious, null);
        }

        
    }
}
