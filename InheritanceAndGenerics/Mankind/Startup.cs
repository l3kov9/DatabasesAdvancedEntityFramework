using Mankind.Models;
using System;

namespace Mankind
{
    public class Startup
    {
        public static void Main()
        {
            var studentInfo = Console.ReadLine()
                .Split();
            var firstName = studentInfo[0];
            var lastName = studentInfo[1];
            var facultyNumber = studentInfo[2];
            try
            {
                var student = new Student(firstName, lastName, facultyNumber);
                Console.WriteLine(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var workerInfo = Console.ReadLine()
                .Split();
            var workerFirstName = workerInfo[0];
            var workerLastName = workerInfo[1];
            var workerWeekSalary = decimal.Parse(workerInfo[2]);
            var workHoursPerDay = double.Parse(workerInfo[3]);
            try
            {
                var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workHoursPerDay);
                Console.WriteLine(worker);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
