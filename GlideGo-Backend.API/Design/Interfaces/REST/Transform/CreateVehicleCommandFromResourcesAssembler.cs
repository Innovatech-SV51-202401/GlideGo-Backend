using ACME.LearningCenterPlatform.API.Design.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Design.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Design.Interfaces.REST.Transform
{
    public static class CreateVehicleCommandFromResourceAssembler
    {
        public static AddVehicleCommand ToCommandFromResource(CreateVehicleResource resource)
        {
            return new AddVehicleCommand(resource.Type);
        }
    }
}