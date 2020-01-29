USE [CodesTable]
GO

IF OBJECT_ID('dbo.Product', 'U') IS NOT NULL
  DROP TABLE [dbo].[Product]; 
GO

IF OBJECT_ID('dbo.Code', 'U') IS NOT NULL
DROP TABLE [dbo].[Code];
GO

IF OBJECT_ID('dbo.CodeCategory', 'U') IS NOT NULL
DROP TABLE [dbo].[CodeCategory];
GO
