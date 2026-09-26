using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Inheritance
{
    class Employee2
    {
        public int EmployeeId;
        public string Name;
        public double BasicSalary;

    }
    class Payroll : Employee2
    {
        public double HRA(double basicSalary)
        {
            return basicSalary * 0.20;

        }
        public double DA(double basicSalary)
        {
            return basicSalary * 0.10;
        }

        public double GrossSalary(double basicSalary)
        {
            return basicSalary + HRA(basicSalary) + DA(basicSalary);
        }

        public void Display(int employeeId, string name, double basicSalary)
        {
            Console.WriteLine($"Employee ID: {employeeId}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Basic Salary: {basicSalary}");
            Console.WriteLine($"HRA: {HRA(basicSalary)}");
            Console.WriteLine($"DA: {DA(basicSalary)}");
            Console.WriteLine($"Gross Salary: {GrossSalary(basicSalary)}");
        }
    }
    internal class TaskInheritance
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Salary Calculation Based on Roles");
            Console.WriteLine("Please enter the id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the Role: ");
            double basicSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Bonus: ");
            Console.WriteLine();
            Payroll payroll = new Payroll
            {
                EmployeeId = id,
                Name = name,
                BasicSalary = basicSalary
            };
            payroll.Display(payroll.EmployeeId, payroll.Name, payroll.BasicSalary);
        }
    }
}
