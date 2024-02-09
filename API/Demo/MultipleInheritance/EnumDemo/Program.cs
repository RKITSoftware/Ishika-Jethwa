using System;

namespace EnumDemo
{
    /// <summary>
    ///  This program demonstrates the use of an enumeration 'enmDaysType' representing days of the week.
    /// It prints the integer values associated with each day of the week.
    /// </summary>
    class Program
    {
        // making an enumerator 'Days'
        public enum enmDaysType
        {
            // following are the data members
            sunday = 1,
            monday = 2,
            tuesday = 3,
            wednesday = 4,
            thursday = 5,
            friday = 6,
            saturday = 7
        }
        static void Main(string[] args)
        {
            // getting the integer values of data members..
            Console.WriteLine("The value of sunday in days enum is " + (int)enmDaysType.sunday);
            Console.WriteLine("The value of monday  in days enum is " + (int)enmDaysType.monday);
            Console.WriteLine("The value of tuesday in days enum is " + (int)enmDaysType.tuesday);
            Console.WriteLine("The value of wednesday in days enum is " + (int)enmDaysType.wednesday);
            Console.WriteLine("The value of thursday in days enum is " + (int)enmDaysType.thursday);
            Console.WriteLine("The value of friday in days enum is " + (int)enmDaysType.friday);
            Console.WriteLine("The value of saturday in days enum is " + (int)enmDaysType.saturday);
            Console.ReadLine();

        }
    }
}
