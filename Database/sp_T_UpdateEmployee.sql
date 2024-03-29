set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		Dinh Thanh
-- Create date: 
-- Description:	
-- =============================================
create PROCEDURE [dbo].[sp_T_UpdateEmployee] 
	-- Add the parameters for the stored procedure here
	@Cashier_ID nvarchar(10), 
	@CustNum nvarchar(12),
	@Dept_ID nvarchar(8),
	@Password nvarchar(12),
	@Swipe_ID nvarchar(25),
	@Hourly_Wage money,
	@Form_Color int,
	@CFA_Setup_Company nvarchar(1),
	@CFA_Setup_Tax nvarchar(1),
	@CFA_Setup_Bonus nvarchar(1),
	@CFA_Setup_Accounting nvarchar(1),
	@CFA_Setup_Discounts nvarchar(1),
	@CFA_Setup_Display nvarchar(1),
	@CFA_Setup_DefPrinter nvarchar(1),
	@CFA_Inven_Add nvarchar(1),
	@CFA_Inven_Edit nvarchar(1),
	@CFA_Vendors_Add nvarchar(1),
	@CFA_Vendors_Edit nvarchar(1),
	@CFA_Depts_Add nvarchar(1),
	@CFA_Depts_Edit nvarchar(1),
	@CFA_Inven_TickVouch nvarchar(1),
	@CFA_Cust_add nvarchar(1),
	@CFA_Cust_Edit nvarchar(1),
	@CFA_Reports_Display nvarchar(1),
	@CFA_Reports_DDR nvarchar(1),
	@CFA_Reports_Print nvarchar(1),
	@CFA_Invoice_Discount nvarchar(1),
	@CFA_Invoice_PriceChange nvarchar(1),
	@CFA_Invoice_DeleteItems nvarchar(1),
	@CFA_Invoice_Void nvarchar(1),
	@CFA_CRE_Acct nvarchar(1),
	@CFA_CRE_Exit nvarchar(1),
	@Dirty bit,
	@CFA_Display_Balance nvarchar(1),
	@CFA_Refund_Item nvarchar(1),
	@Disp_Pay_Option bit,
	@Disp_Item_Option bit,
	@EmpName nvarchar(30),
	@CFA_Receive_Items nvarchar(1),
	@CFA_DO_POS nvarchar(1),
	@CFA_INSTANT_POS nvarchar(1),
	@Section_ID nvarchar(15),
	@CFA_Other_Tables nvarchar(1),
	@CFA_Accept_Cash nvarchar(1),
	@CFA_TRANSFER_NOSWIPE nvarchar(1),
	@CFA_ADD_CCTIPS nvarchar(1),
	@Disabled bit,
	@Admin_Access bit,	
	@CFA_PRINT_HOLD nvarchar(1),
	@CFA_Open_Cash_Drawer nvarchar(1),
	@CCTipsNow bit,
	@ReqClockIn bit,
	@CFA_Split_Checks nvarchar(1),
	@CFA_Transfer_Tables nvarchar(1),
	@CFA_Extra_Item nvarchar(1),
	@CFA_Tax_Exempt nvarchar(1),
	@CFA_GC_Sell nvarchar(1),
	@CFA_GC_Redeem nvarchar(1),
	@CFA_SELL_SPECIAL_ITEM nvarchar(1),
	@CFA_VENDOR_PAYOUT nvarchar(1),
	@CFA_APPLY_GRATUITY nvarchar(1),
	@First_Name nvarchar(15),
	@Middle_Name nvarchar(15),
	@Last_Name nvarchar(20),
	@SSN nvarchar(20),
	@Address_1 nvarchar(30),
	@Address_2 nvarchar(30),
	@City nvarchar(20),
	@State nvarchar(15),
	@Zip_Code nvarchar(15),
	@Phone_1 nvarchar(20),
	@EMail nvarchar(50),
	@Birthday datetime,
	@Picture nvarchar(125),
	@CFA_BUYBACKS_TRADES nvarchar(1),
	@CFA_CC_Force nvarchar(1),
	@CFA_CC_Below_Floor nvarchar(1),
	@Current_Cash money,
	@CFA_Cash_Alerts nvarchar(1),
	@CFA_Cash_Pickup nvarchar(1),
	@CDL_Stations_ID nvarchar(5),
	@CFA_Issue_Credit_Slip nvarchar(1),
	@CFA_Redeem_Credit_Slip nvarchar(1),
	@CFA_REFUND_OVERRIDE nvarchar(1),
	@CFA_DRAWER_TRANSFER nvarchar(1),
	@CFA_LARGE_PURCHASES nvarchar(1),
	@CFA_AUCTION_PHOTO nvarchar(1),
	@CFA_AUCTION_LISTREDEEM nvarchar(1),
	@CFA_AUCTION_SHIP nvarchar(1),
	@CFA_APPROVE_CASHCOUNT nvarchar(1),
	@Orig_Emp_ID nvarchar(10),
	@Orig_Store_ID nvarchar(10),
	@CD_Name nvarchar(25),
	@CFA_APPROVE_OLD_RETURNS nvarchar(1),
	@CFA_APPROVE_EMERGENCY_CLOCKOUT nvarchar(1),
	@TimeWorkedThisPeriod float,
	@OvertimeThreshold smallint,
	@CFA_PULLBACK_INVOICE nvarchar(1),
	@CFA_MANAGE_TIMECLOCK nvarchar(1),
	@CFA_PERFORM_ENDOFDAY nvarchar(1),
	@CFA_HOST_LOGIN nvarchar(1),
	@CFA_REST_OPENTABS nvarchar(1),
	@CFA_REST_TAKEOUT nvarchar(1),
	@CFA_REST_DELIVERY nvarchar(1),
	@CFA_INVOICE_DELETESENT nvarchar(1),
	@CFA_INVEN_VIEW nvarchar(1),
	@CFA_INVEN_VIEWCOST nvarchar(1),
	@CFA_INVEN_NEGATIVE_INSTANTPOS nvarchar(1),
	@CFA_ENDTRANS_CASH nvarchar(1),
	@CFA_ENDTRANS_ACCOUNT nvarchar(1),
	@CFA_REST_COMP nvarchar(1),
	@CFA_CH_FORCE nvarchar(1),
	@CFA_TS_CONFIG nvarchar(1),
	@CFA_TRANSFER_SERVER nvarchar(1),
	@CFA_BACKUP_DATABASE nvarchar(1),
	@CFA_CREDIT_CARD_SETTLEMENT nvarchar(1),
	@CFA_KITCHEN_REPRINT nvarchar(1),
	@CFA_SETUP_RECEIPT_NOTES nvarchar(1),
	@CFA_MANAGE_TIMECLOCK_OWNTIME nvarchar(1),
	@CFA_SETUP_ADD_EMPLOYEES nvarchar(1),
	@CFA_SETUP_EDIT_EMPLOYEES nvarchar(1),
	@CFA_INVENTORY_PROMOTIONS nvarchar(1),
	@CFA_INVOICE_DISCOUNTS_BELOW_X nvarchar(1),
	@CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT nvarchar(1),
	@CFA_REPORTS_VIEW_HISTORICAL_DATA nvarchar(1),
	@CFA_INVEN_MISC_FIELD_LOCKDOWN nvarchar(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION

    UPDATE Employee
	SET CustNum = @CustNum, Dept_ID = @Dept_ID, Employee.Password = @Password, Employee.Swipe_ID = @Swipe_ID, Employee.Hourly_Wage = @Hourly_Wage, 
                                  Employee.Form_Color = @Form_Color, Employee.CFA_Setup_Company = @CFA_Setup_Company, Employee.CFA_Setup_Tax = @CFA_Setup_Tax, 
                                  Employee.CFA_Setup_Bonus = @CFA_Setup_Bonus, Employee.CFA_Setup_Accounting = @CFA_Setup_Accounting, Employee.CFA_Setup_Discounts = @CFA_Setup_Discounts, Employee.CFA_Setup_Display = @CFA_Setup_Display, 
                                  Employee.CFA_Setup_DefPrinter= @CFA_Setup_DefPrinter, Employee.CFA_Inven_Add = @CFA_Inven_Add, Employee.CFA_Inven_Edit = @CFA_Inven_Edit, Employee.CFA_Vendors_Add = @CFA_Vendors_Add, 
                                  Employee.CFA_Vendors_Edit = @CFA_Vendors_Edit, Employee.CFA_Depts_Add = @CFA_Depts_Add, Employee.CFA_Depts_Edit = @CFA_Depts_Edit, Employee.CFA_Inven_TickVouch = @CFA_Inven_TickVouch, 
                                  Employee.CFA_Cust_add = @CFA_Cust_add, Employee.CFA_Cust_Edit = @CFA_Cust_Edit, Employee.CFA_Reports_Display = @CFA_Reports_Display, Employee.CFA_Reports_DDR = @CFA_Reports_DDR, 
                                  Employee.CFA_Reports_Print = @CFA_Reports_Print, Employee.CFA_Invoice_Discount = @CFA_Invoice_Discount, Employee.CFA_Invoice_PriceChange = @CFA_Invoice_PriceChange, Employee.CFA_Invoice_DeleteItems = @CFA_Invoice_DeleteItems,
                                  Employee.CFA_Invoice_Void = @CFA_Invoice_Void, Employee.CFA_CRE_Acct = @CFA_CRE_Acct, Employee.CFA_CRE_Exit = @CFA_CRE_Exit, Employee.Dirty = @Dirty, 
                                  Employee.CFA_Display_Balance = @CFA_Display_Balance, Employee.CFA_Refund_Item = @CFA_Refund_Item, Employee.Disp_Pay_Option = @Disp_Pay_Option, Employee.Disp_Item_Option = @Disp_Item_Option, 
                                  Employee.EmpName = @EmpName, Employee.CFA_Receive_Items = @CFA_Receive_Items, Employee.CFA_DO_POS = @CFA_DO_POS, Employee.CFA_INSTANT_POS = @CFA_INSTANT_POS, Employee.Section_ID = @Section_ID, 
                                  Employee.CFA_Other_Tables = @CFA_Other_Tables, Employee.CFA_Accept_Cash = @CFA_Accept_Cash, Employee.CFA_TRANSFER_NOSWIPE = @CFA_TRANSFER_NOSWIPE, Employee.CFA_ADD_CCTIPS = @CFA_ADD_CCTIPS, 
                                  Employee.Disabled = @Disabled, Employee.Admin_Access = @Admin_Access, Employee.CFA_PRINT_HOLD = @CFA_PRINT_HOLD, Employee.CFA_Open_Cash_Drawer = @CFA_Open_Cash_Drawer, Employee.CCTipsNow = @CCTipsNow, 
                                  Employee.ReqClockIn = @ReqClockIn, Employee.CFA_Split_Checks = @CFA_Split_Checks, Employee.CFA_Transfer_Tables = @CFA_Transfer_Tables, Employee.CFA_Extra_Item = @CFA_Extra_Item, 
                                  Employee.CFA_Tax_Exempt = @CFA_Tax_Exempt, Employee.CFA_GC_Sell = @CFA_GC_Sell, Employee.CFA_GC_Redeem = @CFA_GC_Redeem, Employee.CFA_SELL_SPECIAL_ITEM = @CFA_SELL_SPECIAL_ITEM, 
                                  Employee.CFA_VENDOR_PAYOUT = @CFA_VENDOR_PAYOUT, Employee.CFA_APPLY_GRATUITY = @CFA_APPLY_GRATUITY, Employee.First_Name = @First_Name, Employee.Middle_Name = @Middle_Name, Employee.Last_Name = @Last_Name, 
                                  Employee.SSN = @SSN, Employee.Address_1 = @Address_1, Employee.Address_2 = @Address_2, Employee.City = @City, Employee.State = @State, Employee.Zip_Code = @Zip_Code, Employee.Phone_1 = @Phone_1, 
                                  Employee.EMail = @EMail, Employee.Birthday = @Birthday, Employee.Picture = @Picture, Employee.CFA_BUYBACKS_TRADES = @CFA_BUYBACKS_TRADES, Employee.CFA_CC_Force = @CFA_CC_Force, 
                                  Employee.CFA_CC_Below_Floor = @CFA_CC_Below_Floor, Employee.Current_Cash = @Current_Cash, Employee.CFA_Cash_Alerts = @CFA_Cash_Alerts, Employee.CFA_Cash_Pickup = @CFA_Cash_Pickup, 
                                  Employee.CDL_Stations_ID = @CDL_Stations_ID, Employee.CFA_Issue_Credit_Slip = @CFA_Issue_Credit_Slip, Employee.CFA_Redeem_Credit_Slip = @CFA_Redeem_Credit_Slip, Employee.CFA_REFUND_OVERRIDE = @CFA_REFUND_OVERRIDE, 
                                  Employee.CFA_DRAWER_TRANSFER = @CFA_DRAWER_TRANSFER, Employee.CFA_LARGE_PURCHASES = @CFA_LARGE_PURCHASES, Employee.CFA_AUCTION_PHOTO = @CFA_AUCTION_PHOTO, 
                                  Employee.CFA_AUCTION_LISTREDEEM = @CFA_AUCTION_LISTREDEEM, Employee.CFA_AUCTION_SHIP = @CFA_AUCTION_SHIP, Employee.CFA_APPROVE_CASHCOUNT = @CFA_APPROVE_CASHCOUNT, Employee.Orig_Emp_ID = @Orig_Emp_ID, 
                                  Employee.CD_Name = @CD_Name, Employee.CFA_APPROVE_OLD_RETURNS = @CFA_APPROVE_OLD_RETURNS, 
                                  Employee.CFA_APPROVE_EMERGENCY_CLOCKOUT = @CFA_APPROVE_EMERGENCY_CLOCKOUT, Employee.TimeWorkedThisPeriod = @TimeWorkedThisPeriod, Employee.OvertimeThreshold = @OvertimeThreshold, 
                                  Employee.CFA_PULLBACK_INVOICE = @CFA_PULLBACK_INVOICE, Employee.CFA_MANAGE_TIMECLOCK = @CFA_MANAGE_TIMECLOCK, Employee.CFA_PERFORM_ENDOFDAY = @CFA_PERFORM_ENDOFDAY, 
                                  Employee.CFA_HOST_LOGIN = @CFA_HOST_LOGIN, Employee.CFA_REST_OPENTABS = @CFA_REST_OPENTABS, Employee.CFA_REST_TAKEOUT = @CFA_REST_TAKEOUT, Employee.CFA_REST_DELIVERY = @CFA_REST_DELIVERY, 
                                  Employee.CFA_INVOICE_DELETESENT = @CFA_INVOICE_DELETESENT, Employee.CFA_INVEN_VIEW = @CFA_INVEN_VIEW, Employee.CFA_INVEN_VIEWCOST = @CFA_INVEN_VIEWCOST, 
                                  Employee.CFA_INVEN_NEGATIVE_INSTANTPOS = @CFA_INVEN_NEGATIVE_INSTANTPOS, Employee.CFA_ENDTRANS_CASH = @CFA_ENDTRANS_CASH, Employee.CFA_ENDTRANS_ACCOUNT = @CFA_ENDTRANS_ACCOUNT, 
                                  Employee.CFA_REST_COMP = @CFA_REST_COMP, Employee.CFA_CH_FORCE = @CFA_CH_FORCE, Employee.CFA_TS_CONFIG = @CFA_TS_CONFIG, Employee.CFA_TRANSFER_SERVER = @CFA_TRANSFER_SERVER, 
                                  Employee.CFA_BACKUP_DATABASE = @CFA_BACKUP_DATABASE, Employee.CFA_CREDIT_CARD_SETTLEMENT = @CFA_CREDIT_CARD_SETTLEMENT, Employee.CFA_KITCHEN_REPRINT = @CFA_KITCHEN_REPRINT, 
                                  Employee.CFA_SETUP_RECEIPT_NOTES = @CFA_SETUP_RECEIPT_NOTES, Employee.CFA_MANAGE_TIMECLOCK_OWNTIME = @CFA_MANAGE_TIMECLOCK_OWNTIME, Employee.CFA_SETUP_ADD_EMPLOYEES = @CFA_SETUP_ADD_EMPLOYEES, 
                                  Employee.CFA_SETUP_EDIT_EMPLOYEES = @CFA_SETUP_EDIT_EMPLOYEES, Employee.CFA_INVENTORY_PROMOTIONS = @CFA_INVENTORY_PROMOTIONS, Employee.CFA_INVOICE_DISCOUNTS_BELOW_X = @CFA_INVOICE_DISCOUNTS_BELOW_X, 
                                  Employee.CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT = @CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT, Employee.CFA_REPORTS_VIEW_HISTORICAL_DATA = @CFA_REPORTS_VIEW_HISTORICAL_DATA, 
                                  Employee.CFA_INVEN_MISC_FIELD_LOCKDOWN = @CFA_INVEN_MISC_FIELD_LOCKDOWN
	Where (Cashier_ID = @Cashier_ID)and(Orig_Store_ID = @Orig_Store_ID)

	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END

	COMMIT TRANSACTION
END

