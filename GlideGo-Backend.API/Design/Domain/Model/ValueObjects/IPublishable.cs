namespace ACME.LearningCenterPlatform.API.Design.Domain.Model.ValueObjects;

public interface IPublishable
{
    void ReserveVehicle();
    void MakeVehicleAvailable();
    void UseVehicle();
    void MakeVehicleUnavailable();
}