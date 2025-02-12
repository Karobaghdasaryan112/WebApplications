using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.P.WithCleanArchitecture.Domain.Entities;


namespace S.P.WithCleanArchitecture.Infrastructure.Data.EntitiesConiguration
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder
                .HasOne(O => O.Order)
                .WithMany(O => O.Items)
                .HasForeignKey(O => O.OrderId)
                .IsRequired();

            builder.Ignore(o => o.ItemPrice);
        }
    }
}
