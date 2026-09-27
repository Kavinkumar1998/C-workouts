using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ExceptionHandling
{
    public class InsufficientBalanceException : Exception
    {
        public double AvailableBalance { get; }
        public double RequestedAmount { get; }

        public InsufficientBalanceException(string message, double available, double requested)
            : base(message)
        {
            AvailableBalance = available;
            RequestedAmount = requested;
        }
    }

    class BankAccount
    {
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be greater than 0.");

            if (amount > Balance)
                throw new InsufficientBalanceException("Insufficient balance.", Balance, amount);

            Balance -= amount;
        }
    }

    internal class TaskExceptionHandling1
    {
        public static void Main()
        {
            Console.Write("Account Holder: ");
            string holder = Console.ReadLine();

            Console.Write("Balance: ");
            double balance = 0;
            double.TryParse(Console.ReadLine(), out balance);

            Console.Write("Enter Withdrawal Amount: ");
            double withdraw = 0;
            double.TryParse(Console.ReadLine(), out withdraw);

            var account = new BankAccount { AccountHolderName = holder, Balance = balance };

            try
            {
                account.Withdraw(withdraw);
                Console.WriteLine("Withdrawal successful.");
                Console.WriteLine($"Remaining Balance: {account.Balance:0}");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Transaction Failed.");
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Available Balance: {ex.AvailableBalance:0}");
                Console.WriteLine($"Requested Amount: {ex.RequestedAmount:0}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Transaction Failed.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
