// function Vehicle()  
// {  
//     this.vehicleName= vehicleName;  
//     // throw new Error("You cannot create an instance of Abstract class");  
  
// }  
// Vehicle.prototype.display=function()  
// {  
//     return this.vehicleName;  
// }  
// var vehicle=new Vehicle();  

// // ******************************
// function Vehicle()  
// {  
//     this.vehicleName=vehicleName;  
//     throw new Error("You cannot create an instance of Abstract class");  
// }  
// //Creating a constructor function  
// function Bike(vehicleName)  
// {  
//     this.vehicleName=vehicleName;  
// }  
// Bike.prototype=Object.create(Vehicle.prototype);  
// var bike=new Bike("Honda");  
// document.write(bike instanceof Vehicle);  
// document.write(bike instanceof Bike); 
// // *********************************

// function Shape() {
//     if (this.constructor === Shape) {
//         // console.log("cannot instantiate abstract class shape")
//         throw new Error("Cannot instantiate abstract class Shape");
//     }
//     this.draw = function() {
//         // console.log("cannot call abstract method")
//         throw new Error("Cannot call abstract method draw from Shape");
//     }
// }

// function Circle() {
//     Shape.call(this);
//     this.draw = function() {
//         console.log("Drawing a Circle");
//     }
// }
// Circle.prototype = Object.create(Shape.prototype);
// Circle.prototype.constructor = Circle;

// let circle = new Circle();
// circle.draw(); // "Drawing a Circle"
// let shape = new Shape(); // Error: Cannot instantiate abstract class Shape
// shape.draw()

// const abc = 12
// abc = 15
// console.log(abc)

{
    var a = 15;

    a  = 20
}
// let a =10;
console.log(a)

