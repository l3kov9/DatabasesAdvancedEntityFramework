namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Data.Models;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new SoftUniContext())
            {
                // PrintAllEmployeesWithTheirJobAndSalary(db);

                // PrintAllEmployeeNamesWithMoreThan50000Salary(db);

                // EmployeesFromResearchAndDevelopment(db);

                // UpdateAddressToEmployee(db);

                // EmployeesWithProjectsBetween2001And2003(db);

                // PrintNameAndProjectsToEmployee147(db);

                // FindDepartmentsWithMoreThan5Employees(db);

                // IncreaseSalariesBy12Percents(db);

                // FindEmployeesStartingWithSa(db);

                // DeleteProjectById(db);

                DeleteTownByGivenName(db);
            }
        }

        private static void DeleteTownByGivenName(SoftUniContext db)
        {
            var townName = Console.ReadLine();

            var town = db
                .Towns
                .Where(t => t.Name == townName)
                .FirstOrDefault();

            if (town != null)
            {
                var addressFromTown = db
                    .Addresses
                    .Where(a => a.Town.Name == townName);

                foreach (var address in addressFromTown)
                {
                    db
                        .Employees
                        .Where(e => e.Address == address)
                        .ToList()
                        .ForEach(e => e.Address = null);

                    db
                        .Addresses
                        .Remove(address);
                }

                db
                    .Towns
                    .Remove(town);
            }

            db.SaveChanges();
        }

        private static void DeleteProjectById(SoftUniContext db)
        {
            var project = db
                .Projects
                .Find(2);

            var empProjects = db
                .EmployeesProjects
                .Where(ep => ep.ProjectId == project.ProjectId)
                .ToList();

            foreach (var empProj in empProjects)
            {
                db
                    .EmployeesProjects
                    .Remove(empProj);
            }

            db
                .Projects
                .Remove(project);

            db.SaveChanges();
        }

        private static void FindEmployeesStartingWithSa(SoftUniContext db)
        {
            db
                .Employees
                .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.Name)
                .ToList()
                .ForEach(e => Console.WriteLine($"{e.Name} - {e.JobTitle} - {e.Salary:f2}"));
        }

        private static void IncreaseSalariesBy12Percents(SoftUniContext db)
        {
            db
                .Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .ToList()
                .ForEach(e => e.Salary *= 1.12m);

            db.SaveChanges();
        }

        private static void FindDepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            var result = db
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    Manager = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Employees = d.Employees.Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        e.JobTitle
                    })
                });

            foreach (var department in result)
            {
                Console.WriteLine($"{department.Name} - {department.Manager}");

                foreach (var employee in department.Employees)
                {
                    Console.WriteLine($"    ***** {employee.Name} - {employee.JobTitle}");
                }

                Console.WriteLine(new string('*', 20));
            }
        }

        private static void PrintNameAndProjectsToEmployee147(SoftUniContext db)
        {
            var result = db
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => ep.Project.Name)
                })
                .FirstOrDefault();

            Console.WriteLine($"{result.Name} - {result.JobTitle}");

            foreach (var project in result.Projects.OrderBy(p => p))
            {
                Console.WriteLine(project);
            }
        }

        private static void EmployeesWithProjectsBetween2001And2003(SoftUniContext db)
        {
            var result = db
                .Employees
                .Where(e => e.EmployeesProjects.Any(
                    ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.ManagerId,
                    EmployeesProjects = e.EmployeesProjects.Select(ep => new
                    {
                        ep.Project.Name,
                        ep.Project.StartDate,
                        ep.Project.EndDate
                    })
                })
                .ToList()
                .Take(30);

            foreach (var emp in result)
            {
                var manager = db
                    .Employees
                    .Where(e => e.EmployeeId == emp.ManagerId)
                    .FirstOrDefault();

                Console.WriteLine($"{emp.FirstName} {emp.LastName} - Manager: {manager.FirstName} {manager.LastName}");

                foreach (var project in emp.EmployeesProjects)
                {
                    Console.WriteLine($"  --{project.Name} ,{project.StartDate:M/d/yyyy h: mm:ss tt} - {project.EndDate:M/d/yyyy h: mm:ss tt}");
                }
            }
        }

        private static void UpdateAddressToEmployee(SoftUniContext db)
        {
            var address = new Address
            {
                AddressText = "Test street 123",
                TownId = 4
            };

            db
                .Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault()
                .Address = address;

            db.SaveChanges();

            var result = db
                .Employees
                .Where(e => e.LastName == "Nakov")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Street = e.Address.AddressText
                })
                .FirstOrDefault();

            Console.WriteLine($"{result.FirstName} {result.LastName} - {result.Street}");

        }

        private static void PrintAllEmployeesWithTheirJobAndSalary(SoftUniContext db)
        {
            db
                                .Employees
                                .OrderBy(e => e.EmployeeId)
                                .Select(e => new
                                {
                                    e.FirstName,
                                    e.MiddleName,
                                    e.LastName,
                                    e.JobTitle,
                                    e.Salary
                                })
                                .ToList()
                                .ForEach(e => Console.WriteLine(
                                    $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));
        }

        private static void PrintAllEmployeeNamesWithMoreThan50000Salary(SoftUniContext db)
        {
            db
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => e.FirstName)
                .OrderBy(e => e)
                .ToList()
                .ForEach(e => Console.WriteLine(e));
        }

        private static void EmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            db
                .Employees
                .Where(e => e.JobTitle.Contains("Research and Development"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList()
                .ForEach(e => Console.WriteLine(
                    $"{e.FirstName} {e.LastName} from {e.JobTitle} - ${e.Salary:f2}"));
        }
    }
}
