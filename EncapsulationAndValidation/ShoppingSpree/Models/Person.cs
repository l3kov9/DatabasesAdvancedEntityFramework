using System;
using System.Collections.Generic;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.name = name;
            this.money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return this.products; }
        }

        public void BuyProduct(Product product)
        {
            var price = product.Price;
            if (this.money < price)
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} bought {product.Name}");
                this.money -= price;
                this.products.Add(product);
            }
        }
    }
}
