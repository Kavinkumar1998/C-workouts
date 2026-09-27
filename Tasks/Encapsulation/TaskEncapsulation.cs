using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Encapsulation
{
    class PinNumber
    {
        private int pin;

        public void SetPin(int pin)
        {
            if (pin >= 1000 && pin <= 9999)
            {
                this.pin = pin;
            }
            else
            {
                throw new ArgumentException("Pin must be a 4-digit number.");
            }
        }

        // Do not expose the actual PIN
        public string GetMaskedPin()
        {
            return "****";
        }

        // Prompt user to enter PIN with masked input and validate
        public bool ValidatePin()
        {
            Console.Write("Enter PIN: ");
            string input = ReadPinMasked();
            int entered;
            if (int.TryParse(input, out entered) && input.Length == 4)
            {
                return entered == pin;
            }
            return false;
        }


        private string ReadPinMasked()
        {
            var pinBuilder = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (pinBuilder.Length > 0)
                    {
                        pinBuilder.Length -= 1;
                        Console.Write("\b \b");
                    }
                    continue;
                }
                if (char.IsDigit(key.KeyChar) && pinBuilder.Length < 4)
                {
                    pinBuilder.Append(key.KeyChar);
                    Console.Write("*");
                    if (pinBuilder.Length == 4)
                    {
                        Console.WriteLine();
                        break;
                    }
                }
            }
            return pinBuilder.ToString();
        }


    }



    internal class TaskEncapsulation
    {
        public static void Main()
        {
            var pinObj = new PinNumber();

            while (true)
            {
                Console.Write("Set a 4-digit PIN: ");
                string input = Console.ReadLine();
                if (input != null && input.Length == 4 && input.All(char.IsDigit))
                {
                    pinObj.SetPin(int.Parse(input));
                    break;
                }
                Console.WriteLine("Invalid PIN. PIN must be exactly 4 digits.");
            }

            // When showing account info, do not display actual PIN
            Console.WriteLine($"Enter PIN: {pinObj.GetMaskedPin()}");

            // Now validate PIN (masked input)
            Console.Write("Please enter PIN to verify: ");
            bool valid = pinObj.ValidatePin();
            if (valid)
            {
                Console.WriteLine("PIN Verified");
            }
            else
            {
                Console.WriteLine("Invalid PIN");
            }
        }
    }
}
