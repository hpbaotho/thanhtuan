set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

Create PROCEDURE [dbo].[sp_UpdateInventory]
(
	@OldInvent_ID nvarchar(8),
	@ItemNum nvarchar(20),
	@ItemName nvarchar(30),
	@Store_ID nvarchar(10),
	@Cost varchar(200),
	@Price varchar(200),
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
	
	BEGIN TRANSACTION

	IF @OldInvent_ID <> @ItemNum -- Update primary key
	BEGIN
		
		
		-- Update primary key of Departments table
		UPDATE Inventory SET ItemNum = @ItemNum WHERE ItemNum = @OldInvent_ID AND Store_ID = @Store_ID
		IF @@ERROR != 0 BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END

		
		-- Update Option1 of Setup_TS_Buttons
		UPDATE Setup_TS_Buttons SET Option1 = @Dept_ID 
		WHERE Store_ID = @Store_ID AND Station_ID = @Station_ID
			AND Option1 = @OldDept_ID AND BtnType=0 
			AND Ident IN (SELECT Inventory.ItemNum FROM Inventory WHERE Store_ID = @Store_ID AND Dept_ID = @Dept_ID)



	END

	-- Update Departments
	UPDATE    Inventory
	SET              Description = @Description, Type = @Type, SubType = @Cat_ID, 
						  Print_Dept_Notes = @Print_Dept_Notes, Dept_Notes = @Dept_Notes, Require_Permission = @Require_Permission, 
						  Require_Serials = @Require_Serials, BarTaxInclusive = @BarTaxInclusive, Cost_Calculation_Percentage = @Cost_Calculation_Percentage, 
						  Square_Footage = @Square_Footage
	 WHERE Dept_ID = @Dept_ID AND Store_ID = @Store_ID
	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END

	-- Update Caption of Setup_TS_Buttons
	UPDATE Setup_TS_Buttons SET Caption=@ItemName WHERE Store_ID = @Store_ID AND Station_ID = @Station_ID AND Ident = @ItemNum
	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	
	COMMIT TRANSACTION



