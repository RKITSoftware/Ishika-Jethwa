using System;


namespace MultipleInheritance
{
    /// <summary>
    /// Interface representing the eating behavior of an animal.
    /// </summary>
    interface IFirstBase
    {
        void Eat();
    }

    /// <summary>
    /// Class implementing the eating behavior from the IFirstBase interface.
    /// </summary>
    class FirstBase : IFirstBase
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }
    /// <summary>
    /// Interface representing the sleeping behavior of an animal.
    /// </summary>
    public interface ISecondBase
    {
        void Sleep();
    }

    // second Base class implementing
    //class SecondBase : ISecondBase
    //{
    //    public void Sleep()
    //    {
    //        Console.WriteLine("Animal is sleeping.");s
    //    }
    //}

    /// <summary>
    /// Class inheriting from FirstBase class and implementing the sleeping behavior from ISecondBase interface.
    /// </summary>
    class ChildClass : IFirstBase, ISecondBase
    {
        public void Eat()
        {
            Console.WriteLine("ChildClass is eating.");
        }

        public void Sleep()
        {
            Console.WriteLine("ChildClass is sleeping.");
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            ChildClass child = new ChildClass();
            child.Eat();
            child.Sleep();

            Console.ReadLine();
        }
    }
}
