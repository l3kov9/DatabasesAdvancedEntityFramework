using System.Collections.Generic;

namespace SoftUni.Data.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressText { get; set; }
        public int? TownId { get; set; }

        public Town Town { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
