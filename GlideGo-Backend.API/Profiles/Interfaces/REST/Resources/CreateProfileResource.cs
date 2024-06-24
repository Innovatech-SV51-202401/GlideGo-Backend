namespace GlideGo_Backend.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, int Age, string Number, string Email);