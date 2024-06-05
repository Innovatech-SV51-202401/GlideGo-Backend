namespace GlideGo_Backend.API.Profiles.Domain.Model.ValueObjects;

public record PersonContact(string Email, string Number)
{
    public PersonContact(): this(string.Empty, string.Empty)
    {
    }

    public PersonContact(string Email) : this(Email, string.Empty)
    {
        
    }

    public string FullContact => $"{Email}, {Number}";
}