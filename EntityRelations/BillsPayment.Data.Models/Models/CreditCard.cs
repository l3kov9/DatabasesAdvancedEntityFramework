using System;
using System.Collections.Generic;

namespace BillsPayment.Data.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    }
}
