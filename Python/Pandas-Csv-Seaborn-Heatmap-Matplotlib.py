import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt

# 1. Load the CSV
df = pd.read_csv("FictiviaTemperatures.csv")

# 2. Pivot into year/month table
pivot_df = df.pivot(index="year", columns="month", values="avg_temp_c")

# 3. Draw heatmap
plt.figure(figsize=(10, 6))
sns.set_theme()
sns.heatmap(
    pivot_df,
    annot=True,        # show temperature values
    fmt=".1f",         # one decimal place
    cmap="coolwarm",   # blue = cold, red = hot
    cbar_kws={'label': 'Avg Temp (°C)'}
)

plt.title("Average Monthly Temperatures in Fictivia (2015-2020)")
plt.xlabel("Month")
plt.ylabel("Year")
plt.show()
