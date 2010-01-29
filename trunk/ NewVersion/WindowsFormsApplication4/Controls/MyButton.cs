using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Controls
{
    public partial class MyButton : Control
    {
        public enum ButtonStyles
        {
            Rectangle,
            Ellipse
        }

        public enum GradientStyles
        {
            Horizontal,
            Vertical,
            ForwardDiagonal,
            BackwardDiagonal
        }
        private const int resize_rec = 8;
        private bool check_contain;
        private int left;
        private int top;
        private int right;
        private int bottom;
        private bool focus;
        private bool pDragging;
        private Point pMousePosition;
        private string text = "";
        private GradientStyles _GradientStyle = GradientStyles.Vertical;
        private Color _NormalColorA = Color.Blue;
        private Color _NormalColorB = Color.Blue;
        private ButtonStyles _ButtonStyle;
        private Color _NormalBorderColor = Color.Red;
        //private int _width = this.Width;
        //private int _height = this.Height;
        //private int _Xpos = this.Location.X;
        //private int _Ypos = this.Location.Y;
        private static int WM_NCPAINT = 0x0085;
        private static int WM_ERASEBKGND = 0x0014;
        private static int WM_PAINT = 0x000F;

        public bool isNew = false;
        public bool isDelete = false;
        public Color borColor = Color.Gray;

        public ButtonStyles ButtonStyle
        {
            get
            {
                return _ButtonStyle;
            }
            set
            {
                _ButtonStyle = value;
                Invalidate();
            }
        }
        public bool Forcus_prop
        {
            get
            {
                return focus;
            }
            set
            {
                focus = value;
                Invalidate();
            }
        }
        public string Text_pro
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                Invalidate();
            }
        }

        public GradientStyles GradientStyle
        {
            get
            {
                return _GradientStyle;
            }
            set
            {
                _GradientStyle = value;
                this.Invalidate();
            }

        }

        public Color NormalBorderColor
        {
            get
            {
                return _NormalBorderColor;
            }
            set
            {
                _NormalBorderColor = value;
                this.Invalidate();
            }

        }
        public Color NormalColorA
        {
            set
            {
                _NormalColorA = value;

            }
        }
        public Color NormalColorB
        {
            set
            {
                _NormalColorB = value;
                Invalidate();
            }
        }
        //public int Width
        //{
        //    get
        //    {
        //        return _width;
        //    }
        //    set
        //    {
        //        _width = value;
        //    }
        //}

        //private int Height
        //{
        //    get
        //    {
        //        return _height;
        //    }
        //    set
        //    {
        //        _height = value;
        //    }
        //}

        //private int Xpos
        //{
        //    get
        //    {
        //        return _Xpos;
        //    }
        //    set
        //    {
        //        _Xpos = value;
        //    }
        //}
        //private int Ypos
        //{
        //    get
        //    {
        //        return _Ypos;
        //    }
        //    set
        //    {
        //        _Ypos = value;
        //    }
        //}
        public MyButton()
        {
            // InitializeComponent();
            check_contain = false;
            focus = false;
            pDragging = false;
            pMousePosition = Point.Empty;
            _ButtonStyle = ButtonStyles.Rectangle;

            //this.SetStyle(
            //ControlStyles.SupportsTransparentBackColor |
            //ControlStyles.OptimizedDoubleBuffer |
            //ControlStyles.AllPaintingInWmPaint |
            //ControlStyles.ResizeRedraw |
            //ControlStyles.UserPaint, true);
            //this.BackColor = Color.Transparent;
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);
            //this.BackColor = Color.Transparent;
            //this.BackColor = Color.Transparent;
        }
        public MyButton(int x,int y, int width, int height)
        {
            // InitializeComponent();
            this.Size = new Size(width,height);
            this.Location = new Point(x,y);

            check_contain = false;
            focus = false;
            pDragging = false;
            pMousePosition = Point.Empty;
            _ButtonStyle = ButtonStyles.Rectangle;

            //this.SetStyle(
            //ControlStyles.SupportsTransparentBackColor |
            //ControlStyles.OptimizedDoubleBuffer |
            //ControlStyles.AllPaintingInWmPaint |
            //ControlStyles.ResizeRedraw |
            //ControlStyles.UserPaint, true);
            //this.BackColor = Color.Transparent;
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);
            //this.BackColor = Color.Transparent;
            //this.BackColor = Color.Transparent;
        }

        public MyButton(int x, int y, int width, int height,ButtonStyles style)
        {
            // InitializeComponent();
            this.Size = new Size(width, height);
            this.Location = new Point(x, y);

            check_contain = false;
            focus = false;
            pDragging = false;
            pMousePosition = Point.Empty;
            _ButtonStyle = style;

            //this.SetStyle(
            //ControlStyles.SupportsTransparentBackColor |
            //ControlStyles.OptimizedDoubleBuffer |
            //ControlStyles.AllPaintingInWmPaint |
            //ControlStyles.ResizeRedraw |
            //ControlStyles.UserPaint, true);
            //this.BackColor = Color.Transparent;
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);
            //this.BackColor = Color.Transparent;
            //this.BackColor = Color.Transparent;
        }

        private float resize_yPos(int x, int height, int width)
        {
            float result;

            double w = Convert.ToDouble(x) / Convert.ToDouble(width);


            result = (float)(height * Math.Sqrt(1 - w * w));
            return result;
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            LinearGradientBrush brush;
            LinearGradientMode mode;
            switch (_GradientStyle)
            {
                case GradientStyles.Horizontal:
                    mode = LinearGradientMode.Horizontal;
                    break;
                case GradientStyles.Vertical:
                    mode = LinearGradientMode.Vertical;
                    break;
                case GradientStyles.ForwardDiagonal:
                    mode = LinearGradientMode.ForwardDiagonal;
                    break;
                case GradientStyles.BackwardDiagonal:
                    mode = LinearGradientMode.BackwardDiagonal;
                    break;
                default:
                    mode = LinearGradientMode.Vertical;
                    break;
            }

            SizeF textSize = pe.Graphics.MeasureString(text, base.Font);
            int textX = (int)(this.Size.Width / 2) - (int)(textSize.Width / 2);
            int textY = (int)(this.Size.Height / 2) - (int)(textSize.Height / 2);
            Graphics grp = this.CreateGraphics();
            Rectangle rec = ClientRectangle;
            Rectangle newRect = new Rectangle(ClientRectangle.X + 1, ClientRectangle.Y + 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3);
            //int ix = rec.Width/3;
            //int iy = rec.Height/3;
            //int left = rec.Left;
            //int top = rec.Top;
            //int bottom = rec.Bottom;
            //int right = rec.Right;
            //Point[] points1 = {new Point(left,top),new Point(ix+left,top),new Point(left,iy+top),new Point(left,top)};
            //grp.FillPolygon(new SolidBrush(Color.Orange), points1);
            //Point[] points2 = { new Point(ix + left, top), new Point(ix * 2 + left, top), new Point(left, iy * 2 + top), new Point(left, iy + top)};
            //grp.FillPolygon(new SolidBrush(Color.DimGray),points2);
            //Point[] points3={new Point(ix * 2 + left, top),new Point(right,top),new Point(left,bottom),new Point(left, iy * 2 + top)   };
            //grp.FillPolygon(new SolidBrush(Color.Red),points3);


            //Point[] points4 = { new Point(right, bottom), new Point(right - ix, bottom), new Point(right, bottom-iy), new Point(right, bottom) };
            //grp.FillPolygon(new SolidBrush(Color.DodgerBlue), points4);
            //Point[] points5 = { new Point(right-ix, bottom), new Point(right-ix * 2 , bottom), new Point(right, bottom-iy * 2 ), new Point(right, bottom-iy) };
            //grp.FillPolygon(new SolidBrush(Color.DarkViolet), points5);
            //Point[] points6 = { new Point(right-ix * 2 , bottom), new Point(left, bottom), new Point(right, top), new Point(right, bottom-iy * 2 ) };
            brush = new LinearGradientBrush(newRect, _NormalColorA, _NormalColorB, mode);
            LinearGradientBrush myBrush1;
            Brush myBrush;
            myBrush = new SolidBrush(Color.FromArgb(0, 128, 0));
            switch (_ButtonStyle)
            {
                case ButtonStyles.Rectangle:
                    //grp.FillRectangle(brush, newRect);
                    myBrush1 = new LinearGradientBrush(new Rectangle(ClientRectangle.Right - 4, ClientRectangle.Top, 4, Height), Color.FromArgb(0, 133, 0), Color.FromArgb(0, 55, 0), LinearGradientMode.Vertical);



                    grp.FillRectangle(myBrush, ClientRectangle.X, ClientRectangle.Y, Width - 4, Height - 4);
                    grp.FillRectangle(myBrush1, ClientRectangle.Right - 4, ClientRectangle.Top, 4, Height);
                    myBrush1 = new LinearGradientBrush(new Rectangle(ClientRectangle.Left, ClientRectangle.Bottom - 4, Width, 4), Color.FromArgb(0, 133, 0), Color.FromArgb(0, 55, 0), LinearGradientMode.Horizontal);
                    grp.FillRectangle(myBrush1, ClientRectangle.Left, ClientRectangle.Bottom - 4, Width, 4);
                    grp.DrawLine(new Pen(Color.LightBlue, (float)0.1), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Right, ClientRectangle.Y);
                    grp.DrawLine(new Pen(Color.LightBlue, (float)0.1), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.X, ClientRectangle.Bottom);
                    if (focus)
                    {
                        grp.DrawRectangle(new Pen(_NormalBorderColor, 5), rec);
                        Rectangle newrec = new Rectangle(ClientRectangle.Right - resize_rec, ClientRectangle.Bottom - resize_rec, resize_rec, resize_rec);
                        grp.FillRectangle(Brushes.White, newrec);
                        grp.DrawRectangle(new Pen(Color.Black, 2), newrec);
                    }


                    break;

                case ButtonStyles.Ellipse:
                    //grp.FillEllipse(brush, newRect);
                    myBrush1 = new LinearGradientBrush(new Rectangle(ClientRectangle.X, ClientRectangle.Y, Width, Height), Color.FromArgb(0, 133, 0), Color.FromArgb(0, 55, 0), LinearGradientMode.ForwardDiagonal);


                    grp.FillEllipse(myBrush1, ClientRectangle.X, ClientRectangle.Y, Width, Height);
                    grp.FillEllipse(myBrush, ClientRectangle.X, ClientRectangle.Y, Width - 4, Height - 4);
                    if (focus)
                    {
                        grp.DrawEllipse(new Pen(_NormalBorderColor, 3), newRect);
                        int x = ClientRectangle.Width / 4;
                        int y = Convert.ToInt32(resize_yPos(x, Height / 2, Width / 2));
                        Point p = new Point(x + ClientRectangle.Width / 2 - resize_rec, y + ClientRectangle.Height / 2 - resize_rec);
                        Rectangle newrec = new Rectangle(p, new Size(resize_rec, resize_rec));
                        grp.FillRectangle(Brushes.White, newrec);
                        grp.DrawRectangle(new Pen(Color.Black, 2), newrec);
                    }

                    break;

            }
            //grp.FillRectangle(new SolidBrush(Color.Red), rec);
            //if(focus)
            //    grp.DrawRectangle(new Pen(Color.Yellow,5),rec);
            grp.DrawString(text, base.Font, new SolidBrush(Color.Black), textX, textY);
            base.OnPaint(pe);

        }



        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            Rectangle rec = Rectangle.Empty;
            switch (_ButtonStyle)
            {
                case ButtonStyles.Rectangle:
                    rec = new Rectangle(ClientRectangle.Right - resize_rec, ClientRectangle.Bottom - resize_rec, resize_rec, resize_rec);
                    break;
                case ButtonStyles.Ellipse:
                    int x = ClientRectangle.Width / 4;
                    int y = Convert.ToInt32(resize_yPos(x, Height / 2, Width / 2));
                    Point p = new Point(x + ClientRectangle.Width / 2 - resize_rec, y + ClientRectangle.Height / 2 - resize_rec);
                    rec = new Rectangle(p, new Size(resize_rec, resize_rec));
                    break;
            }
            if (focus)
            {
                if (rec.Contains(e.Location))
                {
                    check_contain = true;

                }
                else
                {
                    if (ClientRectangle.Contains(e.Location))
                    {
                        pMousePosition = PointToClient(Control.MousePosition);
                        pDragging = true;
                    }
                }

                base.OnMouseDown(e);
            }

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {


            Rectangle rec = Rectangle.Empty;
            switch (_ButtonStyle)
            {
                case ButtonStyles.Rectangle:
                    rec = new Rectangle(ClientRectangle.Right - resize_rec, ClientRectangle.Bottom - resize_rec, resize_rec, resize_rec);
                    break;
                case ButtonStyles.Ellipse:
                    int x = ClientRectangle.Width / 4;
                    int y = Convert.ToInt32(resize_yPos(x, Height / 2, Width / 2));
                    Point p = new Point(x + ClientRectangle.Width / 2 - resize_rec, y + ClientRectangle.Height / 2 - resize_rec);
                    rec = new Rectangle(p, new Size(resize_rec, resize_rec));
                    break;
            }
            if (focus)
            {
                //Rectangle rec = new Rectangle(ClientRectangle.Right - resize_rec, ClientRectangle.Bottom - resize_rec, resize_rec, resize_rec);
                if (rec.Contains(e.Location))
                {
                    this.Cursor = Cursors.SizeNWSE;

                }
                else
                {
                    if (ClientRectangle.Contains(e.Location))
                    {
                        this.Cursor = Cursors.SizeAll;
                        if (pDragging && e.Button == MouseButtons.Left)
                        {
                            Point theFormPosition = this.Parent.PointToClient(Control.MousePosition);
                            theFormPosition.X -= pMousePosition.X;
                            theFormPosition.Y -= pMousePosition.Y;
                            Location = theFormPosition;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }

                }
                base.OnMouseMove(e);
            }


        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (check_contain)
            {
                Width = e.Location.X;
                Height = e.Location.Y;
                base.OnMouseUp(e);
                check_contain = false;
            }
            else
            {
                Point theFormPosition = this.Parent.PointToClient(Control.MousePosition);
                theFormPosition.X -= pMousePosition.X;
                theFormPosition.Y -= pMousePosition.Y;
                Location = theFormPosition;
                pDragging = false;
            }

        }
        protected override void OnGotFocus(EventArgs e)
        {
            focus = true;
            Invalidate();
            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            focus = false;
            Invalidate();
            base.OnLostFocus(e);
        }
        protected override void WndProc(ref Message m)
        {

            //borderDrawer.DrawBorder(ref m, this.Width, this.Height);
            if (m.Msg == WM_PAINT)
            {
                IntPtr hdc = GDI.GetDCEx(m.HWnd, (IntPtr.Zero), 1 | 0x0020);
                //IntPtr hdc = GetDC(m.HWnd);
                int rg;
                int hdl;
                switch (_ButtonStyle)
                {
                    case ButtonStyles.Ellipse:
                        if (hdc != IntPtr.Zero)
                        {
                            Graphics graphics = Graphics.FromHdc(hdc);
                            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
                            //ControlPaint.DrawBorder(graphics, rectangle, borderColor, ButtonBorderStyle.Dashed);
                            Rectangle rect = ClientRectangle;
                            rg = GDI.CreateRoundRectRgn(rect.Left, rect.Top, rect.Right, rect.Bottom, Width, Height);
                            hdl = Handle.ToInt32();
                            GDI.SetWindowRgn(hdl, rg, true);
                            m.Result = (IntPtr)1;
                            GDI.ReleaseDC(m.HWnd, hdc);
                        }
                        break;
                    case ButtonStyles.Rectangle:
                        break;

                }
            }
            base.WndProc(ref m);
        }

    }
}
