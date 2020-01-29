USE [CodesTable]
GO

--Product FK Constraints
--
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CONSTRAINT [FK_Product_Code_SizeId] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Code] ([Id])

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Code_SizeId]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD CONSTRAINT [FK_Product_Code_UOMId] FOREIGN KEY([UOMId])
REFERENCES [dbo].[Code] ([Id])

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Code_UOMId]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD CONSTRAINT [FK_Product_Code_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Code] ([Id])

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Code_ColorId]
GO

--Project FK Constraints
--
ALTER TABLE [dbo].[Project]  WITH CHECK ADD CONSTRAINT [FK_Project_Code_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Code] ([Id])

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Code_TypeId]
GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD CONSTRAINT [FK_Project_Code_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Code] ([Id])

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Code_StatusId]
GO