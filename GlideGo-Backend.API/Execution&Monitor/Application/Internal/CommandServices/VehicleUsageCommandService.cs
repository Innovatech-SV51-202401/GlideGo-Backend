using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;

namespace GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;
public class VehicleUsageCommandService
{
    private readonly IVehicleUsageRepository _repository;

    public VehicleUsageCommandService(IVehicleUsageRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VehicleUsage>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<VehicleUsage> GetByIdAsync(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task AddAsync(VehicleUsage vehicleUsage)
    {
        await _repository.AddAsync(vehicleUsage);
    }

    public async Task UpdateAsync(Guid id, VehicleUsage updatedVehicleUsage)
    {
        var vehicleUsage = await _repository.FindByIdAsync(id);
        if (vehicleUsage != null)
        {
            vehicleUsage.VehicleId = updatedVehicleUsage.VehicleId;
            vehicleUsage.UserId = updatedVehicleUsage.UserId;
            vehicleUsage.StartTime = updatedVehicleUsage.StartTime;
            vehicleUsage.EndTime = updatedVehicleUsage.EndTime;
            vehicleUsage.TotalDistance = updatedVehicleUsage.TotalDistance;
            vehicleUsage.MoneySaved = updatedVehicleUsage.MoneySaved;

            _repository.Update(vehicleUsage);
        }
    }
}