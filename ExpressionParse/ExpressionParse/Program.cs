using System;
using System.Text.RegularExpressions;

namespace ExpressionParse
{
    internal class Program
    {
        public static void Main()
        {
            string userExpression; // Variable to hold the user's expression.
            do
            {
                Console.WriteLine("Enter a simple valid expression e.g. 10+10 or 100*7=: ");
                userExpression = Console.ReadLine();
            }
            while (!Regex.IsMatch(userExpression, @"^\d+\s*[+\-*\/]\s*\d+\s*=?\s*$")); // Match <NUM><SYMBOL><NUM><EQUALS>(Optional).

            foreach (char value in userExpression) // A foreach() is a safe option when you don't need to write back to the orignal string.
            {
                if (value >= '0' && value <= '9') // Check if the char value is between 0 or 9.
                {
                    Console.WriteLine("{0} = an integer", value);
                }
                else if (value == '=') // The following belows checks if the char value is a valid symbol.
                {
                    Console.WriteLine("{0} = the equals (=) symbol", value);
                }
                else if (value == '+')
                {
                    Console.WriteLine("{0} = the addition (+) symbol", value);
                }
                else if (value == '-')
                {
                    Console.WriteLine("{0} = the subtraction (-) symbol", value);
                }
                else if (value == '*')
                {
                    Console.WriteLine("{0} = the multiplication (*) symbol", value);
                }
                else if (value == '/')
                {
                    Console.WriteLine("{0} = the division (/) symbol", value);
                }
            }

            Console.WriteLine("Please enter any key to continue...");
            Console.ReadKey(true);
        }
    }
}