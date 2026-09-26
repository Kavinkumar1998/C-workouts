using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Constructor
{
    class Employee
    {
         public string Name;
         public int id;
         public string Department;
         public double Salary;

        // Default Constructor
        public Employee()
        {
            Console.WriteLine("Default Constructor Called");
            id=0;
            Name="";
            Department="";
            Salary= 0;

        }
        // Parameterized Constructor
        public Employee(string name, int Id, string department, double salary)
        {
            Console.WriteLine("Parameterized Constructor Called");
            Name = name;
            id = Id;
            Department = department;
            Salary = salary;
        }
        // Copy Constructor
        public Employee(Employee emp)
        {
            Console.WriteLine("Copy Constructor Called");
            Name = emp.Name;
            id = emp.id;
            Department = "Management";
            Salary = emp.Salary + 4000 ;
        }

        public void Display()
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }
    internal class TaskConstructor
    {
     public  static void Main()
        {
            Employee emp = new Employee();
            emp.Display();
            Employee emp1 = new Employee("Arun",101,"IT",40000);
            emp1.Display();
            Employee emp2 = new Employee(emp1);
            emp2.Display();
            emp1.Display();

        }
    }
}
