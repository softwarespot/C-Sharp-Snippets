#region Required project assemblies

using System;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace EasyCalc_RegExp
{
    internal class Program
    {
        /* The following example was created as part of a competition in March 2014 to see
         * which one of us could create a simple expression calculator with the least amount
         * of lines (of code). The stipulation was that if a line ended with a semi-colon then it
         * constituted as a new line as well as Console.WriteLine()s being exempt from the line count,
         * if they had no relevance and were only informing the user. The expression that had to parse
         * correctly was value [+-/*] value = (with the equals symbol being optional.) The values had to
         * whole integers though you could parse decimal values if you so wished.
         *
         * I won with just 2 lines!
         */

        public static void Main()
        {
            while (true)
            {
                Console.Write(
                    "=========================================\n|\t\t\t\t\t|\n|\tEasyCalc\t\t\t|\n|\t\t\t\t\t|\n|\tAuthor: SoftwareSpot (C) 2014\t|\n|\tBuild: 0.0.0.1\t\t\t|\n|\t\t\t\t\t|\n=========================================\nPlease enter an expression to evaluate e.g. 1+2= or 10*20 (the equals sign is optional).\n");

                string userChoice = Console.ReadLine();
                // Nested ternary statements. It's difficult to read, but this is how the application only spans 2 lines.
                Console.WriteLine(userChoice != null && Regex.IsMatch(userChoice, @"^\d+(?:\.\d+)?\s*[+\-*\/]\s*\d+(?:\.\d+)?\s*=?$") ? "The sum of " + userChoice.TrimEnd('=').Replace(" ", String.Empty) + " is " + ((Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*([+\-*\/])\s*\d+(?:\.\d+)?\s*=?$", @"$1") == "+") ? (double.Parse(Regex.Replace(userChoice, @"^(\d+(?:\.\d+)?)\s*[+\-*\/]\s*\d+(?:\.\d+)?\s*=?$", @"$1")) + double.Parse(Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*[+\-*\/]\s*(\d+(?:\.\d+)?)\s*=?$", @"$1"))).ToString(CultureInfo.InvariantCulture) : (Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*([+\-*\/])\s*\d+(?:\.\d+)?\s*=?$", @"$1") == "-") ? (double.Parse(Regex.Replace(userChoice, @"^(\d+(?:\.\d+)?)\s*[+\-*\/]\s*\d+(?:\.\d+)?\s*=?$", @"$1")) - double.Parse(Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*[+\-*\/]\s*(\d+(?:\.\d+)?)\s*=?$", @"$1"))).ToString(CultureInfo.InvariantCulture) : (Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*([+\-*\/])\s*\d+(?:\.\d+)?\s*=?$", @"$1") == "*") ? (double.Parse(Regex.Replace(userChoice, @"^(\d+(?:\.\d+)?)\s*[+\-*\/]\s*\d+(?:\.\d+)?\s*=?$", @"$1")) * double.Parse(Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*[+\-*\/]\s*(\d+(?:\.\d+)?)\s*=?$", @"$1"))).ToString(CultureInfo.InvariantCulture) : (Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*([+\-*\/])\s*\d+(?:\.\d+)?\s*=?$", @"$1") == "/") ? (double.Parse(Regex.Replace(userChoice, @"^(\d+(?:\.\d+)?)\s*[+\-*\/]\s*\d+(?:\.\d+)?\s*=?$", @"$1")) / double.Parse(Regex.Replace(userChoice, @"^\d+(?:\.\d+)?\s*[+\-*\/]\s*(\d+(?:\.\d+)?)\s*=?$", @"$1"))).ToString(CultureInfo.InvariantCulture) : "A serious error occurred parsing your expression.") : "A serious error occurred parsing your expression.");
            }
        }
    }
}