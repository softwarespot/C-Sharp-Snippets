using System;

namespace pre_increment_and_post_increment
{
    internal class Program
    {
        public static void Main()
        {
            int value = 0;
            value++; // Increase by 1.
            Console.WriteLine("1. " + value); // (value = 1)
            Console.WriteLine("2. " + ++value); // Increase by 1 and then return the value. (value = 2)
            Console.WriteLine("3. " + value++); // Return the value and then increase by 1. (value = 2)
            Console.WriteLine("3. " + ++value); // Increase by 1 and then return the value. (value = 4)
            Console.WriteLine("4. " + value); // (value = 4)

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}