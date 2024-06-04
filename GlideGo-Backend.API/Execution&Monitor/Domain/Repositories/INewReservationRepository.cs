using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;
using GlideGo_Backend.API.Shared.Domain.Repositories;
namespace GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;

public interface INewReservationRepository : IBaseRepository<Reservation>
{
    Task<Reservation?> FindByVehicleIdAsync(string vehicleId);
}