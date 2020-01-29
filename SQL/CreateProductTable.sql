USE [CodesTable]
GO

DROP TABLE IF EXISTS [dbo].[Product];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](50) NOT NULL,
	[SizeId] [int] NOT NULL,				-- FK
	[UOMId] [int] NOT NULL,				-- FK
	[ColorId] [int] NOT NULL,			-- FK
	[Description] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[ModifiedDt] [datetime] NOT NULL,
	[CreateDt] [datetime] NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
ON [PRIMARY]
)
GO

--SET IDENTITY_INSERT [Product] ON
--GO 
--INSERT INTO [Product] ([Id],[SKU],[SizeId],[UOMId],[ColorId],[Description],[Active],[ModifiedDt],[CreateDt]) VALUES (1,'11111',1,4,11,'Claw Hammer',1,GETDATE(),GETDATE());
--INSERT INTO [Product] ([Id],[SKU],[SizeId],[UOMId],[ColorId],[Description],[Active],[ModifiedDt],[CreateDt]) VALUES (2,'22222',2,5,8,'Light Switch',1,GETDATE(),GETDATE());
--INSERT INTO [Product] ([Id],[SKU],[SizeId],[UOMId],[ColorId],[Description],[Active],[ModifiedDt],[CreateDt]) VALUES (3,'33333',3,6,9,'Toilet Flapper',1,GETDATE(),GETDATE());
--INSERT INTO [Product] ([Id],[SKU],[SizeId],[UOMId],[ColorId],[Description],[Active],[ModifiedDt],[CreateDt]) VALUES (4,'44444',12,4,10,'8x4 Plywood',1,GETDATE(),GETDATE());
--GO 
--SET IDENTITY_INSERT [Product] OFF
--GO