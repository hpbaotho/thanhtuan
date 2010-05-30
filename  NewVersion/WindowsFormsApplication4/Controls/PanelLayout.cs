using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4.Controls
{
    public partial class PanelLayout : Panel
    {
        private Color color1;
        private Color color2;
        public ArrayList mangButton = new ArrayList();
        private FrmBanHang banhang;
        private Service.ServiceGet service = new ServiceGet();
        private get_GUI getGui = new get_GUI();
        private bool isTransfer = false;

        public PanelLayout()
        {
            this.Size = new Size(1022, 660);
            this.Location = new Point(1, 54);

            button a = new button();
            a.Text = "asdasd";
            a.Location = new Point(20, 30);
            a.Size = new Size(50, 50);
            this.Controls.Add(a);
            mangButton.Add(a);
            color1 = Color.White;
            color2 = Color.HotPink;
        }
        public PanelLayout(string sectionName)
        {
            this.Size = new Size(1022, 660);
            this.Location = new Point(1, 54);
            color1 = Color.White;
            color2 = Color.HotPink;
            this.Text = sectionName;
        }

        public PanelLayout(string sectionName,ArrayList buttons,Color tmpColor1,Color tmpColor2,bool isTransfer)
        {
            this.isTransfer = isTransfer;
            mangButton = buttons;
            this.Size = new Size(1022, 660);
            this.Location = new Point(1, 54);
            color1 = tmpColor1;
            color2 = tmpColor2;
            this.Text = sectionName;
            foreach (TransButton o in mangButton)
            {
                o.Click += new EventHandler(o_Click);
                this.Controls.Add(o);
            }
           
            if(isTransfer)
            {
                Label info = new Label();
                info.BackColor = Color.Red;
                info.ForeColor = Color.White;
                info.Location = new Point(1,630);
                info.Size = new Size(300, 25);
                info.Font = new Font("Arial",15);
                info.Text = "Hãy chọn bàn muốn chuyển";
                this.Controls.Add(info);
            }
            this.Invalidate();
        }
        public PanelLayout(ArrayList buttons,string sectionName)
        {
            this.Size = new Size(1022, 660);
            this.Location = new Point(1, 54);
            color1 = Color.White;
            color2 = Color.HotPink;
            this.Text = sectionName;
            mangButton = buttons;
            foreach (TransButton o in mangButton)
            {
                o.Click += new EventHandler(o_Click);
                this.Controls.Add(o);
            }
            this.Invalidate();
        }

        /////////////////////////////////////////////////////////////////
        public void Reload(string sectionName, ArrayList buttons, bool isTransfer)
        {
            foreach (Control o in this.Controls)
            {
                o.Dispose();
            }
            this.Controls.Clear();
            this.isTransfer = isTransfer;
            mangButton = buttons;
            this.Size = new Size(1022, 660);
            this.Location = new Point(1, 54);
            //color1 = tmpColor1;
            //color2 = tmpColor2;
            this.Text = sectionName;
            foreach (TransButton o in mangButton)
            {
                o.Click += new EventHandler(o_Click);
                this.Controls.Add(o);
            }
            if (isTransfer)
            {
                Label info = new Label();
                info.BackColor = Color.Red;
                info.ForeColor = Color.White;
                info.Location = new Point(1, 630);
                info.Size = new Size(300, 25);
                info.Font = new Font("Arial", 15);
                info.Text = "Hãy chọn bàn muốn chuyển";
                this.Controls.Add(info);
            }
            this.Invalidate();
        }
        /// /////////////////////////////////////////////////////////

        void o_Click(object sender, EventArgs e)
        {
            if (((TransButton)sender).BackColor == Color.Red)
            {
                if (!Employee.CheckGrant(StaticClass.storeId, StaticClass.cashierId, Employee.XEM_BAN_KHAC))
                {
                    return;
                }
            }
            if(isTransfer)
            {
                FrmDelete confirm = new FrmDelete();
                
                var formLayout = (FrmLayout)(((TransButton)sender).FindForm());
                
                    if (((TransButton)sender).invoiceNum != "")
                    {
                        confirm.label1.Text = "Bạn có thực sự muốn gộp với bàn " + ((TransButton)sender).tableName + " ?";
                        if (confirm.ShowDialog() == DialogResult.OK)
                        {
                            formLayout.formBanHang.combine(((TransButton)sender).tableName, this.Text, ((TransButton)sender).invoiceNum);
                            Alert.Show("Đã gộp sang bàn " + ((TransButton) sender).tableName);

                        }
                    }
                    else
                    {
                        confirm.label1.Text = "Bạn có thực sự muốn chuyển bàn " + ((TransButton)sender).tableName + " ?";
                        if (confirm.ShowDialog() == DialogResult.OK)
                        {
                            formLayout.formBanHang.transfer(((TransButton) sender).tableName,this.Text);
                            Alert.Show("Đã chuyển sang bàn :" + ((TransButton) sender).tableName);
                        }
                    }
                
                
                formLayout.Dispose();

            }
            else
            {
                 if (((TransButton)sender).cashierId != StaticClass.cashierId && ((TransButton)sender).cashierId != "")
                {
                    if(!Employee.CheckGrant(StaticClass.storeId,StaticClass.cashierId,Employee.XEM_BAN_KHAC))
                    {
                        return;
                    }
                }
                //banhang = new FrmBanHang();
                var tmpBut = (TransButton)sender;

                banhang = StaticClass.frmbanhangMain;
                banhang.Start();
                banhang.formLayout = (FrmLayout)((TransButton)sender).FindForm();
                if(tmpBut.invoiceNum == "")
                {
                    banhang.isOnHold = false;
                }
                else
                {
                    banhang.isOnHold = true;
                }
                DataTable InvoiceNumTab = getGui.OpenTable(StaticClass.storeId,this.Text,StaticClass.stationId,tmpBut.tableName,StaticClass.cashierId,StaticClass.custNum,DateTime.Now,"","","","","");
                string InvoiceNum = InvoiceNumTab.Rows[0][0].ToString();
                banhang.invoiceNum = InvoiceNum;
                banhang.tableName = tmpBut.tableName;
                banhang.formLogin.RequestMess("UpdateForm");
                banhang.LoadFrmBanHang();
                banhang.changeLayout(false, null);
                banhang.ShowDialog();
            }
           
            
        }
        public void ChangeColor(Color colorChange1, Color colorChange2)
        {
            color1 = colorChange1;
            color2 = colorChange2;
            Invalidate();
        }

        public void ChangeColor1(Color colorChange1)
        {
            color1 = colorChange1;
            Invalidate();
        }

        public void ChangeColor2(Color colorChange2)
        {
            color2 = colorChange2;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics grp = e.Graphics)
            {
                //vẽ bkgrnd
                //if (m_bIsMouseDown)
                //{
                LinearGradientBrush myBrush;
                myBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), color1, color2, LinearGradientMode.ForwardDiagonal);
                grp.FillRectangle(myBrush, 0, 0, Width, Height);
                Point[] border = new Point[] { new Point(ClientRectangle.X, ClientRectangle.Y), new Point(ClientRectangle.Right, ClientRectangle.Top), new Point(ClientRectangle.Right, ClientRectangle.Bottom), new Point(ClientRectangle.Left, ClientRectangle.Bottom), new Point(ClientRectangle.X, ClientRectangle.Y), };
                grp.DrawLines(new Pen(Color.Black, 2), border);

            }
        }
        protected override void OnPaintBackground(PaintEventArgs e) { }

    }
}
