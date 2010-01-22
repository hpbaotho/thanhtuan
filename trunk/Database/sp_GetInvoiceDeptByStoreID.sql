set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
Create PROCEDURE [dbo].[sp_GetInvoiceDeptByStoreID] 
	-- Add the parameters for the stored procedure here
	@Store_ID nvarchar(10) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Inventory.ItemNum,Inventory.ItemName,Inventory.Dept_ID,Invoice_Itemized.Quantity,Invoice_Itemized.CostPer, Invoice_Itemized.PricePer 
	FROM   Invoice_Itemized inner join Inventory on Inventory.ItemNum=Invoice_Itemized.ItemNum
	WHERE (Invoice_Itemized.Store_ID = @Store_ID)
END

