using ExtensionMethod.Models;

namespace ExtensionMethod
{
    public static class BLHelper
    {
        /// <summary>
        /// Changes the case of the first letter in a string.
        /// </summary>
        /// <param name="inputstring">The input string.</param>
        /// <returns>A string with the case of the first letter changed.</returns>
        public static string ChangeFirstLetterCase(this string inputstring)
        {
            if (inputstring.Length > 0)
            {
                char[] charArray = inputstring.ToCharArray();
                charArray[0] = char.IsUpper(charArray[0]) ? char.ToLower(charArray[0]) : char.ToUpper(charArray[0]);
                return new string(charArray);
            }
            return inputstring;
        }

        /// <summary>
        /// Checks if an integer value is greater than 1000.
        /// </summary>
        /// <param name="value">The input integer value.</param>
        /// <returns>True if the value is greater than 1000; otherwise, false.</returns>
        public static bool IsGreaterThan(this int value)
        {
            return value > 1000;
        }

        /// <summary>
        /// Formats a Person object as a string.
        /// </summary>
        /// <param name="person">The Person object to format.</param>
        /// <returns>A formatted string representation of the Person object.</returns>
        public static string FormatAsString(this Per01 person)
        {
            // Format the Person object as a string
            return $"{person.r01f01} , Age: {person.r01f02}";
        }
    }
}
