set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdatePrinter] 
	-- Add the parameters for the stored procedure here
	@Store_ID nvarchar(10),
	@Station_ID nvarchar(5),
	@PrinterName nvarchar(30),
	@Disabled bit,
	@Two_Color_Printing bit,
	@CutReceipt bit,
	@LocalPort nvarchar(20),
	@NetworkPort nvarchar(75),
	@Details nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION

    UPDATE Printer_Mapping
	SET Disabled = @Disabled,Two_Color_Printing = @Two_Color_Printing , CutReceipt =@CutReceipt,
		LocalPort = @LocalPort,NetworkPort =@NetworkPort,Details = @Details
	Where (Store_ID = @Store_ID) and (@Station_ID = Station_ID) and(@PrinterName = PrinterName)

	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	COMMIT TRANSACTION
END

