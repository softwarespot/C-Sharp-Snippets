﻿#region

using System;
using System.Text.RegularExpressions;

#endregion

namespace IsGUID
{
    internal class Program
    {
        private static bool IsGUID(string guid)
        {
            return !String.IsNullOrEmpty(guid) && Regex.IsMatch(guid,
                @"^(?:(?<curly>\{)?[0-9A-Fa-f]{8}-(?:[0-9A-Fa-f]{4}-){3}[0-9A-Fa-f]{12}(?(curly)\}))$");
        }

        private static void Main()
        {
            // Checks if a GUID contains <8 hex values>-<4 hex values>-<4 hex values>-<4 hex values>-<12 hex values> with optional brackets.

            string guidValue = Guid.NewGuid().ToString();
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guidValue, IsGUID(guidValue));

            Console.WriteLine(); // Empty line.

            guidValue = "{4C425BDE-8D9A-466C-B252-AC74F6F0EFBF}"; // This is valid.
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guidValue, IsGUID(guidValue));

            Console.WriteLine(); // Empty line.

            guidValue = "{4C425BDE-8D9A-466C-B252-AC74F6F0E}"; // This is invalid.
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guidValue, IsGUID(guidValue));

            Console.WriteLine(); // Empty line.

            guidValue = "4C425BDE-8D9A-466C-B252-AC74F6F0EFBF"; // This is valid with no brackets.
            Console.WriteLine("Is the GUID: {0}, a valid GUID?\r\nReturn: {1}", guidValue, IsGUID(guidValue));

            Console.WriteLine(); // Empty line.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}
