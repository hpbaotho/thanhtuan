set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

Create PROCEDURE [dbo].[sp_T_GetAllInventoryByDept]
(
	
	@Store_ID nvarchar(10),
	@Dept_ID nvarchar(12)
)
AS
	SET NOCOUNT ON;
SELECT                  ItemNum, Store_ID
FROM                     Inventory
WHERE                   (Store_ID = @Store_ID)and(Dept_ID=@Dept_ID)
