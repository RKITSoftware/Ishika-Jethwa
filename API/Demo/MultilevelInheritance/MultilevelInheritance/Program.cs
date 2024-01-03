using System;


namespace MultilevelInheritance
{
    /// <summary>
    /// Base class representing an animal.
    /// </summary>
    #region Base Class
    // Base class (parent class)
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }
    #endregion Base Class

    /// <summary>
    /// Intermediate class (derived from Animal) representing a mammal.
    /// </summary>
    #region Intermediate Class

    // Intermediate class (derived from Animal)
    public class Mammal : Animal
    {
        public void GiveBirth()
        {
            Console.WriteLine("Mammal is giving birth.");
        }
    }
    #endregion Intermediate Class

    /// <summary>
    /// Derived class (derived from Mammal) representing a dog.
    /// </summary>
    #region Derived Class
    // Derived class (derived from Mammal)
    public class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Dog is barking.");
        }
    }
    #endregion Derive Class

    class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();

            
            myDog.Eat();       // Inherited from Animal
            myDog.GiveBirth(); // Inherited from Mammal
            myDog.Bark();      // Dog Method

            Console.ReadLine();
        }
    }
}
