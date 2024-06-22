using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.Queries;

namespace GlideGo_Backend.API.Design.Domain.Services;

public interface IVehicleQueryService
{
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesByIdOwner query);
    Task<Vehicle?> Handle(GetVehicleByIdVehicleAndOwner query);
    Task<Vehicle?> Handle(GetVehicleByIdVehicle query);
    
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);
}