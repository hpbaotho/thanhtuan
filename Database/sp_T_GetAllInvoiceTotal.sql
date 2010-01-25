set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_T_GetAllInvoiceTotal]
	-- Add the parameters for the stored procedure here
	@Store_ID nvarchar(10),
	@Status nvarchar(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT   DateTime,Sum(Total_Cost) as Total_Cost,sum(Total_Price) as Total_Price,Sum(Total_Tax1) as Total_Tax1,sum(Total_Tax2) as Total_Tax2,sum(Total_Tax3) as Total_Tax3,sum (Grand_Total) as Grand_Total,sum(Total_GC_Sold) as Total_GC_Sold,Count(Invoice_Number) as TicketsTotal
	FROM InvoiceTotal_View 
	WHERE (Store_ID = @Store_ID) and(Status=@Status)
	group by DateTime
	
END






