namespace GlideGo_Backend.API.Profiles.Domain.Model.ValueObjects;

public record PersonAge(int Age)
{
    public PersonAge() : this(0) { }
}