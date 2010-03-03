using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class TSButtonDept : TSButton
    {
        public ArrayList TSButtonInvent;
        public TSButtonDept(string stationId, int index, string capt, string pic, string option1, int backColor, int foreColor, bool visible, string ident,ArrayList listTSInvent)
        {
            StationId = stationId;
            Index = index;
            Caption = capt;
            Picture = pic;
            Option1 = option1;
            BackColor = backColor;
            ForeColor = foreColor;
            Visible = visible;
            Ident = ident;
            TSButtonInvent = listTSInvent;
        }
    }
}
