USE [InvoiceMaster]
GO

/****** Object:  StoredProcedure [dbo].[sp_getInvoiceList]    Script Date: 9/11/2020 11:32:27 AM ******/
DROP PROCEDURE [dbo].[sp_getInvoiceList]
GO

/****** Object:  StoredProcedure [dbo].[sp_getInvoiceList]    Script Date: 9/11/2020 11:32:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getInvoiceList]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [InvoiceID]
      ,[InvoiceNumber]
      ,[CustomerID]
      ,[Country]
      ,[State]
      ,[AdvancePaymentTax]
      ,[DueDate]
      ,[Created]
  FROM [dbo].[Invoices]


END


GO


