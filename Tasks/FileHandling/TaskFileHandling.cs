using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.FileHandling
{
    internal class TaskFileHandling
    {
        private const string FileName = "employees.txt";

        private class Employee
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string Salary { get; set; }

            public override string ToString()
            {
                return $"{Id},{Name},{Department},{Salary}";
            }

            public static bool TryParse(string line, out Employee emp)
            {
                emp = null;
                if (string.IsNullOrWhiteSpace(line)) return false;
                var parts = line.Split(',');
                if (parts.Length < 4) return false;
                emp = new Employee
                {
                    Id = parts[0].Trim(),
                    Name = parts[1].Trim(),
                    Department = parts[2].Trim(),
                    Salary = parts[3].Trim()
                };
                return true;
            }
        }

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== Employee File Management =====");
                Console.WriteLine("1. Create/Write Employees");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Add Employee");
                Console.WriteLine("4. Search Employee");
                Console.WriteLine("5. Update Employee");
                Console.WriteLine("6. Delete Employee");
                Console.WriteLine("7. File Information");
                Console.WriteLine("8. Delete File");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateWriteEmployees(); break;
                    case "2": DisplayEmployees(); break;
                    case "3": AddEmployee(); break;
                    case "4": SearchEmployee(); break;
                    case "5": UpdateEmployee(); break;
                    case "6": DeleteEmployee(); break;
                    case "7": ShowFileInformation(); break;
                    case "8": DeleteFileOption(); break;
                    case "9": return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private static string GetFilePath()
        {
            // store in current directory
            return Path.Combine(Directory.GetCurrentDirectory(), FileName);
        }

        private static void CreateWriteEmployees()
        {
            var path = GetFilePath();
            var sample = new List<string>
            {
                "101,Arun,IT,35000",
                "102,Divya,HR,30000",
                "103,Kumar,Finance,40000",
                "104,Priya,IT,45000",
                "105,Ravi,Sales,28000"
            };
            try
            {
                File.WriteAllLines(path, sample);
                Console.WriteLine($"File created/written: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing file: " + ex.Message);
            }
        }

        private static void DisplayEmployees()
        {
            var path = GetFilePath();
            if (!File.Exists(path))
            {
                Console.WriteLine("employees.txt does not exist. Create it first.");
                return;
            }
            try
            {
                var lines = File.ReadAllLines(path);
                Console.WriteLine("ID\tName\tDepartment\tSalary");
                foreach (var line in lines)
                {
                    if (Employee.TryParse(line, out var e))
                    {
                        Console.WriteLine($"{e.Id}\t{e.Name}\t{e.Department}\t{e.Salary}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

        private static void AddEmployee()
        {
            var path = GetFilePath();
            if (!File.Exists(path))
            {
                Console.WriteLine("employees.txt does not exist. Create it first.");
                return;
            }

            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(id)) { Console.WriteLine("Invalid ID."); return; }

            var all = File.ReadAllLines(path).ToList();
            if (all.Any(l => Employee.TryParse(l, out var ex) && ex.Id == id))
            {
                Console.WriteLine("Employee ID already exists.");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()?.Trim();
            Console.Write("Enter Department: ");
            string dept = Console.ReadLine()?.Trim();
            Console.Write("Enter Salary: ");
            string sal = Console.ReadLine()?.Trim();

            var record = $"{id},{name},{dept},{sal}";
            try
            {
                File.AppendAllLines(path, new[] { record });
                Console.WriteLine("Employee added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error appending file: " + ex.Message);
            }
        }

        private static void SearchEmployee()
        {
            var path = GetFilePath();
            if (!File.Exists(path)) { Console.WriteLine("employees.txt does not exist."); return; }
            Console.Write("Enter Employee ID to search: ");
            string id = Console.ReadLine()?.Trim();
            var lines = File.ReadAllLines(path);
            var found = lines.Select(l => { Employee.TryParse(l, out var e); return e; })
                             .FirstOrDefault(e => e != null && e.Id == id);
            if (found != null)
            {
                Console.WriteLine("Employee Found");
                Console.WriteLine($"ID: {found.Id}");
                Console.WriteLine($"Name: {found.Name}");
                Console.WriteLine($"Department: {found.Department}");
                Console.WriteLine($"Salary: {found.Salary}");
            }
            else
            {
                Console.WriteLine("Employee Not Found");
            }
        }

        private static void UpdateEmployee()
        {
            var path = GetFilePath();
            if (!File.Exists(path)) { Console.WriteLine("employees.txt does not exist."); return; }
            Console.Write("Enter Employee ID to update: ");
            string id = Console.ReadLine()?.Trim();
            var lines = File.ReadAllLines(path).ToList();
            bool updated = false;
            for (int i = 0; i < lines.Count; i++)
            {
                if (Employee.TryParse(lines[i], out var e) && e.Id == id)
                {
                    Console.WriteLine($"Current Department: {e.Department}");
                    Console.Write("New Department: ");
                    string nd = Console.ReadLine()?.Trim();
                    Console.WriteLine($"Current Salary: {e.Salary}");
                    Console.Write("New Salary: ");
                    string ns = Console.ReadLine()?.Trim();
                    e.Department = string.IsNullOrEmpty(nd) ? e.Department : nd;
                    e.Salary = string.IsNullOrEmpty(ns) ? e.Salary : ns;
                    lines[i] = e.ToString();
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine("Employee updated.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }

        private static void DeleteEmployee()
        {
            var path = GetFilePath();
            if (!File.Exists(path)) { Console.WriteLine("employees.txt does not exist."); return; }
            Console.Write("Enter Employee ID to delete: ");
            string id = Console.ReadLine()?.Trim();
            var lines = File.ReadAllLines(path).ToList();
            int before = lines.Count;
            lines = lines.Where(l => !(Employee.TryParse(l, out var e) && e.Id == id)).ToList();
            if (lines.Count < before)
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }

        private static void ShowFileInformation()
        {
            var path = GetFilePath();
            Console.WriteLine($"File: {path}");
            Console.WriteLine($"Exists: {File.Exists(path)}");
            if (File.Exists(path))
            {
                Console.WriteLine($"Creation Time: {File.GetCreationTime(path)}");
                Console.WriteLine($"Last Write Time: {File.GetLastWriteTime(path)}");
                Console.WriteLine($"Attributes: {File.GetAttributes(path)}");
            }
        }

        private static void DeleteFileOption()
        {
            var path = GetFilePath();
            if (!File.Exists(path)) { Console.WriteLine("File does not exist."); return; }
            Console.Write("Are you sure you want to delete the file? (y/n): ");
            var ans = Console.ReadLine();
            if (ans != null && ans.ToLower().StartsWith("y"))
            {
                File.Delete(path);
                Console.WriteLine("File deleted.");
            }
            else
            {
                Console.WriteLine("Delete cancelled.");
            }
        }
    }
}
