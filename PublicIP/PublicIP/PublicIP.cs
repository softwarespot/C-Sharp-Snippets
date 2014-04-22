using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace PublicIP
{
    internal class PublicIP // Idea about DownloadString(): http://www.codeproject.com/Tips/452024/Getting-the-External-IP-Address
    {
        private static string publicIP = null; // Assign as null.
        private static Stopwatch timer = new Stopwatch(); // Create a new Stopwatch object.

        /// <summary>
        /// Retrieves the public IP address of the local network.
        /// </summary>
        public PublicIP() // Constructor.
        {
            Interval = 300000; // Property for how many milliseconds between each check. This is 5 minutes.
            UserAgent = null; // Assign as null.
        }

        /// <summary>
        /// Retrieves the public IP address of the local network
        /// </summary>
        /// <param name="userAgent">UserAgent string.</param>
        public PublicIP(string userAgent) // Constructor.
        {
            Interval = 300000; // Property for how many milliseconds between each check. This is 5 minutes.
            UserAgent = userAgent;
        }

       ~PublicIP() // DeConstructor.
        {
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
        /// <param name="userAgent">UserAgent string.</param>
        /// <returns></returns>
        public static string Get(string userAgent)
        {
            return new PublicIP(userAgent).Get();
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

            timer.Restart(); // Restart the timer.

            WebClient webClient = new WebClient();
            if (!string.IsNullOrEmpty(UserAgent))
            {
                webClient.Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
            }
            string[] ipGetURL = { "http://checkip.dyndns.org", "http://www.myexternalip.com/raw", "http://bot.whatismyipaddress.com" };
            foreach (string url in ipGetURL)
            {
                string ip = null;
                try
                {
                    ip = webClient.DownloadString(url);
                    ip = (new Regex(@"((?:\d{1,3}\.){3}\d{1,3})")).Matches(ip)[0].ToString();
                }
                catch
                {
                    ip = null; // If an error occurred set ip to null.
                }
                if (ip != null) // If ip is not null then no error occurred.
                {
                    publicIP = ip;
                    break;
                }
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