using System.Collections.Generic;

namespace ProductsShop.Models
{
    public class User
    {
        public int Id { get; set; }

        public int? Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Product> ProductsBought { get; set; } = new List<Product>();

        public List<Product> ProductSold { get; set; } = new List<Product>();
    }
}
