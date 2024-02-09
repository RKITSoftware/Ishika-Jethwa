using System;


namespace DateTimeDemo
{
    /// <summary>
    /// This program demonstrates various operations with DateTime in C#.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            #region currentday , addDays
            // Adding days to a date  
            DateTime today = DateTime.Now;
            DateTime addDay = today.AddDays(-20);
            Console.WriteLine(today);
            Console.WriteLine(addDay);
            #endregion currentday , addDays

            #region Format Date , Last Day of Month
            // Formatting using string interpolation
            string formattedDate = $"{today:dd-MM-yy HH:mm:ss}";
            Console.WriteLine("Formatted Date using String Interpolation: " + formattedDate);
            DateTime lastDateOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            Console.WriteLine("Last Date of Current Month: " + lastDateOfMonth.ToString("dd-MM-yy"));
            #endregion Format Date . Last Day of Month

            #region Parsing
            // Parsing  
            string dateString = "Thu Oct 14, 2021";
            DateTime dateTimeparse = DateTime.Parse(dateString);
            Console.WriteLine(dateTimeparse);
            Console.WriteLine(dateTimeparse.GetType());
            #endregion Parsing

            #region DateDifference
            // Date Difference  

            DateTime date2 = new DateTime(2024, 12, 15, 2, 15, 10);
            //2024: Year  
            //12: Month(Dec)
            //15: Day of the month
            //2: Hour(24 - hour format, so 2 represents 2 AM)
            //15: Minute
            //10: Second

            // diff1 gets 386 days, 06 hours, 51 minutes and 18 seconds.
            TimeSpan diff1 = date2.Subtract(today);
            Console.WriteLine(diff1);
            #endregion DateDifference

            #region UniversalTime
            // Universal Time  
            DateTime objDate = new DateTime(2021, 12, 20, 10, 20, 30);
            Console.WriteLine(objDate.ToUniversalTime());
            #endregion UniversalTime
            Console.ReadLine();
        }
    }
}
