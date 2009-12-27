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
    public partial class ColorBar : Control
    {
        public Color color_prop;

        public ColorBar()
        {
            color_prop = Color.Gray;
        }
        public ColorBar(Color x)
        {
            color_prop = x;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics grp = e.Graphics)
            {
                Brush myBrush = new SolidBrush(color_prop);
                grp.FillRectangle(myBrush,this.ClientRectangle.X,ClientRectangle.Y,ClientRectangle.Width,ClientRectangle.Height);
                Point[] points = new Point[]{new Point(ClientRectangle.Left,ClientRectangle.Top),new Point(ClientRectangle.Right-1,ClientRectangle.Top),new Point(ClientRectangle.Right-1,ClientRectangle.Bottom-1),new Point(ClientRectangle.Left,ClientRectangle.Bottom-1),new Point(ClientRectangle.Left,ClientRectangle.Top) };
                grp.DrawLines(new Pen(Color.Black),points );

            }
        }

        protected override void OnClick(EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                color_prop = colorDialog.Color;
            }
            this.BackColor = color_prop;
            Invalidate();
            base.OnClick(e);
        }
    }
}
