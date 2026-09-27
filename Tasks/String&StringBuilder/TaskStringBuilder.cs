using System;
using System.Linq;

namespace Tasks.String_StringBuilder
{
    internal class TaskStringBuilder
    {
        public static void Main()
        {
            Console.Write("Enter Password: ");
            string pwd = Console.ReadLine() ?? string.Empty;

            int length = pwd.Length;
            bool hasUpper = pwd.Any(char.IsUpper);
            bool hasLower = pwd.Any(char.IsLower);
            bool hasDigit = pwd.Any(char.IsDigit);
            bool hasSpecial = pwd.Any(c => !char.IsLetterOrDigit(c));

            Console.WriteLine($"Password Length: {length}");
            Console.WriteLine($"Uppercase: {(hasUpper ? "Yes" : "No")}");
            Console.WriteLine($"Lowercase: {(hasLower ? "Yes" : "No")}");
            Console.WriteLine($"Digit: {(hasDigit ? "Yes" : "No")}");
            Console.WriteLine($"Special Character: {(hasSpecial ? "Yes" : "No")}");

            int criteria = 0;
            if (hasUpper) criteria++;
            if (hasLower) criteria++;
            if (hasDigit) criteria++;
            if (hasSpecial) criteria++;

            string strength;
            if (length >= 8 && criteria == 4)
            {
                strength = "Strong";
            }
            else if (length >= 6 && criteria >= 3)
            {
                strength = "Medium";
            }
            else
            {
                strength = "Weak";
            }

            Console.WriteLine();
            Console.WriteLine($"Strength: {strength}");

            var missing = new System.Collections.Generic.List<string>();
            if (!hasUpper) missing.Add("Uppercase letter");
            if (!hasLower) missing.Add("Lowercase letter");
            if (!hasDigit) missing.Add("Digit");
            if (!hasSpecial) missing.Add("Special Character");

            if (missing.Count > 0)
            {
                Console.WriteLine($"Missing Requirement: {string.Join(", ", missing)}");
            }
        }
    }
}
