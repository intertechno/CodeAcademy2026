-- =============================================
-- DIMENSION TABLES
-- =============================================

CREATE TABLE Dim_Date (
    date_key        INT           NOT NULL,
    full_date       DATE          NOT NULL,
    day             TINYINT       NOT NULL,
    month           TINYINT       NOT NULL,
    month_name      VARCHAR(20)   NOT NULL,
    quarter         TINYINT       NOT NULL,
    year            SMALLINT      NOT NULL,
    week            TINYINT       NOT NULL,
    weekday         VARCHAR(20)   NOT NULL,
    holiday_flag    BIT           NOT NULL DEFAULT 0,

    CONSTRAINT PK_Dim_Date
        PRIMARY KEY (date_key),

    CONSTRAINT UQ_Dim_Date_FullDate
        UNIQUE (full_date)
);


CREATE TABLE Dim_Customer (
    customer_key    INT           IDENTITY(1,1) NOT NULL,
    customer_id     VARCHAR(50)   NOT NULL,
    customer_name   VARCHAR(200)  NULL,
    gender          VARCHAR(20)   NULL,
    age_group       VARCHAR(20)   NULL,
    loyalty_status  VARCHAR(50)   NULL,

    CONSTRAINT PK_Dim_Customer
        PRIMARY KEY (customer_key)
);


CREATE TABLE Dim_Product (
    product_key     INT           IDENTITY(1,1) NOT NULL,
    product_id      VARCHAR(50)   NOT NULL,
    product_name    VARCHAR(200)  NOT NULL,
    category        VARCHAR(100)  NULL,
    subcategory     VARCHAR(100)  NULL,
    brand           VARCHAR(100)  NULL,

    CONSTRAINT PK_Dim_Product
        PRIMARY KEY (product_key)
);


CREATE TABLE Dim_Region (
    region_key      INT           IDENTITY(1,1) NOT NULL,
    region_name     VARCHAR(100)  NOT NULL,
    country         VARCHAR(100)  NOT NULL,

    CONSTRAINT PK_Dim_Region
        PRIMARY KEY (region_key)
);


CREATE TABLE Dim_Store (
    store_key       INT           IDENTITY(1,1) NOT NULL,
    store_id        VARCHAR(50)   NOT NULL,
    store_name      VARCHAR(200)  NOT NULL,
    city            VARCHAR(100)  NULL,
    region_key      INT           NOT NULL,

    CONSTRAINT PK_Dim_Store
        PRIMARY KEY (store_key),

    CONSTRAINT FK_Dim_Store_Region
        FOREIGN KEY (region_key)
        REFERENCES Dim_Region(region_key)
);


CREATE TABLE Dim_Channel (
    channel_key     INT           IDENTITY(1,1) NOT NULL,
    channel_name    VARCHAR(50)   NOT NULL,

    CONSTRAINT PK_Dim_Channel
        PRIMARY KEY (channel_key)
);


-- =============================================
-- FACT TABLE
-- =============================================

CREATE TABLE Fact_Sales (
    sales_key           BIGINT         IDENTITY(1,1) NOT NULL,
    date_key            INT            NOT NULL,
    customer_key        INT            NULL,
    product_key         INT            NOT NULL,
    store_key           INT            NULL,
    channel_key         INT            NOT NULL,
    transaction_id      VARCHAR(100)   NOT NULL,

    quantity_sold       INT            NOT NULL,
    unit_price          DECIMAL(18,2)  NOT NULL,
    gross_sales_amount  DECIMAL(18,2)  NOT NULL,
    discount_amount     DECIMAL(18,2)  NOT NULL DEFAULT 0,
    net_sales_amount    DECIMAL(18,2)  NOT NULL,

    CONSTRAINT PK_Fact_Sales
        PRIMARY KEY (sales_key),

    CONSTRAINT FK_Fact_Sales_Date
        FOREIGN KEY (date_key)
        REFERENCES Dim_Date(date_key),

    CONSTRAINT FK_Fact_Sales_Customer
        FOREIGN KEY (customer_key)
        REFERENCES Dim_Customer(customer_key),

    CONSTRAINT FK_Fact_Sales_Product
        FOREIGN KEY (product_key)
        REFERENCES Dim_Product(product_key),

    CONSTRAINT FK_Fact_Sales_Store
        FOREIGN KEY (store_key)
        REFERENCES Dim_Store(store_key),

    CONSTRAINT FK_Fact_Sales_Channel
        FOREIGN KEY (channel_key)
        REFERENCES Dim_Channel(channel_key),

    CONSTRAINT CK_Fact_Sales_Quantity
        CHECK (quantity_sold > 0),

    CONSTRAINT CK_Fact_Sales_UnitPrice
        CHECK (unit_price >= 0),

    CONSTRAINT CK_Fact_Sales_GrossSales
        CHECK (gross_sales_amount >= 0),

    CONSTRAINT CK_Fact_Sales_Discount
        CHECK (discount_amount >= 0),

    CONSTRAINT CK_Fact_Sales_NetSales
        CHECK (net_sales_amount >= 0)
);
