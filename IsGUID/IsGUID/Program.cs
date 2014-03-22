﻿using System;
using System.Text.RegularExpressions;

namespace IsGUID
{
    internal class Program
    {
        private static bool IsGUID(string guid)
        {
            return Regex.IsMatch(guid, @"^(?:\{){0,1}[0-9A-Za-z]{8}-(?:[0-9A-Za-z]{4}-){3}[0-9A-Za-z]{12}(?:\}){0,1}$");
        }

        private static void Main()
        {
            // Checks if a GUID contains <8 hex values>-<4 hex values>-<4 hex values>-<4 hex values>-<12 hex values> with optional brackets.
            string guid = string.Empty;

            guid = "{DDBA58F7-8A63-48F1-9641-F550A60AEDD3}"; // This is valid.
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guid, IsGUID(guid));

            Console.WriteLine(""); // Write a new line.

            guid = "{4C425BDE-8D9A-466C-B252-AC74F6F0EFBF}"; // This is valid.
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guid, IsGUID(guid));

            Console.WriteLine(""); // Write a new line.

            guid = "{4C425BDE-8D9A-466C-B252-AC74F6F0E}"; // This is invalid.
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guid, IsGUID(guid));

            Console.WriteLine(""); // Write a new line.

            guid = "4C425BDE-8D9A-466C-B252-AC74F6F0EFBF"; // This is valid with no brackets.
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guid, IsGUID(guid));

            Console.WriteLine(""); // Write a new line.

            Console.WriteLine("Please enter any key to continue...");
            Console.ReadKey(true);
        }
    }
}