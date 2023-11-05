// 1. Ways to print in JavaScript
// console.log("Hello World");
// alert("me");
// document.write("this is document write")

// 2. Javascript console API
// console.log("Hello World", 4 + 6, "Another log");
// console.warn("this is warning");
// console.error("This is an error");

// 3. JavaScript Variables
// What are Variables? - Containers to store data values


var number1 = 34;
var number2 = 56;
// console.log(number1 + number2);

// 4. Data types in JavaScript
// Numbers
var num1 = 455;
var num2 = 56.76;

// String
var str1 = "This is a string";
var str2 = 'This is also a string';

// Objects
var marks = {
    ishika: 34,
    deven: 78,
    bhavik: 99.977
}
// console.log(marks);
// const 
// const ac = 0;
// ac++;
// ac = ac +1;
// console.log(ac)

// Booleans
var a = true;
var b = false;
// console.log(a, b);

// var und = undefined;
var und;
// console.log(und);

var n = null;
// console.log(n);
/*
At a very high level, there are two types of data types in JavaScript
1. Primitive data types: undefined, null, number, string, boolean, symbol
2. Reference data types: Arrays and Objects
*/

var arr = [1, 2, "bablu", 4, 5]
// console.log(arr)

// Operators in JavaScript
// Arithmetic Operators
var a = 100;
var b = 10;
// console.log("The value of a + b is ", a+b);
// console.log("The value of a - b is ", a-b);
// console.log("The value of a * b is ", a*b);
// console.log("The value of a / b is ", a/b);

// Assignment Operators
var c = b;
// c += 2;
// c -= 2; // c = c - 2;
// c *= 2;
// c /= 2;
// console.log(c);

// Comparison Operators
var x = 34;
var y = 56;
// console.log(x == y);
// console.log(x >= y);
// console.log(x <= y);
// console.log(x > y);
// console.log(x < y);

// Logical Operators

// Logical and
// console.log(true && true)
// console.log(true && false)
// console.log(false && true)
// console.log(false && false)

// Logical or
// console.log(true || true)
// console.log(true || false)
// console.log(false || true)
// console.log(false || false)

// Logical not
// console.log(!false);
// console.log(!true);

// Function in JavaScript
function avg(a, b) {
    c = (a + b) / 2;
    return c;
}
// DRY = Do not repeat yourself
c1 = avg(4, 6);
c2 = avg(14, 16);
// console.log(c1, c2);

// Conditionals in JavaScript
/*
var age = 41;
// Single if statement
if(age > 18){
    console.log('You can drink rasna water');
}
// if - else statement
// if(age > 18){
//     console.log('You can drink rasna water');
// }
// else{
//     console.log('You cannot drink rasna water');
// }

age = 25;
// if-else Ladder
if(age > 32){
    console.log("You are not a kid");
}
else if(age >26){
    console.log("Bachhe nahi rahe");
}
else if(age >22){
    console.log("Yes Bachhe nahi rahe");
}
else if(age >18){
    console.log("18 Bachhe nahi rahe");
}
else{
    console.log("Bachhe rahe");
}
console.log("End of ladder");
*/

//Looping
var arr = [1, 2, 3, 4, 5, 6, 7];
// console.log(arr);

// for loop

// for(var i=0;i<arr.length;i++){
//     if(i==2){
//         // break;
//         continue;
//     }
//     console.log(arr[i])
// }

// foreach loop

// arr.forEach(function(element){
//     console.log(element);
// })


// let j = 0;
// while(j<arr.length){
//     console.log(arr[j]);
//     j ++;
// }

// do{
//     console.log(arr[j]);
//     j++;
// } while (j < arr.length);

let myArr = ["Ishika", "Bounty", 29, null, true];
// Array Methods
// console.log(myArr.length);
// myArr.pop();
// myArr.push("harry")
// myArr.shift()
// const newLen = myArr.unshift("Harry")
// console.log(newLen);
// console.log(myArr);

// String Methods in JavaScript
// let myLovelyString = "Ishika is a good girl good ";
// console.log(myLovelyString.length) //27
// console.log(myLovelyString.indexOf("good")) //12
// console.log(myLovelyString.lastIndexOf("good"))  //22
// console.log(myLovelyString.slice(8,21)) // s a good girl
// console.log(myLovelyString.slice(1,4))
// console.log(myLovelyString.slice(-12)) // d girl good
// d = myLovelyString.replace("Ishika", "Smita");
// d = d.replace("good", "bad");
// console.log(d, myLovelyString)


// let text = "a,b,c,d,e,f";
// const myArray = text.split(",");
// console.log(myArray[2])

// let myDate = new Date();
let myDate = new Date("2023-5-18")
// console.log(myDate.getTime());
// console.log(myDate.getFullYear());
// console.log(myDate.getMonth())
// console.log(myDate.getDay());//sunday 1 , monday 2.....
// console.log(myDate.getMinutes());
// console.log(myDate.getHours());
 
// DOM Manipulation
let elem = document.getElementById('click');
// console.log(elem);

let elemClass = document.getElementsByClassName("container")
// console.log(elemClass);
// elemClass[0].style.background = "yellow";
// elemClass[0].classList.add("bg-primary")
// elemClass[0].classList.add("text-success")
// console.log(elem.innerHTML);
// console.log(elem.innerText); 

// console.log(elemClass[0].innerHTML);
// console.log(elemClass[0].innerText); 
tn = document.getElementsByTagName('div')
// console.log(tn)
createdElement = document.createElement('p');
createdElement.innerText = "This is a created paragraph";
tn[0].appendChild(createdElement);
createdElement2 = document.createElement('b');
createdElement2.innerText = "This is a  bold";
tn[0].replaceChild(createdElement2, createdElement);
tn[0].removeChild(createdElement2);// removes an element
 
// Selecting using Query
// sel = document.querySelector('.container')
// console.log(sel)
// sel = document.querySelectorAll('.container')
// console.log(sel)

function clicked(){
    console.log('The button was clicked')
}

// window.onload = function(){
//     console.log('The document was loaded')
// }

// Events in JavaScript

// firstContainer.addEventListener('click', function(){
//     document.querySelectorAll('.container')[1].innerHTML = "<b> We have clicked</b>"
//     console.log("Clicked on Container")
// })

// firstContainer.addEventListener('mouseover', function(){
//     console.log("Mouse on Container")
// })

// firstContainer.addEventListener('mouseout', function(){
//     console.log("Mouse out of Container");
// })

// let prevHTML = document.querySelectorAll('.container')[1].innerHTML;
// firstContainer.addEventListener('mouseup', function(){
//     document.querySelectorAll('.container')[1].innerHTML = prevHTML;
//     console.log("Mouse up when clicked on Container");
// })

// firstContainer.addEventListener('mousedown', function(){
//     document.querySelectorAll('.container')[1].innerHTML = "<b> We have clicked</b>"
//     console.log("Mouse down when clicked on Container");
// })


// Arrow Functions
// function summ(a, b){
//     return a+b;
// }
summ = (a,b)=>{
    return a+b;
}

logKaro = ()=>{
    document.querySelectorAll('.container')[1].innerHTML = "<b> Set interval fired</b>"
    console.log("I am your log")
}

var arr=[
    "abC",
    "BcD",
    "cdE",
    "DeF"
]

function forexample(){
    for (let i = 0; i < arr.length; i++) {
        document.getElementById("loopDemo").innerHTML+="<br>" + arr[i];
      }
      document.getElementById("loopDemo").innerHTML+="<br>============<br>";
}

function whileexample(){
    let i = 0;
    while ( i < arr.length) {
        document.getElementById("loopDemo").innerHTML+="<br>"+arr[i];
        i++;
      }
      document.getElementById("loopDemo").innerHTML+="<br>============<br>";
}

function strMeta(){
    var txt=document.getElementById("strreceieved").value;
    console.log(txt);
    document.getElementById("strmetadata").innerHTML+="<br><b> length : </b>" + txt.length + "<br><b>Words :</b>" + (txt.split(" ").length) + "<br><b>Lines : </b>" + (txt.split("\n").length);
}
// SetTimeout and setinterval

// clr = setTimeout(logKaro, 5000);
// clr = setInterval(logKaro, 2000);
// use clearInterval(clr)/clearTimeout(clr) to cancel setInterval/setTimeout

// JavaScript localStorage
// localStorage.setItem('name', 'harry') 
// localStorage 
// localStorage.getItem('name')
// localStorage.removeItem('name')
// localStorage.clear();



// Json 
// obj = {name: "harry", length: 1, a: {this: 'tha"t'}}
// jso = JSON.stringify(obj);
// console.log(typeof jso)
// console.log(jso)
// parsed = JSON.parse(`{"name":"harry","length":1,"a":{"this":"that"}}`)
// console.log(parsed);

// Template literals - Backticks
// a = 34;
// console.log(`this is my ${a}`)


// validation

// function isPositiveNumber(input) {
//     return Number(input) > 0 && !isNaN(input);
// }

// const userInput = prompt("Enter a positive number:");
// if (isPositiveNumber(userInput)) {
//     console.log("Valid input!");
// } else {
//     console.log("Invalid input. Please enter a positive number.");
// }


// function isValidEmail(email) {
//     const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//     return emailPattern.test(email);
// }

// const userEmail = prompt("Enter your email address:");
// if (isValidEmail(userEmail)) {
//     console.log("Valid email!");
// } else {
//     console.log("Invalid email format. Please enter a valid email address.");
// }

// function isNotEmpty(input) {
//     return input.trim() !== "";
// }

// const userName = prompt("Enter your name:");
// if (isNotEmpty(userName)) {
//     console.log("Valid input!");
// } else {
//     console.log("Name field cannot be empty.");
// }



// Session Cookie localStorage

localStorage.setItem("name" , "Ishika") 
localStorage.setItem("name" , "deven") 
console.log(localStorage.getItem("name"))
localStorage.removeItem("name")

sessionStorage.setItem("name","Ishika")
sessionStorage.setItem("name","deven")
console.log(sessionStorage.getItem("name"))
sessionStorage.removeItem("name")

c


console.log(document.cookie)

