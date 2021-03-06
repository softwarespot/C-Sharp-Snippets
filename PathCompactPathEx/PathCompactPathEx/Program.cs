﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PathCompactPathEx
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(PathCompactPathEx(@"C:\This_is_some_long_file_path\with_a_couple_of_folders\and_a\filename.txt", 20));

            Console.WriteLine(); // New line.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }

        private static string PathCompactPathEx(string filePath, int length)
        {
            if (!String.IsNullOrEmpty(filePath) && (filePath.Length - Path.GetFileName(filePath).Length) > length) // Shorten the path but still retaining the file name length.
            {
                filePath = Regex.Replace(filePath, @"^(.{" + length + @"}).+?([^\\]+)$", @"$1...\$2");
            }
            return filePath;
        }
    }
}
