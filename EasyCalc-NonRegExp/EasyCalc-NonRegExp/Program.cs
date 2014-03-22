using System;

namespace EasyCalc_NonRegExp
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
         * Note: I only did this as a "proof of concept" to show that it could easily be done without
         * using regular expressions. The final version I submitted consisted of 2 lines only and was
         * labelled EasyCalc-RegExp.
         */

        public static void Main()
        {
            while (true)
            {
                Console.Write("=========================================\n|\t\t\t\t\t|\n|\tEasyCalc\t\t\t|\n|\t\t\t\t\t|\n|\tAuthor: SoftwareSpot (C) 2014\t|\n|\tBuild: 0.0.0.1\t\t\t|\n|\t\t\t\t\t|\n=========================================\nPlease enter an expression to evaluate e.g. 1+2= or 10*20 (the equals sign is optional).\n");

                string number1 = null, number2 = null, symbol = null, userChoice = Console.ReadLine(); // Set to null to check later on that numbers were appended to the variables.
                foreach (char value in userChoice)
                {
                    if (value >= '0' && value <= '9' || value == '.')
                    {
                        if (symbol != null) // If the symbol was found then update the second value.
                            number2 += value;
                        else
                            number1 += value;
                    }
                    symbol = ((value == '+' || value == '-' || value == '*' || value == '/') && symbol == null) ? value.ToString() : symbol; // Check if the char value is a valid symbol.
                }

                if (number1 != null && number1 != "." && number2 != null && number2 != "." && symbol != null) // If all variables didn't equal the initial null value or a single dot, then a valid expression was entered.
                {
                    double? num1 = double.Parse(number1), num2 = double.Parse(number2), sum = (symbol == "+") ? num1 + num2 : (symbol == "-") ? num1 - num2 : (symbol == "*") ? num1 * num2 : (symbol == "/") ? num1 / num2 : null;
                    Console.WriteLine("The sum of {0} is {1}\n", userChoice.TrimEnd('=').Replace(" ", string.Empty), sum);
                }
            }
        }
    }
}