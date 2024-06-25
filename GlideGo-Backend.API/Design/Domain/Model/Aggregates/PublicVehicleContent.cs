using GlideGo_Backend.API.Design.Domain.Model.ValueObjects;
using GlideGo_Backend.API.Design.Domain.Model.Entities;
using Microsoft.AspNetCore.Components.Web;


namespace GlideGo_Backend.API.Design.Domain.Model.Aggregates;

public partial class PublicationVehicle : IPublicActions
{
    public ICollection<Publication> Publications { get; }
    public EPublicStatus Status { get; protected set; }
    
    public bool HasElectricVehicle => Publications.Any(publication => publication.IsElectric);
    public bool IsElectric => HasElectricVehicle;

    public bool HasAllPublicationWithStatus(EPublicStatus status)
    {
        return Publications.All(publication => publication.Status == status);
    }


    public void SentToAvailable()
    {
        if (HasAllPublicationWithStatus(EPublicStatus.Available)) Status = EPublicStatus.Available;
    }

    public void SentToUnavailable()
    {
        if (HasAllPublicationWithStatus(EPublicStatus.Unavailable)) Status = EPublicStatus.Unavailable;
    }

    public void SentToInUse()
    {
        if (HasAllPublicationWithStatus(EPublicStatus.InUse)) Status = EPublicStatus.InUse;
    }

    public void SentToInReview()
    {
        if (HasAllPublicationWithStatus(EPublicStatus.InReview)) Status = EPublicStatus.InReview;
    }

    private List<PublicationContent> GetContent()
    {
        var content = new List<PublicationContent>();
        if (Publications.Any())
            content.AddRange(Publications.Select(publication =>
                new PublicationContent(publication.Type.ToString(), publication.Status.ToString(),
                    publication.GetPublic() as string ?? string.Empty)));
        return content;
    }

    private bool ExistBattery(EPublicType type) => Publications.Any(publication =>
        publication.Type == type && publication.IsElectric);

    public void AddElectricPublication(EPublicType type, Location location, Uri? imageUri, Guid idOwner)
    {
        if (ExistBattery(type)) Publications.Add(new ElectricPublication(location, imageUri, idOwner));
    }

    public void AddManualPublication(EPublicType type, Location location, Uri? imageUri, Guid idOwner, bool brake)
    {
        if (ExistBattery(type)) return;
        Publications.Add(new ManualPublication(location, imageUri, idOwner, brake));
    }

    public void RemovePublication(AcmePublicationIdentifier identifier)
    {
        var publication = Publications.FirstOrDefault(publication => publication.PublicationIdentifier == identifier);
        if (publication is not null) Publications.Remove(publication);
    }

    public void ClearPublics() => Publications.Clear();

}






