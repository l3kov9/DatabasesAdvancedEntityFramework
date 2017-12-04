using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DbAppsDemo
{
    public class Startup
    {
        public static void Main()
        {
            var connection = new SqlConnection(
                    "Server=.;Database=SoftUni;Integrated Security=True");

            // connection.Open();
            // connection.Close();

            connection.Open();

            using (connection)
            {
                var command = new SqlCommand(
                    "Select FirstName, LastName, JobTitle From Employees", connection);

                SqlDataReader reader = command.ExecuteReader();

                var people = new List<Person>();

                while (reader.Read())
                {
                    var firstName = (string)reader["FirstName"];
                    var lastName = (string)reader["LastName"];
                    var jobTitle = (string)reader["JobTitle"];

                    var person = new Person(firstName, lastName, jobTitle);
                    people.Add(person);

                    // Console.WriteLine(person);
                }

                Console.WriteLine($"Total people: {people.Count}");

                var orderedPeopleByJobs = people
                    .GroupBy(p => p.JobTitle)
                    .OrderByDescending(p => p.Count());

                foreach (var orderedPeople in orderedPeopleByJobs)
                {
                    Console.WriteLine($"{orderedPeople.Key}: {orderedPeople.Count()} employees");

                    foreach (var person in orderedPeople)
                    {
                        Console.WriteLine($"    ---- {person.FirstName} {person.LastName}");
                    }
                }


                //var command = new SqlCommand("SELECT COUNT(*) FROM Towns", connection);
                //var employeeCount = (int)command.ExecuteScalar();
                //Console.WriteLine($"Total Employees: {employeeCount}");

                //// SqlDataReader data = command.ExecuteReader();

                //var addCommand = new SqlCommand("INSERT INTO Towns VALUES ('Plovdiv')",connection);
                //var rowsAffected = addCommand.ExecuteNonQuery();
                //Console.WriteLine($"Rows affected: {rowsAffected}");

            }
        }
    }
}
