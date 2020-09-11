USE [InvoiceMaster]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertInvoice]    Script Date: 9/11/2020 11:33:36 AM ******/
DROP PROCEDURE [dbo].[sp_InsertInvoice]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertInvoice]    Script Date: 9/11/2020 11:33:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertInvoice]
(
	@InvoiceNumber varchar(20)
	,@CustomerID int
	,@Country varchar(50)
	,@State varchar(50)
	,@AdvancePaymentTax numeric(18,9)
	,@DueDate datetime
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Invoices]
		(  [InvoiceNumber]
		  ,[CustomerID]
		  ,[Country]
		  ,[State]
		  ,[AdvancePaymentTax]
		  ,[DueDate])
	  SELECT @InvoiceNumber,@CustomerID,@Country,@State,@AdvancePaymentTax,@DueDate
		
      
END

GO


