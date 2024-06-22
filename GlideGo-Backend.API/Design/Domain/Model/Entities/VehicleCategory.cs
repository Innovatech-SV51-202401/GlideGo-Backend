using GlideGo_Backend.API.Design.Domain.Model.ValueObjects;

namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public class VehicleCategory : IPublishable
{
    public int Id { get; }
    public AcmeVehicleIdentifier VehicleIdentifier { get; private set; }
    public EVehicleStatus Status { get; protected set; }
    public EVehicleCategory Category { get; private set; }
    public EVehicleSubCategory SubCategory { get; private set; }

    public VehicleCategory(EVehicleCategory category, EVehicleSubCategory subCategory)
    {
        VehicleIdentifier = new AcmeVehicleIdentifier();
        Category = category;
        SubCategory = subCategory;
        Status = EVehicleStatus.Available;
    }
    
    public virtual object GetContent()
    {
        return string.Empty;
    }
    
    public void SendToAvailable()
    {
        Status = EVehicleStatus.Available;
    }

    public void SendToUnavailable()
    {
        Status = EVehicleStatus.Unavailable;
    }

    public void SendToInUse()
    {
        Status = EVehicleStatus.InUse;
    }
}