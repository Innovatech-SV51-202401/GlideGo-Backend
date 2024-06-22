using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Shared.Domain.Repositories;

namespace GlideGo_Backend.API.Design.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> FindAllByIdOwner(int idOwner);
    Task<Vehicle?> FindByIdVehicle(int idVehicle);
    Task<Vehicle?> FindByIdVehicleAndOwner(int idVehicle, int idOwner);
    Task<IEnumerable<Vehicle>> GetAllAsync();
}