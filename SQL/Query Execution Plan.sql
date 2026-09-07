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
