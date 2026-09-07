csv_file = open("SalesData.csv", "r")
line_counter = 1
sales_counts = {}

for row in csv_file:
    if line_counter == 1:
        line_counter += 1
        continue

    row_parts = row.strip().split(",")
    product_id = int(row_parts[1])
    quantity = int(row_parts[2])

    if product_id in sales_counts:
        sales_counts[product_id] += quantity
    else:
        sales_counts[product_id] = quantity
 
    line_counter += 1

csv_file.close()

sorted_sales = sorted(sales_counts.items(), key=lambda item: item[1], reverse=True)
print(sorted_sales)
