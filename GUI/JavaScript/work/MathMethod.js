
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