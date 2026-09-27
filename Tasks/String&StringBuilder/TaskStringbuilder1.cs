using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.String_StringBuilder
{
    internal class TaskStringbuilder1
    {
        public static void Main()
        {
            Console.Write("Employee ID: ");
            string id = Console.ReadLine();

            Console.Write("Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Department: ");
            string dept = Console.ReadLine();

            Console.Write("Salary: ");
            double salary = 0;
            double.TryParse(Console.ReadLine(), out salary);

            Console.Write("City: ");
            string city = Console.ReadLine();

            double annual = salary * 12;

            var sb = new StringBuilder();
            sb.AppendLine(new string('=', 32));
            sb.AppendLine("       EMPLOYEE REPORT");
            sb.AppendLine(new string('=', 32));
            sb.AppendLine($"Employee ID   : {id}");
            sb.AppendLine($"Employee Name : {name}");
            sb.AppendLine($"Department    : {dept}");
            sb.AppendLine($"Monthly Salary: {salary:0}");
            sb.AppendLine($"Annual Salary : {annual:0}");
            sb.AppendLine($"City          : {city}");
            sb.AppendLine(new string('=', 32));

            Console.WriteLine(sb.ToString());
        }
    }
}
