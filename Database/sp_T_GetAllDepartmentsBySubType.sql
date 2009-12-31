set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

Create PROCEDURE [dbo].[sp_T_GetAllDepartmentsBySubType]
(
	@Store_ID nvarchar(10),
	@SubType  nvarchar(8)
)
AS
	SET NOCOUNT ON;
SELECT                  Dept_ID, Store_ID, Description, Type, TSDisplay, Cost_MarkUp, Dirty, SubType, Print_Dept_Notes, Dept_Notes, Require_Permission, 
                                  Require_Serials, BarTaxInclusive, Cost_Calculation_Percentage, Square_Footage
FROM                     Departments
WHERE                   (Store_ID = @Store_ID)and(SubType=@SubType)
