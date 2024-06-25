namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public record AcmePublicationIdentifier(Guid Identifier)
{
    public AcmePublicationIdentifier() : this(Guid.NewGuid()) { }
}