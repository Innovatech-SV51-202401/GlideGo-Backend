using GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;


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

    public async Task AddAsync(VehicleUsageDto dto)
    {
        var vehicleUsage = new VehicleUsage(dto.VehicleId, dto.UserId, dto.StartTime, dto.EndTime, dto.TotalDistance, dto.MoneySaved);
        await _repository.AddAsync(vehicleUsage);
    }

    public async Task UpdateAsync(Guid id, VehicleUsageDto dto)
    {
        var vehicleUsage = await _repository.FindByIdAsync(id);
        if (vehicleUsage != null)
        {
            vehicleUsage.VehicleId = dto.VehicleId;
            vehicleUsage.UserId = dto.UserId;
            vehicleUsage.StartTime = dto.StartTime;
            vehicleUsage.EndTime = dto.EndTime;
            vehicleUsage.TotalDistance = dto.TotalDistance;
            vehicleUsage.MoneySaved = dto.MoneySaved;

            _repository.Update(vehicleUsage);
        }
    }
}