using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Controls;

namespace WindowsFormsApplication4.Controls
{
    public partial class panel : Panel
    {
        private Color color1;
        private Color color2;
        public ArrayList mangMyButton = new ArrayList();
        public Panel panelEditSection = new Panel();
        public Panel panelEditButton = new Panel();
        public ColorBar colorBar1;
        public ColorBar colorBar2;
        public ColorBar colorBar3 = new ColorBar();
        public TextBox txtSection = new TextBox();
        public Label txtTableName = new Label();
        public bool isNew = false;
        public bool isDelete = false;
        public MyButton selectedButton;

        public panel()
        {
            this.Size = new Size(1022, 660);
            this.Location = new Point(1, 54);

            //MyButton a = new MyButton();
            //a.Text = "asdasd";
            //a.Location = new Point(20,30);
            //a.Size = new Size(50,50);
            //this.Controls.Add(a);
            //mangMyButton.Add(a);
            color1 = Color.White;
            color2 = Color.HotPink;
        }

        public panel(string sectionName)
        {

            panelEditButton.BackColor = SystemColors.ControlDarkDark;
            panelEditSection.BackColor = SystemColors.ControlDarkDark;

            this.Text = sectionName;

            this.Size = new Size(1022,660);
            this.Location = new Point(1,54);

            //MyButton a = new MyButton();
            //a.Text = "asdasd";
            //a.Location = new Point(20,30);
            //a.Size = new Size(50,50);
            //this.Controls.Add(a);
            //mangMyButton.Add(a);
            color1 = Color.White;
            color2 = Color.HotPink;

            colorBar1 = new ColorBar(color1);
            colorBar2 = new ColorBar(color2);

            panelEditButton.Location = new Point(4, 570);
            panelEditButton.Size = new Size(604, 81);
            panelEditButton.Visible = false;
            txtTableName.Location = new Point(9, 49);
            txtTableName.Size = new Size(159, 20);
            txtTableName.ForeColor = System.Drawing.Color.White;
            panelEditButton.Controls.Add(txtTableName);
            this.Controls.Add(panelEditButton);

            panelEditSection.Location = new Point(4, 570);
            panelEditSection.Size = new Size(604, 81);
            panelEditSection.Visible = false;
            colorBar1.Location = new Point(185, 49);
            colorBar1.Size = new Size(121, 23);
            colorBar1.BackColorChanged += new EventHandler(colorBar1_BackColorChanged);
            panelEditSection.Controls.Add(colorBar1);

            colorBar2.Location = new Point(333, 49);
            colorBar2.Size = new Size(121, 23);
            colorBar2.BackColorChanged += new EventHandler(colorBar2_BackColorChanged);
            panelEditSection.Controls.Add(colorBar2);

            colorBar3.Location = new Point(481, 49);
            colorBar3.Size = new Size(121, 23);
            panelEditSection.Controls.Add(colorBar3);

            txtSection.Location = new Point(9, 49);
            txtSection.Size = new Size(159, 20);
            panelEditSection.Controls.Add(txtSection);

            txtSection.Text = this.Text;
            this.Controls.Add(panelEditSection);
        }
        public panel(ArrayList x,String sectionName,Color tmpcolor1,Color tmpcolor2)
        {
            panelEditButton.BackColor = SystemColors.ControlDarkDark;
            panelEditSection.BackColor = SystemColors.ControlDarkDark;

            this.Text = sectionName;
            mangMyButton = x;

            this.Size = new Size(1022, 660);
            this.Location = new Point(1, 54);

            foreach (MyButton myButton in mangMyButton)
            {
                myButton.Click += new EventHandler(myButton_Click);
                this.Controls.Add(myButton);
            }

            color1 = tmpcolor1;
            color2 = tmpcolor2;

            colorBar1 = new ColorBar(color1);
            colorBar2 = new ColorBar(color2);

            panelEditButton.Location = new Point(4,570);
            panelEditButton.Size = new Size(604,81);
            panelEditButton.Visible = false;
            txtTableName.Location = new Point(9, 49);
            txtTableName.Size = new Size(159, 20);
            txtTableName.ForeColor = System.Drawing.Color.White;
            panelEditButton.Controls.Add(txtTableName);
            this.Controls.Add(panelEditButton);

            panelEditSection.Location = new Point(4, 570);
            panelEditSection.Size = new Size(604, 81);
            panelEditSection.Visible = false;
            colorBar1.Location = new Point(185,49);
            colorBar1.Size = new Size(121,23);
            colorBar1.BackColorChanged += new EventHandler(colorBar1_BackColorChanged);
            panelEditSection.Controls.Add(colorBar1);
            
            colorBar2.Location = new Point(333,49);
            colorBar2.Size = new Size(121,23);
            colorBar2.BackColorChanged += new EventHandler(colorBar2_BackColorChanged);
            panelEditSection.Controls.Add(colorBar2);

            colorBar3.Location = new Point(481, 49);
            colorBar3.Size = new Size(121, 23);
            panelEditSection.Controls.Add(colorBar3);

            txtSection.Location = new Point(9,49);
            txtSection.Size = new Size(159,20);
            panelEditSection.Controls.Add(txtSection);

            txtSection.Text = this.Text;
            this.Controls.Add(panelEditSection);

        }

        void colorBar3_BackColorChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void addButton(MyButton a)
        {
            a.Click += new EventHandler(myButton_Click);
            this.Controls.Add(a);
            mangMyButton.Add(a);
        }


        void colorBar2_BackColorChanged(object sender, EventArgs e)
        {
            this.ChangeColor2(colorBar2.color_prop);
        }

        void myButton_Click(object sender, EventArgs e)
        {
            panelEditButton.Visible = true;
            panelEditButton.BringToFront();
            txtTableName.Text = ((MyButton) sender).Text_pro;
            selectedButton = (MyButton) sender;
            ((MyButton) sender).BringToFront();
        }

        void colorBar1_BackColorChanged(object sender, EventArgs e)
        {
            this.ChangeColor1(colorBar1.color_prop);
        }


        public void ChangeColor(Color colorChange1,Color colorChange2 )
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
                Point[] border = new Point[]{new Point(ClientRectangle.X,ClientRectangle.Y),new Point(ClientRectangle.Right,ClientRectangle.Top),new Point(ClientRectangle.Right,ClientRectangle.Bottom),new Point(ClientRectangle.Left,ClientRectangle.Bottom),new Point(ClientRectangle.X,ClientRectangle.Y), };
                grp.DrawLines(new Pen(Color.Black,2),border );
                
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e) { }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Focus();
            panelEditSection.Visible = true;
            panelEditSection.BringToFront();
            selectedButton = null;
        }
       
    }
}
