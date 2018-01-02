namespace ProductsShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Data.EntityConfig;
    using ProductsShop.Models;

    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext() { }

        public ProductsShopContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(DbConfig.Configuration);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());

            builder.ApplyConfiguration(new ProductConfig());

            builder.ApplyConfiguration(new CategoryConfig());

            builder.ApplyConfiguration(new CategoryProductConfig());
        }
    }
}
