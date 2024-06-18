using GlideGo_Backend.API.Shared.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity, TKey>(AppDbContext context) : IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public async Task<TEntity?> FindByIdAsync(TKey id) => await Context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
}