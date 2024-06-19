using ACME.LearningCenterPlatform.API.Design.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Design.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Design.Domain.Services;

public interface IVehicleCommadService
{
    Task<Vehicle?> Handle(AddVehicleCommand command);
}