using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Infrastructure.Data.DataBase;

namespace S.P.WithCleanArchitecture.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private CleanAchitectureDbContext _dbContext { get; set; }

        public CategoryRepository(CleanAchitectureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteEntityById(int EntityId)
        {
            var Category = await GetEntityById(EntityId);

            if (Category == null)
                return false;

            _dbContext.Categories.Remove(Category);

            _dbContext.SaveChanges();

            return true;
        }

        public async Task<ICollection<Category>> GetAll()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetEntityById(int entityId)
        {
            var Category = await _dbContext.Categories.FirstOrDefaultAsync();

            return Category;
        }

        public async Task UpdateEntity(Category entity,int Id)
        {
            _dbContext.Categories.Update(entity);

            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> CreateEntity(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryByName(string Name)
        {
            var Category = await _dbContext.Categories.Where(Category => Category.CategoryName == Name).Include(Category => Category.Products).FirstOrDefaultAsync();

            return Category;
        }
    }
}
