using InsideCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace InsideCase.Data
{
    public class InsideCaseContext : DbContext
    {
        public InsideCaseContext(DbContextOptions<InsideCaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var asembly = typeof(InsideCaseContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asembly);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Total_Price).HasColumnName("total_price");
                entity.Property(e => e.Total_Amount).HasColumnName("total_amount");
                entity.Property(e => e.Removed).HasColumnName("removed");
                entity.Property(e => e.Closed).HasColumnName("closed");
                entity.Property(e => e.Created_At).HasColumnName("created_at");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name_Product).HasColumnName("name_product");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Removed).HasColumnName("removed");
                entity.Property(e => e.Stock).HasColumnName("stock");
                entity.Property(e => e.Created_At).HasColumnName("created_at");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.ToTable("Product_Order");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Product_Id).HasColumnName("product_id");
                entity.Property(e => e.Order_Id).HasColumnName("order_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.Created_At).HasColumnName("created_at");
            });

            modelBuilder
                .Entity<Order>()
                .Property(p => p.Created_At)
                .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Created_At)
                .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder
                .Entity<ProductOrder>()
                .Property(p => p.Created_At)
                .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Order>()
                        .HasMany(d => d.ProductOrder)
                        .WithOne(o => o.Order)
                        .HasForeignKey(o => o.Order_Id);

            modelBuilder.Entity<Product>()
                        .HasOne(d => d.ProductOrder)
                        .WithOne(o => o.Product)
                        .HasForeignKey<ProductOrder>(o => o.Product_Id);
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOrder> Product_Order { get; set; }
    }
}
