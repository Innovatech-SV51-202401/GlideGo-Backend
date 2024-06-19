using ACME.LearningCenterPlatform.API.Design.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.executionandmonitor.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Design.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    public new async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await Context.Set<Vehicle>().ToListAsync();
    }

    public new async Task<Vehicle?> GetByIdAsync(int id)
    {
        return await Context.Set<Vehicle>().FindAsync(id);
    }

    public new async Task AddAsync(Vehicle vehicle)
    {
        await Context.Set<Vehicle>().AddAsync(vehicle);
        await Context.SaveChangesAsync();
    }
}