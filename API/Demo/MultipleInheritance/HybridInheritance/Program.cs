using System;


namespace HierarchicalInheritance
{
    ///<summary>
    /// Base class representing an animal.
    ///</summary>
    #region Base Class
    // Base class implementing
    public class Animal 
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }
    #endregion Base Class

    ///<summary>
    /// Intermediate class representing a pet animal, inheriting from Animal.
    ///</summary>
    #region Child Class
    // Intermediate class
    public class PetAnimal : Animal
    {
        public void Display()
        {
            Console.WriteLine("That is pet animal");
        }
    }
    #endregion Child Class

    ///<summary>
    /// Child class representing a wild animal, also inheriting from Animal.
    ///</summary>
    #region Another Child Class
    // Child class
    public class WildAnimal : Animal
    {
        public void  Display()
        {
            Console.WriteLine("wild animal");
        }
    }
    #endregion Another Child Class

    class Program
    {
        static void Main(string[] args)
        {
            PetAnimal dog = new PetAnimal();
            dog.Eat();      //inherite from animal class
            dog.Display();  //call method from derived class or Petanimal class

            WildAnimal lion = new WildAnimal();
            lion.Eat();     //inherite from animal class
            lion.Display(); //call method from derived class or wildanimal class

            Console.ReadLine();
        }
    }
}
