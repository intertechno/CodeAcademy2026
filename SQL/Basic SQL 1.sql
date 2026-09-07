-- a) All Finnish customers
SELECT CompanyName
FROM Customers
WHERE Country = 'Finland'




-- b) All orders for the customer "Que Delícia"
SELECT CustomerID
FROM Customers
WHERE CompanyName = 'Que Delícia'

SELECT *
FROM Orders
WHERE CustomerID = 'QUEDE'

SELECT *
FROM Orders
WHERE CustomerID = (SELECT CustomerID
                    FROM Customers
                    WHERE CompanyName = 'Que Delícia')

-- c) All employees in London.
SELECT *
FROM Employees
WHERE City = 'London' AND Country = 'UK'
