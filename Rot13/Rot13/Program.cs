using System;
using System.Collections.Generic;

namespace Rot13
{
    public class Rot13 : ICipherRot
    {
        private readonly Dictionary<char, char> rot13 = new Dictionary<char, char>();

        /// <summary>
        /// Initialise the dictionary on a per object basis. I guess it could be made static as well?!
        /// </summary>
        public Rot13()
        {
            const string lowLower = "abcdefghijklm";
            const string highLower = "nopqrstuvwxyz";
            const string lowUpper = "ABCDEFGHIJKLM";
            const string highUpper = "NOPQRSTUVWXYZ";

            for (int i = 0; i < lowUpper.Length; i++)
            {
                // Convert a => n and A => N.
                rot13.Add(lowLower[i], highLower[i]);
                rot13.Add(highLower[i], lowLower[i]);

                // Convert n => a and N => A.
                rot13.Add(lowUpper[i], highUpper[i]);
                rot13.Add(highUpper[i], lowUpper[i]);
            }
        }

        /// <summary>
        /// Decode a Rot13 string.
        /// </summary>
        /// <param name="data">A Rot13 encoded string.</param>
        /// <returns>The original string.</returns>
        public string Decode(string data)
        {
            return Encode(data);
        }

        /// <summary>
        /// Encode a string to using Rot13.
        /// </summary>
        /// <param name="data">A string to be encoded.</param>
        /// <returns>An encoded string.</returns>
        public string Encode(string data)
        {
            var array = data.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char rotated;
                if (rot13.TryGetValue(array[i], out rotated))
                {
                    array[i] = rotated;
                }
            }
            return new string(array);
        }
    }

    internal class Program
    {
        public static void Main()
        {
            var rot13 = new Rot13(); // Create a rotation 13 object.
            string encodedString = rot13.Encode("Rotate this string."); // Encode the string.
            Console.WriteLine("Encoded string: {0}", encodedString);

            string decodedString = rot13.Decode(encodedString); // Decode the rotated string.
            Console.WriteLine("Decoded string: {0}", decodedString);

            Console.WriteLine(); // Create a new line.

            Console.Write("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}

interface ICipherRot
{
    string Decode(string data);
    string Encode(string data);
}
