using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPayment.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(25)]
        public string Password { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    }
}
