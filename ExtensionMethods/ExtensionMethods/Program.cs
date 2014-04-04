using CustomMethod;

using System;
using System.Text.RegularExpressions;

namespace CustomMethod
{
    public static class Extensions // Create a custom class for extension methods.
    {
        /// <summary>
        /// Checks whether a character is a digit from 0-9.
        /// </summary>
        /// <param name="c">A character value.</param>
        /// <returns>True or False</returns>
        public static bool IsDigit(this char c)
        {
            return (c >= '0' && c <= '9');
        }

        /// <summary>
        /// Checks whether a string is a digits from 0-9.
        /// </summary>
        /// <param name="i">A string value.</param>
        /// <returns>True or False</returns>
        public static bool IsDigit(this string i)
        {
            foreach (char value in i)
            {
                if (value < '0' || value > '9')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether a double is an even value.
        /// </summary>
        /// <param name="d">A double value.</param>
        /// <returns>True or False</returns>
        public static bool IsEven(this double d)
        {
            return Math.Round(d) % 2 == 0;
        }

        /// <summary>
        /// Checks whether an integer is an even value.
        /// </summary>
        /// <param name="i">An integer value.</param>
        /// <returns>True or False</returns>
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        /// <summary>
        /// Checks whether a character is a hexadecimal value from 0-9 and A-F.
        /// </summary>
        /// <param name="c">A character value.</param>
        /// <returns>True or False</returns>
        public static bool IsHex(this char c)
        {
            return (c >= '0' && c <= '9' ||
                c >= 'A' && c <= 'F' ||
                c >= 'a' && c <= 'f');
        }

        /// <summary>
        /// Checks whether a string is a hexadecimal value from 0-9 and A-F.
        /// </summary>
        /// <param name="s">A string value.</param>
        /// <returns>True or False</returns>
        public static bool IsHex(this string s)
        {
            foreach (char value in s)
            {
                if (value < '0' || value > '9' &&
                    value < 'A' || value > 'F' &&
                    value < 'a' || value > 'f')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if a double is an odd value.
        /// </summary>
        /// <param name="d">A double value.</param>
        /// <returns>True or False</returns>
        public static bool IsOdd(this double d)
        {
            return Math.Round(d) % 2 == 1;
        }

        /// <summary>
        /// Checks if an integer is an odd value.
        /// </summary>
        /// <param name="i">An integer value.</param>
        /// <returns>True or False</returns>
        public static bool IsOdd(this int i)
        {
            return i % 2 == 1;
        }

        /// <summary>
        /// Checks whether a string is a palindrome.
        /// </summary>
        /// <param name="s">A string value.</param>
        /// <returns>True or False</returns>
        public static bool IsPalindrome(this string s)
        {
            s = Regex.Replace(s, @"\W", "").ToLower(); // Remove all non-word characters and convert to lowercase.
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c) == s;
        }

        /// <summary>
        /// Checks if a byte value is true when non-zero. (Like in most languages.)
        /// </summary>
        /// <param name="b">A byte value.</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this byte b)
        {
            return b != 0;
        }

        /// <summary>
        /// Checks if a double value is true when non-zero. (Like in most languages.)
        /// </summary>
        /// <param name="d">A double value.</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this double d)
        {
            return d != 0;
        }

        /// <summary>
        /// Checks if an integer value is true when non-zero. (Like in most languages.)
        /// </summary>
        /// <param name="i">An integer value.</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this int i)
        {
            return i != 0;
        }

        /// <summary>
        /// Checks if a string is true when the value is not empty. (Like in most languages.)
        /// </summary>
        /// <param name="s">A string value.</param>
        /// <returns>True or False</returns>
        public static bool IsTrue(this string s)
        {
            return s.Length != 0;
        }

        /// <summary>
        /// Repeat a character a certain number of times.
        /// </summary>
        /// <param name="c">A character value.</param>
        /// <param name="count">Number of times to repeat the character.</param>
        /// <returns>Repeated character.</returns>
        public static string Repeat(this char c, int count)
        {
            return (count < 0) ? c.ToString() : new string(c, count);
        }

        /// <summary>
        /// Repeat a string a certain number of times.
        /// </summary>
        /// <param name="s">A string value.</param>
        /// <param name="count">Number of times to repeat the string.</param>
        /// <returns>Repeated string.</returns>
        public static string Repeat(this string s, int count) // Idea taken from AutoIt _StringRepeat()
        {
            if (count < 0 || s.Length < 1) // Check the string length is greater than 1 and the repeat count is valid. Zero is considered valid.
                return s;

            return string.Join(s, new string[count + 1]); // http://rosettacode.org/wiki/Repeat_a_string#C.23
        }

        /// <summary>
        /// Reverse a string.
        /// </summary>
        /// <param name="s">A string value.</param>
        /// <returns>Reversed string.</returns>
        public static string Reverse(this string s)
        {
            char[] c = s.ToCharArray();
            int i = 0, j = c.Length - 1;
            while (i < j) // This version is a slightly optimised version than Array.Reverse().
            {
                char temp = c[i];
                c[i++] = c[j];
                c[j--] = temp;
            }
            return new string(c);

            /*
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
            */
        }

        /// <summary>
        /// Convert an integer to a hexadecimal representation.
        /// </summary>
        /// <param name="i">An integer value.</param>
        /// <param name="isLowerCase">Is the representation lowercase (true) or uppercase (false).</param>
        /// <returns>Hexadecimal string.</returns>
        public static string ToHexString(this int i, bool isLowerCase = true) // Convert an integer to a hex string representation.
        {
            return i.ToString((isLowerCase) ? "x" : "X");
        }

        private static string ToLowerFast(this string s) // (Faster) convert a string to lowercase characters. Access the same way as .ToLower().
        {
            string lowerString = string.Empty;
            foreach (char value in s)
            {
                lowerString += (char)((value >= 'A' && value <= 'Z') ? (value + 32) : value); // Cast as a char.
            }
            return lowerString;
        }

        private static string ToUpperFast(this string s) // (Faster) convert a string to uppercase characters. Access the same way as .ToUpper().
        {
            string upperString = string.Empty;
            foreach (char value in s)
            {
                upperString += (char)((value >= 'a' && value <= 'z') ? (value - 32) : value); // Cast as a char.
            }
            return upperString;
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

            Console.WriteLine("Is Odd: {0}", 100.IsOdd()); // Is the number odd?
            Console.WriteLine("Is Odd: {0}", 99.IsOdd()); // Is the number odd?
            Console.WriteLine("Is Even: {0}", 99.IsEven()); // Is the number even?

            Console.WriteLine("To Hex string: {0}", 255.ToHexString(false));

            Console.WriteLine("Is char digit: {0}", 'F'.IsDigit());

            Console.WriteLine("Is Hex: {0}", "FF00FF".IsHex());

            string myString = string.Empty;
            Console.WriteLine(myString.IsTrue());

            double myOdd = 2.21;
            Console.WriteLine(myOdd.IsEven());

            Console.WriteLine("A man, a plan, a canal, Panama".IsPalindrome());

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}