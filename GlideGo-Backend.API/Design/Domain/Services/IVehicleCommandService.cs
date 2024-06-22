using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.Commands;

namespace GlideGo_Backend.API.Design.Domain.Services;

public interface IVehicleCommandService
{
    Task<Vehicle?> Handle(CreateVehicleCommand command);
}