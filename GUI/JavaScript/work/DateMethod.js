// import { format } from 'date-fns';

// const formattedDate = format(specificDate, 'MMMM dd, yyyy');
// console.log(formattedDate)
// Output: August 23, 2023

    
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

const d3 = new Date();
console.log(d3.getFullYear());
console.log(d3.getMonth())
console.log(d3.getDate())
console.log(d3.getDay())
console.log(d3.getHours())
console.log(d3.getMinutes())
console.log(d3.getSeconds())
console.log(d3.getMilliseconds())
console.log(d3.getTime())


function formatDate(d){
    var date = d.getDate();
    var month = d.getMonth();
    month++;
    var year = d.getFullYear();
    return date +"-"+month+"-"+year;
}

console.log(formatDate(d3));


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
