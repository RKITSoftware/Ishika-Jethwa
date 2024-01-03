using System;

namespace HelloWorld
{
    /// <summary>
    /// 
    /// </summary>
    class Datatypes
    {
        public void DisplayMessage()
        {
            Console.WriteLine("Datatypes conversion:");
            int myInt = 7;
            double myDouble = myInt; // Implicit casting: int to double
            Console.WriteLine("Value of myInt = " + myInt);
            Console.WriteLine("Value of myDouble = " + myDouble);

            double doublea = 9.78;
            int inta = (int)doublea; // Explicit casting manually: double to int
            Console.WriteLine("value of variable myDouble = " + doublea);
            Console.WriteLine("value of variable myInt coverted manually = " + inta);
            Console.WriteLine("value of variable myInt coverted using method = " + Convert.ToString(inta)); // Explicitcasting using method: int to string

            Console.WriteLine(" ");
        }
    }
}
