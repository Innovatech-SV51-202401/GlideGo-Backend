using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using GlideGo_Backend.API.Shared.Domain.Repositories;


namespace GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;

public interface IVehicleUsageRepository : IBaseRepository<VehicleUsage>
{
    Task<IEnumerable<VehicleUsage>> GetAllAsync();
}