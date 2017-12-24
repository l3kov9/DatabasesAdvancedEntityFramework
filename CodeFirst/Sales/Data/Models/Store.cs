using System.Collections.Generic;

namespace Sales.Data.Models
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
