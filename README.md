# NextensTaxTool

- Open Package manager console in visual studio.
- Run update-database InitialMigration to create the database and tables.
- Initialize the project.
- How to use application is provided once application is up and runnning at home page.

db connection string can be found in appsettings.json
If you are not able to use db-up , create a database -"NextensTaxTool" and create a table "ClientFinancialData"-

CREATE TABLE [dbo].[ClientFinancialData](
	[Id] [nvarchar](450) NOT NULL,
	[ClientId] [nvarchar](max) NULL,
	[Year] [int] NOT NULL,
	[Income] [bigint] NULL,
	[RealEstatePropertyValue] [bigint] NULL,
	[BankBalanceNational] [bigint] NULL,
	[BankbalanceInternational] [bigint] NULL,
	[StockInvestments] [bigint] NULL,
 CONSTRAINT [PK_ClientFinancialData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
