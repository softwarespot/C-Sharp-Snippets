using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharpDevelopPortable
{
    internal class Program
    {
        public static void Main()
        {
            string sharpExecutable = Application.StartupPath + @"\bin\SharpDevelop.exe";
            string sharpConfig = sharpExecutable + ".config";
            if (!File.Exists(sharpConfig) || !File.Exists(sharpExecutable)) // Check if both files are present.
            {
                MessageBox.Show("Unable to find SharpDevelop.exe or SharpDevelop.exe.config.\n\nPlease ensure they are both located in the bin directory of this folder.");
                return;
            }

            var fileRead = new StreamReader(sharpConfig); // Read the config file to a new stream.
            string dataString = fileRead.ReadToEnd();
            fileRead.Close(); // Close the file stream.
            fileRead = null;

            string srePattern = @"(?<!<!--\s)<add\s+key=""KEYVALUE""\s+value=""\.\.\\VALUEVAL""\s+\/>"; // Regular expression pattern.
            if (!Regex.IsMatch(dataString, srePattern.Replace("KEYVALUE", "settingsPath").Replace("VALUEVAL", "Settings")) ||
                !Regex.IsMatch(dataString, srePattern.Replace("KEYVALUE", "domPersistencePath").Replace("VALUEVAL", "DomCache"))) // Check ..\Settings and ..\DomCache doesn't exist in the file already.
            {
                srePattern = @"((?<!<!--\s)<add\s+key=""KEYVALUE""\s+value=)"".*?"""; // Regular expression pattern.
                dataString = Regex.Replace(dataString, srePattern.Replace("KEYVALUE", "settingsPath"), @"$1""..\Settings"""); // Overwrite the settingsPath key.
                dataString = Regex.Replace(dataString, srePattern.Replace("KEYVALUE", "domPersistencePath"), @"$1""..\DomCache"""); // Overwrite the domPersistencePath key.

                var fileWrite = new StreamWriter(sharpConfig, false); // Write to the file and set append as false to overwrite the file.
                fileWrite.Write(dataString);
                fileWrite.Close(); // Close the file stream.
                fileWrite = null;
            }

            var processInfo = new ProcessStartInfo();
            processInfo.FileName = sharpExecutable;
            processInfo.WorkingDirectory = Application.StartupPath + @"\bin"; // Set the current directory to be in the bin.

            // Execute the SharpDevelop.exe file.
            Process.Start(processInfo);
        }
    }
}