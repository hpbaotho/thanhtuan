using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Const
{
    public static class Department
    {
        public const string Dept_ID = "Dept_ID";
        public const string Store_ID = "Store_ID";
        public const string Description = "Description";
        public const string Type = "Type";
        public const string TSDisplay = "TSDisplay";
        public const string Cost_MarkUp = "Cost_MarkUp";
        public const string Dirty = "Dirty";
        public const string SubType = "SubType";
        public const string Print_Dept_Notes = "Print_Dept_Notes";
        public const string Dept_Notes = "Dept_Notes";
        public const string Require_Permission = "Require_Permission";
        public const string Require_Serials = "Require_Serials";
        public const string BarTaxInclusive = "BarTaxInclusive";
        public const string Cost_Calculation_Percentage = "Cost_Calculation_Percentage";
        public const string Square_Footage = "Square_Footage";

        #region TypeDept

        public const byte REGULAR = 0;
        public const byte RENTAL = 1;
        public const byte EMPLOYEE = 2;
        #endregion
    }
}
