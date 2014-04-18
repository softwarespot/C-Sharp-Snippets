using System;
using System.Linq;

namespace arrays_are_equal
{
    internal class Program
    {
        public static void Main()
        {
            int[] arrayOne = { 0, 1, 2, 3, 4 }, arrayTwo = { 0, 1, 2, 3, 4 }; // Create two arrays with the exact same content.
            Console.WriteLine("Example 1: result = {0}", arrayOne == arrayTwo); // Q: So this should return True?
            // A: It doesn't because we are comparing object references and not the contents of the arrays.

            int[] arrayThree = { 1, 0, 3, 4, 2 }; // Create a third array with exactly the same values but in a different order.
            Console.WriteLine("Example 2: result = {0}", arrayOne.SequenceEqual(arrayThree)); //Q: So this should return True?
            // A: It doesn't because the sequence or order of numbers isn't the same e.g. 0, 1, 2, 3...

            Array.Sort(arrayThree); // Sort the third array into 0, 1, 2...
            Console.WriteLine("Example 3: result = {0}", arrayOne.SequenceEqual(arrayThree)); // Q: So this should return True?
            // A: Yes, because the sequence is exactly the same.

            int[] arrayFour = new int[10]; // Create a new 10 element array and add the values 0, 1, 2, 3, 4.
            arrayFour[0] = 0;
            arrayFour[1] = 1;
            arrayFour[2] = 2;
            arrayFour[3] = 3;
            arrayFour[4] = 4;
            // Hint: The new keyword sets all elements to the default value of the int datatype i.e. 0.

            Console.WriteLine("Example 4: result = {0}", arrayOne.SequenceEqual(arrayFour)); // Q: So this should return True?
            /* A: No, because even though the sequence is 0, 1, 2, 3, 4, with the new keyword all "empty" elements are set to the default value,
             * which is 0 for integer datatypes. Therefore we are comparing 0, 1, 2, 3, 4, 0, 0, 0, 0, 0 to 0, 1, 2, 3, 4. */

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}