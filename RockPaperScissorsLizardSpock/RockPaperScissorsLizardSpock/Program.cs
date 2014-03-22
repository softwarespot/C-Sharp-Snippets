using System;

namespace RockPaperScissorsLizardSpock
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
         *
         * Idea provided by Sam Kass: http://www.samkass.com/theories/RPSSL.html
         */

        private static void Main()
        {
            Console.Write("=========================================================\n|\t\t\t\t\t\t\t|\n|\tRock, Paper, Scissors, Lizard, Spock\t\t|\n|\t\t\t\t\t\t\t|\n|\tAuthor: SoftwareSpot (C) 2014\t\t\t|\n|\tBuild: 0.0.0.1\t\t\t\t\t|\n|\t\t\t\t\t\t\t|\n=========================================================\n");
            while (true)
            {
                Console.Write("\nPlease enter one of the following values\n\t\t1 = Rock\n\t\t2 = Paper\n\t\t3 = Scissors\n\t\t4 = Lizard\n\t\t5 = Spock\n");
                // Nested ternary statements. It's difficult to read, but this is how the game only spans 2 lines.
                string[] answers = { Console.ReadLine(), "Rock", "Paper", "Scissors", "Lizard", "Spock", new Random().Next(1, 5).ToString() };
                Console.WriteLine(answers[0] != "1" && answers[0] != "2" && answers[0] != "3" && answers[0] != "4" && answers[0] != "5" ? "Please enter a valid value next time." : "You chose " + answers[int.Parse(answers[0])] + " and the computer chose " + answers[int.Parse(answers[6])] + " with an outcome of " + (answers[0] == answers[6] ? "the same" : (answers[0] == "1" && answers[6] == "3") || (answers[0] == "1" && answers[6] == "4") || (answers[0] == "2" && answers[6] == "1") || (answers[0] == "2" && answers[6] == "5") || (answers[0] == "3" && answers[6] == "2") || (answers[0] == "3" && answers[6] == "4") || (answers[0] == "4" && answers[6] == "2") || (answers[0] == "4" && answers[6] == "5") || (answers[0] == "5" && answers[6] == "1") || (answers[0] == "5" && answers[6] == "3") ? "winning" : "losing") + ".");
            }
        }
    }
}