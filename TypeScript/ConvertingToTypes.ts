// Function to add two numbers
function addNumbers(a: number, b: number): number {
    return a + b;
}

// Function to greet a user
function greet(name: string): string {
    return `Hello, ${name}!`;
}

// Function to find the max number in an array
function findMax(arr: number[]): number {
    return Math.max(...arr);
}

// Function to update a property in an object
function updateObjectProperty<T extends object, K extends keyof T>(
    obj: T,
    property: K,
    value: T[K]
): T {
    obj[property] = value;
    return obj;
}

// Using the functions
console.log(addNumbers(10, 5)); // 15
console.log(greet("Alice")); // "Hello, Alice!"
console.log(findMax([1, 3, 2, 5, 4])); // 5
console.log(updateObjectProperty({ name: "Bob", age: 30 }, "age", 31)); // { name: "Bob", age: 31 }
