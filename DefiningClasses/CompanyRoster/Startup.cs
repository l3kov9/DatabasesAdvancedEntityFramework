using CompanyRoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class Startup
    {
        public static void Main()
        {
            var totalEmployees = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < totalEmployees; i++)
            {
                var tokens = Console.ReadLine()
                    .Split();
                var name = tokens[0];
                var currentSalary = decimal.Parse(tokens[1]);
                var position = tokens[2];
                var department = tokens[3];
                var employee = new Employee(name, currentSalary, position, department);

                if (tokens.Length > 4)
                {
                    var result = 0;
                    if (int.TryParse(tokens[4], out result))
                    {
                        var age = int.Parse(tokens[4]);
                        employee.Age = age;
                    }
                    else
                    {
                        var email = tokens[4];
                        employee.Email = email;
                        if (tokens.Length > 5)
                        {
                            var age = int.Parse(tokens[5]);
                            employee.Age = age;
                        }
                    }
                }

                employees.Add(employee);
            }

            var maxAvgDepSalary = employees
                .GroupBy(e => e.Department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.Salary),
                    Employees = e.OrderByDescending(emp => emp.Salary)
                })
                .OrderByDescending(e => e.AverageSalary);

            Console.WriteLine($"Highest Average Salary : {maxAvgDepSalary.FirstOrDefault().Department}");
            maxAvgDepSalary
                .ToList()
                .ForEach(e => Console.WriteLine($"{e.Department} {e.AverageSalary}"));
            Console.WriteLine();

            employees
                .OrderByDescending(e => e.Salary)
                .ToList()
                .ForEach(e => Console.WriteLine(e));
        }
    }
}
