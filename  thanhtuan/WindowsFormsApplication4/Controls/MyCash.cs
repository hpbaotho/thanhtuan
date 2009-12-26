using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;


namespace WindowsFormsApplication4.Controls
{
    public partial class MyCash : UserControl
    {
        private bool track;
        private int i;  //so luong item suoc them vao hash
        private int position;
        private int pos_scroll_begin;
        private int pos_scroll_end;
        private Hashtable hash;
        private int scale;
        private int pos_sroll_present;
        private bool multi_selected;
        private int id_pre;
        public DataTable listInvoiceItem;
        public DataTable invoiceTotal;

        public bool MultiSelected
        {
            get
            {
                return multi_selected;
            }
            set
            {
                multi_selected = value;
            }
        }
        public int Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }
        public void Set_LabelBan(string s)
        {
            Label_Ban.Text = s;
        }
        public void Set_LabelServerId(string s)
        {
            Label_ServerId.Text = s;
        }
        public MyCash()
        {
            listInvoiceItem = new DataTable();
            invoiceTotal = new DataTable();
            InitializeComponent();
            multi_selected = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            position = 0;
            pos_scroll_begin = 1;
            track = false;
            int n_rows = (vScrollBar1.Height-myItem1.Height)/myItem1.Height+2;
            hash=new Hashtable();
            pos_sroll_present = 0;
            for (i = 1; i < n_rows; i++)
            {
                MyItem item = new MyItem(myItem1.Width, myItem1.Height);
                item.Id = i;
                item.Text = "myitems" + i;
                item.Name = item.Text;
                item.Location = new System.Drawing.Point(0,panel_Ban.Height+Label_Ban.Height+ i * myItem1.Height);
                this.Controls.Add(item);
                hash.Add(i,item);
            }
            i--;
            pos_scroll_end = i;
        }
        private void drawItems(int h, int start, int n)
        {
            int j = 1;
            for(int k=start; k<=n;k++)
            {
               
                MyItem item = findRow(k);
                item.Location = new Point(0,panel_Ban.Height+Label_Ban.Height+j*h);
                Controls.Add(item);
                //if(n<=position)
                //    item.addRow(item.Id,item.Mota,item.Soluong,item.Gia);
                hash.Remove(k);
                hash.Add(k,item);
                j++;
            }
        }
        private void MyCash_Load(object sender, EventArgs e)
        {
            Label_Timer.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now);       
        }
        private void SmallIncrement(ScrollEventArgs e)
        {
            if (e.OldValue == 91)
            {
            }
            else
            {  
                pos_scroll_begin++;
                pos_scroll_end++;
                if (pos_scroll_end > i)
                {
                    i++;
                    MyItem item = new MyItem(myItem1.Width, myItem1.Height);
                    item.Text = "myitems" + i;
                    item.Name = item.Text;
                    item.Id = i;
                    hash.Add(i, item);
                }
                Controls.Remove(findRow(pos_scroll_begin - 1));
                drawItems(myItem1.Height, pos_scroll_begin, pos_scroll_end);
                pos_sroll_present = e.NewValue;
            }
        }
        private void SmallDecrement(ScrollEventArgs e)
        {
            if (e.OldValue <= 0)
            {
            }
            else
            {
                Controls.Remove(findRow(pos_scroll_end));
                pos_scroll_begin--;
                pos_scroll_end--;
                drawItems(myItem1.Height, pos_scroll_begin, pos_scroll_end);
                pos_sroll_present = e.NewValue;
            }      
        }
        private void LargeIncrement(ScrollEventArgs e)
        {
            if (e.OldValue == 91)
            {
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    pos_scroll_begin++;
                    pos_scroll_end++;
                    if (pos_scroll_end > i)
                    {
                        i++;
                        MyItem item = new MyItem(myItem1.Width, myItem1.Height);
                        item.Text = "myitems" + i;
                        item.Name = item.Text;
                        item.Id = i;
                        hash.Add(i, item);
                    }

                    Controls.Remove(findRow(pos_scroll_begin - 1));
                }
                drawItems(myItem1.Height, pos_scroll_begin, pos_scroll_end);
                pos_sroll_present = e.NewValue;
            }
        }
        private void LargeDecrement(ScrollEventArgs e)
        {
            if (e.OldValue <= 0)
            {
                //MessageBox.Show("mini");
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    Controls.Remove(findRow(pos_scroll_end));
                    pos_scroll_begin--;
                    if (pos_scroll_begin < 1)
                    {
                        pos_scroll_begin = 1;
                        break;
                    }
                    pos_scroll_end--;
                }
                drawItems(myItem1.Height, pos_scroll_begin, pos_scroll_end);
                pos_sroll_present = e.NewValue;
            }      
        }
        private void ThumbTrack(ScrollEventArgs e)
        {
            if (e.OldValue == 91)
            {
                //MessageBox.Show("maxx");
            }
            else if (e.OldValue <= 0)
            {
                //MessageBox.Show("min");
            }
            else
            {
                if (e.NewValue > pos_sroll_present)
                {
                    int n = e.NewValue - pos_sroll_present;
                    for (int j = 0; j < n; j++)
                    {
                        pos_scroll_begin++;
                        pos_scroll_end++;
                        if (pos_scroll_end > i)
                        {
                            i++;
                            MyItem item = new MyItem(myItem1.Width, myItem1.Height);
                            item.Text = "myitems" + i;
                            item.Id = i;
                            item.Name = item.Text;
                            hash.Add(i, item);
                        }

                        Controls.Remove(findRow(pos_scroll_begin - 1));
                    }
                    drawItems(myItem1.Height, pos_scroll_begin, pos_scroll_end);
                    pos_sroll_present = e.NewValue;
                }
                else
                {
                    int n = pos_sroll_present - e.NewValue;
                    for (int j = 0; j < n; j++)
                    {
                        Controls.Remove(findRow(pos_scroll_end));
                        pos_scroll_begin--;
                        if (pos_scroll_begin < 1)
                        {
                            pos_scroll_begin = 1;
                            break;
                        }
                        pos_scroll_end--;
                    }
                    drawItems(myItem1.Height, pos_scroll_begin, pos_scroll_end);
                    pos_sroll_present = e.NewValue;
                }
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
                if(e.ScrollOrientation==ScrollOrientation.VerticalScroll)
                {
                        if(e.Type==ScrollEventType.SmallIncrement)
                        {
                            SmallIncrement(e);
                        }
                        else if(e.Type==ScrollEventType.SmallDecrement)
                        {

                            SmallDecrement(e);
                        }
                        else if(e.Type==ScrollEventType.LargeIncrement)
                        {
                            LargeIncrement(e);
                        }
                        else if(e.Type==ScrollEventType.LargeDecrement)
                        {             
                            LargeDecrement(e);
                        }
                        else if(e.Type==ScrollEventType.ThumbTrack)
                        {
                            ThumbTrack(e);                  
                        }

                }
        }     
        public void addRow(string mota, string sl, string gia)
        {
            position ++;
            if(position> pos_scroll_end)
            {
                if(position>i)
                {
                    i++;
                    MyItem item = new MyItem(myItem1.Width,myItem1.Height);
                    item.Text = "myitems" + i;
                    item.Name = item.Text;
                    item.addRow(i, mota, sl, gia);
                    item.Set_selected();
                    hash.Add(position, item);
                }
                else
                {
                    MyItem tmp = findRow(position);
                    tmp.addRow(tmp.Id, mota, sl, gia);
                    tmp.Set_selected();
                    hash.Remove(position);
                    hash.Add(position, tmp);
                }
            }
            else
            {
                MyItem tmp = findRow(position);
                tmp.addRow(position, mota, sl, gia);
                tmp.Set_selected();
                hash.Remove(position);
                hash.Add(position, tmp);
            }        
        }
        private MyItem findRow(int id)
        {
            MyItem r = (MyItem)hash[id];
            if(r==null)
            {
                MyItem item = new MyItem(myItem1.Width, myItem1.Height);
                item.Id = id + 1;
                return item; 
            }
            return r;   
        }
        private Hashtable change2array(Hashtable h)
        {
            Hashtable list = new Hashtable(h.Count);
            for (int k = 1; k <= h.Count;k++ )
            {
                list[k] = h[k];
            }
            return list;
        }
        private void change2hashtable(Hashtable l)
        {
            hash.Clear();
            int t = 1;
            for(int k=1;k<=l.Count;k++)
            {
                if(((MyItem)l[k]).Id!=0)
                {
                    hash[t] = l[k];
                    t++;
                }
            }
        }
        public void delete_RowSelected()
        {
            ArrayList arr = get_RowSelected();
            Hashtable list = change2array(hash);
            foreach (MyItem o in arr)
            {
                i--;
                position--;
                hash.Remove(o.Id);   
                Controls.RemoveByKey(o.Text);
                ((MyItem)list[o.Id]).Id = 0;
                //drawItems(myItem1.Height, o.Id + 1, pos_scroll_end);
            }
            for (int k = 1; (k <= list.Count);k++ )
            {
                if(k!=((MyItem)list[k]).Id)
                {
                    for(int q=k+1;q<=list.Count;q++)
                    {
                        if(q==((MyItem)list[q]).Id)
                        {
                            MyItem item = (MyItem) list[q];
                            item.Id = k;
                            k++;
                        }               
                    }
                    break;
                }
            }
            change2hashtable(list);
            drawItems(myItem1.Height, pos_scroll_begin, pos_scroll_end);
        }
        public ArrayList get_RowSelected()
        {
            ArrayList re=new ArrayList();
            for(int k=1;k<=hash.Count;k++)
            {
                MyItem item = (MyItem) hash[k];
                if (item.Click)
                    re.Add(hash[k]);
            }
            return re;
        }

        public void invadiate_NonMultiSelected(MyItem item)
        {
            if(item.Add)
            {
                for (int k = 1; k <= hash.Count; k++)
                {
                    MyItem tmp = (MyItem)hash[k];
                    if (tmp.Add)
                    {
                        if (tmp.Id == item.Id)
                        {
                            tmp.Set_selected(true);
                        }
                        else
                        {
                            tmp.Set_selected(false);
                            tmp.Click = false;
                        }
                        tmp.Invalidate();
                    }
                } 
            }
            
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Label_Timer.Text =String.Format("{0:hh:mm:ss tt}", DateTime.Now);
        }

        private const int WM_VSCROLL = 277; // Vertical scroll
        private const int SB_LINEUP = 0; // Scrolls one line up
        private const int SB_LINEDOWN = 1; // Scrolls one line down
        private void button1_Click(object sender, EventArgs e)
        {
            int t = GDI.SendMessage(vScrollBar1.Handle, WM_VSCROLL, (IntPtr)SB_LINEUP, vScrollBar1.Handle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int t = GDI.SendMessage(vScrollBar1.Handle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, vScrollBar1.Handle);
            
        }
        public void changeQuality(string sl)
        {
            ArrayList re = get_RowSelected();
            foreach (MyItem o in re)
            {
                o.changeQuality(sl);
            }
        }
        //public delegate void call_delegate(this.Form_test.);
        //protected override void OnClick(EventArgs e)
        //{
        //    FrmBanHang tmp = (FrmBanHang)this.Parent;
        //    //this.Invoke(call_delegate);
        //    bool flag = false;
        //    if()
        //    this.Invoke(new EventHandler(tmp.call), this, null);
        //    base.OnClick(e);
        //}
    }
}
