using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Controls
{
    public class  exListBoxItem
    {
        private string mota;
        private string soluong;
        
        private string gia;
       
       

        public exListBoxItem(string _mota, string _soluong, string _gia)
        {
            mota = _mota;
            soluong = _soluong;
            gia = _gia;
            
        }

        public string Mota
        {
            get { return mota; }
            set { mota = value; }
        }

        public string Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public string Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public void drawItem(DrawItemEventArgs e, Padding margin,
                             Font titleFont, Font detailsFont, StringFormat aligment)
        {

            // if selected, mark the background differently
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
            }

            // draw some item separator
            e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y);

            // draw item image
            //e.Graphics.DrawImage(this.ItemImage, e.Bounds.X + margin.Left, e.Bounds.Y + margin.Top, imageSize.Width, imageSize.Height);

            // calculate bounds for title text drawing
            Rectangle motaBounds = new Rectangle(e.Bounds.X + margin.Horizontal,
                                                 e.Bounds.Y + (int)titleFont.GetHeight() + 2 + margin.Vertical + margin.Top,
                                                  e.Bounds.Width - margin.Horizontal,
                                                  (int)titleFont.GetHeight()+2);

            // calculate bounds for details text drawing
            Rectangle soluongBounds = new Rectangle(e.Bounds.X + margin.Horizontal+e.Bounds.Width/3 ,
                                                   e.Bounds.Y + (int)titleFont.GetHeight() + 2 + margin.Vertical + margin.Top,
                                                   e.Bounds.Width - margin.Right  - margin.Horizontal,
                                                   e.Bounds.Height - margin.Bottom - (int)titleFont.GetHeight() - 2 - margin.Vertical - margin.Top);

            // draw the text within the bounds
            e.Graphics.DrawString(this.Mota, titleFont, Brushes.Black, motaBounds, aligment);
            e.Graphics.DrawString(this.Soluong, detailsFont, Brushes.DarkGray, soluongBounds, aligment);

            // put some focus rectangle
            e.DrawFocusRectangle();

        }

    }

    public  class MyListbox : ListBox
    {
        
        private StringFormat _fmt;
        private Font _titleFont;
        private Font _detailsFont;
        
        public MyListbox(Font titleFont, Font detailsFont, Size imageSize, 
                         StringAlignment aligment, StringAlignment lineAligment)
        {
            _titleFont = titleFont;
            _detailsFont = detailsFont;
            _fmt = new StringFormat();
            _fmt.Alignment = aligment;
            _fmt.LineAlignment = lineAligment;
            _titleFont = titleFont;
            _detailsFont = detailsFont;
        }
        public MyListbox()
        {
            
           
            this.ItemHeight = this.Margin.Vertical;
            _fmt = new StringFormat();
            _fmt.Alignment = StringAlignment.Near;
            _fmt.LineAlignment = StringAlignment.Near;
            _titleFont = new Font(this.Font, FontStyle.Bold);
            _detailsFont = new Font(this.Font, FontStyle.Regular);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // prevent from error Visual Designer
            if (this.Items.Count > 0)
            {
                exListBoxItem item = (exListBoxItem)this.Items[e.Index];
                item.drawItem(e, this.Margin, _titleFont, _detailsFont, _fmt);
            }
           
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
