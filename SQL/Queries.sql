--Select all the Products
SELECT SKU, Description, Size, UOM, Color 
FROM vwProducts

--Select all Producst with (UOM) of Each 
SELECT SKU, Description, Size, UOM, Color 
FROM vwProducts
WHERE UOM = 'Each'

--Display the options for a category
SELECT CategoryId, Category, CodeId, CodeValue
FROM vwCodeValuesByCategory
WHERE Category = 'Color'
--WHERE Category = 'Size'




