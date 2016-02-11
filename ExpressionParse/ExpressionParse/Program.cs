#region

using System;
using System.Text.RegularExpressions;

#endregion

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
            } while (userExpression != null && !Regex.IsMatch(userExpression, @"^\d+\s*[+\-*\/]\s*\d+\s*=?\s*$"));
            // Match <NUM><SYMBOL><NUM><EQUALS>(Optional).

            if (userExpression != null)
            {
                foreach (char value in userExpression)
                // A foreach() is a safe option when you don't need to write back to the original string.
                {
                    if (value >= '0' && value <= '9') // Check if the char value is between 0 or 9.
                    {
                        Console.WriteLine("{0} = an integer", value);
                    }
                    else
                        switch (value)
                        {
                            case '=':
                                {
                                    Console.WriteLine("{0} = the equals (=) symbol", value);
                                    break;
                                }
                            case '+':
                                {
                                    Console.WriteLine("{0} = the addition (+) symbol", value);
                                    break;
                                }
                            case '-':
                                {
                                    Console.WriteLine("{0} = the subtraction (-) symbol", value);
                                    break;
                                }
                            case '*':
                                {
                                    Console.WriteLine("{0} = the multiplication (*) symbol", value);
                                    break;
                                }
                            case '/':
                                {
                                    Console.WriteLine("{0} = the division (/) symbol", value);
                                    break;
                                }
                            case '^':
                                {
                                    Console.WriteLine("{0} = the power of (^) symbol", value);
                                    break;
                                }
                        }
                }
            }

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}
