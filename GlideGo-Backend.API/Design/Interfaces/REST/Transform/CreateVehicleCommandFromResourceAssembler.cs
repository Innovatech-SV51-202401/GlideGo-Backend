using GlideGo_Backend.API.Design.Domain.Model.Commands;
using GlideGo_Backend.API.Design.Interfaces.REST.Resources;

namespace GlideGo_Backend.API.Design.Interfaces.REST.Transform;

public static class CreateVehicleCommandFromResourceAssembler
{
    public static CreateVehicleCommand ToCommandFromResource(CreateVehicleResource resource) => 
        new(resource.IdVehicle, resource.Category, resource.Subcategory, resource.IdOwner);
}