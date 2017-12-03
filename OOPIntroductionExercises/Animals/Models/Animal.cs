using System;

namespace Animals.Models
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name can't be less than 2 symbols");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age can't be zero or negative");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            set
            {
                if(value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Gender must be Male or Female");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }
    }
}
