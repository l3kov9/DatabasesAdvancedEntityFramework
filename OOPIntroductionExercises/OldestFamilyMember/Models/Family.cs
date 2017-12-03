using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember.Models
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person OldestFamilyMember()
        {
            return this.people
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
    }
}
