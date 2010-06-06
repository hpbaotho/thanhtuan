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
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmSelectKitchenNote : Form
    {
        private Service.ServiceGet serviceGet;
        public string Value;
        public FrmSelectKitchenNote()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
            Value = "";
        }
        public FrmSelectKitchenNote(string text)
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
            Value = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmSelectKitchenNote_Load(object sender, EventArgs e)
        {
            ArrayList arrayList = serviceGet.GetReasonCode(StaticClass.storeId, ReasonCode.KitchenNote);
            foreach (var o in arrayList)
            {
                listBox1.Items.Add(o);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count <= 0)
            {
                this.Dispose();
            }
            for (int i = 0; i < listBox1.SelectedItems.Count - 1 ; i++)
            {
                Value += ((ReasonCode) listBox1.SelectedItems[i]).Code + "-";   
            }
            Value += ((ReasonCode)listBox1.SelectedItems[listBox1.SelectedItems.Count-1]).Code;
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard(Value);
            if(frmKeyBoard.ShowDialog() == DialogResult.OK)
            {
                if(frmKeyBoard.value != "")
                {
                    Value = frmKeyBoard.value;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.Dispose();
                }
          
            }
        }
    }
}
