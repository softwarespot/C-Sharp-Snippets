using System;

namespace bubble_sort
{
    internal class BubbleSort
    {
        public static void Quick(int[] array)
        {
            // This is a simple bubble sort for an array of integers.
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int nextElement = j + 1;
                    if (array[j] > array[nextElement]) // Check each index against one another to see if the next value is greater than the other.
                    {
                        int temp = array[j]; // The temp variable is declared in "loop scope" as this is the only location it is used.
                        array[j] = array[nextElement]; // Swap the contents of the array elements.
                        array[nextElement] = temp;
                    }
                }
            }
        }

        public static void Standard(int[] array)
        {
            // This is a simple bubble sort for an array of integers.
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int nextElement = j + 1;
                    if (array[j] > array[nextElement]) // Check each index against one another to see if the next value is greater than the other.
                    {
                        int temp = array[j]; // The temp variable is declared in "loop scope" as this is the only location it is used.
                        array[j] = array[nextElement]; // Swap the contents of the array elements.
                        array[nextElement] = temp;
                    }
                }
            }
        }
    }

    internal class Program
    {
        private static void CreateArray(int[] array)
        {
            Random random = new Random(Environment.TickCount);
            for (int i = 0, lastElement = array.Length - 1; i <= lastElement; i++)
            {
                array[i] = random.Next(1, 1000);
            }
        }

        private static void Main()
        {
            int[] a1 = new int[5], a2 = new int[a1.Length]; // An array of integers.
            CreateArray(a1); // Create random numbers in the integer array.
            Array.Copy(a1, a2, a2.Length); // Copy the first array.

            PrintArray(a1); // Print the unsorted values.
            BubbleSort.Standard(a1); // Sort the array using the standard bubble sort.
            PrintArray(a1); // Print the sorted values.

            Console.WriteLine(); // Empty line.

            PrintArray(a2); // Print the unsorted values.
            BubbleSort.Quick(a2); // Sort the array using the quick bubble sort.
            PrintArray(a2); // Print the sorted values.

            Console.WriteLine(); // Empty line.
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
        private static void PrintArray(int[] array)
        {
            Console.Write("The values are: ");
            int lastElement = array.Length - 1;
            for (int i = 0; i <= lastElement; i++)
            {
                Console.Write(array[i] + ((i != lastElement) ? ", " : ".")); // Formatting commas and period only.
            }
            Console.WriteLine(); // Empty line.
        }
    }
}