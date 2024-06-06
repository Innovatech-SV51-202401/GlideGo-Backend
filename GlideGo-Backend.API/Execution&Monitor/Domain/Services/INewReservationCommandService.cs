using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Commands;

namespace GlideGo_Backend.API.Execution_Monitor.Domain.Services;

public interface INewReservationCommandService
{
    Task<Reservation?> Handle(CreateReservationCommand command);
}