using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class Ingredient
    {
        public string IngreId;
        public string IngreName;
        public decimal Cost;
        public float Quantity;
        public int Mesurement;
        public float Yield;
        public bool isNew;
        public bool isdelete;
        public Ingredient(string ingreid,string ingreName,float quant,int mesure, float yield,decimal cost)
        {
            IngreId = ingreid;
            IngreName = ingreName;
            Cost = cost;
            Quantity = quant;
            Mesurement = mesure;
            Yield = yield;
            isNew = false;
            isdelete = false;
        }
    }
}
