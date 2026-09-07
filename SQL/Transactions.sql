BEGIN TRANSACTION

INSERT INTO Customers (CustomerID, CompanyName)
VALUES ("TEST1", "Test Company 1")

-- new customer is visible within the transaction
SELECT *
FROM Customers

ROLLBACK

-- new customer is not visible after rollback
SELECT *
FROM Customers
