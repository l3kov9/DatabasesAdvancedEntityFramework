namespace People
{
    using People.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var personInfo = Console.ReadLine().Split();
                    var person = new Person(personInfo[0],
                                            personInfo[1],
                                            int.Parse(personInfo[2]),
                                            decimal.Parse(personInfo[3]));

                    persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var team = new Team("Losers");

            foreach (var person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First Team: {team.FirstTeam.Count}: {string.Join(", ", team.FirstTeam)}");
            Console.WriteLine($"Reserve Team: {team.ReserveTeam.Count}: {string.Join(", ", team.ReserveTeam)}");

            //var bonus = double.Parse(Console.ReadLine());

            //foreach (var person in persons)
            //{
            //    person.IncreaseSalary(bonus);
            //}

            //persons.ForEach(p => Console.WriteLine(p));

        }
    }
}
