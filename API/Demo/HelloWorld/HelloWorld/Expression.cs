using System;


namespace HelloWorld
{
    class Expression
    {
        public void display()
        {
            /* sum = a + b + c; This is called expression
             where sum, a, b, c all are called operands 
             and +, = are called operators
            */
            #region LocalVariables
            int a;
            int b;
            bool isOdd;
            #endregion LocalVariables

            #region Take_Inputs
            Console.Write("Enter 1st value  = ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter 2nd value  = ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" ");
            #endregion Take_Inputs

            #region Arithmetic Operators
            Console.WriteLine("Arithmetic Operators");

            //Arithmetic Add
            Console.WriteLine("Addition : {0} + {1} = {2}", a, b, (a + b));

            //Arithmetic Subtract
            Console.WriteLine("Subtraction : {0} - {1} = {2}", a, b, (a - b));

            //Arithmetic Increment operator
            Console.WriteLine("Increment : {0} is {1}", a, (++a));

            //Arithmetic Decrement operator
            Console.WriteLine("Decrement : {0} is {1}", b, (--b));

            Console.WriteLine(" ");
            #endregion Arithmetic Operators

            #region Relational Operators
            Console.WriteLine("Relational Operators");

            //Relational double Equals, less than and greater than 
            if (a == b)
            {
                Console.WriteLine("{0} and {1} are not equal", a, b);
            }
            else if (a < b)
            {
                Console.WriteLine("{0} is less than {1}", a, b);
            }
            else
            {
                Console.WriteLine("{0} is greater than {1}", a, b);
            }

            Console.WriteLine(" ");
            #endregion Relational Operators

            #region Logical Operators
            Console.WriteLine("Logical Operators");

            //Logical AND
            if ((a != b) && (a > b))
            {
                Console.WriteLine("{0} is greater than {1}", a, b);
            }

            Console.WriteLine(" ");
            #endregion Logical Operators

            #region Bitwise Operators
            Console.WriteLine("Bitwise Operators");
            Console.WriteLine("ANDing of {0} & {1} is {2}", a, b, (a & b));
            Console.WriteLine(" ");
            #endregion Bitwise Operators

            #region Assignment Operators
            Console.WriteLine("Assignment Operators:");
            int x = 10; // Assigning the value 10 to the variable x
            Console.WriteLine("x : {0}", x);

            #endregion Assignment Operators
            //  Nullable<int> i = null;
            // int? i = null;

            #region Miscellaneous Operators
            Console.WriteLine("Miscellaneous Operators:");

            // ternary (? :) Operator
            isOdd = (a % 2 != 0) ? true : false;

            if (isOdd)
            {
                Console.WriteLine("{0} is Odd", a);
            }
            else
            {
                Console.WriteLine("{0} is Even", a);
            }
            //Null Coalescing Operator:
            string name = null;
            string result = name ?? "Default Name";
            Console.WriteLine(result);
            // Typeof Operator
            Type typeOfInt = typeof(int);
            Console.WriteLine("type of int : {0}", typeOfInt); // Output: System.Int32
                                                               //sizeof operator
            int sizeOfInt = sizeof(int);
            Console.WriteLine("size of int :{0}", sizeOfInt);
            #endregion Miscellaneous Operators
        }

    }
}
