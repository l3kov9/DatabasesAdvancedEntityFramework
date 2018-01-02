using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsShop.Models;

namespace ProductsShop.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.ProductsBought)
                .WithOne(pr => pr.Buyer)
                .HasForeignKey(pr => pr.BuyerId);

            builder
                .HasMany(u => u.ProductSold)
                .WithOne(pr => pr.Seller)
                .HasForeignKey(pr => pr.SellerId);
        }
    }
}
