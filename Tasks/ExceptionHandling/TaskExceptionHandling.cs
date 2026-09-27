using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ExceptionHandling
{
    // Custom exception for invalid passwords
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message) { }
    }

    internal class TaskExceptionHandling
    {
        public static void Main()
        {
            Console.Write("Enter Password: ");
            string pwd = Console.ReadLine() ?? string.Empty;

            try
            {
                ValidatePassword(pwd);
                Console.WriteLine("Password is valid.");
                Console.WriteLine("Registration completed successfully.");
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        private static void ValidatePassword(string pwd)
        {
            if (pwd.Length < 6)
                throw new InvalidPasswordException("Password must have a minimum of 6 characters.");

            if (pwd.Contains(' '))
                throw new InvalidPasswordException("Password must not contain spaces.");

            if (!pwd.Any(char.IsUpper))
                throw new InvalidPasswordException("Password must contain at least one uppercase character.");

            if (!pwd.Any(char.IsLower))
                throw new InvalidPasswordException("Password must contain at least one lowercase character.");

            if (!pwd.Any(char.IsDigit))
                throw new InvalidPasswordException("Password must contain at least one digit.");

            if (!pwd.Any(ch => !char.IsLetterOrDigit(ch)))
                throw new InvalidPasswordException("Password must contain at least one special character.");
        }
    }
}
