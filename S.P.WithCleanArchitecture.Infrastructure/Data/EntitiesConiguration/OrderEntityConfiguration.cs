using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.ValueObjects;
using S.P.WithCleanArchitecture.Domain.Enums;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(o => o.Address);

        builder
            .HasOne(O => O.User)
            .WithMany(U => U.Orders)
            .HasForeignKey(O => O.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(o => o.TotalPrice);

    }
}
