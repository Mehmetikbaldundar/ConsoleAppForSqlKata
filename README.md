### **Örnek 1:**
MSSQL Sorgusu:

```sql
SELECT [c].[CategoryName], COUNT(p.ProductID) AS ToplamAdet FROM [Products] AS [p]
INNER JOIN [Categories] AS [c] ON [c].[CategoryID] = [p].[CategoryID] GROUP BY [c].[CategoryName]
```
Sorgu Sonuçlari:
```
{DapperRow, CategoryName = 'Beverages', ToplamAdet = '12'}
{DapperRow, CategoryName = 'Condiments', ToplamAdet = '12'}
{DapperRow, CategoryName = 'Confections', ToplamAdet = '13'}
{DapperRow, CategoryName = 'Dairy Products', ToplamAdet = '10'}
{DapperRow, CategoryName = 'Grains/Cereals', ToplamAdet = '7'}
{DapperRow, CategoryName = 'Meat/Poultry', ToplamAdet = '6'}
{DapperRow, CategoryName = 'Produce', ToplamAdet = '5'}
{DapperRow, CategoryName = 'Seafood', ToplamAdet = '12'}
```
### **Örnek 2:**
MSSQL Sorgusu:
```sql
SELECT e.FirstName + ' ' + e.LastName AS CalisanAdSoyad, SUM(od.Quantity * od.UnitPrice) AS ToplamSatisMiktari FROM [Employees] AS [e]
INNER JOIN [Orders] AS [o] ON [o].[EmployeeID] = [e].[EmployeeID]
INNER JOIN [Order Details] AS [od] ON [od].[OrderID] = [o].[OrderID] GROUP BY e.FirstName + ' ' + e.LastName
```

Sorgu Sonuçlari:
```
{DapperRow, CalisanAdSoyad = 'Nancy Davolio', ToplamSatisMiktari = '202143.7100'}
{DapperRow, CalisanAdSoyad = 'Andrew Fuller', ToplamSatisMiktari = '177749.2600'}
{DapperRow, CalisanAdSoyad = 'Michael Suyama', ToplamSatisMiktari = '78198.1000'}
{DapperRow, CalisanAdSoyad = 'Janet Leverling', ToplamSatisMiktari = '213051.3000'}
{DapperRow, CalisanAdSoyad = 'Anne Dodsworth', ToplamSatisMiktari = '82964.0000'}
{DapperRow, CalisanAdSoyad = 'Laura Callahan', ToplamSatisMiktari = '133301.0300'}
{DapperRow, CalisanAdSoyad = 'Robert King', ToplamSatisMiktari = '141295.9900'}
{DapperRow, CalisanAdSoyad = 'Margaret Peacock', ToplamSatisMiktari = '250187.4500'}
{DapperRow, CalisanAdSoyad = 'Steven Buchanan', ToplamSatisMiktari = '75567.7500'}
```
### **Örnek 3:**
MSSQL Sorgusu:
```sql
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS CalisanAdSoyad, COUNT(od.Quantity * od.UnitPrice) AS ToplamSatisMiktari FROM [Orders] AS [o]
INNER JOIN [Employees] AS [e] ON [e].[EmployeeID] = [o].[EmployeeID]
INNER JOIN [Order Details] AS [od] ON [od].[OrderID] = [o].[OrderID] GROUP BY CONCAT(e.FirstName, ' ', e.LastName) HAVING COUNT(o.OrderID) > 50
```

Sorgu Sonuçlari:
```
{DapperRow, CalisanAdSoyad = 'Nancy Davolio', ToplamSatisMiktari = '345'}
{DapperRow, CalisanAdSoyad = 'Andrew Fuller', ToplamSatisMiktari = '241'}
{DapperRow, CalisanAdSoyad = 'Michael Suyama', ToplamSatisMiktari = '168'}
{DapperRow, CalisanAdSoyad = 'Janet Leverling', ToplamSatisMiktari = '321'}
{DapperRow, CalisanAdSoyad = 'Anne Dodsworth', ToplamSatisMiktari = '107'}
{DapperRow, CalisanAdSoyad = 'Laura Callahan', ToplamSatisMiktari = '260'}
{DapperRow, CalisanAdSoyad = 'Robert King', ToplamSatisMiktari = '176'}
{DapperRow, CalisanAdSoyad = 'Margaret Peacock', ToplamSatisMiktari = '420'}
{DapperRow, CalisanAdSoyad = 'Steven Buchanan', ToplamSatisMiktari = '117'}
```
#### **Örnek 4:**
MSSQL Sorgusu:
```sql
SELECT e.LastName + ' ' + e.FirstName AS AdSoyad, [t].[TerritoryDescription] FROM [Employees] AS [e]
INNER JOIN [EmployeeTerritories] AS [et] ON [et].[EmployeeID] = [e].[EmployeeID]
INNER JOIN [Territories] AS [t] ON [t].[TerritoryID] = [et].[TerritoryID]
```
Sorgu Sonuçlari:
```
{DapperRow, AdSoyad = 'Davolio Nancy', TerritoryDescription = 'Wilton'}
{DapperRow, AdSoyad = 'Davolio Nancy', TerritoryDescription = 'Neward'}
{DapperRow, AdSoyad = 'Fuller Andrew', TerritoryDescription = 'Westboro'}
{DapperRow, AdSoyad = 'Fuller Andrew', TerritoryDescription = 'Bedford'}
{DapperRow, AdSoyad = 'Fuller Andrew', TerritoryDescription = 'Georgetow'}
{DapperRow, AdSoyad = 'Fuller Andrew', TerritoryDescription = 'Boston'}
{DapperRow, AdSoyad = 'Fuller Andrew', TerritoryDescription = 'Cambridge'}
{DapperRow, AdSoyad = 'Fuller Andrew', TerritoryDescription = 'Braintree'}
{DapperRow, AdSoyad = 'Fuller Andrew', TerritoryDescription = 'Louisville'}
{DapperRow, AdSoyad = 'Leverling Janet', TerritoryDescription = 'Atlanta'}
{DapperRow, AdSoyad = 'Leverling Janet', TerritoryDescription = 'Savannah'}
{DapperRow, AdSoyad = 'Leverling Janet', TerritoryDescription = 'Orlando'}
{DapperRow, AdSoyad = 'Leverling Janet', TerritoryDescription = 'Tampa'}
{DapperRow, AdSoyad = 'Peacock Margaret', TerritoryDescription = 'Rockville'}
{DapperRow, AdSoyad = 'Peacock Margaret', TerritoryDescription = 'Greensboro'}
{DapperRow, AdSoyad = 'Peacock Margaret', TerritoryDescription = 'Cary'}
{DapperRow, AdSoyad = 'Buchanan Steven', TerritoryDescription = 'Providence'}
{DapperRow, AdSoyad = 'Buchanan Steven', TerritoryDescription = 'Morristown'}
{DapperRow, AdSoyad = 'Buchanan Steven', TerritoryDescription = 'Edison'}
{DapperRow, AdSoyad = 'Buchanan Steven', TerritoryDescription = 'New York'}
{DapperRow, AdSoyad = 'Buchanan Steven', TerritoryDescription = 'New York'}
{DapperRow, AdSoyad = 'Buchanan Steven', TerritoryDescription = 'Mellvile'}
{DapperRow, AdSoyad = 'Buchanan Steven', TerritoryDescription = 'Fairport'}
{DapperRow, AdSoyad = 'Suyama Michael', TerritoryDescription = 'Phoenix'}
{DapperRow, AdSoyad = 'Suyama Michael', TerritoryDescription = 'Scottsdale'}
{DapperRow, AdSoyad = 'Suyama Michael', TerritoryDescription = 'Bellevue'}
{DapperRow, AdSoyad = 'Suyama Michael', TerritoryDescription = 'Redmond'}
{DapperRow, AdSoyad = 'Suyama Michael', TerritoryDescription = 'Seattle'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Hoffman Estates'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Chicago'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Denver'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Colorado Springs'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Santa Monica'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Menlo Park'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'San Francisco'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Campbell'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Santa Clara'}
{DapperRow, AdSoyad = 'King Robert', TerritoryDescription = 'Santa Cruz'}
{DapperRow, AdSoyad = 'Callahan Laura', TerritoryDescription = 'Philadelphia'}
{DapperRow, AdSoyad = 'Callahan Laura', TerritoryDescription = 'Beachwood'}
{DapperRow, AdSoyad = 'Callahan Laura', TerritoryDescription = 'Findlay'}
{DapperRow, AdSoyad = 'Callahan Laura', TerritoryDescription = 'Racine'}
{DapperRow, AdSoyad = 'Dodsworth Anne', TerritoryDescription = 'Hollis'}
{DapperRow, AdSoyad = 'Dodsworth Anne', TerritoryDescription = 'Portsmouth'}
{DapperRow, AdSoyad = 'Dodsworth Anne', TerritoryDescription = 'Southfield'}
{DapperRow, AdSoyad = 'Dodsworth Anne', TerritoryDescription = 'Troy'}
{DapperRow, AdSoyad = 'Dodsworth Anne', TerritoryDescription = 'Bloomfield Hills'}
{DapperRow, AdSoyad = 'Dodsworth Anne', TerritoryDescription = 'Roseville'}
{DapperRow, AdSoyad = 'Dodsworth Anne', TerritoryDescription = 'Minneapolis'}
```
### **Örnek 5:**
```
Çalisan soyadlarini seçin:
1. Davolio
2. Fuller
3. Leverling
Seçiminizi yapin (1, 2, 3, ...): 1
```
MSSQL Sorgusu:
```sql
SELECT e.LastName + ' ' + e.FirstName AS AdSoyad, [t].[TerritoryDescription] FROM [Employees] AS [e]
INNER JOIN [EmployeeTerritories] AS [et] ON [et].[EmployeeID] = [e].[EmployeeID]
INNER JOIN [Territories] AS [t] ON [t].[TerritoryID] = [et].[TerritoryID] WHERE [e].[LastName] = @p0
```
Sorgu Sonuçlari:
```
{DapperRow, AdSoyad = 'Davolio Nancy', TerritoryDescription = 'Wilton'}
{DapperRow, AdSoyad = 'Davolio Nancy', TerritoryDescription = 'Neward'}
```
### **Örnek 6:**
MSSQL Sorgusu:
```sql
SELECT [p].[ProductName], (SELECT CategoryName FROM Categories WHERE CategoryID = p.CategoryID) AS CategoryName FROM [Products] AS [p]
```
Sorgu Sonuçlari:
```
{DapperRow, ProductName = 'Chai', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Chang', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Aniseed Syrup', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Chef Anton's Cajun Seasoning', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Chef Anton's Gumbo Mix', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Grandma's Boysenberry Spread', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Uncle Bob's Organic Dried Pears', CategoryName = 'Produce'}
{DapperRow, ProductName = 'Northwoods Cranberry Sauce', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Mishi Kobe Niku', CategoryName = 'Meat/Poultry'}
{DapperRow, ProductName = 'Ikura', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Queso Cabrales', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Queso Manchego La Pastora', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Konbu', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Tofu', CategoryName = 'Produce'}
{DapperRow, ProductName = 'Genen Shouyu', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Pavlova', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Alice Mutton', CategoryName = 'Meat/Poultry'}
{DapperRow, ProductName = 'Carnarvon Tigers', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Teatime Chocolate Biscuits', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Sir Rodney's Marmalade', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Sir Rodney's Scones', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Gustaf's Knäckebröd', CategoryName = 'Grains/Cereals'}
{DapperRow, ProductName = 'Tunnbröd', CategoryName = 'Grains/Cereals'}
{DapperRow, ProductName = 'Guaraná Fantástica', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'NuNuCa Nuß-Nougat-Creme', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Gumbär Gummibärchen', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Schoggi Schokolade', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Rössle Sauerkraut', CategoryName = 'Produce'}
{DapperRow, ProductName = 'Thüringer Rostbratwurst', CategoryName = 'Meat/Poultry'}
{DapperRow, ProductName = 'Nord-Ost Matjeshering', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Gorgonzola Telino', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Mascarpone Fabioli', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Geitost', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Sasquatch Ale', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Steeleye Stout', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Inlagd Sill', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Gravad lax', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Côte de Blaye', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Chartreuse verte', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Boston Crab Meat', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Jack's New England Clam Chowder', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Singaporean Hokkien Fried Mee', CategoryName = 'Grains/Cereals'}
{DapperRow, ProductName = 'Ipoh Coffee', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Gula Malacca', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Rogede sild', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Spegesild', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Zaanse koeken', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Chocolade', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Maxilaku', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Valkoinen suklaa', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Manjimup Dried Apples', CategoryName = 'Produce'}
{DapperRow, ProductName = 'Filo Mix', CategoryName = 'Grains/Cereals'}
{DapperRow, ProductName = 'Perth Pasties', CategoryName = 'Meat/Poultry'}
{DapperRow, ProductName = 'Tourtière', CategoryName = 'Meat/Poultry'}
{DapperRow, ProductName = 'Pâté chinois', CategoryName = 'Meat/Poultry'}
{DapperRow, ProductName = 'Gnocchi di nonna Alice', CategoryName = 'Grains/Cereals'}
{DapperRow, ProductName = 'Ravioli Angelo', CategoryName = 'Grains/Cereals'}
{DapperRow, ProductName = 'Escargots de Bourgogne', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Raclette Courdavault', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Camembert Pierrot', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Sirop d'érable', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Tarte au sucre', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Vegie-spread', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Wimmers gute Semmelknödel', CategoryName = 'Grains/Cereals'}
{DapperRow, ProductName = 'Louisiana Fiery Hot Pepper Sauce', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Louisiana Hot Spiced Okra', CategoryName = 'Condiments'}
{DapperRow, ProductName = 'Laughing Lumberjack Lager', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Scottish Longbreads', CategoryName = 'Confections'}
{DapperRow, ProductName = 'Gudbrandsdalsost', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Outback Lager', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Flotemysost', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Mozzarella di Giovanni', CategoryName = 'Dairy Products'}
{DapperRow, ProductName = 'Röd Kaviar', CategoryName = 'Seafood'}
{DapperRow, ProductName = 'Longlife Tofu', CategoryName = 'Produce'}
{DapperRow, ProductName = 'Rhönbräu Klosterbier', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Lakkalikööri', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Original Frankfurter grüne Soße', CategoryName = 'Condiments'}
```
### **Örnek 7:**
MSSQL Sorgusu:
```sql
SELECT [p].[ProductName], [c].[CategoryName] FROM [Products] AS [p]
INNER JOIN [Categories] AS [c] ON ([c].[CategoryID] = [p].[CategoryID] AND LOWER([c].[CategoryName]) like @p0) WHERE [p].[UnitsInStock] BETWEEN @p1 AND @p2
```
Sorgu Sonuçlari:
```
{DapperRow, ProductName = 'Chai', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Guaraná Fantástica', CategoryName = 'Beverages'}
{DapperRow, ProductName = 'Steeleye Stout', CategoryName = 'Beverages'}
```
