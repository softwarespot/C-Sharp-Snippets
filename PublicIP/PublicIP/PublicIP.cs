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
            UserAgent = null; // Assign as null.
            publicIP = null; // Assign as null.
            timer = new Stopwatch(); // Create a new Stopwatch object.
        }

        /// <summary>
        /// Retrieves the public IP address of the local network
        /// </summary>
        /// <param name="userAgent">UserAgent string.</param>
        public PublicIP(string userAgent) // Constructor.
        {
            Interval = 300000; // Property for how many milliseconds between each check. This is 5 minutes.
            UserAgent = userAgent;
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
        /// UserAgent string.
        /// </summary>
        public string UserAgent
        {
            get;
            set;
        }

        /// <summary>
        /// Public IP address of the local network.
        /// </summary>
        /// <returns>Public IP address or null.</returns>
        public string Get()
        {
            if (timer.IsRunning && timer.ElapsedMilliseconds < Interval && publicIP != null)
            {
                return publicIP;
            }

            timer.Reset(); // Reset the timer.
            timer.Start(); // Start the timer from zero.
            try
            {
                WebClient webClient = new WebClient();
                if (!string.IsNullOrEmpty(UserAgent))
                {
                    webClient.Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
                }
                string iP = webClient.DownloadString("http://myexternalip.com/raw");
                iP = (new Regex(@"((?:\d{1,3}\.){3}\d{1,3})")).Matches(iP)[0].ToString();
                publicIP = iP;
            }
            catch
            {
            }
            return publicIP;
        }

        /// <summary>
        /// Public IP address of the local network.
        /// </summary>
        /// <returns>Public IP address of the local network.</returns>
        public override string ToString()
        {
            return publicIP;
        }
    }
}