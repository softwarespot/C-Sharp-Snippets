
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        private static void Main()
        {
            // Console.WriteLine("|#---#|--#--|-----|");
            // Console.WriteLine("|--#--|#---#|-----|");
            // Console.WriteLine("|#---#|--#--|-----|");

            Console.Title = "Tic-Tac-Toe";

            const int emptyValue = 0,
                userValue = 1,
                computerValue = 2,
                _userChoice = 0,
                _computerChoice = 10;
            int[] table = new int[_computerChoice + 1]; // usersChoice = 0, computerChoice = 10.

            Print(table);

            const int _logicCount = 7;
            int[,] computerLogic =
            {
                {0, 0, 0, 0, 0, 0, 0, 0}, // Empty because the game is 1 based.
                {2, 4, 5, 0, 0, 0, 0, 3},
                // Last column is used as a count for the number of possible squares around the user's choice.
                {1, 3, 4, 5, 6, 0, 0, 5},
                {2, 5, 6, 0, 0, 0, 0, 3},
                {1, 2, 5, 7, 8, 0, 0, 5},
                {1, 2, 3, 4, 6, 7, 9, 7},
                {2, 3, 5, 8, 9, 0, 0, 5},
                {4, 5, 8, 0, 0, 0, 0, 3},
                {4, 5, 6, 7, 9, 0, 0, 5},
                {5, 6, 8, 0, 0, 0, 0, 3}
            };

            bool? isWin = null;
            List<int> randomSequence = Enumerable.Range(1, 9).OrderBy(element => Guid.NewGuid()).Take(9).ToList();
            // Create a List of randomly sorted integers between 1 and 9.
            while (randomSequence.Count != 0 && isWin == null)
            {
                Console.WriteLine("Please enter a choice from 1 - 9.");

                int.TryParse(Console.ReadLine(), out table[_userChoice]);
                if (table[_userChoice] < 1 || table[_userChoice] > 9 || table[table[_userChoice]] != emptyValue)
                    continue;

                table[table[_userChoice]] = userValue; // Add as being taken by the user.
                randomSequence.Remove(table[_userChoice]); // Remove item from the random sequence.

                // Only a cosmetic feature.
                Print(table);
                isWin = IsWin(table, userValue, computerValue);
                if (isWin != null)
                {
                    break;
                }

                bool isComputer = false;
                int[] squareRange =
                    Enumerable.Range(0, computerLogic[table[_userChoice], _logicCount] - 1)
                        .OrderBy(element => Guid.NewGuid())
                        .Take(computerLogic[table[_userChoice], _logicCount])
                        .ToArray();
                foreach (int square in squareRange)
                {
                    isComputer = table[computerLogic[table[_userChoice], square]] == emptyValue &&
                                 randomSequence.Count > 0;
                    if (isComputer)
                    {
                        randomSequence.RemoveAt(square); // Remove item from the random sequence.
                        table[computerLogic[table[_userChoice], square]] = computerValue;
                        // Add as being taken by the computer.
                        break;
                    }
                }

                if (!isComputer)
                {
                    table[_computerChoice] = new Random(Environment.TickCount).Next(0, randomSequence.Count - 1);
                    // Use the system tick count as a random seed.
                    randomSequence.RemoveAt(table[_computerChoice]); // Remove item from the random sequence.
                    table[table[_computerChoice]] = computerValue; // Add as being taken by the computer.
                }

                // Only a cosmetic feature.
                Print(table);
                isWin = IsWin(table, userValue, computerValue);
            }

            switch (isWin) // Display the results.
            {
                case true:
                    Console.WriteLine("You won the tic-tac-toe game.");
                    break;

                case false:
                    Console.WriteLine("You lost the tic-tac-toe game.");
                    break;

                default:
                    Console.WriteLine("It was a draw.");
                    break;
            }

            Console.ReadKey(true);
        }

        private static bool? IsWin(int[] table, int userValue, int computerValue)
        {
            return (table[1] == userValue && table[2] == userValue && table[3] == userValue ||
                    table[4] == userValue && table[5] == userValue && table[6] == userValue ||
                    table[7] == userValue && table[8] == userValue && table[9] == userValue ||
                    table[1] == userValue && table[4] == userValue && table[7] == userValue ||
                    table[2] == userValue && table[5] == userValue && table[8] == userValue ||
                    table[3] == userValue && table[6] == userValue && table[9] == userValue ||
                    table[1] == userValue && table[5] == userValue && table[9] == userValue ||
                    table[3] == userValue && table[5] == userValue && table[7] == userValue)
                ? true
                : ((table[1] == computerValue && table[2] == computerValue && table[3] == computerValue ||
                    table[4] == computerValue && table[5] == computerValue && table[6] == computerValue ||
                    table[7] == computerValue && table[8] == computerValue && table[9] == computerValue ||
                    table[1] == computerValue && table[4] == computerValue && table[7] == computerValue ||
                    table[2] == computerValue && table[5] == computerValue && table[8] == computerValue ||
                    table[3] == computerValue && table[6] == computerValue && table[9] == computerValue ||
                    table[1] == computerValue && table[5] == computerValue && table[9] == computerValue ||
                    table[3] == computerValue && table[5] == computerValue && table[7] == computerValue)
                    ? false
                    : (bool?)null);
        }

        private static void Print(int[] table)
        {
            Console.Clear();
            for (int i = 1; i <= 9; i++)
                Console.Write(((i == 1) ? "Tic-Tac-Toe by SoftwareSpot (c) 2014\n|-----|-----|-----|\n" : "") +
                              ((table[i] == 1) ? "|--X--" : (table[i] == 2) ? "|--0--" : "|--" + i + "--") +
                              ((i % 3 == 0) ? "|\n|-----|-----|-----|\n" : ""));
        }
    }
}