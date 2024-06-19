using ACME.LearningCenterPlatform.API.Design.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Design.Domain.Model.Entities;

public partial class Asset : IPublishable
{
    public int Id { get; }
    public AcmeVehicleIdentifier VehicleIdentifier { get; private set; }
    public EVehicleStatus Status { get; protected set; }
    public EVehicleType Type { get; private set; }
    public virtual bool Readable => false;
    public virtual bool Viewable => false;

    public Asset(EVehicleType type)
    {
        Type = type;
        Status = EVehicleStatus.Available;
        VehicleIdentifier = new AcmeVehicleIdentifier();
    }
    
    public void ReserveVehicle()
    {
        Status = EVehicleStatus.Reserved;
    }
    
    public void MakeVehicleAvailable()
    {
        Status = EVehicleStatus.Available;
    }
    
    public void UseVehicle()
    {
        Status = EVehicleStatus.InUse;
    }
    
    public void MakeVehicleUnavailable()
    {
        Status = EVehicleStatus.Unavailable;
    }
    
}