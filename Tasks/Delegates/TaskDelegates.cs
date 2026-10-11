using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Delegates
{
    internal class TaskDelegates
    {
        public class SalaryContext
        {
            public double Basic { get; set; }
            public double HRA { get; set; }
            public double Travel { get; set; }
            public double PF { get; set; }
            public double Tax { get; set; }

            public double AfterAllowances { get; set; }
            public double AfterDeductions { get; set; }
            public double FinalMonthly { get; set; }
        }

        public delegate void SalaryAction(SalaryContext ctx);

        public static void AddAllowances(SalaryContext ctx)
        {
           
            ctx.AfterAllowances = ctx.Basic + ctx.HRA + ctx.Travel;
        }

        public static void ApplyDeductions(SalaryContext ctx)
        {
            
            ctx.AfterDeductions = ctx.AfterAllowances - ctx.PF - ctx.Tax;
            ctx.FinalMonthly = ctx.AfterDeductions;
        }

        public static void Main()
        {
            Console.Write("Enter Basic Salary: ");
            var input = Console.ReadLine();
            double basic =  double.Parse(input);

            Console.Write("Enter HRA : ");
            input = Console.ReadLine();
            double hra = double.Parse(input);

            Console.Write("Enter Travel Allowance: ");
            input = Console.ReadLine();
            double travel = double.Parse(input);

            Console.Write("Enter PF  ");
            input = Console.ReadLine();
            double pf =  double.Parse(input);

            Console.Write("Enter Tax : ");
            input = Console.ReadLine();
            double tax =  double.Parse(input);

            var ctx = new SalaryContext
            {
                Basic = basic,
                HRA = hra,
                Travel = travel,
                PF = pf,
                Tax = tax
            };

           
            SalaryAction action = AddAllowances;
            action += ApplyDeductions;

            
            action(ctx);

            double annual = ctx.FinalMonthly * 12;

            Console.WriteLine();
            Console.WriteLine($"Basic Salary: {ctx.Basic:0}");
            Console.WriteLine($"After Allowances: {ctx.AfterAllowances:0}");
            Console.WriteLine($"After Deductions: {ctx.AfterDeductions:0}");
            Console.WriteLine($"Final Monthly Salary: {ctx.FinalMonthly:0}");
            Console.WriteLine($"Annual CTC: {annual:0}");
        }
    }
}
