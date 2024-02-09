const fruits = ["Banana", "Orange", "Apple", "Mango","Strawberry"];
let size = fruits.length;
console.log("size: "+ size)
console.log(fruits.toString())
console.log(fruits.join(" * "))

let fruit = fruits.pop();
console.log("popped element is :" + fruit)
console.log(fruits)

let add = fruits.push("Kiwi");
console.log("pushed element is :" + add)
console.log(fruits)

fruits.shift();
console.log(fruits)

fruits.unshift("Lemon");
console.log(fruits)

// fruits.splice(2, 0, "Lemon", "Kiwi"); 
//(2) defines the position where new elements should be added (spliced in).
//(0) defines how many elements should be removed.
//rest of the parameters ("Lemon" , "Kiwi") define the new elements to be added.
fruits.splice(0, 1);
console.log(fruits)

delete fruits[0];
console.log(fruits)

// const citrus = fruits.slice(1);
const citrus = fruits.slice(1, 3);
console.log(citrus)

const myGirls = ["Cecilie", "Lone"];
const myBoys = ["Emil", "Tobias", "Linus"];

const myChildren = myGirls.concat(myBoys);
console.log(myChildren)