-- Exercise 1: Insert a new customer into the Customers table.
INSERT INTO Customers (
    CustomerID, CompanyName, ContactName, ContactTitle,
    Address, City, Region, PostalCode, Country,
    Phone, Fax
)
VALUES (
    'NEW01', 'Acme Corporation', 'Jane Smith', 'Sales Manager',
    '123 Main Street', 'Seattle', 'WA', '98101', 'USA',
    '(206) 555-1234', '(206) 555-5678'
);
