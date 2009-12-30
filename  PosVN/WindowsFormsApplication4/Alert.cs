using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4
{
    class Alert
    {
        public static void Show(string alertText)
        {
            MessBox messBox = new MessBox(alertText);
            messBox.ShowDialog();
        }
        public static void Show(string alertText,Color backColor)
        {
            MessBox messBox = new MessBox(alertText);
            messBox.BackColor = backColor;
            messBox.ShowDialog();
        }
    }
}
