SQLCMD -S SCHVW2K12R2-DB\MSSQL2016 -i DropConstraints.sql
SQLCMD -S SCHVW2K12R2-DB\MSSQL2016 -i CreateCodeTable.sql
SQLCMD -S SCHVW2K12R2-DB\MSSQL2016 -i CreateProductTable.sql
SQLCMD -S SCHVW2K12R2-DB\MSSQL2016 -i CreateProjectTable.sql
SQLCMD -S SCHVW2K12R2-DB\MSSQL2016 -i CreateConstraints.sql
bcp CodesTable.dbo.Code in backup\Code.txt -c -t "|"  -T -S SCHVW2K12R2-DB\MSSQL2016
bcp CodesTable.dbo.Product in backup\Product.txt -c -t "|"  -T -S SCHVW2K12R2-DB\MSSQL2016 
bcp CodesTable.dbo.Project in backup\Project.txt -c -t "|"  -T -S SCHVW2K12R2-DB\MSSQL2016 
Pause