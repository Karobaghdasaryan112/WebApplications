using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Infrastructure.Data.DataBase;

namespace S.P.WithCleanArchitecture.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CleanAchitectureDbContext _dbContext {  get; set; }
        public UserRepository(CleanAchitectureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetEntityById(int entityId)
        {
            return await _dbContext.Users.Where(U => U.Id == entityId).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteEntityById(int EntityId)
        {
            var User = await GetEntityById(EntityId);

            if (User == null)
                return false;

            _dbContext.Users.Remove(User);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task UpdateEntity(User updateEntity, int id)
        {
            _dbContext.Update(updateEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<bool> CreateEntity(User entity)
        {
            await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUserByUserName(string UserName)
        {
            return await _dbContext.Users.Where(U => U.UserName == UserName).FirstOrDefaultAsync();
        }
    }
}
