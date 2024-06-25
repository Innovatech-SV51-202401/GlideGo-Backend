using GlideGo_Backend.API.Design.Domain.Model.ValueObjects;

namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public class ElectricPublication : Publication
{
    public int BatteryCapacity { get; private set; }
    public override bool IsElectric => true;

    public override string GetPublic()
    {
        return BatteryCapacity!=0? BatteryCapacity.ToString() : "Rechargeable Battery Required";
    }
    
    protected ElectricPublication() { }

    public ElectricPublication(Location location, Uri? imageUri, Guid idOwner) : base(EPublicType.Electric,
        location, imageUri, idOwner)
    {
        BatteryCapacity= 0;
    }
    
    
}