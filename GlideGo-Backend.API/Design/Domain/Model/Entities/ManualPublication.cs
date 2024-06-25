using GlideGo_Backend.API.Design.Domain.Model.ValueObjects;

namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public class ManualPublication : Publication
{
    public bool HaveBrakes { get; private set; }
    public override bool IsElectric => false;

    public override string GetPublic()
    {
        return "Vehicle Manual";
    }
    protected ManualPublication() { }

    public ManualPublication(Location location, Uri? imageUri, Guid idOwner, bool brakes) : base(EPublicType.Manual,
        location, imageUri, idOwner)
    {
        HaveBrakes= brakes;
    }
}