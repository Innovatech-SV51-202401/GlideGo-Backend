using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Queries;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;
using GlideGo_Backend.API.Execution_Monitor.Domain.Services;

namespace GlideGo_Backend.API.Execution_Monitor.Application.Internal.QueryServices;

public class NewReservationQueryService : INewReservationQueryService
{
    private readonly INewReservationRepository _reservationRepository;

    public NewReservationQueryService(INewReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Reservation?> Handle(GetReservationByIdQuery query)
    {
        return await _reservationRepository.FindByVehicleIdAsync(query.Id);
    }

    public async Task<IEnumerable<Reservation>> Handle(GetAllReservationsByVehicleIdQuery query)
    {
        return await _reservationRepository.FindAllByVehicleIdAsync(query.VehicleId);
    }
}