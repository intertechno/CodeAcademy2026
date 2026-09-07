-- a) How many customers does Northwind have?
SELECT COUNT(*) AS CustomerCount
FROM Customers

-- b) What is the stock value of Northwind presently?
SELECT ProductName, UnitPrice, UnitsInStock, UnitPrice * UnitsInStock
FROM Products

SELECT SUM(UnitPrice * UnitsInStock)
FROM Products

-- c) How much tofu (in $) has Northwind sold?
SELECT *
FROM [Order Details]
WHERE ProductID = 14 OR ProductID = 74

SELECT SUM(UnitPrice * Quantity)
FROM [Order Details]
WHERE ProductID = 14 OR ProductID = 74

SELECT SUM(UnitPrice * Quantity * (1 - Discount))
FROM [Order Details]
WHERE ProductID = 14 OR ProductID = 74

SELECT ProductID
FROM Products
WHERE ProductName LIKE '%Tofu%'

SELECT SUM(UnitPrice * Quantity * (1 - Discount))
FROM [Order Details]
WHERE ProductID IN (SELECT ProductID
                    FROM Products
                    WHERE ProductName LIKE '%Tofu%')
