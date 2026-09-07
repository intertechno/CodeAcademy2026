const fruits = ["apple", "banana", "cherry"];
const vegetables = ["spinach", "carrot", "potato"];

// classic method with for loop
const combinedClassic = [];
for (let i = 0; i < fruits.length; i++) {
  combinedClassic.push(fruits[i]);
}

for (let i = 0; i < vegetables.length; i++) {
  combinedClassic.push(vegetables[i]);
}
console.log("Combined using classic method:", combinedClassic);

// using spread operator
const combinedSpread = [...fruits, ...vegetables];
console.log("Combined using spread operator:", combinedSpread);
