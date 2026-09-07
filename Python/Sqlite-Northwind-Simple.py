import sqlite3

# open the connection
con = sqlite3.connect("Northwind.db")

# read data and print results
cur = con.cursor()
cur.execute("SELECT * FROM Customers WHERE Country='Finland'")
for row in cur:
    print(row)

# close the connection
con.close()
print("Database connection closed.")
