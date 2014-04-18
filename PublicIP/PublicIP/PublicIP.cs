using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace PublicIP
{
    internal class PublicIP // Idea about DownloadString(): http://www.codeproject.com/Tips/452024/Getting-the-External-IP-Address
    {
        private string publicIP;
        private Stopwatch timer;

        /// <summary>
        /// Retrieves the public IP address of the local network.
        /// </summary>
        public PublicIP() // Constructor.
        {
            Interval = 300000; // Property for how many milliseconds between each check. This is 5 minutes.
            publicIP = null; // Assign as null.
            timer = new Stopwatch(); // Create a new Stopwatch object.
        }

        ~PublicIP() // DeConstructor.
        {
            timer.Stop();
            timer = null;
        }

        /// <summary>
        /// Interval in milliseconds of how often the IP discovery site is queried.
        /// </summary>
        public int Interval
        {
            get;
            private set;
        }

        /// <summary>
        /// Public IP address of the local network.
        /// </summary>
        /// <returns>Public IP address or null.</returns>
        public string Get()
        {
            if (timer.IsRunning && timer.ElapsedMilliseconds < Interval && this.publicIP != null)
            {
                return this.publicIP;
            }

            timer.Reset(); // Reset the timer.
            timer.Start(); // Start the timer from zero.
            try
            {
                string publicIP = (new WebClient()).DownloadString("http://myexternalip.com/raw");
                publicIP = (new Regex(@"((?:\d{1,3}\.){3}\d{1,3})")).Matches(publicIP)[0].ToString();
                this.publicIP = publicIP;
            }
            catch { }
            return this.publicIP;
        }

        /// <summary>
        /// Public IP address of the local network.
        /// </summary>
        /// <returns>Public IP address of the local network.</returns>
        public override string ToString()
        {
            return this.publicIP;
        }
    }
}