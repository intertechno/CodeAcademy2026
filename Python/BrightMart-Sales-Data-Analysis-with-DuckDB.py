import pandas as pd
import duckdb

# Load the CSV file from disk with Pandas.
sales = pd.read_csv("BrightMart-Sales.csv")

# Convert the Date column to a real date/time type.
sales["Date"] = pd.to_datetime(sales["Date"])

# Calculate sales value for each row.
sales["SalesValue"] = (
    sales["Quantity"] * sales["UnitPrice"] * (1 - sales["Discount"])
)

# Make the Pandas DataFrame available to DuckDB as a table named "sales".
con = duckdb.connect()
con.register("sales", sales)

# Question 2:
# Calculate total sales by month.

monthly_sales = con.execute("""
    SELECT
        date_trunc('month', Date) AS Month,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    GROUP BY Month
    ORDER BY Month
""").df()

print("\nTotal sales by month:")
print(monthly_sales)


# Question 3:
# Calculate total sales by product category.

category_sales = con.execute("""
    SELECT
        Category,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    GROUP BY Category
    ORDER BY TotalSales DESC
""").df()

print("\nTotal sales by product category:")
print(category_sales)


# Question 4:
# Calculate total sales by region.

region_sales = con.execute("""
    SELECT
        Region,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    GROUP BY Region
    ORDER BY TotalSales DESC
""").df()

print("\nTotal sales by region:")
print(region_sales)


# Question 5:
# Find monthly sales for one product category in one region.
#
# Example: Furniture sales in the South region.

filtered_sales = con.execute("""
    SELECT
        date_trunc('month', Date) AS Month,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    WHERE Category = 'Furniture'
      AND Region = 'South'
    GROUP BY Month
    ORDER BY Month
""").df()

print("\nMonthly Furniture sales in the South region:")
print(filtered_sales)


# Question 6:
# Which analyses could be described as roll-up, drill-down, slice, or dice?
#
# Roll-up example:
# Aggregate detailed daily sales into monthly sales.

roll_up = con.execute("""
    SELECT
        date_trunc('month', Date) AS Month,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    GROUP BY Month
    ORDER BY Month
""").df()

print("\nRoll-up example - sales by month:")
print(roll_up)


# Drill-down example:
# Move from monthly totals to the more detailed daily level.

drill_down = con.execute("""
    SELECT
        CAST(Date AS DATE) AS Day,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    GROUP BY Day
    ORDER BY Day
""").df()

print("\nDrill-down example - sales by day:")
print(drill_down)


# Slice example:
# Select one value from one dimension.
# Here, we select only the Electronics category.

slice_example = con.execute("""
    SELECT
        Region,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    WHERE Category = 'Electronics'
    GROUP BY Region
    ORDER BY Region
""").df()

print("\nSlice example - Electronics sales by region:")
print(slice_example)


# Dice example:
# Restrict the data using several dimensions at the same time.
# Here: Furniture + South region + January-March 2026.

dice_example = con.execute("""
    SELECT
        CAST(Date AS DATE) AS Date,
        Product,
        Region,
        ROUND(SalesValue, 2) AS SalesValue
    FROM sales
    WHERE Category = 'Furniture'
      AND Region = 'South'
      AND Date BETWEEN DATE '2026-01-01' AND DATE '2026-03-31'
    ORDER BY Date
""").df()

print("\nDice example - Furniture sales in South, Jan-Mar 2026:")
print(dice_example)


# Question 7:
# Suppose management often asks for monthly sales by region.
# How could the data warehouse be optimized for this type of analysis?
#
# One option is to create a pre-aggregated table containing monthly
# sales totals by region.

con.execute("""
    CREATE OR REPLACE TABLE monthly_region_sales AS
    SELECT
        date_trunc('month', Date) AS Month,
        Region,
        SUM(Quantity) AS QuantitySold,
        ROUND(SUM(SalesValue), 2) AS TotalSales
    FROM sales
    GROUP BY Month, Region
""")

monthly_region_sales = con.execute("""
    SELECT *
    FROM monthly_region_sales
    ORDER BY Month, Region
""").df()

print("\nPre-aggregated monthly sales by region:")
print(monthly_region_sales)

con.close()
