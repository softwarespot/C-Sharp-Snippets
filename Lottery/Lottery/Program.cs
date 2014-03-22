﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lottery
{
    internal class Program
    {
        /* The following example was created as part of a competition in March 2014 to see
         * which one of us could create a lottery game with the least amount
         * of lines (of code). The stipulation was that if a line ended with a semi-colon then it
         * constituted as a new line as well as Console.WriteLine()s being exempt from the line count,
         * if they had no relevance and were only informing the user. The numbers had to be between
         * 1 and 49, contain no duplicates and be sorted upon presentation to the user.
         *
         * I won with just 5 lines! (Or 4 if you don't include the last Console.WriteLine() line.)
         */

        public static void Main()
        {
            while (true)
            {
                /* Note: This was the design plan I came up with when I implemented the Lottery game.
                * - Ask a user for lottery numbers e.g. 1,20,21,45 or 1 2 20 and between 1 and 49.
                * - Replace spaces and/or commas to commas only. Values can also be delimited by . or -.
                * - Pad single digits with a pre-appending 0 e.g. 9 to 09.
                * - Sort user ints.
                * - Check for duplicates in user integers.
                * - Create a random generated set of integers and sort the computer's choice.
                * - Compare the computer's choice to the user's choice.
                */
                Console.Write("=========================================\n|\t\t\t\t\t|\n|\tLottery Numbers\t\t\t|\n|\t\t\t\t\t|\n|\tAuthor: SoftwareSpot (C) 2014\t|\n|\tBuild: 0.0.0.1\t\t\t|\n|\t\t\t\t\t|\n=========================================\nPlease enter a sequence of 7 lottery numbers between 1 and 49 and using either a comma (,) or whitespace e.g. 1, 6, 19  17 28 48, 15.\n");

                // Replace commas and spaces with a comma only. Strip the last leading/trailing comma characters if they exist.
                // Split into a string array with the comma character being the delimiter and replace non-digits to zero.
                int[] i = { 0 }, userArray = Array.ConvertAll(Regex.Replace(Regex.Replace(Regex.Replace(Console.ReadLine(), @"(\d+)\D*", @"$1,"), @"^,|,$", ""), @"[^\d,]", @"0").Split(','), int.Parse), computerArray = { 0, 0, 0, 0, 0, 0, 0 }; // Integer arrays to compare later using SequenceEqual().

                // Generate a random number between 1 and 49.
                while ((computerArray[i[0]] = new Random().Next(1, 49)) == 0 || Array.FindAll(computerArray, element => element == computerArray[i[0]]).Length != 1 || computerArray[i[0]] == 0 || ++i[0] != computerArray.Length) { } // Check it's not already in the computer's array or equal to 0. Loop until it doesn't exist.

                // Sort the array of integer values..
                Array.Sort(userArray);
                Array.Sort(computerArray);

                // If the sort array does not have 7 elements OR the value is less than 1 OR the value is greater than 49 OR duplicate value exists, the FAIL, otherwise check if both int arrays are equal. // RegExp v2: (\d+),\1(?=,|$)
                Console.WriteLine((userArray.Length != 7 || Array.FindAll(userArray, element => element < 1 || element > 49).Length != 0 || Regex.IsMatch(string.Join(",", userArray), @"(\d+),\b\1\b")) ? "The values passed were incorrectly formatted and/or not between 1 and 49. Please try again.\n\n" : "User Lottery = " + string.Join(",", userArray) + "\nComputer Lottery = " + string.Join(",", computerArray) + "\n\nThe outcome was " + ((userArray.SequenceEqual(computerArray)) ? "you won! Congratulations.\n\n" : "you lost! Please try again.\n\n"));
            }
        }
    }
}