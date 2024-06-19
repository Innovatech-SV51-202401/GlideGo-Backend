using ACME.LearningCenterPlatform.API.Design.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Design.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Design.Domain.Repositories;

namespace GlideGo_Backend.API.Design.Application.Internal.CommandServices
{
    public class VehicleCommandService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleCommandService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task HandleAsync(AddVehicleCommand command)
        {
            var vehicle = new Vehicle()
            {
                Type = command.Type
            };

            await _vehicleRepository.AddAsync(vehicle);
        }
    }
}