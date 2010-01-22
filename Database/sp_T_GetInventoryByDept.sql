set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


Create PROCEDURE [dbo].[sp_T_GetInventoryByDept]
(
	@ScheduleIndex smallint,
	@Dept_ID nvarchar(30),
	@Store_ID nvarchar(10)
)
AS
	SET NOCOUNT ON;
SELECT							*
FROM                     Setup_TS_Buttons INNER JOIN
                                  Inventory ON Setup_TS_Buttons.Ident = Inventory.ItemNum AND Setup_TS_Buttons.Store_ID = Inventory.Store_ID
WHERE                   (Setup_TS_Buttons.ScheduleIndex = @ScheduleIndex) AND (Setup_TS_Buttons.BtnType = 0) AND 
                                  (Setup_TS_Buttons.Option1 = @Dept_ID) AND (Setup_TS_Buttons.[Index] > - 1) AND (Setup_TS_Buttons.Station_ID = '' OR
                                  Setup_TS_Buttons.Station_ID IS NULL) AND (Setup_TS_Buttons.Store_ID = @Store_ID)
ORDER BY           Setup_TS_Buttons.[Index]

