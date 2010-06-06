using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class ReasonCode
    {
        public const int KitchenNote = 0; 
        public string Code;
        public int Type;
        public bool isDelete;
        public bool isNew;
        public ReasonCode(string code,int type)
        {
            Type = type;
            Code = code;
            isDelete = false;
            isNew = false;
        }
        public override string ToString()
        {
            return Code;
        }
    }
}
