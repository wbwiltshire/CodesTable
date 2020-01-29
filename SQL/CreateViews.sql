USE [CodesTable]
GO



DROP VIEW IF EXISTS [dbo].[vwFindAllCodeView]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwFindAllCodeView]
AS
	SELECT t1.Id AS Id,t1.CategoryId AS CategoryId,t1.Name AS Name,t1.Active AS Active,t1.ModifiedDt AS ModifiedDt,t1.CreateDt AS CreateDt,
		CASE WHEN(t1.CategoryId = 1) THEN 'Size' WHEN(t1.CategoryId = 2) THEN 'UOM' WHEN(t1.CategoryId = 3) THEN 'Color' WHEN(t1.CategoryId = 4) THEN 'Project Type' WHEN(t1.CategoryId = 5) THEN 'Status'
		END AS CategoryName	
	FROM Code t1
	WHERE t1.Active=1;
GO

DROP VIEW IF EXISTS [dbo].[vwFindAllProductView];
GO

CREATE VIEW vwFindAllProductView
AS 
SELECT  P.SKU AS SKU, P.Description AS 'Description', C1.Name AS 'Size', c2.Name AS 'UOM', c3.Name AS 'Color'
FROM Product P
JOIN Code c1 ON P.SizeId = c1.Id
JOIN Code c2 ON P.UOMId = c2.Id
JOIN Code c3 ON P.ColorId = c3.Id
GO

DROP VIEW IF EXISTS [dbo].[vwFindAllProjectView];
GO

CREATE VIEW vwFindAllProjectView
AS 
SELECT  P.Id AS Id, P.Name AS Name, P.TypeId AS TypeId, P.ClientId AS ClientId, P.StatusId AS StatusId, P.Active AS Active, P.ModifiedDt AS ModifiedDt, P.CreateDt AS CreateDt,
	c1.Name AS TypeName, c2.Name AS StatusName
FROM Project P
JOIN Code c1 ON P.TypeId = c1.Id
JOIN Code c2 ON P.StatusId = c2.Id
GO
--IF EXISTS(select * FROM sys.views where name = 'vwCodeValuesByCategory')
--	DROP VIEW [dbo].[vwCodeValuesByCategory];
--GO

--CREATE VIEW vwCodeValuesByCategory
--AS 
--SELECT cc.Name AS Category, cc.Id AS CategoryId, c.Name AS CodeValue, c.Id AS CodeId
--FROM Code c
--JOIN CodeCategory cc ON c.CategoryId = cc.Id

