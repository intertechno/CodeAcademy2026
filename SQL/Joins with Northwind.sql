-- Practice 17/1
-- SELECT *
-- FROM Orders
-- JOIN Customers
-- ON Orders.CustomerID = Customers.CustomerID

SELECT
    o.OrderID,
    o.OrderDate,
    c.CompanyName
FROM Orders AS o
JOIN Customers AS c
    ON o.CustomerID = c.CustomerID
ORDER BY
    o.OrderDate DESC,
    o.OrderID DESC
LIMIT 10

-- Practice 17/2
SELECT
    p.ProductID,
    p.ProductName,
    c.CategoryName,
    p.UnitPrice
FROM Products AS p
JOIN Categories AS c
    ON p.CategoryID = c.CategoryID

-- Practice 17/3
SELECT
    c.CompanyName,
    COUNT(o.OrderID) AS NumberOfOrders
FROM Customers AS c
LEFT JOIN Orders AS o
    ON c.CustomerID = o.CustomerID
GROUP BY
    c.CompanyName
ORDER BY
    NumberOfOrders DESC,
    c.CompanyName ASC
