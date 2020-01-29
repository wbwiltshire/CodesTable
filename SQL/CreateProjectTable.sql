USE [CodesTable]
GO

--Drop Extended Properties
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Project') 
	BEGIN
		EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'Id'
		EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'Name'
		EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'TypeId'
		EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'ClientId'
		EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'Active'
		EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'ModifiedDt'
		EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'CreateDt'
	END
GO

--Drop and Recreate Table
DROP TABLE IF EXISTS [dbo].[Project]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Project](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [NVARCHAR](100) NULL,
	[TypeId] [INT] NOT NULL,            -- Foreign key
	[ClientId] [INT] NOT NULL,          -- Foreign key
	[StatusId] [INT] NOT NULL,          -- Foreign key
	[Active] [BIT] NOT NULL,
	[ModifiedDt] [DATETIME] NOT NULL,
	[CreateDt] [DATETIME] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([Id] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Add Extended Properties
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Project Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Project Type Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'TypeId'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Client Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'ClientId'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is Active' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'Active'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Modified Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'ModifiedDt'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Create Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Project', @level2type=N'COLUMN',@level2name=N'CreateDt'
GO

--SET IDENTITY_INSERT [Project] ON
--GO
--INSERT INTO [Project] ([Id],[Name],[TypeId],[ClientId],[StatusId],[Active],[ModifiedDt],[CreateDt]) VALUES (1,'DeMert Brands DR Plan',12,1,15,1,GETDATE(),GETDATE());
--INSERT INTO [Project] ([Id],[Name],[TypeId],[ClientId],[StatusId],[Active],[ModifiedDt],[CreateDt]) VALUES (2,'DeMert Brands ERP Selection',13,1,17,1,GETDATE(),GETDATE());
--INSERT INTO [Project] ([Id],[Name],[TypeId],[ClientId],[StatusId],[Active],[ModifiedDt],[CreateDt]) VALUES (3,'DeMert Brands D365 Implementation',14,1,16,1,GETDATE(),GETDATE());
--GO
--SET IDENTITY_INSERT [Project] OFF
--GO