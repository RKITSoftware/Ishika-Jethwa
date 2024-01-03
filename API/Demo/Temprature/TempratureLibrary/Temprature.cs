using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempratureLibrary
{
    public class TempratureClass
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        // Convert Fahrenheit to Celsius
        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        // Convert Celsius to Kelvin
        public double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        // Convert Kelvin to Celsius
        public double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        // Convert Fahrenheit to Kelvin
        public double FahrenheitToKelvin(double fahrenheit)
        {
            return CelsiusToKelvin(FahrenheitToCelsius(fahrenheit));
        }

        // Convert Kelvin to Fahrenheit
        public double KelvinToFahrenheit(double kelvin)
        {
            return CelsiusToFahrenheit(KelvinToCelsius(kelvin));
        }
    }
}
