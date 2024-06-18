namespace GlideGo_Backend.API.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity, TKey>
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(TKey id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}