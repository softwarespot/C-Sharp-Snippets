using System;

namespace Obfuscate_Mailto_Code
{
    internal class Program
    {
        public static void Main()
        {
            /*
             * The following code was based on an idea from John Haller known as Obfuscate Mailto Code:
             * http://johnhaller.com/useful-stuff/obfuscate-mailto
             *
             * License:
             * The same license as Obfuscate Mailto Code - Creative Commons Attribution-ShareAlike 2.5 License.
             */
            string email = "test@google.com", emailnew = string.Empty;
            for (int i = 0; i < email.Length; i++)
            {
                emailnew += @"&#" + (int)email[i] + ";"; // Cast from char to an integer value.
            }

            string[] split = emailnew.Split(new String[] { "&#64;" }, StringSplitOptions.None);
            string output = @"<script language=""Javascript"" type=""text/javascript"">\n";
            output += "<!--\n";
            output += "document.write('<a href=\"\"mai');\n";
            output += "document.write('lto');\n";
            output += "document.write(':" + split[0] + "');\n";
            output += "document.write('@');\n";
            output += "document.write('" + split[1] + "\"\">');\n";
            output += "document.write('" + split[0] + "');\n";
            output += "document.write('@');\n";
            output += "document.write('" + split[1] + "<\\/a>');\n";
            output += "// -->\n";
            output += "</script><noscript>" + split[0] + " at \n";
            output += split[1].Replace("&#46;", " dot ") + @"</noscript>";
            Console.Write(output);

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}