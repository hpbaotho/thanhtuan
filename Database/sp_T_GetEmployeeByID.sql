set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




Create PROCEDURE [dbo].[sp_T_GetEmployeeByID]
(
	@Store_ID nvarchar(10),
	@Cashier_ID nvarchar(10)
)
AS
	SET NOCOUNT ON;
SELECT                  *
FROM                     Employee
WHERE                   (Orig_Store_ID = @Store_ID)and(Cashier_ID=@Cashier_ID)



