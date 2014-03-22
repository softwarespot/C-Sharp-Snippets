using System;

namespace RockPaperScissors
{
    internal class Program
    {
        /* The following example was created as part of a competition in March 2014 to see
         * which one of us could create a game of Rock, Paper, Scissors using the least amount
         * of lines (of code). The stipulation was that if a line ended with a semi-colon then it
         * constituted as a new line as well as Console.WriteLine()s being exempt from the line count,
         * if they had no relevance and were only informing the user.
         *
         * I won with just 2 lines!
         */

        private static void Main()
        {
            Console.Write("========================================\n|\t\t\t\t\t|\n|\tRock, Paper, Scissors\t\t|\n|\t\t\t\t\t|\n|\tAuthor: SoftwareSpot (C) 2014\t|\n|\tBuild: 0.0.0.1\t\t\t|\n|\t\t\t\t\t|\n========================================\n");
            while (true)
            {
                Console.Write("\nPlease enter one of the following values\n\t\t1 = Rock\n\t\t2 = Paper\n\t\t3 = Scissors\n");
                // Nested ternary statements. It's difficult to read, but this is how the game only spans 2 lines.
                string[] answers = { Console.ReadLine(), "Rock", "Paper", "Scissors", new Random().Next(1, 3).ToString() };
                Console.WriteLine(answers[0] != "1" && answers[0] != "2" && answers[0] != "3" ? "Please enter a valid value next time." : "You chose " + answers[int.Parse(answers[0])] + " and the computer chose " + answers[int.Parse(answers[4])] + " with an outcome of " + (answers[0] == answers[4] ? "the same" : (answers[0] == "1" && answers[4] == "3") || (answers[0] == "2" && answers[4] == "1") || (answers[0] == "3" && answers[4] == "2") ? "winning" : "losing") + ".");
            }
        }
    }
}