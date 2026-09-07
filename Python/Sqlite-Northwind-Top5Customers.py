import numpy as np
import sqlite3

# Connect to database
conn = sqlite3.connect("northwind.db")
cursor = conn.cursor()

# Get raw data only (do not use aggregation in SQL)
cursor.execute("""
SELECT CustomerID, CompanyName
FROM Customers
""")
customers = cursor.fetchall()

cursor.execute("""
SELECT CustomerID
FROM Orders
WHERE CustomerID IS NOT NULL
""")
orders = cursor.fetchall()

conn.close()

# Convert to NumPy arrays
customer_ids = np.array([row[0] for row in customers])
customer_names = np.array([row[1] for row in customers])

order_customer_ids = np.array([row[0] for row in orders])

# Count how many times each customer appears in orders
# np.unique with return_counts counts occurrences
unique_ids, counts = np.unique(
    order_customer_ids,
    return_counts=True
)

# Build a lookup so counts align with all customers
count_lookup = dict(zip(unique_ids, counts))

order_counts = np.array([
    count_lookup.get(customer_id, 0)
    for customer_id in customer_ids
])

# Sort descending by order count
top_indices = np.argsort(order_counts)[::-1][:5]

print("Top 5 customers by order count:\n")

for i in top_indices:
    print(
        f"{customer_names[i]:35}"
        f" Orders: {order_counts[i]}"
    )
