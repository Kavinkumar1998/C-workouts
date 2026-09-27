using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Inheritance
{
    class Payment
    {
        public string PaymentId;
        public int Amount;
        public string CustomerName;

        public void DisplayPaymentDetails()
        {
            Console.WriteLine($"Payment Id: {PaymentId}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Amount: {Amount}");
        }
    }

    class CreditCardPayment : Payment
    {
        public string CardNumber;
        public void ProcessPayment()
        {
            // calculate fee and final amount
            double fee = processingFee();
            double finalAmount = Amount + fee;

            Console.WriteLine($"Payment Id: {PaymentId}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Payment Type: Credit Card");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Processing Fee: {fee:0.##}");
            Console.WriteLine($"Final Amount: {finalAmount:0.##}");
            Console.WriteLine("Payment Status: Successful");
        }
        public double processingFee()
        {
            return Amount * 0.02;
        }
    }
    class UPIpayment : Payment
    {
        public string UPIID;
        public void ProcessPayment()
        {
            double fee = processingFee();
            double finalAmount = Amount + fee;

            Console.WriteLine($"Payment Id: {PaymentId}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Payment Type: UPI");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Processing Fee: {fee:0.##}");
            Console.WriteLine($"Final Amount: {finalAmount:0.##}");
            Console.WriteLine("Payment Status: Successful");
        }
        public double processingFee()
        {
            return Amount * 0.01;
        }
    }
    internal class TaskInhertance3
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Payment Processing System");
            Console.Write("Please enter the Payment Id: ");
            string paymentId = Console.ReadLine();

            Console.Write("Please enter the Amount: ");
            int amount = int.Parse(Console.ReadLine());

            Console.Write("Please enter the Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Please select the Payment Method (1 for Credit Card, 2 for UPI): ");
            int paymentMethod = int.Parse(Console.ReadLine());

            if (paymentMethod == 1)
            {
                CreditCardPayment creditCardPayment = new CreditCardPayment
                {
                    PaymentId = paymentId,
                    Amount = amount,
                    CustomerName = customerName
                };

                Console.Write("Please enter the Card Number: ");
         
                creditCardPayment.CardNumber = Console.ReadLine();
                creditCardPayment.ProcessPayment();
            }
            else if (paymentMethod == 2)
            {
                UPIpayment upiPayment = new UPIpayment
                {
                    PaymentId = paymentId,
                    Amount = amount,
                    CustomerName = customerName
                };

                Console.Write("Please enter the UPI ID: ");
                upiPayment.UPIID = Console.ReadLine();
                upiPayment.ProcessPayment();
            }
            else
            {
                Console.WriteLine("Invalid Payment Method selected.");
            }
        }
    }
}
