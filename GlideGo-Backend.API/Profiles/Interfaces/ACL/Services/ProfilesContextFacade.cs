using GlideGo_Backend.API.Profiles.Domain.Model.Commands;
using GlideGo_Backend.API.Profiles.Domain.Services;

namespace GlideGo_Backend.API.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    public async Task<int> CreateProfile(string firstName, string lastName, int age, string number, string email)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, age, number, email);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }
}