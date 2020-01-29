USE [CodesTable]
GO

/****** Object:  Table [dbo].[Code]    Script Date: 12/2/2015 7:42:39 AM ******/
IF OBJECT_ID('dbo.Code', 'U') IS NOT NULL
	DROP TABLE [dbo].[Code];
GO

/****** Object:  Table [dbo].[Code]    Script Date: 12/2/2015 7:42:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Code](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[ModifiedDt] [datetime] NOT NULL,
	[CreateDt] [datetime] NOT NULL,
	CONSTRAINT [PK_Code] PRIMARY KEY CLUSTERED  ([Id] ASC)
) ON [PRIMARY]
GO

--SET IDENTITY_INSERT [Code] ON
--GO 
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (1,1,'Small', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (2,1,'Medium', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (3,1,'Large', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (4,2,'Each', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (5,2,'Dozen', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (6,2,'Gross', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (7,2,'Lb.', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (8,3,'White', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (9,3,'Green', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (10,3,'Grey', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (11,3,'Black', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (12,4,'Consulting', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (13,4,'Software Selection', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (14,4,'Implementation', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (15,5,'New', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (16,5,'In Process', 1,GETDATE(),GETDATE());
--INSERT INTO [Code] ([Id],[CategoryId],[Name],[Active],[ModifiedDt],[CreateDt]) VALUES (17,5,'Closed', 1,GETDATE(),GETDATE());

--GO 
--SET IDENTITY_INSERT [Code] OFF
--GO