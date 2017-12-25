using BillsPayment.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPayment.Data.EntityConfiguration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasMany(ba => ba.PaymentMethods)
                .WithOne(pm => pm.BankAccount)
                .HasForeignKey(pm => pm.BankAccountId);
        }
    }
}
