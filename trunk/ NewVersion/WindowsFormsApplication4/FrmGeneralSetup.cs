using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Persistence;
using WindowsFormsApplication4.RPDatasets.RPDataset1TableAdapters;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmGeneralSetup : Form
    {
        public Service.ServiceGet serviceGet;
        public ArrayList ReasonCodeList;
        public FrmGeneralSetup()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
            ReasonCodeList = serviceGet.GetReasonCode(StaticClass.storeId,ReasonCode.KitchenNote );
        }

        private void FrmGeneralSetup_Load(object sender, EventArgs e)
        {
            foreach (var o in ReasonCodeList)
            {
                listBox1.Items.Add(o);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard("");
            if(frmKeyBoard.ShowDialog() == DialogResult.OK)
            {
                if(frmKeyBoard.value != "")
                {
                    foreach (var o in ReasonCodeList)
                    {
                        if(frmKeyBoard.value == o.ToString())
                        {
                            Alert.Show("Ghi chú đã có",Color.Red);
                            return;
                        }
                    }
                    ReasonCode reasonCode = new ReasonCode(frmKeyBoard.value,ReasonCode.KitchenNote);
                    reasonCode.isNew = true;
                    listBox1.Items.Add(reasonCode);
                    ReasonCodeList.Add(reasonCode);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count > 0)
            {
                ((ReasonCode) listBox1.SelectedItems[0]).isDelete = true;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RPDatasets.RPDataset1TableAdapters.Setup_Reason_CodesTableAdapter setup_Reason_CodesTableAdapter =
                new Setup_Reason_CodesTableAdapter {Connection = DAO.DataProvider.ConnectionData(StaticClass.RPServer)};

            foreach (ReasonCode o in ReasonCodeList)
            {
                if(o.isDelete&&!o.isNew)
                {
                    setup_Reason_CodesTableAdapter.Delete(StaticClass.storeId, o.Code, ReasonCode.KitchenNote);
                }
                else if(o.isNew&&!o.isDelete)
                { 
                    setup_Reason_CodesTableAdapter.InsertReasonCode(StaticClass.storeId, o.Code, ReasonCode.KitchenNote);
                }
            }
            this.Dispose();
        }
    }
}
