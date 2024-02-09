using System;


namespace StringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Demonstrates copying a string using the Copy method.
            /// </summary>
            #region string copy
            // using the Copy method
            // to copy the value of str1
            // into str2
            string str1 = "Hello";
            string str2 = string.Copy(str1);
            Console.WriteLine(str2);
            #endregion string copy

            /// <summary>
            /// Demonstrates using the Equals method to check if two strings are equal.
            /// </summary>
            #region string Equals
            // Equals(string) method return false because the given strings are not equal
            string strEqual1 = "Hello";
            string strEqual2 = "World";
            Console.WriteLine(strEqual1.Equals(strEqual2));
            #endregion string Equals

            /// <summary>
            /// Demonstrates using the IndexOf method to find the first occurrence index of a specified character in a string.
            /// </summary>
            #region string IndexOf
            //IndexOf() will return first occurrence index of specified character
            //if character not found in given string then return -1
            string a = "Hello";
            int b = a.IndexOf('l');
            int c = a.IndexOf('I');
            Console.WriteLine("Index of l  is : {0}" , b );
            Console.WriteLine("Index of I is : {0}", c);
            #endregion string IndexOf

            /// <summary>
            /// Demonstrates using the Replace method to replace a specified substring in a string.
            /// </summary>
            #region string replace
            //Replace method wiil replace given substring to specified string
            string firstString = "Hello";
            string secondString = firstString.Replace("o", "World");
            Console.WriteLine("Origional string is : " + firstString);
            Console.WriteLine("Replaced string is : " + secondString);
            #endregion string replace

            /// <summary>
            /// Demonstrates using the Trim method to remove extra white spaces from a string.
            /// </summary>
            #region string Trim
            //Trim will remove all the extra white space from string
            string stringTrim = "Hello world  ";
            string trimstr = stringTrim.Trim();
            Console.WriteLine("Trimed string is: " + trimstr);
            #endregion string Trim

            /// <summary>
            /// Demonstrates using the Contains method to check if a substring is present in a string.
            /// </summary>
            #region string contains
            //contains return true if a particular substring is present inside a given string
            string strcontain1 = "Ishika Jethwa";
            string strcontain2 = "Jethwa";
            Console.WriteLine(strcontain1.Contains(strcontain2));
            #endregion string contains

            /// <summary>
            /// Demonstrates converting a string to uppercase and lowercase.
            /// </summary>
            #region string UpperCase, LowerCase
            string strName = "I Love RKIT";
            //ToUpper() converts the string in uppercase.
            Console.WriteLine("Uppercase : " + strName.ToUpper());

            //ToLower() converts the string in uppercase.
            Console.WriteLine("Lowercase : " + strName.ToLower());
            #endregion string UpperCase, LowerCase

            Console.ReadLine();
        }
    }
}
