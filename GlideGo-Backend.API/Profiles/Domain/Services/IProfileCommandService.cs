using GlideGo_Backend.API.Profiles.Domain.Model.Aggregates;
using GlideGo_Backend.API.Profiles.Domain.Model.Commands;

namespace GlideGo_Backend.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}