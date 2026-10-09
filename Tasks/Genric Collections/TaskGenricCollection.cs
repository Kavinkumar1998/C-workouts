using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Genric_Collections
{
    internal class TaskGenricCollection
    { 
        public void TaskGenricCollection1()
        {
            List<int> EmpId = new List<int>();
            EmpId.AddRange(new int[] { 101, 102, 103, 104, 105 });
        }

        public static void Main()
        {
            // List<int>
            Console.WriteLine("--- List<int> ---");
            var empIds = new List<int> { 101, 102, 103, 104, 105 };
            foreach (var id in empIds)
                Console.WriteLine(id);

            Console.WriteLine();
            Console.WriteLine("After removing 103:");
            empIds.Remove(103);
            foreach (var id in empIds)
                Console.WriteLine(id);

            Console.WriteLine();
            // Dictionary<int,string>
            Console.WriteLine("--- Dictionary<int, string> ---");
            var employees = new Dictionary<int, string>
            {
                {101, "Arun"},
                {102, "Priya"},
                {103, "Kumar"},
                {104, "Divya"},
                {105, "Rahul"}
            };
            foreach (var kv in employees)
                Console.WriteLine($"{kv.Key} - {kv.Value}");

            Console.WriteLine();
            // HashSet<string>
            Console.WriteLine("--- HashSet<string> ---");
            var depts = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            depts.Add("IT");
            depts.Add("HR");
            depts.Add("Finance");
            depts.Add("Sales");
            depts.Add("IT"); // duplicate
            foreach (var d in depts)
                Console.WriteLine(d);

            Console.WriteLine();
            // Queue<string>
            Console.WriteLine("--- Queue<string> ---");
            var customers = new Queue<string>();
            customers.Enqueue("Arun");
            customers.Enqueue("Priya");
            customers.Enqueue("Kumar");
            customers.Enqueue("Divya");
            while (customers.Count > 0)
            {
                var c = customers.Dequeue();
                Console.WriteLine($"Processing: {c}");
            }

            Console.WriteLine();
            // Stack<string>
            Console.WriteLine("--- Stack<string> ---");
            var pages = new Stack<string>();
            pages.Push("Login");
            pages.Push("Dashboard");
            pages.Push("Employee List");
            pages.Push("Employee Details");
            Console.WriteLine($"Current Page: {pages.Pop()}"); // last opened
            Console.WriteLine($"Previous Page: {pages.Peek()}");

            Console.WriteLine();
            // SortedList<int,double>
            Console.WriteLine("--- SortedList<int, double> ---");
            var salaries = new SortedList<int, double>
            {
                {103, 45000},
                {101, 35000},
                {102, 40000}
            };
            foreach (var kv in salaries)
                Console.WriteLine($"{kv.Key} - {kv.Value:0}");
        }
    }
}
