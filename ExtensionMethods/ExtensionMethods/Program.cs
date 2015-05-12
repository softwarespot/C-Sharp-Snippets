using CustomMethod;

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CustomMethod
{
    public static class ExtensionMethods // Create a custom class for extension methods.
    {
        /// <summary>
        /// Checks whether a character is a digit from 0-9
        /// </summary>
        /// <param name="value">A character value</param>
        /// <returns>True or False</returns>
        public static bool IsDigit(this char value)
        {
            return value >= '0' && value <= '9';
        }

        /// <summary>
        /// Checks whether a string is a digits from 0-9
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>True or False</returns>
        public static bool IsDigit(this string value)
        {
            return value.All(@int => @int >= '0' && @int <= '9');
        }

        /// <summary>
        /// Checks whether a double is an even value
        /// </summary>
        /// <param name="value">A double value</param>
        /// <returns>True or False</returns>
        public static bool IsEven(this double value)
        {
            int abs = (int)Math.Abs(Math.Round(value) % 2);
            return abs == 0;
        }

        /// <summary>
        /// Checks whether an integer is an even value
        /// </summary>
        /// <param name="value">An integer value</param>
        /// <returns>True or False</returns>
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Checks whether a character is a hexadecimal value from 0-9 and A-F
        /// </summary>
        /// <param name="value">A character value</param>
        /// <returns>True or False</returns>
        public static bool IsHex(this char value)
        {
            return value >= '0' && value <= '9' ||
                value >= 'A' && value <= 'F' ||
                value >= 'a' && value <= 'f';
        }

        /// <summary>
        /// Checks whether a string is a hexadecimal value from 0-9 and A-F
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>True or False</returns>
        public static bool IsHex(this string value)
        {
            return value.All(s => (s >= '0' && s <= '9') || (s >= 'A' && s <= 'F') || (s >= 'a' && s <= 'f'));
        }

        /// <summary>
        /// Checks if a double is an odd value
        /// </summary>
        /// <param name="value">A double value</param>
        /// <returns>True or False</returns>
        public static bool IsOdd(this double value)
        {
            int abs = (int)Math.Abs(Math.Round(value) % 2);
            return abs != 0;
        }

        /// <summary>
        /// Checks if an integer is an odd value
        /// </summary>
        /// <param name="value">An integer value</param>
        /// <returns>True or False</returns>
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        /// <summary>
        /// Checks whether a string is a palindrome
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>True or False</returns>
        public static bool IsPalindrome(this string value)
        {
            value = Regex.Replace(value, @"\W", "").ToLower(); // Remove all non-word characters and convert to lowercase
            char[] array = value.ToCharArray();
            Array.Reverse(array);
            return new string(array) == value;
        }

        /// <summary>
        /// Checks if a byte value is a prime number
        /// </summary>
        /// <param name="value">A byte value</param>
        /// <returns>True or False</returns>
        public static bool IsPrime(this byte value) // Idea from: http://montreal.pm.org/tech/neil_kandalgaonkar.shtml
        {
            return Regex.IsMatch(new string('1', value), @"^(1?|(11+?)\2+)$", RegexOptions.None);
        }

        /// <summary>
        /// Checks if an integer value is a prime number
        /// </summary>
        /// <param name="value">An integer value</param>
        /// <returns>True or False</returns>
        public static bool IsPrime(this int value) // Idea from: http://montreal.pm.org/tech/neil_kandalgaonkar.shtml
        {
            return Regex.IsMatch(new string('1', value), @"^(1?|(11+?)\2+)$", RegexOptions.None);
        }

        /// <summary>
        /// Checks if a byte value is true when non-zero (Like in most languages)
        /// </summary>
        /// <param name="value">A byte value</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this byte value)
        {
            return value != 0;
        }

        /// <summary>
        /// Checks if a double value is true when non-zero. (Like in most languages)
        /// </summary>
        /// <param name="value">A double value</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this double value)
        {
            int abs = (int)Math.Abs(value);
            return abs < 0 || abs > 0;
        }

        /// <summary>
        /// Checks if an integer value is true when non-zero. (Like in most languages)
        /// </summary>
        /// <param name="value">An integer value</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this int value)
        {
            return value != 0;
        }

        /// <summary>
        /// Checks if a string is true when the value is not empty. (Like in most languages)
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this string value)
        {
            return !String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Repeat a character a certain number of times
        /// </summary>
        /// <param name="value">A character value</param>
        /// <param name="count">Number of times to repeat the character</param>
        /// <returns>Repeated character</returns>
        public static string Repeat(this char value, int count)
        {
            return (count < 0) ? value.ToString() : new string(value, count);
        }

        /// <summary>
        /// Repeat a string a certain number of times
        /// </summary>
        /// <param name="value">A string value</param>
        /// <param name="count">Number of times to repeat the string</param>
        /// <returns>Repeated string</returns>
        public static string Repeat(this string value, int count) // Idea taken from AutoIt _StringRepeat()
        {
            if (count < 0 || value.Length < 1) // Check the string length is greater than 1 and the repeat count is valid. Zero is considered valid
                return value;

            return string.Join(value, new string[count + 1]); // http://rosettacode.org/wiki/Repeat_a_string#C.23
        }

        /// <summary>
        /// Reverse a string
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Reversed string</returns>
        public static string Reverse(this string value)
        {
            char[] array = value.ToCharArray();
            int i = 0, j = array.Length - 1;
            while (i < j) // This version is a slightly optimised version than Array.Reverse()
            {
                char temp = array[i];
                array[i++] = array[j];
                array[j--] = temp;
            }
            return new string(array);

            /*
             * char[] c = s.ToCharArray();
             * Array.Reverse(c);
             * return new string(c);
            */
        }

        /// <summary>
        /// Convert an integer to a hexadecimal representation
        /// </summary>
        /// <param name="value">An integer value</param>
        /// <param name="isLowerCase">Is the representation lowercase (true) or uppercase (false)</param>
        /// <returns>Hexadecimal string</returns>
        public static string ToHexString(this int value, bool isLowerCase = true) // Convert an integer to a hex string representation
        {
            return value.ToString((isLowerCase) ? "x" : "X");
        }

        private static string ToLowerFast(this string value) // (Faster) convert a string to lowercase characters. Access the same way as .ToLower()
        {
            return value.Aggregate(String.Empty, (current, @char) => current + (char)((@char >= 'A' && @char <= 'Z') ? (@char + 32) : @char));
        }

        private static string ToUpperFast(this string value) // (Faster) convert a string to uppercase characters. Access the same way as .ToUpper()
        {
            return value.Aggregate(String.Empty, (current, @char) => current + (char)((@char >= 'a' && @char <= 'z') ? (@char - 32) : @char));
        }
    }
}

namespace Example
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Reversed string: {0}", "reverse".Reverse());

            Console.WriteLine("Repeated string: {0}", "s".Repeat(20));

            int negativeOdd = -99;
            Console.WriteLine("Is Odd: {0}", 100.IsOdd()); // Is the number odd?
            Console.WriteLine("Is Odd: {0}", negativeOdd.IsOdd()); // Is the number odd?
            Console.WriteLine("Is Even: {0}", 99.IsEven()); // Is the number even?

            Console.WriteLine("To Hex string: {0}", 255.ToHexString(false));

            Console.WriteLine("Is char digit: {0}", 'F'.IsDigit());

            Console.WriteLine("Is Hex: {0}", "FF00FF".IsHex());

            string myString = string.Empty;
            Console.WriteLine(myString.IsTrue());

            double myOdd = 2.21;
            Console.WriteLine(myOdd.IsEven());

            Console.WriteLine("A man, a plan, a canal, Panama".IsPalindrome());

            int seven = 7;
            Console.WriteLine(seven.IsPrime());

            Console.Write("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}