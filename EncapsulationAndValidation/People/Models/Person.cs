using System;

namespace People.Models
{
    public class Person
    {
        private const int MinNameLength = 3;
        private const decimal MinSalary = 460;
        private string firstName;
        private string lastName;
        private decimal salary;
        private int age;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length <= MinNameLength)
                {
                    throw new ArgumentException($"First name cannot be less than {MinNameLength} symbols");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length <= MinNameLength)
                {
                    throw new ArgumentException($"Last name cannot be less than {MinNameLength} symbols");
                }

                this.lastName = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva");
                }

                this.salary = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or negative integer");
                }

                this.age = value;
            }
        }

        public void IncreaseSalary(double percentBonus)
        {
            if (this.age < 30)
            {
                percentBonus /= 2;
            }

            this.salary += this.salary * (decimal)percentBonus / 100;
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} is a {this.age} years old. Salary: {this.salary:f2}";
        }
    }
}
