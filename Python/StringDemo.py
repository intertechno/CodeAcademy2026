input_data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

print(input_data[0])  # Output: A
print(input_data[5])  # Output: F
print(input_data[-1])  # Output: Z

# slices
print(input_data[0:5])  # Output: ABCDE
print(input_data[5:10])  # Output: FGHIJ

# slices: first and last 5 characters
print(input_data[:5])  # Output: ABCDE
print(input_data[-5:])  # Output: VWXYZ

# reverse the string
print(input_data[::-1])  # Output: ZYXWVUTSRQPONMLK...
