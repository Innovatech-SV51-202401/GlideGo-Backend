namespace GlideGo_Backend.API.Profiles.Domain.Model.Commands;

public record CreateMechanicCommand(string FirstName, string LastName, int Age, string Number, string Email, string Speciality);