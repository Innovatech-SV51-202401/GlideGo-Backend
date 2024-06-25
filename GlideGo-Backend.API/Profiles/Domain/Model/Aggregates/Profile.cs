using GlideGo_Backend.API.Profiles.Domain.Model.Commands;
using GlideGo_Backend.API.Profiles.Domain.Model.ValueObjects;

namespace GlideGo_Backend.API.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public Profile()
    {
        Name = new PersonName();
        Age = new PersonAge();
        Contact = new PersonContact();
    }

    public Profile(string firstName, string lastName, int age, string number, string email)
    {
        Name = new PersonName(firstName, lastName);
        Age = new PersonAge(age);
        Contact = new PersonContact(email, number);
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Age = new PersonAge(command.Age);
        Contact = new PersonContact(command.Email, command.Number);
    }
    
    public int Id { get; }
    public PersonName Name { get; private set; }
    public PersonAge Age { get; private set; }
    public PersonContact Contact { get; private set; }
    
    public string FullName => Name.FullName;
    public int PersonAge => Age.Age;
    public string FullContact => Contact.FullContact;
}