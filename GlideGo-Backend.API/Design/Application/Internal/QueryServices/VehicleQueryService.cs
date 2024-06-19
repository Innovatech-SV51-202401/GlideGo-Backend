using ACME.LearningCenterPlatform.API.Design.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Design.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACME.LearningCenterPlatform.API.Design.Domain.Model.Aggregates;

namespace ACME.LearningCenterPlatform.API.Design.Application.Internal.QueryServices
{
    public class VehicleQueryService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleQueryService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> HandleAsync(GetAllVehicleQuery query)
        {
            return await _vehicleRepository.GetAllAsync();
        }
    }
}