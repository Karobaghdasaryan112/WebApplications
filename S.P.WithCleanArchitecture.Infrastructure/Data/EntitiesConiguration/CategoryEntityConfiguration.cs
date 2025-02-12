using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.P.WithCleanArchitecture.Domain.Entities;


namespace S.P.WithCleanArchitecture.Infrastructure.Data.EntitiesConiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

        }
    }
}
