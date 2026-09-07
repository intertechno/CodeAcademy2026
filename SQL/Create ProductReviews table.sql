/*
CREATE TABLE ProductReviews (
    ReviewID INTEGER,
    ProductID INTEGER,
    CustomerID TEXT,
    Rating INTEGER,
    ReviewText TEXT,
    ReviewDate DATE
);
*/

CREATE TABLE ProductReviews (
    ReviewID INTEGER PRIMARY KEY,
    ProductID INTEGER,
    CustomerID TEXT,
    Rating INTEGER,
    ReviewText TEXT,
    ReviewDate DATE,

    -- Customer must exist in Customers table
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),

    -- Product must exist in Products table
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),

    -- Rating constraint: only values 1–5 allowed
    CHECK (Rating BETWEEN 1 AND 5)
);
