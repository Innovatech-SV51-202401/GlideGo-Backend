using ACME.LearningCenterPlatform.API.Design.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Design.Domain.Model.Queries;

namespace ACME.LearningCenterPlatform.API.Design.Domain.Services;

public interface IVehicleQueryService
{
    Task<Vehicle?> Handle(GetAllVehicleQuery query);
}