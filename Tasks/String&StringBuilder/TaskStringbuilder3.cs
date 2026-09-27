using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.String_StringBuilder
{
    internal class TaskStringbuilder3
    {
        public static void Main()
        {
            const int items = 3;
            var names = new List<string>();
            var qtys = new List<int>();
            var prices = new List<double>();

            for (int i = 1; i <= items; i++)
            {
                Console.Write($"Product {i}: ");
                string name = Console.ReadLine() ?? string.Empty;
                names.Add(name);

                Console.Write("Quantity: ");
                int q = 0;
                int.TryParse(Console.ReadLine(), out q);
                qtys.Add(q);

                Console.Write("Price: ");
                double p = 0;
                double.TryParse(Console.ReadLine(), out p);
                prices.Add(p);
                Console.WriteLine();
            }

            var amounts = new List<double>();
            double subtotal = 0;
            for (int i = 0; i < items; i++)
            {
                double amt = qtys[i] * prices[i];
                amounts.Add(amt);
                subtotal += amt;
            }

            double gst = subtotal * 0.18;
            double grand = subtotal + gst;

            var sb = new StringBuilder();
            sb.AppendLine(new string('=', 40));
            sb.AppendLine("              INVOICE");
            sb.AppendLine(new string('=', 40));
            sb.AppendLine(string.Format("{0,-15}{1,8}{2,10}{3,10}", "Product", "Qty", "Price", "Amount"));
            sb.AppendLine(new string('-', 40));

            for (int i = 0; i < items; i++)
            {
                sb.AppendLine(string.Format("{0,-15}{1,8}{2,10:0}{3,10:0}", names[i], qtys[i], prices[i], amounts[i]));
            }

            sb.AppendLine(new string('-', 40));
            sb.AppendLine(string.Format("{0,-28}{1,12:0}", "Subtotal:", subtotal));
            sb.AppendLine(string.Format("{0,-28}{1,12:0}", "GST 18%:", gst));
            sb.AppendLine(new string('-', 40));
            sb.AppendLine(string.Format("{0,-28}{1,12:0}", "Grand Total:", grand));
            sb.AppendLine(new string('=', 40));

            Console.WriteLine(sb.ToString());
        }
    }
}
