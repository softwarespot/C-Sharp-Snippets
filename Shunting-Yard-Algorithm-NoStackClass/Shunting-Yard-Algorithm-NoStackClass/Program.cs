using System;

namespace Shunting_Yard_Algorithm_NoStackClass
{
    // Ideas provided by: https://en.wikipedia.org/wiki/Shunting_yard_algorithm, https://en.wikipedia.org/wiki/Reverse_Polish_notation and http://www.slideshare.net/grahamwell/shunting-yard
    internal static class ShuntingYard
    {
        /// <summary>
        /// Calculate the value of a postfix notation (RPN) expression.
        /// </summary>
        /// <param name="expression">The postfix string expression.</param>
        /// <returns>The value.</returns>
        public static double Calculate(string expression)
        {
            int buffer = expression.Length; // Create a buffer for the stack so that it can hold all symbol characters.
            double[] stack = new double[buffer];  // Create a stack to push/pop to.
            int index = 0; // index item of the stack.
            char token = new char(); // Token.
            string digits = string.Empty; // Hold string digits e.g. in case there are numbers greater than 1 digit long.
            double number1, number2;

            for (int i = 0; i < buffer; i++)
            {
                token = expression[i];

                if (char.IsDigit(token))
                {
                    digits += token;
                }
                else if (IsOperator(token))
                {
                    number2 = stack[index--]; // Pop stack.
                    number1 = stack[index--]; // Pop stack.
                    stack[++index] = Eval(number1, number2, token); // Push token to stack.
                }
                else if (char.IsWhiteSpace(token) && digits != string.Empty)
                {
                    if (double.TryParse(digits, out number1))
                        stack[++index] = number1; // Push token to stack.
                    digits = string.Empty;
                    number1 = 0;
                }
            }
            return stack[index--]; // Pop stack.
        }

        /// <summary>
        /// Parses an expression from infix notation to postfix notation (RPN).
        /// </summary>
        /// <param name="expression">The infix string expression.</param>
        /// <returns>Postfix notation.</returns>
        public static string Parse(string expression)
        {
            string output = string.Empty; // Output string.

            int buffer = expression.Length; // Create stack that can hold all characters.
            char[] stack = new char[buffer]; // Create a stack to push/pop to.
            int index = 0; // index item of the stack.
            bool isBracket = false; // Is parenthesis.
            char token = new char(); // Token.

            for (int i = 0; i < buffer; i++)
            {
                token = expression[i];

                if (char.IsDigit(token)) // If a digit add to the output string.
                {
                    output += token;
                }
                else if (IsOperator(token)) // Check if a valid token.
                {
                    if (IsBracket(token))
                    {
                        isBracket = token == '('; // True if open bracket else False if closing.
                        if (isBracket) // Open bracket.
                        {
                            stack[++index] = token; // Push token to stack.
                        }
                        else // Closing bracket.
                        {
                            output += " "; // Workaround for spacing and certain expressions.
                            do // Repeat until '(' is found.
                            {
                                output += stack[index--]; // Pop stack.
                            }
                            while (stack[index] != '(');
                            stack[index--] = new char(); // Pop stack and disregard match '('.
                        }
                    }
                    else
                    {
                        output += " "; // Workaround for spacing and certain expressions.
                        if (HasHigherPrecedence(token, stack[index]))
                        {
                            output += stack[index]; // Pop stack.
                            stack[index] = token; // Push token to stack.
                            output += " "; // Workaround for spacing and certain expressions.
                        }
                        else
                        {
                            stack[++index] = token; // Push token to stack.
                        }
                    }
                }
            }

            if (index >= 0) // Append what is left on the stack in reverse order.
            {
                output += " ";
                while (index >= 0)
                {
                    output += stack[index--] + " "; // Pop stack.
                }
            }
            return output;
        }

        // Private wrapper functions.
        /// <summary>
        /// Evaluate a simple expression using standard mathematical operators.
        /// </summary>
        /// <param name="i1">The first value.</param>
        /// <param name="i2">The second value.</param>
        /// <param name="c">Symbol representing the operation e.g. + is addition.</param>
        /// <returns>The sum of both values.</returns>
        private static double Eval(double i1, double i2, char c)
        {
            switch (c)
            {
                case '+':
                    return i1 + i2;

                case '-':
                case (char)8722: // Char 8722 is - but the unicode char code.
                    return i1 - i2;

                case '*':
                    return i1 * i2;

                case '/':
                    return i1 / i2;

                case '^':
                    return Math.Pow(i1, i2);

                default:
                    return i1;
            }
        }

        /// <summary>
        /// Checks whether the first symbol has higher precedence over the second symbol.
        /// </summary>
        /// <param name="c1">The first symbol.</param>
        /// <param name="c2">The second symbol.</param>
        /// <returns>True or False of whether the first symbol has higher precedence.</returns>
        private static bool HasHigherPrecedence(char c1, char c2)
        {
            int i1 = PrecedenceValue(c1);
            int i2 = PrecedenceValue(c2);
            if (i1 == 0 && i2 == 0)
                return false;
            return i1 <= i2 && c1 != '^';
        }

        /// <summary>
        /// Checks if a character is a round bracket.
        /// </summary>
        /// <param name="c">The char value.</param>
        /// <returns>True or False.</returns>
        private static bool IsBracket(char c)
        {
            return c == '(' || c == ')';
        }

        /// <summary>
        /// Checks if a character is a valid operator symbol.
        /// </summary>
        /// <param name="c">The char value.</param>
        /// <returns>True or False.</returns>
        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == 8722 || c == '*' || c == '/' || c == '^' || c == '(' || c == ')'; // Char 8722 is - but the unicode char code.
        }

        /// <summary>
        /// The precedence value of a symbol.
        /// </summary>
        /// <param name="c">The char value.</param>
        /// <returns>The precedence value.</returns>
        private static int PrecedenceValue(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 2;

                case '*':
                case '/':
                    return 3;

                case '^':
                    return 4;

                default:
                    return 0;
            }
        }
    }

    internal class Program
    {
        public static void Main()
        {
            // Create postfix notation (RPN) from infix notation.
            Console.WriteLine("{0} == {1}", "3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3", ShuntingYard.Parse("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3"));
            Console.WriteLine("Reference: 3 4 2 * 1 5 − 2 3 ^ ^ / +");

            Console.WriteLine(""); // A new line.

            Console.WriteLine("{0} == {1}", "3 + 4", ShuntingYard.Parse("3 + 4"));
            Console.WriteLine("Reference: 3 4 +");

            Console.WriteLine(""); // A new line.

            // Expression from: http://www.slideshare.net/grahamwell/shunting-yard.

            Console.WriteLine("{0}: == {1}", "2 + (3 * (8 - 4))", ShuntingYard.Parse("2 + (3 * (8 - 4))"));
            Console.WriteLine("Reference: 2 3 8 4 - * +");

            Console.WriteLine(""); // A new line.

            // Calculate postfix notation (RPN) examples.
            Console.WriteLine("3 4 + == " + ShuntingYard.Calculate("3 4 +"));
            Console.WriteLine("3 4 2 * 1 5 - 2 3 ^ ^ / + == " + ShuntingYard.Calculate("3 4 2 * 1 5 − 2 3 ^ ^ / +"));
            Console.WriteLine("2 3 8 4 - * + == " + ShuntingYard.Calculate("2 3 8 4 - * +"));

            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}