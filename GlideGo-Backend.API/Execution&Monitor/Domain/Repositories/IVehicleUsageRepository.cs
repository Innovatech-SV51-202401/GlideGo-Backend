using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;

namespace GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;

public interface IVehicleUsageRepository
{
    Task<VehicleUsage> GetByIdAsync(Guid id);
    Task<IEnumerable<VehicleUsage>> GetAllAsync();
    Task AddAsync(VehicleUsage vehicleUsage);
    Task UpdateAsync(VehicleUsage vehicleUsage);
}