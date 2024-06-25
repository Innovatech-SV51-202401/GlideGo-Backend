namespace GlideGo_Backend.API.Profiles.Domain.Model.ValueObjects;

public record SpecialityName(string Speciality)
{
    public SpecialityName(): this(string.Empty)
    {
    }
}