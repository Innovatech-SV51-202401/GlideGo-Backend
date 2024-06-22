using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Design.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    
    public async Task<IEnumerable<Vehicle>> FindAllByIdOwner(int idOwner)
    {
        return await Context.Set<Vehicle>().Where(f => f.IdOwner == idOwner).ToListAsync();
    }

    public async Task<Vehicle?> FindByIdVehicle(int idVehicle)
    {
        return await Context.Set<Vehicle>().FirstOrDefaultAsync(f=>f.IdVehicle == idVehicle); 
    }

    public async Task<Vehicle?> FindByIdVehicleAndOwner(int idVehicle, int idOwner)
    {
        return await Context.Set<Vehicle>().FirstOrDefaultAsync(f=>f.IdVehicle == idVehicle && f.IdOwner == idOwner);
    }
}