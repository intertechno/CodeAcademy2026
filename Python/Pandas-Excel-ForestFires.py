import pandas as pd

# Load the Excel file
df = pd.read_excel("Forestfires.xlsx", skiprows=3, usecols="B:N")

# Show first few rows
# print(df.head())
# print(df.columns)

# Basic statistics
# print(df.describe())

# ---------
weekend_days = ['sat', 'sun']
weekend_count = df[df['day'].isin(weekend_days)].shape[0]
weekday_count = df[~df['day'].isin(weekend_days)].shape[0]

print("Weekend fires:", weekend_count)
print("Weekday fires:", weekday_count)

# ---------
print("---------")
df['day_type'] = df['day'].apply(
    lambda x: 'weekend' if x in ['sat', 'sun'] else 'weekday'
)

counts = df['day_type'].value_counts()
print(counts)
