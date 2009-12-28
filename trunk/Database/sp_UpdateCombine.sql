set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateCombine]
	-- Add the parameters for the stored procedure here
	@Store_ID varchar(10),
	@Invoice_Number bigint,
	@Invoice_Number_New bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN TRANSACTION

    UPDATE Invoice_Totals
	SET Total_Cost = 0.000,Total_Price = 0.000,Total_Tax1 = 0.000,Total_Tax2=0.000,Total_Tax3 = 0.000,
		Grand_Total = 0.000,Status = N'V'
	Where (Invoice_Number = @Invoice_Number)and(Store_ID = @Store_ID)

	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	
	

	DELETE FROM Invoice_Itemized
	where (Invoice_Number = @Invoice_Number)and(Store_ID = @Store_ID)

	
	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END

	COMMIT TRANSACTION
END




