-- Tables for Microsoft SQL Server
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,

    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,

    Email NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(25) NULL,

    StreetAddress NVARCHAR(255) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(100) NOT NULL,
    ZipCode NVARCHAR(20) NOT NULL,

    DateOfBirth DATE NULL,

    CONSTRAINT UQ_Customers_Email UNIQUE (Email)
);

CREATE TABLE CommunicationHistory
(
    CommunicationID INT IDENTITY(1,1) PRIMARY KEY,

    CustomerID INT NOT NULL,

    CommunicationType NVARCHAR(50) NOT NULL,
    CommunicationDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

    Subject NVARCHAR(255) NULL,
    Notes NVARCHAR(MAX) NULL,

    CONSTRAINT FK_CommunicationHistory_Customers
        FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID)
);

CREATE TABLE CommunicationTypes
(
    CommunicationTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL UNIQUE
);

----------------------
INSERT INTO Customers
(
    FirstName,
    LastName,
    Email,
    Phone,
    StreetAddress,
    City,
    State,
    ZipCode,
    DateOfBirth
)
VALUES
(
    'John',
    'Smith',
    'john.smith@example.com',
    '555-1001',
    '123 Main St',
    'Seattle',
    'WA',
    '98101',
    '1985-04-12'
),
(
    'Sarah',
    'Johnson',
    'sarah.johnson@example.com',
    '555-1002',
    '456 Oak Ave',
    'Portland',
    'OR',
    '97201',
    '1990-08-25'
),
(
    'Michael',
    'Brown',
    'michael.brown@example.com',
    '555-1003',
    '789 Pine Rd',
    'Denver',
    'CO',
    '80202',
    '1978-11-03'
),
(
    'Emily',
    'Davis',
    'emily.davis@example.com',
    '555-1004',
    '321 Cedar Ln',
    'Austin',
    'TX',
    '78701',
    '1995-02-18'
),
(
    'David',
    'Wilson',
    'david.wilson@example.com',
    '555-1005',
    '654 Maple Dr',
    'Chicago',
    'IL',
    '60601',
    '1982-06-30'
);

INSERT INTO CommunicationTypes (TypeName)
VALUES
    ('Email'),
    ('Phone Call'),
    ('SMS'),
    ('Direct Message'),
    ('Video Call');

INSERT INTO CommunicationHistory
(
    CustomerID,
    CommunicationTypeID,
    CommunicationDate,
    Subject,
    Notes
)
VALUES
(
    1,
    1,
    '2026-06-01 09:15:00',
    'Welcome Email',
    'Sent account setup instructions.'
),
(
    1,
    2,
    '2026-06-03 14:30:00',
    'Follow-up Call',
    'Customer requested product pricing information.'
),
(
    2,
    1,
    '2026-06-02 10:00:00',
    'Newsletter Signup',
    'Customer subscribed to monthly newsletter.'
),
(
    2,
    3,
    '2026-06-05 16:45:00',
    NULL,
    'Sent appointment reminder via SMS.'
),
(
    3,
    2,
    '2026-06-04 11:20:00',
    'Support Call',
    'Resolved login issue.'
),
(
    3,
    5,
    '2026-06-08 15:00:00',
    'Product Demonstration',
    'Conducted online demo of premium features.'
),
(
    4,
    4,
    '2026-06-06 13:10:00',
    NULL,
    'Customer asked questions through social media DM.'
),
(
    4,
    1,
    '2026-06-07 09:00:00',
    'Follow-up Email',
    'Provided requested documentation.'
),
(
    5,
    2,
    '2026-06-09 17:15:00',
    'Contract Discussion',
    'Discussed renewal terms.'
),
(
    5,
    1,
    '2026-06-10 08:30:00',
    'Contract Proposal',
    'Sent proposal document for review.'
);

