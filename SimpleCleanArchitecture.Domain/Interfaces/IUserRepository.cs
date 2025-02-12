using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchitecture.Domain.Interfaces
{
    public interface IUserRepository : ICoreRepository<User>
    {
         Task<User> GetUserByUserName(string UserName);
    }
}
