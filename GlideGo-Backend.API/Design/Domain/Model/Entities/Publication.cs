using GlideGo_Backend.API.Design.Domain.Model.ValueObjects;

namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public partial class Publication : IPublicActions
{
    public int Id { get; }
    public AcmePublicationIdentifier PublicationIdentifier { get; private set; }
    
    public EPublicStatus Status { get; private set; }
    public EPublicType Type { get; private set; }
    public Location Location { get; private set; }
    public Uri? ImageUri { get; private set; }
    
    public Guid IdOwner { get; }
    public double DistanceInKm { get; private set; }
    public double TimeInHours{ get; private set; }
    
    public virtual bool IsElectric => false;
    
    protected Publication() { }
    public Publication(EPublicType type, Location location, Uri? imageUri, Guid idOwner)
    {
        Type = type;
        Location= location;
        ImageUri = imageUri;
        DistanceInKm= 0;
        TimeInHours= 0;
        IdOwner = idOwner;
        Status = EPublicStatus.Available;
        PublicationIdentifier = new AcmePublicationIdentifier();
    }

    public virtual object GetPublic()
    {
        return string.Empty;
    }
    
    public void SentToAvailable()
    {
        Status=EPublicStatus.Available;
    }

    public void SentToUnavailable()
    {
        Status=EPublicStatus.Unavailable;
    }

    public void SentToInUse()
    {
        Status=EPublicStatus.InUse;
    }

    public void SentToInReview()
    {
        Status=EPublicStatus.InReview;
    }
}