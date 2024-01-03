using System;


namespace CustomeException
{
    /// <summary>
    /// This program demonstrates the creation and usage of a custom exception class, AmountIsZeroException,
    /// and its handling in a Bank class that checks for a zero balance.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Custom exception class for AmountIsZeroException.
        /// </summary>
        public class AmountIsZeroException : Exception

        {
            /// <summary>
            /// Constructor for the custom exception class.
            /// </summary>
            public AmountIsZeroException() : base("Zero amount.")
            {
            }
        }
        /// <summary>
        /// Bank class that checks for a zero balance and throws the custom exception.
        /// </summary>
        public class Bank
        {
            int amount = 0;

            /// <summary>
            /// Method to check the balance and throw the custom exception if the amount is zero.
            /// </summary>
            public void balance()
            {

                if (amount == 0)
                {
                    throw (new AmountIsZeroException());//throw custom exception
                }
                else
                {
                    Console.WriteLine("Amount: {0}", amount);
                }
            }

            static void Main(string[] args)
            {
                Bank account = new Bank();
                try
                {
                    account.balance();
                }
                catch (AmountIsZeroException e)
                {
                    Console.WriteLine("AmountIsZeroException: {0}", e.Message);
                }
                finally
                {
                    Console.WriteLine("Always executed");
                }
                Console.ReadLine();
            }
        }
    }
}