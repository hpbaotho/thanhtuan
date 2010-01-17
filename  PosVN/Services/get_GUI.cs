using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using DAO;
using System.Data.SqlClient;
namespace Services
{
    public class get_GUI
    {
        Server sr;
        private SqlCommand cmd;
        public static string serverName = "THANH\\SQLEXPRESS";
        public static string databaseName = "POS";
        public static bool Mode;
        public static string UserName;
        public static string Password;
        public get_GUI()
        {
            sr = new Server();
            //sr.Server_name = @"THANH\SQLEXPRESS";
            //sr.Database_name = "POS";
            sr.Server_name = serverName;
            sr.Database_name = databaseName;

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
                System.Diagnostics.Trace.WriteLine(ex.ToString());
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
        
        public DataTable OpenTable(string Store_ID,string Section_ID,string Station_ID,string OnHoldID,string Cashier_ID,string CustNum,string DateTime,string Line1,string Line2,string Line3,string Line4,string Line5 )
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Section_ID","@Station_ID","@OnHoldID","@Cashier_ID","@CustNum","@DateTime","@Line1","@Line2","@Line3","@Line4","@Line5" };
            string[] value = {  Store_ID, Section_ID, Station_ID, OnHoldID, Cashier_ID, CustNum, DateTime, Line1, Line2, Line3, Line4, Line5};
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_OpenTable");
            
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
        public void UpdateInvoiceItemized(string Store_ID,string Invoice_Number,string ItemNum,string Quantity,string LineDisc,string LineNum,string Tax1per,string Tax2per,string Tax3per)
        {
            cmd = new SqlCommand();
            string[] pa = { "@Store_ID", "@Invoice_Number","@ItemNum","@Quantity","@LineDisc","@LineNum","@Tax1per","@Tax2per","@Tax3per" };
            string[] value = { Store_ID, Invoice_Number, ItemNum, Quantity, LineDisc, LineNum, Tax1per, Tax2per, Tax3per };
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
            for (int i = 0; i < param.Length; i++)
            {
                if(param[i] != null)
                {
                    value[i] = param[i].ToString();
                }
                else
                {
                    value[i] = "";
                }     
            }
            DataTable re = FillDataset(cmd, CommandType.StoredProcedure, pa, value, "sp_UpdateImvoiceTotal");
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
										int Inactive,bool Allow_BuyBack,string Picture,bool Special_Permission,bool Check_ID2,bool Count_This_Item,bool Print_On_Receipt,string Station_ID,int Function,string Option1,int BackColor,int ForeColor)
        {
            cmd = new SqlCommand();
            string[] pa = { "@ItemNum","@ItemName","@Store_ID","@Cost", "@Price", "@In_Stock", "@Tax_1","@Tax_2","@Tax_3","@Dept_ID","@IsModifier","@Exclude_Acct_Limit",
									  "@Use_Serial_Numbers","@IsRental","@AutoWeigh","@FoodStampable","@ItemType","@Prompt_Price","@Prompt_Quantity","@Check_ID",
										"@Inactive","@Allow_BuyBack","@Picture","@Special_Permission","@Check_ID2","@Count_This_Item","@Print_On_Receipt","@Station_ID",
                                        "@Function","@Option1","@BackColor","@ForeColor"};
            object[] value = { ItemNum, ItemName, Store_ID, Cost, Price, In_Stock, Tax_1, Tax_2, Tax_3, Dept_ID, IsModifier,Exclude_Acct_Limit, Use_Serial_Numbers,IsRental,
                                AutoWeigh,FoodStampable,ItemType,Prompt_Price,Prompt_Quantity,Check_ID,Inactive,Allow_BuyBack,Picture,Special_Permission,
                               Check_ID2,Count_This_Item,Print_On_Receipt, Station_ID, Function, Option1, BackColor, ForeColor };
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
										int Inactive,bool Allow_BuyBack,string Picture,bool Special_Permission,bool Check_ID2,bool Count_This_Item,bool Print_On_Receipt,string Station_ID,int Function,string Option1,int BackColor,int ForeColor)
        {
            cmd = new SqlCommand();
            string[] pa = { "@OldInvent_ID","@ItemNum","@ItemName","@Store_ID","@Cost", "@Price", "@In_Stock", "@Tax_1","@Tax_2","@Tax_3","@Dept_ID","@IsModifier","@Exclude_Acct_Limit",
									  "@Use_Serial_Numbers","@IsRental","@AutoWeigh","@FoodStampable","@ItemType","@Prompt_Price","@Prompt_Quantity","@Check_ID",
										"@Inactive","@Allow_BuyBack","@Picture","@Special_Permission","@Check_ID2","@Count_This_Item","@Print_On_Receipt","@Station_ID",
                                        "@Function","@Option1","@BackColor","@ForeColor"};
            object[] value = {OldInvent_ID, ItemNum, ItemName, Store_ID, Cost, Price, In_Stock, Tax_1, Tax_2, Tax_3, Dept_ID, IsModifier,Exclude_Acct_Limit, Use_Serial_Numbers,IsRental,
                                AutoWeigh,FoodStampable,ItemType,Prompt_Price,Prompt_Quantity,Check_ID,Inactive,Allow_BuyBack,Picture,Special_Permission,
                               Check_ID2,Count_This_Item,Print_On_Receipt, Station_ID, Function, Option1, BackColor, ForeColor };
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
    }
}
