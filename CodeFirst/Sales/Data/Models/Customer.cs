using System.Collections.Generic;

namespace Sales.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string CreditCardNumber { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
