using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models;

namespace MyProject.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.Price)
            .HasPrecision(18,2);

        builder.HasMany(o => o.Items)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);
    }
}