using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.P.WithCleanArchitecture.Domain.Entities;


namespace S.P.WithCleanArchitecture.Infrastructure.Data.EntitiesConiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(u => u.Address);

            builder.OwnsOne(u => u.Money);

            builder
                .HasMany(U => U.Orders)
                .WithOne(O => O.User)
                .HasForeignKey(O => O.UserId)
                .IsRequired();
        }
    }
}
