namespace GlideGo_Backend.API.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, int age, string number, string email);
}