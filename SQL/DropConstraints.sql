USE [CodesTable]
GO

--
--Product FK Constraints
--
--Drop Constraints
ALTER TABLE [dbo].[Product] DROP CONSTRAINT IF EXISTS [FK_Product_Code_SizeId];
ALTER TABLE [dbo].[Product] DROP CONSTRAINT IF EXISTS [FK_Product_Code_UOMId];
ALTER TABLE [dbo].[Product] DROP CONSTRAINT IF EXISTS [FK_Product_Code_ColorId];
GO

--
--Project FK Constraints
--
--Drop Constraints
ALTER TABLE [dbo].[Project] DROP CONSTRAINT IF EXISTS [FK_Project_Code_TypeId]
ALTER TABLE [dbo].[Project] DROP CONSTRAINT IF EXISTS [FK_Project_Code_StatusId]
GO