using GlideGo_Backend.API.Design.Domain.Model.Entities;
using GlideGo_Backend.API.Design.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace GlideGo_Backend.API.Design.Infrastructure.Persistence.EFC.Repositorie;

public class LocationRepository(AppDbContext context) : BaseRepository<Location>(context), ILocationRepository
{
    
}