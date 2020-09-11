USE [InvoiceMaster]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertSales]    Script Date: 9/11/2020 11:33:54 AM ******/
DROP PROCEDURE [dbo].[sp_InsertSales]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertSales]    Script Date: 9/11/2020 11:33:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertSales]
(
	 @SalesItem varchar(50)
	,@DateSold	datetime
	,@Quantity	int
	,@Price		money
	,@ShipToLoc	varchar(50)
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Sales(
				 SalesItem
				,DateSold
				,Quantity
				,Price
				,ShipToLoc
				)
	VALUES(@SalesItem
			,@DateSold
			,@Quantity
			,@Price
			,@ShipToLoc
	)


END

GO


