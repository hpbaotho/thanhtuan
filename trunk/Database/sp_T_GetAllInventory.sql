set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

Create PROCEDURE [dbo].[sp_T_GetAllInventory]
(
	@Store_ID nvarchar(10)
)
AS
	SET NOCOUNT ON;
SELECT                  *
FROM                     Inventory
WHERE                   (Store_ID = @Store_ID)
