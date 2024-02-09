using System;


namespace Interface
{
    /// <summary>
    /// Interface representing addition operation.
    /// </summary>
    interface IAdd
    {
        int Add(int a, int b);
    }
    /// <summary>
    /// Interface representing subtraction operation.
    /// </summary>
    interface ISub
    {
        int Sub(int a, int b);
    }
    /// <summary>
    /// Interface representing multiplication operation.
    /// </summary>
    interface IMul
    {
        int Mul(int a, int b);
    }
    /// <summary>
    /// Interface representing division operation.
    /// </summary>
    interface IDiv
    {
        int Div(int a, int b);
    }
    #region class calculation

    /// <summary>
    /// Class implementing all four interfaces (IAdd, ISub, IMul, IDiv) for basic arithmetic operations.
    /// </summary>
    class Calculation : IAdd , ISub ,IMul , IDiv
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public int Mul(int a, int b)
        {
            return a * b;
        }
        public int Div(int a, int b)
        {
            return a / b;
        }
    }
    #endregion class calculation
    class Program
    {
        static void Main(string[] args)
        {
            //object of calculation class 
            Calculation c = new Calculation();

            //calling and accessing calculation's member
            Console.WriteLine("Multiple Interfaces : ");
            Console.WriteLine("Addition: " + c.Add(8, 2));
            Console.WriteLine("Substraction: " + c.Sub(20, 10));
            Console.WriteLine("Multiplication :" + c.Mul(5, 2));
            Console.WriteLine("Division: " + c.Div(20, 10));

            Console.ReadLine();
        }
    }
}
