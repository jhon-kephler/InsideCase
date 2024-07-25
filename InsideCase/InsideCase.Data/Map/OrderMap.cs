using InsideCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsideCase.Data.Map
{
    public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> builder)
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
                .Property(b => b.Total_Amount)
                .HasColumnType("integer")
                .HasColumnName("total_amount")
                .IsRequired();

            builder
                .Property(b => b.Total_Price)
                .HasColumnType("integer")
                .HasColumnName("total_price")
                .IsRequired();

            builder
                .Property(b => b.Removed)
                .HasColumnType("boolean")
                .HasColumnName("removed")
                .IsRequired();

            builder
                .Property(b => b.Closed)
                .HasColumnType("boolean")
                .HasColumnName("closed")
                .IsRequired();

            builder
                .Property(b => b.Created_At)
                .HasColumnType("TIMESTAMPTZ")
                .HasColumnName("created_at")
                .IsRequired();

            builder
                .HasMany(b => b.ProductOrder)
                .WithOne(a => a.Order)
                .HasForeignKey(b => b.Order_Id);
        }
    }
}
