using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class FrmPOS : Form
    {
        public FrmPOS()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics grp = e.Graphics)
            {

                Point[] border = new Point[] { new Point(ClientRectangle.X, ClientRectangle.Y), new Point(ClientRectangle.Right, ClientRectangle.Top), new Point(ClientRectangle.Right, ClientRectangle.Bottom), new Point(ClientRectangle.Left, ClientRectangle.Bottom), new Point(ClientRectangle.X, ClientRectangle.Y), };
                grp.DrawLines(new Pen(Color.Black, 2), border);

            }
        }
        //protected override void OnPaintBackground(PaintEventArgs e) { }
    }
}
