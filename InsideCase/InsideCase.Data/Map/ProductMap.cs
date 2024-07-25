using InsideCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsideCase.Data.Map
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("id");

            builder
                .Property(b => b.Id)
                .HasColumnType("integer")
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(b => b.Name_Product)
                .HasColumnType("varchar")
                .HasColumnName("name_product")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(b => b.Price)
                .HasColumnType("numeric")
                .HasColumnName("price")
                .IsRequired();

            builder
                .Property(b => b.Stock)
                .HasColumnType("NUMERIC")
                .HasColumnName("stock");

            builder
                .Property(b => b.Removed)
                .HasColumnType("boolean")
                .HasColumnName("removed")
                .IsRequired();

            builder
                .Property(b => b.Created_At)
                .HasColumnType("TIMESTAMPTZ")
                .HasColumnName("created_at")
                .IsRequired();

            builder
                .HasOne(b => b.ProductOrder)
                .WithOne(a => a.Product)
                .HasForeignKey<ProductOrder>(b => b.Product_Id);
        }
    }
}