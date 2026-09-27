using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Abstraction
{

    interface IOnlineBanking
    {
        bool TransferMoney(double amount, string receiver);
    }

    abstract class BankAccount
    {
        public string AccountNumber;
        public double Balance;
        public string HolderName;

        public double Deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }

         public abstract double Withdraw(double amount);
         public abstract double CalculateInterest();

    }
    class SavingsAccount : BankAccount, IOnlineBanking
    {
        public override double Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return Balance;
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
                return Balance;
            }
        }
        public override double CalculateInterest()
        {
            return Balance * 4 / 100; 
        }

        public bool TransferMoney(double amount, string receiver)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class CurrentAccount : BankAccount, IOnlineBanking
    {
        public override double Withdraw(double amount)
        {
            // allow withdrawal only if minimum balance 1000 is maintained after withdrawal
            if (Balance - amount >= 1000)
            {
                Balance -= amount;
                return Balance;
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
                return Balance;
            }
        }
        public override double CalculateInterest()
        {
            // current account has no interest
            return 0;
        }

        public bool TransferMoney(double amount, string receiver)
        {
            if (Balance - amount >= 1000)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal class TaskAbstraction
    {
        public static void Main()
        {
            Console.WriteLine("Enter Account Type: 1. Savings 2. Current");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Account Number: ");
            string accNo = Console.ReadLine();
            Console.Write("Holder Name: ");
            string holder = Console.ReadLine();

            BankAccount account;
            if (choice == 1)
            {
                account = new SavingsAccount();
            }
            else
            {
                account = new CurrentAccount();
            }

            account.AccountNumber = accNo;
            account.HolderName = holder;
            account.Balance = 0;

            // collect remaining inputs first
            Console.Write("Enter Deposit Amount: ");
            double deposit = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double withdrawal = double.Parse(Console.ReadLine());

            Console.Write("Enter Transfer Amount: ");
            double transfer = double.Parse(Console.ReadLine());

            Console.Write("Enter Receiver: ");
            string receiver = Console.ReadLine();

            // now perform operations and then display outputs
            account.Deposit(deposit);
            double beforeWithdraw = account.Balance;
            account.Withdraw(withdrawal);
            double interest = account.CalculateInterest();

            var online = account as IOnlineBanking;
            bool transferSuccess = false;
            if (online != null)
            {
                transferSuccess = online.TransferMoney(transfer, receiver);
            }

            // display summary
            if (choice == 1)
            {
                Console.WriteLine("----- Savings Account -----");
            }
            else
            {
                Console.WriteLine("----- Current Account -----");
            }

            Console.WriteLine($"Account Number : {account.AccountNumber}");
            Console.WriteLine($"Holder Name    : {account.HolderName}");
            Console.WriteLine($"Initial Balance: Rs.0");
            Console.WriteLine($"Deposited      : Rs.{deposit:0}");
            Console.WriteLine($"Current Balance: Rs.{beforeWithdraw:0}");

            if (beforeWithdraw != account.Balance)
            {
                Console.WriteLine($"Withdrawal     : Rs.{withdrawal:0}");
                Console.WriteLine($"Current Balance: Rs.{account.Balance:0}");
            }

            Console.WriteLine($"Interest       : Rs.{interest:0}");

            if (online != null)
            {
                if (transferSuccess)
                {
                    Console.WriteLine($"Transferred Rs.{transfer:0} to {receiver}");
                    Console.WriteLine($"Remaining Balance: Rs.{account.Balance:0}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance for transfer.");
                    Console.WriteLine($"Current Balance: Rs.{account.Balance:0}");
                }
            }
        }

    }
}
