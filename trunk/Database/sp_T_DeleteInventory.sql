set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[sp_T_DeleteInventory]
(
	@ItemNum nvarchar(20),
	@Store_ID nvarchar(10)
)
AS
	SET NOCOUNT OFF;
	BEGIN TRANSACTION

	IF EXISTS (SELECT * FROM Invoice_Itemized WHERE Store_ID = @Store_ID AND ItemNum = @ItemNum)
	BEGIN
		-- Update Occupied to false
		UPDATE Invoice_Itemized SET ItemNum = 'Non_Inventory' WHERE  Store_ID = @Store_ID AND ItemNum = @ItemNum
		IF @@ERROR != 0 BEGIN
			ROLLBACK TRANSACTION
			RETURN 0
		END
	END

	DELETE FROM Inventory WHERE ItemNum = @ItemNum AND Store_ID = @Store_ID
	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	
	Delete From Setup_TS_Buttons where Store_ID=@Store_ID And Ident=@ItemNum
	COMMIT TRANSACTION




