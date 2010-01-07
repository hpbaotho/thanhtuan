-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
Alter PROCEDURE sp_GetInvoiceDeptByStoreID 
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
GO
