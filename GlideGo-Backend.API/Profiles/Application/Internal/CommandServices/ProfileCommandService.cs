using GlideGo_Backend.API.Profiles.Domain.Model.Aggregates;
using GlideGo_Backend.API.Profiles.Domain.Model.Commands;
using GlideGo_Backend.API.Profiles.Domain.Repositories;
using GlideGo_Backend.API.Profiles.Domain.Services;
using GlideGo_Backend.API.Shared.Domain.Repositories;

namespace GlideGo_Backend.API.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return profile;
    }
}