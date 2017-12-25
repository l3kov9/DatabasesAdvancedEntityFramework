using BillsPayment.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPayment.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.PaymentMethods)
                .WithOne(pm => pm.User)
                .HasForeignKey(pm => pm.UserId);
        }
    }
}
