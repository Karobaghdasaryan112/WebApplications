using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Infrastructure.Data.DataBase;

namespace S.P.WithCleanArchitecture.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private CleanAchitectureDbContext _dbContext { get; set; }

        public OrderItemRepository(CleanAchitectureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteEntityById(int EntityId)
        {
            var OrderItem = await GetEntityById(EntityId);

            if (OrderItem == null)
                return false;

            _dbContext.OrderItems.Remove(OrderItem);

            _dbContext.SaveChanges();

            return true;
        }

        public async Task<ICollection<OrderItem>> GetAll()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetEntityById(int entityId)
        {
            var OrderItem = await _dbContext.OrderItems.FirstOrDefaultAsync();

            return OrderItem;
        }

        public async Task UpdateEntity(OrderItem entity)
        {
            _dbContext.OrderItems.Update(entity);   

            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> CreateEntity(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
