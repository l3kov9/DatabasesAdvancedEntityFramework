using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var peopleInfos = Console.ReadLine()
                .Split(new[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            var productInfos = Console.ReadLine()
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            foreach (var peopleInfo in peopleInfos)
            {
                var info = peopleInfo
                    .Split('=');
                var name = info[0];
                var money = decimal.Parse(info[1]);
                var person = new Person(name, money);

                people.Add(person);
            }

            foreach (var productInfo in productInfos)
            {
                var info = productInfo
                    .Split('=');

                var name = info[0];
                var price = decimal.Parse(info[1]);
                var product = new Product(name, price);

                products.Add(product);
            }

            while (true)
            {
                var commands = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "END")
                {
                    break;
                }

                var personName = commands[0];
                var productName = commands[1];

                var person = people
                    .Where(p => p.Name == personName)
                    .FirstOrDefault();

                var product = products
                    .Where(pr => pr.Name == productName)
                    .FirstOrDefault();

                person.BuyProduct(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Count)}");
            }
        }
    }
}
