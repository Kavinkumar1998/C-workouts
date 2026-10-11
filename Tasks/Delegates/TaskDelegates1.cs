using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Delegates
{
    internal class TaskDelegates1
    {
        public delegate double SalaryCalculator(double monthlySalary);

        public static double CalculateAnnualSalary(double monthlySalary)
        {
            return monthlySalary * 12;
        }

        public delegate void NotifyUser(string userName);

        public static void SendEmail(string userName)
        {
            Console.WriteLine($"Email Notification sent to {userName}");
        }

        public static void SendSMS(string userName)
        {
            Console.WriteLine($"SMS Notification sent to {userName}");
        }

        public static void Main()
        {
            Console.Write("Enter Monthly Salary (or press Enter for 30000): ");
            string input = Console.ReadLine();
            double monthly = 30000;
            if (!string.IsNullOrWhiteSpace(input))
            {
                double.TryParse(input, out monthly);
            }

            SalaryCalculator calc = CalculateAnnualSalary;
            double annual = calc(monthly);
            Console.WriteLine($"Annual Salary: {annual:0}");

            Console.WriteLine();
            Console.Write("Enter User Name (or press Enter for Ajith): ");
            string user = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(user)) user = "Ajith";

            NotifyUser notifier = SendEmail;
            notifier(user);

            notifier = SendSMS;
            notifier(user);
        }
    }
}
