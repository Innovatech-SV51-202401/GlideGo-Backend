using GlideGo_Backend.API.Profiles.Domain.Model.Aggregates;
using GlideGo_Backend.API.Profiles.Domain.Model.Commands;
using GlideGo_Backend.API.Profiles.Domain.Model.ValueObjects;

namespace GlideGo_Backend.API.Profiles.Domain.Model.Entities;

public class Mechanic : Profile
{
    public Mechanic() : base()
    {
        Speciality = new SpecialityName();
    }

    public Mechanic(string firstName, string lastName, int age, string number, string email, string speciality) 
        : base(firstName, lastName, age, number, email)
    {
        Speciality = new SpecialityName(speciality);
    }

    public Mechanic(CreateMechanicCommand command) : base(command.FirstName, command.LastName, command.Age, command.Number, command.Email)
    {
        Speciality = new SpecialityName(command.Speciality);
    }

    public SpecialityName Speciality { get; private set; }
}