using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchitecture.Infrastructure.Data.DataBase
{
    public class CleanAchitectureDbContext : DbContext
    {

        public CleanAchitectureDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderEntityConfiguration).Assembly);
        }
    }
}
