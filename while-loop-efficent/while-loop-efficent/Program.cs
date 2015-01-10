using System;

namespace while_loop_efficient
{
    internal class Program
    {
        private static void Main()
        {
            // Print all numbers between 0 and 20.

            // Old way with 3 lines ( minus Console.WriteLine() and brackets ({}). )....
            byte counter = 0; // Create a counter from 0.
            while (counter <= 20) // Check if the counter is less than or equal to 20.
            {
                Console.Write(counter + ((counter != 20) ? "," : ".")); // Formatting commas and period only.
                counter += 1; // Increase the counter by 1.
            }

            Console.WriteLine(); // Empty line.

            // New way with 2 lines ( minus Console.WriteLine() and brackets ({}). )....
            sbyte counter2 = -1; // Create a counter from -1.
            while (++counter2 <= 20) // Increase the counter by 1 and check if the counter is less than or equal to 20.
                Console.Write(counter2 + ((counter2 != 20) ? "," : ".")); // Formatting commas and period only.

            Console.WriteLine(); // Empty line.

            Console.WriteLine("\nBonus Round:"); // Bonus round.

            // Third way with 2 lines ( minus Console.WriteLine() and brackets ({}). )....
            sbyte counter3 = -1; // Create a counter from -1.
            while ((counter3 += 1) <= 20) // Increase the counter by 1 and check if the counter is less than or equal to 20.
                Console.Write(counter3 + ((counter3 != 20) ? "," : ".")); // Formatting commas and period only.

            Console.WriteLine(); // Empty line.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}