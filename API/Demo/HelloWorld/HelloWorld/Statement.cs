using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Statement
    {
        public void Display()
        {
            Console.WriteLine(" ");

            #region If Else Statement
                Console.WriteLine("if else statements: ");
                Console.WriteLine("Enter the student's exam marks: ");

                // Get user input for exam marks
                int examMarks;
                examMarks = Convert.ToInt32(Console.ReadLine());
                if (examMarks >= 0 && examMarks <= 100)
                {
                    if (examMarks >= 90)
                    {
                        Console.WriteLine("Grade: A");
                    }
                    else if (examMarks >= 80)
                    {
                        Console.WriteLine("Grade: B");
                    }
                    else if (examMarks >= 70)
                    {
                        Console.WriteLine("Grade: C");
                    }
                    else if (examMarks >= 60)
                    {
                        Console.WriteLine("Grade: D");
                    }
                    else
                    {
                        Console.WriteLine("Grade: F");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid  exam marks.");
                }
                Console.WriteLine(" ");
            #endregion end If Else Statement

            #region SwitchCase
                Console.WriteLine("switch case statements: ");
                Console.WriteLine("Enter a day number:");
                int day = Convert.ToInt32(Console.ReadLine());
                switch (day)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Friday");
                        break;
                    case 6:
                        Console.WriteLine("Saturday");
                        break;
                    case 7:
                        Console.WriteLine("Sunday");
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            #endregion SwitchCase
        }
    }
}
