namespace GlideGo_Backend.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, int Age, string Number, string Email);