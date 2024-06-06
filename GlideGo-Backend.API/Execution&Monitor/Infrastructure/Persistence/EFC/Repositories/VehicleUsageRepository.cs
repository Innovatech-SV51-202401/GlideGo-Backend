using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Execution_Monitor.Infrastructure.Persistence.EFC.Repositories;

public class VehicleUsageRepository : BaseRepository<VehicleUsage, Guid>, IVehicleUsageRepository
{
    private readonly AppDbContext _context;

    public VehicleUsageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VehicleUsage>> GetAllAsync()
    {
        return await _context.VehicleUsages.ToListAsync();
    }
}