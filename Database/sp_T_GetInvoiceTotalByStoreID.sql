set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE [dbo].[sp_T_GetInvoiceTotalByStoreID]
	-- Add the parameters for the stored procedure here
	@Store_ID nvarchar(10),
	@DateTime1 datetime,
	@DateTime2 datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT  * 
	FROM Invoice_Totals 
	WHERE (Store_ID = @Store_ID) And (DateTime between @DateTime1 and @DateTime2)
	
	
END

