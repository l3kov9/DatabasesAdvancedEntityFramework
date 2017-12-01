namespace Bank
{
    using Bank.Models;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var accounts = new Dictionary<int, BankAccount>();

            var commands = Console.ReadLine();

            while (true)
            {
                var tokens = commands.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "Create":
                        CreateAccount(tokens, accounts);
                        break;
                    case "Deposit":
                        accounts[int.Parse(tokens[1])].Deposit(decimal.Parse(tokens[2]));
                        break;
                    case "Withdraw":
                        accounts[int.Parse(tokens[1])].Withdraw(decimal.Parse(tokens[2]));
                        break;
                    case "Print":
                        Console.WriteLine(accounts[int.Parse(tokens[1])]);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void CreateAccount(string[] tokens, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(tokens[1]);

            if (!accounts.ContainsKey(id))
            {
                accounts[id] = new BankAccount();
            }
            else
            {
                Console.WriteLine("Account already exists.");
            }
        }
    }
}
