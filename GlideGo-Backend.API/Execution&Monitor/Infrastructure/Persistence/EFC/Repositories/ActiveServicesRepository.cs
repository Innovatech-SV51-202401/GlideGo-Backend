using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Execution_Monitor.Infrastructure.Persistence.EFC.Repositories;

public class ActiveServicesRepository : BaseRepository<ActiveServices, Guid>, IActiveServicesRepository
{
    private readonly AppDbContext _context;
    
    public ActiveServicesRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ActiveServices>> GetAllAsync()
    {
        return await _context.ActiveServices.ToListAsync();
    }
}