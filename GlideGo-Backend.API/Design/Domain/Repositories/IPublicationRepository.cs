using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.ValueObjects;
using GlideGo_Backend.API.Shared.Domain.Repositories;

namespace GlideGo_Backend.API.Design.Domain.Repositories;

public interface IPublicationRepository : IBaseRepository<PublicationVehicle>
{
    Task<IEnumerable<PublicationVehicle>> FindByIdOwner(int idOwner);
    Task<IEnumerable<PublicationVehicle>> FindByStatus(EPublicStatus status);
}