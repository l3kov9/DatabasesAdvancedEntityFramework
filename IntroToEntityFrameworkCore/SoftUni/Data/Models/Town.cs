using System;
using System.Collections.Generic;

namespace SoftUni.Data.Models
{
    public partial class Town
    {
        public int TownId { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
