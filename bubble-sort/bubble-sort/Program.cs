using System;

namespace bubble_sort
{
    internal class Program
    {
        private static void Main()
        {
            int[] userChoice = { 6, 5, 1, 10, 15, 4, 3, 20, 21, 22 }; // An array of integers.

            // This is a simple bubble sort for an array of integers.
            for (int i = 0; i < userChoice.Length; i++)
            {
                bool isSorted = true; // Set a boolean value to true on whether or not changes occurred.
                for (int j = i + 1; j < userChoice.Length; j++)
                {
                    if (userChoice[i] > userChoice[j]) // Check each index against one another to see if the next value is greater than the other.
                    {
                        int temp = userChoice[i]; // The temp variable is declared in "loop scope" as this is the only location it is used.
                        userChoice[i] = userChoice[j]; // Swap the contents of the array elements.
                        userChoice[j] = temp;
                        isSorted = false; // If a change was made then set isSorted to false. The array still needs to be checked.
                    }
                }
                if (isSorted) // If no changes occurred then break the loop early. In this example it forces the loop iterations from 55 down to 49. (EXPERT ONLY!)
                    break;
            }

            Console.Write("The sorted values are: ");
            for (int i = 0; i < userChoice.Length; i++)
            {
                Console.Write(userChoice[i] + ((i != userChoice.Length - 1) ? ", " : ".")); // Formatting commas and period only.
            }

            Console.WriteLine(""); // Write a new line.

            Console.WriteLine("Please enter any key to continue...");
            Console.ReadKey(true);
        }
    }
}