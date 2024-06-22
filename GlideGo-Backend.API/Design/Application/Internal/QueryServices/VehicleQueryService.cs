using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.Queries;
using GlideGo_Backend.API.Design.Domain.Repositories;
using GlideGo_Backend.API.Design.Domain.Services;

namespace GlideGo_Backend.API.Design.Application.Internal.QueryServices;

public class VehicleQueryService(IVehicleRepository vehicleRepository) : IVehicleQueryService
{
    public async Task<Vehicle?> Handle(GetVehicleByIdQuery query)
    {
        return await vehicleRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesByIdOwner query)
    {
        return await vehicleRepository.FindAllByIdOwner(query.IdOwner);
    }

    public async Task<Vehicle?> Handle(GetVehicleByIdVehicleAndOwner query)
    {
        return await vehicleRepository.FindByIdVehicleAndOwner(query.IdVehicle, query.IdOwner);
    }

    public async Task<Vehicle?> Handle(GetVehicleByIdVehicle query)
    {
        return await vehicleRepository.FindByIdVehicle(query.IdVehicle);
    }
}