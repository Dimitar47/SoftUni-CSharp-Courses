using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];

                var newEmployee = new Employee();
                newEmployee.Name = name;
                newEmployee.Salary = salary;
                newEmployee.Department = department;

                employees.Add(newEmployee);
                departments.Add(department);
            }
            //remove duplicates departments
            departments = departments.Distinct().ToList();

            //find Department with Highest Average Salary
            string departmentHighestAve = "";
            double highestAveSalary = double.MinValue;

            foreach (string department in departments)
            {
                double aveSalary = employees.Where(e => e.Department == department).Select(e => e.Salary).Average();
                if (aveSalary > highestAveSalary)
                {
                    departmentHighestAve = department;
                    highestAveSalary = aveSalary;
                }
            }

            //Printing results
            Console.WriteLine($"Highest Average Salary: {departmentHighestAve}");

            foreach (var employee in employees.Where(e => e.Department == departmentHighestAve).OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}


