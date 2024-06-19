using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;

namespace GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;
public class ActiveServicesCommandService
{
    private readonly IActiveServicesRepository _repository;
    
    public ActiveServicesCommandService(IActiveServicesRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<ActiveServices>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    
    public async Task<ActiveServices> GetByIdAsync(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }
    
    public async Task AddAsync(ActiveServices activeServices)
    {
        await _repository.AddAsync(activeServices);
    }
    
    public async Task UpdateAsync(Guid id, ActiveServices updatedActiveServices)
    {
        var activeServices = await _repository.FindByIdAsync(id);
        if (activeServices != null)
        {
            activeServices.VehicleId = updatedActiveServices.VehicleId;
            activeServices.DistanceToUse = updatedActiveServices.DistanceToUse;
            activeServices.DurationToUse = updatedActiveServices.DurationToUse;
            activeServices.Location = updatedActiveServices.Location;
            
            _repository.Update(activeServices);
        }
    }
}