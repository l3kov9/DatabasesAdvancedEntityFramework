using BillsPayment.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPayment.Data.EntityConfiguration
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder
                .HasMany(cc => cc.PaymentMethods)
                .WithOne(pm => pm.CreditCard)
                .HasForeignKey(pm => pm.CreditCardId);
        }
    }
}
