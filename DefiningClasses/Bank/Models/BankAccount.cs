using System;

namespace Bank.Models
{
    public class BankAccount
    {
        private int id = 1;
        private decimal balance;

        public BankAccount()
        {
            id++;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Incorrect amount");
            }
            else
            {
                this.balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > this.balance)
            {
                Console.WriteLine("Not enough amount.");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Incorrect amount");
            }
            else
            {
                this.balance -= amount;
            }
        }

        public override string ToString()
        {
            return $"Account Id {this.id}, balance: {this.balance:F2}";
        }
    }
}
