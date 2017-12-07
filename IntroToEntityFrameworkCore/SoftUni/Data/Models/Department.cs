using System.Collections.Generic;

namespace SoftUni.Data.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public int ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
