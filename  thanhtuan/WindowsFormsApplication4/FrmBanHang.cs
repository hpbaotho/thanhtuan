using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using POSReport.Report;
using Services;
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmBanHang : FrmPOS
    {
        public ArrayList listNhomHang;
        public ArrayList listIdNhomHang;
        public ArrayList listMatHang;
        public ArrayList listIdMatHang;
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

            listMatHang = new ArrayList();
            listIdNhomHang = new ArrayList();
            listNhomHang = new ArrayList();
            listIdMatHang = new ArrayList();
            DataTable tblnhomhang = serviceGet.GetDepartments("1001");
            for (int i = 0; i < tblnhomhang.Rows.Count; i++)
            {
                listNhomHang.Add(tblnhomhang.Rows[i][2].ToString());
                listIdNhomHang.Add(tblnhomhang.Rows[i][24].ToString());
            }

            DataTable tblMathang = getGui.GetInventoryByDept("0", listIdNhomHang[0].ToString(), "1001");
            for (int i = 0; i < tblMathang.Rows.Count; i++)
            {
                listMatHang.Add(tblMathang.Rows[i][3].ToString());
                listIdMatHang.Add(tblMathang.Rows[i][7].ToString());
            }

            if(listNhomHang.Count % 7 == 0)
            {
                numOfPageNhom = listNhomHang.Count/7;
            }
            else
            {
                numOfPageNhom = listNhomHang.Count / 7 + 1;
                
            }

            if (listMatHang.Count % 28 == 0)
            {
                numOfPageMatHang = listMatHang.Count / 28;
            }
            else
            {
                numOfPageMatHang = listMatHang.Count / 28 + 1;
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
                if (i < listMatHang.Count)
                {

                    tmp.Text = listMatHang[i].ToString();
                    tmp.Ident = listIdMatHang[i].ToString();
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
                if(i < listNhomHang.Count )
                {
                    
                    tmp.Text = listNhomHang[i].ToString();
                    tmp.Ident = listIdNhomHang[i].ToString();
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
            if(isOnHold)
                
            {
                foreach (DataRow c in myCash1.listInvoiceItem.Rows)
                {
                    Decimal quan = Convert.ToDecimal(c[3]);
                    Decimal pricePer = Convert.ToDecimal(c[5]);
                    Decimal price = quan*pricePer; 
                    myCash1.addRow(c[13].ToString(), String.Format("{0:0.00}",c[3]), String.Format("{0:0.00}", price));
                }
            }
            for (int i = 1; i < 8;i++ )
            {
                string buttonName = "button" + i.ToString();
                button tmp = (button)panel1.Controls[buttonName];
                tmp.Click += new EventHandler(tmp_Click);
                tmp.changeColor(Color.White, Color.Orange);
            }
            for (int i = 15; i < 43; i++)
            {
                button tmp1 = (button)panel2.Controls["button" + i.ToString()];
                tmp1.changeColor(Color.White, Color.Gray);
                tmp1.Click += new EventHandler(tmp1_Click);
            }
            UpdateInfo();
        }

        void tmp1_Click(object sender, EventArgs e)
        {
            DataRow invent = getGui.GetInventoryByItemNum(StaticClass.storeId, ((button) sender).Ident).Rows[0];
            string itemName = invent[1].ToString();
            Decimal price = Convert.ToDecimal(invent[4]);
            bool Tax1 = (bool)invent[9];
            bool Tax2 = (bool)invent[10];
            bool Tax3 = (bool)invent[11];
            Decimal Tax1Per = 0;
            Decimal Tax2Per = 0;
            Decimal Tax3Per = 0;
            Decimal Tax1Rate = Convert.ToDecimal(StaticClass.taxRate[1]);
            Decimal Tax2Rate = Convert.ToDecimal(StaticClass.taxRate[2]);
            Decimal Tax3Rate = Convert.ToDecimal(StaticClass.taxRate[7]);
            if(Tax1)
            {
                Tax1Per = price*Tax1Rate;
            }
            if (Tax2)
            {
                Tax2Per = price * Tax2Rate;
            }
            if (Tax3)
            {
                Tax3Per = price * Tax3Rate;
            }
            object[] newrow = new object[] { invoiceNum, (myCash1.listInvoiceItem.Rows.Count + 1).ToString(), ((button)sender).Ident, "1", null, price, Tax1Per, Tax2Per, Tax3Per, null, null, null, 0.00, null, null, null, null, null, StaticClass.storeId, price, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
            myCash1.listInvoiceItem.Rows.Add(newrow);
            myCash1.addRow(itemName,"1.00", String.Format("{0:0.00}",price));
            UpdateInfo();

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
            listMatHang.Clear();
            listIdMatHang.Clear();
            for (int i = 0; i < tblMathang.Rows.Count; i++)
            {
                listMatHang.Add(tblMathang.Rows[i][3].ToString());
                listIdMatHang.Add(tblMathang.Rows[i][7].ToString());
            }
            if (listMatHang.Count % 28 == 0)
            {
                numOfPageMatHang = listMatHang.Count / 28;
            }
            else
            {
                numOfPageMatHang = listMatHang.Count / 28 + 1;
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
            }
            else
            {
                MessageBox.Show("Hủy hoặc giữ hóa đơn trước khi thoát !");
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
                    getGui.UpdateInvoiceItemized(StaticClass.storeId, invoiceNum, c[2].ToString(), c[3].ToString(), c[12].ToString(), c[1].ToString(), c[6].ToString(), c[7].ToString(), c[8].ToString());
                }
            }
            UpdateInvoiceTotals();
            this.Dispose();
            formLayout.FrmLayout_Load(null,null);
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


            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel4.Visible = false;
            }



        }

        private void button50_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                myCash1.addRow("mota", i.ToString(), "gia");
        }

        private void button55_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (MyItem item in myCash1.get_RowSelected())
            {
                myCash1.listInvoiceItem.Rows.RemoveAt(item.Id -1 -i);
                i++;
            }
            myCash1.delete_RowSelected();
            changeLayout(false,null);
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            Decimal SumTax1 = 0;
            Decimal SumTax2 = 0;
            Decimal SumTax3 = 0;
            Decimal SumPice = 0;
            Decimal GranTotal = 0;
            for (int i = 0; i < myCash1.listInvoiceItem.Rows.Count; i++)
            {
                Decimal quant = Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][3]);
                SumTax1 += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][6])*quant;
                SumTax2 += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][7]) * quant;
                SumTax3 += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][8]) * quant;
                SumPice += Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][3])*
                           Convert.ToDecimal(myCash1.listInvoiceItem.Rows[i][5]);
            }
            Decimal SumTax = SumTax1+SumTax2+SumTax3;
            GranTotal = SumPice + SumTax;
            myCash1.invoiceTotal.Rows[0][6] = SumPice;
            myCash1.invoiceTotal.Rows[0][7] = SumTax1;
            myCash1.invoiceTotal.Rows[0][8] = SumTax2;
            myCash1.invoiceTotal.Rows[0][9] = SumTax3;
            myCash1.invoiceTotal.Rows[0][10] = GranTotal;

            myCash1.label_Total.Text = String.Format("{0:0.00}", GranTotal);
            myCash1.label_Tax.Text = String.Format("{0:0.00}", SumTax);

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
                item.changeItem(String.Format("{0:0.00}", myCash1.listInvoiceItem.Rows[item.Id - 1][3]), String.Format("{0:0.00}", price));
            }

            UpdateInfo();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            FrmKeyBoard kb = new FrmKeyBoard();
            if(kb.ShowDialog() == DialogResult.OK)
            {
                foreach (MyItem item in myCash1.get_RowSelected())
                {
                    myCash1.listInvoiceItem.Rows[item.Id - 1][3] = kb.value;
                }
                UpdateItemSelect();
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            FrmKeyBoard kb = new FrmKeyBoard();
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

        private void button52_Click(object sender, EventArgs e)
        {
            panel5.Visible = !panel5.Visible;
            if(!panel5.Visible)
            {
                panel5.BringToFront();
            }

        }

        private void button62_Click(object sender, EventArgs e)
        {
            myCash1.invoiceTotal.Rows[0][15] = "V";
            UpdateInvoiceTotals();
            getGui.CloseTable(StaticClass.storeId, invoiceNum);
            this.Dispose();
            formLayout.FrmLayout_Load(null, null);
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
                    getGui.UpdateInvoiceItemized(StaticClass.storeId, invoiceNum, c[2].ToString(), c[3].ToString(), c[12].ToString(), c[1].ToString(), c[6].ToString(), c[7].ToString(), c[8].ToString());
                }
            }
            UpdateInvoiceTotals();

            if (myCash1.listInvoiceItem.Rows.Count != 0)
            {
                CrystalReport5 xxx = new CrystalReport5();
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();

                ParameterFieldDefinitions crParameterFieldDefinitions1;
                ParameterFieldDefinition crParameterFieldDefinition1;
                ParameterValues crParameterValues1 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();


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


                xxx.PrintToPrinter(1, true, 1, 1);
            }
            this.Dispose();
            formLayout.FrmLayout_Load(null, null); 
        }

        private void button60_Click(object sender, EventArgs e)
        {
            FrmLayout formchuyen = new FrmLayout(StaticClass.cashierId);
            formchuyen.isTransfer = true;
            formchuyen.formBanHang = this;
            formchuyen.ShowDialog();
        }
        public void transfer(string newTableName,string sectionID)
        {
            getGui.UpdateTransfer(StaticClass.storeId,invoiceNum,newTableName,sectionID);
            tableName = newTableName;
            myCash1.Label_Ban.Text = tableName;
        }
    }
}
