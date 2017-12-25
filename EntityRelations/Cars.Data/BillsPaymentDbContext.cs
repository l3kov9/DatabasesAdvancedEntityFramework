using BillsPayment.Data.DbConfiguration;
using BillsPayment.Data.EntityConfiguration;
using BillsPayment.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BillsPayment.Data
{
    public class BillsPaymentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public object Where { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new BankAccountConfiguration());

            builder.ApplyConfiguration(new CreditCardConfiguration());
        }
    }
}
