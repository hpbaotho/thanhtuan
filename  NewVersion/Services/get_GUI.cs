using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using DAO;
using System.Data.SqlClient;
using Services.CustomerTableAdapters;


namespace Services
{
    public class get_GUI
    {
        Server sr;
        private SqlCommand cmd;
        public static string serverName = "THANH\\SQLEXPRESS";
        public static string databaseName = "POS";
        public static string Mode="AUT";
        public static string UserName;
        public static string Password;


        public get_GUI()
        {
            sr = new Server();
            //sr.Server_name = @"THANH\SQLEXPRESS";
            //sr.Database_name = "POS";
            sr.Server_name = serverName;
            sr.Database_name = databaseName;
            sr.Mode = Mode;
            sr.UserName = UserName;
            sr.Password = Password;

            //cmd=new SqlCommand();
        }
        private DataTable FillDataset(SqlCommand cmd,CommandType type, String[] para, string[] value, string strSP)
        {
            DataTable dataset = new DataTable();
            try
            {
                cmd.Connection = DataProvider.ConnectionData(sr);
                cmd.CommandType = type;
                cmd.CommandText = strSP;

                for (int i = 0; i < para.Length; i++)
                {
                    SqlParameter pa = new SqlParameter();
                    pa.ParameterName = para[i];
                    pa.SqlValue = value[i];
                    cmd.Parameters.Add(pa);
                }

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataset);
                adap.Dispose();
                DataProvider.close_connection();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return dataset;
        }
        private DataTable FillDataset2(SqlCommand cmd, CommandType type, String[] para, object[] value, string strSP)
        {
            DataTable dataset = new DataTable();
            try
            {
                cmd.Connection = DataProvider.ConnectionData(sr);
                cmd.CommandType = type;
                cmd.CommandText = strSP;

                for (int i = 0; i < para.Length; i++)
                {
                    SqlParameter pa = new SqlParameter();
                    pa.ParameterName = para[i];
                    pa.SqlValue = value[i];
                    cmd.Parameters.Add(pa);
                }

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataset);
                adap.Dispose();
                DataProvider.close_connection();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
            return dataset;
        }
        private DataTable FillDataset3(SqlCommand cmd, CommandType type,string strSP)
        {
            DataTable dataset = new DataTable();
            try
            {
                cmd.Connection = DataProvider.ConnectionData(sr);
                cmd.CommandType = type;
                cmd.CommandText = strSP;

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataset);
                adap.Dispose();
                DataProvider.close_connection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
            return dataset;
        }
        public DataTable get_Array_button(string strore_id, string section_id)
        {     
           //string query= "select * from Table_Diagram where Store_ID=" +strore_id+ "and "
            cmd.Connection = DataProvider.ConnectionData(sr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_Array_button";

            SqlParameter[] pa = {new SqlParameter("@Store_ID", strore_id), new SqlParameter("@Section_ID", section_id)};
      
            cmd.Parameters.AddRange(pa); 
            DataTable data=new DataTable();
            SqlDataAdapter adpt=new SqlDataAdapter(cmd);
            adpt.Fill(data);
            //System.Windows.Forms.MessageBox.Show(data.Rows[1][1].ToString());
            DataProvider.close_connection();
            return data;
        }
        public DataTable GetAllSections(string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = {"@Store_ID"};
            string[] value = {Store_ID};
            DataTable re =  FillDataset(cmd,CommandType.StoredProcedure, pa, value, "sp_GetAllSections");
            cmd.Dispose();
            return re;
        }

        public DataTable GetAllTablesBySectionID(string Store_ID,string Section_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID" };
            string[] value = { Store_ID, Section_ID};
            DataTable re = FillDataset(cmd,CommandType.StoredProcedure, pa, value, "sp_GetAllTablesBySectionID");
            cmd.Dispose();
            return re;
        }

        public DataTable GetAllDepartments(string Store_ID)
        {
            cmd = new SqlCommand();
            
            string[] pa = { "@Store_ID", "@Visible" };
            string[] value = { Store_ID,"1" };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetAllDept");
            cmd.Dispose();
            return re;
        }

        public DataTable GetAdminPass(string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID" };
            string[] value = { Store_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetAdminPass");
            cmd.Dispose();
            return re;
        }
        public DataTable GetEmployeePass(string Cashier_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Cashier_ID" };
            string[] value = { Cashier_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetEmployeePass");
            cmd.Dispose();
            return re;
        }

        public DataTable GetEmpById(string Cashier_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Cashier_ID" };
            string[] value = { Cashier_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetEmpByID");
            cmd.Dispose();
            return re;
        }

        public DataTable GetInventoryByDept(string SchIndex,string DeptId,string StoreID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ScheduleIndex", "@Dept_ID", "@Store_ID" };
            string[] value = { SchIndex,DeptId,StoreID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetInventoryByDept");
            cmd.Dispose();
            return re;
        }
        public void UpdateSection(string newSectionId,string color1,string color2,string storeId,string sectionId)
        {
            cmd = new SqlCommand();
            string[] pa = { "@NewSection_ID", "@BackColor1", "@BackColor2","@Store_ID","@Section_ID" };
            string[] value = { newSectionId, color1, color2, storeId, sectionId };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateSection");
            cmd.Dispose();
        }
        public void UpdateTable(string Store_ID,string Section_ID,string Table_Number,string ShapeType,string XPos,string YPos,string Height,string Width,string Cost_Center_Index,string NumSeats,string Filled,string Description,string objectColor,string objectTextColor)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID", "@Table_Number", "@ShapeType", "@XPos","@YPos","@Height","@Width","@Cost_Center_Index","@NumSeats","@Filled","@Description","@objectColor","@objectTextColor" };
            string[] value = { Store_ID, Section_ID, Table_Number, ShapeType, XPos,YPos,Height,Width,Cost_Center_Index,NumSeats,Filled ,Description,objectColor,objectTextColor};
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateTableDiagram");
            cmd.Dispose();
        }
        public void InsertSection(string storeId,string sectionId,string color1,string color2)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID", "@BackColor1", "@BackColor2" };
            string[] value = { storeId, sectionId, color1, color2 };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_InsertSection");
            cmd.Dispose();
        }
        public void InsertTableDiagram(string Store_ID, string Section_ID, string Table_Number, string ShapeType, string XPos, string YPos, string Height, string Width, string Cost_Center_Index, string NumSeats, string ObjectType, string Filled, string Description, string objectColor, string objectTextColor)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID", "@Table_Number", "@ShapeType", "@XPos", "@YPos", "@Height", "@Width", "@Cost_Center_Index", "@NumSeats", "@ObjectType", "@Filled", "@Description", "@objectColor", "@objectTextColor" };
            string[] value = { Store_ID, Section_ID, Table_Number, ShapeType, XPos, YPos, Height, Width, Cost_Center_Index, NumSeats,ObjectType, Filled, Description, objectColor, objectTextColor };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_InsertTableDiagram");
            cmd.Dispose();
        }

        public void DeleteSection(string storeId,string sectionId)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID" };
            string[] value = { storeId, sectionId};
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteSection");
            cmd.Dispose();
        }

        public void DeleteTableDiagram(string storeId, string sectionId,string tableNumber)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID", "@Table_Number" };
            string[] value = { storeId, sectionId,tableNumber };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteTableDiagram");
            cmd.Dispose();
        }

        public void CreateDept(string Dept_ID,string Store_ID,string Cat_ID,string Description,string Type,string Print_Dept_Notes,string Dept_Notes,string Require_Permission,string Require_Serials,string BarTaxInclusive,string Cost_Calculation_Percentage,string Square_Footage,string Station_ID,string Picture,string Function,string Option1,string BackColor,string ForeColor)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Dept_ID", "@Store_ID", "@Cat_ID","@Description","@Type","@Print_Dept_Notes","@Dept_Notes","@Require_Permission","@Require_Serials","@BarTaxInclusive","@Cost_Calculation_Percentage","@Square_Footage bigint","@Station_ID","@Picture","@Function","@Option1","@BackColor","@ForeColor"};
            string[] value = {  Dept_ID, Store_ID, Cat_ID, Description, Type, Print_Dept_Notes, Dept_Notes, Require_Permission, Require_Serials, BarTaxInclusive, Cost_Calculation_Percentage, Square_Footage, Station_ID, Picture, Function, Option1, BackColor, ForeColor };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_CreateDepartment");
            cmd.Dispose();
        }

        public void DeleteDept(string Dept_ID, string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Dept_ID", "@Store_ID" };
            string[] value = { Dept_ID, Store_ID};
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteDepartment");
            cmd.Dispose();
        }
        
        public DataTable OpenTable(string Store_ID,string Section_ID,string Station_ID,string OnHoldID,string Cashier_ID,string CustNum,DateTime DateTime,string Line1,string Line2,string Line3,string Line4,string Line5 )
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID","@Station_ID","@OnHoldID","@Cashier_ID","@CustNum","@DateTime","@Line1","@Line2","@Line3","@Line4","@Line5" };
            object[] value = {  Store_ID, Section_ID, Station_ID, OnHoldID, Cashier_ID, CustNum, DateTime, Line1, Line2, Line3, Line4, Line5};
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_OpenTable");
            
            cmd.Dispose();
            return re;
        }

        public void DeleteInvoiceItemized(string Store_ID,string InvoiceNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number" };
            string[] value = { Store_ID, InvoiceNum };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteInvoiceItemized");
            cmd.Dispose();
        }

        public DataTable GetInvoiceItemized(string Store_ID, string InvoiceNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number" };
            string[] value = { Store_ID, InvoiceNum };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetInvoiceItemized");
            cmd.Dispose();
            return re;
        }
        public void UpdateInvoiceItemized(string Store_ID,string Invoice_Number,string ItemNum,string Quantity,string LineDisc,string LineNum,string Tax1per,string Tax2per,string Tax3per,string PricePer,string OrgPrice)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number", "@ItemNum", "@Quantity", "@LineDisc", "@LineNum", "@Tax1per", "@Tax2per", "@Tax3per", "@PricePer", "@OrgPrice1" };
            string[] value = { Store_ID, Invoice_Number, ItemNum, Quantity, LineDisc, LineNum, Tax1per, Tax2per, Tax3per,PricePer,OrgPrice };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateInvoiceItemized");
            cmd.Dispose();
        }

        public void CloseTable(string Store_ID, string InvoiceNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number" };
            string[] value = { Store_ID, InvoiceNum };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_CloseTable");
            cmd.Dispose();
            
        }

        public DataTable GetTaxRate(string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID"};
            string[] value = { Store_ID};
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetTaxRate");
            cmd.Dispose();
            return re;
        }

        public DataTable GetInventoryByItemNum (string Store_ID, string ItemNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@ItemNum" };
            string[] value = { Store_ID, ItemNum };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetInventoryByItemNum");
            cmd.Dispose();
            return re;

        }

        public DataTable GetInvoiceTotal(string Store_ID, string InvoiceNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number" };
            string[] value = { Store_ID, InvoiceNum };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetInvoiceTotal");
            cmd.Dispose();
            return re;
        }

        public void UpdateInvoiceTotal(object[] param)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Invoice_Number", "@Store_ID", "@CustNum", "@DateTime", "@Total_Cost", "@Discount", "@Total_Price", "@Total_Tax1", "@Total_Tax2", "@Total_Tax3", "@Grand_Total", "@Amt_Tendered", "@Amt_Change", "@ShipToUsed", "@InvoiceNotesUsed", "@Status", "@Cashier_ID", "@Station_ID", "@Payment_Method", "@Acct_Balance_Due", "@Acct_FullyPaid_Date", "@Taxed_1", "@Taxed_Sales", "@NonTaxed_Sales", "@Tax_Exempt_Sales", "@CA_Amount", "@CH_Amount", "@CC_Amount", "@OA_Amount", "@GC_Amount", "@Tip_Amount", "@Old_Balance", "@Num_People_Party", "@AcctBalanceBefore", "@Salesperson", "@Dirty", "@Zip_Code", "@InvType", "@FS_Amount", "@Amt_FS_AmtTend", "@Amt_FS_Change", "@DC_Amount", "@OA_Amount_Limited", "@Cost_Center_Index", "@Orig_OnHoldID", "@Total_FixedTax", "@Total_GC_Sold", "@Tax_Rate_ID", "@Tax_Rate1_Percent", "@Amt_CA_Sec", "@Exchange_Rate", "@IsLayaway", "@Amt_Deposit", "@LAY_Amount", "@Total_GC_Free", "@MacromatixSyncStatus", "@TotalLiability", "@SoLanInCheck", "@InvoiceTax" };
            string[] value = new string[param.Length];
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, param, "sp_UpdateImvoiceTotal");
            cmd.Dispose();
        }

        public void UpdateTransfer(string Store_ID, string InvoiceNum,string newTableName,string sectionID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Invoice_Number", "@Store_ID", "@NewTableName", "@NewSectionID" };
            string[] value = { InvoiceNum, Store_ID, newTableName, sectionID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateTransfer");
            cmd.Dispose();
        }

        public DataTable GetAllCategories(string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = {"@Store_ID"};
            string[] value = {Store_ID};
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetAllCategories");
            cmd.Dispose();
            return re;
        }
        public DataTable GetAllDepartments2(string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID" };
            string[] value = { Store_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetAllDepartments");
            cmd.Dispose();
            return re;
        }
        public DataTable GetAllDepartmentsBySubType(string Store_ID, string SubType)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@SubType" };
            string[] value = { Store_ID, SubType };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetAllDepartmentsBySubType");
            cmd.Dispose();
            return re;
        }
        public void UpdateCategory(string Cat_ID,string Store_ID,string Description)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Cat_ID", "@Store_ID", "@Description" };
            string[] value = { Cat_ID, Store_ID, Description };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateCategory");
            cmd.Dispose();
        }
        public void InsertCategory(string Cat_ID,string Store_ID,string Description)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Cat_ID", "@Store_ID", "@Description" };
            string[] value = { Cat_ID, Store_ID, Description };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_InsertCategory");
            cmd.Dispose();
        }
        
        public void DeleteCategory(string Cat_ID,string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Cat_ID", "@Store_ID"};
            string[] value = { Cat_ID, Store_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteCategory");
            cmd.Dispose();
        }
        public DataTable GetAllDepartmentsByDeptId(string Dept_ID, string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Dept_ID", "@Store_ID" };
            string[] value = { Dept_ID, Store_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetAllDepartmentsByCatId");
            cmd.Dispose();
            return re;
        }
        public DataTable CreateDepartment(string Dept_ID, string Store_ID, string Cat_ID, string Description, byte Type, bool Print_Dept_Notes, string Dept_Notes, bool Require_Permission,
                                            bool Require_Serials, bool BarTaxInclusive, double Cost_Calculation_Percentage, int Square_Footage, string Station_ID, string Picture,
                                            int Function, string Option1, int @BackColor, int ForeColor)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Dept_ID", "@Store_ID", "@Cat_ID", "@Description", "@Type", "@Print_Dept_Notes", "@Dept_Notes", "@Require_Permission",
                           "@Require_Serials","@BarTaxInclusive","@Cost_Calculation_Percentage","@Square_Footage","@Station_ID","@Picture" ,
                            "@Function","@Option1","@BackColor","@ForeColor"};
            object[] value = { Dept_ID, Store_ID, Cat_ID, Description, Type, Print_Dept_Notes, Dept_Notes, Require_Permission, Require_Serials, BarTaxInclusive, Cost_Calculation_Percentage, Square_Footage, Station_ID, Picture, Function, Option1, BackColor, ForeColor };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_CreateDepartment");
            cmd.Dispose();
            return re;
        }
        public DataTable GetAllInventoryByDept(string Store_ID, string Dept_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Dept_ID" };
            string[] value = { Store_ID, Dept_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetAllInventoryByDept");
            cmd.Dispose();
            return re;
        }

        public void UpdateDepartment(string OldDept_ID, string Dept_ID, string Store_ID, string Cat_ID, string Description, byte Type, bool Print_Dept_Notes, string Dept_Notes, bool Require_Permission,
                                        bool Require_Serials, bool BarTaxInclusive, double Cost_Calculation_Percentage, int Square_Footage, string Station_ID, string Picture,
                                        int Function, string Option1, int @BackColor, int ForeColor)
        {
            cmd = new SqlCommand();
            string[] pa = { "OldDept_ID", "@Dept_ID", "@Store_ID", "@Cat_ID", "@Description", "@Type", "@Print_Dept_Notes","@Dept_Notes", "@Require_Permission",
                           "Require_Serials","@BarTaxInclusive","@Cost_Calculation_Percentage","@Square_Footage","@Station_ID","@Picture" ,
                            "@Function","@Option1","@BackColor","@ForeColor"};
            object[] value = {OldDept_ID, Dept_ID, Store_ID, Cat_ID, Description, Type, Print_Dept_Notes, Dept_Notes, Require_Permission, Require_Serials, BarTaxInclusive, Cost_Calculation_Percentage, Square_Footage, Station_ID, Picture, Function, Option1, BackColor, ForeColor };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateDepartment");
            cmd.Dispose();
        }

        public DataTable GetAllInventoryByDept_Button(byte ScheduleIndex, string Dept_ID, string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ScheduleIndex", "@Dept_ID", "@Store_ID" };
            object[] value = { ScheduleIndex, Dept_ID, Store_ID };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetInventoryByDept");
            cmd.Dispose();
            return re;
        }
        
        public DataTable GetAllInventory(string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = {"@Store_ID" };
            string[] value = { Store_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetAllInventory");
            cmd.Dispose();
            return re;
        }
        public DataTable CreateInventory(string ItemNum,string ItemName,string Store_ID,string Cost,string Price,float In_Stock,bool Tax_1,bool Tax_2,bool Tax_3,string Dept_ID,bool IsModifier,bool Exclude_Acct_Limit,
									 bool Use_Serial_Numbers,bool IsRental,bool AutoWeigh,bool FoodStampable,byte ItemType,bool Prompt_Price,bool Prompt_Quantity,bool Check_ID,
										int Inactive,bool Allow_BuyBack,string Picture,bool Special_Permission,bool Check_ID2,bool Count_This_Item,bool Print_On_Receipt,string Station_ID,int Function,string Option1,int BackColor,int ForeColor,
                                        string reOrderLevel,string reOrderquant)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ItemNum","@ItemName","@Store_ID","@Cost", "@Price", "@In_Stock", "@Tax_1","@Tax_2","@Tax_3","@Dept_ID","@IsModifier","@Exclude_Acct_Limit",
									  "@Use_Serial_Numbers","@IsRental","@AutoWeigh","@FoodStampable","@ItemType","@Prompt_Price","@Prompt_Quantity","@Check_ID",
										"@Inactive","@Allow_BuyBack","@Picture","@Special_Permission","@Check_ID2","@Count_This_Item","@Print_On_Receipt","@Station_ID",
                                        "@Function","@Option1","@BackColor","@ForeColor","@Reorder_Level","@Reorder_Quantity"};
            object[] value = { ItemNum, ItemName, Store_ID, Cost, Price, In_Stock, Tax_1, Tax_2, Tax_3, Dept_ID, IsModifier,Exclude_Acct_Limit, Use_Serial_Numbers,IsRental,
                                AutoWeigh,FoodStampable,ItemType,Prompt_Price,Prompt_Quantity,Check_ID,Inactive,Allow_BuyBack,Picture,Special_Permission,
                               Check_ID2,Count_This_Item,Print_On_Receipt, Station_ID, Function, Option1, BackColor, ForeColor,reOrderLevel,reOrderquant };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_CreateInventory");
            cmd.Dispose();
            return re;
        }

        public void DeleteInventory(string ItemNum, string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = {"@ItemNum", "@Store_ID" };
            string[] value = {ItemNum, Store_ID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_T_DeleteInventory");
            cmd.Dispose();
        }


        public void UpdateInventory(string OldInvent_ID, string ItemNum, string ItemName, string Store_ID, string Cost, string Price, float In_Stock, bool Tax_1, bool Tax_2, bool Tax_3, string Dept_ID, bool IsModifier, bool Exclude_Acct_Limit,
									 bool Use_Serial_Numbers,bool IsRental,bool AutoWeigh,bool FoodStampable,byte ItemType,bool Prompt_Price,bool Prompt_Quantity,bool Check_ID,
										int Inactive,bool Allow_BuyBack,string Picture,bool Special_Permission,bool Check_ID2,bool Count_This_Item,bool Print_On_Receipt,string Station_ID,int Function,string Option1,int BackColor,int ForeColor,
                                    string reOrderLevel, string reOrderQuant)
        {
            cmd = new SqlCommand();
            string[] pa = { "@OldInvent_ID","@ItemNum","@ItemName","@Store_ID","@Cost", "@Price", "@In_Stock", "@Tax_1","@Tax_2","@Tax_3","@Dept_ID","@IsModifier","@Exclude_Acct_Limit",
									  "@Use_Serial_Numbers","@IsRental","@AutoWeigh","@FoodStampable","@ItemType","@Prompt_Price","@Prompt_Quantity","@Check_ID",
										"@Inactive","@Allow_BuyBack","@Picture","@Special_Permission","@Check_ID2","@Count_This_Item","@Print_On_Receipt","@Station_ID",
                                        "@Function","@Option1","@BackColor","@ForeColor","@Reorder_Level","@Reorder_Quantity"};
            object[] value = {OldInvent_ID, ItemNum, ItemName, Store_ID, Cost, Price, In_Stock, Tax_1, Tax_2, Tax_3, Dept_ID, IsModifier,Exclude_Acct_Limit, Use_Serial_Numbers,IsRental,
                                AutoWeigh,FoodStampable,ItemType,Prompt_Price,Prompt_Quantity,Check_ID,Inactive,Allow_BuyBack,Picture,Special_Permission,
                               Check_ID2,Count_This_Item,Print_On_Receipt, Station_ID, Function, Option1, BackColor, ForeColor,reOrderLevel,reOrderQuant };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateInventory");
            cmd.Dispose();
        }

        public DataTable GetInvoiceItemizedByItemNum(string Store_ID,string ItemNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@ItemNum" };
            string[] value = { Store_ID, ItemNum };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetInvoiceItemizedByItemNum");
            cmd.Dispose();
            return re;
        }
        public void DeleteInvoiceOnhold(string Store_ID, string InvoiceNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number" };
            string[] value = { Store_ID, InvoiceNum };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteInvoiceOnhold");
            cmd.Dispose();
        }

        public void UpdateCombine(string Store_ID, string InvoiceNum, string InvoiceNumNew)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number", "@Invoice_Number_New" };
            string[] value = { Store_ID, InvoiceNum, InvoiceNumNew };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateCombine");
            cmd.Dispose();
        }


        public DataTable GetInvoiceTotalByStoreID(string Store_ID, DateTime DateTime1, DateTime DateTime2)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@DateTime1", "@DateTime2" };
            object[] value = { Store_ID, DateTime1, DateTime2 };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetInvoiceTotalByStoreID");
            cmd.Dispose();
            return re;
        }

        public DataTable GetPrinters(string Store_ID, string Station_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Station_ID" };
            object[] value = { Store_ID,Station_ID};
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_GetPrinters");
            cmd.Dispose();
            return re;
        }

        public void InsertPrinter(string Store_ID, string Station_ID, string PrinterName,bool Disabled,bool Two_Color_Printing,bool CutReceipt,string LocalPort,string NetworkPort,string Details)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Station_ID","@PrinterName","@Disabled","@Two_Color_Printing","@CutReceipt","@LocalPort","@NetworkPort","@Details" };
            object[] value = { Store_ID, Station_ID,PrinterName,Disabled,Two_Color_Printing,CutReceipt,LocalPort,NetworkPort,Details };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_InsertPrinter");
            cmd.Dispose();
            //return re;
        }
        public void DeletePrinter(string Store_ID, string Station_ID, string PrinterName)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Station_ID", "@PrinterName" };
            object[] value = { Store_ID, Station_ID,PrinterName };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_DeletePrinter");
            cmd.Dispose();
        }
        public void UpdatePrinter(string Store_ID, string Station_ID, string PrinterName, bool Disabled, bool Two_Color_Printing, bool CutReceipt, string LocalPort, string NetworkPort, string Details)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Station_ID", "@PrinterName", "@Disabled", "@Two_Color_Printing", "@CutReceipt", "@LocalPort", "@NetworkPort", "@Details" };
            object[] value = { Store_ID, Station_ID, PrinterName, Disabled, Two_Color_Printing, CutReceipt, LocalPort, NetworkPort, Details };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdatePrinter");
            cmd.Dispose();
            //return re;
        }
        public DataTable GetPrinterByName(string Store_ID, string Station_ID, string PrinterName)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Station_ID", "@PrinterName" };
            object[] value = { Store_ID, Station_ID, PrinterName };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_GetPrinterByName");
            cmd.Dispose();
            return re;
        }
        public int GetNumOfInvoice()
        {
            cmd = new SqlCommand();
            DataTable re = FillDataset3(cmd, CommandType.Text, "select count(*) from Invoice_Totals");
            if(re.Rows.Count > 0 )
            {
                return (int) re.Rows[0][0];
            }
            cmd.Dispose();
            return 0;
        }
        public void UpdateTax(string Store_ID, decimal t1, decimal t2, decimal t3)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Tax1_Rate", "@Tax2_Rate", "@Tax3_Rate" };
            object[] value = { Store_ID, t1, t2,t3 };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateTax");
            cmd.Dispose();
        }
        public DataTable GetSetupByStore(string Store_ID)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID" };
            object[] value = { Store_ID };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_GetSetupByStore");
            cmd.Dispose();
            return re;
        }
        public void UpdateInvoiceNotes(string Store_ID, string Invoice_Notes_1,string Invoice_Notes_2,string Invoice_Notes_3,string Invoice_Notes_4,string Invoice_Notes_5,string Invoice_Notes_6,string Invoice_Notes_7,string Invoice_Notes_8,string Invoice_Notes_9,string Invoice_Notes_10)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Notes_1", "@Invoice_Notes_2", "@Invoice_Notes_3", "@Invoice_Notes_4", "@Invoice_Notes_5", "@Invoice_Notes_6", "@Invoice_Notes_7", "@Invoice_Notes_8", "@Invoice_Notes_9", "@Invoice_Notes_10" };
            object[] value = { Store_ID,Invoice_Notes_1,Invoice_Notes_2,Invoice_Notes_3,Invoice_Notes_4,Invoice_Notes_5,Invoice_Notes_6,Invoice_Notes_7,Invoice_Notes_8,Invoice_Notes_9,Invoice_Notes_10 };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateInvoiceNotes");
            cmd.Dispose();
        }
        public void UpdateLogoPath(string store_ID,string path)
        {
            cmd = new SqlCommand();
            FillDataset3(cmd, CommandType.Text, "Update Setup set Company_Info_5 ='" + path + "' where Store_ID ='"+store_ID+"'");
            cmd.Dispose();
        }
        public void InsertItemsToPrintToKit(string storeID,string InvoiceNum,string lineNum,string itemNum,string quan,string note,string itemName)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Invoice_Number","@LineNum","@Store_ID","@ItemNum","@Quantity","@Note","@ItemName" };
            string[] value = { InvoiceNum,lineNum,storeID,itemNum,quan,note,itemName };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_InsertItemsToPrintToKit");
            cmd.Dispose();
        }
        public void DeleteItemsPrintToKit(string storeID, string InvoiceNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Invoice_Number", "@Store_ID"};
            string[] value = { InvoiceNum, storeID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteItemsPrintToKit");
            cmd.Dispose();
        }
        public DataTable GetInventPrinter(string storeID, string itemNum,string printerName)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ItemNum", "@Store_ID", "@PrinterName" };
            string[] value = { itemNum, storeID,printerName };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetInventPrinters");
            cmd.Dispose();
            return re;
        }
        public DataTable GetAllInventPrinter(string storeID, string itemNum)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ItemNum", "@Store_ID" };
            string[] value = { itemNum, storeID };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_GetAllInventPrinters");
            cmd.Dispose();
            return re;
        }
        public void DeleteInventPrinter(string storeID, string itemNum,string pName)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ItemNum", "@Store_ID", "@PrinterName" };
            string[] value = { itemNum, storeID,pName };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_DeleteInventPrinter");
            cmd.Dispose();
        }
        public void DeleteAllInventPrinter(string storeID, string itemNum)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            deleteSQL = "Delete From Printers where (ItemNum = '" + itemNum + "') and ( Store_ID = '" + storeID + "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }
        public void InsertInventPrinter(string storeID, string itemNum, string pName,string port)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ItemNum", "@Store_ID", "@Port", "@PrinterName" };
            string[] value = { itemNum, storeID,port, pName };
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_InsertInventPrinter");
            cmd.Dispose();
        }

        public DataTable GetPrintersOfKitchen(string StoreId, string stationId)
        {
            cmd = new SqlCommand();
            string query = @"SELECT DISTINCT 
                      dbo.Printers.PrinterName, dbo.Printer_Mapping.Station_ID, dbo.Printer_Mapping.Store_ID, dbo.Printer_Mapping.LocalPort, 
                      dbo.Printer_Mapping.NetworkPort, dbo.Printer_Mapping.Details, dbo.Printer_Mapping.Disabled, dbo.Printer_Mapping.Two_Color_Printing, 
                      dbo.Printer_Mapping.CutReceipt
                        FROM         dbo.Printers INNER JOIN
                      dbo.Printer_Mapping ON dbo.Printers.Store_ID = dbo.Printer_Mapping.Store_ID AND dbo.Printer_Mapping.PrinterName = dbo.Printers.PrinterName "
                + " WHERE dbo.Printer_Mapping.Station_ID = '" + stationId + "' and dbo.Printer_Mapping.Store_ID = '" + StoreId+ "'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re; 
        }

        public void UpdateLogo(byte[] logo, string storeID)
        {
            
            try
            {
                cmd = new SqlCommand();
                string str = "";
                if (cmd.Parameters.Count == 0)
                {
                    str = "UPDATE Setup SET Logo = @Picture WHERE Store_ID = @storeID";
                    cmd.Parameters.Add("@storeID", System.Data.SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@Picture", System.Data.SqlDbType.Image);
                }
                cmd.Parameters["@storeID"].Value = storeID;
                cmd.Parameters["@Picture"].Value = logo;
                FillDataset3(cmd, CommandType.Text, str);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;

            }

        }
        #region DeleteInvoices
        public void ClearAllInvoice(string storeId)
        {
            cmd = new SqlCommand();
            string deleteSQL ;
            //FillDataset3(cmd, CommandType.Text, deleteSQL);
            deleteSQL = "Delete From Invoice_Itemized where Store_ID ='" + storeId + "'";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            deleteSQL = "Delete From Invoice_Totals_Notes where Store_ID ='" + storeId + "'";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            deleteSQL = "Delete From Invoice_Totals where Store_ID ='" + storeId + "'";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            deleteSQL = "Update Setup_Corp set LastIN = '0'";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }


        public int OnholdNumber(string storeId)
        {
            cmd = new SqlCommand();
            string query = "Select count(*) from Invoice_OnHold where Store_ID ='"+ storeId+"'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return Convert.ToInt32(re.Rows[0][0]);
        }

        public DataTable GetInvoiceOnholdByTime(string storeId,DateTime startDate, DateTime endDate)
        {
            cmd = new SqlCommand();
            string query = @"SELECT     dbo.Invoice_OnHold.*, dbo.Invoice_Totals.DateTime
                             FROM         dbo.Invoice_OnHold INNER JOIN
                                dbo.Invoice_Totals ON dbo.Invoice_OnHold.Store_ID = dbo.Invoice_Totals.Store_ID AND 
                                dbo.Invoice_OnHold.Invoice_Number = dbo.Invoice_Totals.Invoice_Number "
                                + " Where dbo.Invoice_Totals.DateTime between '" + startDate + "' and '" + endDate+ "'" ;
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public void ClearAllInvoiceByDate(string storeId,DateTime startDate, DateTime endDate)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            //FillDataset3(cmd, CommandType.Text, deleteSQL);
            deleteSQL = @"delete FROM  dbo.Invoice_Totals_Notes 
                        where dbo.Invoice_Totals_Notes.Invoice_Number in (SELECT     Invoice_Number
													FROM         dbo.Invoice_Totals
													WHERE Store_ID = '" + storeId+"' and  dbo.Invoice_Totals.DateTime between '" + startDate + "' and '" + endDate + "') and dbo.Invoice_Totals_Notes.Store_ID = '"
                            + storeId + "' ";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            deleteSQL = @"delete FROM  dbo.Invoice_Itemized 
                        where dbo.Invoice_Itemized.Invoice_Number in (SELECT     Invoice_Number
													FROM         dbo.Invoice_Totals
													WHERE Store_ID = '" + storeId + "' and  dbo.Invoice_Totals.DateTime between '" + startDate + "' and '" + endDate + "') and dbo.Invoice_Itemized.Store_ID = '"
                            + storeId + "' ";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            deleteSQL = "Delete From Invoice_Totals where Store_ID ='" + storeId + "' and Invoice_Totals.DateTime between '" + startDate + "' and '" + endDate + "'";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }

        #endregion
        public void UpdateAdminPass(string StoreId,string NewPass)
        {
            cmd = new SqlCommand();
            string query = "Update Setup Set Admin_Pass = '" + NewPass + "' where Store_ID ='" + StoreId+"'";
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public void UpdateAdminSwipe(string StoreId, string NewSwipe)
        {
            cmd = new SqlCommand();
            string query = "Update Setup Set Admin_Swipe = '" + NewSwipe + "' where Store_ID ='" + StoreId + "'";
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }
        #region Employees
        public DataTable GetAllEmployee(string storeId)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID" };
            object[] value = { storeId };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetAllEmployee");
            cmd.Dispose();
            return re;
        }
        public DataTable GetAllDepartmentsByType(string storeId, byte Type)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Type" };
            object[] value = { storeId, Type };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetAllDepartmentsByType");
            cmd.Dispose();
            return re;
        }

        public DataTable GetEmployeeByID(string storeId, string casherId)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Cashier_ID" };
            object[] value = { storeId, casherId };
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_GetEmployeeByID");
            cmd.Dispose();
            return re;
        }
        public DataTable CreateEmployee(string @Cashier_ID,
                                        string @CustNum,
                                        string @Dept_ID,
                                        string @Password,
                                        string @Swipe_ID,
                                        string @Hourly_Wage,
                                        int @Form_Color,
                                        string @CFA_Setup_Company,
                                        string @CFA_Setup_Tax,
                                        string @CFA_Setup_Bonus,
                                        string @CFA_Setup_Accounting,
                                        string @CFA_Setup_Discounts,
                                        string @CFA_Setup_Display,
                                        string @CFA_Setup_DefPrinter,
                                        string @CFA_Inven_Add,
                                        string @CFA_Inven_Edit,
                                        string @CFA_Vendors_Add,
                                        string @CFA_Vendors_Edit,
                                        string @CFA_Depts_Add,
                                        string @CFA_Depts_Edit,
                                        string @CFA_Inven_TickVouch,
                                        string @CFA_Cust_add,
                                        string @CFA_Cust_Edit,
                                        string @CFA_Reports_Display,
                                        string @CFA_Reports_DDR,
                                        string @CFA_Reports_Print,
                                        string @CFA_Invoice_Discount,
                                        string @CFA_Invoice_PriceChange,
                                        string @CFA_Invoice_DeleteItems,
                                        string @CFA_Invoice_Void,
                                        string @CFA_CRE_Acct,
                                        string @CFA_CRE_Exit,
                                        bool @Dirty,
                                        string @CFA_Display_Balance,
                                        string @CFA_Refund_Item,
                                        bool @Disp_Pay_Option,
                                        bool @Disp_Item_Option,
                                        string @EmpName,
                                        string @CFA_Receive_Items,
                                        string @CFA_DO_POS,
                                        string @CFA_INSTANT_POS,
                                        string @Section_ID,
                                        string @CFA_Other_Tables,
                                        string @CFA_Accept_Cash,
                                        string @CFA_TRANSFER_NOSWIPE,
                                        string @CFA_ADD_CCTIPS,
                                        bool @Disabled,
                                        bool @Admin_Access,
                                        string @CFA_PRINT_HOLD,
                                        string @CFA_Open_Cash_Drawer,
                                        bool @CCTipsNow,
                                        bool @ReqClockIn,
                                        string @CFA_Split_Checks,
                                        string @CFA_Transfer_Tables,
                                        string @CFA_Extra_Item,
                                        string @CFA_Tax_Exempt,
                                        string @CFA_GC_Sell,
                                        string @CFA_GC_Redeem,
                                        string @CFA_SELL_SPECIAL_ITEM,
                                        string @CFA_VENDOR_PAYOUT,
                                        string @CFA_APPLY_GRATUITY,
                                        string @First_Name,
                                        string @Middle_Name,
                                        string @Last_Name,
                                        string @SSN,
                                        string @Address_1,
                                        string @Address_2,
                                        string @City,
                                        string @State,
                                        string @Zip_Code,
                                        string @Phone_1,
                                        string @EMail,
                                        DateTime @Birthday,
                                        string @Picture,
                                        string @CFA_BUYBACKS_TRADES,
                                        string @CFA_CC_Force,
                                        string @CFA_CC_Below_Floor,
                                        string @Current_Cash,
                                        string @CFA_Cash_Alerts,
                                        string @CFA_Cash_Pickup,
                                        string @CDL_Stations_ID,
                                        string @CFA_Issue_Credit_Slip,
                                        string @CFA_Redeem_Credit_Slip,
                                        string @CFA_REFUND_OVERRIDE,
                                        string @CFA_DRAWER_TRANSFER,
                                        string @CFA_LARGE_PURCHASES,
                                        string @CFA_AUCTION_PHOTO,
                                        string @CFA_AUCTION_LISTREDEEM,
                                        string @CFA_AUCTION_SHIP,
                                        string @CFA_APPROVE_CASHCOUNT,
                                        string @Orig_Emp_ID,
                                        string @Orig_Store_ID,
                                        string @CD_Name,
                                        string @CFA_APPROVE_OLD_RETURNS,
                                        string @CFA_APPROVE_EMERGENCY_CLOCKOUT,
                                        float @TimeWorkedThisPeriod,
                                        byte @OvertimeThreshold,
                                        string @CFA_PULLBACK_INVOICE,
                                        string @CFA_MANAGE_TIMECLOCK,
                                        string @CFA_PERFORM_ENDOFDAY,
                                        string @CFA_HOST_LOGIN,
                                        string @CFA_REST_OPENTABS,
                                        string @CFA_REST_TAKEOUT,
                                        string @CFA_REST_DELIVERY,
                                        string @CFA_INVOICE_DELETESENT,
                                        string @CFA_INVEN_VIEW,
                                        string @CFA_INVEN_VIEWCOST,
                                        string @CFA_INVEN_NEGATIVE_INSTANTPOS,
                                        string @CFA_ENDTRANS_CASH,
                                        string @CFA_ENDTRANS_ACCOUNT,
                                        string @CFA_REST_COMP,
                                        string @CFA_CH_FORCE,
                                        string @CFA_TS_CONFIG,
                                        string @CFA_TRANSFER_SERVER,
                                        string @CFA_BACKUP_DATABASE,
                                        string @CFA_CREDIT_CARD_SETTLEMENT,
                                        string @CFA_KITCHEN_REPRINT,
                                        string @CFA_SETUP_RECEIPT_NOTES,
                                        string @CFA_MANAGE_TIMECLOCK_OWNTIME,
                                        string @CFA_SETUP_ADD_EMPLOYEES,
                                        string @CFA_SETUP_EDIT_EMPLOYEES,
                                        string @CFA_INVENTORY_PROMOTIONS,
                                        string @CFA_INVOICE_DISCOUNTS_BELOW_X,
                                        string @CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT,
                                        string @CFA_REPORTS_VIEW_HISTORICAL_DATA,
                                        string @CFA_INVEN_MISC_FIELD_LOCKDOWN)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Cashier_ID" , 
	                        "@CustNum" ,
	                        "@Dept_ID" ,
	                        "@Password",
	                        "@Swipe_ID" ,
	                        "@Hourly_Wage",
	                        "@Form_Color" ,
	                        "@CFA_Setup_Company" ,
	                        "@CFA_Setup_Tax" ,
	                        "@CFA_Setup_Bonus" ,
	                        "@CFA_Setup_Accounting" ,
	                        "@CFA_Setup_Discounts" ,
	                        "@CFA_Setup_Display" ,
	                        "@CFA_Setup_DefPrinter" ,
	                        "@CFA_Inven_Add" ,
	                        "@CFA_Inven_Edit" ,
	                        "@CFA_Vendors_Add" ,
	                        "@CFA_Vendors_Edit" ,
	                        "@CFA_Depts_Add" ,
	                        "@CFA_Depts_Edit",
	                        "@CFA_Inven_TickVouch" ,
	                        "@CFA_Cust_add" ,
	                        "@CFA_Cust_Edit" ,
	                        "@CFA_Reports_Display" ,
	                        "@CFA_Reports_DDR" ,
	                        "@CFA_Reports_Print" ,
	                        "@CFA_Invoice_Discount",
	                        "@CFA_Invoice_PriceChange",
	                        "@CFA_Invoice_DeleteItems" ,
	                        "@CFA_Invoice_Void" ,
	                        "@CFA_CRE_Acct" ,
	                        "@CFA_CRE_Exit",
	                        "@Dirty" ,
	                        "@CFA_Display_Balance" ,
	                        "@CFA_Refund_Item" ,
	                        "@Disp_Pay_Option" ,
	                        "@Disp_Item_Option" ,
	                        "@EmpName" ,
	                        "@CFA_Receive_Items" ,
	                        "@CFA_DO_POS" ,
	                        "@CFA_INSTANT_POS" ,
	                        "@Section_ID" ,
	                        "@CFA_Other_Tables" ,
	                        "@CFA_Accept_Cash" ,
	                        "@CFA_TRANSFER_NOSWIPE" ,
	                        "@CFA_ADD_CCTIPS" ,
	                        "@Disabled" ,
	                        "@Admin_Access" ,	
	                        "@CFA_PRINT_HOLD" ,
	                        "@CFA_Open_Cash_Drawer",
	                        "@CCTipsNow" ,
	                        "@ReqClockIn" ,
	                        "@CFA_Split_Checks" ,
	                        "@CFA_Transfer_Tables" ,
	                        "@CFA_Extra_Item" ,
	                        "@CFA_Tax_Exempt" ,
	                        "@CFA_GC_Sell" ,
	                        "@CFA_GC_Redeem" ,
	                        "@CFA_SELL_SPECIAL_ITEM" ,
	                        "@CFA_VENDOR_PAYOUT" ,
	                        "@CFA_APPLY_GRATUITY" ,
	                        "@First_Name" ,
	                        "@Middle_Name" ,
	                        "@Last_Name" ,
	                        "@SSN" ,
	                        "@Address_1" ,
	                        "@Address_2",
	                        "@City" ,
	                        "@State" ,
	                        "@Zip_Code" ,
	                        "@Phone_1",
	                        "@EMail" ,
	                        "@Birthday" ,
	                        "@Picture" ,
	                        "@CFA_BUYBACKS_TRADES" ,
	                        "@CFA_CC_Force" ,
	                        "@CFA_CC_Below_Floor" ,
	                        "@Current_Cash" ,
	                        "@CFA_Cash_Alerts" ,
	                        "@CFA_Cash_Pickup" ,
	                        "@CDL_Stations_ID" ,
	                        "@CFA_Issue_Credit_Slip" ,
	                        "@CFA_Redeem_Credit_Slip" ,
	                        "@CFA_REFUND_OVERRIDE" ,
	                        "@CFA_DRAWER_TRANSFER" ,
	                        "@CFA_LARGE_PURCHASES" ,
	                        "@CFA_AUCTION_PHOTO" ,
	                        "@CFA_AUCTION_LISTREDEEM" ,
	                        "@CFA_AUCTION_SHIP" ,
	                        "@CFA_APPROVE_CASHCOUNT" ,
	                        "@Orig_Emp_ID" ,
	                        "@Orig_Store_ID" ,
	                        "@CD_Name" ,
	                        "@CFA_APPROVE_OLD_RETURNS" ,
	                        "@CFA_APPROVE_EMERGENCY_CLOCKOUT" ,
	                        "@TimeWorkedThisPeriod" ,
	                        "@OvertimeThreshold" ,
	                        "@CFA_PULLBACK_INVOICE" ,
	                        "@CFA_MANAGE_TIMECLOCK" ,
	                        "@CFA_PERFORM_ENDOFDAY" ,
	                        "@CFA_HOST_LOGIN" ,
	                        "@CFA_REST_OPENTABS" ,
	                        "@CFA_REST_TAKEOUT" ,
	                        "@CFA_REST_DELIVERY" ,
	                        "@CFA_INVOICE_DELETESENT" ,
	                        "@CFA_INVEN_VIEW" ,
	                        "@CFA_INVEN_VIEWCOST" ,
	                        "@CFA_INVEN_NEGATIVE_INSTANTPOS" ,
	                        "@CFA_ENDTRANS_CASH" ,
	                        "@CFA_ENDTRANS_ACCOUNT" ,
	                        "@CFA_REST_COMP" ,
	                        "@CFA_CH_FORCE" ,
	                        "@CFA_TS_CONFIG" ,
	                        "@CFA_TRANSFER_SERVER" ,
	                        "@CFA_BACKUP_DATABASE" ,
	                        "@CFA_CREDIT_CARD_SETTLEMENT" ,
	                        "@CFA_KITCHEN_REPRINT" ,
	                        "@CFA_SETUP_RECEIPT_NOTES" ,
	                        "@CFA_MANAGE_TIMECLOCK_OWNTIME" ,
	                        "@CFA_SETUP_ADD_EMPLOYEES" ,
	                        "@CFA_SETUP_EDIT_EMPLOYEES" ,
	                        "@CFA_INVENTORY_PROMOTIONS" ,
	                        "@CFA_INVOICE_DISCOUNTS_BELOW_X" ,
	                        "@CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT" ,
	                        "@CFA_REPORTS_VIEW_HISTORICAL_DATA" ,
	                        "@CFA_INVEN_MISC_FIELD_LOCKDOWN"};
            object[] value ={@Cashier_ID , 
	                            @CustNum ,
	                            @Dept_ID ,
	                            @Password ,
	                            @Swipe_ID ,
	                            @Hourly_Wage,
	                            @Form_Color ,
	                            @CFA_Setup_Company ,
	                            @CFA_Setup_Tax ,
	                            @CFA_Setup_Bonus ,
	                            @CFA_Setup_Accounting ,
	                            @CFA_Setup_Discounts ,
	                            @CFA_Setup_Display ,
	                            @CFA_Setup_DefPrinter ,
	                            @CFA_Inven_Add ,
	                            @CFA_Inven_Edit ,
	                            @CFA_Vendors_Add ,
	                            @CFA_Vendors_Edit ,
	                            @CFA_Depts_Add ,
	                            @CFA_Depts_Edit,
	                            @CFA_Inven_TickVouch ,
	                            @CFA_Cust_add ,
	                            @CFA_Cust_Edit ,
	                            @CFA_Reports_Display ,
	                            @CFA_Reports_DDR ,
	                            @CFA_Reports_Print ,
	                            @CFA_Invoice_Discount,
	                            @CFA_Invoice_PriceChange,
	                            @CFA_Invoice_DeleteItems ,
	                            @CFA_Invoice_Void ,
	                            @CFA_CRE_Acct ,
	                            @CFA_CRE_Exit,
	                            @Dirty ,
	                            @CFA_Display_Balance ,
	                            @CFA_Refund_Item ,
	                            @Disp_Pay_Option ,
	                            @Disp_Item_Option ,
	                            @EmpName ,
	                            @CFA_Receive_Items ,
	                            @CFA_DO_POS ,
	                            @CFA_INSTANT_POS ,
	                            @Section_ID ,
	                            @CFA_Other_Tables ,
	                            @CFA_Accept_Cash ,
	                            @CFA_TRANSFER_NOSWIPE ,
	                            @CFA_ADD_CCTIPS ,
	                            @Disabled ,
	                            @Admin_Access ,	
	                            @CFA_PRINT_HOLD ,
	                            @CFA_Open_Cash_Drawer,
	                            @CCTipsNow ,
	                            @ReqClockIn ,
	                            @CFA_Split_Checks ,
	                            @CFA_Transfer_Tables ,
	                            @CFA_Extra_Item ,
	                            @CFA_Tax_Exempt ,
	                            @CFA_GC_Sell ,
	                            @CFA_GC_Redeem ,
	                            @CFA_SELL_SPECIAL_ITEM ,
	                            @CFA_VENDOR_PAYOUT ,
	                            @CFA_APPLY_GRATUITY ,
	                            @First_Name ,
	                            @Middle_Name ,
	                            @Last_Name ,
	                            @SSN ,
	                            @Address_1 ,
	                            @Address_2,
	                            @City ,
	                            @State ,
	                            @Zip_Code ,
	                            @Phone_1,
	                            @EMail ,
	                            @Birthday ,
	                            @Picture ,
	                            @CFA_BUYBACKS_TRADES ,
	                            @CFA_CC_Force ,
	                            @CFA_CC_Below_Floor ,
	                            @Current_Cash ,
	                            @CFA_Cash_Alerts ,
	                            @CFA_Cash_Pickup ,
	                            @CDL_Stations_ID ,
	                            @CFA_Issue_Credit_Slip ,
	                            @CFA_Redeem_Credit_Slip ,
	                            @CFA_REFUND_OVERRIDE ,
	                            @CFA_DRAWER_TRANSFER ,
	                            @CFA_LARGE_PURCHASES ,
	                            @CFA_AUCTION_PHOTO ,
	                            @CFA_AUCTION_LISTREDEEM ,
	                            @CFA_AUCTION_SHIP ,
	                            @CFA_APPROVE_CASHCOUNT ,
	                            @Orig_Emp_ID ,
	                            @Orig_Store_ID ,
	                            @CD_Name ,
	                            @CFA_APPROVE_OLD_RETURNS ,
	                            @CFA_APPROVE_EMERGENCY_CLOCKOUT ,
	                            @TimeWorkedThisPeriod ,
	                            @OvertimeThreshold ,
	                            @CFA_PULLBACK_INVOICE ,
	                            @CFA_MANAGE_TIMECLOCK ,
	                            @CFA_PERFORM_ENDOFDAY ,
	                            @CFA_HOST_LOGIN ,
	                            @CFA_REST_OPENTABS ,
	                            @CFA_REST_TAKEOUT ,
	                            @CFA_REST_DELIVERY ,
	                            @CFA_INVOICE_DELETESENT ,
	                            @CFA_INVEN_VIEW ,
	                            @CFA_INVEN_VIEWCOST ,
	                            @CFA_INVEN_NEGATIVE_INSTANTPOS ,
	                            @CFA_ENDTRANS_CASH ,
	                            @CFA_ENDTRANS_ACCOUNT ,
	                            @CFA_REST_COMP ,
	                            @CFA_CH_FORCE ,
	                            @CFA_TS_CONFIG ,
	                            @CFA_TRANSFER_SERVER ,
	                            @CFA_BACKUP_DATABASE ,
	                            @CFA_CREDIT_CARD_SETTLEMENT ,
	                            @CFA_KITCHEN_REPRINT ,
	                            @CFA_SETUP_RECEIPT_NOTES ,
	                            @CFA_MANAGE_TIMECLOCK_OWNTIME ,
	                            @CFA_SETUP_ADD_EMPLOYEES ,
	                            @CFA_SETUP_EDIT_EMPLOYEES ,
	                            @CFA_INVENTORY_PROMOTIONS ,
	                            @CFA_INVOICE_DISCOUNTS_BELOW_X ,
	                            @CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT ,
	                            @CFA_REPORTS_VIEW_HISTORICAL_DATA ,
	                            @CFA_INVEN_MISC_FIELD_LOCKDOWN};
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_CreateEmployee");
            cmd.Dispose();
            return re;
        }
        public void DeleteEmployee(string casherId, string storeID)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            deleteSQL = "Delete From Employee where (Cashier_ID ='" + casherId + "') and ( Orig_Store_ID = '" + storeID + "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }
        public void UpdateEmployee(string @Cashier_ID,
                                        string @CustNum,
                                        string @Dept_ID,
                                        string @Password,
                                        string @Swipe_ID,
                                        string @Hourly_Wage,
                                        int @Form_Color,
                                        string @CFA_Setup_Company,
                                        string @CFA_Setup_Tax,
                                        string @CFA_Setup_Bonus,
                                        string @CFA_Setup_Accounting,
                                        string @CFA_Setup_Discounts,
                                        string @CFA_Setup_Display,
                                        string @CFA_Setup_DefPrinter,
                                        string @CFA_Inven_Add,
                                        string @CFA_Inven_Edit,
                                        string @CFA_Vendors_Add,
                                        string @CFA_Vendors_Edit,
                                        string @CFA_Depts_Add,
                                        string @CFA_Depts_Edit,
                                        string @CFA_Inven_TickVouch,
                                        string @CFA_Cust_add,
                                        string @CFA_Cust_Edit,
                                        string @CFA_Reports_Display,
                                        string @CFA_Reports_DDR,
                                        string @CFA_Reports_Print,
                                        string @CFA_Invoice_Discount,
                                        string @CFA_Invoice_PriceChange,
                                        string @CFA_Invoice_DeleteItems,
                                        string @CFA_Invoice_Void,
                                        string @CFA_CRE_Acct,
                                        string @CFA_CRE_Exit,
                                        bool @Dirty,
                                        string @CFA_Display_Balance,
                                        string @CFA_Refund_Item,
                                        bool @Disp_Pay_Option,
                                        bool @Disp_Item_Option,
                                        string @EmpName,
                                        string @CFA_Receive_Items,
                                        string @CFA_DO_POS,
                                        string @CFA_INSTANT_POS,
                                        string @Section_ID,
                                        string @CFA_Other_Tables,
                                        string @CFA_Accept_Cash,
                                        string @CFA_TRANSFER_NOSWIPE,
                                        string @CFA_ADD_CCTIPS,
                                        bool @Disabled,
                                        bool @Admin_Access,
                                        string @CFA_PRINT_HOLD,
                                        string @CFA_Open_Cash_Drawer,
                                        bool @CCTipsNow,
                                        bool @ReqClockIn,
                                        string @CFA_Split_Checks,
                                        string @CFA_Transfer_Tables,
                                        string @CFA_Extra_Item,
                                        string @CFA_Tax_Exempt,
                                        string @CFA_GC_Sell,
                                        string @CFA_GC_Redeem,
                                        string @CFA_SELL_SPECIAL_ITEM,
                                        string @CFA_VENDOR_PAYOUT,
                                        string @CFA_APPLY_GRATUITY,
                                        string @First_Name,
                                        string @Middle_Name,
                                        string @Last_Name,
                                        string @SSN,
                                        string @Address_1,
                                        string @Address_2,
                                        string @City,
                                        string @State,
                                        string @Zip_Code,
                                        string @Phone_1,
                                        string @EMail,
                                        DateTime @Birthday,
                                        string @Picture,
                                        string @CFA_BUYBACKS_TRADES,
                                        string @CFA_CC_Force,
                                        string @CFA_CC_Below_Floor,
                                        string @Current_Cash,
                                        string @CFA_Cash_Alerts,
                                        string @CFA_Cash_Pickup,
                                        string @CDL_Stations_ID,
                                        string @CFA_Issue_Credit_Slip,
                                        string @CFA_Redeem_Credit_Slip,
                                        string @CFA_REFUND_OVERRIDE,
                                        string @CFA_DRAWER_TRANSFER,
                                        string @CFA_LARGE_PURCHASES,
                                        string @CFA_AUCTION_PHOTO,
                                        string @CFA_AUCTION_LISTREDEEM,
                                        string @CFA_AUCTION_SHIP,
                                        string @CFA_APPROVE_CASHCOUNT,
                                        string @Orig_Emp_ID,
                                        string @Orig_Store_ID,
                                        string @CD_Name,
                                        string @CFA_APPROVE_OLD_RETURNS,
                                        string @CFA_APPROVE_EMERGENCY_CLOCKOUT,
                                        float @TimeWorkedThisPeriod,
                                        byte @OvertimeThreshold,
                                        string @CFA_PULLBACK_INVOICE,
                                        string @CFA_MANAGE_TIMECLOCK,
                                        string @CFA_PERFORM_ENDOFDAY,
                                        string @CFA_HOST_LOGIN,
                                        string @CFA_REST_OPENTABS,
                                        string @CFA_REST_TAKEOUT,
                                        string @CFA_REST_DELIVERY,
                                        string @CFA_INVOICE_DELETESENT,
                                        string @CFA_INVEN_VIEW,
                                        string @CFA_INVEN_VIEWCOST,
                                        string @CFA_INVEN_NEGATIVE_INSTANTPOS,
                                        string @CFA_ENDTRANS_CASH,
                                        string @CFA_ENDTRANS_ACCOUNT,
                                        string @CFA_REST_COMP,
                                        string @CFA_CH_FORCE,
                                        string @CFA_TS_CONFIG,
                                        string @CFA_TRANSFER_SERVER,
                                        string @CFA_BACKUP_DATABASE,
                                        string @CFA_CREDIT_CARD_SETTLEMENT,
                                        string @CFA_KITCHEN_REPRINT,
                                        string @CFA_SETUP_RECEIPT_NOTES,
                                        string @CFA_MANAGE_TIMECLOCK_OWNTIME,
                                        string @CFA_SETUP_ADD_EMPLOYEES,
                                        string @CFA_SETUP_EDIT_EMPLOYEES,
                                        string @CFA_INVENTORY_PROMOTIONS,
                                        string @CFA_INVOICE_DISCOUNTS_BELOW_X,
                                        string @CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT,
                                        string @CFA_REPORTS_VIEW_HISTORICAL_DATA,
                                        string @CFA_INVEN_MISC_FIELD_LOCKDOWN)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Cashier_ID" , 
	                        "@CustNum" ,
	                        "@Dept_ID" ,
	                        "@Password",
	                        "@Swipe_ID" ,
	                        "@Hourly_Wage",
	                        "@Form_Color" ,
	                        "@CFA_Setup_Company" ,
	                        "@CFA_Setup_Tax" ,
	                        "@CFA_Setup_Bonus" ,
	                        "@CFA_Setup_Accounting" ,
	                        "@CFA_Setup_Discounts" ,
	                        "@CFA_Setup_Display" ,
	                        "@CFA_Setup_DefPrinter" ,
	                        "@CFA_Inven_Add" ,
	                        "@CFA_Inven_Edit" ,
	                        "@CFA_Vendors_Add" ,
	                        "@CFA_Vendors_Edit" ,
	                        "@CFA_Depts_Add" ,
	                        "@CFA_Depts_Edit",
	                        "@CFA_Inven_TickVouch" ,
	                        "@CFA_Cust_add" ,
	                        "@CFA_Cust_Edit" ,
	                        "@CFA_Reports_Display" ,
	                        "@CFA_Reports_DDR" ,
	                        "@CFA_Reports_Print" ,
	                        "@CFA_Invoice_Discount",
	                        "@CFA_Invoice_PriceChange",
	                        "@CFA_Invoice_DeleteItems" ,
	                        "@CFA_Invoice_Void" ,
	                        "@CFA_CRE_Acct" ,
	                        "@CFA_CRE_Exit",
	                        "@Dirty" ,
	                        "@CFA_Display_Balance" ,
	                        "@CFA_Refund_Item" ,
	                        "@Disp_Pay_Option" ,
	                        "@Disp_Item_Option" ,
	                        "@EmpName" ,
	                        "@CFA_Receive_Items" ,
	                        "@CFA_DO_POS" ,
	                        "@CFA_INSTANT_POS" ,
	                        "@Section_ID" ,
	                        "@CFA_Other_Tables" ,
	                        "@CFA_Accept_Cash" ,
	                        "@CFA_TRANSFER_NOSWIPE" ,
	                        "@CFA_ADD_CCTIPS" ,
	                        "@Disabled" ,
	                        "@Admin_Access" ,	
	                        "@CFA_PRINT_HOLD" ,
	                        "@CFA_Open_Cash_Drawer",
	                        "@CCTipsNow" ,
	                        "@ReqClockIn" ,
	                        "@CFA_Split_Checks" ,
	                        "@CFA_Transfer_Tables" ,
	                        "@CFA_Extra_Item" ,
	                        "@CFA_Tax_Exempt" ,
	                        "@CFA_GC_Sell" ,
	                        "@CFA_GC_Redeem" ,
	                        "@CFA_SELL_SPECIAL_ITEM" ,
	                        "@CFA_VENDOR_PAYOUT" ,
	                        "@CFA_APPLY_GRATUITY" ,
	                        "@First_Name" ,
	                        "@Middle_Name" ,
	                        "@Last_Name" ,
	                        "@SSN" ,
	                        "@Address_1" ,
	                        "@Address_2",
	                        "@City" ,
	                        "@State" ,
	                        "@Zip_Code" ,
	                        "@Phone_1",
	                        "@EMail" ,
	                        "@Birthday" ,
	                        "@Picture" ,
	                        "@CFA_BUYBACKS_TRADES" ,
	                        "@CFA_CC_Force" ,
	                        "@CFA_CC_Below_Floor" ,
	                        "@Current_Cash" ,
	                        "@CFA_Cash_Alerts" ,
	                        "@CFA_Cash_Pickup" ,
	                        "@CDL_Stations_ID" ,
	                        "@CFA_Issue_Credit_Slip" ,
	                        "@CFA_Redeem_Credit_Slip" ,
	                        "@CFA_REFUND_OVERRIDE" ,
	                        "@CFA_DRAWER_TRANSFER" ,
	                        "@CFA_LARGE_PURCHASES" ,
	                        "@CFA_AUCTION_PHOTO" ,
	                        "@CFA_AUCTION_LISTREDEEM" ,
	                        "@CFA_AUCTION_SHIP" ,
	                        "@CFA_APPROVE_CASHCOUNT" ,
	                        "@Orig_Emp_ID" ,
	                        "@Orig_Store_ID" ,
	                        "@CD_Name" ,
	                        "@CFA_APPROVE_OLD_RETURNS" ,
	                        "@CFA_APPROVE_EMERGENCY_CLOCKOUT" ,
	                        "@TimeWorkedThisPeriod" ,
	                        "@OvertimeThreshold" ,
	                        "@CFA_PULLBACK_INVOICE" ,
	                        "@CFA_MANAGE_TIMECLOCK" ,
	                        "@CFA_PERFORM_ENDOFDAY" ,
	                        "@CFA_HOST_LOGIN" ,
	                        "@CFA_REST_OPENTABS" ,
	                        "@CFA_REST_TAKEOUT" ,
	                        "@CFA_REST_DELIVERY" ,
	                        "@CFA_INVOICE_DELETESENT" ,
	                        "@CFA_INVEN_VIEW" ,
	                        "@CFA_INVEN_VIEWCOST" ,
	                        "@CFA_INVEN_NEGATIVE_INSTANTPOS" ,
	                        "@CFA_ENDTRANS_CASH" ,
	                        "@CFA_ENDTRANS_ACCOUNT" ,
	                        "@CFA_REST_COMP" ,
	                        "@CFA_CH_FORCE" ,
	                        "@CFA_TS_CONFIG" ,
	                        "@CFA_TRANSFER_SERVER" ,
	                        "@CFA_BACKUP_DATABASE" ,
	                        "@CFA_CREDIT_CARD_SETTLEMENT" ,
	                        "@CFA_KITCHEN_REPRINT" ,
	                        "@CFA_SETUP_RECEIPT_NOTES" ,
	                        "@CFA_MANAGE_TIMECLOCK_OWNTIME" ,
	                        "@CFA_SETUP_ADD_EMPLOYEES" ,
	                        "@CFA_SETUP_EDIT_EMPLOYEES" ,
	                        "@CFA_INVENTORY_PROMOTIONS" ,
	                        "@CFA_INVOICE_DISCOUNTS_BELOW_X" ,
	                        "@CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT" ,
	                        "@CFA_REPORTS_VIEW_HISTORICAL_DATA" ,
	                        "@CFA_INVEN_MISC_FIELD_LOCKDOWN"};
            object[] value ={@Cashier_ID , 
	                            @CustNum ,
	                            @Dept_ID ,
	                            @Password ,
	                            @Swipe_ID ,
	                            @Hourly_Wage,
	                            @Form_Color ,
	                            @CFA_Setup_Company ,
	                            @CFA_Setup_Tax ,
	                            @CFA_Setup_Bonus ,
	                            @CFA_Setup_Accounting ,
	                            @CFA_Setup_Discounts ,
	                            @CFA_Setup_Display ,
	                            @CFA_Setup_DefPrinter ,
	                            @CFA_Inven_Add ,
	                            @CFA_Inven_Edit ,
	                            @CFA_Vendors_Add ,
	                            @CFA_Vendors_Edit ,
	                            @CFA_Depts_Add ,
	                            @CFA_Depts_Edit,
	                            @CFA_Inven_TickVouch ,
	                            @CFA_Cust_add ,
	                            @CFA_Cust_Edit ,
	                            @CFA_Reports_Display ,
	                            @CFA_Reports_DDR ,
	                            @CFA_Reports_Print ,
	                            @CFA_Invoice_Discount,
	                            @CFA_Invoice_PriceChange,
	                            @CFA_Invoice_DeleteItems ,
	                            @CFA_Invoice_Void ,
	                            @CFA_CRE_Acct ,
	                            @CFA_CRE_Exit,
	                            @Dirty ,
	                            @CFA_Display_Balance ,
	                            @CFA_Refund_Item ,
	                            @Disp_Pay_Option ,
	                            @Disp_Item_Option ,
	                            @EmpName ,
	                            @CFA_Receive_Items ,
	                            @CFA_DO_POS ,
	                            @CFA_INSTANT_POS ,
	                            @Section_ID ,
	                            @CFA_Other_Tables ,
	                            @CFA_Accept_Cash ,
	                            @CFA_TRANSFER_NOSWIPE ,
	                            @CFA_ADD_CCTIPS ,
	                            @Disabled ,
	                            @Admin_Access ,	
	                            @CFA_PRINT_HOLD ,
	                            @CFA_Open_Cash_Drawer,
	                            @CCTipsNow ,
	                            @ReqClockIn ,
	                            @CFA_Split_Checks ,
	                            @CFA_Transfer_Tables ,
	                            @CFA_Extra_Item ,
	                            @CFA_Tax_Exempt ,
	                            @CFA_GC_Sell ,
	                            @CFA_GC_Redeem ,
	                            @CFA_SELL_SPECIAL_ITEM ,
	                            @CFA_VENDOR_PAYOUT ,
	                            @CFA_APPLY_GRATUITY ,
	                            @First_Name ,
	                            @Middle_Name ,
	                            @Last_Name ,
	                            @SSN ,
	                            @Address_1 ,
	                            @Address_2,
	                            @City ,
	                            @State ,
	                            @Zip_Code ,
	                            @Phone_1,
	                            @EMail ,
	                            @Birthday ,
	                            @Picture ,
	                            @CFA_BUYBACKS_TRADES ,
	                            @CFA_CC_Force ,
	                            @CFA_CC_Below_Floor ,
	                            @Current_Cash ,
	                            @CFA_Cash_Alerts ,
	                            @CFA_Cash_Pickup ,
	                            @CDL_Stations_ID ,
	                            @CFA_Issue_Credit_Slip ,
	                            @CFA_Redeem_Credit_Slip ,
	                            @CFA_REFUND_OVERRIDE ,
	                            @CFA_DRAWER_TRANSFER ,
	                            @CFA_LARGE_PURCHASES ,
	                            @CFA_AUCTION_PHOTO ,
	                            @CFA_AUCTION_LISTREDEEM ,
	                            @CFA_AUCTION_SHIP ,
	                            @CFA_APPROVE_CASHCOUNT ,
	                            @Orig_Emp_ID ,
	                            @Orig_Store_ID ,
	                            @CD_Name ,
	                            @CFA_APPROVE_OLD_RETURNS ,
	                            @CFA_APPROVE_EMERGENCY_CLOCKOUT ,
	                            @TimeWorkedThisPeriod ,
	                            @OvertimeThreshold ,
	                            @CFA_PULLBACK_INVOICE ,
	                            @CFA_MANAGE_TIMECLOCK ,
	                            @CFA_PERFORM_ENDOFDAY ,
	                            @CFA_HOST_LOGIN ,
	                            @CFA_REST_OPENTABS ,
	                            @CFA_REST_TAKEOUT ,
	                            @CFA_REST_DELIVERY ,
	                            @CFA_INVOICE_DELETESENT ,
	                            @CFA_INVEN_VIEW ,
	                            @CFA_INVEN_VIEWCOST ,
	                            @CFA_INVEN_NEGATIVE_INSTANTPOS ,
	                            @CFA_ENDTRANS_CASH ,
	                            @CFA_ENDTRANS_ACCOUNT ,
	                            @CFA_REST_COMP ,
	                            @CFA_CH_FORCE ,
	                            @CFA_TS_CONFIG ,
	                            @CFA_TRANSFER_SERVER ,
	                            @CFA_BACKUP_DATABASE ,
	                            @CFA_CREDIT_CARD_SETTLEMENT ,
	                            @CFA_KITCHEN_REPRINT ,
	                            @CFA_SETUP_RECEIPT_NOTES ,
	                            @CFA_MANAGE_TIMECLOCK_OWNTIME ,
	                            @CFA_SETUP_ADD_EMPLOYEES ,
	                            @CFA_SETUP_EDIT_EMPLOYEES ,
	                            @CFA_INVENTORY_PROMOTIONS ,
	                            @CFA_INVOICE_DISCOUNTS_BELOW_X ,
	                            @CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT ,
	                            @CFA_REPORTS_VIEW_HISTORICAL_DATA ,
	                            @CFA_INVEN_MISC_FIELD_LOCKDOWN};
            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, value, "sp_T_UpdateEmployee");
            cmd.Dispose();
        }

        public DataTable GetEmployeeInInvoiceTotal(string cashierId)
        {
            cmd = new SqlCommand();
            string query = "select * from Invoice_Totals where Cashier_ID = '" + cashierId + "'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }
        #endregion
        #region Customers

        #endregion
        #region Station
        public DataTable GetAllStation(string storeId)
        {
            cmd = new SqlCommand();
            string query = "select * from Stations where Store_ID = '" + storeId + "'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }
        public void InsertStation(object[] station)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Station_ID " ,
	"@Store_ID" ,
	"@CSO" ,
	"@DSO" ,
	"@ISO" ,
	"@VSO" ,
	"@CDL"  ,
	"@PDL"  ,
	"@Pole_Type"  ,
	"@Scale_Port" ,
	"@Ticket_Port" ,
	"@Voucher_Port",
	"@BCB_Port"  ,
	"@SCP_700_Port"  ,
	"@Epson_Cutter_Port"  ,
	"@Printer_Type"  ,
	"@Printer_Port"  ,
	"@Show_Cust_Display"  ,
	"@Show_Toolbar"  ,
	"@API"  ,
	"@Receipt_Format"  ,
	"@Deadbeat_Control"  ,
	"@Prompt_Amt_Tend" ,
	"@Prompt_Table"  ,
	"@Prompt_ID"  ,
	"@Prompt_Salesperson"  ,
	"@Logo_Type"  ,
	"@Logo_Loc" ,
	"@Order_Dest" ,
	"@Stock_Prompt"  ,
	"@numReceiptCopies"  ,
	"@Dirty"   ,
	"@InvScreen" ,
	"@FullSize_Printer" ,
	"@Idle_LogOut"  ,
	"@CCTip"  ,
	"@Prompt_Zip"   ,
	"@Last_DDR"  ,
	"@Use_Sig_Pad_CC"   ,
	"@Require_Swipe"  ,
	"@Receipt_Printer"  ,
	"@Report_Printer"  ,
	"@Full_Receipt_Printer"  ,
	"@Slip_Printer"  ,
	"@DispTaxInPrice" ,
	"@numDocketCopies"  ,
	"@CC_Proc_Drive"  ,
	"@Check_Speed_Entry"  ,
	"@Prompt_Party_Size"  ,
	"@Order_By_Guest"  ,
	"@Label_Printer"  ,
	"@SigPadPort"  ,
	"@TS_Custom"  ,
	"@AmtTendScreen"  ,
	"@Def_OrderType"  ,
	"@Allow_End_Trans"  ,
	"@Prompt_Another_Order"   ,
	"@PinPad_Type"  ,
	"@PinPad_Port"  ,
	"@Login_Background"  ,
	"@Login_Foreground"  ,
	"@Login_Picture"  ,
	"@Login_AlphaNum"  ,
	"@Record_CashierID"  ,
	"@Change_Display"  ,
	"@Quick_Tender" ,
	"@Notify_Exp_Member"  ,
	"@Station_Merchant"  ,
	"@Item_OnTheFly"  ,
	"@Disp_Sec_Desc" ,
	"@Print_Epson_Logo" ,
	"@Quick_Bar"  ,
	"@Use_Cash_Alerts"  ,
	"@Kitchen_Require_Name" ,
	"@OverPayment_As_Tip"  ,
	"@TS_StockLevel"  ,
	"@BarcodeOnHold"   ,
	"@CD_Open" ,
	"@OnHold_Use_Invoice_Number"  ,
	"@PicPath"  ,
	"@SigPadType"  ,
	"@AcceptSigs"  ,
	"@SuppressSigCopy"  ,
	"@MultipleMenus"  ,
	"@Last_Invoice_Number"  ,
	"@Receipt_Display_ItemCount"  ,
	"@AllowSwipeFromInvoice"  ,
	"@Scale_Port2"  ,
	"@Endorse_Printer",
	"@Fax_Printer" ,
	"@Last_MoneyActivity_Index"  ,
	"@Last_TimeClock_Index"  ,
	"@Last_ExceptionIndex"  ,
	"@Section_ID"  ,
	"@TABLE_HIDE_OPENTABS" ,
	"@TABLE_HIDE_TAKEOUT" ,
	"@TABLE_HIDE_DELIVERY"  ,
	"@TABLE_HIDE_QUICKTAB" ,
	"@DisableTimeBasedPricing"  ,
	"@PrintSuggestedTip",
	"@ScaleWeightFormatting"  ,
	"@Cash_Count"  ,
	"@PrintDeliveryLabels"  ,
	"@Role"  ,
	"@CoinDispenserPort"  ,
	"@Current_Cash"  ,
	"@QuickCash_EnterKey"  ,
	"@Label_Printer_Secondary" };

            DataTable re = FillDataset2(cmd, CommandType.StoredProcedure, pa, station, "sp_InsertStation");
            cmd.Dispose();
        }

        #endregion

        #region Stock
        public void UpdateInStock(string StoreId, string itemNum,string inStock)
        {
            cmd = new SqlCommand();
            string query = "Update Inventory Set In_Stock = '" + inStock + "' where (Store_ID ='" + StoreId + "') and ( ItemNum = '"+itemNum + "')";
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }
        public void UpdateCostPer(string StoreId, string itemNum, string costPer)
        {
            cmd = new SqlCommand();
            string query = "Update Inventory Set Cost = '" + costPer + "' where (Store_ID ='" + StoreId + "') and ( ItemNum = '" + itemNum + "')";
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public void InsertInventory_In(string itemNum,string storeId,string quan,string costPer,string datetime,string dirty,string description,string cashierId)
        {
            cmd = new SqlCommand();
            string value = "('" + itemNum + "'," + "'" + storeId + "'," + "'" + quan + "'," + "'" + costPer + "'," + "'" + datetime + "'," + "'" + dirty + "'," + "'" + description + "'," + "'" + cashierId + "')";
            string query = "Insert into Inventory_In (ItemNum,Store_ID,Quantity,CostPer,DateTime,Dirty,Description,Cashier_ID) values " + value;
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public void DeleteInventory_In(string storeID, string itemNum)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            deleteSQL = "Delete From Inventory_In where (ItemNum = '" + itemNum + "') and ( Store_ID = '" + storeID + "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }

        #endregion

        #region SalePricing
        public DataTable GetBulkInfo(string storeId,string ItemNum)
        {
            cmd = new SqlCommand();
            string query = "Select * from Inventory_Bulk_Info where (Store_ID ='" + storeId + "') and (ItemNum = '"+ ItemNum + "')";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public DataTable GetOnsaleInfo(string storeId, string ItemNum)
        {
            cmd = new SqlCommand();
            string query = "Select * from Inventory_OnSale_Info where (Store_ID ='" + storeId + "') and (ItemNum = '" + ItemNum + "')";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public DataTable GetPrices(string storeId, string ItemNum)
        {
            cmd = new SqlCommand();
            string query = "Select * from Inventory_Prices where (Store_ID ='" + storeId + "') and (ItemNum = '" + ItemNum + "')";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public void DeleteBulkInfo(string storeID, string itemNum,float quant)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            deleteSQL = "Delete From Inventory_Bulk_Info where (ItemNum = '" + itemNum +
                "') and ( Store_ID = '" + storeID + "') and ( Bulk_Quan = '"+ quant +"')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }

        public void InsertBulkInfo(string itemNum, string storeId,string price, string quan)
        {
            cmd = new SqlCommand();
            string value = "('" + itemNum + "'," + "'" + storeId + "'," + "'" + price + "'," + "'" + quan + "')";
            string query = "Insert into Inventory_Bulk_Info (ItemNum,Store_ID,Bulk_Price,Bulk_Quan) values " + value;
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public void DeleteOnsaleInfo(string storeID, string itemNum,DateTime saleStart,DateTime saleEnd)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            deleteSQL = "Delete From Inventory_OnSale_Info where (ItemNum = '" + itemNum +
                "') and ( Store_ID = '" + storeID + "') and ( Sale_Start = '" + saleStart +
                "') and ( Sale_End = '" + saleEnd + "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }

        public void InsertOnsaleInfo(string itemNum, string storeId,DateTime saleStart,DateTime saleEnd,float percent)
        {
            cmd = new SqlCommand();
            string value = "('" + itemNum + "'," + "'" + storeId + "'," + "'" + saleStart + "'," + "'" + saleEnd + "','"+ percent + "')";
            string query = "Insert into Inventory_OnSale_Info (ItemNum,Store_ID,Sale_Start,Sale_End,[Percent]) values " + value;
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public void DeletePrices(string storeID, string itemNum,string cr1,string cr2,string cr3,int priceType)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            deleteSQL = "Delete From Inventory_Prices where (ItemNum = '" + itemNum +
                "') and ( Store_ID = '" + storeID + "') and ( Criteria1 = '" + cr1 +
                "') and ( Criteria2 = '" + cr2 + "') and ( Criteria2 = '" + cr2 + 
                "') and ( Criteria3 = '" + cr3 +
                "') and ( PriceType = '" + priceType + "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }

        public void InsertPrices(string itemNum, string storeId, decimal price, string cr1, string cr2, string cr3, bool enable, int priceType)
        {
            cmd = new SqlCommand();
            string value = "('" + itemNum + "'," + "'" + storeId + "'," + "'" + price + "'," + "'" 
                + cr1 + "','" + cr2 + "','" + cr3 + "','" + enable + "','" + priceType + "')";
            string query = "Insert into Inventory_Prices (ItemNum,Store_ID,Price,Criteria1,Criteria2,Criteria3,Enabled,PriceType) values " + value;
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public void DeleteSpecialPricing(string itemNum, string storeId)
        {
            cmd = new SqlCommand();
            string deleteSQL;
            deleteSQL = "Delete From Inventory_Bulk_Info where (ItemNum = '" + itemNum +
                "') and ( Store_ID = '" + storeId +  "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);

            deleteSQL = "Delete From Inventory_OnSale_Info where (ItemNum = '" + itemNum +
                "') and ( Store_ID = '" + storeId + "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);

            deleteSQL = "Delete From Inventory_Prices where (ItemNum = '" + itemNum +
                "') and ( Store_ID = '" + storeId + "')";
            FillDataset3(cmd, CommandType.Text, deleteSQL);
            cmd.Dispose();
        }

        #endregion

        public DataTable GetAllTSButtonDept(string storeId)
        {
            cmd = new SqlCommand();
            string query = @"SELECT Departments.Dept_ID, Departments.Store_ID, Departments.Description, Departments.Type, Departments.TSDisplay, 
                                  Departments.Cost_MarkUp, Departments.Dirty, Departments.SubType, Departments.Print_Dept_Notes, Departments.Dept_Notes, 
                                  Departments.Require_Permission, Departments.Require_Serials, Departments.BarTaxInclusive, Departments.Cost_Calculation_Percentage, 
                                  Departments.Square_Footage, Setup_TS_Buttons.[Index], Setup_TS_Buttons.Caption, Setup_TS_Buttons.Picture, 
                                  Setup_TS_Buttons.[Function], Setup_TS_Buttons.Option1, Setup_TS_Buttons.BackColor, Setup_TS_Buttons.ForeColor, 
                                  Setup_TS_Buttons.Visible, Setup_TS_Buttons.BtnType, Setup_TS_Buttons.Ident, Setup_TS_Buttons.ScheduleIndex, 
                                  Setup_TS_Buttons.RowID
                            FROM       Departments INNER JOIN
                                  Setup_TS_Buttons ON Departments.Store_ID = Setup_TS_Buttons.Store_ID AND Departments.Dept_ID = Setup_TS_Buttons.Ident
                            WHERE       (Departments.Store_ID = '"+ storeId + "')  ORDER BY Setup_TS_Buttons.[Index]";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public DataTable GetAllTSButtonInvent(string storeId, string deptId)
        {
            cmd = new SqlCommand();
            string query = @"SELECT  Setup_TS_Buttons.Store_ID, Setup_TS_Buttons.RowID, Setup_TS_Buttons.[Index], Setup_TS_Buttons.Caption, Setup_TS_Buttons.Picture, 
                                  Setup_TS_Buttons.Option1, Setup_TS_Buttons.BackColor, Setup_TS_Buttons.Ident, Inventory.AutoWeigh, Inventory.Tear, 
                                  Inventory.Dept_ID, Setup_TS_Buttons.Visible, Inventory.Cost, Inventory.Price, Inventory.Retail_Price, Inventory.In_Stock, 
                                  Inventory.Reorder_Level, Inventory.Reorder_Quantity, Inventory.Tax_1, Inventory.Tax_2, Inventory.Tax_3, Inventory.IsKit, 
                                  Inventory.IsModifier, Inventory.ItemType, Inventory.ItemNum, Inventory.ItemName,Setup_TS_Buttons.ForeColor
                        FROM                      Inventory INNER JOIN
                                  Setup_TS_Buttons ON Setup_TS_Buttons.Ident = Inventory.ItemNum AND Setup_TS_Buttons.Store_ID = Inventory.Store_ID
                        WHERE                   (Setup_TS_Buttons.BtnType = 0) AND 
                                  (Setup_TS_Buttons.Option1 = N'"+ deptId+ @"') AND (Setup_TS_Buttons.[Index] > - 1) AND (Setup_TS_Buttons.Station_ID = '' OR
                                  Setup_TS_Buttons.Station_ID IS NULL) AND (Setup_TS_Buttons.Store_ID = '"+ storeId +"') ORDER BY  Setup_TS_Buttons.[Index]";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public void UpdateTSButton(string StoreId, string Ident, string Index, string Caption, string Picture, string BackColor, string ForeColor,string Visible )
        {
            cmd = new SqlCommand();
            string query = "Update Setup_TS_Buttons Set [Index] = '" + Index + "',Caption = N'" + Caption + "', Picture ='" + Picture +
                "',BackColor ='" + BackColor + "',ForeColor ='" + ForeColor + "',Visible ='" + Visible + 
                "'  where (Store_ID ='" + StoreId + "') and (Ident = N'" + Ident + "')";
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }


        public DataTable GetEmpSwipe(string swipe, string storeId)
        {
            cmd = new SqlCommand();
            string query = "Select * from Employee where (Swipe_ID = '" + swipe + "')";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public DataTable GetIngredient(string itemNum,string storeId)
        {
            cmd = new SqlCommand();
            string query = @"SELECT     dbo.Inventory_Ingredients.Ingredient, dbo.Inventory_Ingredients.ItemNum, dbo.Inventory_Ingredients.Store_ID, dbo.Inventory_Ingredients.Quantity, 
                      dbo.Inventory_Ingredients.Measurement, dbo.Inventory_Ingredients.Yield, dbo.Inventory.ItemName, dbo.Inventory.Cost, dbo.Inventory.Price, 
                      dbo.Inventory.In_Stock
                        FROM         dbo.Inventory_Ingredients INNER JOIN
                      dbo.Inventory ON dbo.Inventory_Ingredients.Store_ID = dbo.Inventory.Store_ID AND dbo.Inventory_Ingredients.Ingredient = dbo.Inventory.ItemNum"
                        + " WHERE  dbo.Inventory_Ingredients.Store_ID = '" + storeId + "' and dbo.Inventory_Ingredients.ItemNum = '"+itemNum+"'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }
        public DataTable DeleteIngredient(string itemNum, string Ingredient, string storeId)
        {
            cmd = new SqlCommand();
            string query = @"delete from Inventory_Ingredients where ItemNum ='" + itemNum + "' and Store_ID ='" 
                + storeId + "'" + " and Ingredient = '"
                + Ingredient + "'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public void InsertIngredient(string itemNum, string ingredient, string storeId, string quan,string measure,string yield)
        {
            cmd = new SqlCommand();
            string value = "('" + itemNum + "'," + "'" + storeId + "'," + "'" + ingredient + "'," + "'" + quan + "','" + measure + "','"+ yield+"')";
            string query = "Insert into Inventory_Ingredients (ItemNum,Store_ID,Ingredient,Quantity,Measurement,Yield) values " + value;
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public DataTable DeleteIngredientByItemNum(string itemNum, string storeId)
        {
            cmd = new SqlCommand();
            string query = @"delete from Inventory_Ingredients where ItemNum ='" + itemNum 
                + "' and Store_ID ='"
                + storeId + "'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }
        #region Customers

        public Customer.CustomerDataTable GetAllCustomers()
        {
            var customer=new Customer.CustomerDataTable();
            var customerTableAdapter=new CustomerTableAdapter();
            customerTableAdapter.Connection = DataProvider.ConnectionData(sr);
            customerTableAdapter.Fill(customer);
            return customer;
        }
        public Customer.CustomerDataTable GetCustomerByID(string id)
        {
            var customer = new Customer.CustomerDataTable();
            var customerTableAdapter = new CustomerTableAdapter();
            customerTableAdapter.Connection = DataProvider.ConnectionData(sr);
            customerTableAdapter.FillByCustomerID(customer, id);
            return customer;
        }
        #region CreateCustomer
        public void CreateCustomer(string CustNum,
                    string First_Name,
                    string Last_Name,
                    string Company,
                    string Address_1,
                    string Address_2,
                    string City,
                    string State,
                    string Zip_Code,
                    string Phone_1,
                    string Phone_2,
                    string CC_Type,
                    string CC_Num,
                    string CC_Exp,
                    string Discount_Level,
                    float Discount_Percent,
                    DateTime? Acct_Open_Date,
                    DateTime? Acct_Close_Date,
                    decimal? Acct_Balance,
                    decimal? Acct_Max_Balance,
                    bool Bonus_Plan_Member,
                    int? Bonus_Points,
                    bool Tax_Exempt,
                    DateTime? Member_Exp,
                    bool Dirty,
                    string Phone_3,
                    string Phone_4,
                    string EMail,
                    string County,
                    string Def_SP,
                    DateTime? CreateDate,
                    string Referral,
                    DateTime? Birthday,
                    DateTime? Last_Birthday_Bonus,
                    DateTime? Last_Visit,
                    bool Require_PONum,
                    int? Max_Charge_NumDays,
                    decimal? Max_Charge_Amount,
                    string License_Num,
                    DateTime? ID_Last_Checked,
                    DateTime? Next_Start_Date,
                    string Checking_AcctNum,
                    bool PrintNotes,
                    short? Loyalty_Plan_ID,
                    int? Tax_Rate_ID,
                    string Bill_To_Name,
                    string Contact_1,
                    string Contact_2,
                    string Terms,
                    string Resale_Num,
                    DateTime? Last_Coupon,
                    short? Account_Type,
                    bool? ChargeAtCost)
        {
            var customer = new Customer.CustomerDataTable();
            var customerTableAdapter = new CustomerTableAdapter { Connection = DataProvider.ConnectionData(sr) };
            customerTableAdapter.InsertCustomer(CustNum, First_Name, Last_Name, Company, Address_1, Address_2, City,
                                                State, Zip_Code, Phone_1, Phone_2, CC_Type, CC_Num, CC_Exp,
                                                Discount_Level, Discount_Percent, Acct_Open_Date, Acct_Close_Date,
                                                Acct_Balance, Acct_Max_Balance, Bonus_Plan_Member, Bonus_Points,
                                                Tax_Exempt, Member_Exp, Dirty,
                                                Phone_3, Phone_4, EMail, County, Def_SP, CreateDate, Referral, Birthday,
                                                Last_Birthday_Bonus, Last_Visit, Require_PONum, Max_Charge_NumDays,
                                                Max_Charge_Amount,
                                                License_Num, ID_Last_Checked, Next_Start_Date, Checking_AcctNum,
                                                PrintNotes, Loyalty_Plan_ID, Tax_Rate_ID, Bill_To_Name, Contact_1,
                                                Contact_2, Terms, Resale_Num, Last_Coupon, Account_Type, ChargeAtCost);

        }
        #endregion

        #region UpdateCustomer
        public void UpdateCustomer(string CustNum, 
                    string First_Name, 
                    string Last_Name, 
                    string Company, 
                    string Address_1, 
                    string Address_2, 
                    string City, 
                    string State, 
                    string Zip_Code, 
                    string Phone_1, 
                    string Phone_2, 
                    string CC_Type, 
                    string CC_Num, 
                    string CC_Exp, 
                    string Discount_Level, 
                    float Discount_Percent, 
                    DateTime? Acct_Open_Date, 
                    DateTime? Acct_Close_Date, 
                    decimal? Acct_Balance, 
                    decimal? Acct_Max_Balance, 
                    bool Bonus_Plan_Member, 
                    int? Bonus_Points, 
                    bool Tax_Exempt, 
                    DateTime? Member_Exp, 
                    bool Dirty, 
                    string Phone_3, 
                    string Phone_4, 
                    string EMail, 
                    string County, 
                    string Def_SP, 
                    DateTime? CreateDate, 
                    string Referral, 
                    DateTime? Birthday, 
                    DateTime? Last_Birthday_Bonus, 
                    DateTime? Last_Visit, 
                    bool Require_PONum, 
                    int? Max_Charge_NumDays, 
                    decimal? Max_Charge_Amount, 
                    string License_Num, 
                    DateTime? ID_Last_Checked, 
                    DateTime? Next_Start_Date, 
                    string Checking_AcctNum, 
                    bool PrintNotes, 
                    short? Loyalty_Plan_ID, 
                    int? Tax_Rate_ID, 
                    string Bill_To_Name, 
                    string Contact_1, 
                    string Contact_2, 
                    string Terms, 
                    string Resale_Num, 
                    DateTime? Last_Coupon, 
                    short? Account_Type, 
                    bool? ChargeAtCost,
                    string original_CustNum)
        {
            var customer = new Customer.CustomerDataTable();
            var customerTableAdapter = new CustomerTableAdapter();
            customerTableAdapter.Connection = DataProvider.ConnectionData(sr);
            customerTableAdapter.UpdateCustomer(CustNum, First_Name, Last_Name, Company, Address_1, Address_2, City,
                                                State, Zip_Code, Phone_1, Phone_2, CC_Type,
                                                CC_Num, CC_Exp, Discount_Level, Discount_Percent, Acct_Open_Date,
                                                Acct_Close_Date, Acct_Balance, Acct_Max_Balance, Bonus_Plan_Member,
                                                Bonus_Points,
                                                Tax_Exempt, Member_Exp, Dirty, Phone_3, Phone_4, EMail, County, Def_SP,
                                                CreateDate, Referral, Birthday, Last_Birthday_Bonus, Last_Visit,
                                                Require_PONum,
                                                Max_Charge_NumDays, Max_Charge_Amount, License_Num, ID_Last_Checked,
                                                Next_Start_Date, Checking_AcctNum, PrintNotes, Loyalty_Plan_ID,
                                                Tax_Rate_ID,
                                                Bill_To_Name, Contact_1, Contact_2, Terms, Resale_Num, Last_Coupon,
                                                Account_Type, ChargeAtCost, original_CustNum);

        }
        #endregion
        #region DeleteCustomer
        public void DeleteCustomer(string customerID)
        {
            var customer = new Customer.CustomerDataTable();
            var customerTableAdapter = new CustomerTableAdapter();
            customerTableAdapter.Connection = DataProvider.ConnectionData(sr);
            int customer1 = customerTableAdapter.DeleteCustomer(customerID);
        }
        #endregion

        public DataTable getCustSwipeById(string custId)
        {
            cmd = new SqlCommand();
            string query = "Select * from Customer_Swipes where (CustNum = '" + custId + "')";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public DataTable getCustBySwipe(string swipeId)
        {
            cmd = new SqlCommand();
            string query = @"SELECT     dbo.Customer.*
                            FROM         dbo.Customer INNER JOIN
                            dbo.Customer_Swipes ON dbo.Customer.CustNum = dbo.Customer_Swipes.CustNum "+
                            " WHERE   dbo.Customer_Swipes.Swipe_ID = '"+swipeId+"'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }
        public void DeleteCustSwipe(string custId, string SwipeId)
        {
            cmd = new SqlCommand();
            string query = @"delete from Customer_Swipes " +
                            " WHERE   CustNum = '" + custId + "' and Swipe_ID = '"+ SwipeId + "'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        public void InsertCustSwipe(string custId, string SwipeId)
        {
            cmd = new SqlCommand();
            string value = "('" + custId + "'," + "'" + SwipeId + "')";
            string query = "Insert into Customer_Swipes (CustNum,Swipe_ID) values " + value;
            FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
        }

        
        #endregion

        #region index Search
        public DataTable IndexSearchCust(string key)
        {
            cmd = new SqlCommand();
            string query = @"select * 
                                from Customer
                                where Last_Name like N'%" + key + "%' or CustNum like N'%"
                                + key + "%' or Address_1 like N'%"
                                + key + "%' or Address_2 like N'%"
                                + key + "%' or Phone_1 like N'%"
                                + key + "%' or Phone_2 like N'%"
                                + key + "%' or EMail like N'%"
                                + key + "%'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }
        public DataTable IndexSearchInventory(string key)
        {
            cmd = new SqlCommand();
            string query = @"select * 
                                from Inventory
                                where ItemNum like N'%" + key + "%' or ItemName like N'%"
                                + key + "%'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }

        public DataTable IndexSearchEmp(string key)
        {
            cmd = new SqlCommand();
            string query = @"select * 
                                from Employee
                                where Cashier_ID like N'%" + key + "%' or EmpName like N'%"
                                + key + "%' or First_Name like N'%"
                                + key + "%' or Last_Name like N'%"
                                + key + "%' or Address_1 like N'%"
                                + key + "%' or Address_2 like N'%"
                                + key + "%' or City like N'%"
                                + key + "%' or Phone_1 like N'%"
                                + key + "%' or EMail like N'%"
                                + key + "%'";
            DataTable re = FillDataset3(cmd, CommandType.Text, query);
            cmd.Dispose();
            return re;
        }
        #endregion
        

    }
}
