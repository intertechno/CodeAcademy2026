import pandas as pd
import duckdb

sales = pd.read_csv("BrightMart-Sales.csv")

duckdb.sql("""
    SELECT
        Region,
        Category,
        SUM(Quantity * UnitPrice * (1 - Discount)) AS TotalSales
    FROM sales
    GROUP BY Region, Category
    ORDER BY TotalSales DESC
""").show()
