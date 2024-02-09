
using System;


namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            Datatypes datatype = new Datatypes();
            datatype.DisplayMessage();

            // Expression expression = new Expression();
            // expression.display();

            // Statement statement = new Statement();
            //statement.Display();
            Array array = new Array();
            array.Display();

            Methods method = new Methods();
            method.Display();

            Console.WriteLine("Hello, World!");
            Console.ReadLine();
          
        }
    }
}
