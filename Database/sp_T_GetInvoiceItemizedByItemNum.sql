set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_T_GetInvoiceItemizedByItemNum]
	-- Add the parameters for the stored procedure here
	@Store_ID nvarchar(10),
	@ItemNum nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Invoice_Itemized WHERE Store_ID = @Store_ID AND ItemNum = @ItemNum 
END


