using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Const;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmCustomer : Form
    {
        private Services.get_GUI get_service;
        private Service.ServiceGet serviceGet;
        private Customer.CustomerDataTable Customers;
        private int currentIndex;
        private int limit;
        private string m_oldCusNum = "";
        private ArrayList swipeList;
        public FrmCustomer()
        {

            InitializeComponent();
            get_service = new get_GUI();
            serviceGet = new ServiceGet();
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

                    txtDateBirth.Text = row.IsBirthdayNull() ? "" : String.Format("{0:d/M/yyyy}", row.Birthday);
                    txtDateCloseAccount.Text = row.IsAcct_Close_DateNull() ? "" : String.Format("{0:d/M/yyyy}", row.Acct_Close_Date);

                    txtDateCustomer.Text = row.IsCreateDateNull() ? "" : String.Format("{0:d/M/yyyy}", row.CreateDate);

                    txtDateOpenAccount.Text = row.IsAcct_Open_DateNull() ? "" : String.Format("{0:d/M/yyyy}", row.Acct_Open_Date);

                    txtDiscountPercent.Text = row.Discount_Percent.ToString();
                    txtEmail.Text = row.IsEMailNull() ? "" : row.EMail;
                    txtMaKH.Text = row.CustNum;
                    txtMaxBalance.Text = row.IsAcct_Max_BalanceNull() ? "" : String.Format("{0:0,0}", row.Acct_Max_Balance);
                    txtMobilephone.Text = row.IsPhone_1Null() ? "" : row.Phone_1;
                    txtName.Text = row.Last_Name;
                    txtNameCompany.Text = row.IsCompanyNull() ? "" : row.Company;
                    txtTelephone.Text = row.IsPhone_2Null() ? "" : row.Phone_2;
                    lblNumberOfAdd.Text = row.IsAcct_BalanceNull() ? "" : String.Format("{0:0,0}", row.Acct_Balance); 

                    // Swipe
                    listBox1.Items.Clear();
                    swipeList = serviceGet.GetCustSwipeById(row.CustNum);
                    foreach (Persistence.CustomerSwipe customerSwipe in swipeList)
                    {
                        listBox1.Items.Add(customerSwipe);
                    }

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
                    Alert.Show("Bạn phải nhập mã \nkhách hàng!", Color.Red);
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
                txtMaxBalance.Text = "0";
                Decimal maxBalance=new decimal();
                if (!DateTime.TryParseExact(txtDateOpenAccount.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeOpenAccount))
                {
                    Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                    txtDateOpenAccount.Focus();
                    return;
                }
                if (!DateTime.TryParseExact(txtDateCloseAccount.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeCloseAccount))
                {

                    Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                    txtDateCloseAccount.Focus();
                    return;
                }
                if (!DateTime.TryParseExact(txtDateBirth.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeBirth))
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
                                           dateTimeOpenAccount,dateTimeCloseAccount, (decimal?) 0,
                                           Decimal.Parse(txtMaxBalance.Text),
                                           true, 0, true, null, true, "", "", txtEmail.Text, "VN", "", DateTime.Now, "",
                                           dateTimeBirth, null, null, true, null, null, "", null, null, "", true,
                                           null, null, "", txtAddress.Text, "", "", "", null, null, null);

                updateCustSwipe(txtMaKH.Text);
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
                swipeList = new ArrayList();
                listBox1.Items.Clear();

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
            txtDateCloseAccount.Text = String.Format("{0:d/M/yyyy}", DateTime.Now);
            txtDateCustomer.Text = String.Format("{0:d/M/yyyy}", DateTime.Now);
            txtDateOpenAccount.Text = String.Format("{0:d/M/yyyy}", DateTime.Now);
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
            txtName.Enabled = true;
            this.Refresh();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Equals(""))
            {
                Alert.Show("Bạn phải nhập mã \nkhách hàng!", Color.Red);
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
            if (!DateTime.TryParseExact(txtDateOpenAccount.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeOpenAccount))
            {
           
                Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                txtDateOpenAccount.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txtDateCloseAccount.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeCloseAccount))
            {

                Alert.Show("Bạn nhập sai kiểu ngày!", Color.Red);
                txtDateCloseAccount.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txtDateBirth.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeBirth))
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
                                           dateTimeOpenAccount,
                                           dateTimeCloseAccount, (decimal?)0,
                                           Decimal.Parse(txtMaxBalance.Text),
                                           true, 0, true, null, true, "", "", txtEmail.Text, "VN", "", DateTime.Now, "",
                                           dateTimeBirth, null, null, true, null, null, "", null, null, "", true,
                                           null, null, "", txtAddress.Text, "", "", "", null, null, null,m_oldCusNum);

            updateCustSwipe(txtMaKH.Text);

            Customers = get_service.GetAllCustomers();
            ckb_Sua.Checked = false;
            btnSearch.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnExit.Text = "Thoát";
            btnDeleteCustomer.Enabled = true;
            btnAddCustomer.Enabled = true;
            btnSaveCustomer.Enabled = false;
            ckb_Sua.Enabled = true;
            txtName.Enabled = true;
            txtMaKH.Enabled = true;
            this.Refresh();

        }

        private void updateCustSwipe(string custId)
        {
            foreach (Persistence.CustomerSwipe c in swipeList)
            {
                if(c.isDelete)
                {
                    if(!c.isNew)
                    {
                        get_service.DeleteCustSwipe(custId,c.swipeId);
                    }
                }
                else
                {
                    if(c.isNew)
                    {
                        get_service.InsertCustSwipe(custId,c.swipeId);
                    }
                }
            }
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
            if(txtMaKH.Text == "101")
            {
                Alert.Show("Không thể xóa \nkhách hàng này !",Color.Red);
                return;
            }
            foreach (Persistence.CustomerSwipe o in swipeList)
            {
                get_service.DeleteCustSwipe(txtMaKH.Text,o.swipeId);
            }
            get_service.DeleteCustomer(txtMaKH.Text);
            Customers = get_service.GetAllCustomers();
            limit = Customers.Rows.Count - 1;
            btnPrevious_Click(btnPrevious, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard(true);
            if(frmKeyBoard.ShowDialog() == DialogResult.OK)
            {
                DataTable dataTable = get_service.getCustBySwipe(frmKeyBoard.value);
                if (dataTable.Rows.Count > 0)
                {
                    Alert.Show("Thẻ từ đã tồn tại !",Color.Red);
                    return;
                }
                Persistence.CustomerSwipe customerSwipe = new CustomerSwipe(frmKeyBoard.value);
                customerSwipe.isNew = true;
                listBox1.Items.Add(customerSwipe);
                swipeList.Add(customerSwipe);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count > 0)
            {
                var customerSwipe = (Persistence.CustomerSwipe) listBox1.SelectedItems[0];
                customerSwipe.isDelete = true;
                listBox1.Items.Remove(customerSwipe);
            }
        }

        private void txtDateBirth_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmCanlendar frmCanlendar = new FrmCanlendar("Chọn ngày");
            if(frmCanlendar.ShowDialog() == DialogResult.OK)
            {
                txtDateBirth.Text = String.Format("{0:d/M/yyyy}", frmCanlendar.monthCalendar1.SelectionStart);
            }
        }

        
    }
}
