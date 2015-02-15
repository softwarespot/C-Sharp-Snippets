#region

using System;
using System.Text.RegularExpressions;
using Password;

#endregion

namespace Password // Password namespace.
{
    internal class Errors // Errors class.
    {
        public readonly bool HasConsecutive, HasSpace, IsInts, IsLength, IsLowerCase, IsSpecial, IsUpperCase, IsValid;

        public Errors(bool isValid, bool hasAllow, bool hasSpace, bool isInts, bool isLength, bool isLowerCase,
            bool isSpecial, bool isUpperCase)
        {
            HasConsecutive = hasAllow;
            HasSpace = hasSpace;
            IsInts = isInts;
            IsLength = isLength;
            IsLowerCase = isLowerCase;
            IsSpecial = isSpecial;
            IsUpperCase = isUpperCase;
            IsValid = isValid;
        }
    }

    internal class Valid
    // Based on code I created with AutoIt: http://www.autoitscript.com/forum/topic/153018-passwordvalid-udf-like-example-of-validating-a-password/
    {
        public Valid() // Constructor - Set default values.
        {
            AllowConsecutive = true;
            AllowSpace = true;
            Ints = 0;
            Length = 0;
            LowerCase = 0;
            Special = 0;
            UpperCase = 0;
        }

        // No DeConstructor is required in this class.

        public bool AllowConsecutive { get; set; }
        // Properties. This is alot cleaner than public int isConsecutive; as it doesn't display the variable names to the end user.

        public bool AllowSpace { get; set; }
        public int Ints { get; set; }
        // I could add a try-catch to make sure it's an int or int.TryParse(), but this should be checked before passing to the property.

        public int Length { get; set; }
        public int LowerCase { get; set; }
        public int Special { get; set; }
        public int UpperCase { get; set; }
        // ReSharper disable once FunctionComplexityOverflow
        public Errors Validate(string password) // Validate Method().
        {
            int isValid = 1;
            bool hasConsecutive = false,
                hasSpace = false,
                isInts = false,
                isLength = false,
                isLowerCase = false,
                isSpecial = false,
                isUpperCase = false;
            if (!AllowConsecutive) // Check if characters are consecutive e.g. password, where "aa" is invalid.
            {
                isValid = isValid * (Regex.IsMatch(password, @"(.)\1") ? 0 : 1);
                hasConsecutive = (isValid == 0);
            }

            if (!AllowSpace) // Check if whitespace is found.
            {
                hasSpace = Regex.IsMatch(password, @"\s");
                isValid = isValid * (hasSpace ? 0 : 1);
            }

            if (Ints > 0) // Check if the minimum number of integers is honoured.
            {
                isInts = Regex.Split(password, @"\d").Length - 1 < Ints;
                isValid = isValid * (isInts ? 0 : 1);
            }

            if (Length > 0) // Check if the password length is honoured.
            {
                isLength = Regex.Split(password, @"\S").Length - 1 < Length;
                isValid = isValid * (isLength ? 0 : 1);
            }

            if (LowerCase > 0) // Check if the minimum number of lowercase characters is honoured.
            {
                isLowerCase = Regex.Split(password, @"[a-z]").Length - 1 < LowerCase;
                isValid = isValid * (isLowerCase ? 0 : 1);
            }

            /*
             * Special characters are: ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~
             */
            if (Special > 0) // Check if the minimum number of special characters is honoured.
            {
                isSpecial = Regex.Split(password, @"[><^|=~`$+\p{P}]").Length < Special;
                isValid = isValid * (isSpecial ? 0 : 1);
            }

            if (UpperCase > 0)
            {
                isUpperCase = Regex.Split(password, @"[A-Z]").Length < UpperCase;
                isValid = isValid * (isUpperCase ? 0 : 1);
            }

            return new Errors(isValid > 0, hasConsecutive, hasSpace, isInts, isLength, isLowerCase, isSpecial,
                isUpperCase);
        }
    }
}

namespace PasswordValidator
{
    internal class Program
    {
        private static void Main()
        {
            // Create a PasswordValid object.
            Valid password1 = new Valid
            {
                Ints = 2, // Must contain 2 integers.
                Length = 6, // Must contain a minimum of 6 characters.
                LowerCase = 2, // Must contain at least 2 lowercase characters.
                AllowConsecutive = false // Disallow consecutive characters e.g. the S in password.
            };

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("| Password Validator                                                      |");
            Console.WriteLine("| Build: 0.0.0.1                                                          |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("| Note: To exit the application please enter \"-1\"                       |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("***************************************************************************");

            string password = ""; // Variable to hold the password string..
            while (password != null && password.ToLower() != "-1")
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                Errors password1_Errors = password1.Validate(password);
                // Declare a variable to hold the password error results.
                Console.WriteLine("The following password : {0} returned {1}", password, password1_Errors.IsValid);
                // Returns true or false.

                PrintErrorResults(password1_Errors); // Print additional error results for the PasswordValid object.
            }

            Console.WriteLine(); // Empty line.

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }

        private static void PrintErrorResults(Errors passwordResults)
        {
            Console.WriteLine(); // Empty line.
            if (passwordResults.IsValid)
                return; // Return if the IsValid property is true as this indicated no error was created.
            if (passwordResults.HasConsecutive)
                Console.WriteLine("The password contained repeating characters e.g. S in Password.");
            if (passwordResults.HasSpace)
                Console.WriteLine("The password contained space(s).");
            if (passwordResults.IsInts)
                Console.WriteLine("The password didn't contain the minimum number of digits.");
            if (passwordResults.IsLength)
                Console.WriteLine("The password didn't match the minimum length.");
            if (passwordResults.IsLowerCase)
                Console.WriteLine("The password didn't contain the minimum number of lowercase characters.");
            if (passwordResults.IsSpecial)
                Console.WriteLine("The password didn't contain the minimum number of special characters.");
            if (passwordResults.IsUpperCase)
                Console.WriteLine("The password didn't contain the minimum number of uppercase characters.");
            Console.WriteLine(); // Empty line.
        }
    }
}