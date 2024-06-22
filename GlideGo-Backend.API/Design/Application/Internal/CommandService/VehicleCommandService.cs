using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.Commands;
using GlideGo_Backend.API.Design.Domain.Repositories;
using GlideGo_Backend.API.Design.Domain.Services;
using GlideGo_Backend.API.Shared.Domain.Repositories;


namespace GlideGo_Backend.API.Design.Application.Internal.CommandService;

public class VehicleCommandService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork) : IVehicleCommandService
{
    public async Task<Vehicle?> Handle(CreateVehicleCommand command)
    {
        var vehicle = await vehicleRepository.FindByIdVehicleAndOwner(command.IdVehicle, command.IdOwner);
        if(vehicle != null) throw new Exception("Vehicle already exists");
        vehicle = new Vehicle(command);
        try
        {
            await vehicleRepository.AddAsync(vehicle);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return vehicle;
    }
}