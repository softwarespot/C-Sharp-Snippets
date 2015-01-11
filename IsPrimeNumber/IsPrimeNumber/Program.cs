#region Required project assemblies

using System;

#endregion

namespace IsPrimeNumber
{
    internal class Program
    {
        private static bool IsPrimeNumber(int number, out int divisibleBy)
        {
            divisibleBy = -1; // Set the out parameter as -1, for those numbers which are prime values.
            if (number <= 1)
            {
                return false; // Return false if the value is less than or equal to one.
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    divisibleBy = i; // Set the out param as the divisible by value.
                    return false;
                }
            }
            return true; // This means it's a prime number.
        }

        private static void Main()
        {
            int userChoice;
            do
            {
                Console.Write("Please enter an integer number to see if it's a prime number: ");
                int.TryParse(Console.ReadLine(), out userChoice);
                Console.WriteLine(); // New line.
            } while (userChoice <= 0);

            int numberDivisible;
            if (IsPrimeNumber(userChoice, out numberDivisible))
            {
                Console.WriteLine("Your number is a prime value.");
            }
            else
            {
                if (numberDivisible == -1)
                {
                    Console.WriteLine("Your number is NOT regarded as a prime value.");
                }
                else
                {
                    Console.WriteLine("Your number is NOT a prime value as it's divisible by {0}.", numberDivisible);
                }
            }
            Console.WriteLine(); // New line.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}