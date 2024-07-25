using InsideCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsideCase.Data.Map
{
    public class ProductOrderMap
    {
        public ProductOrderMap(EntityTypeBuilder<ProductOrder> builder)
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
                .Property(b => b.Order_Id)
                .HasColumnType("integer")
                .HasColumnName("order_id")
                .IsRequired();

            builder
                .Property(b => b.Product_Id)
                .HasColumnType("integer")
                .HasColumnName("product_id")
                .IsRequired();

            builder
                .Property(b => b.Amount)
                .HasColumnType("integer")
                .HasColumnName("amount")
                .IsRequired();

            builder
                .Property(b => b.Created_At)
                .HasColumnType("TIMESTAMPTZ")
                .HasColumnName("created_at")
                .IsRequired();

            builder
                .HasOne(b => b.Order)
                .WithMany(v => v.ProductOrder)
                .HasForeignKey(b => b.Order_Id)
                .HasPrincipalKey(v => v.Id);

            builder
                .HasOne(b => b.Product)
                .WithOne(v => v.ProductOrder)
                .HasForeignKey<ProductOrder>(b => b.Product_Id)
                .HasPrincipalKey<Product>(v => v.Id);
        }
    }
}
