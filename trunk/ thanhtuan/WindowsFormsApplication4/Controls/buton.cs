using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;


namespace WindowsFormsApplication4.Controls
{
    public class button : Control, IControlPlus
    {

        #region ----------- Private members ----------

        //IControl Plus members
        private bool m_bUseOwnColor = false;
        private Color m_OwnDrawColor = Color.White;

        // Drawing members
        private readonly Pen m_pWhite = new Pen(Color.White, 2);
        private readonly Pen m_pBlack = new Pen(Color.Black, 2);
        private readonly Pen m_pW = new Pen(Color.Black, 2);
        private Brush m_bLight;
        private Brush m_bNormal;
        private Pen m_pBorder;
        private Brush m_bText;
        private Point[] m_arrBorder;
        private Point[] m_arrBorder1;
        private Point[] m_arrBorder2;
        private bool m_bIsMouseDown = false;

        private readonly StringFormat m_sFmt;

        private Color color1;
        private Color color2;

        public string Ident; //Dung cho button Inventory

        public bool focus = false;

        //Dung cho button table
        public string invoiceNum = "";


        #endregion

        #region -------- Constructor, handler --------

        public button()
        {

            color1 = Color.White;
            color2 = Color.Blue;
            
            m_arrBorder = new Point[6] { new Point(0, Height - 3), new Point(0, 2),new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3)  };
            m_arrBorder1 = new Point[6] {new Point(Width - 1, 2),new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3) };
            m_arrBorder2 = new Point[9] { new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3), new Point(0, 2), new Point(2, 0) };

            m_pWhite = new Pen(Color.White, 2);
            m_pBlack = new Pen(Color.Gray, 2);
            m_pW = new Pen(Color.White, 2);
            m_bLight = new SolidBrush(GetLightColor(ControlPlusData.DrawColor));
            m_bNormal = ControlPlusData.DrawBrush;
            m_pBorder = ControlPlusData.DrawPen;

            m_sFmt = new StringFormat();
            m_sFmt.Alignment = StringAlignment.Center;
            m_sFmt.LineAlignment = StringAlignment.Center;

            ControlPlusData.OnColorSchemeChangeEvent += this.OnColorSchemeChanged;
            
        }

        public button(int x, int y, int width, int height)
        {
            this.Size = new Size(width, height);
            this.Location = new Point(x, y);
            color1 = Color.White;
            color2 = Color.Blue;

            m_arrBorder = new Point[6] { new Point(0, Height - 3), new Point(0, 2),new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3)  };
            m_arrBorder1 = new Point[6] {new Point(Width - 1, 2),new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3) };
            m_arrBorder2 = new Point[9] { new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3), new Point(0, 2), new Point(2, 0) };

            m_pWhite = new Pen(Color.White, 2);
            m_pBlack = new Pen(Color.Gray, 2);
            m_pW = new Pen(Color.White, 2);
            m_bLight = new SolidBrush(GetLightColor(ControlPlusData.DrawColor));
            m_bNormal = ControlPlusData.DrawBrush;
            m_pBorder = ControlPlusData.DrawPen;

            m_sFmt = new StringFormat();
            m_sFmt.Alignment = StringAlignment.Center;
            m_sFmt.LineAlignment = StringAlignment.Center;

            ControlPlusData.OnColorSchemeChangeEvent += this.OnColorSchemeChanged;

        }

        public button(Color colorChange1,Color colorChange2)
        {

            color1 = colorChange1;
            color2 = colorChange2;

            m_arrBorder = new Point[6] { new Point(0, Height - 3), new Point(0, 2),new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3)  };
            m_arrBorder1 = new Point[6] {new Point(Width - 1, 2),new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3) };
            m_arrBorder2 = new Point[9] { new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3), new Point(0, 2), new Point(2, 0) };

            m_pWhite = new Pen(Color.White, 3);
            m_pBlack = new Pen(Color.Gray, 3);
            m_pW = new Pen(Color.White, 3);
            m_bLight = new SolidBrush(GetLightColor(ControlPlusData.DrawColor));
            m_bNormal = ControlPlusData.DrawBrush;
            m_pBorder = ControlPlusData.DrawPen;

            m_sFmt = new StringFormat();
            m_sFmt.Alignment = StringAlignment.Center;
            m_sFmt.LineAlignment = StringAlignment.Center;

            ControlPlusData.OnColorSchemeChangeEvent += this.OnColorSchemeChanged;

        }

        private static Color GetLightColor(Color c)
        {
            if (c.IsEmpty)
                return Color.White;
            else
                return Color.FromArgb(c.R / 2 + 128, c.G / 2 + 128, c.B / 2 + 128);
        }

        private void OnColorSchemeChanged()
        {
            m_bLight = new SolidBrush(GetLightColor(ControlPlusData.DrawColor));
            m_bNormal = ControlPlusData.DrawBrush;
            m_pBorder = ControlPlusData.DrawPen;
        }

        #endregion

        #region ----------- Override voids -----------

        protected override void OnPaint(PaintEventArgs e)
        {
            //int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //int newX = this.Location.X * screenWidth / 1024;
            //int newY = this.Location.Y * screenHeight / 768;
            //int newWidth = this.ClientRectangle.Width * screenWidth / 1024;
            //int newHeight = this.ClientRectangle.Height * screenHeight / 768;



            //this.Location = new Point(newX, newY);
            //this.Size = new Size(newWidth, newHeight);
            using (Graphics grp = e.Graphics)
            {
                //vẽ bkgrnd
                //if (m_bIsMouseDown)
                //{
                LinearGradientBrush myBrush;
                myBrush = new LinearGradientBrush(new Rectangle(0,0,Width,Height), color1, color2,LinearGradientMode.ForwardDiagonal );
                    grp.FillRectangle(myBrush, 0, 0, Width, Height);
                //}
                //else
                //{
                //    int iHalf = Height / 2;

                //    grp.FillRectangle(m_bLight, 0, 0, Width, iHalf);
                //    grp.FillRectangle(m_bNormal, 0, iHalf, Width, iHalf);
                //}

                //vẽ border
                grp.DrawLines(m_pW, m_arrBorder2);
                grp.DrawLines(m_pWhite, m_arrBorder);
                grp.DrawLines(m_pBlack, m_arrBorder1);
                //grp.DrawLines(m_pBorder, m_arrBorder);

                if (Enabled)
                    m_bText = new SolidBrush(ForeColor);
                else
                    m_bText = new SolidBrush(Color.Gray);

                grp.DrawString(Text, Font, m_bText, ClientRectangle, m_sFmt);
                m_bText.Dispose();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e) { }

        protected override void OnResize(EventArgs e)
        {
            //m_arrBorder = new Point[9] { new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
            //    new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), 
            //    new Point(0, Height - 3), new Point(0, 2), new Point(2, 0) };
            m_arrBorder = new Point[6] { new Point(0, Height - 3), new Point(0, 2),new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3)  };
            m_arrBorder1 = new Point[6] {new Point(Width - 1, 2),new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3) };
            m_arrBorder2 = new Point[9] { new Point(2, 0), new Point(Width - 3, 0), new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3), new Point(Width - 3, Height - 1), new Point(2, Height - 1), 
                new Point(0, Height - 3), new Point(0, 2), new Point(2, 0) };
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            m_bIsMouseDown = true;
            m_pWhite.Color = Color.Gray;
            m_pBlack.Color = Color.White;
            
            Invalidate();

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(!this.IsDisposed)
            {
                m_bIsMouseDown = false;
                m_pWhite.Color = Color.White;
                m_pBlack.Color = Color.Gray;

                Invalidate();
            }
            base.OnMouseUp(e);
        }

        //protected override void OnGotFocus(EventArgs e)
        //{
        //    if (focus)
        //    {
        //        color2 = Color.Red;
        //    }
        //    Invalidate();

        //    base.OnGotFocus(e);
        //}

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    if (focus)
        //    {
        //        color2 = Color.Blue;
        //    }

        //    Invalidate();

        //    base.OnLostFocus(e);
        //}

        public void changeColor(Color colorChange1,Color colorChange2)
        {
            color1 = colorChange1;
            color2 = colorChange2;
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (m_pWhite != null)
                m_pWhite.Dispose();
            if (m_bLight != null)
                m_bLight.Dispose();
            if (m_bText != null)
                m_bText.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Left:
                    Parent.SelectNextControl(this, false, true, true, true);
                    break;
                case Keys.Down:
                case Keys.Right:
                    Parent.SelectNextControl(this, true, true, true, true);
                    break;
                case Keys.Enter:
                    OnClick(new EventArgs());
                    break;
            }
        }

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                Invalidate();
            }
        }

        #endregion

        #region ----- IControlPlus implemetation -----

        public Color OwnDrawColor
        {
            get { return m_OwnDrawColor; }
            set { m_OwnDrawColor = value; }
        }

        public bool UseOwnColor
        {
            get { return m_bUseOwnColor; }
            set { m_bUseOwnColor = value; }
        }

        #endregion

    }
}