using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Queries;
namespace GlideGo_Backend.API.Execution_Monitor.Domain.Services;

public interface INewReservationQueryService
{
    Task<Reservation?> Handle(GetReservationByIdQuery query);
    Task<IEnumerable<Reservation>> Handle(GetAllReservationsByVehicleIdQuery query);
    
}