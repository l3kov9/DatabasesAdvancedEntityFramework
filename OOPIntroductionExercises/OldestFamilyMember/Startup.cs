using OldestFamilyMember.Models;
using System;

namespace OldestFamilyMember
{
    public class Startup
    {
        public static void Main()
        {
            var totalPersons = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < totalPersons; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split();
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                family.AddMember(new Person(name, age));
            }

            Console.WriteLine(family.OldestFamilyMember());
        }
    }
}
