using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Interfaces.REST.Resources;

namespace GlideGo_Backend.API.Design.Interfaces.REST.Transform;

public static class VehicleResourceFromEntityAssembler
{
    public static VehicleResource ToResourceFromEntity(Vehicle entity) => new VehicleResource(entity.Id, entity.IdVehicle, entity.Category, entity.SubCategory, entity.IdOwner);
}