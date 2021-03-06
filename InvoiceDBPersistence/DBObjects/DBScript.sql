USE [InvoiceMaster]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 9/11/2020 11:36:56 AM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Feedback] [varchar](2000) NULL,
	[Created] [datetime] NULL DEFAULT (getdate())
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [nvarchar](5) NOT NULL,
	[CountryName] [nvarchar](255) NOT NULL,
	[Region] [nvarchar](255) NULL,
	[SubRegion] [nvarchar](255) NULL,
	[SortOrder] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[country_bkup]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country_bkup](
	[name] [nvarchar](255) NULL,
	[alpha2] [nvarchar](255) NULL,
	[alpha3] [nvarchar](255) NULL,
	[countrycode] [nvarchar](5) NULL,
	[iso31662] [nvarchar](255) NULL,
	[region] [nvarchar](255) NULL,
	[sub_region] [nvarchar](255) NULL,
	[intermediate_region] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customer_backup]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_backup](
	[Name] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[ContactPerson] [nvarchar](max) NOT NULL,
	[Telephone] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](10) NULL,
	[Fax] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Notes] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[ContactPerson] [nvarchar](max) NOT NULL,
	[Telephone] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](10) NULL,
	[Fax] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[InvoiceDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[Description] [varchar](100) NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
	[VAT] [numeric](18, 9) NULL,
	[Memo] [varchar](1000) NULL,
	[Created] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[InvoiceDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [varchar](20) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Country] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[AdvancePaymentTax] [numeric](18, 9) NULL,
	[DueDate] [datetime] NULL,
	[Created] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Providers](
	[ProviderID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CompanyNumber] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
	[Mobile] [varchar](10) NULL,
	[Fax] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[CompanyLogo] [varchar](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sales](
	[SalesId] [int] IDENTITY(1,1) NOT NULL,
	[SalesItem] [varchar](50) NULL,
	[DateSold] [datetime] NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
	[ShipToLoc] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[State]    Script Date: 9/11/2020 11:36:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[CountryCode] [nvarchar](255) NULL,
	[StateName] [nvarchar](255) NULL,
	[StateCode] [nvarchar](255) NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
GO
/****** Object:  StoredProcedure [dbo].[sp_getInvoiceList]    Script Date: 9/11/2020 11:36:56 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_insertCustomerFeedback]    Script Date: 9/11/2020 11:36:56 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertInvoice]    Script Date: 9/11/2020 11:36:56 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertSales]    Script Date: 9/11/2020 11:36:56 AM ******/
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
