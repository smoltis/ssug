USE [SQLCLR]
GO

/****** Object:  Table [dbo].[AddressType]    Script Date: 2/11/2016 2:38:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AddressType](
	[AddressTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL
) ON [PRIMARY]

GO


USE [SQLCLR]
GO

/****** Object:  Trigger [dbo].[AddressTypeCLRTrigger]    Script Date: 2/11/2016 2:38:22 PM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[AddressTypeCLRTrigger] ON [dbo].[AddressType] WITH EXECUTE AS CALLER AFTER  INSERT, UPDATE AS 
EXTERNAL NAME [ExternalSystems].[Triggers].[mySQLCLRTrigger]
GO

ALTER TABLE [dbo].[AddressType] ENABLE TRIGGER [AddressTypeCLRTrigger]
GO

USE [SQLCLR]
GO
SET IDENTITY_INSERT [dbo].[AddressType] ON 

GO
INSERT [dbo].[AddressType] ([AddressTypeID], [Name], [rowguid], [ModifiedDate]) VALUES (1, N'Billing', N'b84f78b1-4efe-4a0e-8cb7-70e9f112f886', CAST(N'2008-04-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [Name], [rowguid], [ModifiedDate]) VALUES (2, N'Home', N'41bc2ff6-f0fc-475f-8eb9-cec0805aa0f2', CAST(N'2016-11-02T13:28:27.500' AS DateTime))
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [Name], [rowguid], [ModifiedDate]) VALUES (3, N'Main Office', N'8eeec28c-07a2-4fb9-ad0a-42d4a0bbc575', CAST(N'2008-04-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [Name], [rowguid], [ModifiedDate]) VALUES (4, N'Primary', N'24cb3088-4345-47c4-86c5-17b535133d1e', CAST(N'2008-04-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [Name], [rowguid], [ModifiedDate]) VALUES (5, N'Shipping', N'b29da3f8-19a3-47da-9daa-15c84f4a83a5', CAST(N'2008-04-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [Name], [rowguid], [ModifiedDate]) VALUES (6, N'Archive', N'a67f238a-5ba2-444b-966c-0467ed9c427f', CAST(N'2008-04-30T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AddressType] OFF
GO
