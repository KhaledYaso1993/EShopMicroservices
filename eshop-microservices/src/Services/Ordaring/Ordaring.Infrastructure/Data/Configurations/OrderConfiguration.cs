using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ordaring.Domain.Enum;
using Ordaring.Domain.Models;
using Ordaring.Domain.ValueObject;

namespace Ordaring.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
            orderId => orderId.Value,
            dbId => OrderId.Of(dbId)
            );

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .IsRequired();

        builder.ComplexProperty
            (x => x.OrderName, nameBuilduer =>
            {
                nameBuilduer.Property(n => n.Value)
                .HasColumnName(nameof(Order.OrderName))
                .HasMaxLength(100)
                .IsRequired();
            });


        builder.ComplexProperty
        (x => x.ShippingAddress, addressBuilduer =>
        {

            addressBuilduer.Property(a => a.FirstName)
              .HasMaxLength(50)
              .IsRequired();

            addressBuilduer.Property(a => a.LastName)
              .HasMaxLength(50)
              .IsRequired();

            addressBuilduer.Property(a => a.AddressLine)
              .HasMaxLength(180)
              .IsRequired();

            addressBuilduer.Property(a => a.ZipCode)
              .HasMaxLength(5)
              .IsRequired();
            addressBuilduer.Property(a => a.EmailAddress)
              .HasMaxLength(50);

            addressBuilduer.Property(a => a.Country)
              .HasMaxLength(50);

            addressBuilduer.Property(a => a.Status)
              .HasMaxLength(50);

        });


        builder.ComplexProperty
      (x => x.BillingAddress, addressBuilduer =>
      {

          addressBuilduer.Property(a => a.FirstName)
            .HasMaxLength(50)
            .IsRequired();

          addressBuilduer.Property(a => a.LastName)
            .HasMaxLength(50)
            .IsRequired();

          addressBuilduer.Property(a => a.AddressLine)
            .HasMaxLength(180)
            .IsRequired();

          addressBuilduer.Property(a => a.ZipCode)
            .HasMaxLength(5)
            .IsRequired();
          addressBuilduer.Property(a => a.EmailAddress)
            .HasMaxLength(50);

          addressBuilduer.Property(a => a.Country)
            .HasMaxLength(50);

          addressBuilduer.Property(a => a.Status)
            .HasMaxLength(50);

      });



        builder.ComplexProperty
      (x => x.Payment, paymentBuilduer =>
      {
          paymentBuilduer.Property(a => a.CardNumber)
              .HasMaxLength(24)
              .IsRequired();

          paymentBuilduer.Property(a => a.CardName)
             .HasMaxLength(50);

          paymentBuilduer.Property(a => a.Expiraton)
             .HasMaxLength(10);

          paymentBuilduer.Property(a => a.CVV)
             .HasMaxLength(3);

          paymentBuilduer.Property(a => a.PaymentMethod);


      });
        builder.Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(s => s.ToString(),
            dbstatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbstatus));

            ;


        builder.Property(o => o.TotalPrice);



    }
}
