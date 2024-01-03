using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    #region Abstract Class
    // Abstract class definition
    public abstract class Shape
    {
        // Abstract method declaration
        public abstract void Draw(); //can not be private


        public void DisplayArea()
        {
            Console.WriteLine("This method is from the abstract class.");
        }
    }

    //class that inherits from the abstract class
    public class Circle : Shape
    {
        // Implementation of the abstract method
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }

    }
    #endregion Abstract Class

    #region Partial Class
    // Partial class definition
    public partial class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // Another part of the partial class
    public partial class Employee
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Employee:{0} {1}", FirstName, LastName);
        }
    }
    #endregion Partial Class

    #region Sealed Class
    // Sealed class definition
    public sealed class FinalClass
    {
        public void DisplayMessage()
        {
            Console.WriteLine("This is a sealed class.");
        }
    }
    #endregion Sealed Class

    #region Static Class
    // Static class definition
    public static class MathOperations
    {
        //static  method
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    #endregion Static Class
    class Program
    {

        static void Main()
        {
            // Using the abstract class
            Circle myCircle = new Circle();
            myCircle.Draw();
            myCircle.DisplayArea();


            // Using the partial class
            Employee objEmployee = new Employee();
            objEmployee.FirstName = "John";
            objEmployee.LastName = "Doe";
            objEmployee.DisplayInfo();

            // Using the sealed class
            FinalClass finalInstance = new FinalClass();
            finalInstance.DisplayMessage();

            // Using the static class
            int resultAdd = MathOperations.Add(5, 3);
            int resultSubtract = MathOperations.Subtract(10, 7);

            Console.WriteLine("Addition Result: {0}", resultAdd);
            Console.WriteLine("Subtraction Result: {0}", resultSubtract);
            Console.ReadLine();
        }

    }


}
