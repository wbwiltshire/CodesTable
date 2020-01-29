bcp CodesTable.dbo.Code out backup\Code.txt -c -t "|"  -T -S SCHVW2K12R2-DB\MSSQL2016
bcp CodesTable.dbo.Product out backup\Product.txt -c -t "|"  -T -S SCHVW2K12R2-DB\MSSQL2016 
bcp CodesTable.dbo.Project out backup\Project.txt -c -t "|"  -T -S SCHVW2K12R2-DB\MSSQL2016 