using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Inheritance;

namespace Tasks.Inheritance
{
    class Customer
    {
     public int CustomerId;
     public string CustomerName;
    }


    class BankAccount : Customer
    {
        public string AccountNumber;
        public double Balance;
        public double Deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }

        public double Withdraw(double amount)
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

    }


    class SavingsAccount : BankAccount
    {
        public double InterestRate;
        public double InitialBalance;
        public double DepositedAmount;
        public double WithdrawnAmount;
        public double CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine($"Customer Id: {CustomerId}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Initial Balance: {InitialBalance}");
            Console.WriteLine($"Deposited: {DepositedAmount}");
            Console.WriteLine($"Withdrawn: {WithdrawnAmount}");
            Console.WriteLine($"Current Balance: {Balance}");
            Console.WriteLine($"Interest: {CalculateInterest()}");
           
        }
    }
    internal class TaskInheritance2
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Canara Bank");
            Console.WriteLine("Please enter your details:");
            Console.Write("Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Account Number: ");
             string aacountNumber = Console.ReadLine();

            Console.Write("Initial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Interest Rate: ");
            double intrestRate = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Amount to Deposit: ");
            double depositAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Amount to Withdraw: ");
            double withdrawAmount = double.Parse(Console.ReadLine());

            SavingsAccount savingsAccount = new SavingsAccount
            {
                CustomerId = id,
                CustomerName = name,
                AccountNumber = aacountNumber,
                Balance = balance,
                InitialBalance = balance,
                InterestRate = intrestRate,
            };
            savingsAccount.Deposit(depositAmount);
            savingsAccount.Withdraw(withdrawAmount);
            savingsAccount.DepositedAmount = depositAmount;
            savingsAccount.WithdrawnAmount = withdrawAmount;
            savingsAccount.DisplayAccountDetails();
        }
    }
}

      