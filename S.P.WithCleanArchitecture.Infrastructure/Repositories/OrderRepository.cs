using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Infrastructure.Data.DataBase;

namespace S.P.WithCleanArchitecture.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CleanAchitectureDbContext _dbContext { get; set; }

        public OrderRepository(CleanAchitectureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteEntityById(int EntityId)
        {
            var Order = await GetEntityById(EntityId);

            if (Order == null)
                return false;

            _dbContext.Orders.Remove(Order);

            _dbContext.SaveChanges();

            return true;
        }

        public async Task<ICollection<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetEntityById(int entityId)
        {
            var Order = await _dbContext.Orders.FirstOrDefaultAsync();

            return Order;
        }

        public async Task UpdateEntity(Order entity)
        {
            _dbContext.Orders.Update(entity);

            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> CreateEntity(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
