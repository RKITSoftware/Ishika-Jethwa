using System;


namespace HelloWorld
{
    class Methods
    {
        #region methods
        static void ModifyValue(int x)
        {
            x = x * 2; // Modify the parameter inside the method
            Console.WriteLine("Inside the method: x = {0} ", x);
        }
        static void ModifyValue(ref int x)
        {
            x = x * 2; // Modify the parameter inside the method
            Console.WriteLine("Inside the method: x = {0}", x);
        }

        static void DisplayMessage(string message = "Default Message")
        {
            Console.WriteLine(message);
        }
        #endregion methods
        public void Display()
        {
            #region Call by Value
            int number = 10;

            Console.WriteLine("number : {0}", number);

            // Call the method with a value type parameter
            ModifyValue(number);

            Console.WriteLine("Square : {0}", number);
            #endregion Call by Value

            #region Call by Reference

            Console.WriteLine("number: {0}", number);

            // Call the method with a reference type parameter
            ModifyValue(ref number);

            Console.WriteLine("Square: {0}", number);
            #endregion Call by Reference

            #region Call by Default Parameter
            // Calling the method without providing the parameter
            DisplayMessage(); // Uses the default value

            // Calling the method with a specific parameter
            DisplayMessage("Hello, World!");
            #endregion Call by Default Parameter

        }
    }
}
