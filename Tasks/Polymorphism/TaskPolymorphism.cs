using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Polymorphism
{
    class SalaryCalculation
    {
        public string Name;
        public string Role;
        public double BasicSalary;
        public double Bonus;
        public double Allowance;

        //Meathod Overloading
        public double CalculateSalary(double basicSalary)
        {
            return basicSalary;

        }

        public double CalculateSalary(double basicSalary, double bonus)
        {
            return basicSalary + bonus;
        }

        public double CalculateSalary(double basicSalary, double bonus, double allowance)
        {
            return basicSalary + bonus + allowance;
        }

        public virtual void Display(string name, string role,double basicSalary,double bonus, double allowance)
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Role: {role}");
            Console.WriteLine($"Basic Salary: {CalculateSalary(basicSalary)}");
            Console.WriteLine($"Basic  with bonus: {CalculateSalary(basicSalary,bonus)}");
            Console.WriteLine($"Basic Salary with Bonus and Allowance: {CalculateSalary(basicSalary,bonus,allowance)}");
        }

    }
    //Method Overriding
    class Developer :SalaryCalculation
    {
        public override void Display(string name, string role,double basicSalary,double bonus, double allowance) {
            SalaryCalculation dev = new Developer {
                Role = "Developer",
                BasicSalary = basicSalary + 20000,
                Bonus = bonus + 5000,
                Allowance = allowance + 2000,
                                                  };
            base.Display(name, dev.Role, dev.BasicSalary, dev.Bonus, dev.Allowance);
        }
    }

    class Trainer : SalaryCalculation
    {
        public override void Display(string name, string role, double basicSalary, double bonus, double allowance)
        {
            SalaryCalculation trainer = new Trainer {
                Role = "Trainer",
                BasicSalary = basicSalary + 10000,
                Bonus = bonus + 3000,
                Allowance = allowance + 1000,
                                                     }; 
            base.Display(name, trainer.Role, trainer.BasicSalary, trainer.Bonus, trainer.Allowance);
        }
    }

    internal class TaskPolymorphism
    {
       public static void Main()
        {
            Console.WriteLine("Welcome to Salary Calculation Based on Roles");
            Console.WriteLine("Please enter the Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the Role: ");
            string role = Console.ReadLine();
            Console.WriteLine("Please enter the Basic Salary: ");
            double basicSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Bonus: ");
            double bonus = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Allowance: ");
            double allowance = double.Parse(Console.ReadLine());

            SalaryCalculation Salary;
            if (role.ToLower() == "developer")
            {
                Salary = new Developer();
            }
            else if (role.ToLower() == "trainer")
            {
                Salary = new Trainer();
            }
            else
            {
                Salary = new SalaryCalculation();
            }

            Salary.Display(name, role, basicSalary, bonus, allowance);
        }
    }
}
