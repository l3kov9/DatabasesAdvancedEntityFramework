using System;

namespace Mankind.Models
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if(value<1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal GetMoneyPerHour()
        {
            return this.weekSalary / ((decimal)this.workHoursPerDay*5);
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Week salary: {this.weekSalary:f2}" + Environment.NewLine +
                $"Hours per day: {this.workHoursPerDay}" + Environment.NewLine +
                $"Salary per hour: {this.GetMoneyPerHour():f2}";
        }
    }
}
