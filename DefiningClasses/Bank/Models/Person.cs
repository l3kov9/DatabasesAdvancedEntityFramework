using System.Collections.Generic;
using System.Linq;

namespace Bank.Models
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<BankAccount> Accounts { get; set; }

        public Person()
        {
            this.Accounts = new List<BankAccount>();
        }

        public Person(string name, int age)
            :this()
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name, int age, List<BankAccount> accounts)
            : this(name, age)
        {
            this.Accounts.AddRange(accounts);
        }

        public decimal GetBalance()
        {
            return this.Accounts.Sum(s=>s.Balance);
        }
    }
}
