namespace DemoDebugging
{
    /// <summary>
    /// Provides mathematical operations such as addition, multiplication, division, and factorial calculation.
    /// </summary>
    public class MathOperations
    {
        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        public int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Multiplies two integers and returns the result.
        /// </summary>
        /// <param name="c">The first integer to multiply.</param>
        /// <param name="a">The second integer to multiply.</param>
        /// <returns>The product of the two integers.</returns>
        public int Multiply(int c, int a)
        {
            return c * a;
        }

        /// <summary>
        /// Divides an integer by another and returns the result.
        /// </summary>
        /// <param name="d">The divisor.</param>
        /// <param name="a">The dividend.</param>
        /// <returns>The result of the division.</returns>
        public int Divide(int d, int a)
        {
            return a / d;
        }

        /// <summary>
        /// Calculates the factorial of an integer and returns the result.
        /// </summary>
        /// <param name="n">The integer for which to calculate the factorial.</param>
        /// <returns>The factorial of the specified integer.</returns>
        public int Factorial(int n)
         {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
