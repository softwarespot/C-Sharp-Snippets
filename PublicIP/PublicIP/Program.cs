using System;

namespace PublicIP
{
    internal class Program
    {
        private static void Main()
        {
            PublicIP publicIP = new PublicIP();
            Console.WriteLine("Public IP: {0}", publicIP.Get());
            Console.WriteLine("IP discovery interval: {0}", publicIP.Interval);
            Console.WriteLine("Public IP (ToString): {0}", publicIP.ToString());

            Console.WriteLine(); // Empty line.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}