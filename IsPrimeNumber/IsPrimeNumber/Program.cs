using System;

namespace IsPrimeNumber
{
    internal class Program
    {
        private static void Main()
        {
            int userChoice;
            do
            {
                Console.Write("Please enter an integer number to see if it's a prime number: ");
                int.TryParse(Console.ReadLine(), out userChoice);
                Console.WriteLine(""); // New line.
            }
            while (userChoice <= 0);

            int? numberDivisible;
            if (IsPrimeNumber(userChoice, out numberDivisible))
            {
                Console.WriteLine("Your number is a prime value.");
            }
            else
            {
                Console.WriteLine("Your number is NOT a prime value as it's divisible by {0}.", numberDivisible);
            }
            Console.WriteLine(""); // New line.

            Console.WriteLine("Please enter any key . . .");
            Console.ReadKey();
        }

        private static bool IsPrimeNumber(int number, out int? divisibleBy) // divisibleBy is a nullable datatype.
        {
            divisibleBy = null; // Set the out parameter as null, for those numbers which are prime values.
            if (number <= 1)
            {
                divisibleBy = 1;
                return false; // Return false if the value is less than or equal to one.
            }

            for (int i = 2; i <= number / 2; i++) // Divide the number by 2 as it's the highest value that will "go in to" the number e.g. if the value was 20 then 11 or above doesn't fit into 20.
            {
                if (number % i == 0) // If there was no remainder means it's not a prime number.
                {
                    divisibleBy = i; // Set the out param as the divisible by value.
                    return false;
                }
            }
            return true; // This means it's a prime number.
        }
    }
}