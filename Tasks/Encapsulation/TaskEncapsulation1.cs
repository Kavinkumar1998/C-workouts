using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Encapsulation
{
    class Balance
    {
        private double balance = 5000;
        
        public double Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                return balance;
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
                return balance;
            }
        }

        public double Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return balance;
            }
            else
            {
                balance += amount;
                return balance;
            }
        }

      public double GetBalance()
        {
            return balance;
        }

    }
    internal class TaskEncapsulation1
    {
        public static void Main()
        {
            Balance account = new Balance();
            Console.WriteLine($"Initial Balance: {account.GetBalance()}");
            Console.WriteLine("Please enter the amount to deposit:");
            if (double.TryParse(Console.ReadLine(), out double depositAmount))
            {
                account.Deposit(depositAmount);
                Console.WriteLine($"Balance after deposit: {account.GetBalance()}");
            }
            Console.WriteLine("Please enter the amount to withdraw:");
            if (double.TryParse(Console.ReadLine(), out double withdrawalAmount))
            {
                account.Withdraw(withdrawalAmount);
                Console.WriteLine($"Balance after withdrawal: {account.GetBalance()}");
            }
        }
    }
}
