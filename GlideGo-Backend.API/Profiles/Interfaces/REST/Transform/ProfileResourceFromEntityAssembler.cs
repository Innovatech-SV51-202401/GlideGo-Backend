using GlideGo_Backend.API.Profiles.Domain.Model.Aggregates;
using GlideGo_Backend.API.Profiles.Interfaces.REST.Resources;

namespace GlideGo_Backend.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.PersonAge, entity.FullContact);
    }
}