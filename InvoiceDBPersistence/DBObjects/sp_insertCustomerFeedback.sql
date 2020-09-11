USE [InvoiceMaster]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertCustomerFeedback]    Script Date: 9/11/2020 11:33:21 AM ******/
DROP PROCEDURE [dbo].[sp_insertCustomerFeedback]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertCustomerFeedback]    Script Date: 9/11/2020 11:33:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertCustomerFeedback]
(
	 @Name varchar(50)
    ,@Email varchar(50)
    ,@Phone varchar(20) = null
    ,@Feedback varchar(2000)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[ContactUs]
	(	 [Name]
		,[Email]
		,[Phone]
		,[Feedback]
	)
		SELECT @Name,@Email,@Phone,@Feedback
     
END

GO


