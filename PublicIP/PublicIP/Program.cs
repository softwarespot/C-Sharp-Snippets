﻿using System;

namespace PublicIP
{
    internal class Program
    {
        private static void Main()
        {
            // Example by creating a new object.
            PublicIP publicIP = new PublicIP();
            publicIP.UserAgent = "PublicIPExample"; // Set the UserAgent string.
            Console.WriteLine("Public IP: {0}", publicIP.Get());
            Console.WriteLine("IP discovery interval: {0}", publicIP.Interval);
            Console.WriteLine("Public IP (ToString): {0}", publicIP.ToString());

            // Example by using the static method.
            Console.WriteLine("Public IP: {0}", PublicIP.Get("PublicIPExampleStatic"));

            Console.WriteLine(); // Empty line.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}