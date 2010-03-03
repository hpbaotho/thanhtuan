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
    public partial class FrmSetupTSButton : Form
    {
        private Service.ServiceGet serviceGet;
        private ArrayList ListTSButtonDept;
        public FrmSetupTSButton()
        {
            InitializeComponent();
            serviceGet = new ServiceGet();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmSetupTSButton_Load(object sender, EventArgs e)
        {
            ListTSButtonDept = serviceGet.GetTSButtonDept(StaticClass.storeId);
            for (int i = 0; i < ListTSButtonDept.Count; i++)
            {
                var TsButDept = (TSButtonDept) ListTSButtonDept[i];
                creListBox1.Items.Add(TsButDept);
            }
            if(creListBox1.Items.Count > 0)
            {
                creListBox1.SelectedIndex = 0;
            }
        }

        private void creListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(creListBox1.SelectedItem != null)
            {
                creListBox2.Items.Clear();
                ArrayList TSButtonInvent = ((TSButtonDept) creListBox1.SelectedItem).TSButtonInvent;
                for (int i = 0; i < TSButtonInvent.Count; i++)
                {
                    var tsButton = (TSButton) TSButtonInvent[i];
                    creListBox2.Items.Add(tsButton);
                }
                if(creListBox2.Items.Count > 0)
                {
                    creListBox2.SelectedIndex = 0;
                }
                button1.Text = ((TSButtonDept) creListBox1.SelectedItem).Caption;
                button1.Color2 = Color.FromArgb(((TSButtonDept) creListBox1.SelectedItem).BackColor);
                button1.ForeColor = Color.FromArgb(((TSButtonDept)creListBox1.SelectedItem).ForeColor);
                creCheckBox1.Checked = ((TSButtonDept) creListBox1.SelectedItem).Visible;
            }
            this.Refresh();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(creListBox1.SelectedIndex > 0)
            {
                TSButtonDept tmp = (TSButtonDept)creListBox1.SelectedItem;
                int selectIndex = creListBox1.SelectedIndex;
                creListBox1.ClearSelected();
                creListBox1.Items.RemoveAt(selectIndex);
                creListBox1.Items.Insert(selectIndex-1,tmp);
                creListBox1.SelectedIndex = selectIndex - 1;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (creListBox1.SelectedIndex < creListBox1.Items.Count - 1 )
            {
                TSButtonDept tmp = (TSButtonDept)creListBox1.SelectedItem;
                int selectIndex = creListBox1.SelectedIndex;
                creListBox1.ClearSelected();
                creListBox1.Items.RemoveAt(selectIndex);
                creListBox1.Items.Insert(selectIndex + 1, tmp);
                creListBox1.SelectedIndex = selectIndex + 1;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(creListBox2.Items.Count > 0 && creListBox2.SelectedIndex > 0)
            {
                TSButton tmp = (TSButton) creListBox2.SelectedItem;
                int selectIndex = creListBox2.SelectedIndex;
                creListBox2.ClearSelected();
                creListBox2.Items.RemoveAt(selectIndex);
                creListBox2.Items.Insert(selectIndex - 1, tmp);
                creListBox2.SelectedIndex = selectIndex - 1;

                ArrayList list =  ((TSButtonDept) creListBox1.SelectedItem).TSButtonInvent;
                list.RemoveAt(selectIndex);
                list.Insert(selectIndex -1,tmp);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (creListBox2.Items.Count > 0 && creListBox2.SelectedIndex < creListBox2.Items.Count - 1)
            {
                TSButton tmp = (TSButton)creListBox2.SelectedItem;
                int selectIndex = creListBox2.SelectedIndex;
                creListBox2.ClearSelected();
                creListBox2.Items.RemoveAt(selectIndex);
                creListBox2.Items.Insert(selectIndex + 1, tmp);
                creListBox2.SelectedIndex = selectIndex + 1;

                ArrayList list = ((TSButtonDept)creListBox1.SelectedItem).TSButtonInvent;
                list.RemoveAt(selectIndex);
                list.Insert(selectIndex + 1, tmp);
            }
        }

        private void creListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (creListBox2.SelectedItem != null)
            {
                button6.Text = ((TSButton)creListBox2.SelectedItem).Caption;
                button6.Color2 = Color.FromArgb(((TSButton)creListBox2.SelectedItem).BackColor);
                button6.ForeColor = Color.FromArgb(((TSButton)creListBox2.SelectedItem).ForeColor);
                creCheckBox2.Checked = ((TSButton) creListBox2.SelectedItem).Visible;
            }
            this.Refresh();
        }

        private void creCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(creListBox1.SelectedItem != null)
            {
                ((TSButtonDept) creListBox1.SelectedItem).Visible = creCheckBox1.Checked;
            }
        }

        private void creCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (creListBox2.SelectedItem != null)
            {
                ((TSButton)creListBox2.SelectedItem).Visible = creCheckBox2.Checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                button1.Color2 = colorDialog.Color;
                ((TSButtonDept) creListBox1.SelectedItem).BackColor = colorDialog.Color.ToArgb();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                button1.ForeColor = colorDialog.Color;
                ((TSButtonDept)creListBox1.SelectedItem).ForeColor = colorDialog.Color.ToArgb();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(creListBox2.SelectedItem != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() != DialogResult.Cancel)
                {
                    button6.Color2 = colorDialog.Color;
                    ((TSButton)creListBox2.SelectedItem).BackColor = colorDialog.Color.ToArgb();
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (creListBox2.SelectedItem != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() != DialogResult.Cancel)
                {
                    button6.ForeColor = colorDialog.Color;
                    ((TSButton)creListBox2.SelectedItem).ForeColor = colorDialog.Color.ToArgb();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < creListBox1.Items.Count; i++)
            {
                var tsButDept = (TSButtonDept) creListBox1.Items[i];
                tsButDept.Index = i;
                serviceGet.getGui.UpdateTSButton(StaticClass.storeId,tsButDept.Ident,tsButDept.Index.ToString(),tsButDept.Caption,
                    tsButDept.Picture,tsButDept.BackColor.ToString(),tsButDept.ForeColor.ToString(),tsButDept.Visible.ToString());
                for (int j = 0; j < tsButDept.TSButtonInvent.Count; j++)
                {
                    var tsButInvent = (TSButton) tsButDept.TSButtonInvent[j];
                    tsButInvent.Index = j;
                    serviceGet.getGui.UpdateTSButton(StaticClass.storeId, tsButInvent.Ident, tsButInvent.Index.ToString(), tsButInvent.Caption,
                    tsButInvent.Picture, tsButInvent.BackColor.ToString(), tsButInvent.ForeColor.ToString(), tsButInvent.Visible.ToString());
                }

            }
            this.Dispose();
        }

    }
}
