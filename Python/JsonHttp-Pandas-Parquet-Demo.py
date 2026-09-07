# note: "pip install pandas", "pip install pyarrow", "pip install requests" and "pip install duckdb" are needed!
import duckdb
import pandas as pd
import requests

Products_URL = "https://dummyjson.com/products"

def fetch_products():
    products = []
    response = requests.get(Products_URL, timeout=20)
    response.raise_for_status()
    data = response.json()
    batch = data["products"]
    products.extend(batch)
    return products


# read products using HTTP request
print("Starting to fetch data...")
products = fetch_products()
print("Products data fetched from HTTP API.")

# create a Pandas DataFrame from the data
df = pd.json_normalize(products)

# select columns for an analytics-friendly version
cols = ["id","title","category","price","rating","stock"]
df = df[cols].copy()

# show information about the cleaner data
print(df.head())
print(df.info())

# save as a CSV file for comparison
df.to_csv("products.csv", index=False)

# save as partitioned Parquet (using PyArrow engine)
df.to_parquet("Parquet Output",
    engine="pyarrow", index=False, partition_cols=["category"], compression="snappy")

print("Data saved to disk.")

# ----------------
# answering the questions
# ----------------

# 1. Which categories have the highest average price?
print("--------")
avg_price_by_category = (
    df.groupby("category", as_index=False)
      .agg(avg_price=("price", "mean"),
           product_count=("id", "count"))
      .sort_values("avg_price", ascending=False)
)
print(avg_price_by_category)

# 2. Which products are low-stock but have a high rating?
LOW_STOCK_LIMIT = 20
HIGH_RATING_LIMIT = 4.5

print("--------")
low_stock_high_rating = (
    df[
        (df["stock"] < LOW_STOCK_LIMIT) &
        (df["rating"] >= HIGH_RATING_LIMIT)
    ]
    .sort_values(["rating", "stock"], ascending=[False, True])
)
print(low_stock_high_rating)

# 3. What is the stock value in total? (using DuckDB)
print("--------")
stock_value_by_category = duckdb.sql(f"""
    SELECT
        category,
        ROUND(SUM(stock * price), 2) AS stock_value
    FROM read_parquet("Parquet Output")
    GROUP BY category
    ORDER BY stock_value DESC
""").df()
print(stock_value_by_category)
