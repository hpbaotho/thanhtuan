using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Controls
{
    public partial class MyItem : Control
    {
        private int id;
        private string mota;
        private string soluong;
        private string gia;
        private int height;
        private int width;
        private bool click;
        private bool add;

        private bool selected;
        public bool Add
        {
            get
            {
                return add;
            }
        }
        public bool Click
        {
            get
            {
                return click;
            }
            set
            {
                click = value;
            }
        }
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Mota
        {
            get
            {
                return mota;
            }
            set
            {
                mota = value;
            }
        }
        public string Soluong
        {
            get
            {
                return soluong;
            }
            set
            {
                soluong = value;
            }
        }
        public string Gia
        {
            get
            {
                return gia;
            }
            set
            {
                gia = value;
            }
        }

        public MyItem()
        {
            selected = false;
            add = false;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }
        public MyItem(int _width,int _height)
        {
            Height = _height;
            Width = _width;
            add = false;
            selected = false;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            
        }
        private string trimMota(string s)
        {
            int n = s.Length;
            if(n>15)
            {
                string ns = s.Substring(0, 14);
                return ns;
            }
            return s;
        }
        private string trimSL(string s)
        {
            int n = s.Length;
            if (n > 4)
            {
                string ns = s.Substring(0, 4);
                return ns;
            }
            return s;
        }
        private string trimGia(string s)
        {
            int n = s.Length;
            if (n > 10)
            {
                string ns = s.Substring(0, 10);
                return ns;
            }
            return s;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grp = e.Graphics;
            if (selected)
            {
                if(click)
                    grp.FillRectangle(Brushes.Gray,ClientRectangle);
                else
                    grp.FillRectangle(Brushes.White, ClientRectangle);
    
            }      
            if(!this.Enabled)
            {
                grp.FillRectangle(Brushes.DarkViolet,ClientRectangle);
                SizeF textSize_mota = grp.MeasureString("MO TA", new Font("Arrial", 15, FontStyle.Regular));
                float textX_mota = (ClientRectangle.Left + ClientRectangle.Width / 2 - textSize_mota.Width) / 2;
                float textY_mota = (Size.Height/2) - (textSize_mota.Height / 2);
                grp.DrawString("MO TA", new Font("Arrial", 15, FontStyle.Regular), Brushes.Black, textX_mota, textY_mota);

                SizeF textSize_soluong = grp.MeasureString("SL", new Font("Arrial", 15, FontStyle.Regular));
                float textX_soluong = (ClientRectangle.Left + ClientRectangle.Width/2 + (ClientRectangle.Width/6 - 5-textSize_soluong.Width)/2);
                int textY_soluong = (int)(Size.Height / 2) - (int)(textSize_soluong.Height / 2);
                grp.DrawString("SL", new Font("Arrial", 15, FontStyle.Regular), Brushes.Black, textX_soluong, textY_soluong);

                SizeF textSize_gia = grp.MeasureString("GIA", new Font("Arrial", 15, FontStyle.Regular));
                float textX_gia = (ClientRectangle.Left + ClientRectangle.Width / 2 + ClientRectangle.Width / 6 - 5 + (ClientRectangle.Width / 3 + 5 - textSize_gia.Width) / 2);
                int textY_gia = (int)(Size.Height / 2) - (int)(textSize_gia.Height / 2);
                grp.DrawString("GIA", new Font("Arrial", 15, FontStyle.Regular), Brushes.Black, textX_gia, textY_gia); 

            }
            grp.DrawRectangle(new Pen(Brushes.DarkGray,2),ClientRectangle );
            float x1 = ClientRectangle.Left + ClientRectangle.Width/2;
            float x2 = ClientRectangle.Left + ClientRectangle.Width/2 + ClientRectangle.Width/6-5;
            grp.DrawLine(new Pen(Brushes.DarkGray, 2), x1, ClientRectangle.Top, x1, ClientRectangle.Bottom);
            grp.DrawLine(new Pen(Brushes.DarkGray, 2), x2, ClientRectangle.Top, x2, ClientRectangle.Bottom);
            if(add)
            {

                SizeF textSize_mota = grp.MeasureString(trimMota(mota), new Font("Arrial", 14, FontStyle.Regular));
                float textX_mota = (ClientRectangle.Left );
                //int textX_mota = (int)(ClientRectangle.Left + ClientRectangle.Width / 3) - (int)(textSize_mota.Width / 2);
                int textY_mota = (int)(Size.Height / 2) - (int)(textSize_mota.Height / 2);
                grp.DrawString(trimMota(mota), new Font("Arrial", 14, FontStyle.Regular), Brushes.Black, textX_mota, textY_mota);

                SizeF textSize_soluong = grp.MeasureString(trimSL(soluong), new Font("Arrial", 14, FontStyle.Regular));
                float textX_soluong = ClientRectangle.Left + ClientRectangle.Width / 2 + ClientRectangle.Width / 6 - 5-textSize_soluong.Width;
                //int textX_soluong = (int)(ClientRectangle.Left + 2 * ClientRectangle.Width / 3 + ClientRectangle.Width / 16) - (int)(textSize_soluong.Width / 2);
                int textY_soluong = (int)(Size.Height / 2) - (int)(textSize_soluong.Height / 2);
                grp.DrawString(trimSL(soluong), new Font("Arrial", 14, FontStyle.Regular), Brushes.Black, textX_soluong, textY_soluong);

                SizeF textSize_gia = grp.MeasureString(trimGia(gia), new Font("Arrial", 14, FontStyle.Regular));
                float textX_gia = ClientRectangle.Left + ClientRectangle.Width - textSize_gia.Width;
                int textY_gia = (int)(Size.Height / 2) - (int)(textSize_gia.Height / 2);
                grp.DrawString(trimGia(gia), new Font("Arrial", 14, FontStyle.Regular), Brushes.Black, textX_gia, textY_gia);           
            }
            
            base.OnPaint(e);
        }
        public int onClick()
        {
            if(selected)
            {
                
              
                click = !click;
                Focus();
                Invalidate();
                if (click)
                {
                    MyCash cash = (MyCash)this.Parent;
                    ArrayList array = cash.get_RowSelected();
                    if(array.Count==1)
                    {
                        FrmBanHang tmp = (FrmBanHang)cash.Parent;
                        this.Invoke(new EventHandler(tmp.changeLayout), true, null);
                    }
                }
                else
                {
                    MyCash cash = (MyCash)this.Parent;
                    ArrayList array = cash.get_RowSelected();
                    if (array.Count == 0)
                    {
                        FrmBanHang tmp = (FrmBanHang)cash.Parent;
                        this.Invoke(new EventHandler(tmp.changeLayout), false, null);
                    }
                }
            }
            return this.id;
            
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MyCash cash = (MyCash) this.Parent;
            if(cash.MultiSelected==false)
                cash.invadiate_NonMultiSelected(this);
            onClick();
            base.OnMouseDown(e);
        }
        public void addRow(int _id,string _mota, string _soluong, string _gia)
        {
            id = _id;
            mota = _mota;
            soluong = _soluong;
            gia = _gia;
            add = true;
            Invalidate();
        }
        public void deleteRow(int _id)
        {
            if(id==_id)
            {
                
            }
        }
        public void Set_selected()
        {
            selected = true;
        }
        public void Set_selected(bool b)
        {
            selected = b;
        }
        public void invadiate()
        {
            add = true;
            Invalidate();
        }
        public override string ToString()
        {
            return this.id.ToString();
        }
        //public override bool Equals(object obj)
        //{
        //    MyItem tmp = (MyItem) obj;
        //    if ((this.id == tmp.id) && (this.mota == tmp.mota) && (this.soluong == tmp.soluong) && (this.gia == tmp.gia))
        //        return true;
        //    return false;
        //}
        public MyItem[] this[int count]
        {
            get { throw new NotImplementedException(); }
        }
        public void changeQuality(string sl)
        {
            soluong = sl;
            Invalidate();
        }
        public void changeItem(string _soluong, string _gia)
        {
            soluong = _soluong;

            gia = _gia;
            Invalidate();
        }
    }
}
