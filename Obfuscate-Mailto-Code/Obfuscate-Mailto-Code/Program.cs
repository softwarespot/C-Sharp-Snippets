using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Obfuscate_Mailto_Code
{
    internal class Program
    {
        [STAThread]
        // http://stackoverflow.com/questions/19707885/c-sharp-copy-to-clipboard
        public static void Main()
        {
            /*
             * The following code was based on an idea from John Haller known as Obfuscate Mailto Code:
             * http://johnhaller.com/useful-stuff/obfuscate-mailto
             *
             * License:
             * The same license as Obfuscate Mailto Code - Creative Commons Attribution-ShareAlike 2.5 License.
             */
            Console.Write("Enter a valid e-mail address: ");
            string email = Console.ReadLine() ?? "", emailnew = string.Empty;
            if (!Regex.IsMatch(email, @"^[A-Z0-9!#$%&'*+\-\/=?\^_`{|}~]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase)) // Specification: http://en.wikipedia.org/wiki/E-mail_address
            {
                Console.WriteLine("\nAn error occurred. Please check you entered a correct e-mail address.");
            }
            else
            {
                for (int i = 0; i < email.Length; i++)
                {
                    emailnew += @"&#" + (int)email[i] + ";"; // Cast from char to an integer value.
                }

                var split = emailnew.Split(new[] { "&#64;" }, StringSplitOptions.None);
                if (split.Length != 2)
                {
                    Console.WriteLine("\nAn error occurred. Please check you entered a correct e-mail address.");
                }
                else
                {
                    string output = @"<script language=""Javascript"" type=""text/javascript"">" + Environment.NewLine;
                    output += "<!--" + Environment.NewLine;
                    output += "document.write('<a href=\"\"mai');" + Environment.NewLine;
                    output += "document.write('lto');" + Environment.NewLine;
                    output += "document.write(':" + split[0] + "');" + Environment.NewLine;
                    output += "document.write('@');" + Environment.NewLine;
                    output += "document.write('" + split[1] + "\"\">');" + Environment.NewLine;
                    output += "document.write('" + split[0] + "');" + Environment.NewLine;
                    output += "document.write('@');" + Environment.NewLine;
                    output += "document.write('" + split[1] + "<\\/a>');" + Environment.NewLine;
                    output += "// -->" + Environment.NewLine;
                    output += "</script><noscript>" + split[0] + " at " + Environment.NewLine;
                    output += split[1].Replace("&#46;", " dot ") + @"</noscript>";

                    Clipboard.SetText(output, TextDataFormat.Text);
                    Console.Write("\nThe following output has been placed on the clipboard.\n\n" + output + "\n");
                }
            }

            Console.WriteLine(); // Empty line.
            Console.Write("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }
}