using System;
using BillsPayment.Data;
using System.Collections.Generic;
using BillsPayment.Data.Models;
using System.Linq;

namespace BillsPayment.App
{
    public class Startup
    {
        public static void Main()
        {
            using (var db = new BillsPaymentDbContext())
            {
                SeedData(db);

                UserInfoById(db);
            }
        }

        private static void UserInfoById(BillsPaymentDbContext db)
        {
            var id = int.Parse(Console.ReadLine());

            var user = db
                .Users
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.Password,
                    PaymentMethods = u.PaymentMethods.Select(pm=>pm.Type)
                })
                .FirstOrDefault();

            Console.WriteLine($"{user.FirstName} {user.LastName} - {user.Email}, {user.Password}");

            foreach (var method in user.PaymentMethods)
            {
                Console.WriteLine(method);
            }
        }

        private static void SeedData(BillsPaymentDbContext db)
        {
            var bankAccounts = new List<BankAccount>
            {
                new BankAccount
                {
                    Balance = 100m,
                    BankName = "Shit Bank",
                    SwiftCode = "1234"
                },
                new BankAccount
                {
                    Balance = 340m,
                    BankName = "Shit Bank",
                    SwiftCode = "1234"
                },
                new BankAccount
                {
                    Balance = 2300m,
                    BankName = "Shit Bank",
                    SwiftCode = "1234"
                },
            };

            var creditCards = new List<CreditCard>
            {
                new CreditCard
                {
                    Limit = 1000m,
                    ExpirationDate= DateTime.Now,
                    MoneyOwed = 2000m
                }
            };

            var users = new List<User>
            {
                new User
                {
                    FirstName = "Pesho",
                    LastName = "Goshov",
                    Email = "Pesho@abv.bg",
                    Password = "1223"
                },
                new User
                {
                    FirstName = "Minka",
                    LastName = "Svirkata",
                    Email = "minka@abv.bg",
                    Password = "1111"
                },
                new User
                {
                    FirstName = "Vanq",
                    LastName = "Miteva",
                    Email = "v.miteva@gmail.bg",
                    Password = "abc"
                }
            };

            var paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod
                {
                    BankAccountId = 8,
                    CreditCardId=3,
                    Type = MethodType.BankAccount,
                    UserId = 7
                }
            };

            db
                .Users
                .AddRange(users);

            db
                .CreditCards
                .AddRange(creditCards);

            db
                .BankAccounts
                .AddRange(bankAccounts);

            db
                .PaymentMethods
                .AddRange(paymentMethods);

            db.SaveChanges();
        }
    }
}
