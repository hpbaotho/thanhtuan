
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create VIEW [dbo].[InvoiceTotal_View]
AS
SELECT     DATEADD(D, 0, DATEDIFF(D, 0, DateTime)) AS DateTime, Invoice_Number, Store_ID, Total_Cost, Total_Price, Total_Tax1, Total_Tax2, Total_Tax3, 
                      Grand_Total, Total_GC_Sold
FROM         dbo.Invoice_Totals
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

