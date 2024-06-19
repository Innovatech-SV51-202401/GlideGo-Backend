using System.Collections;
using ACME.LearningCenterPlatform.API.Design.Domain.Model.Entities;  
using ACME.LearningCenterPlatform.API.Design.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Design.Domain.Model.Aggregates;
public partial class Vehicle
{
    private int Id { get; set; }
    public EVehicleType Type { get; set; }
    public ICollection<Asset> Assets { get; private set; }
    public EVehicleStatus Status { get; private set; }
    public bool HasReadableAssets => Assets.Any(asset => asset.Readable);
    public bool HasviewableAssets => Assets.Any(asset => asset.Viewable);
    public bool Readable => HasReadableAssets;
    public bool Viaewable => HasviewableAssets;

    public Vehicle()
    {
        Type = EVehicleType.Bicycle; 
        Assets = new List<Asset>();
        Status = EVehicleStatus.Available;
    }
    
    public void ReserveVehicle()
    {
        if (Status == EVehicleStatus.Available) Status = EVehicleStatus.Reserved;
    }
    public void MakeVehicleAvailable()
    {
        if (Status == EVehicleStatus.Reserved) Status = EVehicleStatus.Available;
    }
    public void UseVehicle()
    {
        if (Status == EVehicleStatus.Available) Status = EVehicleStatus.InUse;
    }
    public void MakeVehicleUnavailable()
    {
        if (Status == EVehicleStatus.InUse) Status = EVehicleStatus.Unavailable;
    }
    
    public void AddAsset(Asset asset)
    {
        Assets.Add(asset);
    }
    
    public void RemoveAsset(Asset asset)
    {
        Assets.Remove(asset);
    }
    
    public void ClearAssets()
    {
        Assets.Clear();
    }

}