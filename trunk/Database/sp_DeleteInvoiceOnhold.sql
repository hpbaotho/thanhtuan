set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteInvoiceOnhold] 
	-- Add the parameters for the stored procedure here
	@Store_ID nvarchar(10),
	@Invoice_Number bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from Invoice_OnHold where (Invoice_Number = @Invoice_Number)and(Store_ID = @Store_ID)
END

