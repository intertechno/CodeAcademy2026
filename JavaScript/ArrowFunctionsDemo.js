function add(a, b) {
  return a + b;
}

function getRandomNumber() {
  return Math.random();
}

function createUser(name, age) {
  return {
    name: name,
    age: age
  };
}

// -------------------------
// Refactored using Arrow Functions
// -------------------------
const addArrow = (a, b) => a + b;

const getRandomNumberArrow = () => Math.random();

const createUserArrow = (name, age) => ({
  name: name,
  age: age
});
