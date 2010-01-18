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
CREATE PROCEDURE sp_DeletePrinter
	-- Add the parameters for the stored procedure here
	@Store_ID nvarchar(10),
	@Station_ID nvarchar(5),
	@PrinterName nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete From Friendly_Printers Where (@Store_ID = Store_ID) and(@PrinterName = PrinterName)
	Delete From Printer_Mapping Where (@Store_ID = Store_ID) and (@Station_ID = Station_ID) and(@PrinterName = PrinterName)
END
GO