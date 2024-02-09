using System;


namespace ExceptionHandling
{
    /// <summary>
    /// This program demonstrates exception handling in C#.
    /// It includes  a method (Divide) that throws exceptions.
    /// The Main method catches specific exceptions (DivideByZeroException) and a general Exception, displaying error messages.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int result = Divide(10, 0); // call method  Divide
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }

            Console.ReadLine();
        }
        /// <summary>
        /// Divides two integers, throwing a DivideByZeroException if the divisor is zero.
        /// </summary>
        /// <param name="a">The numerator.</param>
        /// <param name="b">The denominator.</param>
        /// <returns>The result of the division.</returns>
        static int Divide(int a, int b)
        {
            if (b == 0)
            {
                // Using throw to explicitly throw a DivideByZeroException
                throw new DivideByZeroException("Cannot divide by zero.");

            }

            return a / b;
        }
    }
}
