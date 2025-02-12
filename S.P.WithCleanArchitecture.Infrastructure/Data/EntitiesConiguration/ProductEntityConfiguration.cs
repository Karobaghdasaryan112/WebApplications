using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Enums;
using S.P.WithCleanArchitecture.Domain.ValueObjects;


namespace S.P.WithCleanArchitecture.Infrastructure.Data.EntitiesConiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product> 
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(p => p.ProductPrice);

            builder
                .HasMany(P => P.OrderItems)
                .WithOne(O => O.Product)
                .HasForeignKey(O => O.ProductId)
                .IsRequired();
        }
    }
}
