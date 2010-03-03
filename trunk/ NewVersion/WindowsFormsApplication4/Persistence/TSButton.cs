using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class TSButton
    {
        public string StationId;
        public int Index;
        public string Caption;
        public string Picture;
        public string Option1;
        public int BackColor;
        public int ForeColor;
        public bool Visible;
        public string Ident;
        public TSButton(string stationId,int index,string capt,string pic,string option1,int backColor,int foreColor,bool visible,string ident)
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
        }
        public TSButton()
        {

        }

        public override string ToString()
        {
            return Caption;
        }
    }
}
