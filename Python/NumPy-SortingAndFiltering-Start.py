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
