import numpy as np

# The locations
locations = np.array([
    "Helsinki", "Tampere", "Oulu", "Kuopio", "Rovaniemi",
    "Turku", "Jyväskylä", "Lahti", "Vaasa", "Joensuu"
])

# Daily average temperatures (°C) for each city
temperatures = np.array([21, 26, 19, 23, 15, 28, 24, 27, 20, 22])

print("Daily temperatures:")
for loc, temp in zip(locations, temperatures):
    print(f"{loc:10s} : {temp} °C")

# 1. Sort days by temperature (ascending)
sorted_indices = np.argsort(temperatures)
print("Cities sorted by temperature (coldest → warmest):")
for idx in sorted_indices:
    print(f"{locations[idx]:10s} : {temperatures[idx]} °C")

# 2. Filter days above 25°C
hot_days_mask = temperatures > 25
# print(hot_days_mask)  # This will show a boolean array indicating which days are hot
print("Cities hotter than 25°C:")
for loc, temp in zip(locations[hot_days_mask], temperatures[hot_days_mask]):
    print(f"{loc:10s} : {temp} °C")

# 3. Find the coldest day
coldest_index = np.argmin(temperatures)
print(f"Coldest city: {locations[coldest_index]} with {temperatures[coldest_index]} °C")
