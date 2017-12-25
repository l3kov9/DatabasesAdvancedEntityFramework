using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPayment.Data.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankName { get; set; }

        [MaxLength(20)]
        public string SwiftCode { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    }
}
