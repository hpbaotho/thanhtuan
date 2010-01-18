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
CREATE PROCEDURE sp_UpdateTax
	-- Add the parameters for the stored procedure here
	@Store_ID varchar(10),
	@Tax1_Rate real,
	@Tax2_Rate real,
	@Tax3_Rate real
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    BEGIN TRANSACTION

    UPDATE Tax_Rate
	SET Tax1_Rate = @Tax1_Rate, Tax2_Rate = @Tax2_Rate,Tax3_Rate = @Tax3_Rate
	Where (Store_ID = @Store_ID)

	IF @@ERROR != 0 BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	COMMIT TRANSACTION
END
GO
