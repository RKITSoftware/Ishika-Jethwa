let str1 = "Hello Good Morning , Ishika is Good girl ...";
let length = str1.length;
console.log("length is "+length)

let str2 = str1.slice(6, 13);
console.log("sliceing (7,13) " +str2)
let str3 = str1.slice(-13);
console.log("sliceing (-13) " +str3)
let str4 = str1.slice(-13, -6);
console.log("sliceing (-13,-6) " +str4)


let str5 = str1.substring(7, 13);
console.log("substring (7,13)"+str5)
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