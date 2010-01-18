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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE sp_InsertPrinter
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
	INSERT INTO Friendly_Printers
					(Store_ID,PrinterName)
		VALUES		(@Station_ID,@PrinterName)
	
	INSERT INTO Printer_Mapping
					(Station_ID,Store_ID,LocalPort,NetworkPort,PrinterName,Details,Disabled,Two_Color_Printing,CutReceipt)
		VALUES		(@Station_ID,@Store_ID,@LocalPort,@NetworkPort,@PrinterName,@Details,@Disabled,@Two_Color_Printing,@CutReceipt)
END
GO
