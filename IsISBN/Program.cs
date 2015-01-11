#region Required project assemblies

using System;

#endregion

namespace IsISBN
{
    internal class Program
    {
        /// <summary>
        ///     ISBN related flags.
        /// </summary>
        private enum ISBN : byte
        {
            /// <summary>
            ///     10-digit ISBN.
            /// </summary>
            Ten,
            /// <summary>
            ///     13-digit ISBN.
            /// </summary>
            Thirteen
        }

        /// <summary>
        ///     Check if a string contains a valid ISBN number.
        /// </summary>
        /// <param name="isbn">A string value containing an ISBN number.</param>
        /// <param name="type">An ISBN flag of the type to check.</param>
        /// <returns>true if a valid ISBN number; otherwise, false.</returns>
        private static bool IsISBN(string isbn, ISBN type)
        {
            if (String.IsNullOrWhiteSpace(isbn))
            {
                return false;
            }

            int length = isbn.Length - 1;
            const int nine = 57, zero = 48;
            int counter, sum = 0;
            switch (type)
            {
                case ISBN.Ten:
                    {
                        if (isbn[length] == 88 || isbn[length] == 120)
                        {
                            length -= 1;
                            sum = 10;
                        }

                        counter = 10;
                        for (int i = 0; i <= length; i++)
                        {
                            if (isbn[i] < zero || isbn[i] > nine)
                            {
                                continue;
                            }
                            sum += (isbn[i] - zero) * counter;
                            counter -= 1;
                        }
                        return sum % 11 == 0; // Divisible by 11.
                    }
                case ISBN.Thirteen:
                    {
                        const int one = 1, three = 3;
                        counter = one;
                        for (int i = 0; i <= length; i++)
                        {
                            if (isbn[i] < zero || isbn[i] > nine)
                            {
                                continue;
                            }
                            sum += (isbn[i] - zero) * counter;
                            counter = (counter == one) ? three : one;
                        }
                        return sum % 10 == 0; // Divisible by 10.
                    }
            }

            return false;
        }

        private static void Main()
        {
            Action<string, ISBN, bool> PrintISBN = // Anonymous method.
                (isbn, type, isExpected) =>
                    Console.WriteLine(isbn + " => " + IsISBN(isbn, type) + " [Expected: " + isExpected + "]");

            // 10-digit ISBN numbers.
            PrintISBN("ISBN0-9752298-0-X", ISBN.Ten, true); // Is a 10-digit ISBN number.
            PrintISBN("ISBN0-9752298-0-4", ISBN.Ten, false); // Is not a 10-digit ISBN number.
            PrintISBN("ISBN1-84356-028-3", ISBN.Ten, true); // Is a 10-digit ISBN number.
            PrintISBN("ISBN0-19-852663-6", ISBN.Ten, true); // Is a 10-digit ISBN number.
            PrintISBN("ISBN 1 86197 271 7", ISBN.Ten, true); // Is a 10-digit ISBN number.
            PrintISBN("ISBN 4 86197 271 7", ISBN.Ten, false); // Is not a 10-digit ISBN number.

            Console.WriteLine(); // Empty line.

            // 13-digit ISBN numbers.
            PrintISBN("ISBN-13: 978-0-306-40615-7", ISBN.Thirteen, true); // Is a 13-digit ISBN number.
            PrintISBN("ISBN-13: 978-1-86197-876-9", ISBN.Thirteen, true); // Is a 13-digit ISBN number.
            PrintISBN("ISBN-13: 978-1-86197-876-8", ISBN.Thirteen, false); // Is not a 13-digit ISBN number.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}