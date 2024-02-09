using System;


namespace Inheritance
{
    /// <summary>
    /// Base class (parent class) representing an animal.
    /// </summary>
    #region Parent Class

    // Base class (parent class)
    public class Animal
    {
        // Fields
        public string Name { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Constructor for the Animal class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Method
        public void Eat()
        {
            Console.WriteLine("{0} is eating.",Name);
        }
    }
    #endregion Parent Class

    #region Child Class
    /// <summary>
    /// Derived class (subclass) representing a dog, inheriting from the Animal class.
    /// </summary>
    public class Dog : Animal
    {
        // Additional field specific to Dog
        public string Color { get; set; }

        /// <summary>
        /// Constructor for the Dog class.
        /// </summary>
        /// <param name="name">The name of the dog.</param>
        /// <param name="age">The age of the dog.</param>
        /// <param name="color">The color of the dog.</param>
        public Dog(string name, int age, string color) : base(name, age) // Call the constructor of the base class
        {
            Color = color;
        }

        // Additional method specific to Dog
        public void Bark()
        {
            Console.WriteLine("{0} is barking." , Name);
        }
    }
    #endregion Child Class
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of the base class
            Animal animal = new Animal("cat", 5);
            animal.Eat();

            // Creating an instance of the derived class
            Dog dog = new Dog("Dog", 3, "Orange");
            dog.Eat(); // Inherited method from the base class
            dog.Bark(); // Method specific to Dog class
            Console.ReadLine();
        }
    }
}
