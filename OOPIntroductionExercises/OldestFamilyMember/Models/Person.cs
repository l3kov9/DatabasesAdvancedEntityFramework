namespace OldestFamilyMember.Models
{
    using System;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length can't be less than 3 characters");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age can not be zero or negative!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.name}, age: {this.age}";
        }
    }
}
