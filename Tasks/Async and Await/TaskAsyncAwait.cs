using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Async_and_Await
{
    internal class TaskAsyncAwait
    {
        public class OrderResult
        {
            public int CustomerId { get; set; }
            public string OrderName { get; set; }
        }

        // Simulate taking order - here we just return values passed in Main
        public Task TakeOrder(int customerId, string order)
        {
            Console.WriteLine($"Customer {customerId}: Orders {order}");
            Console.WriteLine($"Waiter: Took order from Customer {customerId}");
            return Task.CompletedTask;
        }

        // Send to kitchen - create the prepare task and return it
        public Task<OrderResult> SendToKitchen(int customerId, string orderName, int prepMilliseconds)
        {
            Console.WriteLine($"Waiter: Sent {orderName} order to kitchen");
            return PrepareFoodAsync(customerId, orderName, prepMilliseconds);
        }

        // Kitchen prepares food asynchronously
        public async Task<OrderResult> PrepareFoodAsync(int customerId, string orderName, int prepMilliseconds)
        {
            Console.WriteLine($"Kitchen: {orderName} preparation started...");
            await Task.Delay(prepMilliseconds);
            Console.WriteLine($"Kitchen: {orderName} is ready");
            return new OrderResult { CustomerId = customerId, OrderName = orderName };
        }

        // Serve the food to customer
        public void ServeFood(OrderResult result)
        {
            Console.WriteLine($"Waiter: Serving {result.OrderName} to Customer {result.CustomerId}");
        }

        public static async Task Main()
        {
            var system = new TaskAsyncAwait();

            // Example scenario: 4 customers with different prep times
            var orders = new[] {
                (Customer:1, Name:"Biryani", TimeMs:5000),
                (Customer:2, Name:"Fried Rice", TimeMs:3000),
                (Customer:3, Name:"Pizza", TimeMs:7000),
                (Customer:4, Name:"Burger", TimeMs:2000)
            };

            var tasks = new List<Task<OrderResult>>();

            foreach (var o in orders)
            {
                await system.TakeOrder(o.Customer, o.Name);
                var prepTask = system.SendToKitchen(o.Customer, o.Name, o.TimeMs);

                // Attach a continuation to serve when ready without blocking the waiter
                prepTask.ContinueWith(t =>
                {
                    if (t.Status == TaskStatus.RanToCompletion)
                    {
                        system.ServeFood(t.Result);
                    }
                });

                tasks.Add(prepTask);

                // Waiter continues to next customer immediately (no await on prepTask)
            }

            // Wait for all preparations to complete before exiting
            await Task.WhenAll(tasks);
        }
    }
}
