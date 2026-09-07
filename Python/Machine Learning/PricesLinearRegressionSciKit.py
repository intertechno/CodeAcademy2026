import pandas as pd
from sklearn.linear_model import LinearRegression

prices = pd.read_csv("Prices.csv")
# print(prices)
# exit()

model = LinearRegression()
years = prices.drop("price", axis="columns")
# print(years)
model.fit(years, prices.price)
print("Regression model created.")

prediction = model.predict([[2025]])
print("Price prediction for year 2025:", prediction)

prediction = model.predict([[2026]])
print("Price prediction for year 2026:", prediction)

prediction = model.predict([[2027]])
print("Price prediction for year 2027:", prediction)

prediction = model.predict([[2028]])
print("Price prediction for year 2028:", prediction)
