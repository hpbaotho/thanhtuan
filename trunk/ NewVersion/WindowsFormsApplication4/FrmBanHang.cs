using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using POSReport.Report;
using Services;
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmBanHang : FrmPOS
    {
        //public ArrayList listNhomHang;
        //public ArrayList listIdNhomHang;
        //public ArrayList listMatHang;
        //public ArrayList listIdMatHang;

        public ArrayList listTSButtonDept;
        public ArrayList listTSButtonInvent;

        private int numOfPageNhom;
        private int pageIndexNhom;
        private int selectIndexNhom;

        private int numOfPageMatHang;
        private int pageIndexMatHang;
        public FrmLayout formLayout;
        public FrmLogin formLogin;
        private ServiceGet serviceGet;
        private get_GUI getGui;
        public string tableName;
        public string invoiceNum;
        public bool isOnHold;
        private decimal taxInvoice1;
        private decimal taxInvoice2;
        private int numOfItemSended;
        private Thread printThread;
        //private Thread printReceiptThread;
        
        public FrmBanHang()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
            getGui = new get_GUI();
            //for (int i = 1; i < 8;i++ )
            //{
            //    button tmp = (button)panel1.Controls["button" + i.ToString()];
            //    tmp.changeColor(Color.White,Color.Orange);
            //}
            //for (int i = 15; i < 43; i++)
            //{
            //    button tmp = (button)panel2.Controls["button" + i.ToString()];
            //    tmp.changeColor(Color.White, Color.Gray);
            //}
            button45.changeColor(Color.White,Color.OrangeRed);
            button46.changeColor(Color.White, Color.OrangeRed);
            button47.changeColor(Color.White,Color.Orange);
            button48.changeColor(Color.White, Color.Yellow);
            button49.changeColor(Color.White, Color.OrangeRed);
            button50.changeColor(Color.White, Color.Gray);
            button52.changeColor(Color.White, Color.Gray);
            button53.changeColor(Color.White, Color.Orange);
            button54.changeColor(Color.White, Color.Green);

            
            //listNhomHang = new ArrayList();
            
            
            //for (int i = 1; i < 18; i++)
            //{
            //    listNhomHang.Add(i.ToString());
            //}
            //for (int i = 1; i < 70; i++)
            //{
            //    listMatHang.Add(i.ToString());
            //}

            //listMatHang = new ArrayList();
            //listIdNhomHang = new ArrayList();
            //listNhomHang = new ArrayList();
            //listIdMatHang = new ArrayList();
            listTSButtonDept = new ArrayList();
            listTSButtonInvent = new ArrayList();
            DataTable tblnhomhang = serviceGet.GetDepartments("1001");
            for (int i = 0; i < tblnhomhang.Rows.Count; i++)
            {
                //listNhomHang.Add(tblnhomhang.Rows[i][2].ToString());
                //listIdNhomHang.Add(tblnhomhang.Rows[i][24].ToString());
                TSButton tsButton = new TSButton("01", Convert.ToInt32(tblnhomhang.Rows[i]["Index"]),
                 tblnhomhang.Rows[i]["Caption"].ToString(), tblnhomhang.Rows[i]["Picture"].ToString(), tblnhomhang.Rows[i]["Option1"].ToString(),
                 Convert.ToInt32(tblnhomhang.Rows[i]["BackColor"]), Convert.ToInt32(tblnhomhang.Rows[i]["ForeColor"]), Convert.ToBoolean(tblnhomhang.Rows[i]["Visible"]),
                 tblnhomhang.Rows[i]["Ident"].ToString());
                listTSButtonDept.Add(tsButton);
            }

            DataTable tblMathang = getGui.GetInventoryByDept("0", ((TSButton)listTSButtonDept[0]).Ident, "1001");
            for (int i = 0; i < tblMathang.Rows.Count; i++)
            {
                //listMatHang.Add(tblMathang.Rows[i][3].ToString());
                //listIdMatHang.Add(tblMathang.Rows[i][7].ToString());
                TSButton tsButton = new TSButton("01", Convert.ToInt32(tblMathang.Rows[i]["Index"]),
                 tblMathang.Rows[i]["Caption"].ToString(), tblMathang.Rows[i]["Picture"].ToString(), tblMathang.Rows[i]["Option1"].ToString(),
                 Convert.ToInt32(tblMathang.Rows[i]["BackColor"]), Convert.ToInt32(tblMathang.Rows[i]["ForeColor"]), Convert.ToBoolean(tblMathang.Rows[i]["Visible"]),
                 tblMathang.Rows[i]["Ident"].ToString());
                listTSButtonInvent.Add(tsButton);
            }

            if(listTSButtonDept.Count % 7 == 0)
            {
                numOfPageNhom = listTSButtonDept.Count / 7;
            }
            else
            {
                numOfPageNhom = listTSButtonDept.Count / 7 + 1;
                
            }

            if (listTSButtonInvent.Count % 28 == 0)
            {
                numOfPageMatHang = listTSButtonInvent.Count / 28;
            }
            else
            {
                numOfPageMatHang = listTSButtonInvent.Count / 28 + 1;
            }
            pageIndexNhom = 1;
            selectIndexNhom = 1;

            pageIndexMatHang = 1;

            
            LoadNhomHang();
            LoadMatHang();

        }


        public void LoadMatHang()
        {

            for (int i = (pageIndexMatHang - 1) * 28; i < pageIndexMatHang * 28; i++)
            {
                int a = i - (pageIndexMatHang - 1)*28 + 15;

                button tmp = (button) panel2.Controls["button" + a.ToString()];
                if (i < listTSButtonInvent.Count)
                {

                    tmp.Text = ((TSButton)listTSButtonInvent[i]).Caption;
                    tmp.Ident = ((TSButton)listTSButtonInvent[i]).Ident;
                    tmp.Color2 = Color.FromArgb(((TSButton)listTSButtonInvent[i]).BackColor);
                    tmp.ForeColor = Color.FromArgb(((TSButton)listTSButtonInvent[i]).ForeColor);
                    tmp.Visible = true;
                }
                else
                {
                    tmp.Visible = false;
                }
            }
            this.Refresh();
        }

        public void LoadNhomHang()
        {
            for (int i = (pageIndexNhom -1)*7; i < pageIndexNhom * 7 ; i++)
            {
                int a = i - (pageIndexNhom - 1) * 7 + 1;
                
                button tmp = (button)panel1.Controls["button" + a.ToString()];
                if(i < listTSButtonDept.Count )
                {

                    tmp.Text = ((TSButton)listTSButtonDept[i]).Caption;
                    tmp.Ident = ((TSButton)listTSButtonDept[i]).Ident;
                    tmp.Color2 = Color.FromArgb(((TSButton)listTSButtonDept[i]).BackColor);
                    tmp.ForeColor = Color.FromArgb(((TSButton)listTSButtonDept[i]).ForeColor);
                    tmp.Visible = true;
                }
                else
                {
                    tmp.Visible = false;
                }
                if(i + 1 == selectIndexNhom)
                {
                    ((button) panel1.Controls["button" + (a+7).ToString()]).Visible = true;
                }
                else
                {
                    ((button)panel1.Controls["button" + (a+7).ToString()]).Visible = false;
                }

            }
            this.Refresh();
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            

            myCash1.Label_Ban.Text = tableName;
            myCash1.Label_ServerId.Text = StaticClass.thongTinNV["EmpName"].ToString();
            myCash1.listInvoiceItem = getGui.GetInvoiceItemized(StaticClass.storeId, this.invoiceNum);
            myCash1.invoiceTotal = getGui.GetInvoiceTotal(StaticClass.storeId, invoiceNum);
            taxInvoice1 = Convert.ToDecimal(myCash1.invoiceTotal.Rows[0]["InvoiceTax"]);
            numOfItemSended = myCash1.listInvoiceItem.Rows.Count;

            if(isOnHold)
                
            {
                foreach (DataRow c in myCash1.listInvoiceItem.Rows)
                {
                    Decimal quan = Convert.ToDecimal(c[3]);
                    Decimal pricePer = Convert.ToDecimal(c[5]);
                    Decimal price = quan*pricePer; 
                    myCash1.addRow(">"+c[13].ToString(), String.Format("{0:0.##}",c[3]), String.Format("{0:0,0}", price));
                }
            }
            for (int i = 1; i < 8;i++ )
            {
                string buttonName = "button" + i.ToString();
                button tmp = (button)panel1.Controls[buttonName];
                tmp.Click += new EventHandler(tmp_Click);
                //tmp.changeColor(Color.White, Color.Orange);
            }
            for (int i = 15; i < 43; i++)
            {
                button tmp1 = (button)panel2.Controls["button" + i.ToString()];
                //tmp1.changeColor(Color.White, Color.Gray);
                tmp1.Click += new EventHandler(tmp1_Click);
            }
            UpdateInfo();
        }

        void tmp1_Click(object sender, EventArgs e)
        {
            DataRow invent = getGui.GetInventoryByItemNum(StaticClass.storeId, ((button)sender).Ident).Rows[0];
            float quant = PromptQuant(invent);
            if(quant <= 0 )
            {
                return;
            }

            if (CheckInStock(StaticClass.storeId, ((button)sender).Ident, 0, quant))
            {
                string itemName = invent[1].ToString();
                Decimal price = PromptPrice(invent);
                if(price == Convert.ToDecimal(-0.1234))
                {
                    return;
                }

                SpecialPricing specialPricing = new SpecialPricing(((button)sender).Ident);
                decimal newPrice =  specialPricing.CalculatePrice(1, price, Convert.ToDateTime(myCash1.invoiceTotal.Rows[0]["DateTime"]));

                //bool Tax1 = (bool)invent[9];
                //bool Tax2 = (bool)invent[10];
                //bool Tax3 = (bool)invent[11];
                Decimal Tax1Per = 0;
                Decimal Tax2Per = 0;
                Decimal Tax3Per = 0;
                //Decimal Tax1Rate = Convert.ToDecimal(StaticClass.taxRate[1]);
                //Decimal Tax2Rate = Convert.ToDecimal(StaticClass.taxRate[2]);
                //Decimal Tax3Rate = Convert.ToDecimal(StaticClass.taxRate[7]);
                //if (Tax1)
                //{
                //    Tax1Per = price * Tax1Rate;
                //}
                //if (Tax2)
                //{
                //    Tax2Per = price * Tax2Rate;
                //}
                //if (Tax3)
                //{
                //    Tax3Per = price * Tax3Rate;
                //}
                decimal costper = Convert.ToDecimal(invent[3]);
                object[] newrow = new object[] { invoiceNum, (myCash1.listInvoiceItem.Rows.Count + 1).ToString(), ((button)sender).Ident, quant.ToString(), costper, newPrice, Tax1Per, Tax2Per, Tax3Per, null, null, null, 0.00, itemName, null, null, null, null, StaticClass.storeId, newPrice, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
                myCash1.listInvoiceItem.Rows.Add(newrow);
                myCash1.addRow(itemName, String.Format("{0:0.##}", quant), String.Format("{0:0,0}", newPrice * Convert.ToDecimal(quant)));
                UpdateInfo();
                specialPricing = null;
                invent = null;
            }
        }

        decimal PromptPrice(DataRow Item)
        {
            if (Convert.ToBoolean(Item[42]))
            {
                FrmKeyboardNumber frmKeyboardNumber = new FrmKeyboardNumber("Nhập Giá bán");
                if (frmKeyboardNumber.ShowDialog() == DialogResult.OK)
                {
                    return Convert.ToDecimal(frmKeyboardNumber.value);
                }
                else
                {
                    return  Convert.ToDecimal(-0.1234);
                }
            }
            else
            {
                return Convert.ToDecimal(Item[4]);
            }
        }

        float PromptQuant(DataRow Item)
        {
            if(Convert.ToBoolean(Item[43]))
            {
                FrmKeyboardNumber frmKeyboardNumber = new FrmKeyboardNumber("Nhập số lượng ");
                if(frmKeyboardNumber.ShowDialog() == DialogResult.OK)
                {
                    return Convert.ToSingle(frmKeyboardNumber.value);
                }
                return -1;
            }
            else
            {
                return 1;
            }
            
        }

        void tmp_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(((button)sender).Name.Substring(6, 1)) + 7;
            selectIndexNhom = (pageIndexNhom -1)*7 + a - 7;
            for (int i = 8; i < 15;i++ )
            {
                button tmp = (button)panel1.Controls["button" + i.ToString()];
                tmp.Visible = false;
            }
            ((button)panel1.Controls["button" + a.ToString()]).Visible = true;
            DataTable tblMathang = getGui.GetInventoryByDept("0", ((button)sender).Ident, "1001");
            //listMatHang.Clear();
            //listIdMatHang.Clear();
            listTSButtonInvent = null;
            listTSButtonInvent = new ArrayList();
            for (int i = 0; i < tblMathang.Rows.Count; i++)
            {
                //listMatHang.Add(tblMathang.Rows[i][3].ToString());
                //listIdMatHang.Add(tblMathang.Rows[i][7].ToString());
                TSButton tsButton = new TSButton("01", Convert.ToInt32(tblMathang.Rows[i]["Index"]),
                 tblMathang.Rows[i]["Caption"].ToString(), tblMathang.Rows[i]["Picture"].ToString(), tblMathang.Rows[i]["Option1"].ToString(),
                 Convert.ToInt32(tblMathang.Rows[i]["BackColor"]), Convert.ToInt32(tblMathang.Rows[i]["ForeColor"]), Convert.ToBoolean(tblMathang.Rows[i]["Visible"]),
                 tblMathang.Rows[i]["Ident"].ToString());
                listTSButtonInvent.Add(tsButton);

            }
            if (listTSButtonInvent.Count % 28 == 0)
            {
                numOfPageMatHang = listTSButtonInvent.Count / 28;
            }
            else
            {
                numOfPageMatHang = listTSButtonInvent.Count / 28 + 1;
            }
            pageIndexMatHang = 1;
            LoadMatHang();
            this.Refresh();
            
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if(pageIndexNhom > 1)
            {
                pageIndexNhom -= 1;
                LoadNhomHang();
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if(pageIndexNhom < numOfPageNhom)
            {
                pageIndexNhom += 1;
                LoadNhomHang();
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (pageIndexMatHang > 1)
            {
                pageIndexMatHang -= 1;
                LoadMatHang();
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (pageIndexMatHang < numOfPageMatHang)
            {
                pageIndexMatHang += 1;
                LoadMatHang();
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if(myCash1.listInvoiceItem.Rows.Count == 0)
            {
                myCash1.invoiceTotal.Rows[0][15] = "V";
                UpdateInvoiceTotals();
                getGui.DeleteInvoiceItemized(StaticClass.storeId, this.invoiceNum);
                getGui.CloseTable(StaticClass.storeId,this.invoiceNum);
                this.Dispose();
                formLogin.RequestMess("UpdateForm");
            }
            else
            {
                Alert.Show("Hủy hoặc giữ hóa đơn \ntrước khi thoát !",Color.Red);
            }
            
        }

        private void button53_Click(object sender, EventArgs e)
        {
            getGui.DeleteInvoiceItemized(StaticClass.storeId, this.invoiceNum);
            if(myCash1.listInvoiceItem.Rows.Count == 0)
            {
                myCash1.invoiceTotal.Rows[0][15] = "V";
                getGui.CloseTable(StaticClass.storeId,invoiceNum);
            }
            else
            {          
                foreach (DataRow c in myCash1.listInvoiceItem.Rows)
                {
                    getGui.UpdateInvoiceItemized(StaticClass.storeId, invoiceNum, c[2].ToString(), c[3].ToString(), c[12].ToString(), c[1].ToString(), c[6].ToString(), c[7].ToString(), c[8].ToString(),c[5].ToString(),c[19].ToString());
                }
            }
            UpdateInvoiceTotals();
            formLayout.FrmLayout_Load(null, null);
            //if(printThread == null||!printThread.IsAlive)
            //{
            //    printThread = new Thread(new ThreadStart(SendToKitchen));
            //    printThread.Start();
            //}
            
            SendToKitchen();
            formLogin.RequestMess("UpdateForm");
            this.Dispose();
            

            //formLogin.FrmLogin_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void changeLayout(object sender, EventArgs e)
        {
            bool tmp = (bool)sender;
            if (tmp)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel4.Visible = true;
                panel5.Visible = false;
                panel4.BringToFront();

            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel4.Visible = false;
                panel5.Visible = false;
                panel4.SendToBack();
            }



        }

        private void button50_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 20; i++)
            //    myCash1.addRow("mota", i.ToString(), "gia");
        }

        private void button55_Click(object sender, EventArgs e)
        {
            if(checkItemSended())
            {
                if(!Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_INVOICE_DELETE_ITEMS))
                {
                    return;
                }
            }
            int i = 0;
            foreach (MyItem item in myCash1.get_RowSelected())
            {
                myCash1.listInvoiceItem.Rows.RemoveAt(item.Id - 1 - i);
                i++;
            }
            myCash1.delete_RowSelected();
            changeLayout(false,null);
            UpdateInfo();
            UpdateLineNum();
        }

        private void UpdateLineNum()
        {
            for (int i = 0; i < myCash1.listInvoiceItem.Rows.Count; i++)
            {
                myCash1.listInvoiceItem.Rows[i]["LineNum"] = i + 1;
            }
        }

        private bool checkItemSended()
        {
            foreach (MyItem item in myCash1.get_RowSelected())
            {
                if(item.Id -1 < numOfItemSended)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateInfo()
        {
            Decimal SumTax1 = 0;
            Decimal SumTax2 = 0;
            Decimal SumTax3 = 0;
            Decimal SumPice = 0;
            Decimal GranTotal = 0;
            Decimal SumCost = 0;
            for (int i = 0; i < myCash1.listInvoiceItem.Rows.Count; i++)
            {
                Decimal quant = Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][3]);
                SumTax1 += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][6])*quant;
                SumTax2 += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][7]) * quant;
                SumTax3 += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][8]) * quant;
                SumPice += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][3])*
                           Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][5]);
                SumCost += quant * Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i]["CostPer"]);
            }
            Decimal SumTax = SumTax1+SumTax2+SumTax3;
            GranTotal = SumPice + SumTax;
            myCash1.invoiceTotal.Rows[0][6] = SumPice;
            //myCash1.invoiceTotal.Rows[0][7] = SumTax1;
            //myCash1.invoiceTotal.Rows[0][8] = SumTax2;
            //myCash1.invoiceTotal.Rows[0][9] = SumTax3;

            decimal invoiceDiscount = Convert.ToDecimal(myCash1.invoiceTotal.Rows[0]["Discount"]);

            SumTax = taxInvoice1*SumPice*(1 - invoiceDiscount);
            GranTotal = SumTax + SumPice * (1 - invoiceDiscount);


            myCash1.invoiceTotal.Rows[0]["Total_Tax1"] = SumTax;
            myCash1.invoiceTotal.Rows[0]["InvoiceTax"] = taxInvoice1;
            myCash1.invoiceTotal.Rows[0]["Grand_Total"] = GranTotal;
            myCash1.invoiceTotal.Rows[0]["Total_Cost"] = SumCost;


            myCash1.label_Total.Text = String.Format("{0:0,0}", GranTotal);
            myCash1.label_Tax.Text = String.Format("{0:0,0}", SumTax);

        }

        public void UpdateInvoiceTotals()
        {
            getGui.UpdateInvoiceTotal(myCash1.invoiceTotal.Rows[0].ItemArray);
        }

        public void UpdateItemSelect()
        {
          
            foreach (MyItem item in myCash1.get_RowSelected())
            {
                string itemNum = myCash1.listInvoiceItem.Rows[item.Id - 1][2].ToString();
                Decimal orgPrice = Convert.ToDecimal(myCash1.listInvoiceItem.Rows[item.Id - 1][19]);
                Decimal disc = Convert.ToDecimal(myCash1.listInvoiceItem.Rows[item.Id - 1][12]);
                Decimal quantity = Convert.ToDecimal(myCash1.listInvoiceItem.Rows[item.Id - 1][3]);

                DataRow invent = getGui.GetInventoryByItemNum(StaticClass.storeId,itemNum).Rows[0];
                Decimal pricePer = orgPrice * (1 - disc) ;

                Decimal price = orgPrice*(1 - disc) * quantity;

                bool Tax1 = (bool)invent[9];
                bool Tax2 = (bool)invent[10];
                bool Tax3 = (bool)invent[11];
                Decimal Tax1Per = 0;
                Decimal Tax2Per = 0;
                Decimal Tax3Per = 0;
                Decimal Tax1Rate = Convert.ToDecimal(StaticClass.taxRate[1]);
                Decimal Tax2Rate = Convert.ToDecimal(StaticClass.taxRate[2]);
                Decimal Tax3Rate = Convert.ToDecimal(StaticClass.taxRate[7]);
                if (Tax1)
                {
                    Tax1Per = pricePer * Tax1Rate;
                }
                if (Tax2)
                {
                    Tax2Per = pricePer * Tax2Rate;
                }
                if (Tax3)
                {
                    Tax3Per = pricePer * Tax3Rate;
                }
                myCash1.listInvoiceItem.Rows[item.Id - 1][5] = pricePer;
                myCash1.listInvoiceItem.Rows[item.Id - 1][6] = Tax1Per;
                myCash1.listInvoiceItem.Rows[item.Id - 1][7] = Tax2Per;
                myCash1.listInvoiceItem.Rows[item.Id - 1][8] = Tax3Per;
                item.changeItem(String.Format("{0:0.##}", myCash1.listInvoiceItem.Rows[item.Id - 1][3]), String.Format("{0:0,0}", price));
            }

            UpdateInfo();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            if(checkItemSended())
            {
                if(!Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_INVOICE_QUAN_CHANGE))
                {
                    return;
                }
            }
            FrmKeyboardNumber kb = new FrmKeyboardNumber("Nhập số lượng :");
            if(kb.ShowDialog() == DialogResult.OK)
            {
                if(Convert.ToDecimal(kb.value) == 0)
                {
                    Alert.Show("Không thể nhập số lượng \nbằng 0",Color.Red);
                }
                else
                {
                    foreach (MyItem item in myCash1.get_RowSelected())
                    {
                        string itemNum = myCash1.listInvoiceItem.Rows[item.Id - 1]["ItemNum"].ToString();
                        float Quan = Convert.ToSingle(myCash1.listInvoiceItem.Rows[item.Id - 1]["Quantity"]);
                        if (CheckInStock(StaticClass.storeId, itemNum, 0, Convert.ToSingle(kb.value)))
                        {
                            myCash1.listInvoiceItem.Rows[item.Id - 1][3] = kb.value;
                        }
                    }
                    UpdateItemSelect();
                }
                
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if(Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_INVOICE_DISCOUNT))
            {
                FrmKeyboardNumber kb = new FrmKeyboardNumber("Nhập % khấu trừ");
                if (kb.ShowDialog() == DialogResult.OK)
                {
                    foreach (MyItem item in myCash1.get_RowSelected())
                    {
                        Decimal disc = Convert.ToDecimal(kb.value)/100;
                        myCash1.listInvoiceItem.Rows[item.Id - 1][12] = disc;
                    }
                    UpdateItemSelect();
                }
            }
            
        }

        private void button52_Click(object sender, EventArgs e)
        {
            panel5.Visible = !panel5.Visible;
            if(panel5.Visible)
            {
                panel5.BringToFront();
            }

        }

        private void button62_Click(object sender, EventArgs e)
        {
            if(Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_INVOICE_VOID))
            {
                myCash1.invoiceTotal.Rows[0][15] = "V";
                UpdateInvoiceTotals();
                getGui.CloseTable(StaticClass.storeId, invoiceNum);
                this.Dispose();
                formLayout.FrmLayout_Load(null, null);
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            getGui.DeleteInvoiceItemized(StaticClass.storeId, this.invoiceNum);
            if (myCash1.listInvoiceItem.Rows.Count == 0)
            {
                myCash1.invoiceTotal.Rows[0][15] = "V";
                
                getGui.CloseTable(StaticClass.storeId, invoiceNum);
            }
            else
            {
                myCash1.invoiceTotal.Rows[0][57] = Convert.ToInt32(myCash1.invoiceTotal.Rows[0][57]) + 1;
                foreach (DataRow c in myCash1.listInvoiceItem.Rows)
                {
                    getGui.UpdateInvoiceItemized(StaticClass.storeId, invoiceNum, c[2].ToString(), c[3].ToString(), c[12].ToString(), c[1].ToString(), c[6].ToString(), c[7].ToString(), c[8].ToString(), c[5].ToString(), c[19].ToString());
                }
            }
            UpdateInvoiceTotals();
            formLogin.RequestMess("UpdateForm");
            formLayout.FrmLayout_Load(null, null); 
            SendToKitchen();
            //if (printThread == null || !printThread.IsAlive)
            //{
            //    printThread = new Thread(new ThreadStart(SendToKitchen));
            //    printThread.Start();
            //}

            //if (printReceiptThread == null || !printReceiptThread.IsAlive)
            //{
            //    printReceiptThread = new Thread(new ThreadStart(PrintTamtinh));
            //    printReceiptThread.Start();
            //}
            PrintTamtinh();
            
            this.Dispose();
            
        }

        private void PrintTamtinh()
        {
            if (myCash1.listInvoiceItem.Rows.Count != 0)
            {
                Printer printer = serviceGet.GetPrinterByName(StaticClass.storeId, StaticClass.stationId, "Hóa đơn");
                if (!(printer == null || printer.Details == "NONE" || printer.Disable == true))
                {
                    CrystalReport5 xxx = new CrystalReport5();

                    if (StaticClass.mode == "AUT")
                    {
                        xxx.DataSourceConnections[0].SetConnection(StaticClass.serverName, StaticClass.databaseName, true);
                    }
                    else if (StaticClass.mode == "SQL")
                    {
                        xxx.SetDatabaseLogon(StaticClass.userName, StaticClass.password, StaticClass.serverName,
                                         StaticClass.databaseName);
                        xxx.DataSourceConnections[0].IntegratedSecurity = false;
                    }
                    else
                    {
                        return;
                    }
                    ParameterFieldDefinitions crParameterFieldDefinitions;
                    ParameterFieldDefinition crParameterFieldDefinition;
                    ParameterValues crParameterValues = new ParameterValues();

                    ParameterFieldDefinitions crParameterFieldDefinitions1;
                    ParameterFieldDefinition crParameterFieldDefinition1;
                    ParameterValues crParameterValues1 = new ParameterValues();

                    ParameterFieldDefinitions crParameterFieldDefinitions2;
                    ParameterFieldDefinition crParameterFieldDefinition2;
                    ParameterValues crParameterValues2 = new ParameterValues();

                    ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                    ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
                    ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();

                    crParameterDiscreteValue.Value = StaticClass.storeId;
                    crParameterFieldDefinitions = xxx.DataDefinition.ParameterFields;
                    crParameterFieldDefinition = crParameterFieldDefinitions["@Store_ID"];
                    crParameterValues = crParameterFieldDefinition.CurrentValues;

                    crParameterValues.Clear();
                    crParameterValues.Add(crParameterDiscreteValue);
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                    crParameterDiscreteValue1.Value = invoiceNum;
                    crParameterFieldDefinitions1 = xxx.DataDefinition.ParameterFields;
                    crParameterFieldDefinition1 = crParameterFieldDefinitions1["@Invoice_Number"];
                    crParameterValues1 = crParameterFieldDefinition1.CurrentValues;

                    crParameterValues1.Clear();
                    crParameterValues1.Add(crParameterDiscreteValue1);
                    crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

                    crParameterDiscreteValue2.Value = tableName;
                    crParameterFieldDefinitions2 = xxx.DataDefinition.ParameterFields;
                    crParameterFieldDefinition2 = crParameterFieldDefinitions2["table"];
                    crParameterValues2 = crParameterFieldDefinition2.CurrentValues;

                    crParameterValues2.Clear();
                    crParameterValues2.Add(crParameterDiscreteValue2);
                    crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2);

                    xxx.PrintOptions.PrinterName = printer.Details;

                    xxx.PrintOptions.ApplyPageMargins(new PageMargins(1, 2, 1, 0));
                    try
                    {
                        xxx.PrintToPrinter(1, false, 0, 0);
                    }
                    catch (Exception)
                    {
                        Alert.Show("Lỗi máy in", Color.Red);
                    }
                    xxx.Dispose();
                }
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if(Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_TRANSFER_TABLE))
            {
                FrmLayout formchuyen = new FrmLayout(StaticClass.cashierId);
                formchuyen.isTransfer = true;
                formchuyen.formBanHang = this;
                formchuyen.ShowDialog();
                formLogin.RequestMess("UpdateForm");
            }
            
        }
        public void transfer(string newTableName,string sectionID)
        {
            getGui.UpdateTransfer(StaticClass.storeId,invoiceNum,newTableName,sectionID);
            tableName = newTableName;
            myCash1.Label_Ban.Text = tableName;
        }

        public void combine(string newTable,string sectionID,string InvoiceNumOld)
        {
            getGui.DeleteInvoiceOnhold(StaticClass.storeId,InvoiceNumOld);
            DataTable oldInvoiceItemized = getGui.GetInvoiceItemized(StaticClass.storeId, InvoiceNumOld);
            for (int i = 0; i < oldInvoiceItemized.Rows.Count; i++)
            {
                oldInvoiceItemized.Rows[i]["Invoice_Number"] = invoiceNum;
                oldInvoiceItemized.Rows[i]["LineNum"] = myCash1.listInvoiceItem.Rows.Count + 1;
                myCash1.listInvoiceItem.Rows.Add(oldInvoiceItemized.Rows[i].ItemArray);
                decimal price = Convert.ToDecimal(oldInvoiceItemized.Rows[i]["Quantity"]) * Convert.ToDecimal(oldInvoiceItemized.Rows[i]["PricePer"]) * (1 - Convert.ToDecimal(oldInvoiceItemized.Rows[i]["LineDisc"]));
                myCash1.addRow(">"+oldInvoiceItemized.Rows[i]["DiffItemName"].ToString(), String.Format("{0:0.##}", oldInvoiceItemized.Rows[i]["Quantity"]), String.Format("{0:0,0}", price));
            }
            UpdateInfo();

            getGui.UpdateCombine(StaticClass.storeId,InvoiceNumOld,invoiceNum);
            numOfItemSended = myCash1.listInvoiceItem.Rows.Count;

        }

        private void button64_Click(object sender, EventArgs e)
        {
            if(Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_TRANSFER_TABLE))
            {
                FrmLayout formchuyen = new FrmLayout(StaticClass.cashierId);
                formchuyen.isTransfer = true;
                formchuyen.formBanHang = this;
                formchuyen.ShowDialog();
                formLogin.RequestMess("UpdateForm");
            }
            
        }

        private void button61_Click(object sender, EventArgs e)
        {
            ArrayList myItems = myCash1.get_RowSelected();
            MyItem myItem = (MyItem)myItems[0];
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard(myCash1.listInvoiceItem.Rows[myItem.Id - 1]["Kit_ItemNum"].ToString());
            if (frmKeyBoard.ShowDialog() == DialogResult.OK)
            {
                foreach (MyItem item in myItems)
                {
                    myCash1.listInvoiceItem.Rows[item.Id - 1]["Kit_ItemNum"] = frmKeyBoard.value;
                }
            }
           
        }

        private void button65_Click(object sender, EventArgs e)
        {

            taxInvoice1 = Convert.ToDecimal(StaticClass.taxRate[1]);
            
            UpdateInfo();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            taxInvoice1 = Convert.ToDecimal(StaticClass.taxRate[2]);
            UpdateInfo();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            taxInvoice1 = 0;
            UpdateInfo();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            if(Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_INVOICE_DISCOUNT))
            {
                FrmKeyboardNumber frmKeyBoard = new FrmKeyboardNumber("Nhập % khấu trừ : ");
                if (frmKeyBoard.ShowDialog() == DialogResult.OK)
                {
                    myCash1.invoiceTotal.Rows[0]["Discount"] = Convert.ToDecimal(frmKeyBoard.value) / 100;
                    UpdateInfo();
                }
            }
            
        }

        private void button54_Click(object sender, EventArgs e)
        {
            
            if(myCash1.listInvoiceItem.Rows.Count != 0)
            {
                FrmPay frmPay = new FrmPay();
                frmPay.textBox1.Text = frmPay.textBox2.Text = String.Format("{0:0,0}", Convert.ToDecimal(myCash1.label_Total.Text));
                if(frmPay.ShowDialog() == DialogResult.OK)
                {
                    myCash1.invoiceTotal.Rows[0]["Amt_Tendered"] = frmPay.tienTra;
                    myCash1.invoiceTotal.Rows[0]["Amt_Change"] = frmPay.tienThoi;
                    myCash1.invoiceTotal.Rows[0]["Status"] = "C";
                    myCash1.invoiceTotal.Rows[0]["Payment_Method"] = frmPay.hinhThucTra;
                    if(frmPay.hinhThucTra == "CA")
                    {
                        myCash1.invoiceTotal.Rows[0]["CA_Amount"] = Convert.ToDecimal(myCash1.label_Total.Text);

                    }
                    else if (frmPay.hinhThucTra == "CC")
                    {
                        myCash1.invoiceTotal.Rows[0]["CC_Amount"] = Convert.ToDecimal(myCash1.label_Total.Text);
                    }
                    else if (frmPay.hinhThucTra == "DC")
                    {
                        myCash1.invoiceTotal.Rows[0]["DC_Amount"] = Convert.ToDecimal(myCash1.label_Total.Text);
                    }

                    myCash1.invoiceTotal.Rows[0]["Cashier_ID"] = StaticClass.cashierId;
                    myCash1.invoiceTotal.Rows[0]["DateTime"] = DateTime.Now;
                    getGui.DeleteInvoiceItemized(StaticClass.storeId, this.invoiceNum);
                    if (myCash1.listInvoiceItem.Rows.Count == 0)
                    {
                        myCash1.invoiceTotal.Rows[0][15] = "V";
                        getGui.CloseTable(StaticClass.storeId, invoiceNum);
                    }
                    else
                    {
                        foreach (DataRow c in myCash1.listInvoiceItem.Rows)
                        {
                            getGui.UpdateInvoiceItemized(StaticClass.storeId, invoiceNum, c[2].ToString(), c[3].ToString(), c[12].ToString(), c[1].ToString(), c[6].ToString(), c[7].ToString(), c[8].ToString(), c[5].ToString(), c[19].ToString());
                            UpdateInstock(StaticClass.storeId, c[2].ToString(), Convert.ToSingle(c[3]));
                        }
                    }
                    UpdateInvoiceTotals();
                    getGui.DeleteInvoiceOnhold(StaticClass.storeId,invoiceNum);
                    formLogin.RequestMess("UpdateForm");
                    formLayout.FrmLayout_Load(null, null);

                    //if (printThread == null || !printThread.IsAlive)
                    //{
                    //    printThread = new Thread(new ThreadStart(SendToKitchen));
                    //    printThread.Start();
                    //}
                    SendToKitchen();
                    //if (printReceiptThread == null || !printReceiptThread.IsAlive)
                    //{
                    //    printReceiptThread = new Thread(new ThreadStart(printThanhToan));
                    //    printReceiptThread.Start();
                    //}
                    printThanhToan();

                    //SendToKitchen();
                    frmPay.Dispose();
                    this.Dispose();
                }
                frmPay.Dispose();
            }
            else
            {
                Alert.Show("Hóa đơn chưa có hàng",Color.Red);
            }
        }

        private void printThanhToan()
        {
            Printer printer = serviceGet.GetPrinterByName(StaticClass.storeId, StaticClass.stationId, "Hóa đơn");
            if (!(printer == null || printer.Details == "NONE" || printer.Disable == true))
            {
                Re_ThanhToan xxx = new Re_ThanhToan();

                if (StaticClass.mode == "AUT")
                {
                    xxx.DataSourceConnections[0].SetConnection(StaticClass.serverName, StaticClass.databaseName, true);
                }
                else if (StaticClass.mode == "SQL")
                {
                    xxx.SetDatabaseLogon(StaticClass.userName, StaticClass.password, StaticClass.serverName,
                                     StaticClass.databaseName);
                    xxx.DataSourceConnections[0].IntegratedSecurity = false;
                    //ConnectionInfo crConnectionInfo = new ConnectionInfo();
                    //crConnectionInfo.ServerName = StaticClass.serverName;
                    //crConnectionInfo.DatabaseName = StaticClass.databaseName;
                    //crConnectionInfo.UserID = StaticClass.userName;
                    //crConnectionInfo.Password = StaticClass.password;
                    //crConnectionInfo.IntegratedSecurity = false;

                    //Tables crTables = xxx.Database.Tables;

                    //for (int j = 0; j < crTables.Count; j++)
                    //{
                    //    Table crTable = crTables[j];
                    //    TableLogOnInfo crTableLogOnInfo = crTable.LogOnInfo;
                    //    crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                    //    crTable.ApplyLogOnInfo(crTableLogOnInfo);

                    //    crTable.Location = crConnectionInfo.DatabaseName + ".dbo." + crTable.Name;

                    //}
                }
                else
                {
                    return;
                }
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();

                ParameterFieldDefinitions crParameterFieldDefinitions1;
                ParameterFieldDefinition crParameterFieldDefinition1;
                ParameterValues crParameterValues1 = new ParameterValues();

                ParameterFieldDefinitions crParameterFieldDefinitions2;
                ParameterFieldDefinition crParameterFieldDefinition2;
                ParameterValues crParameterValues2 = new ParameterValues();

                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
                ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();

                crParameterDiscreteValue.Value = StaticClass.storeId;
                crParameterFieldDefinitions = xxx.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["@Store_ID"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                crParameterDiscreteValue1.Value = invoiceNum;
                crParameterFieldDefinitions1 = xxx.DataDefinition.ParameterFields;
                crParameterFieldDefinition1 = crParameterFieldDefinitions1["@Invoice_Number"];
                crParameterValues1 = crParameterFieldDefinition1.CurrentValues;

                crParameterValues1.Clear();
                crParameterValues1.Add(crParameterDiscreteValue1);
                crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

                crParameterDiscreteValue2.Value = tableName;
                crParameterFieldDefinitions2 = xxx.DataDefinition.ParameterFields;
                crParameterFieldDefinition2 = crParameterFieldDefinitions2["table"];
                crParameterValues2 = crParameterFieldDefinition2.CurrentValues;

                crParameterValues2.Clear();
                crParameterValues2.Add(crParameterDiscreteValue2);
                crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2);

                xxx.PrintOptions.PrinterName = printer.Details;

                xxx.PrintOptions.ApplyPageMargins(new PageMargins(1, 2, 1, 0));
                try
                {
                    xxx.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    Alert.Show("Lỗi máy in", Color.Red);
                }
                xxx.Dispose();
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            FrmManager frmManager = new FrmManager();
            frmManager.ShowDialog();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.CFA_INVOICE_PRICE_CHANGE))
            {
                return;
            }
            FrmKeyboardNumber kb = new FrmKeyboardNumber("Nhập giá :");
            if (kb.ShowDialog() == DialogResult.OK)
            {

                    foreach (MyItem item in myCash1.get_RowSelected())
                    {
                        myCash1.listInvoiceItem.Rows[item.Id - 1]["origPricePer"] = kb.value;
                    }
                    UpdateItemSelect();
            }
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if(!Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.CFA_INVOICE_RETURN))
            {
                return;
            }
            ArrayList arrayList = myCash1.get_RowSelected();
            if(arrayList.Count > 1)
            {
                Alert.Show("Chỉ chọn một món để trả lại.",Color.Red);
            }
            else
            {
                FrmKeyboardNumber frmKeyboardNumber = new FrmKeyboardNumber("Nhập số lượng trả lại");
                if(frmKeyboardNumber.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    decimal oldQuan = Convert.ToDecimal(myCash1.listInvoiceItem.Rows[((MyItem)arrayList[0]).Id - 1]["Quantity"]);
                    string itemNum = myCash1.listInvoiceItem.Rows[((MyItem)arrayList[0]).Id - 1]["ItemNum"].ToString();
                    decimal returnQuan = Convert.ToDecimal(frmKeyboardNumber.value);
                    if(oldQuan >= returnQuan)
                    {
                        object[] newrow = myCash1.listInvoiceItem.Rows[((MyItem) arrayList[0]).Id - 1].ItemArray;
                        newrow[3] = 0 - returnQuan;
                        newrow[1] = myCash1.listInvoiceItem.Rows.Count + 1;
                        decimal price = (0 - returnQuan)*Convert.ToDecimal(newrow[5]);
                        string itemName = myCash1.listInvoiceItem.Rows[((MyItem)arrayList[0]).Id - 1]["DiffItemName"].ToString();
                        
                        myCash1.listInvoiceItem.Rows.Add(newrow);
                        myCash1.addRow(itemName, String.Format("{0:0.##}",0-returnQuan), String.Format("{0:0,0}", price));
                        UpdateInfo();
                    }
                    else
                    {
                        Alert.Show("Số lượng trả vượt quá số\n lượng bán.",Color.Red);
                    }
                }
            }
        }

        private void SendToKitchen()
        {
            if(myCash1.listInvoiceItem.Rows.Count>0)
            {
                bool kt = false;
                foreach (Printer c in serviceGet.getPrintersOfKitchen(StaticClass.storeId, StaticClass.stationId))
                {
                    kt = false;
                    if (!c.Disable && (c.Details != "NONE"))
                    {
                        foreach (MyItem c1 in myCash1.get_All_Rows())
                        {
                            if (!(c1.Mota.StartsWith(">")))
                            {
                                DataTable inventPrinter = getGui.GetInventPrinter(StaticClass.storeId, myCash1.listInvoiceItem.Rows[c1.Id - 1]["ItemNum"].ToString(), c.PrinterName);
                                if (inventPrinter.Rows.Count > 0)
                                {
                                    string lineNum = myCash1.listInvoiceItem.Rows[c1.Id -1]["LineNum"].ToString();
                                    string itemNum = myCash1.listInvoiceItem.Rows[c1.Id - 1]["ItemNum"].ToString();
                                    string quan = myCash1.listInvoiceItem.Rows[c1.Id - 1]["Quantity"].ToString();
                                    string note = myCash1.listInvoiceItem.Rows[c1.Id - 1]["Kit_ItemNum"].ToString();
                                    string itemname = myCash1.listInvoiceItem.Rows[c1.Id - 1]["DiffItemName"].ToString();
                                    getGui.InsertItemsToPrintToKit(StaticClass.storeId, invoiceNum, lineNum, itemNum, quan, note, itemname);
                                    kt = true;
                                }
                            }
                        }
                        if (kt)
                        {
                            rpt_PrintToKit xxx = new rpt_PrintToKit();
                            if(StaticClass.mode == "AUT")
                            {
                                xxx.DataSourceConnections[0].SetConnection(StaticClass.serverName, StaticClass.databaseName, true);
                            }
                            else if(StaticClass.mode == "SQL")
                            {
                                xxx.SetDatabaseLogon(StaticClass.userName, StaticClass.password, StaticClass.serverName,
                                                 StaticClass.databaseName);
                                xxx.DataSourceConnections[0].IntegratedSecurity = false;
                            }
                            else
                            {
                                return;
                            }
                            
                            string[] para = { "@Store_ID", "@Invoice_Number","@Table" };
                            string[] value = {StaticClass.storeId,invoiceNum,tableName};
                            serviceGet.FillDataReport(xxx,para,value,true);

                            xxx.PrintOptions.PrinterName = c.Details;
                            xxx.PrintOptions.ApplyPageMargins(new PageMargins(1, 2, 1, 0));
                            try
                            {
                                xxx.PrintToPrinter(1, false, 0, 0);
                            }
                            catch (Exception)
                            {
                                Alert.Show("Lỗi máy in",Color.Red);
                            }
                            getGui.DeleteItemsPrintToKit(StaticClass.storeId, invoiceNum);
                            xxx.Dispose();
                            xxx = null;
                        }
                    }
                }
            }
        }

        private bool CheckInStock(string StoreId,string itemNum, float oldQuan, float newQuan)
        {
            DataTable inventory = getGui.GetInventoryByItemNum(StoreId, itemNum);
            bool countThisItem = Convert.ToBoolean(inventory.Rows[0]["Count_This_Item"]);
            if(countThisItem)
            {
                float InStock = Convert.ToSingle(inventory.Rows[0]["In_Stock"]);
                InStock = InStock + oldQuan - newQuan;
                if(InStock < 0)
                {
                    if(MessBox2Choice.ShowBox("Mặt hàng này còn ít \nhơn số lượng yêu cầu.\n Bạn có muốn bán không ?",Color.Red) == DialogResult.No)
                    {
                        return false;
                    }
                }
                //getGui.UpdateInStock(StoreId,itemNum,InStock.ToString());
            }
            return true;
        }
        private void UpdateInstock(string StoreId, string itemNum, float Quan)
        {
            DataTable inventory = getGui.GetInventoryByItemNum(StoreId, itemNum);
            bool countThisItem = Convert.ToBoolean(inventory.Rows[0]["Count_This_Item"]);
            if (countThisItem)
            {
                float InStock = Convert.ToSingle(inventory.Rows[0]["In_Stock"]);
                InStock = InStock - Quan;
                getGui.UpdateInStock(StoreId,itemNum,InStock.ToString());
            }

            ArrayList ingreList = serviceGet.GetInventIngredient(StaticClass.storeId, itemNum);
            foreach (Ingredient o in ingreList)
            {
                getGui.UpdateInStock(StaticClass.storeId,o.IngreId,(o.Instock - o.Quantity).ToString());
            }
        }

    }
}
