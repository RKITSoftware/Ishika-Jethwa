function oper(){
    
    document.getElementById("opr1").innerHTML += "<h3><ul><li><a href='#' onClick='Arithmetic()'> Arithmetic Operators</a></li>"+
    "<li> <a href='#' onClick='Assignment()'>Assignment Operators</a> </li> "+
    "<li><a href='#' onClick='Comparision()'>Comparison Operators</a> </li>" +
    "<li><a href='#' onClick = 'Strin()'> String Operators</a> </li> "+
    "<li><a href='#' onClick = 'Logic()'> Logical Operators</a></li> "+
    "<li><a href='#' onClick = 'Bitwise()'> Bitwise Operators</a> </li> </ul></h3>"
   
}
function Arithmetic(){
    let x = 50;
    let y = 2;
    let z = x + y;
    document.write(`<h1>addition of ${x} and ${y} = ${z} <br>`);
    document.write(`Subtraction of ${x} and ${y} = ${x-y} <br>`);
    document.write(`Multiplication of ${x} and ${y} = ${x*y} <br>`);
    document.write(`Division of ${x} and ${y} = ${x/y} <br>`);
    document.write(`Reminder of ${x} and ${y} = ${x%y} <br>`);  

}
function Assignment(){
    let x = 50;
    let y = 2;
    
    document.write(`addition of ${x} and ${y} = ${x+=y} <br>`);
    document.write(`Subtraction of ${x} and ${y} = ${x-=y} <br>`);
    document.write(`Multiplication of ${x} and ${y} = ${x*=y} <br>`);
    document.write(`Division of ${x} and ${y} = ${x/=y} <br>`);
    document.write(`Reminder of ${x} and ${y} = ${x%=y} <br>`);  

}
function Comparision(){
    x = 5;
    y = "10"
    document.write("x is == 5 " + (x=="5") )
    document.write("<br> y is === 10 " + (y===10))
    document.write("<br>x is >= 10 " + (x>=10))
    document.write("<br>x is <= 10 " + (x<=10))
    document.write("<br>x is != 10 " + (x!=10))
    document.write("<br>x is !== 10 " + (x!==10))
    document.write("<br>x is > 10 " + (x>10))
    document.write("<br>x is < 10 " + (x>10))
}

function Strin(){
    let text1 = "Hello";
    let text2 = "World!";
    let result = text1 < text2; 
    let text3 = text1 + " " + text2;
    document.write(`Is A less than B?  ${result}`)
    document.write(`<br> ${text3}`)
}
function Logic(){
    let x = 6
    let y = 3
    document.write(`Logical And  ${(x < 10 && y > 1)}  ${(x < 10 && y > 1)} <br>`)
    document.write(`Logical Or  ${(x < 10 || y > 1)}   ${(x < 2 || y > 10)}<br>`)
    document.write(`Logical Not  ${!(x < 10)} ${!(x < 10 && y < 1)}<br>`)
}

function Bitwise(){
    let x = 5
    let y = 1
    document.write(`5 & 1 = ${(5&1)} <br>`)
    document.write(`5 | 1 = ${(5|1)}<br>`)
    document.write(`~5 = ${(~5)}<br>`)

}


// =================Data Types============
function Datatype(){
        // Numbers:
        let length = 16;
        let weight = 7.5;

        document.write("type of length and weight is "+ typeof(length) +" , " + typeof weight )

        // Strings:
        let color = "Yellow";
        let lastName = "Johnson";

        document.write("<br>type of color and lastName is "+ typeof(color) +" , " + typeof lastName )


        // Booleans
        let x = true;
        let y = false;
        document.write("<br>type of x and y is "+ typeof(x) +" , " + typeof y )

        // Object:
        const person = {firstName:"John", lastName:"Doe"};
        document.write("<br>type of person is "+ typeof(person))


        // Array object:
        const cars = ["Saab", "Volvo", "BMW"];
        document.write("<br>type of cars is "+ typeof(cars))


        // Date object:
        const date = new Date("2022-03-25");
        document.write("<br>type of Date "+ typeof(date) )
}

function fun(){
    document.write("<br>Without Arrow function<br>")
    hello = function() {
        return "Hello World!";
      }
    document.write(hello());

    document.write("<br><br><br>With Arrow function<br>")
    hello = () => {
        return "Hello World!";
      }
    document.write(hello());

    document.write("<br><br><br>Arrow Functions Return Value by Default<br>")
    hello = () => "Hello World!";
    document.write(hello());

    document.write("<br><br><br>Arrow Function With Parameters<br>")
    hello = (val) => "Hello " + val;
    document.write(hello("world!"));
}

function even(){
   

    // document.write("onclick  - 	The user clicks an HTML element<br>")
   

    // document.write("onmouseover -	The user moves the mouse over an HTML element")
     firstContainer.addEventListener('mouseover', function(){
        document.querySelectorAll('.container')[6].innerHTML = "<b> mouse over on container</b>"
            console.log("Mouse on Container")
        })
    // document.write("onmouseout - The user moves the mouse away from an HTML element")
     firstContainer.addEventListener('mouseout', function(){
        document.querySelectorAll('.container')[6].innerHTML = "<b> mouse out on container</b>"

            console.log("Mouse out of Container");
        })
    // document.write("mouseup -	The user press the mouse")
     firstContainer.addEventListener('mouseup', function(){
            document.querySelectorAll('.container')[6].innerHTML = "<b> Mouse up when clicked on Container</b>"
            console.log("Mouse up when clicked on Container");
        })
    
      firstContainer.addEventListener('mousedown', function(){
            document.querySelectorAll('.container')[6].innerHTML = "<b> Mouse down when clicked on Container"
            console.log("Mouse down when clicked on Container");
        })

      firstContainer.addEventListener('keyup', (event) => {
          var name = event.key;
          var code = event.code;
          // Alert the key name and key code on keydown
          alert(`Key pressed ${name} \r\n Key code value: ${code}`);
        }, false);

}
window.addEventListener("load", (event) => {
    alert("Window loading....")
  });

// ===================string method=============

function strMethod(){
    let str1 = "Hello Good Morning , Ishika is Good girl ...";
    let length = str1.length;
    console.log("length is "+length)

    let str = str1.startsWith("Hello")
    console.log(str)
    let str22 = str1.includes("good")
    console.log(str22)

    let str2 = str1.slice(6, 13);
    console.log("sliceing (6,13) " +str2)
    let str3 = str1.slice(-13);
    console.log("sliceing (-13) " +str3)
    let str4 = str1.slice(-13,-6);
    console.log("sliceing (-13,-6) " +str4)

    // dont support negative index  
    let str5 = str1.substring(7, -6); //Hello G
    console.log("substring (7,-6)"+str5)
    let str6 = str1.substr(7, 6);
    console.log("substr (7,6)"+str6)

    let str7 = str1.substr(-4);
    console.log("substr (-4)"+str7)

    let str8 = str1.replace("Ishika", "Jeeny");
    console.log(str8)

    str9 = str1.replaceAll("Good","bad");
    console.log(str9)

    let str10 = str1.toUpperCase();
    console.log(str10)

    let str11 = str1.toLowerCase();
    console.log(str11)

    let text = "also honest!! , beautiful"
    let text3 = str1.concat(" ", text);
    console.log(text3)

    let text1 = "     Hello World!     ";
    let text2 = text1.trim();
    console.log(text2)


    let text4 = text1.trimStart();
    console.log(text4)

    let text5 = text1.trimEnd();
    console.log(text5)

    let x = "5";
    let padded = x.padStart(4,"0");
    console.log(padded)

    let padded1 = x.padStart(4,"x");
    console.log(padded1)

    let txt = "HELLO WORLD";
    let char = txt.charAt(0);
    console.log(char)

    let txt1 = text.split(",")   
    console.log(txt1) // Split on commas
    // text.split(" ")    // Split on spaces
    // text.split("|")    // Split on pipe
}

function arrMethod(){
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

        const numbers = [1, 2, 3, 4, 5];
        const squaredNumbers = numbers.map(num => num * num);
        console.log(squaredNumbers)
        // squaredNumbers will be [1, 4, 9, 16, 25]

        
        const evenNumbers = numbers.filter(num => num % 2 === 0);
        console.log(evenNumbers)
        // evenNumbers will be [2, 4]

       
        const sum = numbers.reduce((accumulator, currentValue) => accumulator + currentValue, 0);
        console.log(sum)
        // sum will be 15



}

function dateMethod(){
        const d = new Date("October 13, 2014 11:13:00");
        console.log("Date is : " +d)

        // JavaScript counts months from 0 to 11.
        // Specifying a month higher than 11, will not result in an error but add the overflow to the next year:

        const d1 = new Date(2018, 15, 24, 10, 33, 30, 0);
        console.log(d1)

        // One and two digit years will be interpreted as 19xx:

        const d2 = new Date(99, 11, 24); // Fri Dec 24 1999 00:00:00 GMT+0530 (India Standard Time)
        console.log(d2)


        // getFullYear()	    Get year as a four digit number (yyyy)
        // getMonth()	        Get month as a number (0-11)
        // getDate()	        Get day as a number (1-31)
        // getDay()	            Get weekday as a number (0-6)
        // getHours()	        Get hour (0-23)
        // getMinutes()	        Get minute (0-59)
        // getSeconds()	        Get second (0-59)
        // getMilliseconds()	Get millisecond (0-999)
        // getTime()	        Get time (milliseconds since January 1, 1970)
        // format
        const d3 = new Date();
        console.log(d3)
        console.log(d3.getFullYear());
        console.log(d3.getMonth())
        console.log(d3.getDate())
        console.log(d3.getDay())
        console.log(d3.getHours())
        console.log(d3.getMinutes())
        console.log(d3.getSeconds())
        console.log(d3.getMilliseconds())
        console.log(d3.getTime())



        // setDate()	        Set the day as a number (1-31)
        // setFullYear()	    Set the year (optionally month and day)
        // setHours()	        Set the hour (0-23)
        // setMilliseconds()	Set the milliseconds (0-999)
        // setMinutes()	        Set the minutes (0-59)
        // setMonth()	        Set the month (0-11)
        // setSeconds()	        Set the seconds (0-59)
        // setTime()	        Set the time (milliseconds since January 1, 1970)


        const d4 = new Date();
        d4.setFullYear(2020)
        console.log(d4)
        d4.setMonth(11)
        console.log(d4)
        d4.setDate(15)
        console.log(d4)
        d4.setHours(6)
        console.log(d4)
        d4.setMinutes(15)
        console.log(d4)
        d4.setSeconds(45)
        console.log(d4)

       

}


function mathMethod(){


    document.write("8^2 = "+ Math.pow(8, 2));
    document.write("<br>sqrt of 64 = "+Math.sqrt(64))
    document.write("<br>absolute value = "+Math.abs(-4.7))
    document.write("<br>Minimum value of (0, 150, 30, 20, -8, -200) is : "+ Math.min(0, 150, 30, 20, -8, -200))
    document.write("<br>Maximum value of (0, 150, 30, 20, -8, -200) is : "+ Math.max(0, 150, 30, 20, -8, -200))

    // Math.random() returns a random number between 0 and 1:
    document.write("<br>Random no. is : "+ Math.random())
    // Returns a random integer from 0 to 10:
    document.write("<br> Random integer from 0 to 10 : "+Math.floor(Math.random() * 11));

    // Math.E        // returns Euler's number
    // Math.PI       // returns PI
    // Math.SQRT2    // returns the square root of 2
    // Math.SQRT1_2  // returns the square root of 1/2
    // Math.LN2      // returns the natural logarithm of 2
    // Math.LN10     // returns the natural logarithm of 10
    // Math.LOG2E    // returns base 2 logarithm of E
    // Math.LOG10E   // returns base 10 logarithm of E

    // Math.round(x)	Returns x rounded to its nearest integer
    // Math.ceil(x)	Returns x rounded up to its nearest integer
    // Math.floor(x)	Returns x rounded down to its nearest integer
    // Math.trunc(x)	Returns the integer part of x (new in ES6)


}

var arr=[
    "abC",
    "BcD",
    "cdE",
    "DeF"
]
function forexample(){
    document.getElementById("loopDemo").innerHTML+="<br>======For Loop ======<br>";
    for (let i = 0; i < arr.length; i++) {
        document.getElementById("loopDemo").innerHTML+="<br>" + arr[i];
      }
     
}

function whileexample(){
    let i = 0;
    document.getElementById("loopDemo").innerHTML +="<br>======While loop======<br>";
    while ( i < arr.length) {
        document.getElementById("loopDemo").innerHTML+="<br>"+arr[i];
        i++;
      }
      
}

function dowhileexample(){
    let i = 0;
    document.getElementById("loopDemo").innerHTML+="<br>======Do While loop======<br>";
    do{
        document.getElementById("loopDemo").innerHTML+="<br>"+arr[i];
        i++;
      }while ( i < arr.length)
     
}

function condition(){
    const time = new Date().getHours();
    let greeting;
    if (time < 10) {
        greeting = "Good morning";
      } else if (time < 20) {
        greeting = "Good day";
      } else {
        greeting = "Good evening";
      }
    document.write(greeting)

    switch (new Date().getDay()) {
        case 0:
          day = "Sunday";
          break;
        case 1:
          day = "Monday";
          break;
        case 2:
           day = "Tuesday";
          break;
        case 3:
          day = "Wednesday";
          break;
        case 4:
          day = "Thursday";
          break;
        case 5:
          day = "Friday";
          break;
        case 6:
          day = "Saturday";
      
      }
      document.write("<br>" +day)
}

function regexp(){
    // i	Perform case-insensitive matching	
    // g	Perform a global match (find all matches rather than stopping after the first match)	
    // m	Perform multiline matching

    // [abc]	Find any of the characters between the brackets	
    // [0-9]	Find any of the digits between the brackets	
    // (x|y)	Find any of the alternatives separated with |

    // \d	Find a digit	
    // \s	Find a whitespace character	
    // \b	Find a match at the beginning of a word like this: \bWORD, or at the end of a word like this: WORD\b	
    // \uxxxx	Find the Unicode character specified by the hexadecimal number xxxx

    // n+	Matches any string that contains at least one n
    // n*	Matches any string that contains zero or more occurrences of n
    // n?	Matches any string that contains zero or one occurrences of n
    text =" Replace 'Microsoft' with 'W3Schools' in the paragraph below:"
    text2 = text.replace(/microsoft/i, "W3Schools");
    console.log(text2)
}
function scope(){
    //   JavaScript has 3 types of scope:

    //      Block scope
    //      Function scope
    //      Global scope

    // {
    //   let x = 2;
    // }
    // x can NOT be used here

    // {
    //   var x = 2;
    // }
    // x CAN be used here

    // code here can NOT use carName

    // function myFunction() {
    //    let carName = "Volvo";
    // // code here CAN use carName
    //   }

    // code here can NOT use carName

    // let carName = "Volvo";
    // code here can use carName

    // function myFunction() {
    // code here can also use carName
    // }

    //If you assign a value to a variable that has not been declared, it will automatically become a GLOBAL variable.

}


    // In an object method, this refers to the object.
    // Alone, this refers to the global object.
    // In a function, this refers to the global object.
    // In a function, in strict mode, this is undefined.
    // In an event, this refers to the element that received the event.
    // Methods like call(), apply(), and bind() can refer this to any object.

    const person = {
      firstName: "Ishika",
      lastName : "Jethwa",
      id       : 5566,
      fullName : function() {
        return this.firstName + " " + this.lastName;
      }
    };
    console.log("Fullname = " + person.fullName())

    // call()
    const person1 = {
      fullName: function() {
        return this.firstName + " " + this.lastName;
      }
    }
    
    const person2 = {
      firstName:"Deven",
      lastName: "Jethwa",
    }
    
    // Return "John Doe":
    console.log(person1.fullName.call(person2));

function storage(){
  // Session localStorage

    localStorage.setItem("name" , "Ishika") 
    localStorage.setItem("name" , "deven") 
    console.log(localStorage.getItem("name"))
    // localStorage.removeItem("name")

    sessionStorage.setItem("name","Ishika")
    sessionStorage.setItem("name","deven")
    console.log(sessionStorage.getItem("name"))
    // sessionStorage.removeItem("name")

  console.log(localStorage)
  console.log(sessionStorage)
    


}
// Cookie
document.cookie = "name =ishika; expires= " + new Date("2025-1-18") 
document.cookie = "lname =deven; expires= " + new Date("2025-1-18") 
document.cookie = "lsname =decven"


logKaro = ()=>{
    document.querySelectorAll('.Demo2')[0].innerHTML = "<b> Set interval fired</b>"
    console.log("I am your log")
  }

// SetTimeout and setinterval

clr = setTimeout(logKaro, 5000); //5 second pachhi logkaro function ne call karse 1 time
clr = setInterval(logKaro, 2000); // every 2 second a logkaro function call thase
// use clearInterval(clr)/clearTimeout(clr) to cancel setInterval/setTimeout  


function myDisplayer(something) {
  document.getElementById("callback").innerHTML += something;
}

function myCalculator(num1, num2, myCallback) {
  let sum = num1 + num2;
  myCallback(sum);
}

myCalculator(5, 5, myDisplayer);

function myblur(){
  let x = document.getElementById("fname");
  x.value = x.value.toUpperCase();
}

var buttonElement = document.getElementById('myButton');
buttonElement.addEventListener('click', function handleClick() {
  console.log('External Button Clicked!');
});

