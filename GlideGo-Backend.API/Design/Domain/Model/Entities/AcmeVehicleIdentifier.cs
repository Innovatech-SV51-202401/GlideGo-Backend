namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public record AcmeVehicleIdentifier(Guid Identifier)
{
    public AcmeVehicleIdentifier() : this(Guid.NewGuid()) { }
}