using GlideGo_Backend.API.Profiles.Domain.Model.Aggregates;
using GlideGo_Backend.API.Profiles.Domain.Model.Queries;

namespace GlideGo_Backend.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    
    Task<Profile?> Handle(GetProfileByIdQuery query);
}