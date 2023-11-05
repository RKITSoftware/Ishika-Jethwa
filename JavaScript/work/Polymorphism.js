// --------------overloading---------------

function exampleFunction() {
    if (arguments.length === 1 && typeof arguments[0] === 'number') {
    
      console.log('One number:', arguments[0]);
    } else if (arguments.length === 2 && typeof arguments[0] === 'string' && typeof arguments[1] === 'boolean') {
    
      console.log('String:', arguments[0]);
      console.log('Boolean:', arguments[1]);
    } else {
      // Handle other cases or throw an error
      console.log('Invalid arguments');
    }
  }
  
  exampleFunction(42);                    // One number: 42
  exampleFunction('Hello', true);          // String: Hello, Boolean: true
  exampleFunction('Hello', 42);            // Invalid arguments


//   -----------overriding------------

// Parent class
class Animal {
    constructor(name) {
      this.name = name;
    }
  
    sayHello() {
      console.log(`Hello, I am ${this.name}`);
    }
  }
  
  // Child class
  class Dog extends Animal {
    constructor(name, breed) {
      super(name); // Call the parent class constructor
      this.breed = breed;
    }
  
    // Override the parent class method
    sayHello() {
      console.log(`Woof! I am ${this.name} the ${this.breed}`);
    }
  }
  
  // Create instances of the parent and child classes
  const genericAnimal = new Animal("Generic Animal");
  const dog = new Dog("Buddy", "Golden Retriever");
  
  genericAnimal.sayHello(); // Outputs: Hello, I am Generic Animal
  dog.sayHello();            // Outputs: Woof! I am Buddy the Golden Retriever
  