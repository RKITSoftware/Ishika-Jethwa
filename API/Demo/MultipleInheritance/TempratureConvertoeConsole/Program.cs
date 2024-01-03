using System;
using TemperatureConverterLibrary;

namespace TempratureConvertoeConsole
{
    /// <summary>
    /// Represents a console application for converting temperatures using the TemperatureConverter library.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConverter calc = new TemperatureConverter();
            Console.WriteLine("Welcome to the Temperature Converter App!");
            Console.WriteLine("---------------------------------------");

            // Input temperature in Celsius from the user
            Console.Write("Enter temperature in Celsius: ");
            Double celsius = Convert.ToDouble(Console.ReadLine());
          
                // Using the TemperatureConverter library
                double fahrenheit = calc.CelsiusToFahrenheit(celsius);
                double kelvin = calc.CelsiusToKelvin(celsius);

                // Display the converted temperatures
                Console.WriteLine($"{celsius} Celsius is equal to:");
                Console.WriteLine($"{fahrenheit} Fahrenheit");
                Console.WriteLine($"{kelvin} Kelvin");


            Console.ReadLine();
        }
    }
}
