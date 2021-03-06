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
         * I won with just 2 lines! (Or 1 if you don't include the last Console.WriteLine() line.)
         */

        public static void Main()
        {
            while (true)
            {
                /* Note: This was the design plan I came up with when I implemented the Lottery game.
                * - Ask a user for lottery numbers e.g. 1,20,21,45 or 1 2 20 and between 1 and 49.
                * - Replace spaces and/or commas to commas only. Values can also be delimited by . or -.
                * - Replace non-digits with zero, so int.Parse() doesn't fail dramatically.
                * - Sort user ints.
                * - Check for duplicates in user integers.
                * - Create a random generated set of integers and sort the computer's choice.
                * - Compare the computer's choice to the user's choice.
                * NOTE: All regular expressions created by SoftwareSpot. The links to regex101.com are only to show what is parsed by the expression.
                */
                Console.Write("=========================================\n|\t\t\t\t\t|\n|\tLottery Numbers\t\t\t|\n|\t\t\t\t\t|\n|\tAuthor: SoftwareSpot (C) 2014\t|\n|\tBuild: 0.0.0.1\t\t\t|\n|\t\t\t\t\t|\n=========================================\nPlease enter a sequence of 7 lottery numbers between 1 and 49 and using either a comma (,) or whitespace e.g. 1, 6, 19  17 28 48, 15.\n");

                // Replace commas and spaces with a comma only. Strip the last leading/trailing comma characters if they exist.
                // Split into a string array with the comma character being the delimiter and replace non-digits to zero.
                // Parse each element as an integer and sort the elements in sequential order.
                // Creating a random integer array between 1 and 49: http://stackoverflow.com/questions/14118844/how-does-enumerable-orderby-use-keyselector with help from Joni for their idea with Enumerable.Range() and Take() method.
                int[] userArray = Array.ConvertAll(Regex.Replace(Regex.Replace(Regex.Replace(Console.ReadLine() ?? "", @"(\d+)\D*", @"$1,"), @"^,|,$", ""), @"[^\d,]", @"0").Split(','), int.Parse).OrderBy(element => element).ToArray(), computerArray = Enumerable.Range(1, 49).OrderBy(element => Guid.NewGuid()).Take(7).OrderBy(element => element).ToArray();  // Integer arrays to compare later using SequenceEqual().

                // Previous approach to generating a random number between 1 and 49.
                // while ((computerArray[i[0]] = new Random().Next(1, 49)) == 0 || Array.FindAll(computerArray, element => element == computerArray[i[0]]).Length != 1 || computerArray[i[0]] == 0 || ++i[0] != computerArray.Length) { } // Check it's not already in the computer's array or equal to 0. Loop until it doesn't exist.

                // OrderBy() and SequenceEqual() concept: http://stackoverflow.com/questions/50098/comparing-two-collections-for-equality-irrespective-of-the-order-of-items-in-the.
                // Find similar matches between both arrays: http://www.dotnetperls.com/intersect.

                // If the sort array doesn't have 7 elements OR there is a value less than 1 OR there is a value greater than 49 OR duplicate values exist, then FAIL. Otherwise check if both integer arrays are equal is the jackpot otherwise display the matches found using Intersect() of alternative winnings.
                // Changed matching values less than 1 or greater than 49 to a regular expression.  Old approach: Array.FindAll(userArray, element => element < 1 || element > 49).Length != 0
                // Alternative regular expression for checking duplicates: (\d+),\1(?=,|$).
                // Alternative regular expression for checking the bounds: http://regex101.com/r/lC9jX8.
                // Console.WriteLine((userArray.Length != 7 || Regex.IsMatch(String.Join(",", userArray), @"\b(0|(?:(?<=-)|[56789])\d+|\d{3,})\b") || Regex.IsMatch(String.Join(",", userArray), @"(\d+),\b\1\b")) ? "The values passed were incorrectly formatted and/or not between 1 and 49. Please try again.\n\n" : "User Lottery = " + String.Join(",", userArray) + "\nComputer Lottery = " + String.Join(",", computerArray) + "\n\nThe outcome was " + ((userArray.SequenceEqual(computerArray)) ? "you won! Congratulations.\n\n" : "you lost the jackpot!" + ((userArray.Intersect(computerArray).ToArray().Count() > 0) ? " But you had " + ((userArray.Intersect(computerArray).ToArray().Count() == 1) ? userArray.Intersect(computerArray).ToArray().Count() + " match " : userArray.Intersect(computerArray).ToArray().Count() + " matches ") + ((userArray.Intersect(computerArray).ToArray().Count() < 4) ? "and no win this time." : (userArray.Intersect(computerArray).ToArray().Count() == 4) ? "and won 400e." : (userArray.Intersect(computerArray).ToArray().Count() == 5) ? "and won 2300e." : (userArray.Intersect(computerArray).ToArray().Count() == 6) ? "and won 22000e." : "") : " Please try again.\n\n")));
                // Alternative approach to checking matches - Regex.Matches(String.Join(",", userArray) + "," + String.Join(",", computerArray), @"(\b\d{1,2}\b)(?=[\d,]+\b\1\b)").Count : http://regex101.com/r/aI3bA4
                Console.WriteLine((userArray.Length != 7 || Regex.IsMatch(String.Join(",", userArray), @"\b(0|(?:(?<=-)|[56789])\d+|\d{3,})\b") || Regex.IsMatch(String.Join(",", userArray), @"(\d+),\b\1\b")) ? "The values passed were incorrectly formatted and/or not between 1 and 49. Please try again.\n\n" : "User Lottery = " + String.Join(",", userArray) + "\nComputer Lottery = " + String.Join(",", computerArray) + "\n\nThe outcome was " + ((Regex.Matches(String.Join(",", userArray) + "," + String.Join(",", computerArray), @"(\b\d{1,2}\b)(?=[\d,]+\b\1\b)").Count == 7) ? "you won! Congratulations.\n\n" : "you lost the jackpot!" + ((userArray.Intersect(computerArray).ToArray().Count() > 0) ? " But you had " + ((userArray.Intersect(computerArray).ToArray().Count() == 1) ? userArray.Intersect(computerArray).ToArray().Count() + " match " : userArray.Intersect(computerArray).ToArray().Count() + " matches ") + ((Regex.Matches(String.Join(",", userArray) + "," + String.Join(",", computerArray), @"(\b\d{1,2}\b)(?=[\d,]+\b\1\b)").Count < 4) ? "and no win this time." : (Regex.Matches(String.Join(",", userArray) + "," + String.Join(",", computerArray), @"(\b\d{1,2}\b)(?=[\d,]+\b\1\b)").Count == 4) ? "and won 400e." : (Regex.Matches(String.Join(",", userArray) + "," + String.Join(",", computerArray), @"(\b\d{1,2}\b)(?=[\d,]+\b\1\b)").Count == 5) ? "and won 2300e." : (Regex.Matches(String.Join(",", userArray) + "," + String.Join(",", computerArray), @"(\b\d{1,2}\b)(?=[\d,]+\b\1\b)").Count == 6) ? "and won 22000e." : "") : " Please try again.\n\n")));
                return;
            }
        }
    }
}