using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordaring.Domain.Models;
using Ordaring.Domain.ValueObject;

namespace Ordaring.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion
            (
            orderItemId => orderItemId.Value,
            dbId => OrderItemId.Of(dbId)

            );
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId);
        builder.Property(propertyExpression: x => x.Quentity).IsRequired();
        builder.Property(propertyExpression: x => x.Price).IsRequired();


    }
}