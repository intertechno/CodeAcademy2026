number_file = open("Numbers.txt", "r")

# loop through the lines and print all numbers that are even
for line in number_file:
    number = int(line.strip())
    if number % 2 == 0:
        print(number)

number_file.close()
