set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


Create PROCEDURE [dbo].[sp_T_CreateInventory]
(
	@ItemNum nvarchar(20),
	@ItemName nvarchar(30),
	@Store_ID nvarchar(10),
	@Cost money,
	@Price money,
	@In_Stock float,
	@Tax_1 bit,
	@Tax_2 bit,
	@Tax_3 bit,
	@Dept_ID nvarchar(8),
	@IsModifier bit,
	@Exclude_Acct_Limit bit,
	@Use_Serial_Numbers bit,
	@IsRental bit,
	@AutoWeigh bit,
	@FoodStampable bit,
	@ItemType smallint,
	@Prompt_Price bit,
	@Prompt_Quantity bit,
	@Check_ID bit,
	@Inactive smallint,
	@Allow_BuyBack bit,
	@Picture nvarchar(125),
	@Special_Permission bit,
	@Check_ID2 bit,
	@Count_This_Item bit,
	@Print_On_Receipt bit,
	@Station_ID nvarchar(5),
	@Function int,
	@Option1 nvarchar(30),
	@BackColor int,
	@ForeColor int
)
AS
	SET NOCOUNT OFF;
	DECLARE @Ident nvarchar(20),
			@Caption nvarchar(30),
			@Index int
	SET @Ident = @ItemNum 
	SET @Caption = @ItemName
	
	BEGIN TRANSACTION

	-- Insert [dbo].[Departments]
	INSERT INTO     Inventory
									  (ItemNum, ItemName, Store_ID, Cost, Price, In_Stock, Tax_1, Tax_2, Tax_3, Dept_ID, IsModifier, Exclude_Acct_Limit,
									  Use_Serial_Numbers, IsRental, AutoWeigh, FoodStampable,ItemType,Prompt_Price,Prompt_Quantity,Check_ID,
										Inactive,Allow_BuyBack,Picture,Special_Permission,Check_ID2,Count_This_Item,Print_On_Receipt)


	VALUES                (@ItemNum,@ItemName,@Store_ID,@Cost, @Price, @In_Stock, @Tax_1,@Tax_2,@Tax_3,@Dept_ID,@IsModifier,@Exclude_Acct_Limit,
									  @Use_Serial_Numbers,@IsRental,@AutoWeigh,@FoodStampable,@ItemType,@Prompt_Price,@Prompt_Quantity,@Check_ID,
										@Inactive,@Allow_BuyBack,@Picture,@Special_Permission,@Check_ID2,@Count_This_Item,@Print_On_Receipt)
	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	
	-- Get next index
    SELECT @Index = COUNT(*) FROM Inventory
    
    -- Insert [dbo].[Setup_TS_Buttons]
	INSERT INTO     Setup_TS_Buttons
									  (Store_ID, Station_ID, [Index], Caption, Picture, [Function], Option1, BackColor, ForeColor, Visible, BtnType, Ident, ScheduleIndex, 
									  RowID)
	VALUES                (@Store_ID,@Station_ID,@Index,@Caption,@Picture,@Function,@Option1,@BackColor,@ForeColor, 1, 1,@Ident, 0, newid())
	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	COMMIT TRANSACTION


