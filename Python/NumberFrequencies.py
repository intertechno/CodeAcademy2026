numbers = open("Numbers.txt", "r").read().splitlines()
frequencies = [0] * 10    # [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

for number in numbers:
    try:
        index = int(number) // 10
        frequencies[index] += 1
    except:
        print(f"Invalid number: '{number}'.")
print("Frequencies:", frequencies)

print("Number frequencies by group of ten:")
for i in range(len(frequencies)):   
    lower_bound = i * 10
    upper_bound = lower_bound + 9
    if i == 0:
        lower_bound = 1
    print(f"Numbers between {lower_bound} and {upper_bound}: {frequencies[i]}")
