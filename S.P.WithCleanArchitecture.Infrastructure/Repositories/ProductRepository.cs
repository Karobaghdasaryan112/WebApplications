using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Infrastructure.Data.DataBase;

namespace S.P.WithCleanArchitecture.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private CleanAchitectureDbContext _dbContext {  get; set; }

        public ProductRepository(CleanAchitectureDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteEntityById(int EntityId)
        {
            var Product = await GetEntityById(EntityId);

            if (Product == null)
                return false;

            _dbContext.Products.Remove(Product);

            _dbContext.SaveChanges();

            return true;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetEntityById(int entityId)
        {
            var Product =  await _dbContext.Products.FirstOrDefaultAsync();

            return Product;
        }

        public async Task UpdateEntity(Product entity)
        {
            _dbContext.Products.Update(entity);

            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> CreateEntity(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
