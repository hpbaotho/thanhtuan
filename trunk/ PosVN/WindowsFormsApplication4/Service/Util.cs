using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Controls;

namespace WindowsFormsApplication4.Service
{
    class Util
    {
        static public int UpdateDataTableForCombo(ComboBox comboBox, DataTable table, int column)
        {
            comboBox.DataSource = table;
            comboBox.DisplayMember = table.Columns[column].ColumnName;
            return table.Rows.Count - 1;
        }
        static public int setCurrentIndexForCombo(DataTable table,int column, string s)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][column].Equals(s))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
