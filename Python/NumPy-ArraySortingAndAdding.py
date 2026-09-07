import numpy as np

my_numbers = [6, 12, 10, 5, 3, 8, 11, 7, 4, 2]
arr = np.array(my_numbers)
print(arr)

arr_to_sort = np.array(my_numbers)
arr_to_sort.sort()
print(arr_to_sort)

# ---------------

my_numbers2 = [3, 6, 14, 4, 5, 9, 11, 13, 1, 7]
arr2 = np.array(my_numbers2)
print(arr2)

print("------------------")
# sum_arr = np.add(arr, arr2)

sum_arr = arr + arr2
print(sum_arr)
