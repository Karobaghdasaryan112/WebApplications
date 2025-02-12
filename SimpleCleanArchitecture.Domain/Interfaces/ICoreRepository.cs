
namespace S.P.WithCleanArchitecture.Domain.Interfaces
{
    public interface ICoreRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntityById(int entityId);
        Task<bool> DeleteEntityById(int EntityId);
        Task UpdateEntity(TEntity entity);
        Task<ICollection<TEntity>> GetAll();

        Task<bool> CreateEntity(TEntity entity);
    }
}
