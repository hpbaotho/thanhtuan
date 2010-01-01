using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Services;
using WindowsFormsApplication4.Controls;


namespace WindowsFormsApplication4.Service
{
    public class ServiceGet
    {
        get_GUI getGui ;
        public ServiceGet()
        {
            getGui = new get_GUI();
        }

        public ArrayList getArrayButton(string storeID,string sectionName)
        {
            ArrayList mangButton = new ArrayList();
            DataTable tbl =  getGui.get_Array_button(storeID, sectionName);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                int x = (int)tbl.Rows[i][4];
                int y = (int)tbl.Rows[i][5];
                int height = (int)tbl.Rows[i][6];
                int width = (int)tbl.Rows[i][7];
                var tmpBut = new button(x, y, width, height);
                mangButton.Add(tmpBut);
            }
            return mangButton;
        }
        public DataTable getSections(string storeID)
        {
            return getGui.GetAllSections(storeID);
        }
        public ArrayList getTables(string storeID, string sectionName)
        {
            ArrayList mangButton = new ArrayList();
            DataTable tbl = getGui.GetAllTablesBySectionID(storeID,sectionName);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if ((int)tbl.Rows[i][10] == 0)
                {
                    int x = (int)tbl.Rows[i][4];
                    int y = (int)tbl.Rows[i][5];
                    int height = (int)tbl.Rows[i][6];
                    int width = (int)tbl.Rows[i][7];
                    int shapeType = (int) tbl.Rows[i][3];
                    TransButton.Shape shape;
                    if(shapeType == 0)
                    {
                        shape = TransButton.Shape.Rec;
                    }
                    else if(shapeType == 1)
                    {
                        shape = TransButton.Shape.Square;
                    }
                    else
                    {
                        shape = TransButton.Shape.Elip;
                    }
                   
                    var tmpBut = new TransButton(x, y, width, height);
                    tmpBut.ForeColor = Color.FromArgb((int)tbl.Rows[i][13]);
                    tmpBut.BorderColor = Color.FromArgb((int)tbl.Rows[i][13]);
                    if (tbl.Rows[i][17].ToString() != "")
                    {
                        tmpBut.cashierId = tbl.Rows[i][16].ToString();
                        if (tbl.Rows[i][16].ToString() == StaticClass.cashierId)
                        {
                            tmpBut.BackColor = Color.Green;
                        }
                        else
                        {
                            tmpBut.BackColor = Color.Orange;
                        }
                        if (Convert.ToBoolean(tbl.Rows[i][15]))
                        {
                            tmpBut.BackColor = Color.Red;
                            tmpBut.ForeColor = Color.Gray;
                            tmpBut.Enabled = false;
                        }
                        tmpBut.invoiceNum = tbl.Rows[i][17].ToString();
                    }
                    
                    tmpBut.ButtonShape = shape;
                    tmpBut.tableName = tbl.Rows[i][2].ToString();
                    tmpBut.ButtonText = tbl.Rows[i][2].ToString();
                    mangButton.Add(tmpBut);
                }
               
            }
            return mangButton;
        }
        public ArrayList getTablesEdit(string storeID, string sectionName)
        {
            ArrayList mangButton = new ArrayList();
            DataTable tbl = getGui.GetAllTablesBySectionID(storeID, sectionName);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if ((int)tbl.Rows[i][10] == 0)
                {
                    int x = (int)tbl.Rows[i][4];
                    int y = (int)tbl.Rows[i][5];
                    int height = (int)tbl.Rows[i][6];
                    int width = (int)tbl.Rows[i][7];
                    MyButton.ButtonStyles style;
                    if((int)tbl.Rows[i][3] == 0 || (int)tbl.Rows[i][3] == 1 )
                    {
                        style = MyButton.ButtonStyles.Rectangle;
                    }
                    else
                    {
                        style = MyButton.ButtonStyles.Ellipse;
                    }
                    var tmpBut = new MyButton(x, y, width, height, style);
                    tmpBut.borColor = Color.FromArgb((int) tbl.Rows[i][13]);
                    tmpBut.Text_pro = tbl.Rows[i][2].ToString();
                    mangButton.Add(tmpBut);
                }   
            }
            return mangButton;
        }
        public DataTable GetDepartments(string storeID)
        {
            return getGui.GetAllDepartments(storeID);

        }

        public int Login(string Id,string pass,string storeId)
        {
            DataTable getCashierpass = getGui.GetEmployeePass(Id);
            if(getCashierpass.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                string cashierPass = getCashierpass.Rows[0][1].ToString();
                string adminPass = getGui.GetAdminPass(storeId).Rows[0][1].ToString();
                if(pass == cashierPass || pass == adminPass)
                {
                    if (pass == cashierPass)
                    {
                        StaticClass.isAdmin = false;
                    }
                    else
                    {
                        StaticClass.isAdmin = true;
                    }
                    StaticClass.cashierId = Id;
                    DataTable thongTinNV = getGui.GetEmpById(Id);
                    StaticClass.thongTinNV = thongTinNV.Rows[0];
                    return 2;
                }
                else
                {
                    return 1;
                }
                
            }
        }
        public bool checkAdminPass(string pass,string storeId)
        {
            if(pass == getGui.GetAdminPass(storeId).Rows[0][1].ToString())
            {
                return true;
            }
            return false;
        }
    }
}
