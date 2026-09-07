const user = {
  name: "Alice",
  age: 25
};

/*
const name = user.name;
const age = user.age;
*/

// Using destructuring assignment
const { name, age } = user;
console.log(`Name: ${name}, Age: ${age}`);

const product = {
  id: 42,
  price: 9.99
};

/*
const productId = product.id;
const productPrice = product.price;
*/

// Using destructuring assignment
const { id: productId, price: productPrice } = product;
console.log(`Product ID: ${productId}, Product Price: ${productPrice}`);

const numbers = [10, 20, 30, 40];
let [a, b] = numbers;
console.log(`a: ${a}, b: ${b}`);

let valueOfA = numbers[0];
let valueOfB = numbers[1];
